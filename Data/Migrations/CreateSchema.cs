using FluentMigrator;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Notes_Web.Data.Migrations
{
    [Migration(090320251)]
    public class CreateSchema:Migration
    {

        public override void Down()
        {
           
        }

        public override void Up()
        {
            Create.Table("notes")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("Title").AsString().NotNullable()
                 .WithColumn("Content").AsString().NotNullable()
                 .WithColumn("Date_Created").AsDate().NotNullable()
                 .WithColumn("Date_Modified").AsDate()
                 .WithColumn("Color").AsString().NotNullable()
                 .WithColumn("Priority").AsInt32().NotNullable()
                 .WithColumn("Favorite").AsBoolean();



        }








    }
}
