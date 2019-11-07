using System;

namespace back_sistema_tg.DAL.Models
{
    public class Horario
    {
        public DateTime DataInicioMovimento { get; set; }
        public DateTime DataFinalMovimento { get; set; }
        public DateTime HoraInicioMovimento { get; set; }
        public DateTime HoraFinalMovimento { get; set; }
    }
}
