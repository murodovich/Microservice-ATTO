#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Microservice_exam_project_6_month/src/University.Service/University.Api/University.Api.csproj", "Microservice_exam_project_6_month/src/University.Service/University.Api/"]
COPY ["Microservice_exam_project_6_month/src/University.Service/University.Application/University.Application.csproj", "Microservice_exam_project_6_month/src/University.Service/University.Application/"]
COPY ["Microservice_exam_project_6_month/src/University.Service/University.Domain/University.Domain.csproj", "Microservice_exam_project_6_month/src/University.Service/University.Domain/"]
COPY ["Microservice_exam_project_6_month/src/University.Service/University.Infrastructure/University.Infrastructure.csproj", "Microservice_exam_project_6_month/src/University.Service/University.Infrastructure/"]
RUN dotnet restore "./Microservice_exam_project_6_month/src/University.Service/University.Api/./University.Api.csproj"
COPY . .
WORKDIR "/src/Microservice_exam_project_6_month/src/University.Service/University.Api"
RUN dotnet build "./University.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./University.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "University.Api.dll"]