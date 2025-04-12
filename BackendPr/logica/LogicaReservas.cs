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
        public ResInsertarReserva Insertar(ResInsertarReserva req)
        {
            ResInsertarReserva res = new ResInsertarReserva();
            res.error = new List<Error>();

            try
            {
                // Validación inicial: Verificar si el request o la reserva es nula
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
                if (req.Reservas.CheckIn == default || req.Reservas.CheckOut == default)
                {
                    // Validar que las fechas de check-in y check-out no sean valores por defecto
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.fechainvalida,
                        errorMsg = "Fechas de check-in y check-out requeridas"
                    });
                }
                else if (req.Reservas.CheckIn >= req.Reservas.CheckOut)
                {
                    // Validar que la fecha de check-out sea posterior a la de check-in
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.fechainvalida,
                        errorMsg = "La fecha de check-out debe ser posterior al check-in"
                    });
                }

                // Validación de cantidad de personas
                if (req.Reservas.CantidadPersonas <= 0)
                {
                    // Validar que al menos haya una persona en la reserva
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.valorinvalido,
                        errorMsg = "Debe ingresar al menos un adulto"
                    });
                }

                // Si hay errores en las validaciones, retornar el resultado con los errores
                if (res.error.Any())
                {
                    res.Resultado = false;
                    return res;
                }

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
                // Manejo de excepciones no controladas
                res.error.Add(new Error
                {
                    codigoError = enumErrores.errorNoControlado,
                    errorMsg = ex.Message
                });
                res.Resultado = false;
            }

            // Retornar el resultado final
            return res;
        }
    }
}
