using System.ComponentModel.DataAnnotations.Schema;

namespace DataGrid.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArName { get; set; }
        public string Description { get; set; }
        public string ArDescription { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // Navigation TO Category
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category
        {
            get; set;

        }
        public DateTime AddedOn { get; set; }
        public DateOnly AddedData { get; set; }
        public TimeOnly AddedTime { get; set; }

    }
}