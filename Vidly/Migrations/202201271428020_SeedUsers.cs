namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'83991571-920a-4cae-9513-85f5694b7c15', N'admin@vidly.com', 0, N'APis/bjd7Nm9jo92HSOzcI/03oH49ui9FUYQSXZMOo0Gy1xsstK+pLBYcWfX3z6Nnw==', N'c35da72e-62f0-43bd-869b-7f6b5d4e8685', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a16eed28-6761-4fe4-abd2-a5a27d245fd8', N'guest@vidly.com', 0, N'AFOO6mc2um+lmFM+MCyFLBhtq83V5k8Bez0rU78nCvMN32mH3XgYfhte3mW23Z9s4Q==', N'3ae47fda-bb89-4a80-b25d-b8a57d07066d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'41bf4c16-f099-466b-be8b-900107dcd0f8', N'canManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'83991571-920a-4cae-9513-85f5694b7c15', N'41bf4c16-f099-466b-be8b-900107dcd0f8')

");
        }
        
        public override void Down()
        {
        }
    }
}
