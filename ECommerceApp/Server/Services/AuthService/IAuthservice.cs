﻿namespace ECommerceApp.Server.Services.AuthService;


public interface IAuthservice
{
    Task<ServiceResponse<int>> Register(User user, string password);
    Task<bool> UserExists(string email);
    Task<ServiceResponse<string>> Login(string email, string password);

    Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
    int GetUserId();
    string GetUserEmail();

    Task<User> GetUserByEmail(string email);
}
