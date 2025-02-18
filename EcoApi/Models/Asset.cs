namespace EcoApi.Models
{
    public class Asset
    {
        #region Properties
        public int Id { get; set; }
        public User? User { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public decimal CarbonSavings { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime LastMaintainance { get; set; }
        #endregion
    }
}
