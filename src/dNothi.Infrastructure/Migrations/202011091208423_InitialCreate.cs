namespace Nothi.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeInfos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
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
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(maxLength: 200),
                        PasswordHash = c.Binary(),
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
            DropTable("dbo.Users");
            DropTable("dbo.OfficeInfos");
            DropTable("dbo.AppUsers");
            DropTable("dbo.EmployeeInfos");
        }
    }
}
