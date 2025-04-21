using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace PizzaHut.Filters;

public class LatencyFilter : IActionFilter
{
    private readonly Stopwatch _stopwatch;

    public LatencyFilter()
    {
        _stopwatch = new Stopwatch();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch.Start();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();
        var latency = _stopwatch.ElapsedMilliseconds;
        Console.WriteLine($"Action {context.ActionDescriptor.DisplayName} took {latency} ms to execute.");
    }
}