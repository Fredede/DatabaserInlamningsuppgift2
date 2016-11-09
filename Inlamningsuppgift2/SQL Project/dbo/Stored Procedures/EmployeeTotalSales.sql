CREATE PROCEDURE EmployeeTotalSales (@EmployeeID INT)
AS

SELECT SUM([Order Details].UnitPrice*[Order Details].Quantity*(1-[Order Details].Discount)) AS TotalOrderValue, Employees.EmployeeID
FROM     Employees INNER JOIN
                  Orders ON Employees.EmployeeID = Orders.EmployeeID INNER JOIN
                  [Order Details] ON Orders.OrderID = [Order Details].OrderID
WHERE Employees.EmployeeID = @EmployeeID
GROUP BY Employees.EmployeeID

EXEC EmployeeTotalSales 3
