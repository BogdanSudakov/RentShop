using System.Collections.Generic;

namespace API.Entities
{
    public class ResearchIndicator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Measure { get; set; }

        public ICollection<Research> Researches { get; set; }
    }
}