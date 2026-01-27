using TodoList.Core.DTOs.Responses;
using TodoList.Domain.Entities;

namespace TodoList.API.Mappers;

public static class UserMapperExtensions
{
    public static UserResponseDto ToUserResponseDto (this User user)
    {
        return new UserResponseDto
        {
            Id = user.Id,
            Email = user.Email,
            Lastname = user.Lastname,
            Firstname = user.Firstname
        };
    }

    public static IEnumerable<UserResponseDto> ToUserResponseDtos (this IEnumerable<User> users)
    {
        return users.Select(u => u.ToUserResponseDto()).ToList();
    }
}
