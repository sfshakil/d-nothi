namespace Nothi.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDakUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DakInboxList", "dak_tagsid", "dbo.DakTag");
            DropPrimaryKey("dbo.DakInboxList");
            DropPrimaryKey("dbo.DakTag");
            CreateTable(
                "dbo.DakUser",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dak_id = c.Int(nullable: false),
                        dak_type = c.String(),
                        is_copied_dak = c.Int(nullable: false),
                        dak_origin = c.String(),
                        from_potrojari = c.Int(nullable: false),
                        dak_view_status = c.String(),
                        attention_type = c.String(),
                        dak_priority = c.String(),
                        dak_security = c.String(),
                        dak_movement_sequence = c.Int(nullable: false),
                        last_movement_date = c.String(),
                        dak_category = c.String(),
                        dak_subject = c.String(),
                        dak_decision = c.String(),
                        drafted_decisions = c.String(),
                      
                    })
                .PrimaryKey(t => t.id);
            
            AlterColumn("dbo.DakInboxList", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.DakInboxList", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DakTag", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.DakTag", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DakInboxList", "id");
            AddPrimaryKey("dbo.DakTag", "id");
            AddForeignKey("dbo.DakInboxList", "dak_tagsid", "dbo.DakTag", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DakInboxList", "dak_tagsid", "dbo.DakTag");
            DropPrimaryKey("dbo.DakTag");
            DropPrimaryKey("dbo.DakInboxList");
            AlterColumn("dbo.DakTag", "id", c => c.Long(nullable: false));
            AlterColumn("dbo.DakTag", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DakInboxList", "id", c => c.Long(nullable: false));
            AlterColumn("dbo.DakInboxList", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.DakUser");
            AddPrimaryKey("dbo.DakTag", "id");
            AddPrimaryKey("dbo.DakInboxList", "id");
            AddForeignKey("dbo.DakInboxList", "dak_tagsid", "dbo.DakTag", "id", cascadeDelete: true);
        }
    }
}
