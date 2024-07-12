namespace EldenRing
{
    class Personaje
    {
        public Datos Datos { get; set; }
        public Estadisticas Caracteristicas { get; set; }
        public Personaje(Datos Datos)
        {
            this.Datos = Datos;
            this.Caracteristicas = Datos.Estadisticas;
        }
    }
}
