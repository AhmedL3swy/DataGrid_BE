namespace DataGrid.Application.Features.Search.SearchRequestModels.Product
{
    public class SearchProduct
    {
        public int? Id { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string EnDescription { get; set; }
        public string ArDescription { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        //public DateTime AddedOn { get; set; }
        //public DateOnly AddedDate { get; set; }
        //public TimeOnly AddedTime { get; set; }
    }
}
