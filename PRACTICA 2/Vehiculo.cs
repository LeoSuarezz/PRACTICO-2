using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICA_2
{
    internal class Vehiculo
    {
        protected int numVehiculo;
        protected string matricula;
        protected string marca;
        protected string color;
        protected int capacidadTanque;
        protected bool estado;
        protected int precio;
        protected int kmLitro;
        public Vehiculo() { }
        public Vehiculo(int numVehiculo,string matricula,string marca,string color,int capacidadTanque,bool estado,int precio,int kmLitro) 
        {
            this.numVehiculo = numVehiculo;
            this.matricula = matricula;
            this.marca = marca;
            this.color = color;
            this.capacidadTanque = capacidadTanque;
            this.estado = estado;
            this.precio = precio;
            this.kmLitro = kmLitro;
        }
        public int getNumVehiculo() {  return numVehiculo; }
        public string getMatricula() {  return matricula; }
        public string getMarca() {  return marca; }
        public string getColor() { return color; }
        public int getCapacidadTanque() {  return capacidadTanque; }
        public bool getEstado() { return estado; }
        public int getPrecio() {  return precio; }
        public double getKmLitro() { return kmLitro; }
        public void setNumVehiculo(int numVehiculo) { this.numVehiculo = numVehiculo; }
        public void setMatricula(string matricula) { this.matricula = matricula; }
        public void setMarca(string marca) { this.marca = marca; }
        public void setColor(string color) {  this.color = color; }
        public void setCapacidadTanque(int capacidadTanque) { this.capacidadTanque = capacidadTanque; }
        public void setEstado(bool estado) { this.estado = estado; }
        public void setPrecio(int precio) { this.precio = precio; }
        public void setKmLitro(int kmLitro) { this.kmLitro = kmLitro; }

    }
}
