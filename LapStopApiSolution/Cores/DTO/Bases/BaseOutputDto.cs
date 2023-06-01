namespace DTO.Bases
{
    public abstract class BaseOutputDto
    {
        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
