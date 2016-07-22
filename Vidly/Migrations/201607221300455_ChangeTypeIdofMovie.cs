namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeIdofMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Id", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
