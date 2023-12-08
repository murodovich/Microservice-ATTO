#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Microservice_exam_project_6_month/src/Transport.Service/Transport.Api/Transport.Api.csproj", "Microservice_exam_project_6_month/src/Transport.Service/Transport.Api/"]
COPY ["Microservice_exam_project_6_month/src/Transport.Service/Transport.Application/Transport.Application.csproj", "Microservice_exam_project_6_month/src/Transport.Service/Transport.Application/"]
COPY ["Microservice_exam_project_6_month/src/Transport.Service/Transport.Domain/Transport.Domain.csproj", "Microservice_exam_project_6_month/src/Transport.Service/Transport.Domain/"]
COPY ["Microservice_exam_project_6_month/src/Transport.Service/Transport.Infrastructure/Transport.Infrastructure.csproj", "Microservice_exam_project_6_month/src/Transport.Service/Transport.Infrastructure/"]
RUN dotnet restore "./Microservice_exam_project_6_month/src/Transport.Service/Transport.Api/./Transport.Api.csproj"
COPY . .
WORKDIR "/src/Microservice_exam_project_6_month/src/Transport.Service/Transport.Api"
RUN dotnet build "./Transport.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Transport.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transport.Api.dll"]