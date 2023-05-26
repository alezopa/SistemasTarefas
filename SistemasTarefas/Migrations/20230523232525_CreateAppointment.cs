using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemasTarefas.Migrations
{
    public partial class CreateAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var sp = @"CREATE PROCEDURE [dbo].[CreateAppointment]
                    @Id int 
                AS
                BEGIN
                    SET NOCOUNT ON;
                    (select  count(*) as 'Quantidade' from Projects )  
                END";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
