namespace SuperHeroProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SuperHeros", newName: "SuperHeroes");
            AlterColumn("dbo.SuperHeroes", "Name", c => c.String());
            AlterColumn("dbo.SuperHeroes", "AlterEgo", c => c.String());
            AlterColumn("dbo.SuperHeroes", "PrimaryPower", c => c.String());
            AlterColumn("dbo.SuperHeroes", "SecondaryPower", c => c.String());
            AlterColumn("dbo.SuperHeroes", "Catchphrase", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SuperHeroes", "Catchphrase", c => c.Int(nullable: false));
            AlterColumn("dbo.SuperHeroes", "SecondaryPower", c => c.Int(nullable: false));
            AlterColumn("dbo.SuperHeroes", "PrimaryPower", c => c.Int(nullable: false));
            AlterColumn("dbo.SuperHeroes", "AlterEgo", c => c.Int(nullable: false));
            AlterColumn("dbo.SuperHeroes", "Name", c => c.Int(nullable: false));
            RenameTable(name: "dbo.SuperHeroes", newName: "SuperHeros");
        }
    }
}
