FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
RUN apt update && apt install -y nodejs
COPY ["Blog.Web/*.csproj", "Blog.Web/"]
COPY ["Blog.Application/*.csproj", "Blog.Application/"]
COPY ["Blog.Domain/*.csproj", "Blog.Domain/"]
COPY ["Blog.Infrastructure/*.csproj", "Blog.Infrastructure/"]
RUN dotnet restore "Blog.Web/Blog.Web.csproj"
COPY . .
WORKDIR "/src/Blog.Web"
RUN dotnet build "Blog.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Blog.Web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "Blog.Web.dll"]