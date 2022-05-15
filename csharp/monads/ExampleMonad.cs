public interface IMonadicRepository
{
    Maybe<Customer> GetCustomer(int id);
    Maybe<Address> GetAddress(int id);
    Maybe<Order> GetOrder(int id);
}


Maybe<Shipper> shipperOfLastOrderOnCurrentAddress =
    repo.GetCustomer(customerId)
        .Bind(c => c.Address)
        .Bind(a => repo.GetAddress(a.Id))
        .Bind(a => a.LastOrder)
        .Bind(lo => repo.GetOrder(lo.Id))
        .Bind(o => o.Shipper);


