# Enunciado

## Explique cómo identificaría los cuellos de botella.

# Solución

- Utilizar las herramientas EF Core Logging, SQL Server Profiler o Application Insights.

- Consultas utiles para identificar cuellos de botella en SQL Server:

```sql  
-- Identificar consultas lentas
SELECT 
    qs.execution_count,
    qs.total_logical_reads / qs.execution_count as avg_logical_reads,
    SUBSTRING(qt.text,qs.statement_start_offset/2, 
        (CASE WHEN qs.statement_end_offset = -1 
            THEN LEN(CONVERT(NVARCHAR(MAX), qt.text)) * 2 
            ELSE qs.statement_end_offset END - qs.statement_start_offset)/2) AS query_text
FROM sys.dm_exec_query_stats qs
CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) qt
ORDER BY avg_logical_reads DESC;

-- Fragmentación de índices
SELECT 
    OBJECT_NAME(ips.object_id) AS TableName,
    i.name AS IndexName,
    ips.avg_fragmentation_in_percent
FROM sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, NULL) ips
INNER JOIN sys.indexes i ON ips.object_id = i.object_id
    AND ips.index_id = i.index_id
WHERE ips.avg_fragmentation_in_percent > 30;
```


