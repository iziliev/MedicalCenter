﻿using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Global;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenter.Core.Models.Review
{
    public class ShowAllReceiveReviewViewModel
    {
        public const int ReviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        public int TotalReviewsCount { get; set; }

        public string? SearchTerm { get; set; }

        public IEnumerable<AllReceiveReviewViewModel> Reviews { get; set; } = new List<AllReceiveReviewViewModel>();
    }
}
