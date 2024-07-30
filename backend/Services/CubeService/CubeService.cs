using backend.context;
using backend.entities;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.services.CubeService;

public class CubeService(CubeDbContext dbContext) : ICubeService 
{
    public async Task<List<UserCubeModel>> GetUserCubes(Guid userId)
    {
        var userCubesList = await dbContext.Cubes
            .Where(c => c.User.Id == userId)
            .Select(c => new UserCubeModel(c.CubeName))
            .ToListAsync();

        // mock data for page for now.
        userCubesList.AddRange([new UserCubeModel("Rakdos Cats"), new UserCubeModel("Azorius Bats")]);
        
        return userCubesList;
    }

    public async Task<ActionResult> CreateCube(Guid userId, string cubeName)
    {
        var user = await dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null) return new NotFoundResult();

        dbContext.Add(new Cube() { CubeName = cubeName, User = user, Cards = [] });
        await dbContext.SaveChangesAsync();
        return new OkResult();
    }
    
}