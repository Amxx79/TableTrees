using TableTree.Web.ViewModels.Order;

namespace TableTree.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetAllOrders();
        Task AddToOrders(OrderViewModel order);
        int GetLatestSequenceNumberAsync();
        Task<IEnumerable<ProductViewModel>> GetDetailsOfOrder(Guid orderId);
    }
}
