# Справка по Entity Freamwork


## Проблемы


### Проблемы при миграции


Если при попытке запустить утилиту миграции `dotnet ef migrations ...` возникает ошибка вида:
```
Unable to create an object of type 'Context'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
```
Решением будет создание фабрики вида:

```
public class ContextFactory : IDesignTimeDbContextFactory<Context> {
    public Context CreateDbContext(string[] args) {
        var optionsBuilder = new DbContextOptionsBuilder<Context>();
        optionsBuilder.UseSqlite("Filename=sqlite.db");

        return new Context(optionsBuilder.Options);
    }
} 
```
Класс унаследованный от `IDesignTimeDbContextFactory` покажет утилите миграции, как именно она сможет создать ваш контекст базы данных. 
Из кода фабрики видно, что метод `CreateDbContext(string[] args)` предполагает наличие конструктора у вашего контекста базы данных, 
поэтому его необходиму будет создать самостоятельно:

```
public class Context : DbContext {
    public DbSet<User> Users { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Filename=sqlite.db");
    }
}
```
