using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[ApiController]
[Route("/data")]
public class CubeController : ControllerBase
{
    private string connectionString = "Data Source=c:../database/cube.db;Version=3;";



}




