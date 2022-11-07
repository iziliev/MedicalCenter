﻿using MedicalCenter.Core.Models.Administrator;

namespace MedicalCenter.Core.Models.Review
{
    public class ShowAllReviewViewModel
    {
        public const int ReviewPerPage = 5;

        public int CurrentPage { get; set; } = 1;

        public int TotalReviewsCount { get; set; }

        public IEnumerable<AllReviewViewModel> Reviews { get; set; } = new List<AllReviewViewModel>();
    }
}