@echo off
dotnet ef migrations add AutoMigration_%date:~-4,4%%date:~-7,2%%date:~-10,2%_%time:~0,2%%time:~3,2%%time:~6,2%
dotnet ef database update