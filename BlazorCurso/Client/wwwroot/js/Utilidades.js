function pruebaPuntoNetStatic() {
	DotNet.invokeMethodAsync("BlazorCurso.Client", "ObtenerCurrentCount").
		then(resultado => {
			console.log("conteo desde javascript " + resultado);
		});
}

function pruebaPuntoNetInstancia(dotnetHelper) {
	dotnetHelper.invokeMethodAsync("IncrementCount");
}