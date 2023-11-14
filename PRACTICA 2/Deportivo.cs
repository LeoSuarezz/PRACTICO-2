using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICA_2
{
    internal class Deportivo : Vehiculo
    {
        private int velocidadMaxima;
        public Deportivo(){ }
        public Deportivo(int numVehiculo, string matricula, string marca, string color, int capacidadTanque, bool estado, int precio, int kmLitro, int velocidadMaxima) : base(numVehiculo, matricula, marca, color, capacidadTanque, estado, precio, kmLitro)
        {
            this.velocidadMaxima = velocidadMaxima;
        }
        public int getVelocidadMaxima() { return velocidadMaxima; }
        public void setVelocidadMaxima(int velocidadMaxima) { this.velocidadMaxima = velocidadMaxima; }

    }
}
