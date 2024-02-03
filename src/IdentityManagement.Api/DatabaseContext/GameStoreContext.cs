using IdentityManagementPoc.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityManagementPoc.Api;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) 
    : IdentityDbContext<GameStoreUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
