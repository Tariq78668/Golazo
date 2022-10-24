namespace Golazo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scheduleraddition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblScheduler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroundName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblScheduler");
        }
    }
}
