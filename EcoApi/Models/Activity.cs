using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcoApi.Models
{
    public class Activity
    {
        #region Properties
        public int Id { get; set; }
        public User? User { get; set; }
        public required string Type { get; set; }
        public required string Details { get; set; }
        public decimal CarbonEmission { get; set; }
        public DateTime Date { get; set; }
        #endregion
    }
}
