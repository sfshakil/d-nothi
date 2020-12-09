namespace Nothi.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DakList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserToken",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Token = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeInfos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        emp_id = c.Int(nullable: false),
                        name_eng = c.String(maxLength: 500),
                        name_bng = c.String(maxLength: 500),
                        father_name_eng = c.String(maxLength: 500),
                        father_name_bng = c.String(maxLength: 500),
                        mother_name_eng = c.String(maxLength: 500),
                        mother_name_bng = c.String(maxLength: 500),
                        date_of_birth = c.DateTime(nullable: false),
                        nid = c.String(maxLength: 50),
                        bcn = c.String(maxLength: 500),
                        ppn = c.String(maxLength: 500),
                        personal_email = c.String(maxLength: 500),
                        personal_mobile = c.String(maxLength: 50),
                        is_cadre = c.Int(nullable: false),
                        default_sign = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NothiListRecords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        office_id = c.Int(nullable: false),
                        office_name = c.String(maxLength: 4000),
                        office_unit_id = c.Int(nullable: false),
                        office_unit_name = c.String(maxLength: 4000),
                        office_unit_organogram_id = c.Int(nullable: false),
                        office_designation_name = c.String(maxLength: 4000),
                        nothi_no = c.String(maxLength: 4000),
                        subject = c.String(maxLength: 4000),
                        nothi_class = c.Int(nullable: false),
                        note_current_status = c.String(maxLength: 4000),
                        priority = c.String(maxLength: 4000),
                        note_count = c.Int(nullable: false),
                        issue_date = c.String(maxLength: 4000),
                        last_note_date = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DakList",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        dak_user_id = c.Long(),
                        dak_origin_id = c.Long(),
                        movement_status_id = c.Long(),
                        attachment_count = c.Long(nullable: false),
                        dak_nothi_id = c.Long(),
                        dak_List_type_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DakType", t => t.dak_List_type_Id, cascadeDelete: true)
                .ForeignKey("dbo.DakNothi", t => t.dak_nothi_id)
                .ForeignKey("dbo.DakOrigin", t => t.dak_origin_id)
                .ForeignKey("dbo.DakUser", t => t.dak_user_id)
                .ForeignKey("dbo.MovementStatus", t => t.movement_status_id)
                .Index(t => t.dak_user_id)
                .Index(t => t.dak_origin_id)
                .Index(t => t.movement_status_id)
                .Index(t => t.dak_nothi_id)
                .Index(t => t.dak_List_type_Id);
            
            CreateTable(
                "dbo.DakType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        total_records = c.Int(nullable: false),
                        is_inbox = c.Boolean(nullable: false),
                        is_outbox = c.Boolean(nullable: false),
                        is_archived = c.Boolean(nullable: false),
                        is_sorted = c.Boolean(nullable: false),
                        is_nothijato = c.Boolean(nullable: false),
                        is_nothivukto = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DakNothi",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        nothi_master_id = c.Int(nullable: false),
                        nothi_note_id = c.Int(nullable: false),
                        nothi_potro_id = c.Int(nullable: false),
                        dak_id = c.Int(nullable: false),
                        dak_type = c.String(maxLength: 4000),
                        is_copied_dak = c.Int(nullable: false),
                        nothi_no = c.String(maxLength: 4000),
                        subject = c.String(maxLength: 4000),
                        office_id = c.Int(nullable: false),
                        office_name = c.String(maxLength: 4000),
                        office_unit_id = c.Int(nullable: false),
                        office_unit_name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DakOrigin",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        dak_origin_id = c.Int(nullable: false),
                        name_eng = c.String(maxLength: 4000),
                        name_bng = c.String(maxLength: 4000),
                        sender_name = c.String(maxLength: 4000),
                        receiving_office_id = c.Int(nullable: false),
                        receiving_office_name = c.String(maxLength: 4000),
                        receiving_office_unit_id = c.Int(nullable: false),
                        receiving_office_unit_name = c.String(maxLength: 4000),
                        receiving_officer_id = c.Int(nullable: false),
                        receiving_officer_designation_id = c.Int(nullable: false),
                        receiving_officer_designation_label = c.String(maxLength: 4000),
                        receiving_officer_name = c.String(maxLength: 4000),
                        docketing_no = c.Int(nullable: false),
                        dak_received_no = c.String(maxLength: 4000),
                        receiving_date = c.String(maxLength: 4000),
                        sender_sarok_no = c.String(maxLength: 4000),
                        sender_officer_id = c.Int(nullable: false),
                        sender_office_name = c.String(maxLength: 4000),
                        sender_office_unit_id = c.Int(nullable: false),
                        sender_office_unit_name = c.String(maxLength: 4000),
                        sender_officer_designation_id = c.Int(nullable: false),
                        sender_officer_designation_label = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DakTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        dak_tag_id = c.Int(nullable: false),
                        dak_custom_label_id = c.Int(nullable: false),
                        dak_id = c.Int(nullable: false),
                        dak_type = c.String(maxLength: 4000),
                        is_copied_dak = c.Int(nullable: false),
                        tag = c.String(maxLength: 4000),
                        dak_list_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DakList", t => t.dak_list_id, cascadeDelete: true)
                .Index(t => t.dak_list_id);
            
            CreateTable(
                "dbo.DakUser",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        dak_id = c.Int(nullable: false),
                        dak_type = c.String(maxLength: 4000),
                        is_copied_dak = c.Int(nullable: false),
                        dak_origin = c.String(maxLength: 4000),
                        from_potrojari = c.Int(nullable: false),
                        dak_view_status = c.String(maxLength: 4000),
                        attention_type = c.String(maxLength: 4000),
                        dak_priority = c.String(maxLength: 4000),
                        dak_security = c.String(maxLength: 4000),
                        dak_movement_sequence = c.Int(nullable: false),
                        last_movement_date = c.String(maxLength: 4000),
                        dak_category = c.String(maxLength: 4000),
                        dak_subject = c.String(maxLength: 4000),
                        dak_decision = c.String(maxLength: 4000),
                        drafted_decisions = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovementStatus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        from_id = c.Long(nullable: false),
                        other_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Officer", t => t.from_id, cascadeDelete: true)
                .ForeignKey("dbo.Other", t => t.other_id, cascadeDelete: true)
                .Index(t => t.from_id)
                .Index(t => t.other_id);
            
            CreateTable(
                "dbo.Officer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        office_id = c.Int(nullable: false),
                        office_unit_id = c.Int(nullable: false),
                        designation_id = c.Int(nullable: false),
                        officer_id = c.Int(nullable: false),
                        office = c.String(maxLength: 4000),
                        office_unit = c.String(maxLength: 4000),
                        designation = c.String(maxLength: 4000),
                        officer = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.To",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        attention_type = c.String(maxLength: 4000),
                        to_id = c.Long(nullable: false),
                        movement_status_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovementStatus", t => t.movement_status_id, cascadeDelete: true)
                .ForeignKey("dbo.Officer", t => t.to_id, cascadeDelete: false)
                .Index(t => t.to_id)
                .Index(t => t.movement_status_id);
            
            CreateTable(
                "dbo.Other",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        operation_type = c.String(maxLength: 4000),
                        last_movement_date = c.String(maxLength: 4000),
                        dak_priority = c.Int(nullable: false),
                        dak_security_level = c.String(maxLength: 4000),
                        sequence = c.Int(nullable: false),
                        dak_actions = c.String(maxLength: 4000),
                        docketing_no = c.Int(nullable: false),
                        otherId = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(maxLength: 200),
                        PasswordHash = c.Binary(maxLength: 4000),
                        isRemember = c.Boolean(nullable: false),
                        Role = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OfficeInfos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        employee_record_id = c.Int(nullable: false),
                        office_id = c.Int(nullable: false),
                        office_unit_id = c.Int(nullable: false),
                        office_unit_organogram_id = c.Int(nullable: false),
                        designation = c.String(maxLength: 500),
                        designation_level = c.Int(nullable: false),
                        designation_sequence = c.Int(nullable: false),
                        office_head = c.Int(nullable: false),
                        incharge_label = c.String(maxLength: 500),
                        joining_date = c.DateTime(nullable: false),
                        status = c.Boolean(nullable: false),
                        show_unit = c.Int(nullable: false),
                        designation_en = c.String(maxLength: 500),
                        unit_name_bn = c.String(maxLength: 500),
                        office_name_bn = c.String(maxLength: 500),
                        unit_name_en = c.String(maxLength: 500),
                        office_name_en = c.String(maxLength: 500),
                        protikolpo_status = c.Int(nullable: false),
                        domain = c.String(maxLength: 500),
                        is_admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        username = c.String(maxLength: 500),
                        user_alias = c.String(maxLength: 500),
                        active = c.Boolean(nullable: false),
                        employee_record_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DakList", "movement_status_id", "dbo.MovementStatus");
            DropForeignKey("dbo.MovementStatus", "other_id", "dbo.Other");
            DropForeignKey("dbo.MovementStatus", "from_id", "dbo.Officer");
            DropForeignKey("dbo.To", "to_id", "dbo.Officer");
            DropForeignKey("dbo.To", "movement_status_id", "dbo.MovementStatus");
            DropForeignKey("dbo.DakList", "dak_user_id", "dbo.DakUser");
            DropForeignKey("dbo.DakTag", "dak_list_id", "dbo.DakList");
            DropForeignKey("dbo.DakList", "dak_origin_id", "dbo.DakOrigin");
            DropForeignKey("dbo.DakList", "dak_nothi_id", "dbo.DakNothi");
            DropForeignKey("dbo.DakList", "dak_List_type_Id", "dbo.DakType");
            DropIndex("dbo.To", new[] { "movement_status_id" });
            DropIndex("dbo.To", new[] { "to_id" });
            DropIndex("dbo.MovementStatus", new[] { "other_id" });
            DropIndex("dbo.MovementStatus", new[] { "from_id" });
            DropIndex("dbo.DakTag", new[] { "dak_list_id" });
            DropIndex("dbo.DakList", new[] { "dak_List_type_Id" });
            DropIndex("dbo.DakList", new[] { "dak_nothi_id" });
            DropIndex("dbo.DakList", new[] { "movement_status_id" });
            DropIndex("dbo.DakList", new[] { "dak_origin_id" });
            DropIndex("dbo.DakList", new[] { "dak_user_id" });
            DropTable("dbo.Users");
            DropTable("dbo.OfficeInfos");
            DropTable("dbo.AppUsers");
            DropTable("dbo.Other");
            DropTable("dbo.To");
            DropTable("dbo.Officer");
            DropTable("dbo.MovementStatus");
            DropTable("dbo.DakUser");
            DropTable("dbo.DakTag");
            DropTable("dbo.DakOrigin");
            DropTable("dbo.DakNothi");
            DropTable("dbo.DakType");
            DropTable("dbo.DakList");
            DropTable("dbo.NothiListRecords");
            DropTable("dbo.EmployeeInfos");
            DropTable("dbo.UserToken");
        }
    }
}
