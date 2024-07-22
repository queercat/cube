using backend.services;
using backend.services.CubeService;
using backend.types;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;


[ApiController]
[Route("/api/v1/")]
public class CubeController(ICubeService cubeService) : ControllerBase
{

    [HttpGet("cube/{userId:int}")]
    public async Task<List<UserCubes>> GetCube([FromRoute] int userId) // I would like this to be a global variable
    {
        var cube = await cubeService.GetUserCubes(userId);

        return cube;
    }


}