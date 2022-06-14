using Microsoft.EntityFrameworkCore.Migrations;

namespace SLIIT.MTIT.HospitalService.Billing.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "billings",
                columns: table => new
                {
                    BillingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Discount = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billings", x => x.BillingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "billings");
        }
    }
}
