namespace EcoApi.Models
{
    public class Report
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public required string Period { get; set; }
        public decimal TotalSavings { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}
