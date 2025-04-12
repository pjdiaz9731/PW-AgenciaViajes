using BackendViajes.Entidades;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

public class ValidarUsuario
{
    public ResValidacionUsuarios Validar(ResValidacionUsuarios req)
    {
        // Crear una nueva instancia de ResValidacionUsuarios para almacenar el resultado
        ResValidacionUsuarios res = new ResValidacionUsuarios();
        res.error = new List<Error>();

        // Definir el nombre de usuario esperado
        string usuarioEsperado = "Usuario";

        // Validar si el nombre completo del usuario coincide con el esperado
        if (req.Usuario.NombreCompleto != usuarioEsperado)
        {
            // Agregar un error a la lista si el nombre no coincide
            res.error.Add(new Error
            {
                codigoError = enumErrores.usuarioincorrecto,
                errorMsg = "Nombre completo incorrecto"
            });
        }

        // Retornar el resultado de la validación
        return res;
    }
}
