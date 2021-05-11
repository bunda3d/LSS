function confirmDeleteMsg(message) {
	console.log("from utilities script " + message);
}

function dotnetStaticInvocation() {
	DotNet.invokeMethodAsync("LSS.Client", "GetCurrentCount")
		.then(result => {
			console.log("Count from javascript dotnet invocation " + result);
		})
}

function dotnetInstanceInvocation(dotnetHelper) {
	dotnetHelper.invokeMethodAsync("IncrementCount");
}