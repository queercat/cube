using backend.Models;
using backend.services;
using backend.services.CubeService;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;


[ApiController]
[Route("/api/v1/cube")]
public class CubeController(ICubeService cubeService) : ControllerBase
{

    [HttpGet("{userId:guid}")]
    public async Task<List<UserCubeModel>> GetCube([FromRoute] Guid userId) // I would like this to be a global variable
    {
        var cube = await cubeService.GetUserCubes(userId);

        return cube;
    }

    [HttpPost("/create/{userId:guid}/{cubeName}")]
    public async Task<ActionResult> CreateCube([FromRoute] Guid userId, [FromRoute] string cubeName)
    {
        var response = await cubeService.CreateCube(userId, cubeName);
        
        return response;
    }
    
    [HttpPost("/addCards/{userId:guid}/{cubeId:int}")]
    public async Task<ActionResult> AddCardToCube([FromRoute] Guid userId, [FromRoute] int cubeId, [FromBody] CardType[] cards)
    {
        var response = await cubeService.AddCardToCube(userId, cards, cubeId);
        
        return response;
    }


}