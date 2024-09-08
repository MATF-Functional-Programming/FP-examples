
// No return value
async Task WorkAsync()
{
    await Task.Delay(42);
    // No return statement needed
}

Task returnedTask = WorkAsync();
await returnedTask;

// Single line
await WorkAsync();


// With return value
async Task<int> CalculateAsync()
{
    int result = 42;
    await Task.Delay(1000);
    return result;
}


Task<int> returnedTaskTResult = CalculateAsync()
int intResult1 = await returnedTaskTResult;

// Single line
int intResult2 = await CalculateAsync()


// Converting values to tasks
Task<int> CalculateTaskAsync()
{
    return Task.FromResult(42);
}


// Version 1: async
async Task<int> DelegateCalculationV1Async()
{
    // Perform some work here ...
    // And then await calculation
    return await CalculateTaskAsync();
}

// Version 2: task
Task<int> DelegateCalculationV1Async()
{
    // Perform some work here ...
    // And then return calculate task
    return CalculateTaskAsync();
}
