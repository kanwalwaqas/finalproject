namespace OLIWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class project : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.String(nullable: false, maxLength: 128),
                        DonorID = c.String(maxLength: 128),
                        ReceiverID = c.String(maxLength: 128),
                        AccountName = c.String(),
                        duration = c.String(),
                        AccountNumber = c.String(),
                        status = c.String(),
                        SortCode = c.String(),
                        Remaning_Amount = c.String(),
                        LoanID = c.String(maxLength: 128),
                        TeamID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Donors", t => t.DonorID)
                .ForeignKey("dbo.Loans", t => t.LoanID)
                .ForeignKey("dbo.Receivers", t => t.ReceiverID)
                .ForeignKey("dbo.Teams", t => t.TeamID)
                .Index(t => t.DonorID)
                .Index(t => t.ReceiverID)
                .Index(t => t.LoanID)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        DonorID = c.String(nullable: false, maxLength: 128),
                        frequency = c.String(),
                        Amount = c.String(),
                        status = c.String(),
                        Id = c.String(maxLength: 128),
                        Fund_TypeID = c.String(maxLength: 128),
                        fund_descriptionID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DonorID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.fund_description", t => t.fund_descriptionID)
                .ForeignKey("dbo.Fund_Type", t => t.Fund_TypeID)
                .Index(t => t.Id)
                .Index(t => t.Fund_TypeID)
                .Index(t => t.fund_descriptionID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Gender = c.String(),
                        Date_of_birth = c.String(),
                        CNIC = c.String(),
                        Selected_city = c.String(),
                        Selected_Area = c.String(),
                        Address = c.String(),
                        Muslim = c.String(),
                        in_org = c.String(),
                        Category = c.String(),
                        userStatus = c.Boolean(nullable: false),
                        currentDate = c.DateTime(nullable: false),
                        image = c.String(),
                        fund_type = c.String(),
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.fund_description",
                c => new
                    {
                        fund_descriptionID = c.String(nullable: false, maxLength: 128),
                        Fund_sub_catID = c.String(maxLength: 128),
                        Fund_CategoriesID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.fund_descriptionID)
                .ForeignKey("dbo.Fund_Categories", t => t.Fund_CategoriesID)
                .ForeignKey("dbo.Fund_sub_cat", t => t.Fund_sub_catID)
                .Index(t => t.Fund_sub_catID)
                .Index(t => t.Fund_CategoriesID);
            
            CreateTable(
                "dbo.Fund_Categories",
                c => new
                    {
                        Fund_CategoriesID = c.String(nullable: false, maxLength: 128),
                        fund_cat = c.String(),
                        Education = c.String(),
                        Health = c.String(),
                        Loan = c.String(),
                        status = c.String(),
                        frequency = c.String(),
                        cat_img = c.String(),
                        cat_title = c.String(),
                        cat_decsription = c.String(),
                    })
                .PrimaryKey(t => t.Fund_CategoriesID);
            
            CreateTable(
                "dbo.Fund_sub_cat",
                c => new
                    {
                        Fund_sub_catID = c.String(nullable: false, maxLength: 128),
                        AdmissionFee = c.String(),
                        Accessories = c.String(),
                        Uniform = c.String(),
                        fee_cat = c.String(),
                        semesterFee = c.String(),
                        Annual = c.String(),
                        stationary_cat = c.String(),
                        bags = c.String(),
                        books_notes = c.String(),
                        uniform_cat = c.String(),
                        Dress = c.String(),
                        shoes = c.String(),
                        Medicine = c.String(),
                        Minor_Surgury = c.String(),
                        Test_Reports = c.String(),
                        medi_cat = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.Fund_sub_catID);
            
            CreateTable(
                "dbo.Fund_Type",
                c => new
                    {
                        Fund_TypeID = c.String(nullable: false, maxLength: 128),
                        Registration_typeID = c.String(maxLength: 128),
                        Zakat = c.String(),
                        Sadaqah = c.String(),
                        Usher = c.String(),
                        zakat_ul_fitr = c.String(),
                        khums = c.String(),
                        Atia_o_Khairat = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.Fund_TypeID)
                .ForeignKey("dbo.Registration_type", t => t.Registration_typeID)
                .Index(t => t.Registration_typeID);
            
            CreateTable(
                "dbo.Registration_type",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Registration_typeID = c.String(),
                        RoleID = c.String(maxLength: 128),
                        status = c.String(),
                        applicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.applicationUser_Id)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID)
                .Index(t => t.applicationUser_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 128),
                        Id = c.String(maxLength: 128),
                        Role_Name = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.RoleID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanID = c.String(nullable: false, maxLength: 128),
                        Loan_Type = c.String(),
                        loan_amount = c.String(),
                        source_finance = c.String(),
                        loan_Limit = c.String(),
                        return_amount = c.String(),
                        remaining_balance = c.String(),
                        return_date = c.String(),
                    })
                .PrimaryKey(t => t.LoanID);
            
            CreateTable(
                "dbo.Receivers",
                c => new
                    {
                        ReceiverID = c.String(nullable: false, maxLength: 128),
                        amount = c.String(),
                        status = c.String(),
                        fund_limit = c.String(),
                        Id = c.String(maxLength: 128),
                        fund_descriptionID = c.String(maxLength: 128),
                        LoanID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReceiverID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.fund_description", t => t.fund_descriptionID)
                .ForeignKey("dbo.Loans", t => t.LoanID)
                .Index(t => t.Id)
                .Index(t => t.fund_descriptionID)
                .Index(t => t.LoanID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.String(nullable: false, maxLength: 128),
                        verify = c.String(),
                        Duration = c.String(),
                        Timing = c.String(),
                        experience = c.String(),
                        Id = c.String(maxLength: 128),
                        team_img = c.String(),
                        team_title = c.String(),
                        team_description = c.String(),
                    })
                .PrimaryKey(t => t.TeamID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.BalanceDetails",
                c => new
                    {
                        BalanceID = c.String(nullable: false, maxLength: 128),
                        TotalAmount = c.Single(nullable: false),
                        Education = c.Single(nullable: false),
                        Health = c.Single(nullable: false),
                        Others = c.Single(nullable: false),
                        Team = c.Single(nullable: false),
                        Admin = c.Single(nullable: false),
                        dateInformation = c.String(),
                        UserID = c.String(),
                        DonorID = c.String(),
                    })
                .PrimaryKey(t => t.BalanceID);
            
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        CampaignsID = c.String(nullable: false, maxLength: 128),
                        volunteer1 = c.String(),
                        volunteer2 = c.String(),
                        volunteer3 = c.String(),
                        volunteer4 = c.String(),
                        volunteer5 = c.String(),
                        volunteer6 = c.String(),
                        volunteer7 = c.String(),
                        volunteer8 = c.String(),
                        volunteer9 = c.String(),
                        volunteer10 = c.String(),
                        task = c.String(),
                        compaign_area = c.String(),
                        Purpose = c.String(),
                        date_time = c.DateTime(nullable: false),
                        timelimit = c.String(),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CampaignsID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.String(nullable: false, maxLength: 128),
                        city_name = c.String(),
                        status = c.Boolean(nullable: false),
                        StateID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.States", t => t.StateID)
                .Index(t => t.StateID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.String(nullable: false, maxLength: 128),
                        state_name = c.String(),
                        status = c.Boolean(nullable: false),
                        CountryID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StateID)
                .ForeignKey("dbo.Countries", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.String(nullable: false, maxLength: 128),
                        country_name = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Contact_us",
                c => new
                    {
                        Contact_usID = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        lastname = c.String(),
                        con_Email = c.String(),
                        subject = c.String(),
                        Message = c.String(),
                        status = c.String(),
                        cont_img = c.String(),
                        delete = c.Boolean(nullable: false),
                        currentDate = c.DateTime(nullable: false),
                        Seen = c.Boolean(nullable: false),
                        reply = c.Boolean(nullable: false),
                        Replied_By = c.String(),
                        Seen_By = c.String(),
                    })
                .PrimaryKey(t => t.Contact_usID);
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        Banner_Id = c.String(nullable: false, maxLength: 128),
                        Image = c.String(),
                        Name = c.String(),
                        De_Activate = c.Boolean(nullable: false),
                        Id = c.String(maxLength: 128),
                        CurrentDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Banner_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.GaudianInformations",
                c => new
                    {
                        GaudianKey = c.String(nullable: false, maxLength: 128),
                        Gardian_Name = c.String(),
                        Gardian_Members = c.String(),
                        Gardian_Income = c.String(),
                        Gardian_Occupation = c.String(),
                        Gardian_Oranization = c.String(),
                        Loan_Amount = c.String(),
                        UserID = c.String(),
                        RecieverID = c.String(),
                    })
                .PrimaryKey(t => t.GaudianKey);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationID = c.String(nullable: false, maxLength: 128),
                        owner_Name = c.String(),
                        owner_LastName = c.String(),
                        owner_CNIC = c.String(),
                        owner_Address = c.String(),
                        owner_PhoneNum = c.String(),
                        owner_Email = c.String(),
                        focalPerson_Name = c.String(),
                        focalPerson_Num = c.String(),
                        focalPerson_Address = c.String(),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrganizationID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Profile_biulding",
                c => new
                    {
                        Profile_biuldingID = c.String(nullable: false, maxLength: 128),
                        picture = c.String(),
                        personal_info = c.String(),
                        Qualification = c.String(),
                        Shift_Of_Working = c.String(),
                        Area_of_Work = c.String(),
                        Discription = c.String(),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Profile_biuldingID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportID = c.String(nullable: false, maxLength: 128),
                        Registration_typeID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.Registration_type", t => t.Registration_typeID)
                .Index(t => t.Registration_typeID);
            
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
                "dbo.team_asigned_jobs",
                c => new
                    {
                        tm_job_Id = c.String(nullable: false, maxLength: 128),
                        Job_status = c.Int(nullable: false),
                        Id = c.String(maxLength: 128),
                        TeamID = c.String(maxLength: 128),
                        currentdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.tm_job_Id)
                .ForeignKey("dbo.Teams", t => t.TeamID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.work_events",
                c => new
                    {
                        work_eventsID = c.String(nullable: false, maxLength: 128),
                        events = c.String(),
                        campigns = c.String(),
                        news = c.String(),
                        notification = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.work_eventsID);
            
            CreateTable(
                "dbo.work_sub_cat",
                c => new
                    {
                        work_sub_catID = c.String(nullable: false, maxLength: 128),
                        work_eventsID = c.String(maxLength: 128),
                        Title = c.String(),
                        Description = c.String(),
                        Number = c.String(),
                        Date = c.String(),
                        Name = c.String(),
                        detail = c.String(),
                        Venue = c.String(),
                        event_image = c.String(),
                    })
                .PrimaryKey(t => t.work_sub_catID)
                .ForeignKey("dbo.work_events", t => t.work_eventsID)
                .Index(t => t.work_eventsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.work_sub_cat", "work_eventsID", "dbo.work_events");
            DropForeignKey("dbo.team_asigned_jobs", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.team_asigned_jobs", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reports", "Registration_typeID", "dbo.Registration_type");
            DropForeignKey("dbo.Profile_biulding", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Organizations", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Banners", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "StateID", "dbo.States");
            DropForeignKey("dbo.States", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Accounts", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accounts", "ReceiverID", "dbo.Receivers");
            DropForeignKey("dbo.Receivers", "LoanID", "dbo.Loans");
            DropForeignKey("dbo.Receivers", "fund_descriptionID", "dbo.fund_description");
            DropForeignKey("dbo.Receivers", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accounts", "LoanID", "dbo.Loans");
            DropForeignKey("dbo.Accounts", "DonorID", "dbo.Donors");
            DropForeignKey("dbo.Donors", "Fund_TypeID", "dbo.Fund_Type");
            DropForeignKey("dbo.Fund_Type", "Registration_typeID", "dbo.Registration_type");
            DropForeignKey("dbo.Registration_type", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Roles", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Registration_type", "applicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Donors", "fund_descriptionID", "dbo.fund_description");
            DropForeignKey("dbo.fund_description", "Fund_sub_catID", "dbo.Fund_sub_cat");
            DropForeignKey("dbo.fund_description", "Fund_CategoriesID", "dbo.Fund_Categories");
            DropForeignKey("dbo.Donors", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.work_sub_cat", new[] { "work_eventsID" });
            DropIndex("dbo.team_asigned_jobs", new[] { "TeamID" });
            DropIndex("dbo.team_asigned_jobs", new[] { "Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Reports", new[] { "Registration_typeID" });
            DropIndex("dbo.Profile_biulding", new[] { "Id" });
            DropIndex("dbo.Organizations", new[] { "Id" });
            DropIndex("dbo.Banners", new[] { "Id" });
            DropIndex("dbo.States", new[] { "CountryID" });
            DropIndex("dbo.Cities", new[] { "StateID" });
            DropIndex("dbo.Teams", new[] { "Id" });
            DropIndex("dbo.Receivers", new[] { "LoanID" });
            DropIndex("dbo.Receivers", new[] { "fund_descriptionID" });
            DropIndex("dbo.Receivers", new[] { "Id" });
            DropIndex("dbo.Roles", new[] { "Id" });
            DropIndex("dbo.Registration_type", new[] { "applicationUser_Id" });
            DropIndex("dbo.Registration_type", new[] { "RoleID" });
            DropIndex("dbo.Fund_Type", new[] { "Registration_typeID" });
            DropIndex("dbo.fund_description", new[] { "Fund_CategoriesID" });
            DropIndex("dbo.fund_description", new[] { "Fund_sub_catID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Donors", new[] { "fund_descriptionID" });
            DropIndex("dbo.Donors", new[] { "Fund_TypeID" });
            DropIndex("dbo.Donors", new[] { "Id" });
            DropIndex("dbo.Accounts", new[] { "TeamID" });
            DropIndex("dbo.Accounts", new[] { "LoanID" });
            DropIndex("dbo.Accounts", new[] { "ReceiverID" });
            DropIndex("dbo.Accounts", new[] { "DonorID" });
            DropTable("dbo.work_sub_cat");
            DropTable("dbo.work_events");
            DropTable("dbo.team_asigned_jobs");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reports");
            DropTable("dbo.Profile_biulding");
            DropTable("dbo.Organizations");
            DropTable("dbo.GaudianInformations");
            DropTable("dbo.Banners");
            DropTable("dbo.Contact_us");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            DropTable("dbo.Campaigns");
            DropTable("dbo.BalanceDetails");
            DropTable("dbo.Teams");
            DropTable("dbo.Receivers");
            DropTable("dbo.Loans");
            DropTable("dbo.Roles");
            DropTable("dbo.Registration_type");
            DropTable("dbo.Fund_Type");
            DropTable("dbo.Fund_sub_cat");
            DropTable("dbo.Fund_Categories");
            DropTable("dbo.fund_description");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Donors");
            DropTable("dbo.Accounts");
        }
    }
}
