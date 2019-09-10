FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Happy5SocialMedia.Activity/Happy5SocialMedia.Activity.csproj", "Happy5SocialMedia.Activity/"]
COPY ["Happy5SocialMedia.Common/Happy5SocialMedia.Common.csproj", "Happy5SocialMedia.Common/"]
RUN dotnet restore "Happy5SocialMedia.Activity/Happy5SocialMedia.Activity.csproj"
COPY . .
WORKDIR "/src/Happy5SocialMedia.Activity"
RUN dotnet build "Happy5SocialMedia.Activity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Happy5SocialMedia.Activity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Happy5SocialMedia.Activity.dll"]
