-- Add check constraint
ALTER TABLE [Users] ADD CONSTRAINT CHK_Password CHECK(LEN(Password) >= 5)