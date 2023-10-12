using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Klient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PESEL { get; set; }
        public int BirthYear { get; set; }
        public int Plec { get; set; }
    }
}
