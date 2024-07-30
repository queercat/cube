using backend.entities;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.CubeService;

public interface ICubeService
{
    public Task<List<UserCubeModel>> GetUserCubes(Guid userId);

    public Task<ActionResult> CreateCube(Guid userId, string cubeName);

    public Task<ActionResult> AddCardToCube(Guid userId, CardType[] cardsToAdd, int cubeId);

}