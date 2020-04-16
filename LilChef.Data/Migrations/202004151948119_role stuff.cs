namespace LilChef.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolestuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Author", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Author");
        }
    }
}
