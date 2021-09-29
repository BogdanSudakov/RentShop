namespace API.Entities
{
    public class RealResearchIndicator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Measure { get; set; }
        public double Value { get; set; }
        public int RealResearchId { get; set; }
        public RealResearch RealResearch { get; set; }
    }
}