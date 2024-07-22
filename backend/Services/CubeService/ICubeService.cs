using backend.entities;
using backend.types;

namespace backend.services;

public interface ICubeService
{
    public Task<List<UserCubes>> GetUserCubes(int userId);
    
    
}