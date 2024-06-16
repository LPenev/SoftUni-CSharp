SELECT 
    Title AS [Book Title],
    ISBN,
    YearPublished AS Released
FROM Books
ORDER BY YearPublished DESC, Title;