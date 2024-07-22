using backend.entities;
using backend.Models;

namespace backend.services;

public interface ICubeService
{
    public Task<List<UserCubeModel>> GetUserCubes(int userId);
    
    
}