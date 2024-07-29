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


}