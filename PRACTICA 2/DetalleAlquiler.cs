using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICA_2
{
    internal class DetalleAlquiler
    {
        private int cantVehiculosAlquilados;
        private DateTime fechaRetiro;
        private int cantDias;
        public DetalleAlquiler() { }
        public DetalleAlquiler(int cantVehiculosAlquilados, DateTime fechaRetiro, int cantDias)
        {
            this.cantVehiculosAlquilados = cantVehiculosAlquilados;
            this.fechaRetiro = fechaRetiro;
            this.cantDias = cantDias;
        }
        public int getCantVehiculosAlquilados() { return cantVehiculosAlquilados; }
        public DateTime getFechaRetiro() {  return fechaRetiro; }
        public int getCantDias() {  return cantDias; }
        public void setCantVehiculosAlquilados(int cantVehiculosAlquilados) { this.cantVehiculosAlquilados = cantVehiculosAlquilados; }
        public void setFechaRetiro(DateTime fechaRetiro) { this.fechaRetiro=fechaRetiro; }
        public void setCantDias(int cantDias) { this.cantDias=cantDias; }
    }
}
