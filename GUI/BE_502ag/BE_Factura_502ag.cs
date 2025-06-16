using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_Factura_502ag
    {
        private int codFactura;
        private string dniCliente;
        private DateTime? fecha;
        private TimeSpan? hora;
        private string metodoPago;
        private decimal? monto;
        private string nombreCliente;
        private string apellidoCliente;
        private int codCombustible;
        private decimal? cantCargada;
        private bool isFacturado;
        private int estadoFactura;
        private string nombreCombustible;

        public int CodFactura_502ag { get; set; }
        public string DNICliente_502ag { get; set; }
        public DateTime Fecha_502ag { get; set; }
        public TimeSpan Hora_502ag { get; set; }
        public string MetodoPago_502ag { get; set; }
        public decimal Monto_502ag { get; set; }
        public string NombreCliente_502ag { get; set; }
        public string ApellidoCliente_502ag { get; set; }
        public int CodCombustible_502ag { get; set; }
        public decimal CantCargada_502ag { get; set; }
        public bool IsFacturado_502ag { get; set; }
        public int EstadoFactura_502ag { get; set; } 
        public string NombreCombustible_502ag { get; set; }

        //constructor para el alta de la factura
        public BE_Factura_502ag(int pCodFactura_502ag, int pCodCombustible_502ag)
        {
            CodFactura_502ag = pCodFactura_502ag;
            CodCombustible_502ag = pCodCombustible_502ag;
        }
        //constructor para la factura final 
        public BE_Factura_502ag(int pCodFactura_502ag, string pDNICliente_502ag, DateTime pFecha_502ag, TimeSpan pHora_502ag, string pMetodoPago_502ag, decimal pMonto_502ag, string pNombreCliente_502ag, string pApellidoCliente_502ag, int pCodCombustible_502ag, decimal pCantCargada_502ag, bool pIsFacturado_502ag, int pEstadoFactura_502ag, string pNombreCombustible_502ag)
        {
            CodFactura_502ag = pCodFactura_502ag;
            DNICliente_502ag = pDNICliente_502ag;
            Fecha_502ag = pFecha_502ag;
            Hora_502ag = pHora_502ag;
            MetodoPago_502ag = pMetodoPago_502ag;
            Monto_502ag = pMonto_502ag;
            NombreCliente_502ag = pNombreCliente_502ag;
            ApellidoCliente_502ag = pApellidoCliente_502ag;
            CodCombustible_502ag = pCodCombustible_502ag;
            CantCargada_502ag = pCantCargada_502ag;
            IsFacturado_502ag = pIsFacturado_502ag;
            EstadoFactura_502ag = pEstadoFactura_502ag;
            NombreCombustible_502ag = pNombreCombustible_502ag;
        }

        //constructor para cuando el estado de la factura es 1 
        public BE_Factura_502ag(int pCodFactura_502ag, int pCodCombustible_502ag, bool pIsFacturado_502ag, int pEstadoFactura_502ag, DateTime pFecha_502ag, TimeSpan pHora_502ag)
        {
            CodFactura_502ag = pCodFactura_502ag;
            CodCombustible_502ag = pCodCombustible_502ag;
            IsFacturado_502ag = pIsFacturado_502ag;
            EstadoFactura_502ag = pEstadoFactura_502ag;
            Fecha_502ag = pFecha_502ag;
            Hora_502ag = pHora_502ag;
        }

        //constructor para cuando el estado de la factura es 2
        public BE_Factura_502ag(int pCodFactura_502ag, int pCodCombustible_502ag, bool pIsFacturado_502ag, int pEstadoFactura_502ag, DateTime pFecha_502ag, TimeSpan pHora_502ag, decimal pMonto_502ag, decimal pCantCargada_502ag)
        {
            CodFactura_502ag = pCodFactura_502ag;
            CodCombustible_502ag = pCodCombustible_502ag;
            IsFacturado_502ag = pIsFacturado_502ag;
            EstadoFactura_502ag = pEstadoFactura_502ag;
            Fecha_502ag = pFecha_502ag;
            Hora_502ag = pHora_502ag;
            Monto_502ag = pMonto_502ag;
            CantCargada_502ag = pCantCargada_502ag;
        }

        //constructor para cuando el estado de la factura es 3
        public BE_Factura_502ag(int pCodFactura_502ag, int pCodCombustible_502ag, bool pIsFacturado_502ag, int pEstadoFactura_502ag, DateTime pFecha_502ag, TimeSpan pHora_502ag, decimal pMonto_502ag, decimal pCantCargada_502ag, string pDNICliente_502ag, string pNombreCliente_502ag, string pApellidoCliente_502ag)
        {
            CodFactura_502ag = pCodFactura_502ag;
            CodCombustible_502ag = pCodCombustible_502ag;
            IsFacturado_502ag = pIsFacturado_502ag;
            EstadoFactura_502ag = pEstadoFactura_502ag;
            Fecha_502ag = pFecha_502ag;
            Hora_502ag = pHora_502ag;
            Monto_502ag = pMonto_502ag;
            CantCargada_502ag = pCantCargada_502ag;
            DNICliente_502ag = pDNICliente_502ag;
            NombreCliente_502ag = pNombreCliente_502ag;
            ApellidoCliente_502ag = pApellidoCliente_502ag;

        }
    }
}
