
namespace Domains.Base
{
    public abstract class BaseModel
    {
        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
