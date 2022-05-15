public interface ITraditionalRepository
{
    Customer GetCustomer(int id);
    Address GetAddress(int id);
    Order GetOrder(int id);
}


Shipper shipperOfLastOrderOnCurrentAddress = null;
var customer = repo.GetCustomer(customerId);
if (customer?.Address is not null)
{
    var address = repo.GetAddress(customer.Address.Id);
    if (address?.LastOrder is not null)
    {
        var order = repo.GetOrder(address.LastOrder.Id);
        shipperOfLastOrderOnCurrentAddress = order?.Shipper;
    }
}
return shipperOfLastOrderOnCurrentAddress;

