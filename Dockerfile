# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# The React ClientApp is built via npm during `dotnet publish`,
# so Node.js must exist in this stage or the publish step fails.
RUN curl -fsSL https://deb.nodesource.com/setup_18.x | bash - \
    && apt-get install -y nodejs

# Restore NuGet packages first for better layer caching
COPY ["NBAGraphs.csproj", "./"]
RUN dotnet restore "NBAGraphs.csproj"

# Copy the rest and publish (this triggers npm install + npm run build)
COPY . .
RUN dotnet publish "NBAGraphs.csproj" -c Release -o /app/publish

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "NBAGraphs.dll"]