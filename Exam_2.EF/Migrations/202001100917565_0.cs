namespace Exam_2.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                {
                    CityId = c.Int(nullable: false, identity: true),
                    Street = c.String(nullable: false),
                })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Cities", x => x.CityId)
                .Index(x => x.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.Int(nullable: false),
                        Longitude = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Address_CityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_CityId)
                .Index(t => t.Address_CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Address_CityId", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "Address_CityId" });
            DropTable("dbo.People");
            DropTable("dbo.Cities");
            DropTable("dbo.Addresses");
        }
    }
}
