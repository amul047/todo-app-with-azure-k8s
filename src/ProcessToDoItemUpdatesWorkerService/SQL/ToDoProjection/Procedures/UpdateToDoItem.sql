CREATE OR ALTER PROCEDURE UpdateToDoItem
(
    @Id INT NULL,
    @Title VARCHAR(100) NULL,
    @State VARCHAR(10) NULL
)
AS
BEGIN
    UPDATE dbo.ToDoItems
    SET Title = @Title,
        State = @State
    WHERE Id = @Id;
END;
