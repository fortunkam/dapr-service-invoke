using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", async () => {
    CancellationTokenSource source = new CancellationTokenSource();
    CancellationToken cancellationToken = source.Token;
    using var client = new DaprClientBuilder().Build();
    //Using Dapr SDK to invoke a method
    var request = client.CreateInvokeMethodRequest(HttpMethod.Get, "inner", "api/OUTER");
    var response = await client.InvokeMethodWithResponseAsync(request);
    var responseVal = await response.Content.ReadAsStringAsync();

    return $"OK from Outer (response from Inner = '{responseVal}')";
});

app.Run();
