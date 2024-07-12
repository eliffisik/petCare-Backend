using System;

namespace CleanArchitecture.Core.Features.CaretakerInfos.Queries
{
    public class GetCaretakerInfoByIdViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int YearsOfExperience { get; set; }
        public string Skills { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
