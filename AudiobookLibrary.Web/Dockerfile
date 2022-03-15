#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AudiobookLibrary.Web/AudiobookLibrary.Web.csproj", "AudiobookLibrary.Web/"]
COPY ["AudiobookLibrary.Core/AudiobookLibrary.Core.csproj", "AudiobookLibrary.Core/"]
RUN dotnet restore "AudiobookLibrary.Web/AudiobookLibrary.Web.csproj"
COPY . .
WORKDIR "/src/AudiobookLibrary.Web"
RUN dotnet build "AudiobookLibrary.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AudiobookLibrary.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AudiobookLibrary.Web.dll"]