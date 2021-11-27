using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Client.Helpers
{
    public static class IJSRuntimeExtendionMethods
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string mensaje)
        {
            return await js.InvokeAsync<bool>("confirm",mensaje);
        }
    }
}
