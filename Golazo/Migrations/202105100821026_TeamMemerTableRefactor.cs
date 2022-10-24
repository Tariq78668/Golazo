namespace Golazo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamMemerTableRefactor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblTeamMember", "TeamName", c => c.String());
            AlterColumn("dbo.tblTeamMember", "MemberId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblTeamMember", "MemberId", c => c.Int(nullable: false));
            DropColumn("dbo.tblTeamMember", "TeamName");
        }
    }
}
