using FluentMigrator;
using Notes_Web;



namespace Notes_Web.Data.Migrations
{
    [Migration(090320252)]
    public class TestMigrate:Migration
    {
        public override void Down()
        {

        }
        public override void Up()
        {

            Execute.Script(@"Data/scripts/data.sql");

        }








    }
}
