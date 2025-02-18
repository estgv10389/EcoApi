namespace EcoApi.Models
{
    public class User
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public required string Email { get; set; }
        public required string EmailConfirmed { get; set; }
        public bool IsActive { get; set; }
        public bool IsNew { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
        public Role? Role { get; set; }
        public DateTime CreatedAt { get; set; }
        #endregion
    }
}
