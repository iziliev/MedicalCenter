namespace MedicalCenter.Core.Models.Laborant
{
    public class DashboardLaboratoryPatientViewModel
    {
        public string? Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Egn { get; set; } = null!;

        public string? JoinOnDate { get; set; }
    }
}
