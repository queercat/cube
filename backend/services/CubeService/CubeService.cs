using backend.context;
using backend.entities;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.services.CubeService;

public class CubeService(CubeDbContext dbContext) : ICubeService 
{
    public async Task<List<UserCubeModel>> GetUserCubes(int userId)
    {
        var userCubesList = await dbContext.Cubes
            .Where(c => c.User.UserId == userId)
            .Select(c => new UserCubeModel(c.CubeName))
            .ToListAsync();

        // mock data for page for now.
        userCubesList.AddRange([new UserCubeModel("Rakdos Cats"), new UserCubeModel("Azorius Bats")]);
        
        return userCubesList;
    }
    
}