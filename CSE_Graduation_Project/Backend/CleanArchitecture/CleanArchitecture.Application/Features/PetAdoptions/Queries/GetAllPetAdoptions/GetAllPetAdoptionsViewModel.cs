namespace CleanArchitecture.Core.Features.PetAdoptions.Queries.GetAllPetAdoptions
{
    public class GetAllPetAdoptionsViewModel
    {
        public string Type { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string AdditionalInfo { get; set; }
        public string Photo { get; set; }
        public int UserId { get; set; }
    }
}
