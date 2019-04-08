namespace JMAInsurance.EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedScemaLookup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Insurance.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        State = c.String(),
                        Zip = c.String(),
                        IsMailing = c.Boolean(nullable: false),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Insurance.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("Lookups.City", t => t.CityId, cascadeDelete: true)
                .ForeignKey("Lookups.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
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
                        MaritalStatusId = c.Int(nullable: false),
                        HighestEducation = c.String(),
                        LicenseStatus = c.String(),
                        YearsLicensed = c.String(),
                        WorkFlowStage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Lookups.MaritalStatus", t => t.MaritalStatusId, cascadeDelete: true)
                .Index(t => t.MaritalStatusId);
            
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
                "Lookups.MaritalStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusAr = c.String(),
                        StatusEn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        YearId = c.Int(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        BodyType = c.String(),
                        PrimaryUse = c.String(),
                        OwnLease = c.String(),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Insurance.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("Lookups.Years", t => t.YearId, cascadeDelete: true)
                .Index(t => t.YearId)
                .Index(t => t.ApplicantId);
            
            CreateTable(
                "Lookups.Years",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        year = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("Lookups.Country", t => t.CountryId, cascadeDelete: false)
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("Insurance.Address", "CountryId", "Lookups.Country");
            DropForeignKey("Insurance.Address", "CityId", "Lookups.City");
            DropForeignKey("Lookups.City", "CountryId", "Lookups.Country");
            DropForeignKey("Insurance.Vehicles", "YearId", "Lookups.Years");
            DropForeignKey("Insurance.Vehicles", "ApplicantId", "Insurance.Applicants");
            DropForeignKey("Insurance.Products", "ApplicantId", "Insurance.Applicants");
            DropForeignKey("Insurance.Applicants", "MaritalStatusId", "Lookups.MaritalStatus");
            DropForeignKey("Insurance.Employments", "ApplicantId", "Insurance.Applicants");
            DropForeignKey("Insurance.Address", "ApplicantId", "Insurance.Applicants");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("Lookups.City", new[] { "CountryId" });
            DropIndex("Insurance.Vehicles", new[] { "ApplicantId" });
            DropIndex("Insurance.Vehicles", new[] { "YearId" });
            DropIndex("Insurance.Products", new[] { "ApplicantId" });
            DropIndex("Insurance.Employments", new[] { "ApplicantId" });
            DropIndex("Insurance.Applicants", new[] { "MaritalStatusId" });
            DropIndex("Insurance.Address", new[] { "ApplicantId" });
            DropIndex("Insurance.Address", new[] { "CityId" });
            DropIndex("Insurance.Address", new[] { "CountryId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("Lookups.Country");
            DropTable("Lookups.City");
            DropTable("Lookups.Years");
            DropTable("Insurance.Vehicles");
            DropTable("Insurance.Products");
            DropTable("Lookups.MaritalStatus");
            DropTable("Insurance.Employments");
            DropTable("Insurance.Applicants");
            DropTable("Insurance.Address");
        }
    }
}
