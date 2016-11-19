namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieandGenreproperties1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_GenreId" });
            RenameColumn(table: "dbo.Movies", name: "Genre_GenreId", newName: "GenreId");
            DropPrimaryKey("dbo.Genres");
            AddColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Genres", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "GenreId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte());
            DropColumn("dbo.Genres", "Id");
            AddPrimaryKey("dbo.Genres", "GenreId");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genre_GenreId");
            CreateIndex("dbo.Movies", "Genre_GenreId");
            AddForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres", "GenreId");
        }
    }
}
