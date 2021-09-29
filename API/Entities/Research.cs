using System.Collections.Generic;

namespace API.Entities
{
    public class  Research
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Deadline { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ResearchIndicator> Indicators { get; set; }

        public ICollection<RealResearch> RealResearches { get; set; }
    }
}