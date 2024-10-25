namespace SignalRUI.Dtos.BasketDtos
{
    public class ResultBasketDtos
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableId { get; set; }

        public string ProductName { get; set; }
    }
}
