using backend.context;
using backend.entities;
using backend.types;
using Microsoft.EntityFrameworkCore;

namespace backend.services.CubeService;

public class CubeService(CubeDbContext dbContext) : ICubeService 
{
    public async Task<List<UserCubes>> GetUserCubes(int userId)
    {
        List<UserCubes> cubes = new List<UserCubes>();
        
        
        await dbContext.Cubes
            .Where(c => c.User.UserId == userId)
            .ForEachAsync(c => cubes.Add(new UserCubes(c.CubeName, c)));

        return cubes;
    }

    public async void GetString()
    {
        
    }
    
}