namespace HouApp_Web.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageprops : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageCollabs", "Address", c => c.String());
            AddColumn("dbo.ImageCollabs", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImageCollabs", "Description");
            DropColumn("dbo.ImageCollabs", "Address");
        }
    }
}
