

insert into InfoBook (BookName,AuthorName,	Publisher,	Category,	ISBN,	PublishYear)
SELECT A.BookName, A.AuthorName, A.Publisher,A.Category, A.ISBN,  A.PublishYear
FROM OPENROWSET 
('Microsoft.Jet.OLEDB.4.0', 'Excel 8.0;Database=C:\Users\HP\Desktop\Book.xls; HDR=YES', 'select * from [BookList$]') AS A;













