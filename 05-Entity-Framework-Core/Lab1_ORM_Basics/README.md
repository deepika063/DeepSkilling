# Lab 1 - Understanding ORM with EF Core

## What is ORM?

ORM (Object Relational Mapping) maps C# classes to SQL database tables.

Example:

Product class  ---> Products table

Benefits:

- Less SQL code
- Easy maintenance
- Faster development
- Strongly typed queries

## EF Core vs EF Framework

Entity Framework

- Windows only
- Older version

EF Core

- Cross-platform
- Faster
- Lightweight
- Supports LINQ
- Async queries
- Compiled queries

## EF Core 8 Features

- JSON Column Mapping
- Better Performance
- Compiled Models
- Interceptors
- Bulk Operations

## Create Project

```bash
dotnet new console -n RetailInventory
cd RetailInventory
```

## Install Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```
