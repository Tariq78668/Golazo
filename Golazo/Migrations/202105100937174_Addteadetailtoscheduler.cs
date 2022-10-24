namespace Golazo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addteadetailtoscheduler : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblScheduler", "TeamName", c => c.String());
            AddColumn("dbo.tblScheduler", "SelfPaid", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblScheduler", "PaidByTeam", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblScheduler", "PaidByTeam");
            DropColumn("dbo.tblScheduler", "SelfPaid");
            DropColumn("dbo.tblScheduler", "TeamName");
        }
    }
}
