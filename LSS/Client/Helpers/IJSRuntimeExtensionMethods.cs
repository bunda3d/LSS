﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Client.Helpers
{
	public static class IJSRuntimeExtensionMethods
	{
		public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
		{
			await js.InvokeVoidAsync("console.log", "user deleting movie");
			return await js.InvokeAsync<bool>("confirm", message);
		}
		public static async ValueTask ConfirmDeleteMsg(this IJSRuntime js, string message)
		{
			await js.InvokeVoidAsync("confirmDeleteMsg", message);
		}
	}
}
