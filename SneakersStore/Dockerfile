# Первый этап (сборка)
# Образ sdk
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

# Указание рабочей директории
WORKDIR /src

# Копирование проектов в контейнер (откуда/куда)
COPY ["SneakersStore.API/SneakersStore.API.csproj", "SneakersStore.API/"]
COPY ["SneakersStore.Application/SneakersStore.Application.csproj", "SneakersStore.Application/"]
COPY ["SneakersStore.Core/SneakersStore.Core.csproj", "SneakersStore.Core/"]
COPY ["SneakersStore.DataAccess/SneakersStore.DataAccess.csproj", "SneakersStore.DataAccess/"]

# Восстановление NuGet-пакетов
RUN dotnet restore "SneakersStore.API/SneakersStore.API.csproj"

# Копирование всего исходного кода
COPY . .

# Указание рабочей директории
WORKDIR "/src/SneakersStore.API"

RUN dotnet publish "SneakersStore.API.csproj" -c Release -o /app/publish --no-restore


# Второй этап (Продакшин, запуск уже собранного проекта, без sdk)
# Образ aspnet
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

# Указание рабочей директории
WORKDIR /app

# Явное указание порта
ENV ASPNETCORE_HTTP_PORTS=8080

EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SneakersStore.API.dll"]