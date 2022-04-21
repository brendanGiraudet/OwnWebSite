#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM nginx:alpine AS base
WORKDIR /app
EXPOSE 4043

FROM emscripten/emsdk:3.0.1 AS build
RUN wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb; dpkg -i packages-microsoft-prod.deb;rm packages-microsoft-prod.deb
RUN apt-get update; apt-get install -y apt-transport-https && \
    apt-get update && \
    apt-get install -y dotnet-sdk-6.0
WORKDIR /src
RUN dotnet workload install wasm-tools
COPY ["./Website.csproj", "Website/"]
WORKDIR "/src/Website"
RUN dotnet restore "./Website.csproj"
COPY . .
RUN dotnet build "Website.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Website.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY "./nginx.conf" /etc/nginx/nginx.conf