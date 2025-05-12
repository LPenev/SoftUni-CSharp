using Boardgames.Data.Models.Enums;

namespace Boardgames.Common;

public static class ValidationConstants
{
    // Boardgames
    public const int BoardgameNameMinLenght = 10;
    public const int BoardgameNameMaxLenght = 20;
    public const double BoardgameRatingMinLenght = 1;
    public const double BoardgameRatingMaxLenght = 10;
    public const int BoardgameYearPublishedMin = 2018;
    public const int BoardgameYearPublishedMax = 2023;
    public const int BoardgameCategoryTypeMin = (int)CategoryType.Abstract;
    public const int BoardgameCategoryTypeMax = (int)CategoryType.Strategy;


    // Seller
    public const int SellerNameMinLenght = 5;
    public const int SellerNameMaxLenght = 20;
    public const int SellerAddressMinLenght = 2;
    public const int SellerAddressMaxLenght = 30;
    public const string SellerWebsiteRegExpression = @"www\.[A-Za-z0-9\-]+\.com";

    // Creator
    public const int CreatorFirstNameMinLenght = 2;
    public const int CreatorFirstNameMaxLenght = 7;
    public const int CreatorLastNameMinLenght = 2;
    public const int CreatorLastNameMaxLenght = 7;


}
