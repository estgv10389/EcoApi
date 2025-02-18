using EcoApi.Data;
using EcoApi.Models;
using EcoApi.Repositories.Interfaces;

namespace EcoApi.Repositories
{
    public class CarbonGoalRepository: ICarbonGoalRepository
    {
        private readonly AppDbContext _context;
        public CarbonGoalRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<CarbonGoal> GetCarbonGoalById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CarbonGoal?> GetCarbonGoalByUserId(int userId)
        {
            CarbonGoal? carbonGoal =  _context.CarbonGoals.FirstOrDefault(cg => cg.User.Id == userId);
            return Task.FromResult(carbonGoal);
        }

        public async Task<CarbonGoal> CreateCarbonGoal(CarbonGoal carbonGoal)
        {
            _context.CarbonGoals.Add(carbonGoal);
            await _context.SaveChangesAsync();
            return carbonGoal;
        }

        public Task<CarbonGoal> UpdateCarbonGoal(CarbonGoal carbonGoal)
        {
            throw new NotImplementedException();
        }

        public Task<CarbonGoal> DeleteCarbonGoal(CarbonGoal carbonGoal)
        {
            throw new NotImplementedException();
        }
    }
}
