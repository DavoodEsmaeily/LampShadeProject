using System;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class InventoryOperation
    {
        public long Id { get; private set; }
        public bool Operation { get; private set; }
        public long OperatorId { get; private set; }
        public long Count { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string Discription { get; private set; }
        public long OrderId { get; private set; }
        public long InventoryId { get; private set; }
        public Inventory Inventory { get; private set; }

        public InventoryOperation(bool operation, long operatorId, long count,  long currentCount, string discription, long orderId, long inventoryId)
        {
            Operation = operation;
            OperatorId = operatorId;
            Count = count;
            CurrentCount = currentCount;
            Discription = discription;
            OrderId = orderId;
            InventoryId = inventoryId;
            OperationDate = DateTime.Now;
        }
    }
}
