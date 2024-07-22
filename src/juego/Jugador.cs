namespace Proyecto
{
    public class Jugador
    {
        public string Tipo { set; get; }
        public string Nombre { set; get; }
        public string Apodo { set; get; }
        public DateTime FechaDeNacimiento { set; get; }
        public int Edad { set; get; }
        public int Velocidad { set; get; }
        public int Destreza { set; get; }
        public int Fuerza { set; get; }
        public int Nivel { set; get; }
        public int Armadura { set; get; }
        public int Salud = 100;
    }
}