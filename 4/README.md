# Enunciado
## Diseña una clase en C# para un sistema de notificaciones que soporte correos electrónicos, SMS y notificaciones push, siguiendo principios SOLID.

#Solución

![Archivo con solucion](./Notificaciones.cs)

## Explicación

1. SRP (Single Responsibility): Cada interfaz y clase maneja un único tipo de notificación
2. OCP (Open/Closed): Fácil de extender con nuevos tipos de notificación
3. LSP (Liskov Substitution): Las implementaciones son sustituibles por sus interfaces
4. ISP (Interface Segregation): Interfaces específicas para cada tipo de notificación
5. DIP (Dependency Inversion): El servicio depende de abstracciones, no de implementaciones

