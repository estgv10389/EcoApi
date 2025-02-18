using EcoApi.DTO;

namespace EcoApi.Services.Interfaces
{
    public interface ICarbonGoalService
    {
        Task<CarbonGoalDTO> AddCarbonGoal(CarbonGoalDTO carbonGoal);
    }
}
