-- Create the stored procedure
CREATE PROCEDURE usp_SearchByCountry
    @country NVARCHAR(50)
AS
BEGIN
    -- Declare variables
    DECLARE @CountryId INT;

    -- Get the CountryId for the specified country name
    SELECT @CountryId = Id
    FROM Countries
    WHERE [Name] = @country;

    -- Print the header
    PRINT 'Name | PhoneNumber | Email | CountOfBookings';

    -- Select and print tourist information for the specified country
    SELECT
        T.Name,
        T.PhoneNumber,
        T.Email,
        COUNT(B.Id) AS CountOfBookings
    FROM
        Tourists AS T
    INNER JOIN
        Bookings AS B ON T.Id = B.TouristId
    WHERE
        T.CountryId = @CountryId
    GROUP BY
        T.Name,
        T.PhoneNumber,
        T.Email
    ORDER BY
        T.Name ASC,
        CountOfBookings DESC;
END;

EXEC usp_SearchByCountry 'Greece';