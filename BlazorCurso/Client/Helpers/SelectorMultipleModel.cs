﻿namespace BlazorCurso.Client.Helpers
{
    public struct SelectorMultipleModel
    {
        public SelectorMultipleModel(string llave, string valor){
            Llave = llave;
            Valor = valor;
        }

        public string Llave { get; set; }
        public string Valor { get; set; }
    }
}
