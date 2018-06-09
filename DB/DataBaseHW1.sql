SELECT ord.SupplierID, ord.OrderDate, ord.EstimatedDeliveryDate, 
DATEDIFF(DAY, ord.OrderDate, ord.EstimatedDeliveryDate) AS DayExpect FROM Orders ord
WHERE DATEDIFF(DAY, GETDATE(), ord.EstimatedDeliveryDate) > 0;

SELECT bill.CustomerID, CONVERT(VARCHAR(10), bill.Created, 105) AS created FROM OutBill bill
WHERE YEAR(bill.Created) = YEAR(GETDATE())
AND DATEPART(QUARTER,bill.Created) = DATEPART(QUARTER,GETDATE())
ORDER BY  bill.Created DESC;

SELECT ord.ItemID, ord.Quantity, ord.DeliveredQuantity, ord.DeliveredDate,
(ord.Quantity - ord.DeliveredQuantity)*ord.Price AS Lack
FROM OrdersItem ord
WHERE DATEPART(WEEK,ord.DeliveredDate) = DATEPART(WEEK,GETDATE())-1
AND (ord.Quantity - ord.DeliveredQuantity)*ord.Price > 0;
