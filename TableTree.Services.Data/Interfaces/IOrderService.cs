﻿using TableTree.Web.ViewModels.Order;

namespace TableTree.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetAllOrders(string userIdentificator);
        Task AddToOrders(OrderViewModel order);
        int GetLatestSequenceNumberAsync();
        Task<OrderDetailsViewModel> GetDetailsOfOrder(Guid orderId);
    }
}
