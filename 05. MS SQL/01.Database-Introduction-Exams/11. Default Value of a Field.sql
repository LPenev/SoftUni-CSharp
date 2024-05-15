--Add by default CurrentTime in column

ALTER TABLE [Users] ADD CONSTRAINT df_CurrentTime DEFAULT CURRENT_TIMESTAMP FOR LastLoginTime