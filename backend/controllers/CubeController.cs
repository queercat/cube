using backend.services;
using backend.services.CubeService;
using backend.types;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;


public class CubeController(ICubeService cubeService) : ControllerBase
{

    [HttpGet]
    [Route("/GetUserCubes", Name = "GetUserCubes")]
    public async Task<List<UserCubes>> GetCube(
        [FromQuery] int userId) // I would like this to be a global variable
    {
        var cube = await cubeService.GetUserCubes(userId);

        return cube;
    }


}