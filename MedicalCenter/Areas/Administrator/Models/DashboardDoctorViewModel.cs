namespace MedicalCenter.Areas.Administrator.Models
{
    public class DashboardDoctorViewModel
    {
        public string? Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? SpecialityName { get; set; }

        public int SpecialityId { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string Egn { get; set; } = null!;

        public string? JoinOnDate { get; set; }

        public string? OutOnDate { get; set; }
    }
}
