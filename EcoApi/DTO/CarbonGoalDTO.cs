namespace EcoApi.DTO
{
    public class CarbonGoalDTO
    {
        #region Properties
        public required int UserId { get; set; }
        public string? Description { get; set; }
        public required decimal TargetEmission { get; set; }
        public decimal? CurrentEmission { get; set; }
        public required DateTime Deadline { get; set; }
        #endregion

    }
}
