namespace NetPay.Common;

public static class ValidationConstants
{
    //Household
    public const int HouseholdContactPersonMinLength = 5;
    public const int HouseholdContactPersonMaxLength = 50;

    public const int HouseholdEmailMinLength = 6;
    public const int HouseholdEmailMaxLength = 80;

    public const int HouseholdPhoneNumberLength = 15;
    public const string HouseholdPhoneNumberPattern = @"^\+\d{3}/\d{3}-\d{6}$";
    public const string HouseholdXmlPhoneAttribute = "phone";

    //Expence
    public const int ExpenceNameMinLength = 5;
    public const int ExpenceNameMaxLength = 50;

    public const double ExpenceMinAmount = 0.01;
    public const double ExpenceMaxAmount = 100000;

    //Service
    public const int ServiceNameMinLength = 4;
    public const int ServiceNameMaxLength = 60;

    //Supplier
    public const int SupplierNameMinLength = 3;
    public const int SupplierNameMaxLength = 60;
}
