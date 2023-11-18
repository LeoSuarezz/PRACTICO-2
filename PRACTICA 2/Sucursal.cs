using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICA_2
{
    internal class Sucursal
    {
        private int numSucursal;
        private string direccion;
        List<Vehiculo> listaVehiculos;
        List<Alquiler> listaAlquileres;

        public Sucursal() { }

        public Sucursal(int numSucursal, string direccion, List<Vehiculo> listaVehiculos, List<Alquiler> listaAlquileres)
        {
            this.numSucursal = numSucursal;
            this.direccion = direccion;
            this.listaVehiculos = listaVehiculos;
            this.listaAlquileres = listaAlquileres;
        }

        public int getNumSucursal() { return numSucursal; }
        public string getDireccion() { return direccion; }
        public List<Vehiculo> getVehiculos() { return listaVehiculos; }
        public List<Alquiler> getAlquiler() { return listaAlquileres; }
        public void setNumSucursal(int numSucursal) { this.numSucursal = numSucursal; }
        public void setDireccion(string direccion) { this.direccion = direccion; }
        public void setVehiculos(List<Vehiculo> listaVehiculos) { this.listaVehiculos = listaVehiculos; }
        public void setAlquileres(List<Alquiler> listaAlquileres) { this.listaAlquileres = listaAlquileres; }

        public void mostrarVehiculos(List<Vehiculo> listaVehiculos)
        { 
            var utilitarios = listaVehiculos.OfType<Utilitario>().ToList();
            var deportivos = listaVehiculos.OfType<Deportivo>().ToList();
            var familiares = listaVehiculos.OfType<Familiar>().ToList();

            Console.WriteLine("Vehículos Deportivos:");
            if (deportivos.Count > 0)
            {
                foreach (Deportivo vehiculo in deportivos)
                {
                    Console.WriteLine($"    Código n° {vehiculo.getNumVehiculo()} - Marca: {vehiculo.getMarca()} - Color: {vehiculo.getColor()} - km/lts: {vehiculo.getKmLitro()} - Velocidad máxima: {vehiculo.getVelocidadMaxima()}km/h - Precio: ${vehiculo.getPrecio()} por día");
                }
            }
            Console.WriteLine("\n Vehículos Familiar:");
            if (familiares.Count > 0)
            {
                foreach (Familiar vehiculo in familiares)
                {
                    Console.WriteLine($"    Código n° {vehiculo.getNumVehiculo()} - Marca: {vehiculo.getMarca()} - Color: {vehiculo.getColor()} - km/lts: {vehiculo.getKmLitro()} - Capacidad maletero: {vehiculo.getCapacidadMaletero()}lts - Precio: ${vehiculo.getPrecio()} por día");
                }
            }
            Console.WriteLine("\n Vehículos Utilitarios:");
            if (utilitarios.Count > 0)
            {
                foreach (Utilitario vehiculo in utilitarios)
                {
                    Console.WriteLine($"    Código n° {vehiculo.getNumVehiculo()} - Marca: {vehiculo.getMarca()} - Color: {vehiculo.getColor()} - km/lts: {vehiculo.getKmLitro()} - Capacidad carga: {vehiculo.getCapacidadCarga()}Kgs - Precio: ${vehiculo.getPrecio()} por día");
                }
            }
        }

        public void mostrarVehiculosDisponibles(List<Vehiculo> listaVehiculos)
        {
            var utilitarios = listaVehiculos.OfType<Utilitario>().ToList();
            var deportivos = listaVehiculos.OfType<Deportivo>().ToList();
            var familiares = listaVehiculos.OfType<Familiar>().ToList();

            Console.WriteLine("Vehículos Deportivos disponibles:");
            foreach (Deportivo vehiculo in deportivos)
            {
                if (vehiculo.getEstado() == true) 
                {
                    Console.WriteLine($"    Código n° {vehiculo.getNumVehiculo()} - Marca: {vehiculo.getMarca()} - Color: {vehiculo.getColor()} - km/lts: {vehiculo.getKmLitro()} - Velocidad máxima: {vehiculo.getVelocidadMaxima()}km/h - Precio: ${vehiculo.getPrecio()} por día");
                }
            }

            Console.WriteLine("\n Vehículos Familiares disponibles:");
            foreach (Familiar vehiculo in familiares)
            {
                if (vehiculo.getEstado() == true) 
                {
                    Console.WriteLine($"    Código n° {vehiculo.getNumVehiculo()} - Marca: {vehiculo.getMarca()} - Color: {vehiculo.getColor()} - km/lts: {vehiculo.getKmLitro()} - Capacidad maletero: {vehiculo.getCapacidadMaletero()}lts - Precio: ${vehiculo.getPrecio()} por día");
                }
            }

            Console.WriteLine("\n Vehículos Utilitarios disponibles:");
            foreach (Utilitario vehiculo in utilitarios)
            {
                if (vehiculo.getEstado() == true) 
                {
                    Console.WriteLine($"    Código n° {vehiculo.getNumVehiculo()} - Marca: {vehiculo.getMarca()} - Color: {vehiculo.getColor()} - km/lts: {vehiculo.getKmLitro()} - Capacidad carga: {vehiculo.getCapacidadCarga()}Kgs - Precio: ${vehiculo.getPrecio()} por día");
                }
            }
        }

        public void mostrarAlquileres(List<Alquiler> listaAlquileres)
        {
            foreach (Alquiler alquiler in listaAlquileres)
            {
                Console.WriteLine($"    Código n° {alquiler.getNumAlquiler()} - {alquiler.getNombreCliente()} {alquiler.getApellidoCliente()} " +
                    $"- Cantidad de vehículos: {alquiler.getDetalleAlquiler().getCantVehiculosAlquilados()} - Cantidad de días: {alquiler.getDetalleAlquiler().getCantDias()} " +
                    $"- Costo total: ${alquiler.getPrecioTotalAlquiler()}");
            }
        }

        public void AgregarVehiculoDeportivo(int numVehiculo, string matricula, string marca, string color, int capacidadTanque, bool estado, int precio, int kmLitro, int velocidadMaxima)
        {
            Deportivo deportivo = new Deportivo();
            deportivo.setNumVehiculo(numVehiculo);
            deportivo.setMatricula(matricula);
            deportivo.setMarca(marca);
            deportivo.setColor(color);
            deportivo.setCapacidadTanque(capacidadTanque);
            deportivo.setEstado(estado);
            deportivo.setPrecio(precio);
            deportivo.setKmLitro(kmLitro);
            deportivo.setVelocidadMaxima(velocidadMaxima);
            listaVehiculos.Add(deportivo);
        }
        public void AgregarVehiculoFamiliar(int numVehiculo, string matricula, string marca, string color, int capacidadTanque, bool estado, int precio, int kmLitro, int capMaletero)
        {
            Familiar familiar = new Familiar();
            familiar.setNumVehiculo(numVehiculo);
            familiar.setMatricula(matricula);
            familiar.setMarca(marca);
            familiar.setColor(color);
            familiar.setCapacidadTanque(capacidadTanque);
            familiar.setEstado(estado);
            familiar.setPrecio(precio);
            familiar.setKmLitro(kmLitro);
            familiar.setCapacidadMaletero(capMaletero);
            listaVehiculos.Add(familiar);
        }
        public void AgregarVehiculoUtilitario(int numVehiculo, string matricula, string marca, string color, int capacidadTanque, bool estado, int precio, int kmLitro, int capacidadCarga)
        {
            Utilitario utilitario = new Utilitario();
            utilitario.setNumVehiculo(numVehiculo);
            utilitario.setMatricula(matricula);
            utilitario.setMarca(marca);
            utilitario.setColor(color);
            utilitario.setCapacidadTanque(capacidadTanque);
            utilitario.setEstado(estado);
            utilitario.setPrecio(precio);
            utilitario.setKmLitro(kmLitro);
            utilitario.setCapacidadCarga(capacidadCarga);
            listaVehiculos.Add(utilitario);
        }
        
        public void AgregarAlquier(int numAlquiler, int precioTotalAlquiler, int documentoCliente, int telefonoCliente, string nombreCliente, string apellidoCliente, int cantVehiculosAlquilados, DateTime fechaRetiro, int cantDias)
        {

            Alquiler alquiler = new Alquiler(numAlquiler, precioTotalAlquiler,documentoCliente,telefonoCliente,nombreCliente,apellidoCliente,cantVehiculosAlquilados,fechaRetiro,cantDias); 
            listaAlquileres.Add(alquiler);
        }

       
        public List<Alquiler> DarAlquileresPorDocumento(int documento)
        {
            
            List<Alquiler> colAlquileresCliente = new List<Alquiler>();
            foreach (Alquiler item in this.listaAlquileres)
            {              
                if (item.getDocumentoCliente() == documento)
                {
                    colAlquileresCliente.Add(item);
                }
            }
            return colAlquileresCliente;
        }
    }

}
