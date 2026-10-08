var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/vat", (decimal price, decimal vatRate = 8.1m) =>
{
    var vatAmount = Math.Round(price * vatRate / 100, 2);
    var totalPrice = price + vatAmount;

    return Results.Ok(new
    {
        Price = price,
        VatRate = vatRate,
        VatAmount = vatAmount,
        TotalPrice = totalPrice
    });
});

app.Run();