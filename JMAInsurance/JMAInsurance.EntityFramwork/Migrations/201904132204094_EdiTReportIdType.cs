namespace JMAInsurance.EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EdiTReportIdType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Insurance.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        IsMailing = c.Boolean(nullable: false),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Insurance.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .Index(t => t.ApplicantId);
            
            CreateTable(
                "Insurance.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicantTracker = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Dob = c.DateTime(),
                        Phone = c.Double(),
                        Email = c.String(nullable: false),
                        MaritalStatus = c.String(),
                        HighestEducation = c.String(),
                        LicenseStatus = c.String(),
                        YearsLicensed = c.String(),
                        WorkFlowStage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Insurance.Employments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmploymentType = c.String(),
                        Employer = c.String(),
                        Position = c.String(),
                        GrossMonthlyIncome = c.Double(nullable: false),
                        StartDate = c.DateTime(),
                        IsPrimary = c.Boolean(nullable: false),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Insurance.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .Index(t => t.ApplicantId);
            
            CreateTable(
                "Insurance.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Liability = c.Double(nullable: false),
                        RoadSideAssistance = c.Boolean(nullable: false),
                        PropertyDamage = c.Double(nullable: false),
                        Collision = c.Double(nullable: false),
                        Comprehensive = c.Double(nullable: false),
                        Rental = c.Boolean(nullable: false),
                        LoanPayoff = c.Boolean(nullable: false),
                        DriverRewards = c.Boolean(nullable: false),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Insurance.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .Index(t => t.ApplicantId);
            
            CreateTable(
                "Insurance.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Double(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        BodyType = c.String(),
                        PrimaryUse = c.String(),
                        OwnLease = c.String(),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Insurance.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .Index(t => t.ApplicantId);
            
            CreateTable(
                "Lookups.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameAr = c.String(),
                        NameEn = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Lookups.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "Lookups.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameAr = c.Int(nullable: false),
                        NameEn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "Lookups.MaritalStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusAr = c.String(),
                        StatusEn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Insurance.EMonthlyReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberRead = c.Double(nullable: false),
                        ClickThruRate = c.Double(nullable: false),
                        NumberSent = c.Double(nullable: false),
                        AverageQuote = c.Double(nullable: false),
                        ProjectedConversationRate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Insurance.WeeklyReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberRead = c.Double(),
                        ClickThruRate = c.Double(),
                        NumberSent = c.Double(),
                        AverageQuote = c.Double(),
                        ProjectedConversationRate = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Lookups.City", "CountryId", "Lookups.Country");
            DropForeignKey("Insurance.Vehicles", "ApplicantId", "Insurance.Applicants");
            DropForeignKey("Insurance.Products", "ApplicantId", "Insurance.Applicants");
            DropForeignKey("Insurance.Employments", "ApplicantId", "Insurance.Applicants");
            DropForeignKey("Insurance.Address", "ApplicantId", "Insurance.Applicants");
            DropIndex("Lookups.City", new[] { "CountryId" });
            DropIndex("Insurance.Vehicles", new[] { "ApplicantId" });
            DropIndex("Insurance.Products", new[] { "ApplicantId" });
            DropIndex("Insurance.Employments", new[] { "ApplicantId" });
            DropIndex("Insurance.Address", new[] { "ApplicantId" });
            DropTable("Insurance.WeeklyReports");
            DropTable("Insurance.EMonthlyReports");
            DropTable("Lookups.MaritalStatus");
            DropTable("common.Errors");
            DropTable("Lookups.Country");
            DropTable("Lookups.City");
            DropTable("Insurance.Vehicles");
            DropTable("Insurance.Products");
            DropTable("Insurance.Employments");
            DropTable("Insurance.Applicants");
            DropTable("Insurance.Address");
        }
    }
}
