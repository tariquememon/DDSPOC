﻿namespace App.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailModelValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Email", "EmailAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Email", "EmailAddress", c => c.String());
        }
    }
}
