using Entidades.DataContracts;
using System;
using System.Collections.Generic;

namespace Api_Web
{
    public class Funciones
    {
        Response GetError(Exception ex)
        {
            var ErrorDiccionary = new Dictionary<string, Response>
            {
                {
                   "Error1", new Response
                   {
                      ErrorCode = 1001,
                      Message = "Error 1",
                      Description = "Descripción del Error 1"
                   }

                },
                 {
                   "Error1", new Response
                   {
                      ErrorCode = 1001,
                      Message = "Error 1",
                      Description = "Descripción del Error 1"
                   }

                },
            };

            string errorKey = ex.GetType().Name;
            if(ErrorDiccionary.ContainsKey(errorKey))
            {
                return ErrorDiccionary[errorKey];
            }


            return new Response
            {
                ErrorCode = 500,
                Message = "Error desconocido",
                Description = "Se produjo un error desconocido"
            };
        }
    }
}
