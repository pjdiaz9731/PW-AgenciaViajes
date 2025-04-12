using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum enumErrores
    {
        errorEnBaseDatos = -2,
        errorNoControlado = -1,
        reqNulo = 0,
        nombreInvalido = 1,
        
        correoFaltante = 3,
        passwordFaltante = 4,
        correoNoValido = 5,
        passwordDebil = 6,
        cuentaNoVerificada = 7,
        credencialesNoValidas = 8,
        cuentaYaVerificada = 9,
        usuarioincorrecto= 10,
<<<<<<< HEAD
        FaltaTelefono = 11,
        SinMensaje = 12,
        fechainvalida =13,
        valorinvalido =14,
        noError = 15,
        errorBD = 16,
=======
        AsuntoFalta = 11,
        SinMensaje = 12,
        fechainvalida =13,
        valorinvalido =14,
        NoLink = 15,
        Nocoment = 16,
        loginFallido = 17,
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
    }
}
