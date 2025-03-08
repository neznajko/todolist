#
# Build Stage (uses full SDK), ( the comments are not from CGPT! )
#
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
#
# Copy project file and restore dependencies
#
COPY todolist.csproj .
RUN dotnet restore
#
# Copy the entire source code
#
COPY . .
#
# Build the app
#
RUN dotnet publish -c Release -o /app/published
#
# Runtime Stage (uses lightweight ASP.NET runtime image)
#
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
#
# Copy published output from the build stage
#
COPY --from=build /app/published .
#
# Copy the local database file into the container
#
COPY todolist.db .
#
# Expose port
#
EXPOSE 8080
#
# Start the application
#
CMD ["dotnet", "todolist.dll"]

