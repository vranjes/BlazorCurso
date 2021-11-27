using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Client.Helpers
{
    public class MostrarMensajes : IMostrarMensajes
    {
        public Task MostrarMensajeError(string mensaje)
        {
            return Task.FromResult(0);
        }
    }
}
