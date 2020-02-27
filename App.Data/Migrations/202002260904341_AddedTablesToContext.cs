namespace App.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTablesToContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "Address_Id", "dbo.Address");
            DropForeignKey("dbo.Email", "Person_Id", "dbo.Person");
            DropIndex("dbo.Person", new[] { "Address_Id" });
            DropIndex("dbo.Email", new[] { "Person_Id" });
            RenameColumn(table: "dbo.Person", name: "Address_Id", newName: "AddressId");
            RenameColumn(table: "dbo.Email", name: "Person_Id", newName: "PersonId");
            AlterColumn("dbo.Person", "AddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.Email", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Person", "AddressId");
            CreateIndex("dbo.Email", "PersonId");
            AddForeignKey("dbo.Person", "AddressId", "dbo.Address", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Email", "PersonId", "dbo.Person", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Email", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Person", "AddressId", "dbo.Address");
            DropIndex("dbo.Email", new[] { "PersonId" });
            DropIndex("dbo.Person", new[] { "AddressId" });
            AlterColumn("dbo.Email", "PersonId", c => c.Int());
            AlterColumn("dbo.Person", "AddressId", c => c.Int());
            RenameColumn(table: "dbo.Email", name: "PersonId", newName: "Person_Id");
            RenameColumn(table: "dbo.Person", name: "AddressId", newName: "Address_Id");
            CreateIndex("dbo.Email", "Person_Id");
            CreateIndex("dbo.Person", "Address_Id");
            AddForeignKey("dbo.Email", "Person_Id", "dbo.Person", "Id");
            AddForeignKey("dbo.Person", "Address_Id", "dbo.Address", "Id");
        }
    }
}
