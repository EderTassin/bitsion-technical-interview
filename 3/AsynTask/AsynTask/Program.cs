
public static class TaskManager
{
    public static async Task<List<TResult>> GetResultsWithinTimeoutAsync<TResult>(
        IEnumerable<Task<TResult>> tasks, 
        TimeSpan timeout)
    {
        var remainingTasks = new List<Task<TResult>>(tasks);
        var results = new List<TResult>();
        var delayTask = Task.Delay(timeout);

        while (remainingTasks.Count > 0)
        {
            Task completedTask = await Task.WhenAny(remainingTasks.Append(delayTask));
            
            if (completedTask == delayTask)
                break;

            var completedTypedTask = (Task<TResult>)completedTask;
            remainingTasks.Remove(completedTypedTask);
            
            if (completedTypedTask.Status == TaskStatus.RanToCompletion)
            {
                results.Add(completedTypedTask.Result);
            }
        }

        return results;
    }


    public class Program
    {
        public static async Task Main(string[] args)
        {
            var tasks = new List<Task<int>> {
                Task.Delay(1000).ContinueWith(_ => 1),
                Task.Delay(3000).ContinueWith(_ => 2),
                Task.Delay(2000).ContinueWith(_ => 3),
                Task.Delay(4500).ContinueWith(_ => 4)
            };

            var results = await TaskManager.GetResultsWithinTimeoutAsync(tasks, TimeSpan.FromMilliseconds(4000));
            
            Console.WriteLine("Resultados completados:");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
