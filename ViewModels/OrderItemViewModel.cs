using System.ComponentModel.DataAnnotations;

namespace DutchTreat.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public int productId { get; set; }
        public string productCategory { get; set; }
        public string productSize { get; set; }
        public string productTitle { get; set; }
        public string productArtist { get; set; }
        public string productArtId { get; set; }

    }
}