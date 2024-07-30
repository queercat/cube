using backend.context;
using backend.entities;
using backend.Models;
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
        ActionResult response;
        
        var newEntry = new Cube
        {
            Id = Guid.NewGuid(),
            CubeName = cubeName,
            User = await dbContext.User // I will have to check if this works how I hope it does
                .Where(u => u.Id = userId)
                .FirstOrDefaultAsync();
        };

        try
        {
            dbContext.Add<Cube>(newEntry);
            response = OK();
        }
        catch (error)
        {
            Console.Write(error);
            response = View("error"); // This was the first way to do a reponse to ActionResult failure I found
        }
        finally
        {
            dbContext.SaveChanges();
            return response;
        }
    }
    
}