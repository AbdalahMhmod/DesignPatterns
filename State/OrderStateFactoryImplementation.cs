namespace State
{
    #region Factory method example
    internal interface IOrderStateFactory
    {
        IOrderState CreateOrderState();
    }

    internal class OrderStateFactory : IOrderStateFactory
    {
        private readonly OrderState _orderState;
        private readonly Order _order;

        public OrderStateFactory(OrderState orderState, Order order)
        {
            _orderState = orderState;
            _order = order;
        }

        public IOrderState CreateOrderState()
        {
            return _orderState switch
            {
                OrderState.Draft => new OrderDraftState(_order),
                OrderState.Canceled => new OrderCanceledState(_order),
                OrderState.Confirmed => new OrderConfirmedState(_order),
                OrderState.UnderProcessing => new OrderProcessedState(_order),
                OrderState.Shipped => new OrderShippedState(_order),
                OrderState.Delivered => new OrderDeliveredState(_order),
                OrderState.Returned => new OrderReturnededState(_order),
                _ => throw new NotImplementedException()
            };
        }
    }

    #endregion
}
