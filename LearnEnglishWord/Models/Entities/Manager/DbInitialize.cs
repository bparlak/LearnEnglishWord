using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglishWord.Models.Entities.Manager
{
    public class DbInitialize
    {
        public static void InitializeDb(IApplicationBuilder app)
        {
            DatabaseContext context = app.ApplicationServices.GetRequiredService<DatabaseContext>();
            context.Database.Migrate();
            /*burada yazılacak kodlar baslangıc verilerini olusturacak
             program ilk çalıştığında aşağıdaki veriler oluşturulacak ilk for da 10 tane kullanıcının olusturulması gibi.
             */

            if (false)
            {
            }
        }
    }
}
