FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["../MicroQuiz.Services.Quizzes/src/MicroQuiz.Services.Quizzes.Api/MicroQuiz.Services.Quizzes.Api.csproj", "../MicroQuiz.Services.Quizzes/src/MicroQuiz.Services.Quizzes.Api/"]
COPY ["../MicroQuiz.Services.Quizzes/src/MicroQuiz.Services.Quizzes.Application/MicroQuiz.Services.Quizzes.Application.csproj", "../MicroQuiz.Services.Quizzes/src/MicroQuiz.Services.Quizzes.Application/"]
COPY ["../MicroQuiz.Services.Quizzes/src/MicroQuiz.Services.Quizzes.Core/MicroQuiz.Services.Quizzes.Core.csproj", "../MicroQuiz.Services.Quizzes/src/MicroQuiz.Services.Quizzes.Core/"]
COPY ["../MicroQuiz.Services.Quizzes/src/MicroQuiz.Services.Quizzes.Infrastructure/MicroQuiz.Services.Quizzes.Infrastructure.csproj", "../MicroQuiz.Services.Quizzes/src/MicroQuiz.Services.Quizzes.Infrastructure/"]
RUN dotnet restore "../MicroQuiz.Services.Quizzes/src/MicroQuiz.Services.Quizzes.Api/MicroQuiz.Services.Quizzes.Api.csproj"
COPY . .
WORKDIR "/src/../MicroQuiz.Services.Quizzes/src/MicroQuiz.Services.Quizzes.Api"
RUN dotnet build "MicroQuiz.Services.Quizzes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroQuiz.Services.Quizzes.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroQuiz.Services.Quizzes.Api.dll"]
