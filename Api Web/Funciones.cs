using Entidades.DataContracts;
using System;
using System.Collections.Generic;

namespace Api_Web
{
    public class Funciones
    {
        public LoginResponse GetError(Exception ex)
        {
            var ErrorDiccionary = new Dictionary<string, LoginResponse>
            {
                {
                   "ErrorUsuario", new LoginResponse
                   {
                      ErrorCode = 1001,
                      Message = "Error al ingresar el username",
                      Description = "No se encontro el usuario en la base de datos"
                   }

                },
                 {
                   "ErrorContraseña", new LoginResponse
                   {
                      ErrorCode = 1002,
                      Message = "Error al ingresar el password",
                      Description = "La contraseña ingresada es incorrecta"
                   }

                },
                 {
                   "TiempoRespuesta", new LoginResponse
                   {
                      ErrorCode = 1003,
                      Message = "Tiempo de respuesta excedido",
                      Description = "La solicitud ha excedido el tiempo de respuesta permitido"
                   }

                },
                  {
                    "ErrorConexionBD", new LoginResponse
                    {
                       ErrorCode = 1004,
                       Message = "Error de conexión a la base de datos",
                       Description = "No se pudo establecer una conexión a la base de datos."
                    }

                },
            };
            /*
            string errorKey = ex.GetType().Name;
            if (ErrorDiccionary.ContainsKey(errorKey))
            {
                return ErrorDiccionary[errorKey];
            }
            else
            {
            */
                string errorMessage = ex.Message;
                if (ErrorDiccionary.ContainsKey(errorMessage))
                {
                    return ErrorDiccionary[errorMessage];
                }
                else
                {
                    return new LoginResponse
                    {
                        ErrorCode = 500,
                        Message = "Error desconocido",
                        Description = "Se produjo un error desconocido"
                    };
                }
            
        }
    }
}
