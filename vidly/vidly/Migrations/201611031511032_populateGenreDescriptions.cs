namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenreDescriptions : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (name) VALUES ('Terror')");
            Sql("INSERT INTO Genres (name) VALUES ('Drama')");
            Sql("INSERT INTO Genres (name) VALUES ('Suspense')");
            Sql("INSERT INTO Genres (name) VALUES ('Action')");

        }
        
        public override void Down()
        {
        }
    }
}
