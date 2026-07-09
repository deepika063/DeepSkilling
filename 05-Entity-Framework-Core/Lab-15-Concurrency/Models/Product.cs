using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}
