using AutoMapper;
using BlazorCurso.Shared.DTOs;
using BlazorCurso.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Server.Helpers
{
    public class AutoMapperPerfiles:Profile
    {
        public AutoMapperPerfiles()
        {
            CreateMap<Persona, Persona>().ForMember(x=>x.Foto,option=>option.Ignore());
            CreateMap<Pelicula, Pelicula>().ForMember(x=>x.Poster,option=>option.Ignore());
        }
    }
}
