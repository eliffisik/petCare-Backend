using System;

namespace CleanArchitecture.Core.Entities
{ 
    public class PetAdoption : AuditableBaseEntity
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Age { get; set; }
    public string Gender { get; set; }
    public string AdditionalInfo { get; set; }
    public string Photo { get; set; } // Base64 encoded image
    public int UserId { get; set; }

}
}