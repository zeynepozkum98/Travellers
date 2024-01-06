namespace Traveller.WebUI.BasketTransaction.BasketModels
{
	public class BasketItemDto
	{
        public string? Name { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
		public string? AccommodationType { get; set; }
		public DateTime DateOfEntry { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int WinterHolidayId { get; set; }
        public string? UserName { get; set; }
    }
}
