namespace EcoApi.DTO
{
    public class UserDTO
    {
        public int? Id { get; set; } 
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string EmailConfirmed { get; set; }

        public required bool IsNew { get; set; }
        public string? Password { get; set; }
        public required RoleDTO Role { get; set; }
    }
}
