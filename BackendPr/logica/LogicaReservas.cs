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
    public class LogicaReservas
    {
<<<<<<< HEAD
        public ResInsertarReserva Insertar(ResInsertarReserva req)
        {
            ResInsertarReserva res = new ResInsertarReserva();
            res.error = new List<Error>();

            try
            {
                // Validación inicial: Verificar si el request o la reserva es nula
=======
        public ResInsertarReserva Insertar (ResInsertarReserva req, string errorDesc)
        {
            ResInsertarReserva res = new ResInsertarReserva();
            res.error = new List<Error>();
            List<sp_Reservas_PorUsuarioResult> miListaTipoComplejo2 = new List<sp_Reservas_PorUsuarioResult>();
            try
            {
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
                if (req == null || req.Reservas == null)
                {
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.reqNulo,
                        errorMsg = "El request o la reserva es nula"
                    });
                    res.Resultado = false;
                    return res;
                }

                // Validaciones de fechas
<<<<<<< HEAD
                if (req.Reservas.CheckIn == default || req.Reservas.CheckOut == default)
                {
                    // Validar que las fechas de check-in y check-out no sean valores por defecto
=======
                if (req.Reservas.checkIn == default || req.Reservas.checkOut == default)
                {
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.fechainvalida,
                        errorMsg = "Fechas de check-in y check-out requeridas"
                    });
                }
<<<<<<< HEAD
                else if (req.Reservas.CheckIn >= req.Reservas.CheckOut)
                {
                    // Validar que la fecha de check-out sea posterior a la de check-in
=======
                else if (req.Reservas.checkIn >= req.Reservas.checkOut)
                {
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.fechainvalida,
                        errorMsg = "La fecha de check-out debe ser posterior al check-in"
                    });
                }

<<<<<<< HEAD
                // Validación de cantidad de personas
                if (req.Reservas.CantidadPersonas <= 0)
                {
                    // Validar que al menos haya una persona en la reserva
=======
                // Validación de cantidad de adultos
                if (req.Reservas.CantidadAdultos <= 0)
                {
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.valorinvalido,
                        errorMsg = "Debe ingresar al menos un adulto"
                    });
                }

<<<<<<< HEAD
                // Si hay errores en las validaciones, retornar el resultado con los errores
=======
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
                if (res.error.Any())
                {
                    res.Resultado = false;
                    return res;
                }

<<<<<<< HEAD
                // Variables para manejar el resultado de la operación en la base de datos
                int? idReserva = 0;
                int? errorBD = 0;
                string errorDesc = "";

                // Llamada al procedimiento almacenado para insertar la reserva
                using (LinqConnecDataContext linq = new LinqConnecDataContext())
                {
                    linq.sp_Reservas_Insertar(
                        req.Reservas.UsuarioID,
                        req.Reservas.CantidadPersonas,
                        req.Reservas.CheckIn,
                        req.Reservas.CheckOut,
                        ref errorBD,
                        ref errorDesc
                    );
                }

                // Validar el resultado de la operación en la base de datos
=======
                int? idReserva = 0;
                int? errorBD = 0;
                errorDesc = "";

                using (LinqConnecDataContext linq = new LinqConnecDataContext())
                {
                    linq.sp_Reservas_Insertar(
                          req.usuarioID,                        // UsuarioID - INT?
                         req.Reservas.CantidadAdultos,        // CantidadPersonas - INT?
                            req.Reservas.checkIn,                // CheckIn - DATETIME
                         req.Reservas.checkOut,               // CheckOut - DATETIME
                                ref errorBD,                         // ErrorID - OUTPUT
                                 errorDesc
                                 );
                    miListaTipoComplejo2 = linq.sp_Reservas_PorUsuario(req.usuarioID).ToList();
                }

>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
                if (idReserva <= 0 || errorBD != 0)
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
            catch (Exception ex)
            {
<<<<<<< HEAD
                // Manejo de excepciones no controladas
=======
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
                res.error.Add(new Error
                {
                    codigoError = enumErrores.errorNoControlado,
                    errorMsg = ex.Message
                });
                res.Resultado = false;
            }

<<<<<<< HEAD
            // Retornar el resultado final
            return res;
        }
=======
            return res;
        }

>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
    }
}
