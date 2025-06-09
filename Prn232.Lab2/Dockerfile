# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Prn232.Lab2/Prn232.Lab2.csproj", "Prn232.Lab2/"]
COPY ["Lab2.Repo/Lab2.Repo.csproj", "Lab2.Repo/"]
COPY ["Lab2.Service/Lab2.Service.csproj", "Lab2.Service/"]
COPY ["LabPrn232.ServiceDefaults/LabPrn232.ServiceDefaults.csproj", "LabPrn232.ServiceDefaults/"]
RUN dotnet restore "./Prn232.Lab2/Prn232.Lab2.csproj"
COPY . .
WORKDIR "/src/Prn232.Lab2"
RUN dotnet build "./Prn232.Lab2.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Prn232.Lab2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prn232.Lab2.dll"]