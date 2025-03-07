namespace ProductShop.DTOs.Export;
public class ExportCategoriesProductsCountDto
{
    public string Category { get; internal set; }
    public int ProductCount { get; internal set; }
    public decimal AveragePrice { get; internal set; }
    public decimal TotalRevenue { get; internal set; }
}
