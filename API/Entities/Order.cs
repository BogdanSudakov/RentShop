using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime CompleteDate { get; set; }
        
        public int LaboratoryAssistantId { get; set; }
        public AppUser LaboratoryAssistant { get; set; }

        public int CustomerId { get; set; }
        public AppUser Customer { get; set; }

        public ICollection<RealResearch> OrderResearches { get; set; }
    }
}