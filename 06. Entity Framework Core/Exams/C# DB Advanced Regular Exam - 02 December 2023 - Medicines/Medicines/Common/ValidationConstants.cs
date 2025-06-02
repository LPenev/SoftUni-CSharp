namespace Medicines.Common;

public static class ValidationConstants
{
    public const int PharmacyNameMinLength = 2;
    public const int PharmacyNameMaxLength = 50;
    public const int PharmacyPhoneNumberLength = 13;
    public const string PharmacyPhoneNumberRegEx = @"\([0-9]{3}\) [0-9]{3}\-[0-9]{4}";

    public const int MedicineNameMinLength = 3;
    public const int MedicineNameMaxLength = 150;
    public const double MedicinePriceMin = 0.01;
    public const int MedicinePriceMax = 1000;
    public const int MedicineProducerMinLength = 3;
    public const int MedicineProducerMaxLength = 100;

    public const int PatientFullNameMinLength = 5;
    public const int PatientFullNameMaxLength = 100;
}
