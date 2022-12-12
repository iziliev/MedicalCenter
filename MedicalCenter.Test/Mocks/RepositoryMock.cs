using MedicalCenter.Infrastructure.Data.Common;

namespace MedicalCenter.Test.Mocks
{
    public class RepositoryMock
    {
        public static IRepository Instance
        {
            get
            {
                var context = DbContextMock.MockMedicalCenterDbContext;

                return new Repository(context);
            }
        }
    }
}
