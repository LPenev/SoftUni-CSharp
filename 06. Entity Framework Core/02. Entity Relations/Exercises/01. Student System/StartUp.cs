
using P01_StudentSystem.Data;

var context = new StudentSystemContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();