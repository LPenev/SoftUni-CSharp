-- Delete Constraint /Primary Key/
ALTER TABLE [Users] DROP CONSTRAINT PK__Users__3214EC07BCCF7CB9

--Add Primary KEY to two columns
ALTER TABLE [Users] ADD CONSTRAINT PK_Users PRIMARY KEY(Id,Username)