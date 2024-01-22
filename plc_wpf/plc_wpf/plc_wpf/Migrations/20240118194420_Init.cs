using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace plc_wpf.Migrations
{
    public partial class Init : Migration
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
                    PlcType = table.Column<int>(type: "int", nullable: false),
                    Slot = table.Column<int>(type: "int", nullable: false),
                    Rack = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plc_Conections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    VarType = table.Column<int>(type: "int", nullable: false),
                    DB = table.Column<int>(type: "int", nullable: false),
                    StartByteAdr = table.Column<int>(type: "int", nullable: false),
                    BitAdr = table.Column<byte>(type: "tinyint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PLC_ConectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pls_Tags_Plc_Conections_PLC_ConectionId",
                        column: x => x.PLC_ConectionId,
                        principalTable: "Plc_Conections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pls_Tags_PLC_ConectionId",
                table: "Pls_Tags",
                column: "PLC_ConectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pls_Tags");

            migrationBuilder.DropTable(
                name: "Plc_Conections");
        }
    }
}
