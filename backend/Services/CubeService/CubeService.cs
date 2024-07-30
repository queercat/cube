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

        if (user == null)
        {
            Console.WriteLine("User was not found"); // for now this is here for testing
            return new NotFoundResult();
        }

        var newCube = new Cube() { CubeName = cubeName, User = user, Cards = [] };
        dbContext.Add(newCube);
        await dbContext.SaveChangesAsync(); 
        Console.WriteLine($"New Cube Created {newCube.Id}"); // for now this is here for testing
        return new OkResult();
    }

    public async Task<ActionResult> AddCardToCube(Guid userId, CardType[] cardsToAdd, int cubeId)
    {
        var cube = await dbContext.Cubes.FirstOrDefaultAsync(c => c.User.Id == userId && c.Id == cubeId);

        if (cube == null) return new NotFoundResult(); // return if user or cube don't exist

        foreach (var card in cardsToAdd)
        {
            var cardInSystem = await dbContext.Cards.FirstOrDefaultAsync(c => c.OracleId == card.OracleId);
            if (cardInSystem == null)
            {
                Console.WriteLine("Card doesn't exist");
                return new NotFoundResult(); 
            }
            cardInSystem.Cubes.Add(cube);
            cube.Cards.Add(cardInSystem);
        }
        
        await dbContext.SaveChangesAsync();
        
        return new OkResult();
    }
    
}