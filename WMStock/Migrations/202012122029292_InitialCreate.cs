namespace WMStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrandID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryID = c.Int(nullable: false, identity: true),
                        InventoryName = c.String(),
                        PersonalID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                        ModalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryID)
                .ForeignKey("dbo.Brand", t => t.BrandID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .ForeignKey("dbo.Personal", t => t.PersonalID)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .ForeignKey("dbo.Modal", t => t.ModalID)
                .Index(t => t.PersonalID)
                .Index(t => t.LocationID)
                .Index(t => t.CategoryID)
                .Index(t => t.BrandID)
                .Index(t => t.ModalID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Personal",
                c => new
                    {
                        PersonalId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Pjob = c.String(),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonalId)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Modal",
                c => new
                    {
                        ModalID = c.Int(nullable: false, identity: true),
                        ModalName = c.String(),
                        CategoryID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModalID)
                .ForeignKey("dbo.Brand", t => t.BrandID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.BrandID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventory", "ModalID", "dbo.Modal");
            DropForeignKey("dbo.Modal", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Modal", "BrandID", "dbo.Brand");
            DropForeignKey("dbo.Inventory", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Inventory", "PersonalID", "dbo.Personal");
            DropForeignKey("dbo.Personal", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Department", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Inventory", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Inventory", "BrandID", "dbo.Brand");
            DropForeignKey("dbo.Brand", "CategoryID", "dbo.Category");
            DropIndex("dbo.Modal", new[] { "BrandID" });
            DropIndex("dbo.Modal", new[] { "CategoryID" });
            DropIndex("dbo.Personal", new[] { "DepartmentID" });
            DropIndex("dbo.Department", new[] { "LocationID" });
            DropIndex("dbo.Inventory", new[] { "ModalID" });
            DropIndex("dbo.Inventory", new[] { "BrandID" });
            DropIndex("dbo.Inventory", new[] { "CategoryID" });
            DropIndex("dbo.Inventory", new[] { "LocationID" });
            DropIndex("dbo.Inventory", new[] { "PersonalID" });
            DropIndex("dbo.Brand", new[] { "CategoryID" });
            DropTable("dbo.Modal");
            DropTable("dbo.Personal");
            DropTable("dbo.Department");
            DropTable("dbo.Location");
            DropTable("dbo.Inventory");
            DropTable("dbo.Category");
            DropTable("dbo.Brand");
        }
    }
}
