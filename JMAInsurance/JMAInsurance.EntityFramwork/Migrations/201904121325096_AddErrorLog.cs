namespace JMAInsurance.EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "common.Errors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ControllerName = c.String(),
                        UserAgent = c.String(),
                        StackTrace = c.String(),
                        SessionId = c.String(),
                        TargetedResult = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("common.Errors");
        }
    }
}
