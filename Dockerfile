# Use the official .NET image from Docker Hub for ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app  # Work in the /app directory, which is the root directory of the container

# Copy the .csproj file to restore dependencies first
COPY team05project/team_project.csproj ./  # Corrected path for team_project.csproj

# Restore dependencies
RUN dotnet restore "team_project.csproj"

# Copy the rest of the application files into the container
COPY team05project/ .  # Copy everything from the team05project folder

# Build the app
RUN dotnet build "team_project.csproj" -c Release -o /app/build

# Publish the app to a folder
FROM build AS publish
RUN dotnet publish "team05project/team_project.csproj" -c Release -o /app/publish

# Copy the built app to the base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .  # Copy the published files into the base image

# Entry point for the application
ENTRYPOINT ["dotnet", "team05project.dll"]  # Adjusted the DLL file name for team05project
