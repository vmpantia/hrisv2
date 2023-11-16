using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHRISTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressVersions",
                columns: table => new
                {
                    Version = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barangay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressVersions", x => x.Version);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    Section = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => new { x.Section, x.Key });
                });

            migrationBuilder.CreateTable(
                name: "ContactVersions",
                columns: table => new
                {
                    Version = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsPersonal = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactVersions", x => x.Version);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeVersions",
                columns: table => new
                {
                    Version = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVersions", x => x.Version);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barangay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsPersonal = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Configs",
                columns: new[] { "Key", "Section", "Value" },
                values: new object[,]
                {
                    { "COMPANY_DOMAIN", "SYSTEM", "companydomain.com.ph" },
                    { "ID_NUMBER_DIGIT", "SYSTEM", "7" },
                    { "ID_NUMBER_EMPLOYEE_PREFIX", "SYSTEM", "EMP" },
                    { "ID_NUMBER_FORMAT", "SYSTEM", "{0}-{1}-{2}" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "FirstName", "Gender", "LastName", "MiddleName", "Number", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0b21bd10-688f-4ec0-e638-1979292a7add"), new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 6, 3, 19, 38, 197, DateTimeKind.Local).AddTicks(1973), "Scot.Keeling47@hotmail.com", null, null, "Jayce", "Male", "Abernathy", "雾㡹⩝鳊훫ꀋ㒫⬶ݜ᥸", "䒵鲂薊㖙볬﫸臗៩", 2, null, null },
                    { new Guid("0d17e661-d836-c25c-2456-f17b862a3d01"), new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 23, 3, 45, 19, 39, DateTimeKind.Local).AddTicks(5491), "Amelie_Bernier@hotmail.com", null, null, "Jaden", "Female", "Champlin", "䘞琣욕뚏ꑵ輺ԯ쳵埃옔", "즕ꏧ䚯쐗糁☼៓�吋ྲ", 2, null, null },
                    { new Guid("134c9a71-0a39-1470-9ae5-a533b6e5338e"), new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 18, 6, 44, 54, 640, DateTimeKind.Local).AddTicks(6100), "Stanton51@gmail.com", null, null, "Rick", "Male", "Turner", "왮̠枮华䐑샼㌝廛졢⊙", "룫셕࿆铣䂓킨ᖈ噋뵺堏", 0, null, null },
                    { new Guid("145e184e-5e65-5348-b047-7728eaabeb1e"), new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 29, 18, 2, 59, 410, DateTimeKind.Local).AddTicks(5863), "Millie_Wisoky@yahoo.com", null, null, "Alexie", "Female", "Rath", "裝㾒娇૝쓹ভ떥餫⧁♜", "䚽书⭮鶿篠狷륚䈳틈煠", 0, null, null },
                    { new Guid("16dd1341-f1e7-e056-7ff0-5e5055d45b68"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 24, 15, 29, 35, 632, DateTimeKind.Local).AddTicks(7107), "Duane18@yahoo.com", null, null, "Adela", "Male", "Johns", "쪖睔坚�脇⧠駂嘠", "ᥭ픙䡯陫Ⲥ띉䚺咝�桪", 1, null, null },
                    { new Guid("1737b321-f32d-1d71-7b31-dfe8aa07a91e"), new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 12, 22, 50, 35, 250, DateTimeKind.Local).AddTicks(2262), "Tito_Batz@gmail.com", null, null, "Mervin", "Male", "Bins", "剀潣㜦臘둘谷ề忚膼", "滶᩼ඩ鞞ᦇ㶭▿ᨶ駡팠", 0, null, null },
                    { new Guid("19c7c1de-5c54-cbe4-efd9-b93c9cc4d379"), new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 12, 12, 4, 31, 522, DateTimeKind.Local).AddTicks(479), "Aubrey.Windler13@hotmail.com", null, null, "Chester", "Male", "Goldner", "췪韃庡脌蛬폅懅뮐븕﮵", "嶦㰵樘俟뮐⨟᷍蠋ꝰਦ", 0, null, null },
                    { new Guid("1a877ae4-38a2-5610-af42-fda9910e4cb8"), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 27, 17, 2, 39, 438, DateTimeKind.Local).AddTicks(7740), "Angelina83@gmail.com", null, null, "Bennett", "Female", "Runolfsson", "猞怲쐦鋀㭝䚽஘ⶵ蠜�", "呈Ｆ櫔⥕콃臾寿蘚ࡒ", 2, null, null },
                    { new Guid("1aa82e0b-42b9-1a43-8569-8384583ff3d4"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 5, 1, 14, 45, 472, DateTimeKind.Local).AddTicks(9691), "Eino.Bosco@hotmail.com", null, null, "Aletha", "Female", "Rau", "ꋹ榣趣얿ᘆ踯巓ꖜ㝣懀", "윐뽕�ꓛ䳆⎻䪍刴帩", 0, null, null },
                    { new Guid("20a6143c-836a-afb7-c5d4-247987d71c4c"), new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 8, 11, 38, 52, 708, DateTimeKind.Local).AddTicks(6821), "Kayden.Bauch79@yahoo.com", null, null, "Josefina", "Male", "Hintz", "谄諯╓ﭢ蝙஼㾉⦷ᰃ", "⃟屾⣆䛔찵쉎쵋켂䑦य", 1, null, null },
                    { new Guid("25822ac1-9c26-8f21-8fbb-86bd9d9c76f7"), new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 13, 17, 58, 59, 153, DateTimeKind.Local).AddTicks(267), "Arielle4@gmail.com", null, null, "Vicenta", "Female", "Stehr", "�娀횫竴죖볶㍈㚝૩괈", "齵홈䆀ꄽ�髣䤢", 1, null, null },
                    { new Guid("294e20d4-c8c1-aa0b-7d9c-cd721760188f"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 11, 22, 26, 2, 386, DateTimeKind.Local).AddTicks(1151), "Valentine.Torp67@gmail.com", null, null, "Everette", "Female", "O'Reilly", "뷝約쉌烍裎࢟⮳씐간", "쳁豭厥샼쥗䢫Ӌ곁﬎瀺", 0, null, null },
                    { new Guid("2a39cfd1-be7c-d0ed-827f-dbc41485c8e7"), new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 13, 17, 3, 47, 762, DateTimeKind.Local).AddTicks(6153), "Icie_Koss@hotmail.com", null, null, "Delpha", "Male", "Emard", "�恴쿫扢貀桡훗脨懛炝", "ණ锴㝸ꖣ蛱㺍茯", 2, null, null },
                    { new Guid("2cadbcbe-1b44-405d-c842-3b5bb6cca93e"), new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 10, 7, 9, 58, 304, DateTimeKind.Local).AddTicks(1562), "Sebastian.Schuppe@gmail.com", null, null, "Tina", "Female", "Miller", "㋔㡷⌚粛아껲嘝哏ὔ蓲", "Ꮐ嶧鬈盦嬏䀃∠൛薇", 2, null, null },
                    { new Guid("2eb8ddf3-2951-7472-1482-4adf6ad43586"), new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 8, 22, 17, 10, 697, DateTimeKind.Local).AddTicks(2525), "America.Raynor52@gmail.com", null, null, "Kirsten", "Female", "Tromp", "촿踒﮿棊睆꫞អ㨚ﱔ⢛", "펨ꊔ猄�ᒽⷆ䏫䬑꼚", 1, null, null },
                    { new Guid("2f3a9038-6f67-4225-78ea-c9f4c7a08e27"), new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 2, 3, 39, 1, 436, DateTimeKind.Local).AddTicks(3894), "Vella_Abernathy18@yahoo.com", null, null, "Sigmund", "Female", "Kunze", "嵘뀼뜴羃퍼囼�䇳꣞걏", "憜覢蝣๎뾞殽˟䖠�崨", 2, null, null },
                    { new Guid("307c5dac-2762-6bf3-1361-9a890ad4c5d4"), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 5, 4, 6, 35, 937, DateTimeKind.Local).AddTicks(231), "Madalyn97@yahoo.com", null, null, "Vito", "Female", "Purdy", "鋇糼鴹橵㷗⌖喡㜞ྣ", "ೌ塅壙ꔎﾷ鲇�化", 2, null, null },
                    { new Guid("30844130-07e2-128c-bba7-aca73829426e"), new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 9, 2, 30, 55, 414, DateTimeKind.Local).AddTicks(3921), "Jana.Cronin95@hotmail.com", null, null, "Tristian", "Female", "Pfeffer", "⁵㘤䛤䖰亙ᵛۉ秾舒", "ꕪẑ쾇ײַḡ苬륞ￏ", 1, null, null },
                    { new Guid("30c8b8a3-976b-d777-cf16-d199e7f9d2e0"), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 29, 0, 31, 38, 757, DateTimeKind.Local).AddTicks(4663), "John_Toy@yahoo.com", null, null, "Ezra", "Female", "Kunze", "隽鹀ﰆ儃鲚䟬ဂ菉ꏝ", "♠с턉㮒ﲮ辗蜪ț둼ؙ", 1, null, null },
                    { new Guid("30fe9814-6de9-ae64-9612-8a6bb8cbc06f"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 15, 5, 30, 42, 420, DateTimeKind.Local).AddTicks(3624), "Modesto28@gmail.com", null, null, "Archibald", "Female", "Stark", "铬*։戫恮ֺ쑰ၧ࿻봝", "雡ﮒ䉨䫯膆׀諕霰꤫螴", 0, null, null },
                    { new Guid("3310c368-05f6-f01d-7438-9efe65836460"), new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 19, 17, 52, 7, 854, DateTimeKind.Local).AddTicks(5041), "Fredy60@gmail.com", null, null, "Meda", "Male", "Jerde", "䀡榴㳇鹏㶕르❺嶇", "琉�騠燸ﵛﭼ䉔骍䂏", 0, null, null },
                    { new Guid("35e57337-7f0b-c5ea-483b-5abffcc9d505"), new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 18, 18, 14, 0, 655, DateTimeKind.Local).AddTicks(3046), "Darrin29@hotmail.com", null, null, "Mose", "Male", "Mohr", "፧鷍몐걩蕑�섙뮭ᚷ", "�ࢫ⥅㧥愽ꑶ剗瑐亿賷", 0, null, null },
                    { new Guid("3f541f50-f266-eb26-0a07-8dfeaf40e0db"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 15, 12, 1, 20, 515, DateTimeKind.Local).AddTicks(3251), "Cecilia_Kuphal17@gmail.com", null, null, "Rae", "Female", "Senger", "∎�ꭋ㖢胂⏲퀋", "降봵夀ꠟ뭱␑㔕", 1, null, null },
                    { new Guid("419b2317-b782-ce59-68a6-422842e3f852"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 9, 2, 50, 519, DateTimeKind.Local).AddTicks(1361), "Brianne7@yahoo.com", null, null, "Felicita", "Female", "Champlin", "㡨锋䜁ᵴ턙裱j랢慺", "䚇첒ކ꼙⎴�ℚ됮髮", 1, null, null },
                    { new Guid("41c31c29-8c65-2f15-2f79-9c9d2e82abf7"), new DateTime(2022, 11, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 13, 3, 20, 43, 934, DateTimeKind.Local).AddTicks(5884), "Earline.Botsford34@yahoo.com", null, null, "Kyra", "Male", "Pfeffer", "⬼辂囮뼩冂쓭샎�", "㘵乜訏ⴊꐏ䁸ዿ槰", 0, null, null },
                    { new Guid("42eb034d-9af8-8fe3-4e01-7a0ea900693c"), new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 2, 20, 38, 45, 232, DateTimeKind.Local).AddTicks(4342), "Wilhelm_Hammes@gmail.com", null, null, "Art", "Female", "Bradtke", "╮်仔�䒰㙡䘳ট삵ꪂ", "ꗬꉣ䇗쁒ꎷ數型○콊", 1, null, null },
                    { new Guid("4305cd36-7d8e-077d-4010-efe2d06d4f74"), new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 2, 9, 28, 57, 369, DateTimeKind.Local).AddTicks(1833), "Oswald.Dibbert25@yahoo.com", null, null, "Gus", "Female", "Stiedemann", "黸⽺쥛絥ႎ븘♚", "ꄟ➂麩뽧颯㔹㋾퀿䄢瓌", 0, null, null },
                    { new Guid("43ba84be-87ad-549c-a4b7-d9ea965d02a2"), new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 29, 22, 35, 35, 466, DateTimeKind.Local).AddTicks(3084), "Celia.Douglas@yahoo.com", null, null, "Carey", "Male", "Harris", "�⤕Г擁屁ὦᚐ껻", "Ⓕсᖎꈲ縼姡⦀퉸ᛸ", 2, null, null },
                    { new Guid("43deb1d4-4415-f720-3f2c-03ef30dd8c6c"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 24, 0, 53, 37, 543, DateTimeKind.Local).AddTicks(989), "Mable29@gmail.com", null, null, "Shany", "Male", "Johns", "�倡㐃ꦾᵷᰪ霪᫄", "寧竈⭡﬜둲㤟�裑", 2, null, null },
                    { new Guid("44a9dc86-3cb2-d1b0-9eac-ab8ece7a464a"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 20, 3, 57, 25, 999, DateTimeKind.Local).AddTicks(5153), "Audrey9@hotmail.com", null, null, "Armani", "Male", "Feest", "䘅ઽ৔侤ꤶ벣諚悹", "㠅ါ䇝诘践廫餋邓溃", 1, null, null },
                    { new Guid("48552ea0-4a98-ecba-b856-56dc1988e993"), new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 30, 1, 26, 39, 721, DateTimeKind.Local).AddTicks(9254), "Flossie.Metz@gmail.com", null, null, "Elouise", "Female", "Bins", "⽨ᨁ限᧣餴ꨤ잶瑢礮倦", "췛쮞쐋鷜Ⲝ屍邤腴圏㑛", 2, null, null },
                    { new Guid("48f7ea7b-490e-f1e3-dc12-fc7dbf87d5ae"), new DateTime(2023, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 24, 5, 32, 12, 837, DateTimeKind.Local).AddTicks(8566), "Kris.Zboncak@hotmail.com", null, null, "Art", "Female", "Treutel", "尲ዖ餠�筓킯좹횳ᗋ", "ᥗ蓑ꅗ휗Ꮡ⑏ꚉ潮", 2, null, null },
                    { new Guid("4cc46f37-6b4b-c2a6-413a-04b27f3fc1f3"), new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 14, 18, 44, 15, 355, DateTimeKind.Local).AddTicks(6544), "Raleigh_Pollich40@yahoo.com", null, null, "Camylle", "Female", "McCullough", "⎁슓�⯲鏻鋸೟⦼ⶵ�", "椊욖㒃鎏ﻶﺆ✾ܭޤ", 1, null, null },
                    { new Guid("4d5435b8-241a-6cc4-2f64-68bcde765b06"), new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 11, 8, 32, 53, 679, DateTimeKind.Local).AddTicks(3090), "Toney98@gmail.com", null, null, "Maximo", "Male", "Buckridge", "൷딣͘漠풌戚ꆧ铈ᥕ", "掖棑ᢣ�豩唞∁湾", 2, null, null },
                    { new Guid("4f076d09-44a1-7244-83dd-ecc0e1561ed8"), new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 18, 10, 0, 17, 627, DateTimeKind.Local).AddTicks(788), "Virgie26@hotmail.com", null, null, "Eusebio", "Male", "Thiel", "欗腬➏퐧뒷㾒㾌", "퉗ꑍ캊脗௔꠳㉬ￎ�", 2, null, null },
                    { new Guid("52069abe-35d7-351e-3566-568cb8f35ab3"), new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 8, 7, 59, 26, 668, DateTimeKind.Local).AddTicks(4149), "Jody_Senger17@gmail.com", null, null, "Serena", "Male", "Gorczany", "䀅〹黴둒顑쫳܈䟍롦", "韙骯浯ꇬ壅؛�챻똔", 1, null, null },
                    { new Guid("529568de-81bf-7251-c350-82e92eef0de4"), new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 1, 11, 31, 46, 470, DateTimeKind.Local).AddTicks(9970), "Tyrel.Oberbrunner@yahoo.com", null, null, "Linnie", "Male", "Russel", "䑡缑摒魛ᐷ塞ᴅ", "鴂Ｉ糺뛿Ꞌꬽꮄꙣ夔", 0, null, null },
                    { new Guid("5348db7b-1da5-06ea-e4b2-477c34c0263d"), new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 4, 1, 5, 58, 976, DateTimeKind.Local).AddTicks(1005), "Bridgette_Beahan36@hotmail.com", null, null, "Justus", "Male", "Hegmann", "쫸厗錃섃烄粇윩ἱ", "릞磨厰᳛莖炢榑", 2, null, null },
                    { new Guid("59185c9b-afc1-4ed3-c1a4-ba6fb11e9d1f"), new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 26, 15, 51, 1, 733, DateTimeKind.Local).AddTicks(5452), "Macey45@gmail.com", null, null, "Kellen", "Male", "Douglas", "Ἵ䆏訴䊁Ȫ௑꣬ᢤ�ᄫ", "㈯ꜵ숟⏻׮뾁䞠䙴", 0, null, null },
                    { new Guid("5b09b81a-6567-a514-21a0-6722fc778cb1"), new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 25, 8, 59, 26, 832, DateTimeKind.Local).AddTicks(3861), "Cara.Bins54@yahoo.com", null, null, "Dane", "Female", "Sanford", "ᐵଞ缗ฯ糑梖㑑钿귿ꁍ", "�ꂅ磝ꠞ㭨若ꏴ⽣ꅅݷ", 0, null, null },
                    { new Guid("5cf13df2-d817-4983-5095-c4684d896d9b"), new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 16, 6, 11, 40, 875, DateTimeKind.Local).AddTicks(9546), "Connor1@hotmail.com", null, null, "Cletus", "Female", "Beahan", "䚰㒤룧쬏䊸⪨﫹䋧逝ㆳ", "豈�礧ᯋ搄쮼짞螷砆擌", 0, null, null },
                    { new Guid("5d4743b3-1de3-7cc8-f4a5-78d2f39fe741"), new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 29, 17, 59, 35, 716, DateTimeKind.Local).AddTicks(8080), "Robert.Bernhard@gmail.com", null, null, "Rory", "Male", "Hamill", "棸늄㲸▼溲灢ӽ䪋䕯", "穘孡뼼ᗕ쵡꙱죦楎䧝", 0, null, null },
                    { new Guid("5dc56630-1789-ab84-52e3-958d6ae69edf"), new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 15, 3, 48, 38, 1, DateTimeKind.Local).AddTicks(3066), "Misty_Emmerich79@gmail.com", null, null, "Cornell", "Female", "Doyle", "沢㡌霳Ῑ�ⱞ⮼끸猋", "䷱顗鸾跬듬峴㴢നᙒ쯓", 1, null, null },
                    { new Guid("5f4cdd8c-a01d-d46d-b84b-66ef2dc1758b"), new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 14, 21, 49, 48, 986, DateTimeKind.Local).AddTicks(9138), "Dewitt27@gmail.com", null, null, "Marty", "Male", "Bartoletti", "ꘄ⥱䑓帜㘋ᘝ따ᐝﴇ", "᱆∯쁷à檪텔̕�누㾷", 1, null, null },
                    { new Guid("62d0d82c-0294-20f4-9663-7a0f458d660e"), new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 7, 1, 13, 24, 807, DateTimeKind.Local).AddTicks(4124), "Angelita_Ledner68@gmail.com", null, null, "Lucius", "Female", "Smith", "ᙫⷚ涿瑴ꮏ點藂", "ಆ穂ל㴵Ở木ঀߖ䆟銠", 0, null, null },
                    { new Guid("650ae824-701b-eed9-ab15-cf27d3f834fa"), new DateTime(2023, 7, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 15, 5, 5, 42, 665, DateTimeKind.Local).AddTicks(1770), "Bobbie12@hotmail.com", null, null, "Doyle", "Female", "Ritchie", "ᔠ䅧紹ٶ㇙୮ᒂ碑", "웼慾䏃켦索⿣҅Ṳ炨", 2, null, null },
                    { new Guid("68b29311-2e68-2a60-89ef-8dd36f712fb2"), new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 10, 23, 3, 21, 75, DateTimeKind.Local).AddTicks(3667), "Marisa73@yahoo.com", null, null, "Jacquelyn", "Female", "Ratke", "耫붰慠鞰�⒄榚꓊Ꝼ", "줉ℍᙵ㮢琴趠씎�袧磆", 1, null, null },
                    { new Guid("695dde12-e5a3-2648-7267-3f61de01cfa6"), new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 1, 20, 15, 53, 301, DateTimeKind.Local).AddTicks(706), "Lindsay58@hotmail.com", null, null, "Kale", "Female", "Quigley", "꺆躋詠敬訋泅ᮡ눛岀", "迀䠝﹋ꇾ匱搮䣪ᦐ粎涃", 1, null, null },
                    { new Guid("6bebd8d7-c36b-167f-9c25-fbc1a5b0780c"), new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 20, 6, 18, 18, 849, DateTimeKind.Local).AddTicks(6328), "Burnice.Abernathy51@yahoo.com", null, null, "Jordane", "Female", "Tremblay", "봐墴♢섄쭯㲤Ჰ䣻飶윓", "鱾ঞ续發⢄렓㙕㻋까閆", 0, null, null },
                    { new Guid("6c6d2013-3562-3a35-4b81-4060f926923f"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 27, 4, 57, 16, 975, DateTimeKind.Local).AddTicks(1916), "Madonna.Pfannerstill@yahoo.com", null, null, "Rupert", "Female", "Gibson", "`쭕鋃ၓ诰떳ֱ炮⦳", "瀾ꮠ蘐ꠙ৺咺撢�ꗵ嬞", 0, null, null },
                    { new Guid("6fee3171-0e29-52c2-b5ab-d8ddb362e1b2"), new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 15, 2, 33, 48, 815, DateTimeKind.Local).AddTicks(8892), "Jacky.Stanton81@hotmail.com", null, null, "Fleta", "Male", "Koepp", "쀓ꠇ띃॔៷粇�掿扭", "攪ᅥݱ蛽䀀ᴙ㺧⊕", 2, null, null },
                    { new Guid("729c8fec-6922-17a2-6263-45454815543c"), new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 25, 1, 25, 50, 551, DateTimeKind.Local).AddTicks(1735), "Marge_Treutel66@gmail.com", null, null, "Gilda", "Male", "Fay", "틴鷇垛펦㻮棚ｧ䃩�䡋", "纏鎕砓೴驮ゥṛ䐨勆", 0, null, null },
                    { new Guid("72c8c787-5835-083a-e2dc-ee8e687f6318"), new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 30, 7, 10, 18, 280, DateTimeKind.Local).AddTicks(1036), "Veda.Borer90@hotmail.com", null, null, "Judson", "Male", "Hintz", "�蟟釃뮲ᑷ楄ꭎ⮻᫛㴁", "郌챫損᜶珜憸d⁳䲏�", 0, null, null },
                    { new Guid("736b85fb-6fee-e8c7-d92c-3094e53719ce"), new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 23, 10, 28, 9, 224, DateTimeKind.Local).AddTicks(5076), "Alessandro48@gmail.com", null, null, "Kyra", "Male", "Huel", "㷆䝱┱늏唫麍緈竢ﶥঠ", "骵퇇筤氥괚ᶍႫ묡�", 0, null, null },
                    { new Guid("740d4c5b-c8c0-6b2a-c705-0a9f607e12c6"), new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 26, 13, 12, 56, 916, DateTimeKind.Local).AddTicks(9585), "Stacy23@yahoo.com", null, null, "Karlie", "Female", "Jerde", "겖ꈤ謺奯㗪ȅ㓔뾳항", "묶껁曒圄ꚠਚ쫟게缤傡", 1, null, null },
                    { new Guid("7b70d7ba-3fc9-a8da-629d-3403cba51ad5"), new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 6, 8, 18, 367, DateTimeKind.Local).AddTicks(4172), "Selina_Nienow@gmail.com", null, null, "Alysha", "Male", "Padberg", "憻䕽䂡閽쨗堘槻탫⭁", "隐᧳⪐䥋뇗㊠⅏呶�", 1, null, null },
                    { new Guid("7b8f697e-8b95-b64f-37f1-36251a3011c6"), new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 15, 19, 53, 33, 946, DateTimeKind.Local).AddTicks(7403), "Gracie52@yahoo.com", null, null, "Eve", "Female", "Shields", "՞ᤑ韁卬⬁骗⭩㼼", "瑢�䎰龁쮾诀鴉", 1, null, null },
                    { new Guid("7dd3ec8d-a88b-0d28-15ea-d6c200b1483b"), new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 22, 13, 51, 39, 214, DateTimeKind.Local).AddTicks(7335), "Nichole32@yahoo.com", null, null, "Patsy", "Male", "Nikolaus", "앨些샟䃡⩇䤰ꃿ攛椁ᷱ", "䎊鄣뤿썄뭃୽鱌൙棓", 0, null, null },
                    { new Guid("7e1c366e-4eb0-1f19-a44d-7c810b3ef9bf"), new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 11, 23, 9, 733, DateTimeKind.Local).AddTicks(6373), "Alfonso59@hotmail.com", null, null, "Ophelia", "Female", "Beer", "�⟫䰆Ή�콚堁蛯舠�", "䯳�誇㹒୬캣꾭粂䲲㭴", 1, null, null },
                    { new Guid("7e1ddb36-9271-dc63-287a-f177aa192aba"), new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 13, 19, 11, 45, 697, DateTimeKind.Local).AddTicks(5046), "Emmie.Beatty@hotmail.com", null, null, "Bennett", "Female", "Glover", "拾畚荠먞̍䳢�菱", "劧獞쀶价ﻚᬵൕ殼", 2, null, null },
                    { new Guid("801f6011-0a0d-c8d2-cda8-438c4cee064f"), new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 21, 5, 12, 35, 862, DateTimeKind.Local).AddTicks(8017), "Piper59@hotmail.com", null, null, "Oren", "Female", "Schiller", "璯�䷷ൿȓ᭼�퍷", "愰䵷堋⟣၉ᰚ䞠ଃ", 2, null, null },
                    { new Guid("86045346-275b-ff02-d557-ce817c73de78"), new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 10, 10, 59, 11, 712, DateTimeKind.Local).AddTicks(8074), "Rickey74@gmail.com", null, null, "Gerson", "Male", "Prohaska", "꼔뷨覕꒮䠨險酚ㅉ囟", "풫䲡ዠ〆䮈䟹〔귆쮄쭩", 1, null, null },
                    { new Guid("871e9c1b-9dda-8a01-b54c-7c0438c7b726"), new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 13, 14, 53, 42, 920, DateTimeKind.Local).AddTicks(2773), "Jeanie_Champlin@yahoo.com", null, null, "Chyna", "Male", "Purdy", "桰㠢觿鄘≈癑冫氳✖", "შ컎裩军筵璁堻뮭皭", 0, null, null },
                    { new Guid("872eec42-d214-7473-7fce-6aeb1d501d20"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 20, 1, 40, 46, 189, DateTimeKind.Local).AddTicks(4878), "Korey_Reichel85@hotmail.com", null, null, "Sydnee", "Male", "Boyer", "땱鞥팹鳺瑺瓺㠵쒋ꖊ", "뺬ء鈱쥂譟謱䊯뷄", 0, null, null },
                    { new Guid("8843cd46-7669-6c39-8684-6a0a2f10e1da"), new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 28, 18, 19, 39, 571, DateTimeKind.Local).AddTicks(5416), "Elenora.Feeney78@gmail.com", null, null, "Rollin", "Male", "Shanahan", "眳ѭﲺ휞䚑臍喩", "鑜曳䊁뱺㥘礫ᛒᐥ띪륭", 2, null, null },
                    { new Guid("88cad496-36fd-9900-c8ed-248e495242bb"), new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 4, 19, 3, 41, 103, DateTimeKind.Local).AddTicks(424), "Kaylin6@hotmail.com", null, null, "Tomasa", "Female", "Stanton", "螦ے쩤驪捺세覤ꂱ", "楺Ḓ댥燜ꙥ硢眛鄂鬺", 1, null, null },
                    { new Guid("8afc6fb1-8e0e-33c4-4b70-5b31bde0ef60"), new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 5, 21, 54, 17, 263, DateTimeKind.Local).AddTicks(7693), "Angelina_Crona@yahoo.com", null, null, "Alexandre", "Male", "Glover", "ં퓋劚し脃푲饱䮴䔗", "鴖眬�䁸븠睟ᬿ컣鉩", 1, null, null },
                    { new Guid("8d6390e3-7302-5507-e182-34322a1e1bbc"), new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 7, 20, 45, 22, 511, DateTimeKind.Local).AddTicks(8878), "Carlie.Schmeler32@gmail.com", null, null, "Josue", "Male", "Dare", "暔伡క涋‚誺⇛᲻䩺㆙", "㘪㴚Ⱊ慜虾畧뾲΅㥀힁", 2, null, null },
                    { new Guid("8de8bed4-6786-8ca7-eaa8-035cb839f4a3"), new DateTime(2023, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 5, 7, 30, 9, 393, DateTimeKind.Local).AddTicks(1586), "Garth_Leannon@gmail.com", null, null, "Cordelia", "Male", "Hirthe", "螾㠺鷔ᅌ儲毱퉃䙠ᶸ", "ྌ⌾ኼ薞䱽餃햿鐖듖ꃸ", 0, null, null },
                    { new Guid("8e702aba-2dc1-f841-5865-d2b711ecd90c"), new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 9, 18, 53, 13, 374, DateTimeKind.Local).AddTicks(7735), "Beau_Brekke23@yahoo.com", null, null, "Mckenna", "Male", "Wyman", "鶼矻둡ϡ锅翲ﾈ㾋ﳳꘊ", "턞쨇♊ᆀ䚂藩쑁⇸", 0, null, null },
                    { new Guid("930ae6d8-37ef-2f82-fe93-c84b20d7d9c7"), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 27, 20, 27, 11, 542, DateTimeKind.Local).AddTicks(5678), "German55@yahoo.com", null, null, "Ryann", "Male", "Raynor", "묂쐺鋽슬抜甋闂傛ᏸ鬈", "䊣ᝄ㥶丅퉭噅뛱ꃧ晆", 1, null, null },
                    { new Guid("95ca4941-dc2a-36f3-dfa0-10bdb9f2fdcd"), new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 19, 16, 8, 6, 356, DateTimeKind.Local).AddTicks(5345), "Nannie.Runte38@gmail.com", null, null, "Verda", "Female", "Williamson", "⌹켅Ґ嫮⣁疉墷辗盄", "긆ﴫ릵苹ஐ相疴뛙鎡婕", 0, null, null },
                    { new Guid("9df28012-cbda-1cd7-ac31-07858561e3cc"), new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 17, 6, 1, 30, 732, DateTimeKind.Local).AddTicks(5156), "Herta.Bradtke91@yahoo.com", null, null, "Harold", "Female", "King", "舳⢐⸣簿镩�嵷악躡琐", "㚒괟腺筢痕Ꚓ뭥鍲ඦ", 1, null, null },
                    { new Guid("9eea48aa-6ac9-3f80-3212-0b246b96b00c"), new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 12, 8, 46, 52, 359, DateTimeKind.Local).AddTicks(4884), "Juwan.Pollich@yahoo.com", null, null, "Eleanore", "Male", "Pouros", "傘篁㢐峝ﰌब젦�臯햎", "틍酮馀佾篻�铢�䐣꿐", 1, null, null },
                    { new Guid("aaf8450d-2519-6869-4504-bfc246d3b063"), new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 9, 16, 36, 0, 433, DateTimeKind.Local).AddTicks(9332), "Abdul_Ullrich@yahoo.com", null, null, "Lon", "Female", "Robel", "玴觼ᾗ諌䂰♹�嘆⎪︄", "ڭꈞ奄몶퐶壮镡꿚", 1, null, null },
                    { new Guid("af5ef91b-8d33-ce87-33bf-fdbf072f763e"), new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 20, 7, 28, 18, 192, DateTimeKind.Local).AddTicks(9464), "Jerrell_Wyman94@hotmail.com", null, null, "Sofia", "Female", "Zieme", "莚ᨣ�驕㫏ᐯ큍ᙹ봎", "磁﹌緶ﲺ扩裬䀸", 2, null, null },
                    { new Guid("b334bc97-ee85-826c-fe0e-5e546fb29eab"), new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 25, 8, 36, 24, 162, DateTimeKind.Local).AddTicks(6486), "Esmeralda37@hotmail.com", null, null, "Victor", "Male", "Mante", "葮膍ԼᲖ섒䪚굏ԝ졁", "텴⊧﫶ض샯誧鎠侥㍛騰", 0, null, null },
                    { new Guid("b4278132-72bd-80fc-65b8-c5e44bef376a"), new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 11, 21, 35, 22, 834, DateTimeKind.Local).AddTicks(7532), "Mohamed_Reinger95@hotmail.com", null, null, "Pierre", "Female", "Konopelski", "ῑᬎ␱揉⛳祶僸坼", "ᤧꏕ者ઢ南蟶鯧㑣", 1, null, null },
                    { new Guid("b82f6da5-33b1-ade8-5c71-dac0d1be84ec"), new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 17, 1, 57, 37, 816, DateTimeKind.Local).AddTicks(5523), "Kayley.Rowe@hotmail.com", null, null, "Eldon", "Female", "Adams", "傛봯啮ץ္₠ඤㇿꈕꍐ", "ꕋ駡荜ᅘ�멨ｳ鈗肘", 0, null, null },
                    { new Guid("b8bfe4d4-7010-2cb3-1404-c0112e57a897"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 11, 16, 20, 18, 725, DateTimeKind.Local).AddTicks(6281), "Bria_Lang2@hotmail.com", null, null, "Mafalda", "Male", "Mohr", "㿃办迠罳燍甑핺๳飭", "챒ㄡ섺态શ莩姅㓱", 0, null, null },
                    { new Guid("bc35889f-1d95-4029-7ee4-6452d1526353"), new DateTime(2023, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 20, 23, 21, 33, 811, DateTimeKind.Local).AddTicks(8323), "Fausto78@hotmail.com", null, null, "Giovanny", "Male", "Mertz", "媆狦ͬ帊깇忒◡쓷麚", "鑍瞼풴啗퉂瀬꿪偄", 0, null, null },
                    { new Guid("be776de5-027a-3277-3ac3-0191c5282a06"), new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 2, 4, 22, 6, 621, DateTimeKind.Local).AddTicks(6466), "Angel_Boyle@gmail.com", null, null, "Chris", "Male", "Hayes", "뒔᯷쨺ጷᵇ뺋籶�珓࿤", "遲Ꮵ卨��䖱씅蟛䂗", 1, null, null },
                    { new Guid("c011b317-5d6f-3991-c54a-6a976dd3a86d"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 19, 9, 41, 35, 546, DateTimeKind.Local).AddTicks(9027), "Trent_Spinka@hotmail.com", null, null, "Jessie", "Female", "Nienow", "形楺뾜ᣳ䄯射ᑮ怑샒", "ꧯ삄帢빃プ뼠ҫ뾪흴颌", 1, null, null },
                    { new Guid("c549b4fc-bb5d-040b-83dc-78cdd7e55b43"), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 2, 19, 36, 38, 41, DateTimeKind.Local).AddTicks(7005), "Zion_Blanda@yahoo.com", null, null, "Scarlett", "Female", "Lehner", "ꀃѰ⇜㉀冕䠖蓛忟윯㺸", "ᗹ멵쨣⠤ힽ꜄᷼", 0, null, null },
                    { new Guid("c6206cf1-f6f8-6bcc-2657-d66db93b7189"), new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 15, 18, 30, 56, 192, DateTimeKind.Local).AddTicks(9752), "Kaley80@hotmail.com", null, null, "Lexie", "Female", "Cole", "�绡堨쭐缅ﭟ䷊ꉑ跃ⴴ", "珡醏纕녦쓜茅픧ۢ", 2, null, null },
                    { new Guid("cbf414e1-4662-ef83-0407-b8c6b7bdb0ba"), new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 30, 3, 14, 48, 965, DateTimeKind.Local).AddTicks(8109), "Laverne.Wiza@yahoo.com", null, null, "Alexa", "Female", "Sipes", "⤨ꚹ熓흸㷹ח킜ꝼ柨", "ꞡ竊䮉骅欰쬀ﬕ൓軮", 2, null, null },
                    { new Guid("ccbff4b7-52e0-ced8-370a-01db243842f1"), new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 4, 23, 12, 10, 697, DateTimeKind.Local).AddTicks(2663), "Monica94@gmail.com", null, null, "Katelynn", "Female", "Terry", "ᤪ껁䐃틒�㼃�䄴姇", "뫍뱾ﳓ䐇䷊�志Íਧ", 2, null, null },
                    { new Guid("ce21c3c8-4713-a3b4-1180-fb5e3c415996"), new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 12, 12, 48, 15, 687, DateTimeKind.Local).AddTicks(9980), "Simone.Shanahan@gmail.com", null, null, "Alexane", "Female", "Emmerich", "﹔P탐电र颋ꍈꢹ", "宁恓⁬뻆矟헭␗푔娌ꗺ", 0, null, null },
                    { new Guid("d3897d8f-ccb4-e22a-c460-b60317addca5"), new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 25, 9, 7, 14, 130, DateTimeKind.Local).AddTicks(278), "Alf86@gmail.com", null, null, "Ernestine", "Male", "Toy", "ᡠ蚠஦켷秀ꉻ蘆ڼ", "ᔰ푇鸿᭮愔算甏꼇", 2, null, null },
                    { new Guid("d3d07c4d-dd4b-abde-5a7e-eae2584e9d78"), new DateTime(2023, 7, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 10, 22, 13, 39, 902, DateTimeKind.Local).AddTicks(2690), "Gregory_Haag59@yahoo.com", null, null, "Wade", "Male", "Lemke", "뺄ὑ砜쾶幐偗뵤뺀䁞ތ", "繡㴗》烟㔀⊵薀炨餴᧦", 0, null, null },
                    { new Guid("d96b4e6c-0fb7-0083-4447-42c854eb15ac"), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 18, 48, 20, 213, DateTimeKind.Local).AddTicks(1096), "Cleveland_Wiza@yahoo.com", null, null, "Maximillia", "Female", "Hoeger", "쟇੭鼻�⬁Ể푿印蔍ꇙ", "熝롋왐౱査緆䆩妾", 1, null, null },
                    { new Guid("d9f41bbc-2710-97c1-75e6-0f4ea5a4269d"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 25, 1, 26, 37, 354, DateTimeKind.Local).AddTicks(4074), "Teagan.Ernser@hotmail.com", null, null, "Edgardo", "Male", "Gislason", "鱭永䷸匿摬ᒌ᳛屖䖎䪑", "欭쓍퀚탈밙찖ק篢", 0, null, null },
                    { new Guid("daf9e708-16bd-cccb-50c1-c1a2c932a865"), new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 14, 20, 12, 57, 120, DateTimeKind.Local).AddTicks(2712), "Weldon_Parisian@gmail.com", null, null, "Eudora", "Male", "Harris", "嶼箸๻⦈㉽彣韤⺗ꂁ⽆", "鿭৯흶蜇䁂癌㣫饗蒂皊", 1, null, null },
                    { new Guid("dba1b893-1167-2d2b-acc7-696e13005a7e"), new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 15, 7, 58, 35, 119, DateTimeKind.Local).AddTicks(7641), "Moses.Auer@yahoo.com", null, null, "Ulises", "Male", "Wiza", "ﵼʷ珲蟳᜖�神뼇ꦖ㿒", "밾㊎徯鳯坼担﹘噕庄꭛", 1, null, null },
                    { new Guid("df76e192-64d0-89e9-d00e-b49e976b7ef1"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 17, 20, 11, 32, 76, DateTimeKind.Local).AddTicks(1040), "Agustina70@hotmail.com", null, null, "Electa", "Male", "Zieme", "ꖇ㳜츁䋑㪕琿ᙇ菷İ蕲", "쩞則霂큓먙羧✒䙫⿘", 2, null, null },
                    { new Guid("e3dbd453-ec9b-882d-b5b4-9e4f10e3d949"), new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 5, 9, 55, 37, 980, DateTimeKind.Local).AddTicks(2551), "Toney_Homenick@hotmail.com", null, null, "Tamia", "Female", "McLaughlin", "槆ႀꈜ亻韫퀰ↇ㚁", "넄㯩Ⲗ蔳徣嚣₥঑믣", 2, null, null },
                    { new Guid("ebc7ff6d-4a74-f834-8adb-69d662cd7147"), new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 23, 6, 47, 16, 586, DateTimeKind.Local).AddTicks(2536), "Maybelle.Schneider@gmail.com", null, null, "Juliet", "Female", "Blanda", "癔⤓⣽漟㢽얛だᜊ톤䃛", "嘸䓭렠灧쵲쀟抇ꩂ䍕", 1, null, null },
                    { new Guid("ed5b0d64-c6cf-6083-e3f9-d36e66073b50"), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 16, 5, 54, 1, 849, DateTimeKind.Local).AddTicks(5496), "Pierce_Rutherford@gmail.com", null, null, "Bridie", "Male", "Robel", "氫넑鸀誤쎑᪌액嘙╟", "檋动䰱殺캦㶸嫎脀彫", 2, null, null },
                    { new Guid("ee69e790-88fd-edb7-c663-9f42a4684387"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 20, 6, 42, 10, 96, DateTimeKind.Local).AddTicks(225), "Janis43@gmail.com", null, null, "Phyllis", "Male", "Armstrong", "ﴱ᳂ꡠጏ쨧૗ᮥ场鉴", "ꂛ⠳莹࿤⬕⺜ꪦ烓᛽", 2, null, null },
                    { new Guid("efd14b66-3f9f-d2e1-e2de-58f374ca845b"), new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 12, 14, 28, 42, 15, DateTimeKind.Local).AddTicks(3220), "Justen_Moen15@hotmail.com", null, null, "Haley", "Female", "Gibson", "昪㚉㴵�㺉店⫆줹攝䴜", "ᤌ縺䶣ꭷ松閟ת鼹ﳪ", 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Barangay", "City", "Country", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EmployeeId", "Line1", "Line2", "Province", "Status", "Type", "UpdatedAt", "UpdatedBy", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("002c246b-31ad-22fc-a927-0187fea920d0"), "Alaska", "MacGyverview", "Japan", new DateTime(2024, 5, 24, 8, 26, 45, 482, DateTimeKind.Local).AddTicks(2782), "Zella.Toy@yahoo.com", null, null, new Guid("4f076d09-44a1-7244-83dd-ecc0e1561ed8"), "06977 Ruecker Forks", "Knoll", "New York", 1, 1, null, null, "31220" },
                    { new Guid("033a3377-b365-75f8-262f-034c35d1b62d"), "South Carolina", "East Jamirville", "Samoa", new DateTime(2024, 2, 19, 2, 51, 13, 3, DateTimeKind.Local).AddTicks(4060), "Maia.Rau45@yahoo.com", null, null, new Guid("42eb034d-9af8-8fe3-4e01-7a0ea900693c"), "67845 Althea Plains", "Points", "Wyoming", 2, 0, null, null, "61388" },
                    { new Guid("089ae727-b506-eafa-942a-f7ce868b2c36"), "Kentucky", "Fisherhaven", "Bhutan", new DateTime(2024, 10, 1, 2, 54, 52, 206, DateTimeKind.Local).AddTicks(3021), "Raegan18@yahoo.com", null, null, new Guid("7b70d7ba-3fc9-a8da-629d-3403cba51ad5"), "35769 O'Kon Junction", "Causeway", "California", 2, 2, null, null, "90032" },
                    { new Guid("09d9271f-d7c5-3cf4-c2a3-3809ae7e01db"), "Michigan", "West Hassie", "Brunei Darussalam", new DateTime(2024, 4, 6, 21, 31, 18, 184, DateTimeKind.Local).AddTicks(1531), "Julius_Jerde40@yahoo.com", null, null, new Guid("9df28012-cbda-1cd7-ac31-07858561e3cc"), "8487 Emie Route", "Creek", "Maryland", 0, 1, null, null, "14156-2691" },
                    { new Guid("1604c769-3dd1-c7ac-6a56-39828fb945cc"), "Maryland", "Port Evertberg", "Iceland", new DateTime(2023, 11, 16, 22, 40, 30, 792, DateTimeKind.Local).AddTicks(7439), "Kylie.Feil4@gmail.com", null, null, new Guid("c011b317-5d6f-3991-c54a-6a976dd3a86d"), "34586 Robel Springs", "Unions", "New Jersey", 1, 0, null, null, "24152-7806" },
                    { new Guid("19d4c350-6a47-f506-e167-ef0a10e61a0a"), "North Carolina", "Lake Mack", "Senegal", new DateTime(2024, 3, 29, 16, 26, 32, 227, DateTimeKind.Local).AddTicks(7967), "Josh.Stoltenberg@yahoo.com", null, null, new Guid("35e57337-7f0b-c5ea-483b-5abffcc9d505"), "827 Raoul Station", "Tunnel", "New Jersey", 1, 1, null, null, "96723" },
                    { new Guid("1aa2be82-59a3-d935-b083-0f07da458c74"), "Illinois", "Lake Stuartville", "Comoros", new DateTime(2023, 12, 23, 10, 25, 19, 619, DateTimeKind.Local).AddTicks(9106), "Bulah_Kreiger@yahoo.com", null, null, new Guid("6fee3171-0e29-52c2-b5ab-d8ddb362e1b2"), "9809 Americo Ville", "Roads", "South Carolina", 2, 2, null, null, "96420" },
                    { new Guid("1de650b8-e1b5-2032-9617-0c57ad958626"), "Maine", "East Clemmieborough", "Nepal", new DateTime(2024, 4, 11, 18, 4, 52, 265, DateTimeKind.Local).AddTicks(6787), "Jo_Heaney23@hotmail.com", null, null, new Guid("c011b317-5d6f-3991-c54a-6a976dd3a86d"), "991 River Grove", "Fort", "New York", 2, 1, null, null, "81527" },
                    { new Guid("215e74ab-c4c6-2ee7-fbed-74777dc36f84"), "Kansas", "New Marcus", "Kazakhstan", new DateTime(2023, 11, 23, 8, 37, 9, 681, DateTimeKind.Local).AddTicks(8777), "Walker.Hintz@hotmail.com", null, null, new Guid("b82f6da5-33b1-ade8-5c71-dac0d1be84ec"), "3936 Leonora Forges", "Well", "Washington", 0, 1, null, null, "00907-6902" },
                    { new Guid("2e63e0d8-0098-51e2-9d82-fd876c60cb61"), "Nebraska", "Port Myrticeville", "Turkmenistan", new DateTime(2024, 6, 6, 5, 1, 20, 465, DateTimeKind.Local).AddTicks(5883), "Karolann_Ryan14@hotmail.com", null, null, new Guid("8e702aba-2dc1-f841-5865-d2b711ecd90c"), "0303 Dennis Row", "Drive", "Oklahoma", 1, 2, null, null, "93457" },
                    { new Guid("3b24173f-ab5b-e645-4d89-9b5e516bdf20"), "Arkansas", "East Aurore", "Jamaica", new DateTime(2024, 4, 28, 19, 7, 42, 767, DateTimeKind.Local).AddTicks(4712), "Talia2@yahoo.com", null, null, new Guid("bc35889f-1d95-4029-7ee4-6452d1526353"), "12743 Schroeder Stream", "Garden", "Pennsylvania", 1, 1, null, null, "52171" },
                    { new Guid("3daeecda-6085-62a6-a90c-c4b27af8a2e4"), "Rhode Island", "Ellsworthmouth", "Philippines", new DateTime(2024, 5, 19, 4, 55, 41, 352, DateTimeKind.Local).AddTicks(2150), "Sincere_Dare@yahoo.com", null, null, new Guid("8e702aba-2dc1-f841-5865-d2b711ecd90c"), "308 Walker Cape", "Village", "Alabama", 2, 1, null, null, "91439-1722" },
                    { new Guid("3e912e46-eb16-6283-c513-1f9ee7ded8b7"), "Idaho", "South Ignatius", "Estonia", new DateTime(2024, 9, 11, 6, 51, 38, 628, DateTimeKind.Local).AddTicks(9283), "Dedric25@yahoo.com", null, null, new Guid("72c8c787-5835-083a-e2dc-ee8e687f6318"), "933 Jonathon Fords", "Well", "Arkansas", 1, 0, null, null, "67455-8917" },
                    { new Guid("42b71f26-8b90-3bb3-12bc-2a1852aa0bab"), "Connecticut", "Ratkehaven", "Burundi", new DateTime(2024, 1, 29, 23, 51, 2, 61, DateTimeKind.Local).AddTicks(9292), "Brenden_Baumbach66@yahoo.com", null, null, new Guid("5d4743b3-1de3-7cc8-f4a5-78d2f39fe741"), "5135 Thalia Light", "Throughway", "Alaska", 1, 0, null, null, "33106-2808" },
                    { new Guid("44f5fd65-1e8f-9047-4199-10d991db3b37"), "Mississippi", "Kertzmanntown", "Somalia", new DateTime(2024, 7, 17, 2, 29, 14, 17, DateTimeKind.Local).AddTicks(7913), "Luciano.Schaden@gmail.com", null, null, new Guid("30fe9814-6de9-ae64-9612-8a6bb8cbc06f"), "94985 Devon Plains", "Roads", "Minnesota", 1, 1, null, null, "05889" },
                    { new Guid("45c33490-7c5b-6303-cfbf-1c10033c7b97"), "North Dakota", "West Keonshire", "Germany", new DateTime(2024, 5, 6, 9, 4, 10, 354, DateTimeKind.Local).AddTicks(1572), "Kadin34@gmail.com", null, null, new Guid("30c8b8a3-976b-d777-cf16-d199e7f9d2e0"), "835 Aurelia Lock", "River", "Ohio", 2, 0, null, null, "39180-5508" },
                    { new Guid("4d828561-dc91-3f98-22c6-4d622993fcfc"), "Texas", "New Amalia", "Solomon Islands", new DateTime(2024, 10, 22, 5, 16, 42, 383, DateTimeKind.Local).AddTicks(3510), "Betty21@gmail.com", null, null, new Guid("294e20d4-c8c1-aa0b-7d9c-cd721760188f"), "9162 Terry Plains", "Coves", "Florida", 1, 2, null, null, "38056-3141" },
                    { new Guid("5e570d10-3f6d-abcd-b496-771ccfdd9296"), "California", "New Aurorestad", "Gabon", new DateTime(2024, 7, 10, 19, 44, 4, 626, DateTimeKind.Local).AddTicks(2397), "Davion_Abbott12@gmail.com", null, null, new Guid("62d0d82c-0294-20f4-9663-7a0f458d660e"), "6769 Waters Meadow", "Port", "Oregon", 0, 1, null, null, "29559" },
                    { new Guid("64d65cdb-cb5b-7c3b-55eb-3326df642b51"), "Oklahoma", "East Nels", "American Samoa", new DateTime(2024, 4, 26, 19, 55, 33, 287, DateTimeKind.Local).AddTicks(4179), "Pietro.Reinger@hotmail.com", null, null, new Guid("d3d07c4d-dd4b-abde-5a7e-eae2584e9d78"), "4131 Kyler Springs", "Unions", "New Mexico", 1, 2, null, null, "40415-9471" },
                    { new Guid("69862cb1-f62c-b41e-ccf2-c91a12925833"), "Connecticut", "Meaghanberg", "Liberia", new DateTime(2024, 4, 13, 17, 34, 0, 689, DateTimeKind.Local).AddTicks(7772), "Erika71@hotmail.com", null, null, new Guid("0d17e661-d836-c25c-2456-f17b862a3d01"), "5970 Wilhelm Prairie", "Viaduct", "Minnesota", 2, 0, null, null, "73777" },
                    { new Guid("720b1415-9087-a6c4-3d07-053f66cabe8b"), "Alabama", "South Hyman", "Netherlands", new DateTime(2024, 6, 24, 6, 47, 38, 737, DateTimeKind.Local).AddTicks(6437), "Coy_Flatley75@hotmail.com", null, null, new Guid("ccbff4b7-52e0-ced8-370a-01db243842f1"), "99452 Ewald Flat", "Springs", "Minnesota", 0, 1, null, null, "62193" },
                    { new Guid("78856236-d502-5641-f37a-ed3e1c619a70"), "Montana", "Hauckmouth", "Virgin Islands, U.S.", new DateTime(2024, 9, 20, 0, 46, 23, 728, DateTimeKind.Local).AddTicks(6667), "Jalon.Koelpin20@hotmail.com", null, null, new Guid("30844130-07e2-128c-bba7-aca73829426e"), "39757 Bosco Junctions", "Crest", "North Carolina", 0, 2, null, null, "88655-4263" },
                    { new Guid("7b5571a3-88f8-b1a5-7a0e-a031f578ca2e"), "Wyoming", "Legrosburgh", "Greenland", new DateTime(2023, 11, 29, 10, 32, 46, 233, DateTimeKind.Local).AddTicks(7267), "Eldridge.Ratke@yahoo.com", null, null, new Guid("88cad496-36fd-9900-c8ed-248e495242bb"), "04730 Chris Village", "Junctions", "Arkansas", 1, 1, null, null, "47609-3862" },
                    { new Guid("7d6bc2ca-37ff-7ca3-b544-48058aa66bbc"), "Iowa", "Jakubowskibury", "Antarctica (the territory South of 60 deg S)", new DateTime(2024, 6, 9, 19, 9, 59, 302, DateTimeKind.Local).AddTicks(4544), "Rick.OKeefe6@yahoo.com", null, null, new Guid("7dd3ec8d-a88b-0d28-15ea-d6c200b1483b"), "0345 Kenny Loop", "Corners", "Vermont", 0, 2, null, null, "91123-7784" },
                    { new Guid("8555cc5e-7c88-22ff-ac30-312c62cda54b"), "New Hampshire", "West Aleenchester", "Greenland", new DateTime(2024, 9, 17, 14, 6, 5, 754, DateTimeKind.Local).AddTicks(5775), "David.Murray@hotmail.com", null, null, new Guid("c011b317-5d6f-3991-c54a-6a976dd3a86d"), "485 Thiel Corner", "Shoal", "Colorado", 2, 2, null, null, "92763-7076" },
                    { new Guid("857c311b-1b46-7b05-ffa2-6323eeaa2d72"), "Louisiana", "North Isabelle", "Reunion", new DateTime(2024, 7, 11, 12, 16, 21, 841, DateTimeKind.Local).AddTicks(7340), "Justice.Dibbert85@yahoo.com", null, null, new Guid("62d0d82c-0294-20f4-9663-7a0f458d660e"), "792 Arlie Circles", "Road", "Connecticut", 0, 2, null, null, "89801" },
                    { new Guid("87fb04a5-c055-37e1-58c6-1b5cc1dd94ce"), "Alabama", "Jarodborough", "Guatemala", new DateTime(2024, 1, 23, 20, 25, 48, 472, DateTimeKind.Local).AddTicks(6526), "Jordan.Kunze@yahoo.com", null, null, new Guid("9df28012-cbda-1cd7-ac31-07858561e3cc"), "46517 Emiliano Causeway", "Viaduct", "Wyoming", 1, 1, null, null, "27139-9902" },
                    { new Guid("88735438-6ef8-7867-a633-8633c6ec55ad"), "Ohio", "Gladyceberg", "Nicaragua", new DateTime(2024, 4, 5, 17, 44, 24, 266, DateTimeKind.Local).AddTicks(5944), "Karl_Bode10@hotmail.com", null, null, new Guid("48552ea0-4a98-ecba-b856-56dc1988e993"), "63425 Lowe Underpass", "Trafficway", "Nevada", 0, 0, null, null, "95162-1783" },
                    { new Guid("8c25e791-d641-0838-b512-364de0580de2"), "South Dakota", "North Dedrick", "Cameroon", new DateTime(2023, 12, 2, 10, 49, 48, 691, DateTimeKind.Local).AddTicks(2319), "Nasir_Schneider20@yahoo.com", null, null, new Guid("30844130-07e2-128c-bba7-aca73829426e"), "3864 Jailyn Divide", "Motorway", "New Mexico", 2, 2, null, null, "95952" },
                    { new Guid("8d168caf-dfee-2f9c-8b0a-700f850fd2f4"), "Georgia", "New Kathlyn", "Christmas Island", new DateTime(2024, 9, 21, 3, 59, 13, 31, DateTimeKind.Local).AddTicks(9591), "Mozelle_Raynor@hotmail.com", null, null, new Guid("695dde12-e5a3-2648-7267-3f61de01cfa6"), "671 Breitenberg Circle", "Village", "South Dakota", 2, 0, null, null, "90991" },
                    { new Guid("9dc97ca0-fc7b-b947-26f2-41475c2715a7"), "North Carolina", "Corwinland", "Saint Kitts and Nevis", new DateTime(2023, 11, 28, 12, 15, 49, 245, DateTimeKind.Local).AddTicks(205), "Reyes.Mueller4@yahoo.com", null, null, new Guid("307c5dac-2762-6bf3-1361-9a890ad4c5d4"), "1117 Witting Stream", "Canyon", "Missouri", 1, 2, null, null, "77735-5180" },
                    { new Guid("a18c0dfc-515d-29cb-9443-0430b681b686"), "Alabama", "Pfannerstillburgh", "Zambia", new DateTime(2024, 5, 8, 13, 5, 0, 291, DateTimeKind.Local).AddTicks(9069), "Pat38@gmail.com", null, null, new Guid("872eec42-d214-7473-7fce-6aeb1d501d20"), "1713 Stoltenberg Park", "Inlet", "Hawaii", 2, 2, null, null, "38479-0746" },
                    { new Guid("a2928b5b-5125-838c-7b8d-9c7dbca7b11c"), "Montana", "West Nia", "French Guiana", new DateTime(2024, 3, 9, 23, 20, 43, 607, DateTimeKind.Local).AddTicks(657), "Bud_Gibson29@gmail.com", null, null, new Guid("2f3a9038-6f67-4225-78ea-c9f4c7a08e27"), "0010 Schaefer Knoll", "Lights", "Colorado", 2, 1, null, null, "86417" },
                    { new Guid("aa4edb3b-d0c9-8f8b-a63e-116063da0a8b"), "Ohio", "West Letitia", "Guyana", new DateTime(2024, 10, 16, 16, 33, 0, 693, DateTimeKind.Local).AddTicks(120), "Kirstin_Krajcik@hotmail.com", null, null, new Guid("43deb1d4-4415-f720-3f2c-03ef30dd8c6c"), "278 Lilla Port", "Trafficway", "South Dakota", 1, 1, null, null, "76119" },
                    { new Guid("beed6e8f-b349-1672-21b3-e2974d7dd89f"), "Michigan", "North Nikita", "Mauritania", new DateTime(2023, 12, 1, 5, 57, 17, 620, DateTimeKind.Local).AddTicks(1477), "Leonor.Stiedemann87@yahoo.com", null, null, new Guid("3310c368-05f6-f01d-7438-9efe65836460"), "80521 Leannon Brooks", "Viaduct", "New York", 0, 2, null, null, "78056" },
                    { new Guid("bfaad068-f761-d6ca-d96b-77acf3e57363"), "Michigan", "West Finnfurt", "Oman", new DateTime(2024, 3, 2, 3, 4, 18, 632, DateTimeKind.Local).AddTicks(2434), "Clemens72@gmail.com", null, null, new Guid("72c8c787-5835-083a-e2dc-ee8e687f6318"), "5844 Melyna Lake", "Course", "Arkansas", 2, 2, null, null, "24773-6473" },
                    { new Guid("bff49bdb-6f3d-c7c2-90dd-1d1cffeda649"), "Texas", "South Alycia", "Cameroon", new DateTime(2024, 8, 24, 7, 42, 33, 859, DateTimeKind.Local).AddTicks(9003), "Jaylin_Swift4@yahoo.com", null, null, new Guid("c011b317-5d6f-3991-c54a-6a976dd3a86d"), "51607 Crooks Cape", "Forks", "Minnesota", 1, 1, null, null, "17596" },
                    { new Guid("c18e0b45-4a88-0d70-f0c2-5305b195a7fc"), "Massachusetts", "South Genovevastad", "Togo", new DateTime(2024, 5, 16, 2, 17, 28, 960, DateTimeKind.Local).AddTicks(9049), "Samara_Morar84@yahoo.com", null, null, new Guid("0b21bd10-688f-4ec0-e638-1979292a7add"), "5731 Chanel Causeway", "Lakes", "Pennsylvania", 0, 1, null, null, "12239" },
                    { new Guid("cc009101-e984-3682-fb90-53f779858297"), "Texas", "Beierchester", "Lesotho", new DateTime(2024, 8, 20, 17, 17, 3, 132, DateTimeKind.Local).AddTicks(271), "Dawson_Corwin@gmail.com", null, null, new Guid("7b8f697e-8b95-b64f-37f1-36251a3011c6"), "013 Bettye Road", "Circles", "Louisiana", 0, 1, null, null, "47171" },
                    { new Guid("d09be264-875a-9c09-613c-8a1e655ad9be"), "New Mexico", "Lake Vidal", "Antigua and Barbuda", new DateTime(2024, 2, 7, 1, 56, 58, 137, DateTimeKind.Local).AddTicks(6018), "Ferne.Turcotte@gmail.com", null, null, new Guid("43deb1d4-4415-f720-3f2c-03ef30dd8c6c"), "518 Schmeler Pike", "Orchard", "Texas", 0, 0, null, null, "92872" },
                    { new Guid("d7d76045-dc17-60ef-ee9e-6897b146b34c"), "Alaska", "Melbabury", "Malaysia", new DateTime(2024, 4, 7, 20, 43, 28, 270, DateTimeKind.Local).AddTicks(9044), "Herbert6@yahoo.com", null, null, new Guid("43ba84be-87ad-549c-a4b7-d9ea965d02a2"), "9882 Rohan Valley", "Villages", "Michigan", 1, 1, null, null, "59608" },
                    { new Guid("d873b56d-c9fc-6c3d-6b80-de64f817659c"), "Nevada", "New Alfonzo", "Norway", new DateTime(2024, 8, 5, 7, 53, 49, 287, DateTimeKind.Local).AddTicks(6346), "Santina.Hilll48@hotmail.com", null, null, new Guid("419b2317-b782-ce59-68a6-422842e3f852"), "96687 Aliyah Squares", "Ports", "Nevada", 1, 1, null, null, "19167" },
                    { new Guid("e48831af-fcea-0b3e-a688-4df242dd6be3"), "Maryland", "New Lilliana", "Montenegro", new DateTime(2024, 3, 9, 4, 30, 59, 364, DateTimeKind.Local).AddTicks(4467), "Maria_Wolf@yahoo.com", null, null, new Guid("6fee3171-0e29-52c2-b5ab-d8ddb362e1b2"), "8292 Schiller Field", "Mill", "Nevada", 2, 1, null, null, "43573-9364" },
                    { new Guid("e666706b-ebab-e420-5c17-60f19c1368ee"), "Ohio", "Evansville", "Wallis and Futuna", new DateTime(2024, 7, 20, 10, 26, 5, 593, DateTimeKind.Local).AddTicks(2525), "Delia.Gottlieb@gmail.com", null, null, new Guid("af5ef91b-8d33-ce87-33bf-fdbf072f763e"), "5567 Crist Lane", "Plains", "Missouri", 2, 2, null, null, "85101-9810" },
                    { new Guid("e89b6fce-d667-76b2-f3bb-0501af9824eb"), "Alabama", "Romaguerachester", "Virgin Islands, U.S.", new DateTime(2024, 1, 20, 2, 52, 28, 175, DateTimeKind.Local).AddTicks(8308), "Maverick.OConnell94@hotmail.com", null, null, new Guid("7e1c366e-4eb0-1f19-a44d-7c810b3ef9bf"), "7649 Cole Pines", "Court", "Maine", 1, 0, null, null, "44318-1368" },
                    { new Guid("ee8b8f91-7d0f-e2da-47eb-a2df9b7df5bd"), "Georgia", "Gislasonburgh", "Netherlands Antilles", new DateTime(2024, 5, 2, 13, 19, 29, 731, DateTimeKind.Local).AddTicks(1304), "Loyce.Morissette92@gmail.com", null, null, new Guid("0b21bd10-688f-4ec0-e638-1979292a7add"), "308 Lou Glen", "Union", "North Carolina", 2, 0, null, null, "71803-6703" },
                    { new Guid("f021eca7-d7a3-9c83-3276-b2a09d2f3ad9"), "New York", "South Amya", "Egypt", new DateTime(2024, 10, 26, 1, 48, 43, 47, DateTimeKind.Local).AddTicks(839), "Sophie_Cronin96@hotmail.com", null, null, new Guid("419b2317-b782-ce59-68a6-422842e3f852"), "74475 Cummerata Lake", "Port", "Georgia", 2, 1, null, null, "50976" },
                    { new Guid("f517c751-4613-92f2-b3cc-81aa3bb79cba"), "Nevada", "North Andreston", "Hungary", new DateTime(2024, 10, 16, 12, 52, 0, 242, DateTimeKind.Local).AddTicks(8135), "Jazlyn.Gutkowski@yahoo.com", null, null, new Guid("5cf13df2-d817-4983-5095-c4684d896d9b"), "797 Roselyn Drive", "Lights", "Florida", 1, 1, null, null, "74632-6331" },
                    { new Guid("f53084a6-a032-e03b-8375-92206840c123"), "Kentucky", "Quinnhaven", "Jamaica", new DateTime(2024, 8, 16, 2, 43, 52, 20, DateTimeKind.Local).AddTicks(3423), "Maeve.Lemke64@hotmail.com", null, null, new Guid("d96b4e6c-0fb7-0083-4447-42c854eb15ac"), "751 Waino Squares", "Track", "Massachusetts", 0, 1, null, null, "82670-9686" },
                    { new Guid("fa3895ec-4b44-e6c4-32d9-7d5bda140c16"), "Oregon", "Adellaland", "Malaysia", new DateTime(2024, 2, 20, 7, 37, 22, 143, DateTimeKind.Local).AddTicks(216), "Isabel96@hotmail.com", null, null, new Guid("e3dbd453-ec9b-882d-b5b4-9e4f10e3d949"), "482 Boehm Shoal", "Highway", "Utah", 1, 1, null, null, "83730-3701" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EmployeeId", "IsPersonal", "IsPrimary", "Status", "Type", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { new Guid("0157d01e-b1a0-7d27-28ee-a4867c93e516"), new DateTime(2024, 4, 5, 11, 31, 1, 509, DateTimeKind.Local).AddTicks(3850), "Thad.Baumbach@gmail.com", null, null, new Guid("8e702aba-2dc1-f841-5865-d2b711ecd90c"), false, false, 1, 2, null, null, "Hildegard91@yahoo.com" },
                    { new Guid("04f1c453-97ad-9faa-22a4-1bc559c1c158"), new DateTime(2024, 4, 7, 22, 33, 12, 145, DateTimeKind.Local).AddTicks(7052), "Talia.Harber62@gmail.com", null, null, new Guid("68b29311-2e68-2a60-89ef-8dd36f712fb2"), false, false, 1, 2, null, null, "Drew.Funk55@hotmail.com" },
                    { new Guid("11cb3509-d9e5-66d3-e580-6a636955edad"), new DateTime(2024, 2, 14, 22, 2, 22, 144, DateTimeKind.Local).AddTicks(7281), "Justice_Hane@gmail.com", null, null, new Guid("ce21c3c8-4713-a3b4-1180-fb5e3c415996"), false, true, 0, 0, null, null, "1-913-276-4264 x17521" },
                    { new Guid("1710689e-a0c6-2451-a5c0-819f1eced0aa"), new DateTime(2024, 8, 8, 7, 51, 4, 87, DateTimeKind.Local).AddTicks(7470), "Patrick.Crooks@hotmail.com", null, null, new Guid("20a6143c-836a-afb7-c5d4-247987d71c4c"), false, true, 1, 1, null, null, "532-603-2202" },
                    { new Guid("18a77dd6-23c2-669d-a811-0bfacd6ee500"), new DateTime(2023, 12, 7, 11, 53, 27, 476, DateTimeKind.Local).AddTicks(4948), "Cale44@yahoo.com", null, null, new Guid("736b85fb-6fee-e8c7-d92c-3094e53719ce"), false, true, 0, 2, null, null, "Libby30@yahoo.com" },
                    { new Guid("1a3f3d84-d9b6-a5a5-7c2c-c772f4e9949f"), new DateTime(2024, 9, 27, 15, 9, 53, 646, DateTimeKind.Local).AddTicks(4861), "Tyler.Adams85@yahoo.com", null, null, new Guid("0d17e661-d836-c25c-2456-f17b862a3d01"), false, true, 0, 1, null, null, "1-319-878-1949 x547" },
                    { new Guid("1aae5d7a-ad22-e199-96a8-0dce2e5304f8"), new DateTime(2024, 2, 24, 21, 55, 25, 32, DateTimeKind.Local).AddTicks(7191), "Camden.Bogisich53@hotmail.com", null, null, new Guid("8d6390e3-7302-5507-e182-34322a1e1bbc"), false, false, 0, 0, null, null, "663-629-6554 x5392" },
                    { new Guid("1b1067cd-6b64-2892-2ab9-fa33581e766c"), new DateTime(2024, 10, 20, 8, 56, 58, 105, DateTimeKind.Local).AddTicks(1330), "Brenda22@yahoo.com", null, null, new Guid("5dc56630-1789-ab84-52e3-958d6ae69edf"), false, false, 1, 2, null, null, "Jennie68@hotmail.com" },
                    { new Guid("26f8a901-7531-399f-6f4d-39e2a08215b4"), new DateTime(2024, 7, 29, 11, 11, 58, 668, DateTimeKind.Local).AddTicks(5359), "Griffin30@gmail.com", null, null, new Guid("5dc56630-1789-ab84-52e3-958d6ae69edf"), true, false, 0, 1, null, null, "1-446-267-3742 x9109" },
                    { new Guid("2a74baa7-78b6-b534-348b-268de2da5ec2"), new DateTime(2024, 7, 26, 16, 52, 16, 43, DateTimeKind.Local).AddTicks(6441), "Dandre.Klocko10@hotmail.com", null, null, new Guid("145e184e-5e65-5348-b047-7728eaabeb1e"), false, false, 0, 1, null, null, "419.376.7600" },
                    { new Guid("2a7aa05b-502e-aeaa-dfac-c751fd9359dc"), new DateTime(2024, 1, 5, 18, 35, 45, 958, DateTimeKind.Local).AddTicks(3586), "Sonia28@gmail.com", null, null, new Guid("88cad496-36fd-9900-c8ed-248e495242bb"), false, true, 0, 1, null, null, "(892) 446-5969" },
                    { new Guid("2c46a896-30c3-a568-8186-541a34c15929"), new DateTime(2024, 3, 26, 18, 49, 7, 154, DateTimeKind.Local).AddTicks(7944), "Joany.Hintz73@yahoo.com", null, null, new Guid("2f3a9038-6f67-4225-78ea-c9f4c7a08e27"), true, true, 1, 2, null, null, "Raymundo.Flatley21@gmail.com" },
                    { new Guid("36049e1e-6737-5c7f-e91c-23e01aa21cb8"), new DateTime(2024, 6, 21, 1, 26, 29, 238, DateTimeKind.Local).AddTicks(5422), "Darren_Macejkovic36@gmail.com", null, null, new Guid("736b85fb-6fee-e8c7-d92c-3094e53719ce"), false, false, 0, 0, null, null, "(696) 778-7612" },
                    { new Guid("3c4b7a04-4715-3b24-1049-14ae8e1d51f8"), new DateTime(2024, 9, 25, 8, 21, 11, 166, DateTimeKind.Local).AddTicks(6428), "Shemar.MacGyver@gmail.com", null, null, new Guid("25822ac1-9c26-8f21-8fbb-86bd9d9c76f7"), false, true, 2, 2, null, null, "Abraham.Miller@yahoo.com" },
                    { new Guid("3f5210cb-8126-38ef-8307-2c51c21470e2"), new DateTime(2024, 7, 3, 1, 19, 12, 462, DateTimeKind.Local).AddTicks(5300), "Prince58@gmail.com", null, null, new Guid("d3d07c4d-dd4b-abde-5a7e-eae2584e9d78"), false, false, 2, 0, null, null, "(706) 708-8064" },
                    { new Guid("4ff2c285-84de-e963-a4bf-a66944771513"), new DateTime(2024, 7, 8, 13, 36, 14, 876, DateTimeKind.Local).AddTicks(6668), "Donavon.Buckridge@gmail.com", null, null, new Guid("2f3a9038-6f67-4225-78ea-c9f4c7a08e27"), false, true, 0, 2, null, null, "Spencer31@gmail.com" },
                    { new Guid("5021d3e8-b5e0-2d66-b143-8bccd35f6348"), new DateTime(2024, 5, 18, 18, 58, 35, 15, DateTimeKind.Local).AddTicks(8488), "Judson20@hotmail.com", null, null, new Guid("68b29311-2e68-2a60-89ef-8dd36f712fb2"), true, true, 1, 0, null, null, "(245) 650-4241" },
                    { new Guid("5219ac48-3af2-3e1c-417a-26d771f5cacf"), new DateTime(2024, 6, 30, 13, 44, 12, 323, DateTimeKind.Local).AddTicks(5362), "Lisandro.Reilly26@gmail.com", null, null, new Guid("be776de5-027a-3277-3ac3-0191c5282a06"), false, true, 0, 1, null, null, "711-464-8495" },
                    { new Guid("547ea1bd-a78a-e98c-21ac-d4bca6cbbe1c"), new DateTime(2024, 1, 15, 15, 32, 12, 787, DateTimeKind.Local).AddTicks(8323), "Helene30@gmail.com", null, null, new Guid("d3d07c4d-dd4b-abde-5a7e-eae2584e9d78"), false, false, 2, 1, null, null, "(748) 400-3075 x62283" },
                    { new Guid("5874a886-c8bb-1144-c75e-0365d11f0346"), new DateTime(2024, 7, 10, 15, 12, 28, 228, DateTimeKind.Local).AddTicks(5935), "Alfonzo.Bradtke21@gmail.com", null, null, new Guid("9df28012-cbda-1cd7-ac31-07858561e3cc"), false, false, 2, 2, null, null, "Ciara_Green46@yahoo.com" },
                    { new Guid("61448e07-27b8-442c-bc84-e88143766104"), new DateTime(2024, 3, 22, 11, 24, 56, 572, DateTimeKind.Local).AddTicks(3309), "Fatima67@hotmail.com", null, null, new Guid("42eb034d-9af8-8fe3-4e01-7a0ea900693c"), false, true, 0, 0, null, null, "1-448-697-7093" },
                    { new Guid("6462648b-18f1-1215-659a-351df3c4ebeb"), new DateTime(2024, 4, 28, 6, 14, 32, 903, DateTimeKind.Local).AddTicks(3910), "Jade.Mraz@hotmail.com", null, null, new Guid("294e20d4-c8c1-aa0b-7d9c-cd721760188f"), true, true, 1, 2, null, null, "Melyna_Halvorson9@yahoo.com" },
                    { new Guid("657d2b24-3b1e-5fba-ee4e-0bf2b119e894"), new DateTime(2024, 9, 16, 10, 37, 29, 182, DateTimeKind.Local).AddTicks(9001), "William54@hotmail.com", null, null, new Guid("7b8f697e-8b95-b64f-37f1-36251a3011c6"), false, false, 0, 0, null, null, "846.755.6693 x04799" },
                    { new Guid("67aab4ae-cc45-0954-47aa-a20d5ac38cd5"), new DateTime(2024, 5, 15, 3, 8, 4, 148, DateTimeKind.Local).AddTicks(9010), "Myron.Lynch@hotmail.com", null, null, new Guid("ed5b0d64-c6cf-6083-e3f9-d36e66073b50"), true, true, 1, 1, null, null, "1-258-620-7091" },
                    { new Guid("7f8c7b98-3911-8973-c59b-32844970f619"), new DateTime(2024, 8, 31, 16, 14, 44, 344, DateTimeKind.Local).AddTicks(4352), "Genevieve.Corkery40@yahoo.com", null, null, new Guid("ce21c3c8-4713-a3b4-1180-fb5e3c415996"), true, true, 1, 2, null, null, "Lysanne54@gmail.com" },
                    { new Guid("8a024036-a783-a638-103f-c3856fdf9467"), new DateTime(2024, 9, 17, 14, 38, 31, 616, DateTimeKind.Local).AddTicks(4340), "Hilbert_Goldner@yahoo.com", null, null, new Guid("5b09b81a-6567-a514-21a0-6722fc778cb1"), false, false, 0, 0, null, null, "214.451.2547" },
                    { new Guid("916a4345-93fe-e562-ae30-5a43ed413bb7"), new DateTime(2023, 12, 6, 18, 15, 24, 254, DateTimeKind.Local).AddTicks(747), "Tremayne_Kshlerin@yahoo.com", null, null, new Guid("ed5b0d64-c6cf-6083-e3f9-d36e66073b50"), true, false, 2, 0, null, null, "708-885-0677 x5364" },
                    { new Guid("92f36225-2ddd-c1f4-579f-b0dab41814de"), new DateTime(2023, 12, 31, 17, 22, 29, 299, DateTimeKind.Local).AddTicks(7692), "Darrell0@yahoo.com", null, null, new Guid("7e1ddb36-9271-dc63-287a-f177aa192aba"), false, false, 0, 0, null, null, "(545) 708-9626 x24311" },
                    { new Guid("951fa53d-2aa7-b862-ae43-49f65316fcc5"), new DateTime(2024, 8, 15, 19, 5, 49, 207, DateTimeKind.Local).AddTicks(3352), "Damaris_Robel@gmail.com", null, null, new Guid("307c5dac-2762-6bf3-1361-9a890ad4c5d4"), false, false, 0, 2, null, null, "Raheem.Osinski@gmail.com" },
                    { new Guid("956f22a6-b03e-a8eb-2c8b-35cc2d1e458f"), new DateTime(2024, 3, 18, 9, 33, 5, 468, DateTimeKind.Local).AddTicks(5269), "Naomi51@yahoo.com", null, null, new Guid("d3d07c4d-dd4b-abde-5a7e-eae2584e9d78"), false, true, 0, 0, null, null, "272-926-0484" },
                    { new Guid("95c131cb-b115-2b84-9c6f-01274886544f"), new DateTime(2023, 12, 28, 21, 23, 6, 818, DateTimeKind.Local).AddTicks(1495), "Obie92@gmail.com", null, null, new Guid("30c8b8a3-976b-d777-cf16-d199e7f9d2e0"), true, false, 1, 1, null, null, "(853) 414-0306 x0291" },
                    { new Guid("a2e50ef2-dcc5-af5b-74ac-262cbaf25bef"), new DateTime(2024, 1, 4, 9, 7, 42, 109, DateTimeKind.Local).AddTicks(6805), "Dawn30@hotmail.com", null, null, new Guid("cbf414e1-4662-ef83-0407-b8c6b7bdb0ba"), true, false, 1, 1, null, null, "1-557-787-5302 x5912" },
                    { new Guid("ab8c2207-2dec-4c23-43bc-0b747299547d"), new DateTime(2024, 2, 2, 4, 5, 15, 156, DateTimeKind.Local).AddTicks(518), "Eloise_Zieme36@gmail.com", null, null, new Guid("42eb034d-9af8-8fe3-4e01-7a0ea900693c"), false, false, 0, 2, null, null, "Alford.Funk27@gmail.com" },
                    { new Guid("b0d6d262-528e-b5d0-e1d4-1ff5a0d60395"), new DateTime(2024, 8, 4, 12, 12, 38, 155, DateTimeKind.Local).AddTicks(5249), "Janis27@yahoo.com", null, null, new Guid("68b29311-2e68-2a60-89ef-8dd36f712fb2"), true, false, 2, 1, null, null, "1-836-476-5578 x0713" },
                    { new Guid("b28cf0de-12c9-bc99-e6d0-59e29e7144f0"), new DateTime(2024, 8, 11, 17, 39, 30, 521, DateTimeKind.Local).AddTicks(7774), "Hilma_Keebler@hotmail.com", null, null, new Guid("7e1c366e-4eb0-1f19-a44d-7c810b3ef9bf"), false, false, 2, 1, null, null, "487-801-1215" },
                    { new Guid("be1e3faf-8d22-a7fd-8fd8-e6726e378284"), new DateTime(2024, 2, 16, 21, 37, 33, 796, DateTimeKind.Local).AddTicks(6322), "Rodger.Stroman@hotmail.com", null, null, new Guid("cbf414e1-4662-ef83-0407-b8c6b7bdb0ba"), false, false, 1, 0, null, null, "1-818-746-6942 x1235" },
                    { new Guid("bfaccda0-7fa4-d326-ca73-dd3ad2c2eb1c"), new DateTime(2024, 6, 28, 7, 6, 21, 511, DateTimeKind.Local).AddTicks(7840), "Brandon_Barton@yahoo.com", null, null, new Guid("44a9dc86-3cb2-d1b0-9eac-ab8ece7a464a"), false, true, 2, 0, null, null, "1-877-230-2870" },
                    { new Guid("c428e905-282e-4d13-1147-a693d0c7cde2"), new DateTime(2024, 3, 15, 13, 23, 31, 863, DateTimeKind.Local).AddTicks(5917), "Mallie_Johnston@yahoo.com", null, null, new Guid("d96b4e6c-0fb7-0083-4447-42c854eb15ac"), false, false, 0, 1, null, null, "1-563-573-2393 x15035" },
                    { new Guid("cb4e9f43-55bb-ca2f-071b-5a9142219359"), new DateTime(2024, 11, 15, 22, 24, 0, 726, DateTimeKind.Local).AddTicks(788), "Waylon29@yahoo.com", null, null, new Guid("3310c368-05f6-f01d-7438-9efe65836460"), true, false, 1, 2, null, null, "Arturo6@gmail.com" },
                    { new Guid("cd53fb95-0c5c-2aa5-c7b4-51dd07bbe267"), new DateTime(2024, 1, 1, 17, 15, 5, 902, DateTimeKind.Local).AddTicks(5782), "Moses.Reichel@hotmail.com", null, null, new Guid("736b85fb-6fee-e8c7-d92c-3094e53719ce"), true, true, 1, 2, null, null, "Mekhi_Williamson91@yahoo.com" },
                    { new Guid("d83266b0-d2d2-7b7d-fe97-df1099777ba9"), new DateTime(2024, 9, 2, 21, 46, 59, 616, DateTimeKind.Local).AddTicks(4941), "Tracy_Von@yahoo.com", null, null, new Guid("307c5dac-2762-6bf3-1361-9a890ad4c5d4"), true, false, 1, 1, null, null, "558.568.5943" },
                    { new Guid("e7649c59-e345-ce6d-30ae-b3c3b9817bd0"), new DateTime(2024, 9, 9, 14, 33, 26, 618, DateTimeKind.Local).AddTicks(3493), "Burnice11@gmail.com", null, null, new Guid("b82f6da5-33b1-ade8-5c71-dac0d1be84ec"), true, false, 2, 1, null, null, "1-873-383-7963" },
                    { new Guid("ed86c55a-5e8b-d25b-b6f4-35475993770b"), new DateTime(2024, 1, 11, 17, 38, 52, 653, DateTimeKind.Local).AddTicks(7910), "Donny.Nienow@gmail.com", null, null, new Guid("95ca4941-dc2a-36f3-dfa0-10bdb9f2fdcd"), false, true, 2, 0, null, null, "(948) 700-6853 x425" },
                    { new Guid("f00a19cb-e579-74c2-cb8e-c8582814f0b4"), new DateTime(2024, 11, 4, 20, 26, 10, 212, DateTimeKind.Local).AddTicks(421), "Timothy_Goldner21@gmail.com", null, null, new Guid("729c8fec-6922-17a2-6263-45454815543c"), false, false, 2, 1, null, null, "(585) 725-7499 x5052" },
                    { new Guid("f448b425-43fd-e088-9f2d-44ee8d8e51a5"), new DateTime(2024, 4, 24, 8, 1, 20, 587, DateTimeKind.Local).AddTicks(9444), "Darby_Runte19@yahoo.com", null, null, new Guid("d96b4e6c-0fb7-0083-4447-42c854eb15ac"), false, false, 1, 2, null, null, "Alvina.Spinka@hotmail.com" },
                    { new Guid("f6176472-b76b-1a31-89ec-96b2f409c434"), new DateTime(2024, 1, 11, 16, 11, 23, 521, DateTimeKind.Local).AddTicks(9399), "Viola.Feil67@yahoo.com", null, null, new Guid("7e1c366e-4eb0-1f19-a44d-7c810b3ef9bf"), true, false, 2, 1, null, null, "951.288.1678" },
                    { new Guid("f8cf3722-a320-af8b-682e-4abf14e09ed6"), new DateTime(2024, 3, 19, 13, 34, 10, 309, DateTimeKind.Local).AddTicks(5979), "Leonora.Weissnat@hotmail.com", null, null, new Guid("5d4743b3-1de3-7cc8-f4a5-78d2f39fe741"), false, false, 0, 2, null, null, "Adan13@yahoo.com" },
                    { new Guid("f982574b-7c7a-1c94-9b02-f4a608df10cc"), new DateTime(2024, 11, 11, 3, 7, 17, 80, DateTimeKind.Local).AddTicks(161), "Alfreda.Ortiz62@hotmail.com", null, null, new Guid("145e184e-5e65-5348-b047-7728eaabeb1e"), true, true, 0, 2, null, null, "Virginia_Casper59@yahoo.com" },
                    { new Guid("f98eaca8-dcdf-2806-902a-4f6cfccf46b1"), new DateTime(2024, 7, 29, 9, 35, 13, 780, DateTimeKind.Local).AddTicks(2655), "Ignacio_Brown46@gmail.com", null, null, new Guid("20a6143c-836a-afb7-c5d4-247987d71c4c"), true, false, 2, 2, null, null, "Elissa_Schoen51@hotmail.com" },
                    { new Guid("fba0a754-6fc1-6824-ca6f-fa02c91847b4"), new DateTime(2024, 3, 14, 0, 49, 17, 460, DateTimeKind.Local).AddTicks(3619), "Domenic_Gottlieb76@yahoo.com", null, null, new Guid("4f076d09-44a1-7244-83dd-ecc0e1561ed8"), true, true, 2, 2, null, null, "Otto.Sawayn37@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EmployeeId",
                table: "Addresses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EmployeeId",
                table: "Contacts",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AddressVersions");

            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ContactVersions");

            migrationBuilder.DropTable(
                name: "EmployeeVersions");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
