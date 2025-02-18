using EcoApi.DTO;
using EcoApi.Models;
using EcoApi.Repositories.Interfaces;
using EcoApi.Services.Interfaces;
using EcoApi.Utils;

namespace EcoApi.Services
{
    public class AuthService: IAuthService
    {
        #region Properties
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly PasswordHelper _passwordHelper;
        #endregion

        #region Constructor
        public AuthService(IUserRepository userRepository, IRoleRepository roleRepository ,PasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
            _roleRepository = roleRepository;
        }
        #endregion
        #region Methods
        public async Task<UserDTO?> Login(LoginDTO loginDTO)
        {
            var user = await _userRepository.GetUserByEmail(loginDTO.Email);
            if (user == null || !_passwordHelper.VerifyPasswordHash(loginDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Invalid email or password.");
            }

            return new UserDTO { 
                Id = user.Id, Name = user.Name!, 
                Email = user.Email, EmailConfirmed = user.EmailConfirmed,
                IsNew = user.IsNew,
                Role = new RoleDTO { Id = user.Role!.Id, Name = user.Role.Name } 
            };
        }

        public async Task<UserDTO> Register(UserDTO user)
        {
            User? existingUser = await _userRepository.GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                throw new Exception($"User with email {user.Email} already exists.");
            }

            _passwordHelper.CreatePasswordHash(user.Password!, out byte[] passwordHash, out byte[] passwordSalt);
            Role role = await _roleRepository.GetRoleById(user.Role.Id);
            User? u = new User {
                Name = user.Name, 
                Email = user.Email, 
                EmailConfirmed = user.EmailConfirmed, 
                IsActive = true, PasswordHash = passwordHash, 
                PasswordSalt = passwordSalt,
                Role = role,
            };

           User? newUser = await _userRepository.CreateUser(u);
            if(newUser == null)
            {
                throw new Exception("User could not be created.");
            }

            return new UserDTO { 
                Name = newUser.Name!, 
                Email = newUser.Email, 
                EmailConfirmed = newUser.EmailConfirmed,
                IsNew = newUser.IsNew,
                Role = new RoleDTO { Id = user.Role!.Id, Name = user.Role.Name } };
        }
        #endregion
    }
}
