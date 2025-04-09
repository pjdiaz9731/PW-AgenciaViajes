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
        ResValidacionUsuarios res = new ResValidacionUsuarios();
        res.error = new List<Error>();

        
        string usuarioEsperado = "Usuario"; // Ajusta esto según tu lógica real

        if (req.Usuario.NombreCompleto != usuarioEsperado)
        {
            res.error.Add(new Error
            {
                codigoError = enumErrores.usuarioincorrecto,
                errorMsg = "Nombre completo incorrecto"
            });
        }

        return res;
    }
}
