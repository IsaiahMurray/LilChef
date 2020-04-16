namespace LilChef.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalHopefully : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Author", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Author", c => c.String(nullable: false));
        }
    }
}
