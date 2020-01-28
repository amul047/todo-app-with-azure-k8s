CREATE OR ALTER PROCEDURE dbo.GetAllToDoItems
AS
BEGIN
    SELECT Id,
           Title,
           State
    FROM dbo.ToDoItems;
END;
