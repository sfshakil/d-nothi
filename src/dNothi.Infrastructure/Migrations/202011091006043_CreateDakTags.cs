namespace Nothi.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDakTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DakInboxList",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dak_tagsid = c.Int(nullable: false),
                       
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DakTag", t => t.dak_tagsid, cascadeDelete: true)
                .Index(t => t.dak_tagsid);
            
            CreateTable(
                "dbo.DakTag",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dak_custom_label_id = c.Int(nullable: false),
                        dak_id = c.Int(nullable: false),
                        dak_type = c.String(),
                        is_copied_dak = c.Int(nullable: false),
                        tag = c.String(),
                       
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DakInboxList", "dak_tagsid", "dbo.DakTag");
            DropIndex("dbo.DakInboxList", new[] { "dak_tagsid" });
            DropTable("dbo.DakTag");
            DropTable("dbo.DakInboxList");
        }
    }
}
