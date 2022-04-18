using Application.Business.Service;
using Application.Entitities;
using MediaBrowser.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Business.Abstract
{
    public interface IUserService
    {
        Task<int> AddAsync(User entity);
        Task<WebApiResponse> UpdateAsync(int? userId, User entity);
        Task<WebApiResponse> DeleteAsync(int? userId);
        Task<IEnumerable<User>> GetAsync();
        Task<User> GetByIdAsync(int? userId);
        Task AddUserAsync(User user);
        //Task UpdateAsync(int? id, User userModel);
    }
}
