namespace PetFriendly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiparisDetayları : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiparisDetaylar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductAd = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Piece = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Siparisler", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Urunler", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Siparisler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(maxLength: 128),
                        SehirId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Address2 = c.String(),
                        ZIP = c.String(nullable: false),
                        PaymentTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerID)
                .ForeignKey("dbo.Şehirler", t => t.SehirId, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.SehirId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SiparisDetaylar", "ProductId", "dbo.Urunler");
            DropForeignKey("dbo.Siparisler", "SehirId", "dbo.Şehirler");
            DropForeignKey("dbo.SiparisDetaylar", "OrderId", "dbo.Siparisler");
            DropForeignKey("dbo.Siparisler", "CustomerID", "dbo.AspNetUsers");
            DropIndex("dbo.Siparisler", new[] { "SehirId" });
            DropIndex("dbo.Siparisler", new[] { "CustomerID" });
            DropIndex("dbo.SiparisDetaylar", new[] { "ProductId" });
            DropIndex("dbo.SiparisDetaylar", new[] { "OrderId" });
            DropTable("dbo.Siparisler");
            DropTable("dbo.SiparisDetaylar");
        }
    }
}
