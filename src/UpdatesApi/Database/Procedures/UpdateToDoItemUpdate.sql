CREATE OR ALTER PROCEDURE dbo.UpdateToDoItemUpdate(
	@ItemId VARCHAR(100),
	@Title VARCHAR(100),
	@State VARCHAR(10)
)
AS
BEGIN
	INSERT INTO dbo.ToDoItemUpdates
	(
		ItemId,
	    Title,
	    State
	)
	VALUES
	(
		@ItemId,
	    @Title,           -- Title - varchar(100)
	    @State            -- State - varchar(10)
	)
END
