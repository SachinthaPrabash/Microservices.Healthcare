using Microsoft.EntityFrameworkCore.Migrations;

namespace SLIIT.MTIT.HospitalService.Doctor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorfirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DoctorLastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    specialization = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    registercode = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.DoctorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctors");
        }
    }
}
