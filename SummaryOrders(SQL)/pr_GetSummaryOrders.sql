ALTER PROCEDURE pr_GetOrderSummary @StartDate datetime ,@EndDate datetime,@CustomerID nchar(5), @EmployeeID int
AS
SELECT 
    CONCAT(' ', TitleOfCourtesy, FirstName, LastName) AS 'EmployeeFullName', 
	Shippers.CompanyName as 'Shipper CompanyName', 
	Customers.CompanyName as 'Customer CompanyName',
	COUNT(Orders.OrderID) as 'NumberOfOrders',
	Orders.OrderDate as 'Date',
	SUM(Orders.Freight) as 'TotalFreightCost',
	COUNT(DISTINCT Products.ProductID) as 'NumberOfDifferentProducts',
	SUM([Order Details].UnitPrice * Quantity) as 'TotalOrderValue'
FROM Employees
JOIN Orders
ON Employees.EmployeeID = Orders.EmployeeID
JOIN Customers
ON Customers.CustomerID = @CustomerID
JOIN [Order Details]
ON [Order Details].OrderID = Orders.OrderID
JOIN Products
ON Products.ProductID = [Order Details].ProductID
JOIN Shippers
ON Shippers.ShipperID = Orders.ShipVia
WHERE   (OrderDate BETWEEN @StartDate AND @EndDate)
		AND Customers.CustomerID = @CustomerID
		AND Employees.EmployeeID =  @CustomerID
		
GROUP BY Employees.TitleOfCourtesy, Employees.FirstName, Employees.LastName,
Customers.CompanyName,
Orders.OrderDate,
Shippers.CompanyName

