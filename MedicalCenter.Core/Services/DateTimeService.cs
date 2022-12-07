using MedicalCenter.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Services
{
    public class DateTimeService : IDateTimeService
    {
        public string GetDate() => DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
    }
}
