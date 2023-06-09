﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core.Utilities.DataTransferObjects.User;
using Application.DataAccess.Entities;
using Application.DataAccess.Services.HttpClientService;

namespace Application.DataAccess.Services.Api;

public class UserSevice : IUserService
{
    private readonly IHttpService _httpService;
    
    public UserSevice(IHttpService httpService)
    {
        _httpService = httpService;
    }
    
    public async Task<UserResponse> GetUserByTokenAsync(string token)
    {
        return await _httpService.PostAsync<UserResponse>("profilbilgilerinigetir",new UserRequest(null), token);
    }

    public async Task<UserResponse> GetOtherUserAsync(string token, int userId)
    {
        var user = await _httpService.PostAsync<UserResponse>("profilbilgilerinigetir", new UserRequest(userId), token);

        return user;
    }
}