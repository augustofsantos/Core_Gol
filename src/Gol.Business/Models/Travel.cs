using System;

namespace Gol.Business.Models
{
    public class Travel : Entity
    {
        public Guid TravelId { get; set; }
        public string Nome { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime DataViagem { get; set; }
    }
}