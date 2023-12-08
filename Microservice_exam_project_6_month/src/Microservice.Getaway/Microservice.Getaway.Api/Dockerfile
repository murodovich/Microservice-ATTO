#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Microservice_exam_project_6_month/src/Microservice.Getaway/Microservice.Getaway.Api/Microservice.Getaway.Api.csproj", "Microservice_exam_project_6_month/src/Microservice.Getaway/Microservice.Getaway.Api/"]
RUN dotnet restore "./Microservice_exam_project_6_month/src/Microservice.Getaway/Microservice.Getaway.Api/./Microservice.Getaway.Api.csproj"
COPY . .
WORKDIR "/src/Microservice_exam_project_6_month/src/Microservice.Getaway/Microservice.Getaway.Api"
RUN dotnet build "./Microservice.Getaway.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Microservice.Getaway.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.Getaway.Api.dll"]