using Microsoft.Extensions.Primitives;

namespace TravelAgency.Common;

public static class ValidationConstants
{
    public const int CustomerFullNameMinLength = 4;
    public const int CustomerFullNameMaxLength = 60;
    public const int CustomerEmailMinLength = 6;
    public const int CustomerEmailMaxLength = 50;
    public const int CustomerPhoneNumberLength = 13;
    public const string CustomerPhoneNumberRegExpression = @"^\+[0-9]{12,12}";

    public const int GuideFullNameMinLength = 4;
    public const int GuideFullNameMaxLength = 60;

    public const int TourPackagePackageNameMinLength = 2;
    public const int TourPackagePackageNameMaxLength = 40;
    public const int TourPackageDescriptionMaxLength = 200;

}
