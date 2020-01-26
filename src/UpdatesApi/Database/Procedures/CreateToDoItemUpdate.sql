CREATE OR ALTER PROCEDURE dbo.CreateToDoItemUpdate(
	@Title VARCHAR(100),
	@State VARCHAR(10)
)
AS
BEGIN
	INSERT INTO dbo.ToDoItemUpdates
	(
	    Title,
	    State
	)
	VALUES
	(
	    @Title,           -- Title - varchar(100)
	    @State            -- State - varchar(10)
	)
END
