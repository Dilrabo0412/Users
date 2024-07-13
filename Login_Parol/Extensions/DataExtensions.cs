using Microsoft.EntityFrameworkCore;
using UserLoginApi.Data;

namespace Login_Parol.Extensions
{
    public static class DataExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<UserContext>();
                db.Database.Migrate();
            }
        }
    }



}
