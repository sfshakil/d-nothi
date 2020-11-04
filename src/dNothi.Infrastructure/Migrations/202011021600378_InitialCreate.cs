namespace dNothi.Infrastructure.Migrations
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
                        name_eng = c.String(),
                        name_bng = c.String(),
                        father_name_eng = c.String(),
                        father_name_bng = c.String(),
                        mother_name_eng = c.String(),
                        mother_name_bng = c.String(),
                        date_of_birth = c.DateTime(nullable: false),
                        nid = c.String(),
                        bcn = c.String(),
                        ppn = c.String(),
                        personal_email = c.String(),
                        personal_mobile = c.String(),
                        is_cadre = c.Int(nullable: false),
                        default_sign = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Role = c.String(),
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
                        designation = c.String(),
                        designation_level = c.Int(nullable: false),
                        designation_sequence = c.Int(nullable: false),
                        office_head = c.Int(nullable: false),
                        incharge_label = c.String(),
                        joining_date = c.DateTime(nullable: false),
                        status = c.Boolean(nullable: false),
                        show_unit = c.Int(nullable: false),
                        designation_en = c.String(),
                        unit_name_bn = c.String(),
                        office_name_bn = c.String(),
                        unit_name_en = c.String(),
                        office_name_en = c.String(),
                        protikolpo_status = c.Int(nullable: false),
                        domain = c.String(),
                        is_admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        username = c.String(),
                        user_alias = c.String(),
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
