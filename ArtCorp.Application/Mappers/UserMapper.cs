using ArtCorp.Application.DTO.Request;
using ArtCorp.Application.DTO.Response;
using ArtCorp.Domain.Models;
using AutoMapper;

namespace ArtCorp.Application.Mappers
{
    public class UserMapper
    {
        public static UserResponse ToUserResponse(UserModel user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, UserResponse>());

            var mapper = new Mapper(config);

            return mapper.Map<UserModel, UserResponse>(user);
        }

        public static LoginModel ToLoginModel(LoginRequest user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LoginRequest, LoginModel>());

            var mapper = new Mapper(config);

            return mapper.Map<LoginRequest, LoginModel>(user);
        }.

        public static UserModel ToUser(UserRequest user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRequest, UserModel>());

            var mapper = new Mapper(config);

            return mapper.Map<UserRequest, UserModel>(user);
        }
    }
}
