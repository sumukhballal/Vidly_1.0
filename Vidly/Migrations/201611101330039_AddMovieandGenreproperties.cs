namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieandGenreproperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Byte(nullable: false),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Genre_GenreId", c => c.Byte());
            AlterColumn("dbo.Movies", "MovieName", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Movies", "Genre_GenreId");
            AddForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres", "GenreId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_GenreId" });
            AlterColumn("dbo.Movies", "MovieName", c => c.String());
            DropColumn("dbo.Movies", "Genre_GenreId");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "NumberInStock");
            DropTable("dbo.Genres");
        }
    }
}
