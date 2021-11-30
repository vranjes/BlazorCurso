using BlazorCurso.Shared.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCurso.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable,PaginacionDTO paginacion)
        {
            return queryable.Skip((paginacion.Pagina - 1) * paginacion.CantidadRegistros).Take(paginacion.CantidadRegistros);
        }
    }
}
