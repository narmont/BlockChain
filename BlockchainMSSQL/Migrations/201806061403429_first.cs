namespace BlockchainMSSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        BlockId = c.Int(nullable: false, identity: true),
                        Version = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        Hash = c.String(),
                        PreviousHash = c.String(),
                        Data = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlockId)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blocks", "UserID", "dbo.Users");
            DropIndex("dbo.Blocks", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Blocks");
        }
    }
}
