CREATE OR ALTER PROCEDURE CreateToDoItem
(
    @Title VARCHAR(100) NULL,
    @State VARCHAR(10) NULL
)
AS
BEGIN
    INSERT INTO dbo.ToDoItems
    (
        Title,
        State
    )
    VALUES
    (   @Title, -- Title - varchar(100)
        @State  -- State - varchar(10)
        );
END;
