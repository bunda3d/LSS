using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;
using Microsoft.JSInterop.Implementation;

namespace LSS.Client.Pages
{
  public partial class Counter
  {
    [Inject] private IJSRuntime js { get; set; }

    private int currentCount = 0;
    private static int currentCountStatic = 0;
    private IJSObjectReference module;

    [JSInvokable]
    public async Task IncrementCountAsync()
    {
      var array = new double[] { 1, 2, 3, 4, 5 };
      var max = array.Maximum();
      var min = array.Minimum();

      module = await js.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
      await module.InvokeVoidAsync("displayAlert", $"Max is {max} and min is {min}");

      currentCount++;
      currentCountStatic++;
      await js.InvokeVoidAsync("dotnetStaticInvocation");
    }

    [JSInvokable]
    public static Task<int> GetCurrentCount()
    {
      return Task.FromResult(currentCountStatic);
    }
  }
}