namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDatainGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) Values('Comedy'),('Action'),('Family'),('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
