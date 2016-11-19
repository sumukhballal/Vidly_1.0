namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addisuscribetonewsproperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "MembershipType_memberid");
            DropColumn("dbo.Customers", "MembershipType_duration");
            DropColumn("dbo.Customers", "MembershipType_signupfee");
            DropColumn("dbo.Customers", "MembershipType_discount");
            DropColumn("dbo.Customers", "MembershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_discount", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_signupfee", c => c.Short(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_duration", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_memberid", c => c.Byte(nullable: false));
        }
    }
}
