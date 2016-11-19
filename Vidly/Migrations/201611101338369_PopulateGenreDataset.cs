namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreDataset : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(Id,GenreName) Values('1','Comedy')");
            Sql("Insert into Genres(Id,GenreName) Values('2','Horror')");
            Sql("Insert into Genres(Id,GenreName) Values('3','Romance')");
            Sql("Insert into Genres(Id,GenreName) Values('4','Action')");
            Sql("Insert into Genres(Id,GenreName) Values('5','Crime')");
            Sql("Insert into Genres(Id,GenreName) Values('6','Thriller')");
            Sql("Insert into Genres(Id,GenreName) Values('7','Biography')");
        }

        public override void Down()
        {
        }
    }
}
