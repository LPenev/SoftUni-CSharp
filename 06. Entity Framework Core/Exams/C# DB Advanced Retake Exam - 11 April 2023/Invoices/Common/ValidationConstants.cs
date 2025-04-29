using Invoices.Data.Models.Enums;

namespace Invoices.Common;

public static class ValidationConstants
{
    // Product
    public const int ProductNameMinLenght = 9;
    public const int ProductNameMaxLenght = 30;

    public const string ProductPriceMinValue = "5";
    public const string ProductPriceMaxValue = "1000";

    public const int ProductCategoryTypeMinValue = (int)CategoryType.ADR;
    public const int ProductCategoryTypeMaxValue = (int)CategoryType.Tyres;


    //Address
    public const int AddressStreetNameMinLenght = 10;
    public const int AddressStreetNameMaxLenght = 20;

    public const int AddressCityMinLenght = 5;
    public const int AddressCityMaxLenght = 15;

    public const int AddressCountryMinLenght = 5;
    public const int AddressCountryMaxLenght = 15;


    // Invoice
    public const int InvoiceMinNumber = 1_000_000_000;
    public const int InvoiceMaxNumber = 1_500_000_000;
    public const int InvoiceMinCurrencyType = (int)CurrencyType.BGN;
    public const int InvoiceMaxCurrencyType = (int)CurrencyType.USD;



    // Client
    public const int ClientNameMinLenght = 10;
    public const int ClientNameMaxLenght = 25;
    public const int ClientNumberVatMinLenght = 10;
    public const int ClientNumberVatMaxLenght = 15;

}
