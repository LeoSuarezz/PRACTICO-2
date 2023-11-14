using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICA_2
{
    internal class Utilitario : Vehiculo
    {
        private int capacidadCarga;
        public Utilitario() { }
        public Utilitario(int numVehiculo, string matricula, string marca, string color, int capacidadTanque, bool estado, int precio, int kmLitro, int capacidadCarga) : base(numVehiculo, matricula, marca, color, capacidadTanque, estado, precio, kmLitro)
        {
            this.capacidadCarga = capacidadCarga;
        }
        public int getCapacidadCarga () { return capacidadCarga; }
        public void setCapacidadCarga (int capacidadCarga) { this.capacidadCarga = capacidadCarga; }
    }
}
