﻿using Microsoft.EntityFrameworkCore;
using WebApplication___Week_5.Data;
using WebApplication___Week_5.ViewModels;

namespace WebApplication___Week_5.Repositories
{
    public class UserRepo
    {
        ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        // Get all users in the database.
        public async Task<List<UserVM>> All()
        {
            var users = await _context.Users.Select(u => new UserVM()
            {
                // Conditionally handle case where email is null.
                Email = (u.Email) != null ? u.Email : "",
            }).ToListAsync();
            return users;
        }
    }

}
