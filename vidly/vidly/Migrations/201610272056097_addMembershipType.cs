namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
              "dbo.MembershipTypes",
              c => new
              {
                  Id = c.Byte(nullable: false, identity: true),
                  SignUpFee = c.Short(),
                  DurationInMonths = c.Byte(),
                  DiscountRate = c.Byte()
                 })
              .PrimaryKey(t => t.Id);

            DropForeignKey("dbo.MembershipTypes", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.MembershipTypes", new[] { "MembershipTypeId" });
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            // DropColumn("dbo.MembershipTypes", "MembershipTypeId");
        }

        public override void Down()
        {
            DropTable("dbo.MembershipTypes");
            AddColumn("dbo.MembershipTypes", "MembershipTypeId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            CreateIndex("dbo.MembershipTypes", "MembershipTypeId");
            AddForeignKey("dbo.MembershipTypes", "MembershipTypeId", "dbo.MembershipTypes", "Id");
        }
    }
}
