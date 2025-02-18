namespace EcoApi.Models
{
    public class EmissionFactor
    {
        #region Properties
        public int Id { get; set; }
        public required string ActivityType { get; set; }
        public required string Unit { get; set; }
        public required decimal Factor { get; set; }
        #endregion
    }
}
