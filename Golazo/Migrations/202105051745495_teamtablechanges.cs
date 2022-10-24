namespace Golazo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamtablechanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "TeamModel_ID", newName: "Team_ID");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_TeamModel_ID", newName: "IX_Team_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Team_ID", newName: "IX_TeamModel_ID");
            RenameColumn(table: "dbo.AspNetUsers", name: "Team_ID", newName: "TeamModel_ID");
        }
    }
}
