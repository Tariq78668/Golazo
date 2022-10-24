namespace Golazo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamMembermigraton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblTeamMember",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        MemberEmail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblTeamMember");
        }
    }
}
