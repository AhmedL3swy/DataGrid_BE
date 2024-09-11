namespace DataGrid.Application.Shared.Models
{
    public class ApiResult<T> where T : class
    {
        public List<T> Data { get; set; }
        public int Total { get; set; }

    }
}
