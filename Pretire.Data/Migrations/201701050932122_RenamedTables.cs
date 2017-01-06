namespace Pretire.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTables : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TaxCodes", name: "Salary_Id", newName: "SalaryEntity_Id");
            RenameColumn(table: "dbo.TaxBrackets", name: "TaxCode_Id", newName: "TaxCodeEntity_Id");
            RenameIndex(table: "dbo.TaxCodes", name: "IX_Salary_Id", newName: "IX_SalaryEntity_Id");
            RenameIndex(table: "dbo.TaxBrackets", name: "IX_TaxCode_Id", newName: "IX_TaxCodeEntity_Id");
            AddColumn("dbo.TaxCodes", "UsesDeductions", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaxCodes", "UsesDeductions");
            RenameIndex(table: "dbo.TaxBrackets", name: "IX_TaxCodeEntity_Id", newName: "IX_TaxCode_Id");
            RenameIndex(table: "dbo.TaxCodes", name: "IX_SalaryEntity_Id", newName: "IX_Salary_Id");
            RenameColumn(table: "dbo.TaxBrackets", name: "TaxCodeEntity_Id", newName: "TaxCode_Id");
            RenameColumn(table: "dbo.TaxCodes", name: "SalaryEntity_Id", newName: "Salary_Id");
        }
    }
}
