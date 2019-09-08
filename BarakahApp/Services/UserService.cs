using BarakahApp.Data.Repositories;
using BarakahApp.Entities;
using BarakahApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarakahApp.Services
{
    public class UserService : IUserService
    {
        private IUserEntityRepository _userEntityRepository;

        public UserService(IUserEntityRepository userEntityRepository)
        {
            _userEntityRepository = userEntityRepository;
        }

        public UserEntity Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _userEntityRepository.GetAll().SingleOrDefault(x => x.Email == email);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!PasswordHelper.Verify(password, user.Password))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _userEntityRepository.GetAll();
        }

        public UserEntity GetById(int id)
        {
            return _userEntityRepository.GetAll().FirstOrDefault(u => u.Id == id);
        }

        public async Task<UserEntity> Create(UserEntity user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (_userEntityRepository.GetAll().Any(x => x.Email == user.Email))
                throw new Exception("Username \"" + user.Email + "\" is already taken");



            user.Password = PasswordHelper.Hash(password);

            await _userEntityRepository.AddAsync(user);

            return user;
        }

        public async Task Update(UserEntity userParam, string password = null)
        {
            var user = await _userEntityRepository.GetByIdAsync(userParam.Id);

            if (user == null)
                throw new Exception("User not found");

            if (userParam.Email != user.Email)
            {
                // username has changed so check if the new username is already taken
                if (_userEntityRepository.GetAll().Any(x => x.Email == userParam.Email))
                    throw new Exception("Username " + userParam.Email + " is already taken");
            }

            // update user properties
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Email = userParam.Email;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                user.Password = PasswordHelper.Hash(password);
            }

            await _userEntityRepository.UpdateAsync(user);
        }

        public async Task Delete(int id)
        {
            var user = await _userEntityRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _userEntityRepository.DeleteAsync(user);
            }
        }
    }
}
