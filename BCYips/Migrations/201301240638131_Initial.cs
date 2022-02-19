namespace BCYips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yips",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        YipperID = c.Int(nullable: false),
                        Content = c.String(maxLength: 140),
                        Posted = c.DateTime(nullable: false),
                        ReYip_ID = c.Int(),
                        ReplyTo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Yippers", t => t.YipperID, cascadeDelete: true)
                .ForeignKey("dbo.Yips", t => t.ReYip_ID)
                .ForeignKey("dbo.Yips", t => t.ReplyTo_ID)
                .Index(t => t.YipperID)
                .Index(t => t.ReYip_ID)
                .Index(t => t.ReplyTo_ID);
            
            CreateTable(
                "dbo.Yippers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Yips", new[] { "ReplyTo_ID" });
            DropIndex("dbo.Yips", new[] { "ReYip_ID" });
            DropIndex("dbo.Yips", new[] { "YipperID" });
            DropForeignKey("dbo.Yips", "ReplyTo_ID", "dbo.Yips");
            DropForeignKey("dbo.Yips", "ReYip_ID", "dbo.Yips");
            DropForeignKey("dbo.Yips", "YipperID", "dbo.Yippers");
            DropTable("dbo.Yippers");
            DropTable("dbo.Yips");
        }
    }
}
