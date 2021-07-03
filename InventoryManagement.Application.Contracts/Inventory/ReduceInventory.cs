namespace InventoryManagement.Application.Contracts.Inventory
{
    public class ReduceInventory
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long Count { get; set; }
        public string Discription { get; set; }
        public long OperatorId { get; set; }
        public long InventoryId { get; set; }
    }


}
