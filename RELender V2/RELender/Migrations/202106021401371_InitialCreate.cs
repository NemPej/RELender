namespace RELender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        PhoneNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        PhoneNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RealEstateOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        PhoneNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RealEstates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Area = c.Int(nullable: false),
                        NoBeds = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        NoRooms = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RealEstateOwners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.RentingRights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerCompensation = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Agency_Id = c.Int(),
                        RealEstate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agencies", t => t.Agency_Id)
                .ForeignKey("dbo.RealEstates", t => t.RealEstate_Id)
                .Index(t => t.Agency_Id)
                .Index(t => t.RealEstate_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentingRights", "RealEstate_Id", "dbo.RealEstates");
            DropForeignKey("dbo.RentingRights", "Agency_Id", "dbo.Agencies");
            DropForeignKey("dbo.RealEstates", "OwnerId", "dbo.RealEstateOwners");
            DropIndex("dbo.RentingRights", new[] { "RealEstate_Id" });
            DropIndex("dbo.RentingRights", new[] { "Agency_Id" });
            DropIndex("dbo.RealEstates", new[] { "OwnerId" });
            DropTable("dbo.RentingRights");
            DropTable("dbo.RealEstates");
            DropTable("dbo.RealEstateOwners");
            DropTable("dbo.Clients");
            DropTable("dbo.Agents");
            DropTable("dbo.Agencies");
        }
    }
}
