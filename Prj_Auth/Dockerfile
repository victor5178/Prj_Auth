#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Prj_Auth/Prj_Auth.csproj", "Prj_Auth/"]
RUN dotnet restore "Prj_Auth/Prj_Auth.csproj"
COPY . .
WORKDIR "/src/Prj_Auth"
RUN dotnet build "Prj_Auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Prj_Auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prj_Auth.dll"]