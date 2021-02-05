namespace Super_Zapatos_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoresArticles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 100),
                        description = c.String(maxLength: 500),
                        price = c.Decimal(nullable: false, storeType: "money"),
                        total_in_shelf = c.Single(nullable: false),
                        total_in_vault = c.Single(nullable: false),
                        store_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Stores", t => t.store_id)
                .Index(t => t.store_id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 100),
                        address = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "store_id", "dbo.Stores");
            DropIndex("dbo.Articles", new[] { "store_id" });
            DropTable("dbo.Stores");
            DropTable("dbo.Articles");
        }
    }
}
