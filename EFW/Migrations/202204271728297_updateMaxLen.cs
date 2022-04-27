namespace EFW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMaxLen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 250));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
