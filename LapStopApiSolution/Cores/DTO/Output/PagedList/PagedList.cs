namespace DTO.Output.PagedList
{
    public sealed class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }

        public PagedList(List<T> sourceData, int totalRecords, int pageNumber, int pageSize) 
        {
            MetaData = new MetaData()
            {
                TotalRecords = totalRecords,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = pageSize > 0 ? (int)Math.Ceiling(totalRecords / (double)pageSize) : 0,
            };

            AddRange(sourceData);
        }
    }
}
