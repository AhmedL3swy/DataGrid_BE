namespace DataGrid.Application.Features.Search.Queries
{
    public class SearchProductViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ArName { get; set; }
        public string Description { get; set; }
        public string ArDescription { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
    }
}
