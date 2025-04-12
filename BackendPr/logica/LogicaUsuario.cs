using BackendPr.AccesoDatos;
using BackendViajes.Entidades;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

public class LogicaUsuario
{
    public ResInsertarUsuario Insertar(ReqInsertarUsuario req)
    {
        ResInsertarUsuario res = new ResInsertarUsuario();

        res.error = new List<Error>();

        try

        {

            // Validación: si el request o el objeto usuario son nulos
            if (req == null || req.Usuario == null)
            {

                res.error.Add(new Error
                {
                    codigoError = enumErrores.reqNulo,
                    errorMsg = "El request o el objeto usuario es nulo"
                });
                res.Resultado = false;
                return res;
            }

            // Validaciones del usuario
            if (string.IsNullOrWhiteSpace(req.Usuario.NombreCompleto))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.nombreInvalido,
                    errorMsg = "Nombre completo requerido"
                });
            }

            if (string.IsNullOrWhiteSpace(req.Usuario.Email))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.correoFaltante,
                    errorMsg = "Correo requerido"
                });
            }
            else if (!EsCorreoValido(req.Usuario.Email))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.correoNoValido,
                    errorMsg = "Correo no válido"
                });
            }

            if (string.IsNullOrWhiteSpace(req.Usuario.Contrasena))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.passwordFaltante,
                    errorMsg = "Contraseña requerida"
                });
            }
            else if (!EsPasswordFuerte(req.Usuario.Contrasena))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.passwordDebil,
                    errorMsg = "Contraseña débil"
                });
            }

            // Si hubo errores en la validación, regresamos el resultado con errores
            if (res.error.Any())
            {
                res.Resultado = false;
                return res;
            }

            // Si todo está bien, insertamos el usuario en la base de datos
            int? idUsuario = 0;
            int? errorBD = 0;
            string errorDesc = "";

            using (LinqConnecDataContext linq = new LinqConnecDataContext())
            {
                // Llamada al procedimiento almacenado para insertar el usuario
                linq.sp_Usuarios_Insertar(
                    req.Usuario.NombreCompleto,
                    req.Usuario.usuario,
                    req.Usuario.Contrasena,
                    req.Usuario.Email,
                    ref errorBD,
                    ref errorDesc
                );

                // Verificamos si la inserción fue exitosa
                if (idUsuario <= 0 || errorBD != 0)
                {
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.errorEnBaseDatos,
                        errorMsg = errorDesc
                    });
                    res.Resultado = false;
                }
                else
                {
                    res.Resultado = true;
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

    // Método auxiliar para validar si un correo es válido
    private bool EsCorreoValido(string correo)
    {
        try
        {
            var addr = new MailAddress(correo);
            return addr.Address == correo;
        }
        catch
        {
            return false;
        }
    }

    // Método auxiliar para validar si una contraseña es fuerte
    private bool EsPasswordFuerte(string password)
    {
        var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
        return regex.IsMatch(password);
    }
}