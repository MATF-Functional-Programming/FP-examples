public static IEnumerable<B> SelectMany<A, B>(
        this IEnumerable<A> first,
        Func<A, IEnumerable<B>> selector);


IEnumerable<Shipper> shippers =
    customers
        .SelectMany(c => c.Addresses)
        .SelectMany(a => a.Orders)
        .SelectMany(o => o.Shippers);

