#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["EshoppingCenter/EshoppingCenter.csproj", "EshoppingCenter/"]
RUN dotnet restore "EshoppingCenter/EshoppingCenter.csproj"
COPY . .
WORKDIR "/src/EshoppingCenter"
RUN dotnet build "EshoppingCenter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EshoppingCenter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EshoppingCenter.dll"]
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet EshoppingCenter.dll