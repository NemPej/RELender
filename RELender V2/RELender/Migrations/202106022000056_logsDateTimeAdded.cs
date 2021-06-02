namespace RELender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logsDateTimeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "DateTime");
        }
    }
}
