namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedstoMembershipTypeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id", newName: "MembershipTypeId");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "MembershipTypesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipTypesId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipType_Id");
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
