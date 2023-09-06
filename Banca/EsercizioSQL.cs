
//--1)
//SELECT COUNT(*) FROM Orders

//--2)
//SELECT COUNT(*) FROM Employees

//--3)
//SELECT COUNT(*)FROM Employees
//GROUP BY City
//HAVING City='London'

//--4)
//SELECT AVG(Freight) FROM Orders

//--5)
//SELECT AVG(Freight) FROM Orders
//GROUP BY CustomerID
//HAVING CustomerID='BOTTM'

//--6)
//SELECT COUNT(*),EmployeeID FROM Orders
//GROUP BY EmployeeID
//--7)
//SELECT COUNT(EmployeeID) as Employee,city FROM Employees
//GROUP  BY City

//--8)
//SELECT(UnitPrice* Quantity),OrderID FROM[Order Details]

//--9)
//SELECT(UnitPrice* Quantity),OrderID FROM[Order Details]
//WHERE OrderID = 10248

//--10)
//SELECT COUNT(*),CategoryID FROM Products
//GROUP BY CategoryID

//--11)
//SELECT COUNT(OrderID),ShipCountry FROM Orders
//GROUP BY ShipCountry

//--12)
//SELECT AVG(Freight) ,ShipCountry FROM Orders
//GROUP BY ShipCountry
//    }

