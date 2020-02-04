namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MonthlyCharge", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MonthlyCharge");
        }
    }
}
