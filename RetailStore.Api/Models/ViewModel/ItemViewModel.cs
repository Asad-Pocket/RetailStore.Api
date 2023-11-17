namespace RetailStore.Api.Models.ViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ReOrderLevel { get; set; }
        public int CompanyId { get; set; }
    }
}

