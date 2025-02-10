using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservice.Appointments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cambiodemodelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Appointment",
                newName: "PatientDni");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Appointment",
                newName: "DoctorCredential");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientDni",
                table: "Appointment",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "DoctorCredential",
                table: "Appointment",
                newName: "DoctorId");
        }
    }
}
