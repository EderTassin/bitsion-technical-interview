# Enunciado

## Sugiera y aplique mejoras (como optimización de consultas, uso de caché, o ajuste de Entity Framework).

# Solución

- Utilizar Indices y normalizacion de tablas.

- Consultas mas optimizadas.

```csharp
var users = await _context.Users
    .Where(u => u.IsActive)
    .Select(u => new { u.Id, u.Name, u.Email }) // Solo columnas necesarias
    .ToListAsync();
```

```csharp
modelBuilder.Entity<User>()
    .HasIndex(u => u.Email) // Índice para búsquedas por Email
    .IsUnique();
```

- Utilizar DTOs para evitar el uso de la clase de entidad en el controlador.


