using _0_Framework.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public  class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
            Operations = new List<InventoryOperation>();
        }

        public long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            return plus - minus;
        }

        public void Increase(long operatorId , long count , string discription)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true, operatorId, count, currentCount, discription, 0, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }


        public void Reduce(long operatorId, long count, string discription , long OrderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(true, operatorId, count, currentCount, discription, OrderId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }

        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }
    }
}
