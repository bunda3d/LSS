using LSS.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Client.Pages
{
	public partial class Counter
	{

		[Inject] SingletonService singleton { get; set; }
		[Inject] TransientService transient { get; set; }
		[Inject] IJSRuntime js { get; set; }

		private int currentCount = 0;
		private static int currentCountStatic = 0;
		//the datatype of the variable that allows for js isolation via only downloading as needed.
		IJSObjectReference module;

		[JSInvokable]
		public async Task IncrementCountAsync()
		{
			module = await js.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
			await module.InvokeVoidAsync("displayAlert", "This is part of a JS Isolation scheme to only download JS files when called (when you click on the counter button)");
			currentCount++;
			singleton.Value += 1;
			transient.Value += 1;
			currentCountStatic++;
			await js.InvokeVoidAsync("dotnetStaticInvocation");
		}
		
		private async Task IncrementCountJavaScript()
		{
			await js.InvokeVoidAsync("dotnetStaticInvocation",
					DotNetObjectReference.Create(this));
		}


		[JSInvokable]
		public static Task<int> GetCurrentCount()
		{
			return Task.FromResult(currentCountStatic);
		}

		private List<Movie> movies;

		protected override void OnInitialized()
		{
			movies = new List<Movie>()
		{
			new Movie(){Title = "Joker", ReleaseDate = new DateTime(2019, 10, 4) },
			new Movie(){Title = "Avengers", ReleaseDate = new DateTime(2012, 5, 12) }
		};
		}
	}
}
