namespace Golazo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamIdtoScedulr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblScheduler", "TeamId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblScheduler", "TeamId");
        }
    }
}
