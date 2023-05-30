namespace uploadFile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tailieudinhkem", "filePdf", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tailieudinhkem", "filePdf");
        }
    }
}
