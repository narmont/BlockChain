namespace BlockchainMSSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoney : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blocks", "Money", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "Money", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Money");
            DropColumn("dbo.Blocks", "Money");
        }
    }
}
