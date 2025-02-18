namespace EcoApi.Models
{
    public class CarbonGoal
    {
        #region Properties
        public int Id { get; set; }
        public required User User { get; set; }
        public string? Description { get; set; }
        public decimal TargetEmission { get; set; }
        public decimal CurrentEmission { get; set; }
        public DateTime Deadline { get; set; }
        #endregion
}
}
