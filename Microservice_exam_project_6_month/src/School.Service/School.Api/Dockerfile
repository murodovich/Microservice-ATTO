FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Microservice_exam_project_6_month/src/School.Service/School.Api/School.Api.csproj", "Microservice_exam_project_6_month/src/School.Service/School.Api/"]
COPY ["Microservice_exam_project_6_month/src/School.Service/School.Application/School.Application.csproj", "Microservice_exam_project_6_month/src/School.Service/School.Application/"]
COPY ["Microservice_exam_project_6_month/src/School.Service/School.Domain/School.Domain.csproj", "Microservice_exam_project_6_month/src/School.Service/School.Domain/"]
COPY ["Microservice_exam_project_6_month/src/School.Service/School.Infrastructure/School.Infrastructure.csproj", "Microservice_exam_project_6_month/src/School.Service/School.Infrastructure/"]
RUN dotnet restore "./Microservice_exam_project_6_month/src/School.Service/School.Api/./School.Api.csproj"
COPY . .
WORKDIR "/src/Microservice_exam_project_6_month/src/School.Service/School.Api"
RUN dotnet build "./School.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./School.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "School.Api.dll"]