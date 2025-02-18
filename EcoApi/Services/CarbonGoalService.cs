using EcoApi.DTO;
using EcoApi.Models;
using EcoApi.Repositories.Interfaces;
using EcoApi.Services.Interfaces;

namespace EcoApi.Services
{
    public class CarbonGoalService:ICarbonGoalService
    {
        #region Properties
        private readonly ICarbonGoalRepository _carbonGoalRepository;
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructor
        public CarbonGoalService(ICarbonGoalRepository carbonGoalRepository, IUserRepository userRepository )
        {
            _carbonGoalRepository = carbonGoalRepository;
            _userRepository = userRepository;
        }
        #endregion

        #region Methods
        public async Task<CarbonGoalDTO> AddCarbonGoal(CarbonGoalDTO carbonGoal)
        {
            CarbonGoal? existingCarbonGoal = await _carbonGoalRepository.GetCarbonGoalByUserId(carbonGoal.UserId);
            if (existingCarbonGoal != null)
            {
                throw new Exception($"Carbon goal for user with id {carbonGoal.UserId} already exists.");
            }

            User? user = await _userRepository.GetUserById(carbonGoal.UserId);
            CarbonGoal newcarbonGoal = await _carbonGoalRepository.CreateCarbonGoal(new CarbonGoal
            {
                Description = carbonGoal.Description,
                TargetEmission = carbonGoal.TargetEmission,
                CurrentEmission = carbonGoal.CurrentEmission ?? 0,
                Deadline = carbonGoal.Deadline.ToUniversalTime(),
                User = user!
            });
            if(newcarbonGoal == null)
            {
                throw new Exception("Failed to create carbon goal.");
            }

             return new CarbonGoalDTO { 
                 CurrentEmission = newcarbonGoal.CurrentEmission, 
                 Deadline = newcarbonGoal.Deadline, 
                 Description = newcarbonGoal.Description,
                 TargetEmission = newcarbonGoal.TargetEmission,
                 UserId = newcarbonGoal.User.Id
             } ;
        }
        #endregion
    }
}
