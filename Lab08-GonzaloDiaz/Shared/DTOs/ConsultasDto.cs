using System;
using System.Collections.Generic;

namespace Lab08_GonzaloDiaz.DTOs;

public class ProductOrderDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
}

public class ClientOrderCountDto
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public int OrderCount { get; set; }
}

public class SoldProductDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
}

public class OrderWithDetailsDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<ProductOrderDto> Details { get; set; } = new();
}