namespace Pretire.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultDatabaseWithSalaries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartingValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartingYear = c.Int(nullable: false),
                        EndingYear = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        GrowthRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrowthType_Id = c.Int(nullable: false),
                        Simulation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrowthTypes", t => t.GrowthType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Simulations", t => t.Simulation_Id)
                .Index(t => t.GrowthType_Id)
                .Index(t => t.Simulation_Id);
            
            CreateTable(
                "dbo.GrowthTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Simulations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaxCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Salary_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salaries", t => t.Salary_Id)
                .Index(t => t.Salary_Id);
            
            CreateTable(
                "dbo.TaxBrackets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LowerBound = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UpperBound = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxCode_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaxCodes", t => t.TaxCode_Id)
                .Index(t => t.TaxCode_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaxCodes", "Salary_Id", "dbo.Salaries");
            DropForeignKey("dbo.TaxBrackets", "TaxCode_Id", "dbo.TaxCodes");
            DropForeignKey("dbo.Salaries", "Simulation_Id", "dbo.Simulations");
            DropForeignKey("dbo.Simulations", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Salaries", "GrowthType_Id", "dbo.GrowthTypes");
            DropIndex("dbo.TaxBrackets", new[] { "TaxCode_Id" });
            DropIndex("dbo.TaxCodes", new[] { "Salary_Id" });
            DropIndex("dbo.Simulations", new[] { "Owner_Id" });
            DropIndex("dbo.Salaries", new[] { "Simulation_Id" });
            DropIndex("dbo.Salaries", new[] { "GrowthType_Id" });
            DropTable("dbo.TaxBrackets");
            DropTable("dbo.TaxCodes");
            DropTable("dbo.Users");
            DropTable("dbo.Simulations");
            DropTable("dbo.GrowthTypes");
            DropTable("dbo.Salaries");
        }
    }
}
