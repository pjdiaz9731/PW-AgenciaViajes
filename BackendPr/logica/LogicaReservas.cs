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
        public ResInsertarReserva Insertar (ResInsertarReserva req, string errorDesc)
        {
            ResInsertarReserva res = new ResInsertarReserva();
            res.error = new List<Error>();
            List<sp_Reservas_PorUsuarioResult> miListaTipoComplejo2 = new List<sp_Reservas_PorUsuarioResult>();
            try
            {
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
                if (req.Reservas.checkIn == default || req.Reservas.checkOut == default)
                {
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.fechainvalida,
                        errorMsg = "Fechas de check-in y check-out requeridas"
                    });
                }
                else if (req.Reservas.checkIn >= req.Reservas.checkOut)
                {
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.fechainvalida,
                        errorMsg = "La fecha de check-out debe ser posterior al check-in"
                    });
                }

                // Validación de cantidad de adultos
                if (req.Reservas.CantidadAdultos <= 0)
                {
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.valorinvalido,
                        errorMsg = "Debe ingresar al menos un adulto"
                    });
                }

                if (res.error.Any())
                {
                    res.Resultado = false;
                    return res;
                }

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
