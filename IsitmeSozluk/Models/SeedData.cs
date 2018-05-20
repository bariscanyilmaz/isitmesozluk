using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsitmeSozluk.Models
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            using(var serviceScope=app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                SozlukContext sozlukContext = serviceScope.ServiceProvider.GetRequiredService<SozlukContext>();
                
                sozlukContext.Database.Migrate();

                if (!sozlukContext.Sozluks.Any())
                {
                    sozlukContext.Sozluks.AddRange(
                        new Sozluk() { Id = 1, Name = "Merhaba" },
                        new Sozluk() { Id = 2, Name = "Eğitim" },
                        new Sozluk() { Id = 3, Name = "Başarı" },
                        new Sozluk() { Id = 4, Name = "Yazmak" },
                        new Sozluk() { Id = 5, Name = "Güle Güle" }
                        );

                    sozlukContext.SaveChanges();
                }


            }
        }
    }
}
