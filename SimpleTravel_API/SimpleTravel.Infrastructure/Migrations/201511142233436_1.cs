namespace SimpleTravel.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Trips");
            AlterColumn("dbo.Trips", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Trips", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Trips");
            AlterColumn("dbo.Trips", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Trips", "Id");
        }
    }
}
