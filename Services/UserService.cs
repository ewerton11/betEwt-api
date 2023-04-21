using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyDbContextApi.Data;
using UserApi.Models;

namespace UserApi.Service;

public class UserService
{
    private readonly MyDbContext _context;
    private readonly IPasswordHasher<UserModels> _passwordHasher;

    public UserService(MyDbContext context, IPasswordHasher<UserModels> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserModels?> GetUserByUserAsync(string user)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.User == user);
    }

    public async Task CreateUserAsync(UserModels userModels)
    {
        var hashedPassword = _passwordHasher.HashPassword(userModels, userModels.Password);

        userModels.PasswordHash = hashedPassword;
        _context.Users.Add(userModels);
        await _context.SaveChangesAsync();
    }

    public bool VerifyPasswordAsync(UserModels userModels)
    {
        var result = _passwordHasher.VerifyHashedPassword(userModels, userModels.PasswordHash, userModels.Password);
        return result == PasswordVerificationResult.Success;
    }
}