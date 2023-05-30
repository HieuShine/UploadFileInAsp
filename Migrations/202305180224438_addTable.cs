namespace uploadFile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.doanhngiep",
                c => new
                    {
                        idDN = c.Int(nullable: false, identity: true),
                        tenDN = c.String(maxLength: 255),
                        id = c.Int(),
                    })
                .PrimaryKey(t => t.idDN)
                .ForeignKey("dbo.tailieudinhkem", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.tailieudinhkem",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DuongDan = c.String(maxLength: 255),
                        MoTa = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.doanhngiep", "id", "dbo.tailieudinhkem");
            DropIndex("dbo.doanhngiep", new[] { "id" });
            DropTable("dbo.tailieudinhkem");
            DropTable("dbo.doanhngiep");
        }
    }
}
