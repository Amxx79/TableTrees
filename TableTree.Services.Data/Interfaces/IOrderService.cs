﻿using TableTree.Web.ViewModels.Cart;
using TableTree.Web.ViewModels.Order;

namespace TableTree.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetAllOrders();
        Task AddToOrders(OrderViewModel order);
    }
}