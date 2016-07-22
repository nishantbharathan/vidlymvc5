namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToMemberShipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE  MemberShipTypes Set Name='Pay as You Go' where Id=1");
            Sql("UPDATE  MemberShipTypes Set Name='Monthly' where Id=2");
            Sql("UPDATE  MemberShipTypes Set Name='Quarterly' where Id=3");
            Sql("UPDATE  MemberShipTypes Set Name='Annual' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
