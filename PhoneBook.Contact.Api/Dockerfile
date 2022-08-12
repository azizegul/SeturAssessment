FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PhoneBook.Contact.Api/PhoneBook.Contact.Api.csproj", "PhoneBook.Contact.Api/"]
RUN dotnet restore "PhoneBook.Contact.Api/PhoneBook.Contact.Api.csproj"
COPY . .
WORKDIR "/src/PhoneBook.Contact.Api"
RUN dotnet build "PhoneBook.Contact.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhoneBook.Contact.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhoneBook.Contact.Api.dll"]
