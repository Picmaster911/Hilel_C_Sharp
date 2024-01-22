using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace plc_wpf.Migrations
{
    public partial class AddCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pls_Tags_Plc_Conections_PLC_ConectionId",
                table: "Pls_Tags");

            migrationBuilder.AlterColumn<int>(
                name: "PLC_ConectionId",
                table: "Pls_Tags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pls_Tags_Plc_Conections_PLC_ConectionId",
                table: "Pls_Tags",
                column: "PLC_ConectionId",
                principalTable: "Plc_Conections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pls_Tags_Plc_Conections_PLC_ConectionId",
                table: "Pls_Tags");

            migrationBuilder.AlterColumn<int>(
                name: "PLC_ConectionId",
                table: "Pls_Tags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pls_Tags_Plc_Conections_PLC_ConectionId",
                table: "Pls_Tags",
                column: "PLC_ConectionId",
                principalTable: "Plc_Conections",
                principalColumn: "Id");
        }
    }
}
