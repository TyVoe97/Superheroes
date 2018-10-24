namespace SuperHeroProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuperHeros",
                c => new
                    {
                        SuperHeroID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        AlterEgo = c.Int(nullable: false),
                        PrimaryPower = c.Int(nullable: false),
                        SecondaryPower = c.Int(nullable: false),
                        Catchphrase = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SuperHeroID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SuperHeros");
        }
    }
}
