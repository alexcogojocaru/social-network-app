#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["SocialApp.csproj", ""]
RUN dotnet restore "./SocialApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SocialApp.csproj" -c Release -o /app/build

RUN dotnet publish "SocialApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet SocialApp.dll