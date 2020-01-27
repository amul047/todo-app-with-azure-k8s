CREATE OR ALTER PROCEDURE GetToDoItemUpdatesToProcess
(@lastProcessedToDoItemUpdateId INT)
AS
BEGIN
    SELECT Id,
           ItemId AS ToDoItemId,
           Title,
           State
    FROM dbo.ToDoItemUpdates
    WHERE TimeProcessed IS NULL
        AND Id > @lastProcessedToDoItemUpdateId;
END;
