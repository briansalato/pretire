namespace Pretire.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaxCodesAndGrowthTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaxBrackets", "UpperBound", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaxBrackets", "UpperBound", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
