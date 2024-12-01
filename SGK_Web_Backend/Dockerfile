# Base Image for Running the Application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ./SGK_Web_Backend/SGK_Web_Backend.csproj ./SGK_Web_Backend.csproj
RUN dotnet restore "./SGK_Web_Backend.csproj"

# Copy the entire project and build it
COPY ./SGK_Web_Backend ./SGK_Web_Backend
WORKDIR /src/SGK_Web_Backend
RUN dotnet build "SGK_Web_Backend.csproj" -c Release -o /app/build

# Publish Stage
FROM build AS publish
RUN dotnet publish "SGK_Web_Backend.csproj" -c Release -o /app/publish

# Final Stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "SGK_Web_Backend.dll"]
