using EcoApi.Models;

namespace EcoApi.Repositories.Interfaces
{
    public interface ICarbonGoalRepository
    {
        Task<CarbonGoal> GetCarbonGoalById(int id);
        Task<CarbonGoal?> GetCarbonGoalByUserId(int userId);
        Task<CarbonGoal> CreateCarbonGoal(CarbonGoal carbonGoal);
        Task<CarbonGoal> UpdateCarbonGoal(CarbonGoal carbonGoal);
        Task<CarbonGoal> DeleteCarbonGoal(CarbonGoal carbonGoal);
    }
}
