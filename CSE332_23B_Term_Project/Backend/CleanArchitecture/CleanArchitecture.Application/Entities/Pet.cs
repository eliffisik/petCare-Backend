namespace CleanArchitecture.Core.Entities
{
    public class Pet : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }

        public string Breed { get; set; }
        public int CategoryId { get; set; }
       
        public string ImagePath { get; set; }

      }

    }


