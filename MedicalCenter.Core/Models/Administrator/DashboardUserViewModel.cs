﻿namespace MedicalCenter.Core.Models.Administrator
{
    public class DashboardUserViewModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? JoinOnDate { get; set; }
    }
}
