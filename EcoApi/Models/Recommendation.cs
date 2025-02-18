namespace EcoApi.Models
{
    public class Recommendation
    {
        #region Properties
        public int Id { get; set; }
        public User? User { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        #endregion
    }
}
