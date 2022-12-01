Select ProductName, CategoryName From 
(products LEFT JOIN products_categories ON products.ProductID = products_categories.ProductID 
LEFT JOIN categories ON products_categories.CategoryID = categories.CategoryID)



