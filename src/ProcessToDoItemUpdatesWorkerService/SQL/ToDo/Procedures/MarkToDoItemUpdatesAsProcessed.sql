CREATE OR ALTER PROCEDURE MarkToDoItemUpdatesAsProcessed
(@lastProcessedToDoItemUpdateId INT)
AS
BEGIN
    DECLARE @now DATETIME2 = GETDATE();

    UPDATE dbo.ToDoItemUpdates
    SET TimeProcessed = @now
    WHERE TimeProcessed IS NULL
          AND Id <= @lastProcessedToDoItemUpdateId;
END;