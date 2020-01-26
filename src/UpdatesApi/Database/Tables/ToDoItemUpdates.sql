IF (NOT EXISTS (SELECT 1
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'ToDoItemUpdates'))
BEGIN
    
	CREATE TABLE dbo.ToDoItemUpdates(
		[Id] INT NOT NULL IDENTITY(1,1),
		[ItemId] INT NULL,
		[Title] VARCHAR(100) NULL,
		[State] VARCHAR(10) NULL,
		[TimeProcessed] DATETIME2 NULL,
		CONSTRAINT [PK_ToDoItemUpdates] PRIMARY KEY CLUSTERED(Id ASC)
	);

END