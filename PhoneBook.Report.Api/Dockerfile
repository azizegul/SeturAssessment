FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PhoneBook.Report.Api/PhoneBook.Report.Api.csproj", "PhoneBook.Report.Api/"]
RUN dotnet restore "PhoneBook.Report.Api/PhoneBook.Report.Api.csproj"
COPY . .
WORKDIR "/src/PhoneBook.Report.Api"
RUN dotnet build "PhoneBook.Report.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhoneBook.Report.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhoneBook.Report.Api.dll"]
