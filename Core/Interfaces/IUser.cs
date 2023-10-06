using Core.Entities;

namespace Core.Interfaces;

public interface IUser : IGenericRepository<User>
{
    Task<User> GetByUserNameAsync(string userName);
}
