using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICA_2
{
    internal class Familiar : Vehiculo
    {
        private int capacidadMaletero;
        public Familiar() { }
        public Familiar(int numVehiculo, string matricula, string marca, string color, int capacidadTanque, bool estado, int precio, int kmLitro, int capacidadMaletero) : base(numVehiculo, matricula, marca, color, capacidadTanque, estado, precio, kmLitro)
        {
            this.capacidadMaletero = capacidadMaletero;
        }
        public int getCapacidadMaletero() { return capacidadMaletero; }
        public void setCapacidadMaletero(int capacidadMaletero) { this.capacidadMaletero=capacidadMaletero;}
    }
}
