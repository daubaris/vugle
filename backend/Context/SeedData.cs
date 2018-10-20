using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using VugleBE.Context.Models;

namespace VugleBE.Context
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VugleContext())
            {
                if (context.Users.Any())
                {
                    return;  
                }

                context.Users.AddRange(
                     new User
                     {
                         Username = "vugle",
                         Password = "tieto"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}