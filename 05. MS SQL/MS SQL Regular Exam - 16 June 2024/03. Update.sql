UPDATE Contacts
SET Website = 'www.' + LOWER(REPLACE(A.Name, ' ', '')) + '.com'
FROM Contacts C
JOIN Authors A ON C.Id = A.ContactId
WHERE C.Website IS NULL;