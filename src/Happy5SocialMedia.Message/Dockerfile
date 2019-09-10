FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Happy5SocialMedia.Message/Happy5SocialMedia.Message.csproj", "Happy5SocialMedia.Message/"]
COPY ["Happy5SocialMedia.Common/Happy5SocialMedia.Common.csproj", "Happy5SocialMedia.Common/"]
RUN dotnet restore "Happy5SocialMedia.Message/Happy5SocialMedia.Message.csproj"
COPY . .
WORKDIR "/src/Happy5SocialMedia.Message"
RUN dotnet build "Happy5SocialMedia.Message.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Happy5SocialMedia.Message.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Happy5SocialMedia.Message.dll"]
