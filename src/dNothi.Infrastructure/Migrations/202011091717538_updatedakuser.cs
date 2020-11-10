namespace Nothi.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedakuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DakInboxList", "dak_tagsid", "dbo.DakTag");
            DropPrimaryKey("dbo.DakInboxList");
            DropPrimaryKey("dbo.DakTag");
            DropPrimaryKey("dbo.DakUser");
            AlterColumn("dbo.DakInboxList", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.DakInboxList", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DakTag", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.DakTag", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DakUser", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.DakUser", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.DakInboxList", "id");
            AddPrimaryKey("dbo.DakTag", "id");
            AddPrimaryKey("dbo.DakUser", "Id");
            AddForeignKey("dbo.DakInboxList", "dak_tagsid", "dbo.DakTag", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DakInboxList", "dak_tagsid", "dbo.DakTag");
            DropPrimaryKey("dbo.DakUser");
            DropPrimaryKey("dbo.DakTag");
            DropPrimaryKey("dbo.DakInboxList");
            AlterColumn("dbo.DakUser", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.DakUser", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DakTag", "id", c => c.Long(nullable: false));
            AlterColumn("dbo.DakTag", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DakInboxList", "id", c => c.Long(nullable: false));
            AlterColumn("dbo.DakInboxList", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DakUser", "id");
            AddPrimaryKey("dbo.DakTag", "id");
            AddPrimaryKey("dbo.DakInboxList", "id");
            AddForeignKey("dbo.DakInboxList", "dak_tagsid", "dbo.DakTag", "id", cascadeDelete: true);
        }
    }
}
