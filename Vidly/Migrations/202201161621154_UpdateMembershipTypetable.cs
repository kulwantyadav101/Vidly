namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypetable : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name = 'Pay as you Go' WHERE Id=1");
            Sql("Update MembershipTypes SET Name = 'Monthly' WHERE Id=2");

        }

        public override void Down()
        {
        }
    }
}
