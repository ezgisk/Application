using Application.Business.Abstract;
using Application.Entitities;
using Application.GenericRepository;
using AutoMapper;
using MediaBrowser.Model.Dto;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Business.Service
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<UserManager> _logger;
        private readonly IMapper _mapper;

        public UserManager(IUnitOfWork unit,
            ILogger<UserManager> logger,
            IMapper mapper)
        {
            _uow = unit;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// // Create Movie
        /// </summary>
        /// <param name="movie">Movie Model Parameter</param>
        /// <returns></returns>



        public async Task<WebApiResponse> UpdateAsync(int? userId, User user)
        {
            try
            {
                var User = await _uow.UserRepository.GetByIdAsync(userId);
                if (user != null)
                {

                    user.UserName = user.UserName;
                    user.FirstName = user.FirstName;
                    user.Lastname = user.LastName;
                    user.Description = user.Description;

                    await _uow.UserRepository.UpdateAsync(user);
                    await _uow.Commit();

                    return new WebApiResponse()
                    {
                        StatusCode = (int)HttpStatusCode.OK,
                        Status = true
                    };
                }
                else
                {
                    return new WebApiResponse()
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Status = false
                    };
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception Error During Update Product", user);
                throw e;
            }
        }

        public async Task<WebApiResponse> DeleteAsync(int? userId)
        {
            try
            {
                var user = await _uow.UserRepository.FindByAsync(a => a.Id == userId);
                if (user != null)
                {
                    await _uow.UserRepository.DeleteAsync(user);
                    await _uow.Commit();
                    return new WebApiResponse()
                    {
                        StatusCode = (int)HttpStatusCode.OK,
                        Status = true
                    };
                }
                else
                {
                    return new WebApiResponse()
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Status = false
                    };
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception Error During Delete Product", userId);
                throw e;
            }
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            try
            {
                return await _uow.UserRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Product Get By Id Method
        public async Task<User> GetByIdAsync(int? userId)
        {
            try
            {
                var result = await _uow.UserRepository.GetByIdAsync(userId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
