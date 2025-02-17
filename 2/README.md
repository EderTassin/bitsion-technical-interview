# Ejercicio: Diseño de Arquitectura Distribuida para Sistema Financiero

## Objetivo
Diseñar una arquitectura distribuida para un sistema de gestión de transacciones financieras utilizando .NET Core.

# Solucion

## Diagrama de Arquitectura

![Diagrama de Arquitectura](./diagrama.png)

## Explicación

### Autenticación

Para la autenticación se utiliza IdentityServer4 para manejar los tokens y el login de usuarios.

### Autorización

Para la autorización se utiliza ASP.NET Core Identity para manejar los roles y permisos de los usuarios.

### Logging y Monitoring

Para el logging y monitoring se utiliza Azure Insihts para manejar los logs y manejar las metricas.

### Escalabilidad

Para la escalabilidad se utiliza Azure App Service para manejar el balanceo de carga y kubernetes para manejar el despliegue de los microservicios.



