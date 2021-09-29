using System.Collections.Generic;

namespace API.Entities
{
    public class RealResearch
    {
        public int Id { get; set; }
        public ICollection<RealResearchIndicator> RealResearchIndicators { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }


        public int ResearchId { get; set; }
        public Research Research { get; set; }
    }
}