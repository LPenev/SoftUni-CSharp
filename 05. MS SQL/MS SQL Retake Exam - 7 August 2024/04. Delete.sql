USE ShoesApplicationDatabase;

DELETE FROM ShoesSizes WHERE ShoeId = (SELECT Id FROM Shoes WHERE Model = 'Joyride Run Flyknit')
DELETE FROM ORDERS WHERE ShoeId = (SELECT Id FROM Shoes WHERE Model = 'Joyride Run Flyknit')
DELETE FROM Shoes WHERE Model = 'Joyride Run Flyknit'
