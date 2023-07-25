FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers

RUN dotnet restore
# Build and publish a release
 #RUN dotnet ef migrations add InitialCreate
#RUN dotnet ef database update
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App

COPY --from=build-env /App/out .
ENV ASPNETCORE_URLS http://*:443

# Exponer el puerto 80 del contenedor al host

EXPOSE 4433
# docker build -t counternet -f Dockerfile .
# docker run --name counternet -p 3545:80 -d counternet

ENTRYPOINT ["dotnet", "Backrest.dll"]