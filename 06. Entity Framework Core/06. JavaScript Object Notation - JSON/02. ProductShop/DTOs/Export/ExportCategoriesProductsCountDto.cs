namespace ProductShop.DTOs.Export;
public class ExportCategoriesProductsCountDto
{
    public string Category { get; internal set; }
    public int ProductsCount { get; internal set; }
    public string AveragePrice { get; internal set; }
    public string TotalRevenue { get; internal set; }
}
