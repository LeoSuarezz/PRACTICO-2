using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICA_2
{
    internal class Alquiler
    {
        private int numAlquiler;
        private int precioTotalAlquiler;
        private int documentoCliente;
        private int telefonoCliente;
        private string nombreCliente;
        private string apellidoCliente;
        private DetalleAlquiler detalle;
        List<Vehiculo> listaVehiculosAlquilados;
        
        public Alquiler() { }
        public Alquiler(int numAlquiler, int precioTotalAlquiler, int documentoCliente, int telefonoCliente, string nombreCliente, string apellidoCliente, int cantVehiculosAlquilados, DateTime fechaRetiro, int cantDias)
        {
            this.numAlquiler = numAlquiler;
            this.precioTotalAlquiler = precioTotalAlquiler;
            this.documentoCliente = documentoCliente;
            this.telefonoCliente = telefonoCliente;
            this.nombreCliente = nombreCliente;
            this.apellidoCliente = apellidoCliente;
            this.detalle = new DetalleAlquiler(cantVehiculosAlquilados, fechaRetiro, cantDias);
            this.listaVehiculosAlquilados = new List<Vehiculo>();
        }

        public int getNumAlquiler() {  return numAlquiler; }
        public int getPrecioTotalAlquiler() { return precioTotalAlquiler;}
        public int getDocumentoCliente() {  return documentoCliente;}
        public int getTelefonoCliente() { return telefonoCliente;}
        public string getNombreCliente() { return nombreCliente;}
        public string getApellidoCliente() { return apellidoCliente;}
        public DetalleAlquiler getDetalleAlquiler() { return detalle;}
        public List<Vehiculo> getListaVehiculos() { return listaVehiculosAlquilados;}
        public void setNumAlquiler(int numAlquiler) { this.numAlquiler = numAlquiler;}
        public void setPrecioTotalAlquiler(int precioTotalAlquiler) { this.precioTotalAlquiler =  precioTotalAlquiler;}
        public void setDocumentoCliente(int documentoCliente) { this.documentoCliente = documentoCliente;}
        public void setTelefonoCliente(int telefonoCliente) { this.telefonoCliente  = telefonoCliente;}
        public void setNombreCliente(string nombreCliente) { this.nombreCliente =  nombreCliente;}
        public void setApellidoCliente(string apellidoCliente) { this.apellidoCliente = apellidoCliente;}
        public void setDetalleAlquiler(DetalleAlquiler detalle) { this.detalle = detalle;}
        public void setListaVehiculos(List<Vehiculo> listaVehiculos) { this.listaVehiculosAlquilados = listaVehiculos;}

    }

}
