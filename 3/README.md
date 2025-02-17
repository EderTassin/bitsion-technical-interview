# Enunciado

## Escribe una función en C# que reciba una lista de tareas asíncronas y devuelva los resultados completados más rápido que un tiempo límite especificado.

# Solución

![Archivo con solucion](./AsynTask/AsynTask/Program.cs)

## Explicación

- La función `GetResultsWithinTimeoutAsync` recibe una lista de tareas asíncronas y un tiempo límite. Utiliza `Task.WhenAny` para obtener la primera tarea que se completa y `Task.Delay` para manejar el tiempo límite.