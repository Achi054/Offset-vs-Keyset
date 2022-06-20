# Keyset vs Offset pagination
The repository illustrates the perks of using `Keyset` over `Offset` for pagination.

## Problem statement
Performance implications of using `Offset` pagination and what are the alternatives for improvements.

[Why should I not use Offset?](https://use-the-index-luke.com/no-offset)

## Infrastructure
- _.net5.0 class library_ `KeySetPagination.DataAccess` <br/>
  The project is a _Data access layer_ containing database setup, context and repositories.
  
- _.net5.0 console application_ `KeySetPagination.Benchmark` <br/>
  The project is a _console application_ containing _Benchmark runner_ and _CRUD_ calls.

## Setup
Database setup requires to build and publish defined database schema.

_Initial migration_
```csharp
dotnet ef migrations add InitialMigration --project "KeySetPagination.DataAccess" --startup-project "KeySetPagination.Benchmark" -- "Data Source = <server-name>; Initial Catalog = EmployeeDB; Integrated Security = True; Connect Timeout = 60"
```

_Database setup_
```csharp
dotnet ef database update --project "KeySetPagination.DataAccess" --startup-project "KeySetPagination.Benchmark" -- "Data Source = <server-name>; Initial Catalog = EmployeeDB; Integrated Security = True; Connect Timeout = 60"
```

## Execution
Run below command for benchmark
```csharp
dotnet build -c Release

dotnet run -p "KeySetPagination.Benchmark\KeySetPagination.Benchmark.csproj" -c Release
```

## Reference
- [.NET Data Community Standup](https://www.youtube.com/watch?v=DIKH-q-gJNU)
- [MR.EntityFrameworkCore.KeysetPagination
 nuget from Mohammad Rahhal](https://github.com/mrahhal/MR.EntityFrameworkCore.KeysetPagination)