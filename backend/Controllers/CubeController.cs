using backend.Models;
using backend.services;
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

    [HttpPost("{userId:guid , cubeName:string}")]
    public async Task<ActionResult> CreateCube([FromRoute] Guid userId, [FromRoute] string cubeName)
    {
        var response = await cubeService.CreateCube(userId, cubeName);

        return await response; // I froget if this has to be awaited here or not.
    }


}