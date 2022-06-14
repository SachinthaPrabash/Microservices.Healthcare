using Microsoft.EntityFrameworkCore.Migrations;

namespace SLIIT.MTIT.HospitalService.HospitalAdmin.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckupName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CheckupPrice = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");
        }
    }
}
