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
<<<<<<< HEAD
        public ResInsertarContacto Insertar(ResInsertarContacto req)
        {
            // Inicializamos el objeto de respuesta
            ResInsertarContacto res = new ResInsertarContacto();
            res.error = new List<Error>();

            // Validaciones del usuario
            if (string.IsNullOrWhiteSpace(req.Contacto.nombre))
            {
                // Validación: El nombre es requerido
=======
        public ResInsertarContacto Insertar (ResInsertarContacto req, ref string errorDesc)
        {
            ResInsertarContacto res = new ResInsertarContacto();
            res.error = new List<Error>();
            // Validaciones del usuario
            if (string.IsNullOrWhiteSpace(req.Contacto.Nombre))
            {
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
                res.error.Add(new Error
                {
                    codigoError = enumErrores.nombreInvalido,
                    errorMsg = "Nombre requerido"
                });
            }

<<<<<<< HEAD
            if (string.IsNullOrWhiteSpace(req.Contacto.email))
            {
                // Validación: El correo electrónico es requerido
=======
            if (string.IsNullOrWhiteSpace(req.Contacto.Email))
            {
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
                res.error.Add(new Error
                {
                    codigoError = enumErrores.correoFaltante,
                    errorMsg = "Correo requerido"
                });
            }

<<<<<<< HEAD
            if (string.IsNullOrWhiteSpace(req.Contacto.telefono))
            {
                // Validación: El número de teléfono es requerido
                res.error.Add(new Error
                {
                    codigoError = enumErrores.FaltaTelefono,
                    errorMsg = "Por favor ingresar numero de telefono"
                });
            }

            if (string.IsNullOrWhiteSpace(req.Contacto.mensaje))
            {
                // Validación: El mensaje es requerido
=======

            if (string.IsNullOrWhiteSpace(req.Contacto.Direccion))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.AsuntoFalta,
                    errorMsg = "Ingrese una direccion valida"
                });
            }
            if (string.IsNullOrWhiteSpace(req.Contacto.Mensaje))
            {
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
                res.error.Add(new Error
                {
                    codigoError = enumErrores.SinMensaje,
                    errorMsg = "Ingrese su mensaje"
                });
            }

            // Si hubo errores en la validación, regresamos el resultado con errores
            if (res.error.Any())
            {
<<<<<<< HEAD
                res.Resultado = false; // Indicamos que la operación no fue exitosa
                return res; // Retornamos el objeto de respuesta con los errores
            }

            // Si todo está bien, procedemos a insertar el usuario en la base de datos
            int? idUsuario = 0; // Variable para almacenar el ID del usuario insertado
            int? errorBD = 0; // Variable para almacenar el código de error de la base de datos
            string errorDesc = ""; // Variable para almacenar la descripción del error

=======
                res.Resultado = false;
                return res;
            }

            // Si todo está bien, insertamos el usuario en la base de datos
            int? idUsuario = 0;
            int? errorBD = 0;
            errorDesc = "";
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
            using (LinqConnecDataContext linq = new LinqConnecDataContext())
            {
                // Llamada al procedimiento almacenado para insertar el usuario
                linq.sp_MensajesContacto_Insertar(
<<<<<<< HEAD
                    req.Contacto.nombre,
                    req.Contacto.email, 
                    req.Contacto.telefono,
                    req.Contacto.mensaje, 
                    req.Contacto.direccion,
                    ref errorBD, 
                    ref errorDesc
                );
            }

            // Retornamos el objeto de respuesta (puede ser extendido para incluir más información)
            return res;
=======
                     req.Contacto.Nombre,
                      req.Contacto.Email,
                    req.Contacto.Telefono,
                     req.Contacto.Mensaje,
                     req.Contacto.Direccion,
                    
                        ref errorBD,
                    ref errorDesc);
            }
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
        }
    }
}
