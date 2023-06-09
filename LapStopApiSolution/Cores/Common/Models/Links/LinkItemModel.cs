namespace Common.Models.Links
{
    public sealed class LinkItemModel
    {
        public string? Method { get; set; }
        public string? Rel { get; set; }    // relationship
        public string? Href { get; set; }

        public LinkItemModel(string? method, string? rel, string? href)
        {
            Method = method;
            Rel = rel;
            Href = href;
        }
    }
}
