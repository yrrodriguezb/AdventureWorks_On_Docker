-- 1. Seleccionar los primeros 10 productos
SELECT TOP 10 *
FROM Production.Product;

-- 2. Seleccionar los nombres de los productos y sus precios de lista
SELECT Name, ListPrice
FROM Production.Product;

-- 3. Listar las órdenes de ventas con su total mayor a 150000
SELECT SalesOrderID, OrderDate, TotalDue
FROM Sales.SalesOrderHeader
WHERE TotalDue > 150000
ORDER BY OrderDate DESC;


-- Funciones de agregación

-- 4. Contar el número de producto
SELECT COUNT(*) AS TotalProductos
FROM Production.Product;

-- 5. Calcular la suma del costo estándar de todos los productos
SELECT SUM(StandardCost) AS SumaTotalCostos
FROM Production.Product;

-- 6. Calcular el promedio del precio de lista de los productos
SELECT AVG(ListPrice) AS PromedioPrecioLista
FROM Production.Product;

-- 7. Encontrar el precio de lista máximo de los productos
SELECT MAX(ListPrice) AS PrecioMaximo
FROM Production.Product;

-- 8. Encontrar el precio de lista mínimo de los productos
SELECT MIN(ListPrice) AS PrecioMinimo
FROM Production.Product;

-- 9. Prodcutos que tienen asignados un color
SELECT COUNT(Color), Color
FROM Production.Product
GROUP BY Color
HAVING COUNT(Color) > 0
ORDER BY 1
