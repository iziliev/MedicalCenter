using MedicalCenter.Infrastructure.Data;
using MedicalCenter.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Test.Mocks
{
    public class RepositoryMock
    {
        public static IRepository Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<MedicalCenterDbContext>()
                    .UseInMemoryDatabase("MedicalCenterInMemoryDb" + DateTime.Now.Ticks.ToString())
                    .Options;

                var context = new MedicalCenterDbContext(dbContextOptions);

                return new Repository(context);
            }
        }
    }
}
