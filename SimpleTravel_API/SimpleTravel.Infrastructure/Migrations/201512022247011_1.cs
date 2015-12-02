namespace SimpleTravel.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotesInObjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ApartmentId_Id = c.Guid(),
                        NoteId_Id = c.Guid(),
                        PlaceId_Id = c.Guid(),
                        TransportId_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartments", t => t.ApartmentId_Id)
                .ForeignKey("dbo.Notes", t => t.NoteId_Id)
                .ForeignKey("dbo.Places", t => t.PlaceId_Id)
                .ForeignKey("dbo.Transports", t => t.TransportId_Id)
                .Index(t => t.ApartmentId_Id)
                .Index(t => t.NoteId_Id)
                .Index(t => t.PlaceId_Id)
                .Index(t => t.TransportId_Id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        From = c.String(),
                        To = c.String(),
                        TypeId = c.Int(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotesInObjects", "TransportId_Id", "dbo.Transports");
            DropForeignKey("dbo.NotesInObjects", "PlaceId_Id", "dbo.Places");
            DropForeignKey("dbo.NotesInObjects", "NoteId_Id", "dbo.Notes");
            DropForeignKey("dbo.NotesInObjects", "ApartmentId_Id", "dbo.Apartments");
            DropIndex("dbo.NotesInObjects", new[] { "TransportId_Id" });
            DropIndex("dbo.NotesInObjects", new[] { "PlaceId_Id" });
            DropIndex("dbo.NotesInObjects", new[] { "NoteId_Id" });
            DropIndex("dbo.NotesInObjects", new[] { "ApartmentId_Id" });
            DropTable("dbo.Transports");
            DropTable("dbo.Places");
            DropTable("dbo.NotesInObjects");
            DropTable("dbo.Notes");
        }
    }
}
