using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask_ParseToDB_.Models
{
    public static class DbContextCreation
    {
        public static ApplicationDbContext DbContext { set; get; }

        public static void CreateDbContext(IApplicationBuilder app)
        {
            DbContext = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            DbContext.Database.Migrate();
        }
    }
}
