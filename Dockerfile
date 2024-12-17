# Use the official .NET image from Docker Hub for ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file to restore dependencies first
# Adjusted the path since 'team05project' is the root folder
COPY team05project/team_project.csproj ./ 

# Restore dependencies
RUN dotnet restore "team_project.csproj"

# Copy the rest of the application files from the root directory
COPY . ./

# Build the app
RUN dotnet build "team05project/team_project.csproj" -c Release -o /app/build

# Publish the app to a folder
FROM build AS publish
RUN dotnet publish "team05project.csproj" -c Release -o /app/publish

# Copy the built app to the base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Entry point for the application
ENTRYPOINT ["dotnet", "team05project.dll"]
