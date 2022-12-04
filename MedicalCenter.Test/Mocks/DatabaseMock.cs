using MedicalCenter.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Test.Mocks
{
    public class DatabaseMock
    {
        public static MedicalCenterDbContext Instance 
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<MedicalCenterDbContext>()
                    .UseInMemoryDatabase("MedicalCenterInMemoryDb" +DateTime.Now.Ticks.ToString())
                    .Options;

                return new MedicalCenterDbContext(dbContextOptions);
            }
        }
    }
}
