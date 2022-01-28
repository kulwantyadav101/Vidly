namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePjoneNumberInAspnetUsersTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
Update  [dbo].[AspNetUsers] SET PhoneNumber = '12345676'

");
        }
        
        public override void Down()
        {
        }
    }
}
