namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Guid BranchId { get; set; }
        public string BranchName { get; set; }
        public decimal TotalAmount { get; private set; }
        public List<SaleItem> Items { get; set; } = new();
        public bool IsCancelled { get; set; }

        public Sale()
        {
            Items = new List<SaleItem>();
            UpdateTotalAmount();
        }

        public void UpdateTotalAmount()
        {
            TotalAmount = Items.Sum(item => item.TotalAmount);
        }

        public void AddItem(SaleItem item)
        {
            Items.Add(item);
            ApplyDiscounts();
            UpdateTotalAmount();
        }

        public void SetItems(List<SaleItem> items)
        {
            Items = items;
            UpdateTotalAmount();
        }

        private void ApplyDiscounts()
        {
            foreach (var item in Items)
            {
                if (item.Quantity < 4)
                {
                    item.Discount = 0;
                }
                else if (item.Quantity >= 4 && item.Quantity < 10)
                {
                    item.Discount = item.UnitPrice * item.Quantity * 0.1m;
                }
                else if (item.Quantity >= 10 && item.Quantity <= 20)
                {
                    item.Discount = item.UnitPrice * item.Quantity * 0.2m;
                }
                else
                {
                    throw new InvalidOperationException("Cannot sell more than 20 identical items.");
                }
            }
        }
    }
}