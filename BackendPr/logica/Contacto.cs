using BackendPr.AccesoDatos;
using BackendPr.Entidades;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPr.logica
{
    public class Contacto
    {
        public ResInsertarContacto Insertar(ResInsertarContacto req, string errorDesc)
        {
            ResInsertarContacto res = new ResInsertarContacto();
            res.error = new List<Error>();
            // Validaciones del usuario
            if (string.IsNullOrWhiteSpace(req.Contacto.nombre))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.nombreInvalido,
                    errorMsg = "Nombre requerido"
                });
            }

            if (string.IsNullOrWhiteSpace(req.Contacto.email))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.correoFaltante,
                    errorMsg = "Correo requerido"
                });
            }


            if (string.IsNullOrWhiteSpace(req.Contacto.asunto))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.AsuntoFalta,
                    errorMsg = "Por favor ingresar asunto"
                });
            }
            if (string.IsNullOrWhiteSpace(req.Contacto.mensaje))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.SinMensaje,
                    errorMsg = "Ingrese su mensaje"
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
            errorDesc = "";
            using (LinqConnecDataContext linq = new LinqConnecDataContext())
            {
                // Llamada al procedimiento almacenado para insertar el usuario
                linq.sp_Contacto_Insertar(
                    req.Contacto.nombre,
                    req.Contacto.email,
                    req.Contacto.asunto,
                    req.Contacto.mensaje,
                    ref idUsuario,
                    ref errorBD,
                    errorDesc);
            }
        }
    }
}
