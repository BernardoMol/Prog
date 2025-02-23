// https://www.youtube.com/watch?v=qBTe6uHJS_Y&list=PL82C6-O4XrHfrGOCPmKmwTO7M0avXyQKc&index=1
// dotnet new webapi -o api --> cria uma pasta configurada com o nome "api"
// dotnet watch run --> manda rodar a api (tem q ser usado dentro da pasta api)
// o arquivo "Program" é quase um "módulo", ele controla tudo
// dotnet ef migrations add ini --> comando para gerar os arquivos de migração, ou seja, modelar nossa tabela no banco de dados
// dotnet ef database update   --> comando para jogar nossa tabela no banco de dados
// ionstalamos "Newtonsoft.Json" e "Microsoft.AspNetCore.Mvc.NewtonsoftJson" da galeria NuGet 

// A partir do video 21 começamos a usar o JWT para pegar o email e fazer o login
// instalamos entao (pela NuGet gallery):
// 1 - Microsoft.Extension.Identity.Core
// 2 - Microsoft.AspNetCore.Identity.EntityFrameworkCore
// 3 - Microsoft.AspNetCore.Autentication.JwtBearer

// Comandos do final da aula 21
// dotnet ef migrations add Identity
// dotnet ef database update
// extremamente QUEBRADO, ja criou varais tabelas de dados no banco atravez do framework (pelo que entendi)


// eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJnaXZlbl9uYW1lIjoibW9sIiwiZW1haWwiOiJ1c2VyQGV4YW1wbGUuY29tIiwibmJmIjoxNzQwMzE1NTk5LCJleHAiOjE3NDA5MjAzOTksImlhdCI6MTc0MDMxNTU5OSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDg4IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MDg4In0.XyPxDfmW1Epgtq1Ulio-kGszoGaIn_-03dMSInwoXyB9aZIqjI4pS79qkLdJfOqxB3JUgOx2gj9YivRxATIftw