using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "customerProfiles",
                columns: table => new
                {
                    CustomerProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerProfiles", x => x.CustomerProfileId);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CustomerProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_customers_customerProfiles_CustomerProfileId",
                        column: x => x.CustomerProfileId,
                        principalTable: "customerProfiles",
                        principalColumn: "CustomerProfileId");
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalePrice = table.Column<int>(type: "int", precision: 12, scale: 2, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_sales_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_sales_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Transmission = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Available"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_vehicles_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_vehicles_sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "sales",
                        principalColumn: "SaleId");
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Comfortable passenger cars", "Sedan" },
                    { 2, "Sport utility vehicles", "SUV" },
                    { 3, "Compact practical cars", "Hatchback" }
                });

            migrationBuilder.InsertData(
                table: "customerProfiles",
                columns: new[] { "CustomerProfileId", "Address", "City", "DateOfBirth", "Nationality" },
                values: new object[,]
                {
                    { 1, "12 Nile St.", "Cairo", new DateTime(1992, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egypt" },
                    { 2, "25 Tahrir St.", "Giza", new DateTime(1995, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egypt" },
                    { 3, "18 El Nasr St.", "Cairo", new DateTime(1988, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egypt" }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmployeeId", "Email", "FullName", "HireDate", "Phone", "Position" },
                values: new object[,]
                {
                    { 1, "mostafa.nabil@autodrive.com", "Mostafa Nabil", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01020000001", "Sales Manager" },
                    { 2, "aya.emad@autodrive.com", "Aya Emad", new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01020000002", "Sales Consultant" },
                    { 3, "hassan.ali@autodrive.com", "Hassan Ali", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01020000003", "Sales Consultant" }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "CustomerId", "CustomerProfileId", "DriverLicenseNumber", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "DL100001", "ahmed.hassan@example.com", "Ahmed Hassan", "01010000001" },
                    { 2, 2, "DL100002", "mona.adel@example.com", "Mona Adel", "01010000002" },
                    { 3, 3, "DL100003", "omar.khaled@example.com", "Omar Khaled", "01010000003" }
                });

            migrationBuilder.InsertData(
                table: "sales",
                columns: new[] { "SaleId", "CustomerId", "EmployeeId", "Notes", "PaymentMethod", "SaleDate", "SalePrice" },
                values: new object[,]
                {
                    { 1, 1, 1, "Completed sale.", "Bank Transfer", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1750000 },
                    { 2, 2, 2, "Completed sale.", "Bank Transfer", new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1850000 },
                    { 3, 3, 3, "Completed sale.", "Cash", new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 510000 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "VehicleId", "CategoryId", "Color", "FuelType", "Make", "Mileage", "Model", "Price", "SalesId", "Status", "Transmission", "VIN", "Year" },
                values: new object[,]
                {
                    { 1, 1, "White", "Petrol", "Toyota", 12000, "Corolla", 650000m, 1, "Available", "Automatic", "VIN00000000000001", 2024 },
                    { 2, 2, "Black", "Petrol", "Hyundai", 18000, "Elantra", 590000m, 2, "Available", "Automatic", "VIN00000000000002", 2023 },
                    { 3, 3, "Grey", "Petrol", "KIA", 9000, "Sportage", 980000m, 3, "Available", "Automatic", "VIN00000000000003", 2024 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_Name",
                table: "categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_CustomerProfileId",
                table: "customers",
                column: "CustomerProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_DriverLicenseNumber",
                table: "customers",
                column: "DriverLicenseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_Email",
                table: "customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_Email",
                table: "employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sales_CustomerId",
                table: "sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_EmployeeId",
                table: "sales",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_CategoryId",
                table: "vehicles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_SalesId",
                table: "vehicles",
                column: "SalesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_VIN",
                table: "vehicles",
                column: "VIN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "customerProfiles");
        }
    }
}
