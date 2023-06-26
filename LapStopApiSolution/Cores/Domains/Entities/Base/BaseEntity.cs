namespace Domains.Entities.Base
{
    public abstract class BaseEntity
    {
        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
