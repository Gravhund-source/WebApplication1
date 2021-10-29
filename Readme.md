# ToDo asp.net MVC af Victor, Simone og Mikkel

- Clone Git projekt [Link til Git](https://github.com/Gravhund-source/WebApplication1.git)
- Opdatér de to connectionstrings i appsettings.json
- Lav ny migration (slet eksisterende først)

```bash
Add-Migration -Context [todo context navn]
- Opdatér database med EF
```

```bash
Add-Migration -Context [WebAplication1 context navn]
```

- Opdatér database med EF

```bash
Update-Database -Context [WebAplication1 context navn]
Update-Database -Context [todo context navn]
```

```sql
use master
Go
Create Database testDB
Go

USE testDB
GO
Create Table Todo(
ID int Identity Primary key not null,
[User] nvarchar (Max) not null,
Title nvarchar (Max) not null,
[Description] nvarchar(Max) not null,
)
GO
```

## God fornøjelse
