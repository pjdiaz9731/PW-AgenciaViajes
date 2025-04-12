using BackendPr.AccesoDatos;
using BackendPr.Entidades.Response;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPr.logica
{
    public class LogicaLogin
    {
        public ResLoginUsuario Login (ResLoginUsuario req, ref string errorDesc)
        {
            ResLoginUsuario res = new ResLoginUsuario();
            res.error = new List<Error>();
            int? errorID = 0;
            string errorMessage = "";

            try
            {
                using (LinqConnecDataContext linq = new LinqConnecDataContext())
                {
                    // Llamada al procedimiento almacenado para login
                    var usuarioResult = linq.sp_Usuarios_Login(res.Login.usuario, res.Login.contrasena, ref errorID, ref errorMessage);
                    if (usuarioResult != null)
                    {
                        // Si el usuario es válido, se retorna el resultado exitoso
                        res.Resultado = true;
                        res.usuario = usuarioResult.usuario;
                        res.contrasena = usuarioResult.contrasena;

                    }
                    else
                    {
                        // Si no se encuentra el usuario o la contraseña es incorrecta
                        res.error.Add(new Error
                        {
                            codigoError = enumErrores.loginFallido,
                            errorMsg = "Usuario o contraseña incorrectos"
                        });
                        res.Resultado = false;
                    }

                }


            }
            catch (Exception ex)
            {
                // Capturamos cualquier excepción inesperada
                res.error.Add(new Error
                {
                    codigoError = enumErrores.errorNoControlado,
                    errorMsg = ex.Message
                });
                res.Resultado = false;
            }

            return res;
        }


    }
}
