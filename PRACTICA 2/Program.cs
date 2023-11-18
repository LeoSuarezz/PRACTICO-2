using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICA_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deportivo deportivo1 = new Deportivo(01, "CEI001", "Ferrari", "Rojo", 60, false, 1500, 5, 350);
            Deportivo deportivo2 = new Deportivo(02, "CEI002", "Porsche", "Negro", 50, true, 1000, 7, 290);
            Deportivo deportivo3 = new Deportivo(03, "CEI002", "Mercedes Benz", "Plateado", 60, true, 1200, 8, 250);

            Familiar familiar1 = new Familiar(04, "CEI003", "Toyota", "Gris", 70, false, 250, 13, 400);
            Familiar familiar2 = new Familiar(05, "CEI004", "Hyundai", "Azul", 80, false, 300, 16, 500);
            Familiar familiar3 = new Familiar(06, "CEI004", "Suzuki", "Blanco", 50, true, 200, 15, 350);

            Utilitario utilitario1 = new Utilitario(07, "CEI007", "JAC", "Blanco", 100, true, 500, 15, 2000); 
            Utilitario utilitario2 = new Utilitario(08, "CEI008", "Nissan", "Azul", 90, false, 700, 12, 1800);
            Utilitario utilitario3 = new Utilitario(09, "CEI009", "Toyota", "Verde", 80, true, 600, 11, 2100);

            Alquiler alquiler1 = new Alquiler(01, 8750, 11111, 101010, "Lionel", "Messi", 2, DateTime.Today, 5);
            var vehiculosAlquilados1 = new List<Vehiculo>();
            vehiculosAlquilados1.Add(deportivo1);
            vehiculosAlquilados1.Add(familiar1);

            Alquiler alquiler2 = new Alquiler(02, 1500, 22222, 202020, "Luis", "Suarez", 1, DateTime.Today, 5);
            var vehiculosAlquilados2 = new List<Vehiculo>();
            vehiculosAlquilados2.Add(familiar2);

            Alquiler alquiler3 = new Alquiler(03, 2500, 33333, 303030, "Neymar", "Jr", 1, DateTime.Today, 5);
            var vehiculosAlquilados3 = new List<Vehiculo>();
            vehiculosAlquilados3.Add(utilitario2);

            var alquileres = new List<Alquiler>();
            alquileres.Add(alquiler1);
            alquileres.Add(alquiler2);
            alquileres.Add(alquiler3);

            var vehiculos = new List<Vehiculo>();
            vehiculos.Add(deportivo1);
            vehiculos.Add(deportivo2);
            vehiculos.Add(deportivo3);
            vehiculos.Add(familiar1);
            vehiculos.Add(familiar2);
            vehiculos.Add(familiar3);
            vehiculos.Add(utilitario1);
            vehiculos.Add(utilitario2);
            vehiculos.Add(utilitario3);

            Sucursal Sucursal1 = new Sucursal(1, "Dr. Eyde y Rincon", vehiculos, alquileres);
            

            string opcion;
            Console.WriteLine("Bienvenido a Automotora CEI:");
            do
            {
                Console.WriteLine("Menú de opciones:");
                Console.WriteLine(" 1. Ver todos los vehículos\n 2. Ver alquileres.\n 3. Ver alquileres por cliente. \n 4. Alquilar un vehículo.\n 5. Agregar un vehículo a la Automotora.\n 6. Salir.");
                Console.Write("Ingrese la opción deseada: ");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Lista de todos los vehículos: \n");
                        Sucursal1.mostrarVehiculos(Sucursal1.getVehiculos());
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Lista de todos los alquileres: \n");
                        Sucursal1.mostrarAlquileres(Sucursal1.getAlquiler());
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Ingrese el documento del cliente: (sin puntos ni guión)");
                        bool datosValidos1 = false;
                        bool datosValidos5 = false;
                        int documentoCliente = 0;
                        do
                        {
                            while (!datosValidos5)
                            {
                                string entrada2 = Console.ReadLine();
                                try
                                {
                                    int valorIngresado = int.Parse(entrada2);
                                    if (valorIngresado > 0)
                                    {
                                        documentoCliente = valorIngresado;
                                        datosValidos5 = true;
                                    }
                                    else
                                    {
                                        throw new ArgumentException("El número ingresado no puede ser negativo.");
                                    }
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Entrada no válida. Debe ingresar un número entero. Inténtelo de nuevo:");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                            List<Alquiler> colAlquileresCliente = Sucursal1.DarAlquileresPorDocumento(documentoCliente);
                            if (colAlquileresCliente.Count > 0)
                            {
                                Console.Clear();
                                Console.WriteLine($"\nResumen de el/los alquileres de {colAlquileresCliente[0].getNombreCliente()} {colAlquileresCliente[0].getApellidoCliente()}:");
                                foreach (Alquiler alquiler in colAlquileresCliente)
                                {
                                    Console.WriteLine($"    Número de alquiler: {alquiler.getNumAlquiler()}\n        Cantidad de Vehículos alquilados: {(alquiler.getDetalleAlquiler().getCantVehiculosAlquilados())}\n        Fecha Retiro: {(alquiler.getDetalleAlquiler().getFechaRetiro())}\n        Cantidad de días: {(alquiler.getDetalleAlquiler().getCantDias())}\n        Costo total: ${alquiler.getPrecioTotalAlquiler()}\n");
                                    
                                }
                                datosValidos1 = true;
                            }
                            else
                            {
                                Console.WriteLine("El documento ingresado no existe, ingrese nuevamente el N° de documento:");
                                datosValidos5 = false;

                            }   
                        } while (!datosValidos1);
                        Console.ReadLine();

                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Lista de todos los vehículos disponibles para alquilar: \n");
                        Sucursal1.mostrarVehiculosDisponibles(Sucursal1.getVehiculos());
                        List<Vehiculo> VehiculosSeleccionados = new List<Vehiculo>(); 
                        int costoVehiculo = 0;
                        int cantidadVehiculos = 0;
                        string entrada1;

                        do
                        {
                            Console.WriteLine("\nDesea realizar un alquiler? \n1. Si\n2. No");
                            entrada1 = Console.ReadLine();

                            if (entrada1 == "1")
                            {
                                bool datosValidos = false;
                                string valor;

                                while (!datosValidos)
                                {
                                    Console.Clear();
                                    Sucursal1.mostrarVehiculosDisponibles(Sucursal1.getVehiculos());
                                    Console.WriteLine("\nElija el N° de código del vehículo a alquilar.");
                                    valor = Console.ReadLine();

                                    if (int.TryParse(valor, out int valorIngresado) && valorIngresado > 0)
                                    {
                                        List<Vehiculo> listaDeVehiculos = Sucursal1.getVehiculos();
                                        Vehiculo vehiculoSeleccionado = listaDeVehiculos.FirstOrDefault(v => v.getNumVehiculo() == valorIngresado && v.getEstado() == true);

                                        if (vehiculoSeleccionado != null)
                                        {
                                            VehiculosSeleccionados.Add(vehiculoSeleccionado);
                                            cantidadVehiculos++;
                                            costoVehiculo += vehiculoSeleccionado.getPrecio();
                                            vehiculoSeleccionado.setEstado(false);
                                            Console.WriteLine("Vehículo seleccionado agregado.");

                                            Console.WriteLine("\nDesea realizar el alquiler de otro vehículo? \n1. Si\n2. No");
                                            entrada1 = Console.ReadLine();
                                            if (entrada1 == "2")
                                            {
                                                datosValidos = true;
                                            }
                                            else if (Sucursal1.getVehiculos().Count(v => v.getEstado() == true && !VehiculosSeleccionados.Contains(v)) == 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("No quedan más vehículos disponibles para alquilar.");
                                                Console.ReadLine();
                                                entrada1 = "2";
                                                datosValidos = true;
                                            }
                                            else
                                            {
                                                while (entrada1 != "1" && entrada1 != "2")
                                                {
                                                    Console.WriteLine("Entrada no válida. Inténtelo nuevamente:");
                                                    Console.WriteLine("\nDesea realizar el alquiler de otro vehículo? \n1. Si\n2. No");
                                                    entrada1 = Console.ReadLine();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("El número de vehículo no existe o se encuentra alquilado. Inténtelo nuevamente:");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Entrada no válida. Inténtelo nuevamente:");
                                    }
                                }
                            }
                            else if (Sucursal1.getVehiculos().Count(v => v.getEstado() == true && !VehiculosSeleccionados.Contains(v)) == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("No quedan más vehículos disponibles para alquilar.");
                                Console.ReadLine();
                                entrada1 = "2";
                            }
                            else if (entrada1 != "1" && entrada1 != "2")
                            {
                                Console.WriteLine("Entrada no válida. Inténtelo nuevamente:");
                                while (entrada1 != "1" && entrada1 != "2")
                                {
                                    Console.WriteLine("\nDesea realizar un alquiler? \n1. Si\n2. No");
                                    entrada1 = Console.ReadLine();
                                }

                            }
                        } while (entrada1 == "1");

                        if (VehiculosSeleccionados.Count > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Complete los siguientes datos para registar un alquiler:");
                            Console.ReadLine();
                            var arrayAtributosAlq = AgregarAlquiler(Sucursal1.getAlquiler());
                            int costoTotal = 0;
                            costoTotal = (int)arrayAtributosAlq[6] * costoVehiculo;
                            Sucursal1.AgregarAlquier((int)arrayAtributosAlq[0], costoTotal, (int)arrayAtributosAlq[1], (int)arrayAtributosAlq[2], arrayAtributosAlq[3] as string, arrayAtributosAlq[4] as string, cantidadVehiculos, (DateTime)arrayAtributosAlq[5], (int)arrayAtributosAlq[6]);
                        }
                        Console.Clear();

                        break;
                    case "5":
                        Console.Clear();
                        var arrayAtributos = AgregarAuto(Sucursal1.getVehiculos());
                        string entrada;
                        do
                        {
                            Console.WriteLine("Elija que tipo de vehículo desea agregar: \n 1. Deportivo \n 2. Familiar \n 3. Utilitario");
                            entrada = Console.ReadLine();
                            switch (entrada)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Ingrese la velocidad máxima del vehículo:");
                                    int velMax = 0;
                                    bool datosValidos = false;
                                    while (!datosValidos)
                                    {
                                        string valor = Console.ReadLine();
                                        try
                                        {
                                            int valorIngresado = int.Parse(valor);
                                            if (valorIngresado > 0)
                                            {
                                                velMax = valorIngresado;
                                                datosValidos = true;
                                            }
                                            else
                                            {
                                                throw new ArgumentException("El número ingresado no puede ser negativo.");
                                            }
                                        }
                                        catch (ArgumentException ex)
                                        {
                                            Console.WriteLine($"Error: {ex.Message}");
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Entrada no válida. Debe ingresar un número entero. Inténtelo de nuevo:");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    Sucursal1.AgregarVehiculoDeportivo((int)arrayAtributos[0], arrayAtributos[1] as string, arrayAtributos[2] as string, arrayAtributos[3] as string, (int)arrayAtributos[4], true, (int)arrayAtributos[5], (int)arrayAtributos[6], velMax);
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Ingrese la capacidad del maletero del vehículo:");
                                    int capacidadMaletero = 0;
                                    bool datosValidos2 = false;
                                    while (!datosValidos2)
                                    {
                                        string valor = Console.ReadLine();
                                        try
                                        {
                                            int valorIngresado = int.Parse(valor);
                                            if (valorIngresado > 0)
                                            {
                                                capacidadMaletero = valorIngresado;
                                                datosValidos2 = true;
                                            }
                                            else
                                            {
                                                throw new ArgumentException("El número ingresado no puede ser negativo.");
                                            }
                                        }
                                        catch (ArgumentException ex)
                                        {
                                            Console.WriteLine($"Error: {ex.Message}");
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Entrada no válida. Debe ingresar un número entero. Inténtelo de nuevo:");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    Sucursal1.AgregarVehiculoFamiliar((int)arrayAtributos[0], arrayAtributos[1] as string, arrayAtributos[2] as string, arrayAtributos[3] as string, (int)arrayAtributos[4], true, (int)arrayAtributos[5], (int)arrayAtributos[6], capacidadMaletero);
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Ingrese la capacidad de la caja del vehículo:");
                                    int capacidadCaja = 0;
                                    bool datosValidos3 = false;
                                    while (!datosValidos3)
                                    {
                                        string valor = Console.ReadLine();
                                        try
                                        {
                                            int valorIngresado = int.Parse(valor);
                                            if (valorIngresado > 0)
                                            {
                                                capacidadCaja = valorIngresado;
                                                datosValidos3 = true;
                                            }
                                            else
                                            {
                                                throw new ArgumentException("El número ingresado no puede ser negativo.");
                                            }
                                        }
                                        catch (ArgumentException ex)
                                        {
                                            Console.WriteLine($"Error: {ex.Message}");
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Entrada no válida. Debe ingresar un número entero. Inténtelo de nuevo:");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    Sucursal1.AgregarVehiculoUtilitario((int)arrayAtributos[0], arrayAtributos[1] as string, arrayAtributos[2] as string, arrayAtributos[3] as string, (int)arrayAtributos[4], true, (int)arrayAtributos[5], (int)arrayAtributos[6], capacidadCaja);
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                                    break;
                            }
                        } while (entrada != "1" && entrada != "2" && entrada != "3");

                        break;
                    case "6":
                        Console.WriteLine("Saliendo del programa.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
                Console.Clear();
            } while (opcion != "6");
        }

        public static object[] AgregarAuto(List<Vehiculo> listaVehiculos)
        {
            int nroIdentificador = listaVehiculos.Count + 1;

            string matricula;
            string marca;
            string color;
            int capacidadTanque = 0;
            int precio = 0;
            int kmLitro = 0;

            Console.Clear();
            Console.WriteLine("Ingrese la matrícula del vehículo a adquirir: ");
            matricula = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Ingrese la marca del vehículo: ");
            marca = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Ingrese el color del vehículo: ");
            color = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Ingrese la capacidad del tanque del vehículo: ");
            bool datosValidos1 = false;
            while (!datosValidos1)
            {
                string entrada = Console.ReadLine();
                try
                {
                    int valorIngresado = int.Parse(entrada);
                    if (valorIngresado > 0)
                    {
                        capacidadTanque = valorIngresado;
                        datosValidos1 = true;
                    }
                    else
                    {
                        throw new ArgumentException("El número ingresado no puede ser negativo.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada no válida. Debe ingresar un número entero. Inténtelo de nuevo:");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.Clear();
            Console.WriteLine("Ingrese el precio que tendrá el vehículo: ");
            bool datosValidos2 = false;
            while (!datosValidos2)
            {
                string entrada = Console.ReadLine();
                try
                {
                    int valorIngresado = int.Parse(entrada);
                    if (valorIngresado > 0)
                    {
                        precio = valorIngresado;
                        datosValidos2 = true;
                    }
                    else
                    {
                        throw new ArgumentException("El número ingresado no puede ser negativo.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada no válida. Debe ingresar un número entero. Inténtelo de nuevo:");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.Clear();
            Console.WriteLine("Ingrese los km que recorre el vehículo por litro de combustible: ");
            bool datosValidos3 = false;
            while (!datosValidos3)
            {
                string entrada = Console.ReadLine();
                try
                {
                    int valorIngresado = int.Parse(entrada);
                    if (valorIngresado > 0)
                    {
                        kmLitro = valorIngresado;
                        datosValidos3 = true;
                    }
                    else
                    {
                        throw new ArgumentException("El número ingresado no puede ser negativo.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada no válida. Debe ingresar un número entero. Inténtelo de nuevo:");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            object[] arr = new object[] { nroIdentificador, matricula, marca, color, capacidadTanque, precio, kmLitro };

            return arr;
        }
        public static object[] AgregarAlquiler(List<Alquiler> listaAlquileres)
        {
            int numAlquiler = listaAlquileres.Count + 1;
            int documentoCliente = 0;
            int telefonoCliente = 0;
            string nombreCliente;
            string apellidoCliente;
            DateTime fechaRetiro = DateTime.Now;
            int cantDias = 0;

            Console.Clear();
            Console.WriteLine("Ingrese el documento del cliente (sin punto ni gión): ");
            bool datosValidos = false;
            while (!datosValidos)
            {
                string entrada = Console.ReadLine();
                try
                {
                    int valorIngresado = int.Parse(entrada);
                    if (valorIngresado > 0)
                    {
                        documentoCliente = valorIngresado;
                        datosValidos = true;
                    }
                    else
                    {
                        throw new ArgumentException("El número ingresado no puede ser negativo.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada no válida. Debe ingresar un número entero. Inténtelo de nuevo:");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.Clear();
            Console.WriteLine("Ingrese el teléfono del cliente: ");
            bool datosValidos1 = false;
            while (!datosValidos1)
            {
                string entrada = Console.ReadLine();
                try
                {
                    int valorIngresado = int.Parse(entrada);
                    if (valorIngresado > 0)
                    {
                        telefonoCliente = valorIngresado;
                        datosValidos1 = true;
                    }
                    else
                    {
                        throw new ArgumentException("El número ingresado no puede ser negativo.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada no válida. Debe ingresar un número entero. Inténtelo de nuevo:");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.Clear();
            Console.WriteLine("Ingrese el nombre del cliente:");
            nombreCliente = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Ingrese el apellido del cliente:");
            apellidoCliente = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Ingrese la cantidad de días que el cliente rentará el/los vehículo/s: ");
            bool datosValidos2 = false;
            while (!datosValidos2)
            {
                string entrada = Console.ReadLine();
                try
                {
                    int valorIngresado = int.Parse(entrada);
                    if (valorIngresado > 0)
                    {
                        cantDias = valorIngresado;
                        datosValidos2 = true;
                    }
                    else
                    {
                        throw new ArgumentException("El número ingresado no puede ser negativo.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada no válida. Debe ingresar un número entero. Inténtelo de nuevo:");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            object[] arr2 = new object[] { numAlquiler, documentoCliente, telefonoCliente, nombreCliente, apellidoCliente, fechaRetiro, cantDias };

            return arr2;
        }
    }
}


