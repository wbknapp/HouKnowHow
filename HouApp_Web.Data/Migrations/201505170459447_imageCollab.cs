namespace HouApp_Web.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageCollab : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageCollabs",
                c => new
                    {
                        ImageCollabId = c.Int(nullable: false, identity: true),
                        LocLat = c.String(),
                        LocLong = c.String(),
                        UrlString = c.String(),
                        PostType = c.String(),
                    })
                .PrimaryKey(t => t.ImageCollabId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageCollabs");
        }
    }
}
