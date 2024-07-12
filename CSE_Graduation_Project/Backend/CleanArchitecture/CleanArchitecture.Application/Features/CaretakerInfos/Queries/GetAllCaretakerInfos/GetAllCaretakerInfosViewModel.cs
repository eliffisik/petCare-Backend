namespace CleanArchitecture.Core.Features.CaretakerInfos.Queries.GetAllCaretakerInfos
{
    public class GetAllCaretakerInfosViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int YearsOfExperience { get; set; }
        public string Skills { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
