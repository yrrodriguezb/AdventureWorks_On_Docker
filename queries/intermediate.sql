-- 1. Obtener el total de ventas por año
SELECT YEAR(OrderDate) AS Year, SUM(TotalDue) AS TotalSales
FROM Sales.SalesOrderHeader
GROUP BY YEAR(OrderDate)
ORDER BY Year;

-- 2. Agrupar por categoría de producto y contar los productos en cada categoría
SELECT p.ProductSubcategoryID, COUNT(*) AS TotalProductos
FROM Production.Product p
GROUP BY p.ProductSubcategoryID;

-- 3. Obtener el promedio de precio de lista de los productos por categoría
SELECT pc.Name AS CategoryName, AVG(p.ListPrice) AS AverageListPrice
FROM Production.Product p
JOIN Production.ProductSubcategory ps ON p.ProductSubcategoryID = ps.ProductSubcategoryID
JOIN Production.ProductCategory pc ON ps.ProductCategoryID = pc.ProductCategoryID
GROUP BY pc.Name
ORDER BY AverageListPrice DESC;

-- 4. Encontrar los empleados que han realizado más de 10 órdenes de ventas
SELECT e.BusinessEntityID, p.FirstName, p.LastName, COUNT(soh.SalesOrderID) AS OrderCount
FROM Sales.SalesOrderHeader soh
JOIN Sales.SalesPerson sp ON soh.SalesPersonID = sp.BusinessEntityID
JOIN HumanResources.Employee e ON sp.BusinessEntityID = e.BusinessEntityID
JOIN Person.Person p ON e.BusinessEntityID = p.BusinessEntityID
GROUP BY e.BusinessEntityID, p.FirstName, p.LastName
HAVING COUNT(soh.SalesOrderID) > 10
ORDER BY OrderCount DESC;

-- 5. Obtener los productos que no se han vendido en el último año
SELECT p.ProductID, p.Name
FROM Production.Product p
LEFT JOIN Sales.SalesOrderDetail sod ON p.ProductID = sod.ProductID
LEFT JOIN Sales.SalesOrderHeader soh ON sod.SalesOrderID = soh.SalesOrderID AND soh.OrderDate >= DATEADD(year, -1, GETDATE())
WHERE soh.SalesOrderID IS NULL
ORDER BY 1;

-- 6. Obtener el nombre completo del cliente y los detalles de sus pedidos.
SELECT c.CustomerID, p.FirstName + ' ' + p.LastName AS FullName, 
       soh.SalesOrderID, soh.OrderDate, sod.ProductID, sod.OrderQty
FROM Sales.Customer c
JOIN Person.Person p ON c.PersonID = p.BusinessEntityID
JOIN Sales.SalesOrderHeader soh ON c.CustomerID = soh.CustomerID
JOIN Sales.SalesOrderDetail sod ON soh.SalesOrderID = sod.SalesOrderID
WHERE soh.OrderDate >= '2014-06-30';
