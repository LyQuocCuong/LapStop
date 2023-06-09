using Common.Models.Links;

namespace RestfulApiHandler.Models
{
    public sealed class RootDocumentModel
    {
        public string? Name { get; set; }
        public List<LinkItemModel>? Links { get; set; }

        public RootDocumentModel(string? modelName, List<LinkItemModel>? rootLinks)
        {
            Name = modelName;
            Links = rootLinks;
        }
    }
}
