namespace BlockchainMSSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blocks", "UserID", "dbo.Users");
            DropIndex("dbo.Blocks", new[] { "UserID" });
            RenameColumn(table: "dbo.Blocks", name: "UserID", newName: "UserFrom_UserId");
            AddColumn("dbo.Blocks", "UserFromID", c => c.Int(nullable: false));
            AddColumn("dbo.Blocks", "UserToID", c => c.Int(nullable: false));
            AddColumn("dbo.Blocks", "UserTo_UserId", c => c.Int());
            AlterColumn("dbo.Blocks", "UserFrom_UserId", c => c.Int());
            CreateIndex("dbo.Blocks", "UserFrom_UserId");
            CreateIndex("dbo.Blocks", "UserTo_UserId");
            AddForeignKey("dbo.Blocks", "UserTo_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Blocks", "UserFrom_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blocks", "UserFrom_UserId", "dbo.Users");
            DropForeignKey("dbo.Blocks", "UserTo_UserId", "dbo.Users");
            DropIndex("dbo.Blocks", new[] { "UserTo_UserId" });
            DropIndex("dbo.Blocks", new[] { "UserFrom_UserId" });
            AlterColumn("dbo.Blocks", "UserFrom_UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Blocks", "UserTo_UserId");
            DropColumn("dbo.Blocks", "UserToID");
            DropColumn("dbo.Blocks", "UserFromID");
            RenameColumn(table: "dbo.Blocks", name: "UserFrom_UserId", newName: "UserID");
            CreateIndex("dbo.Blocks", "UserID");
            AddForeignKey("dbo.Blocks", "UserID", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
