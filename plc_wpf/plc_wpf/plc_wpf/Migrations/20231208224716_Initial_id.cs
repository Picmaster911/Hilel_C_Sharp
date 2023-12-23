using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace plc_wpf.Migrations
{
    public partial class Initial_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plc_Conections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlcName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlcType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slot = table.Column<int>(type: "int", nullable: false),
                    Rack = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plc_Conections", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plc_Conections");
        }
    }
}
