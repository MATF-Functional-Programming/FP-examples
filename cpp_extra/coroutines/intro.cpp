// co_await expression — to suspend execution until resumed 
task<> tcp_echo_server()
{
    char data[1024];
    while (true)
    {
        std::size_t n = co_await socket.async_read_some(buffer(data));
        co_await async_write(socket, buffer(data, n));
    }
}

// co_yield expression — to suspend execution returning a value 
generator<unsigned int> iota(unsigned int n = 0)
{
    while (true)
        co_yield n++;
}

// co_return statement — to complete execution returning a value 
lazy<int> f()
{
    co_return 7;
}

