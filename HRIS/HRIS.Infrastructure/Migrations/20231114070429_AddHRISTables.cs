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
                    { "ID_NUMBER_DIGIT", "SYSTEM", "7" },
                    { "ID_NUMBER_EMPLOYEE_PREFIX", "SYSTEM", "EMP" },
                    { "ID_NUMBER_FORMAT", "SYSTEM", "{0}-{1}-{2}" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "FirstName", "Gender", "LastName", "MiddleName", "Number", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("035bdee8-a73f-1794-90a1-9a8dd1d2ead2"), new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 11, 52, 24, 964, DateTimeKind.Local).AddTicks(3382), "Mason45@gmail.com", null, null, "Domenica", "Male", "Dickinson", "뚥랺겗←뭜埽獘娠뤊", "葎쌆༠攡㭏瓺쎞ﰯ궘", 1, null, null },
                    { new Guid("03c60d04-02da-cef3-f5bf-2ab06862cbab"), new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 13, 17, 39, 18, 845, DateTimeKind.Local).AddTicks(6754), "Claude.Schultz21@hotmail.com", null, null, "Israel", "Male", "Parker", "�휎䮊꨷ꛋ쾀儇冒鰯䃏", "㠆켃숽和䵰쓍揖톤", 1, null, null },
                    { new Guid("04be90bc-5e67-bea7-a5c5-2897c12d9a1f"), new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 17, 4, 48, 59, 679, DateTimeKind.Local).AddTicks(5478), "Fabiola_Bahringer@hotmail.com", null, null, "Oma", "Female", "Jerde", "ﬀ⋉�棇✃ॗ큢맜樖깉", "陌ꦯꑋ⫴킆Ⴁ앂꼿", 1, null, null },
                    { new Guid("053dc79b-c5de-6432-43af-7f57125715af"), new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 5, 3, 50, 22, 660, DateTimeKind.Local).AddTicks(448), "Lilliana_Schmidt1@yahoo.com", null, null, "Davion", "Female", "Botsford", "⬊⪿㴐潲쑇놰쒈ᵙ", "뢥紹ϔ❌➞ꠡꮲ㡋ꂲ", 0, null, null },
                    { new Guid("0c276161-8a0f-3e99-3319-0d427a760132"), new DateTime(2022, 12, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 27, 19, 51, 57, 528, DateTimeKind.Local).AddTicks(8845), "Joanne9@hotmail.com", null, null, "Riley", "Male", "Heathcote", "￾鹥돏ㅙ䯶쐊≿天堡", "侁실铡䎵懲寡汣﫩", 1, null, null },
                    { new Guid("0f679da9-bd95-c8fc-665e-8821d1caf576"), new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 4, 8, 30, 37, 363, DateTimeKind.Local).AddTicks(4308), "Selmer92@hotmail.com", null, null, "Kaitlin", "Female", "Ziemann", "꭫澫룼鱴宩ሺ煮⁐쭋", "㫗罐疗㿵ف黌캺䰸璝少", 1, null, null },
                    { new Guid("11f91228-b00e-721a-53cd-5cf3ce1bca96"), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 28, 8, 15, 51, 241, DateTimeKind.Local).AddTicks(8287), "Stacey_Lakin62@hotmail.com", null, null, "Dejuan", "Female", "Rutherford", "呼㭱ദꛩ艥㞓⁎툠檷", "㛴䙱夡惦贂쐆跋踻", 1, null, null },
                    { new Guid("1446547e-f9c4-dd0e-be04-c26d850c8a22"), new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 13, 11, 16, 56, 900, DateTimeKind.Local).AddTicks(4685), "Amparo66@hotmail.com", null, null, "Sigrid", "Male", "Lowe", "宭栀癠㳶堈ࡹ㗭蝄", "ߟ쥒꪿꯽ﺯ⨠䗚ꕸ慧껊", 0, null, null },
                    { new Guid("17d11798-8759-377d-3445-894abde44b2f"), new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 16, 21, 11, 51, 614, DateTimeKind.Local).AddTicks(7837), "Devon.Kub6@yahoo.com", null, null, "Freeman", "Male", "Towne", "酘袆ㅗ␘␡죿눸궕�", "�ᴞ㴷遌蠛黴ሓ", 2, null, null },
                    { new Guid("18cef689-80aa-1713-a86e-9df38e5488cb"), new DateTime(2023, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 8, 15, 12, 52, 380, DateTimeKind.Local).AddTicks(6623), "Autumn66@gmail.com", null, null, "Mireya", "Male", "Jenkins", "ᄞ縪톷㮆Ճ苵뎳믿嘙὞", "옘欧즰ꩲ肖ᖾ�ｲ껌빽", 1, null, null },
                    { new Guid("1b248e0c-6c97-e9d8-4765-b6ac6d7ab621"), new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 13, 2, 6, 58, 979, DateTimeKind.Local).AddTicks(8119), "Isidro_Howell0@yahoo.com", null, null, "Lora", "Male", "West", "쭒눘员峆炾᤺䌐낟鈢Ϳ", "睈⑥냻⌃㒀ꜝ㻈扬銜㉛", 2, null, null },
                    { new Guid("2192bc6d-0dc0-0d07-79e2-d01a1d5a3814"), new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 26, 15, 40, 16, 646, DateTimeKind.Local).AddTicks(2670), "Arnold.Waelchi21@yahoo.com", null, null, "Nichole", "Female", "Sipes", "暑灄颵酲両薌濕鮦쐍", "졊؝ק뜅窰렩﫥է᩾", 2, null, null },
                    { new Guid("224d3279-78b9-4b1c-4653-721ec307d25c"), new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 8, 18, 14, 58, 545, DateTimeKind.Local).AddTicks(823), "Dortha_Rohan43@yahoo.com", null, null, "Paul", "Female", "Miller", "꿶䶬࿔鳡ꊰ莤뚣䂛", "ꩳ遉پ˻킢採䌳徥聶匰", 0, null, null },
                    { new Guid("2504af6e-5051-6ed4-106b-f7a300a7a200"), new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 18, 23, 33, 8, 284, DateTimeKind.Local).AddTicks(9708), "Lilly.Skiles68@yahoo.com", null, null, "Leslie", "Male", "Mann", "鶙鱭⬿䯫媄僻掖䱨", "ݵꗰ凥鬒掜ㄾ`憸켔ﳮ", 0, null, null },
                    { new Guid("2584cbed-6871-583e-141f-b6a09d8a85d1"), new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 21, 17, 23, 38, 546, DateTimeKind.Local).AddTicks(6559), "Elwin3@yahoo.com", null, null, "Ryder", "Male", "Collier", "㤣㋢궓蚞ｵ苙ꬖ潬宼", "㘱଩蜢롱㇁ಉ傅䕍솩墧", 2, null, null },
                    { new Guid("2669835a-03d6-f4b1-0d5c-ce770d7d2511"), new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 5, 2, 31, 13, 329, DateTimeKind.Local).AddTicks(4648), "Jettie.Kling@yahoo.com", null, null, "Allie", "Male", "Conn", "㵒清젃䆱髽貛匁엧ꑒ", "疪普▯ﴋ䙧斶ᛃ�쿘", 0, null, null },
                    { new Guid("26cc107f-cb29-5943-9d22-c4bd14c55a0e"), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 30, 16, 44, 14, 889, DateTimeKind.Local).AddTicks(9384), "Emory97@yahoo.com", null, null, "Vaughn", "Male", "Heidenreich", "鿳䓠輗鼀儲⨪㴵쪪嶛賌", "ꄶ竐햴뱌亀勻둀䥺ޚ", 0, null, null },
                    { new Guid("2d75e257-5e3e-ec39-dd29-4c44bdbdb99a"), new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 5, 2, 17, 5, 846, DateTimeKind.Local).AddTicks(712), "Willy_Ullrich@yahoo.com", null, null, "Kendall", "Female", "Miller", "㷇뚅陓䔎䔪꽗ބ甽�Ἒ", "냁痯虳孍蒳骬⫠쬩", 2, null, null },
                    { new Guid("2e3c7085-4eaf-b05c-995c-d1674d4e7e74"), new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 29, 19, 58, 2, 628, DateTimeKind.Local).AddTicks(4362), "Emmalee_Rowe@gmail.com", null, null, "Jeff", "Male", "Kihn", "ᯝ뇶၈敕鄞뗌떟㞪⾨", "湲䍙ഺ쥞䑁Ꞃࣔ풸॥痯", 1, null, null },
                    { new Guid("2e7fd84f-089c-ebaa-c690-23e166d54ce5"), new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 19, 24, 16, 924, DateTimeKind.Local).AddTicks(4590), "Isaac72@yahoo.com", null, null, "Jeffrey", "Male", "Spinka", "榣䄰愭춏蛿닍र滠", "錰鱹풤䗂ꌹ䖢薊䌡ẫ珕", 0, null, null },
                    { new Guid("2eb48373-4a76-dbbc-50e2-9383eb7acc6f"), new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 3, 20, 4, 39, 224, DateTimeKind.Local).AddTicks(3400), "Allen8@yahoo.com", null, null, "Jackson", "Male", "Flatley", "㍴敘웜੽�鋔٤聓의", "ⵈ慂⺚�饝뻖舆ꖛ", 1, null, null },
                    { new Guid("308671a2-fa9a-0ef4-89e5-9fcbcf119b7f"), new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 17, 19, 21, 20, 173, DateTimeKind.Local).AddTicks(923), "Elmore.Frami95@yahoo.com", null, null, "Kristopher", "Female", "Yundt", "㍌痄蜓ꊿﲓ姉驞죸⹓", "ᬶ쿻匸蕴늷䡼ࢥ䵞", 2, null, null },
                    { new Guid("346cc8fe-d1de-4e05-f1d6-9278ee092474"), new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 20, 12, 8, 4, 916, DateTimeKind.Local).AddTicks(7975), "Rahul_Boyle@gmail.com", null, null, "Kellen", "Female", "Corkery", "ࢻᜀ븒鵻�솅䏂끍", "栛鳹﹢猉➥फ़螏欹霤", 1, null, null },
                    { new Guid("349eea88-5437-2753-3e02-af3e69c45195"), new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 27, 16, 22, 29, 222, DateTimeKind.Local).AddTicks(4561), "Ford.Ondricka59@gmail.com", null, null, "Korbin", "Male", "Ward", "쫥⹞㉴䶵샖膄畞내", "쳃鷔㯈ᦱ⮹浡ﱕ�", 1, null, null },
                    { new Guid("3975c660-ea26-c8eb-5ccd-3bdfb49bcc10"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 11, 3, 32, 29, 484, DateTimeKind.Local).AddTicks(988), "Maurice_Wolff@hotmail.com", null, null, "Luther", "Female", "Schamberger", "ә砺㋟ﱀ穉焌ꄽ쐇毒", "郎뵡቙硏옕噞磆酽", 1, null, null },
                    { new Guid("3a17ed9c-56e7-8d61-0828-167ac498ce52"), new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 2, 33, 51, 758, DateTimeKind.Local).AddTicks(209), "Imelda99@hotmail.com", null, null, "Cora", "Female", "Gorczany", "끷٤끌∰⽰䫇脗ﳶ", "킿쯑鿔ﴙ䃕晫వ鈽㷐", 1, null, null },
                    { new Guid("3fb8a640-25f2-69c8-bffa-74ab9e5b1cea"), new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 1, 13, 53, 32, 685, DateTimeKind.Local).AddTicks(5553), "Oral.Jast28@hotmail.com", null, null, "Isaiah", "Male", "Gislason", "쟑੿坐㲪杢₏쯨桄緡", "੕綄좗뇟岭ⷂᰥ谺", 1, null, null },
                    { new Guid("3fe6dfe5-8f91-b494-40f4-acf60a52a7fb"), new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 24, 1, 38, 38, 30, DateTimeKind.Local).AddTicks(159), "Hazle10@hotmail.com", null, null, "Freeda", "Male", "Hoppe", "궟䣚솦辘砶⭩航ὲ", "撲婦濾绍懒㙂達㑐", 2, null, null },
                    { new Guid("409d249a-43f6-f154-d137-1d65585f4d02"), new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 8, 0, 34, 16, 227, DateTimeKind.Local).AddTicks(6347), "Chauncey28@hotmail.com", null, null, "Theodora", "Female", "Cormier", "ۿ桥ᚙ낲䮖㼼蕳˷퓹ṫ", "䕝㿁唺�쯰틆鷓휟䦵", 2, null, null },
                    { new Guid("410417ab-e4fc-a13f-65dd-430d20182ca0"), new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 24, 16, 53, 29, 318, DateTimeKind.Local).AddTicks(5361), "Esperanza57@gmail.com", null, null, "Mallie", "Male", "Zieme", "歫₽̌헍쫉鞱헪絆맲", "⾨Ɦ䇖餗쳑䎔ᦺ袌", 0, null, null },
                    { new Guid("41bd02d9-4687-5ad8-d7d2-673be0a44e68"), new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 14, 15, 29, 42, 937, DateTimeKind.Local).AddTicks(524), "Kiel64@yahoo.com", null, null, "Darien", "Male", "Moore", "䔐ᗰ㟜ꄏ뒇漤⥙⡊", "싏ꨋꝷ彲᣸㯤桌虨媹蜐", 1, null, null },
                    { new Guid("43d6010a-5fd8-0b17-f092-b4427bef760d"), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 6, 18, 50, 35, 277, DateTimeKind.Local).AddTicks(5278), "Constance.Jerde82@hotmail.com", null, null, "Evert", "Male", "Kuhn", "딉⢡⦇溝䐐ᮚ睱냩輳啀", "⠎來膾ự␧㮉鄥墚", 0, null, null },
                    { new Guid("44bb380a-3c2a-481b-e4ce-41fcb615524c"), new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 31, 18, 53, 40, 329, DateTimeKind.Local).AddTicks(4485), "Kraig14@hotmail.com", null, null, "Anna", "Male", "Emard", "�疐罤슍뜽邉�닗ꋏ枸", "쀓ꖁ⍆莪甤構྿뫛書뾚", 2, null, null },
                    { new Guid("499b8f8d-af64-cfb2-72d0-8eca8a68a932"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 6, 7, 17, 24, 491, DateTimeKind.Local).AddTicks(1727), "Percy21@yahoo.com", null, null, "Carrie", "Male", "Schultz", "道佯㯕의匁穧䈁ꝿ", "놏滴잯��䅄趗䅍儣", 1, null, null },
                    { new Guid("4d5e1801-d086-e38e-572a-44ca8a69ab4e"), new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 6, 19, 20, 9, 316, DateTimeKind.Local).AddTicks(4912), "Michele66@yahoo.com", null, null, "Candelario", "Male", "Marvin", "₂㖸Ⓖ阐ﱎ�벩뗍", "฽侤둕䰎䅅븿쯼㳝ㄲ", 2, null, null },
                    { new Guid("4eb0a9bb-3171-9dc3-e09f-6a421c3bb867"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 9, 9, 6, 0, 172, DateTimeKind.Local).AddTicks(2636), "Marta54@hotmail.com", null, null, "Kimberly", "Female", "Mraz", "锗齃�ᵓ墘꺂҆퍤㛈", "ᒁ鉏囒颳冯쮅嘷㭻", 1, null, null },
                    { new Guid("4f9cfd74-ecdd-d308-87be-f45420df42ee"), new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 17, 18, 5, 35, 269, DateTimeKind.Local).AddTicks(6451), "Aryanna87@hotmail.com", null, null, "Darion", "Female", "Hermann", "묧┈㧬뱉�燸", "ଔ睬얒咾炅䉐箕델㙤宐", 2, null, null },
                    { new Guid("50c5b7f3-412f-a49f-67d8-bc0f7eb83405"), new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 22, 3, 10, 10, 798, DateTimeKind.Local).AddTicks(9667), "Julio_Feest@hotmail.com", null, null, "William", "Female", "Kirlin", "䧢屠ᪿ苫ᎋม�釧㴟", "㥭굦ﶫꞰ�坌糔㰶僤", 0, null, null },
                    { new Guid("551bb687-b4e0-994f-11cb-08db893ce5fa"), new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 14, 0, 21, 10, 858, DateTimeKind.Local).AddTicks(854), "Enola_Grimes@hotmail.com", null, null, "Wilhelm", "Female", "Kling", "琙곚砓⸨駊㣮콳杬쳳", "ᕻ皜ਗ樻禼塖龜撷뫇鍚", 1, null, null },
                    { new Guid("5528e14c-5d16-fb9b-b6a2-0f36e3bfa1ab"), new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 17, 0, 22, 47, 970, DateTimeKind.Local).AddTicks(9106), "Neoma9@gmail.com", null, null, "Ramon", "Female", "Reilly", "밖瞭輅貲튋ꢏ읍ゾߊ呔", "˞ὺ�ꔚㄖ蝊ィ⹲䔋뱦", 0, null, null },
                    { new Guid("593e6613-25af-1ead-e666-c5dc66e349c6"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 29, 20, 44, 34, 894, DateTimeKind.Local).AddTicks(6309), "Cordelia48@yahoo.com", null, null, "Julianne", "Female", "Batz", "⒆\r㧓厕㮫ⴙꟅ䣈㌂", "㑀ꉝ╽嚁첼↵쪻ዂ陉", 1, null, null },
                    { new Guid("5b74522c-fc1f-b817-e331-b77cec596e6b"), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 12, 20, 7, 20, 263, DateTimeKind.Local).AddTicks(4630), "Bethel62@hotmail.com", null, null, "Chet", "Female", "Weber", "冒䝢⃵ᶋ౳ꑆ熟覧響봌", "櫣䨜벒᫶悻⧩曆盙授", 0, null, null },
                    { new Guid("5eaac6e9-434d-12fa-4845-1189bf5448ee"), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 22, 14, 44, 42, 883, DateTimeKind.Local).AddTicks(7897), "Golden.OKon@gmail.com", null, null, "Arianna", "Male", "Pouros", "貿Ἢﳟ燂멡蛾ᛲ骍纮⠨", "́嘻㛙騗굓团슧�", 1, null, null },
                    { new Guid("5eb8b7f4-9f0f-3cac-ace9-9b7b1f171445"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 22, 16, 31, 54, 499, DateTimeKind.Local).AddTicks(5473), "Benedict35@hotmail.com", null, null, "Carlotta", "Female", "Armstrong", "냾컡伮敳뫩㓺쒁럵ᯮ魷", "枴瀛ᙾ罝鵂㖳䪇∹", 0, null, null },
                    { new Guid("65d39f80-bae5-3ae5-eece-5e4c4f53b7d6"), new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 10, 13, 57, 36, 645, DateTimeKind.Local).AddTicks(8009), "Nova.Zieme@hotmail.com", null, null, "Tressie", "Female", "Murphy", "甫Ⱖヂ뤜ᣮ佑圉昦輽읲", "㫎껌詨鉭귂袕ᓒ쪔�", 0, null, null },
                    { new Guid("65ea95f2-e001-b149-580f-a7d830bc6515"), new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 21, 14, 17, 42, 964, DateTimeKind.Local).AddTicks(1765), "Jon.Bosco@yahoo.com", null, null, "Markus", "Male", "Glover", "蔧栍䉫�쀐횢蛏쐵냍쎰", "䡁﮲ꟹ䖴릪㵯⮧ಯ暝", 2, null, null },
                    { new Guid("6901692c-d46f-69ad-b86b-47f0abca0b0e"), new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 14, 18, 45, 12, 21, DateTimeKind.Local).AddTicks(9971), "Effie_Reynolds@hotmail.com", null, null, "Elmira", "Female", "Pollich", "珩쬰諘䧈㴉�ꑊ", "몗��ꗍ⌓ᢸ銞堫餚", 1, null, null },
                    { new Guid("6b9c96f9-81b0-7504-d589-100d74f7bd88"), new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 29, 9, 48, 12, 554, DateTimeKind.Local).AddTicks(8289), "Maurine_Littel@hotmail.com", null, null, "Percy", "Female", "Adams", "慖㙩롐薗죓ɤ꟩븤", "뮳නᅰ룣ⳛ菤", 0, null, null },
                    { new Guid("6d66ed26-eab9-c9e7-6ccf-a67860c419f5"), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 26, 11, 33, 26, 83, DateTimeKind.Local).AddTicks(573), "Eulah.Hills90@hotmail.com", null, null, "Brice", "Female", "Rice", "讽놬ˣዯ櫔灙趒쾎Ȏⷬ", "爻큪朸謁䜊璳밦✻㸺⍧", 0, null, null },
                    { new Guid("6e61c6a6-d4d3-c1eb-ec42-b673ffb13a78"), new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 21, 6, 17, 40, 238, DateTimeKind.Local).AddTicks(1392), "Bernie_Hickle87@gmail.com", null, null, "Rigoberto", "Female", "Bartoletti", "凳꾱싃郿І摐�㔹㗟", "臿繱ꮟ愅〵꽜駇诫ꢙ", 2, null, null },
                    { new Guid("6fb841a4-5aaf-bb02-8eca-96d9bcba8018"), new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 14, 15, 29, 42, 29, DateTimeKind.Local).AddTicks(9093), "Grant.Schimmel@gmail.com", null, null, "Dee", "Female", "Nader", "憋窽惿쉞㍶濈潙猱픒䏶", "湒詜ꇕퟺ읢﯁䗡荾῔襨", 2, null, null },
                    { new Guid("7026b9b5-7571-ff0b-6a2e-bd92c47a6e22"), new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 8, 18, 23, 5, 258, DateTimeKind.Local).AddTicks(9942), "Austen_Mitchell@hotmail.com", null, null, "Donna", "Female", "Mosciski", "皕쪛麓㶈ǳ톕Ῥꁹ", "ᷗ趼冷䯷册蹡ⷫ惧", 0, null, null },
                    { new Guid("76414830-9e37-394c-117b-7e73d8381cee"), new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 11, 11, 58, 1, 527, DateTimeKind.Local).AddTicks(3575), "Dovie.Monahan@gmail.com", null, null, "Mitchel", "Female", "Gleichner", "뷅죂팎槈ؑ㬢悽嚁Ჴ濖", "ꣀ픮吹趍畔螯苊수ﰴ", 2, null, null },
                    { new Guid("770f79bc-f690-489d-442a-bf84f8e42385"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 27, 2, 38, 44, 834, DateTimeKind.Local).AddTicks(4668), "Aubree57@yahoo.com", null, null, "Murray", "Female", "Mitchell", "陞逮ុফ䔩娥捌ಥڂ憡", "ᥒ软請깵∸읎⟹嬖㯤", 2, null, null },
                    { new Guid("8242dfbf-54de-73bd-ee70-0311a7f19389"), new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 9, 12, 58, 33, 789, DateTimeKind.Local).AddTicks(5911), "Gabrielle9@yahoo.com", null, null, "Alfred", "Female", "Medhurst", "遃냭멊⛤딸ᅢ䠉㮛粔", "ੱᬀ㟚賒�獂䌙㱝敓", 2, null, null },
                    { new Guid("852e96d6-4288-2ab2-0325-dc405877d86f"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 10, 33, 29, 442, DateTimeKind.Local).AddTicks(5134), "Flavie.Beier@hotmail.com", null, null, "Eleanore", "Male", "Marquardt", "䌙猩글ẳṠ畎⯲�ﱽ뱉", "დ쬞臻(繒熆७铩잩ⰵ", 0, null, null },
                    { new Guid("8588d8f0-779c-a630-8144-107196683255"), new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 14, 5, 29, 57, 113, DateTimeKind.Local).AddTicks(5113), "Carlee20@hotmail.com", null, null, "Brooklyn", "Male", "Lang", "旗쏟䃕苼閨瑚쁇폳꿎ힵ", "컡ഋ嵔磧褢ଗ鉮읯䔧긞", 2, null, null },
                    { new Guid("8d92ee06-e2c5-1e4b-e217-0fb5dbe2ec2d"), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 25, 19, 32, 8, 501, DateTimeKind.Local).AddTicks(4292), "Rubie.Fisher65@yahoo.com", null, null, "Maggie", "Male", "Trantow", "ヴ듓㞞˯歿᫜죕贫譃콻", "ಘᒼ램℥녜駩꙽ꆑ", 0, null, null },
                    { new Guid("8dcc20a0-904f-a057-0c5b-daae06cc0f43"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 17, 1, 22, 9, 949, DateTimeKind.Local).AddTicks(4095), "Christine_Leffler50@hotmail.com", null, null, "Cullen", "Male", "Grimes", "痉멃ｹ湄자乂쳓߅ꇀ㍑", "誰瓺檱῝㯗孯ꐇ", 2, null, null },
                    { new Guid("9293e9dd-dd72-d2a9-585e-b51a2ba0bfcb"), new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 5, 1, 26, 51, 804, DateTimeKind.Local).AddTicks(6242), "Skye.Parisian@yahoo.com", null, null, "Andy", "Male", "Renner", "隧✫죉聭뀋ↀনዬ沏", "栗ᯭʶ☭ᢃ㬜ᙎ✸悭", 1, null, null },
                    { new Guid("950918e1-6ab7-4c50-f7e3-5880bdd2828c"), new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 27, 16, 31, 2, 787, DateTimeKind.Local).AddTicks(1759), "Enid89@gmail.com", null, null, "Stanford", "Male", "Kling", "蒊썓袾跁℔熆瘷띫", "髃⦟윯�瓉ᥨ㞞ᣊ䗽", 2, null, null },
                    { new Guid("95cbf859-e28b-ad5c-2a79-f04c6c3ef4e8"), new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 1, 8, 38, 51, 666, DateTimeKind.Local).AddTicks(5133), "Alvina65@hotmail.com", null, null, "Colleen", "Female", "Jacobson", "퀭鴃㤸迢ᒂ峿師벏灣䈯", "⩥暽⩖퐎☙ꌆꫝኊ", 2, null, null },
                    { new Guid("95dcb80a-17c0-93bb-a54f-3dfb9778057d"), new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 16, 6, 6, 25, 925, DateTimeKind.Local).AddTicks(3965), "Ola.Labadie@hotmail.com", null, null, "Marcia", "Female", "Swift", "酫䧼컏㈯눁蚾鑙흝늌羳", "ᶻ竀奎ᇰ袯맇룫圄", 0, null, null },
                    { new Guid("9b9180e4-da1d-c1f2-4371-f19ec7aabe44"), new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 5, 9, 53, 19, 595, DateTimeKind.Local).AddTicks(8314), "Pasquale99@gmail.com", null, null, "Astrid", "Female", "Graham", "䝻ሂ뛵䬕콉䙋䕋櫌滽", "ꠓ�ꫧ鐄뒤魄眘金", 1, null, null },
                    { new Guid("9d04d428-af16-1ed6-c95d-db76ed6d033c"), new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 3, 18, 22, 3, 43, DateTimeKind.Local).AddTicks(3861), "Vallie_Bahringer@gmail.com", null, null, "Buster", "Male", "Altenwerth", "弬鿹載靜軋넎誗承蠐", "麢Ƃ核쿴ⷖ⯜≱崚ꐳ", 1, null, null },
                    { new Guid("9d6e5ef4-bf0e-49b7-7e1c-34851eb8b19d"), new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 30, 3, 12, 58, 277, DateTimeKind.Local).AddTicks(9017), "Tyree_Stracke@gmail.com", null, null, "Kailee", "Female", "Thompson", "若⚙羄⅊፡┻澂번ꨢ", "ӎ歠஖ퟨ쿀꽈弧뇫疙", 2, null, null },
                    { new Guid("a01f102b-2ddd-db7a-afec-5f932cbfc9ba"), new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 28, 18, 3, 55, 853, DateTimeKind.Local).AddTicks(4818), "Mia39@hotmail.com", null, null, "Rylan", "Male", "Prosacco", "◹⬽骙ᕋ呏䞷㸞殗➅", "膰䴲ᨬȨ鏀Ⳋ꤇䬸滺婜", 0, null, null },
                    { new Guid("ad15bbc0-2cad-fd78-f122-6ac50a0678ff"), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 2, 7, 33, 27, 514, DateTimeKind.Local).AddTicks(4937), "Damaris.Welch@hotmail.com", null, null, "Dorris", "Male", "Conroy", "ꓷ禵Щꈧ귥�땁㸟횿䛋", "㫁残閱┮턃Ⴡ䕔齱刡", 0, null, null },
                    { new Guid("ae16a6cd-9e72-6e98-e378-4d8a6c2874d9"), new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 29, 9, 45, 57, 660, DateTimeKind.Local).AddTicks(523), "Mittie_Block@hotmail.com", null, null, "Sebastian", "Female", "Gibson", "⍌쀏溠艰ͳ쏚赆봋", "ᔧ呪䙝甠綒쒗剥鐙롍", 0, null, null },
                    { new Guid("b36013bd-fa55-bd94-d0a7-c686ed2ece57"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 19, 5, 37, 30, 200, DateTimeKind.Local).AddTicks(6270), "Ollie.Aufderhar6@yahoo.com", null, null, "Yasmin", "Female", "Davis", "ꨛꃾ⓻갾꜔㴌ꜭ䀙懽鲶", "왡�ﮜ춁怢੪槡돧銆", 0, null, null },
                    { new Guid("b78896af-c55d-5a4c-1c70-962f6bc1eee3"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 21, 23, 10, 2, 656, DateTimeKind.Local).AddTicks(1314), "Jerrell37@hotmail.com", null, null, "Ludie", "Male", "Rippin", "ᾴ頰珮ཱུ冂咭뙺⦻", "ꝉ�ꈳ鰣똸튀ಓ䴯浇一", 2, null, null },
                    { new Guid("b7ef2f8a-39cf-ca87-b3fe-e96903917c85"), new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 22, 21, 19, 30, 153, DateTimeKind.Local).AddTicks(6082), "Hertha65@yahoo.com", null, null, "Esta", "Male", "Medhurst", "竾䙪Ⲭꤴ郦∜욝", "﵀닦᝛䂣䨍慿隡衭乧孑", 1, null, null },
                    { new Guid("bab1c9c8-bb8e-df3c-1477-5bb1e4f9110c"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 8, 31, 16, 733, DateTimeKind.Local).AddTicks(8288), "Afton78@gmail.com", null, null, "Dannie", "Male", "Ernser", "ﲴ類_䖠簈㯒咈㤥⟢㰒", "圷鴊䮩蹳撜ẁ鳪폧臄錕", 0, null, null },
                    { new Guid("bfd6e006-17a3-56c6-4d31-90b73406c200"), new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 8, 7, 10, 43, 97, DateTimeKind.Local).AddTicks(1537), "Kaden.Osinski@hotmail.com", null, null, "Madie", "Male", "Smith", "쯸㥵㣂㡮擰쌾㻴뽜", "䙔﷙倗먛〘ꭀ䌾鮙腛", 1, null, null },
                    { new Guid("c2325de0-dfda-8f60-82bf-ba440acdb13e"), new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 23, 21, 47, 8, 594, DateTimeKind.Local).AddTicks(5919), "Britney11@gmail.com", null, null, "Wellington", "Male", "Yost", "ꐖ⪓㳥ϳ冾ϗⲦチ岽൬", "紜쒆霅봬츩懌뀫縦", 0, null, null },
                    { new Guid("c45b975c-f3a6-1f0a-ff8c-bbc5a5191300"), new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 30, 14, 0, 22, 352, DateTimeKind.Local).AddTicks(3804), "Lavina_Klocko@gmail.com", null, null, "Bryon", "Female", "Smitham", "恜轎잚⋮�綁잭ቨ", "㱸봆Գᑹ䍓褔㘡鷎", 2, null, null },
                    { new Guid("c9c0909d-96a4-fe1a-0a56-c27d0e9cf5ad"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 14, 10, 50, 7, 977, DateTimeKind.Local).AddTicks(9395), "Alvena_Cummings@yahoo.com", null, null, "Brigitte", "Female", "Schuppe", "윭겛ꉴ醎躳ዷ䀎㌄茆", "픅顠�꾫ᦜ䖺Ձ싨݁깛", 2, null, null },
                    { new Guid("d0e77273-c3cf-cbbc-3871-b792ef3db7e8"), new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 13, 4, 42, 2, 342, DateTimeKind.Local).AddTicks(7564), "Tremayne_Blick@hotmail.com", null, null, "Everett", "Female", "Schmitt", "ꒅ⾇ꙫ｢큀⁷ﰵ老乏", "돆ᾎ니谷冨⠐�籙찕풉", 1, null, null },
                    { new Guid("d43e2ace-e91f-4994-1c2d-176cb7f66e0b"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 21, 21, 13, 56, 633, DateTimeKind.Local).AddTicks(5051), "Magnolia.Bernhard@gmail.com", null, null, "Amparo", "Male", "Lehner", "�纡相⸕⠻찈珘Ⲙ븝", "̔�㘻䶔漉䊋땎﵅䬃ꘊ", 2, null, null },
                    { new Guid("d5e6d946-91a8-0c4b-b149-6f1d42c6634d"), new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 19, 4, 25, 3, 268, DateTimeKind.Local).AddTicks(7885), "Murl.Koss@gmail.com", null, null, "Meggie", "Male", "Skiles", "㰇꽝虴⨤흮遏┥᥵蹶�", "愜᷎ﾆ䰩㫓៧䤞趠Ꭹ", 2, null, null },
                    { new Guid("d63eafff-7a89-d600-d7ba-6a3c2c961778"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 4, 13, 36, 57, 907, DateTimeKind.Local).AddTicks(9332), "Wilburn.Turner40@gmail.com", null, null, "Magdalena", "Female", "Mraz", "ܩ�弛褞⪪偲枷諦ꝼ", "᠁뜓�ﳅꨦࡐ뼲蹳쉍", 0, null, null },
                    { new Guid("d92bcf1a-868d-431d-d960-13fc1dfd90c6"), new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 5, 19, 2, 2, 798, DateTimeKind.Local).AddTicks(4333), "Grant_Predovic@gmail.com", null, null, "Landen", "Female", "Armstrong", "푹�䝆싦娃뇥殚씨", "螬℟纜稓䛜㹬쒒暋", 2, null, null },
                    { new Guid("dbeb65a9-fe8a-e4a3-00fb-2689a27ec138"), new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 3, 1, 6, 59, 862, DateTimeKind.Local).AddTicks(2037), "Hershel40@hotmail.com", null, null, "Micheal", "Female", "Rodriguez", "㈽곽軷�믰먴㣮҆⒩＜", "콚ᮁ嫕ሗ띶뫵᤼诸㳟", 2, null, null },
                    { new Guid("e2159279-75dd-73b8-c220-d75a782ca63c"), new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 25, 17, 50, 9, 251, DateTimeKind.Local).AddTicks(3369), "Madison.Hermiston2@hotmail.com", null, null, "Leola", "Male", "Hudson", "泯뛡︯伈䄁༂囃ꮙઙ焧", "턘톻ؗ−岘᦬鶝ᙼ꠭쾐", 1, null, null },
                    { new Guid("e2486cb0-ce51-540b-fbbb-87599c25d7b8"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 30, 21, 4, 30, 579, DateTimeKind.Local).AddTicks(601), "Keegan.Rohan@hotmail.com", null, null, "Vern", "Female", "Grant", "♰稗訖侖㎠ៅ黎秠", "ᒻ͙曏幒种ス⣠㵔", 1, null, null },
                    { new Guid("e750ffe3-8dfe-5c13-8157-b73b549356df"), new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 1, 14, 17, 22, 679, DateTimeKind.Local).AddTicks(5017), "Hollis_OConner72@hotmail.com", null, null, "Alanna", "Male", "Stehr", "몎⯯杫툓期炙Ⴊꤷ䧚", "돩ᓨ◆駍ᙚ䍸훛緅", 0, null, null },
                    { new Guid("e89e37fe-6167-f410-b616-32a96fa25b33"), new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 20, 4, 32, 10, 961, DateTimeKind.Local).AddTicks(5675), "Marguerite30@gmail.com", null, null, "Liam", "Male", "Osinski", "�ꟸ쵲皷헐蕟弄⬃ﴷ橡", "샊긱외呥샼苊ꐣ", 1, null, null },
                    { new Guid("ece5bad9-e0a9-e2b5-9199-3a65e28c45e7"), new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 29, 5, 6, 59, 45, DateTimeKind.Local).AddTicks(1539), "Ned_Crona@yahoo.com", null, null, "Jada", "Male", "Kilback", "敇쐩䝩秆豔꿭怭詗䔯ꮄ", "딌ꥭ쩘촂쑌Օ㏗멟쏟헻", 0, null, null },
                    { new Guid("ee85d431-4a33-0496-24d9-df54fe3fa31b"), new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 20, 12, 25, 23, 372, DateTimeKind.Local).AddTicks(4048), "Genevieve_Schroeder@hotmail.com", null, null, "Dillon", "Male", "Turcotte", "橸㶑銹᫃▼舏쪉ᡠ᣿鎿", "�䢥ꔥꯥ薚彼鵴凸ᯔ", 2, null, null },
                    { new Guid("f0edc233-e920-8eaf-3252-46001d8e3456"), new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 3, 2, 22, 35, 510, DateTimeKind.Local).AddTicks(4742), "Amaya_Wunsch91@hotmail.com", null, null, "Jarred", "Female", "Schuster", "霗スൢᾁ̭쥭쏍︤ຶ", "憯婇ຂ倦ൎ⤞△㶐篊攽", 2, null, null },
                    { new Guid("f15c7248-0270-e2e0-7851-eaaf9d656f94"), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 7, 19, 11, 16, 179, DateTimeKind.Local).AddTicks(283), "Burnice_Kuhlman@hotmail.com", null, null, "Christina", "Female", "D'Amore", "ᖏ琹毧⏼駄⳴薑엋᎙", "冚Ｘ婔⺰�妳괐舊ヽ雕", 1, null, null },
                    { new Guid("f300e51b-9e1e-702c-8ce6-29943168cf18"), new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 23, 11, 54, 763, DateTimeKind.Local).AddTicks(5035), "Haven_Emmerich@yahoo.com", null, null, "Hazle", "Female", "Bruen", "㐤ץ稼땖牺왬ኚꖎЭ殴", "浱ꫲ䢍⓶▄ﴀ掄蟶鷜츳", 0, null, null },
                    { new Guid("f4351afa-f27b-0069-2593-29d9b875eb4e"), new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 22, 18, 37, 23, 756, DateTimeKind.Local).AddTicks(3400), "Johnathan.Mann56@gmail.com", null, null, "Audra", "Male", "Gerlach", "簥깃珎ᧁ䀦쎦䘕", "㴢튜∆刮薫笝婽〃�엪", 0, null, null },
                    { new Guid("f602630f-6f34-8e2f-56c7-2f862e72d578"), new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 13, 6, 7, 0, 114, DateTimeKind.Local).AddTicks(415), "Marielle93@gmail.com", null, null, "Mayra", "Male", "Kunze", "擥牀鐮╱䎗ⲫ籵爜萿丂", "헖沧挗숵ཌྷ벼", 1, null, null },
                    { new Guid("f7d359dd-c909-76e7-4aad-2f0693ed8fa0"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 19, 19, 23, 0, 648, DateTimeKind.Local).AddTicks(7942), "Irving33@yahoo.com", null, null, "Cleve", "Female", "Monahan", "債馄碲쇦웆喁�嶞攢ே", "⍸ᢢ憪㮈츼됞婛ɖ뇺", 0, null, null },
                    { new Guid("f950af8d-8e63-e14c-3f5a-997b058a8d99"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 19, 10, 40, 30, 185, DateTimeKind.Local).AddTicks(9322), "Kiara.Barrows@gmail.com", null, null, "Nedra", "Female", "Lubowitz", "﫪줃ᆭꉤ龧횔쥉ꬼᠵ", "ᅴ넕凌斊䈾诓�썀뎡", 0, null, null },
                    { new Guid("f96a7c1e-f39d-ecd9-1542-af719f677974"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 24, 9, 23, 56, 449, DateTimeKind.Local).AddTicks(8855), "Carole67@yahoo.com", null, null, "Rossie", "Female", "Herman", "�싾乖䵛껲ꥌỖܳ쁤뺍", "�永汧◾䣟쎑겋伲䟽", 0, null, null },
                    { new Guid("fb96e38c-0e1c-757f-3426-3e52c97860a8"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 27, 10, 38, 1, 41, DateTimeKind.Local).AddTicks(8491), "Adeline94@gmail.com", null, null, "Granville", "Male", "Goodwin", "᫬곮里䐞꠿偭䤷품ἴ", "눈৴ɐ㙈붦≘펹⪘呑", 1, null, null },
                    { new Guid("fd0b4d6a-f197-ae36-f97e-7a521eb211f3"), new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 4, 15, 8, 9, 253, DateTimeKind.Local).AddTicks(2537), "Fannie_Bashirian@hotmail.com", null, null, "Fritz", "Male", "Kris", "呺梫ﯨ䨑酝⥞尽ﮈ槨ᙄ", "䡉齛䉣刞蓈ᐎ｠࿓쮾", 2, null, null },
                    { new Guid("fe409e34-b53d-ef0a-0622-ac2c8f7af69f"), new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 2, 8, 28, 58, 816, DateTimeKind.Local).AddTicks(3949), "Gerson16@hotmail.com", null, null, "Van", "Female", "Krajcik", "⟮ࡰ⁖ჶ噆퇺ⲁ㋴艹ᎏ", "࠹ԏ勢繆侢�உ꺲娩⾶", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Barangay", "City", "Country", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EmployeeId", "Line1", "Line2", "Province", "Status", "Type", "UpdatedAt", "UpdatedBy", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("00df27ff-187f-4984-9b77-ba9ede542495"), "Rhode Island", "Schaeferport", "Guadeloupe", new DateTime(2024, 1, 18, 15, 33, 4, 837, DateTimeKind.Local).AddTicks(677), "Amely49@yahoo.com", null, null, new Guid("053dc79b-c5de-6432-43af-7f57125715af"), "97768 Welch Creek", "Well", "Louisiana", 2, 2, null, null, "52999-8268" },
                    { new Guid("0af7090c-48f5-a79a-e7af-18c92008ac49"), "Delaware", "Lake Celestinoview", "Mauritius", new DateTime(2024, 5, 15, 13, 41, 29, 407, DateTimeKind.Local).AddTicks(5564), "Jeramy.Doyle58@yahoo.com", null, null, new Guid("2e7fd84f-089c-ebaa-c690-23e166d54ce5"), "83596 Quinten Rue", "Harbors", "Oklahoma", 0, 0, null, null, "11555" },
                    { new Guid("1367441a-b49a-c6a4-1bb9-1b3fb9b7b4e1"), "New York", "Herminiashire", "Comoros", new DateTime(2024, 2, 3, 5, 44, 45, 30, DateTimeKind.Local).AddTicks(8835), "Antonietta45@hotmail.com", null, null, new Guid("41bd02d9-4687-5ad8-d7d2-673be0a44e68"), "5831 Nikolas Manors", "Bridge", "Idaho", 1, 0, null, null, "95194-8329" },
                    { new Guid("18ada0e6-f0c6-ab16-3cb5-27c1891c86ba"), "New Hampshire", "Peterville", "Ghana", new DateTime(2024, 5, 31, 6, 44, 46, 820, DateTimeKind.Local).AddTicks(347), "Delta.Heller94@yahoo.com", null, null, new Guid("f15c7248-0270-e2e0-7851-eaaf9d656f94"), "74524 Kareem Spur", "Canyon", "Arizona", 0, 1, null, null, "00565-8166" },
                    { new Guid("191bec08-2451-a92b-5956-6e01ec32d715"), "Iowa", "Lake Turner", "Reunion", new DateTime(2024, 3, 21, 7, 39, 35, 331, DateTimeKind.Local).AddTicks(7352), "Cedrick_Orn@yahoo.com", null, null, new Guid("17d11798-8759-377d-3445-894abde44b2f"), "03355 Lonnie Branch", "Union", "Wyoming", 2, 2, null, null, "14372-7666" },
                    { new Guid("1ebc4a03-1688-3384-e121-dec047986986"), "Texas", "Kerluketon", "Ukraine", new DateTime(2024, 8, 2, 8, 51, 0, 903, DateTimeKind.Local).AddTicks(3340), "Brandy.Breitenberg@gmail.com", null, null, new Guid("ad15bbc0-2cad-fd78-f122-6ac50a0678ff"), "41251 Juliet Loaf", "Walks", "Georgia", 1, 0, null, null, "82907" },
                    { new Guid("2e3ed103-ba99-72c8-cc31-9b28a6ef99d6"), "Oregon", "Kautzerport", "Yemen", new DateTime(2023, 12, 5, 13, 37, 43, 488, DateTimeKind.Local).AddTicks(3790), "Payton4@gmail.com", null, null, new Guid("76414830-9e37-394c-117b-7e73d8381cee"), "07184 Runte Burgs", "Estates", "Arkansas", 2, 0, null, null, "81608-1283" },
                    { new Guid("3314c1b9-cb1e-17cf-64ab-03b36b4146bc"), "Washington", "Reichelview", "Brunei Darussalam", new DateTime(2024, 7, 9, 13, 41, 28, 589, DateTimeKind.Local).AddTicks(2193), "Garfield.King@yahoo.com", null, null, new Guid("b7ef2f8a-39cf-ca87-b3fe-e96903917c85"), "9493 Kathleen Lock", "Spur", "Pennsylvania", 2, 0, null, null, "25398-8586" },
                    { new Guid("3a0b1387-f9cc-e7eb-3ff1-46558202be58"), "North Carolina", "West Nelsonfort", "Fiji", new DateTime(2024, 1, 30, 7, 31, 41, 939, DateTimeKind.Local).AddTicks(9683), "Antonio86@gmail.com", null, null, new Guid("2669835a-03d6-f4b1-0d5c-ce770d7d2511"), "2526 Dortha Lane", "Parkways", "Wyoming", 0, 2, null, null, "63148-0330" },
                    { new Guid("3f7ed0a4-f241-fcf3-4dc3-7c422bc61264"), "Louisiana", "Julioside", "Namibia", new DateTime(2024, 6, 11, 17, 8, 46, 775, DateTimeKind.Local).AddTicks(2826), "Boyd_Koch8@hotmail.com", null, null, new Guid("43d6010a-5fd8-0b17-f092-b4427bef760d"), "019 Vinnie Landing", "Courts", "North Carolina", 2, 2, null, null, "17692-2710" },
                    { new Guid("4d8442ae-233a-14ce-490a-09130611ca99"), "Louisiana", "Goldenhaven", "Guatemala", new DateTime(2024, 4, 30, 21, 29, 10, 514, DateTimeKind.Local).AddTicks(3663), "Fermin_Reichert25@gmail.com", null, null, new Guid("2192bc6d-0dc0-0d07-79e2-d01a1d5a3814"), "71603 Aufderhar Streets", "Ramp", "Minnesota", 2, 0, null, null, "77201" },
                    { new Guid("58faae77-edf0-2010-861c-136994a3f392"), "Hawaii", "Arlieborough", "Tuvalu", new DateTime(2024, 5, 8, 12, 56, 13, 157, DateTimeKind.Local).AddTicks(2010), "Mireya.Schmeler52@hotmail.com", null, null, new Guid("b78896af-c55d-5a4c-1c70-962f6bc1eee3"), "74093 Veda Glen", "Plains", "New Mexico", 1, 0, null, null, "86182" },
                    { new Guid("5ebd09e7-a958-87eb-a7f3-f9390a02d172"), "Arkansas", "East Jana", "Cayman Islands", new DateTime(2024, 10, 3, 6, 19, 35, 8, DateTimeKind.Local).AddTicks(2797), "Easton76@hotmail.com", null, null, new Guid("409d249a-43f6-f154-d137-1d65585f4d02"), "531 Immanuel Isle", "Hill", "California", 2, 2, null, null, "90037" },
                    { new Guid("601942cd-2336-a003-b43f-0424c87791d1"), "Louisiana", "Port Idellafort", "Holy See (Vatican City State)", new DateTime(2024, 8, 24, 22, 25, 49, 608, DateTimeKind.Local).AddTicks(806), "Laisha37@gmail.com", null, null, new Guid("41bd02d9-4687-5ad8-d7d2-673be0a44e68"), "4719 Winfield Stream", "Tunnel", "Missouri", 1, 2, null, null, "96780-4252" },
                    { new Guid("613c47b7-cad9-4676-62fb-89b8c099d960"), "Kentucky", "East Laury", "Cuba", new DateTime(2023, 11, 23, 1, 35, 46, 999, DateTimeKind.Local).AddTicks(8517), "Russel.Franecki@gmail.com", null, null, new Guid("3fe6dfe5-8f91-b494-40f4-acf60a52a7fb"), "0185 Friesen Gardens", "Extensions", "Florida", 0, 2, null, null, "16282-1591" },
                    { new Guid("638f7f80-4b9a-faaf-18fa-ef6f84481a9f"), "Indiana", "Emardfurt", "Gabon", new DateTime(2024, 10, 16, 23, 2, 36, 825, DateTimeKind.Local).AddTicks(7299), "Freeda_Marquardt@hotmail.com", null, null, new Guid("9b9180e4-da1d-c1f2-4371-f19ec7aabe44"), "71719 Steuber Crossing", "Mission", "Colorado", 1, 1, null, null, "01239" },
                    { new Guid("64a40ca9-1c21-b0a9-5f44-eaecf20e9443"), "New Mexico", "Arishire", "Pakistan", new DateTime(2023, 12, 13, 12, 29, 53, 483, DateTimeKind.Local).AddTicks(6118), "Bobby72@hotmail.com", null, null, new Guid("0c276161-8a0f-3e99-3319-0d427a760132"), "99993 Pacocha Stream", "Flats", "Virginia", 0, 1, null, null, "92256-6476" },
                    { new Guid("64e5b2a5-2608-2f5b-4fd7-1ef9d9a5c962"), "California", "East Meganeville", "Israel", new DateTime(2023, 11, 26, 16, 38, 1, 153, DateTimeKind.Local).AddTicks(1595), "Quinten.Christiansen36@yahoo.com", null, null, new Guid("410417ab-e4fc-a13f-65dd-430d20182ca0"), "5156 Hettinger Parkway", "Shore", "Vermont", 1, 2, null, null, "65596" },
                    { new Guid("6b0fbcd0-14a1-ad3e-d316-d72cc711bb71"), "Washington", "Lakinfort", "Mauritius", new DateTime(2024, 8, 9, 20, 28, 48, 494, DateTimeKind.Local).AddTicks(8220), "Susie63@gmail.com", null, null, new Guid("1446547e-f9c4-dd0e-be04-c26d850c8a22"), "53378 Paula Inlet", "Square", "Illinois", 2, 0, null, null, "08285" },
                    { new Guid("6fa141e9-7827-b51c-3a51-c9ec089ad246"), "South Dakota", "Uniqueburgh", "Botswana", new DateTime(2024, 3, 28, 2, 35, 13, 699, DateTimeKind.Local).AddTicks(1872), "Vidal_Waters80@gmail.com", null, null, new Guid("6901692c-d46f-69ad-b86b-47f0abca0b0e"), "10457 Adolph Shoals", "Fields", "Oregon", 0, 0, null, null, "85344-2474" },
                    { new Guid("737f3f78-63b6-834a-b641-cd5fd7600165"), "North Carolina", "North Sedrickstad", "Togo", new DateTime(2024, 11, 7, 1, 20, 35, 251, DateTimeKind.Local).AddTicks(922), "Newton69@gmail.com", null, null, new Guid("053dc79b-c5de-6432-43af-7f57125715af"), "50795 Carissa Stravenue", "Points", "New Hampshire", 2, 0, null, null, "62295-3411" },
                    { new Guid("74480920-f1c2-25c2-dfb6-902ebe1ff682"), "Minnesota", "Walterborough", "Myanmar", new DateTime(2024, 11, 13, 19, 27, 30, 697, DateTimeKind.Local).AddTicks(183), "Gianni_Parker@gmail.com", null, null, new Guid("035bdee8-a73f-1794-90a1-9a8dd1d2ead2"), "827 Chauncey Islands", "Mews", "Minnesota", 2, 1, null, null, "54937" },
                    { new Guid("77557175-a767-927a-010a-2ca2fc529066"), "New Mexico", "New Maxieberg", "Belgium", new DateTime(2024, 3, 16, 14, 4, 23, 604, DateTimeKind.Local).AddTicks(2838), "Waino47@yahoo.com", null, null, new Guid("f15c7248-0270-e2e0-7851-eaaf9d656f94"), "7703 Lucas Street", "Rue", "Kentucky", 1, 2, null, null, "98781-6338" },
                    { new Guid("78eae819-9457-78cd-6c23-909039a3a28b"), "Kansas", "West Maybell", "Spain", new DateTime(2024, 9, 4, 9, 2, 30, 266, DateTimeKind.Local).AddTicks(547), "Marcella.Heidenreich53@yahoo.com", null, null, new Guid("43d6010a-5fd8-0b17-f092-b4427bef760d"), "78560 Nolan Extension", "Walks", "Illinois", 1, 2, null, null, "25233-3188" },
                    { new Guid("7c951b50-7f6e-5d09-3ab6-800d5df50e3f"), "South Carolina", "Pfannerstillborough", "Lesotho", new DateTime(2024, 5, 16, 10, 10, 14, 981, DateTimeKind.Local).AddTicks(3914), "Bethel.Bode@hotmail.com", null, null, new Guid("852e96d6-4288-2ab2-0325-dc405877d86f"), "863 Mireille Loop", "Lake", "Massachusetts", 2, 1, null, null, "86663-2208" },
                    { new Guid("8608ea1b-56dc-fb28-9fc8-20850723a7ce"), "Rhode Island", "Wildermanfurt", "Northern Mariana Islands", new DateTime(2023, 12, 16, 8, 45, 17, 70, DateTimeKind.Local).AddTicks(6036), "Jerel72@gmail.com", null, null, new Guid("9d6e5ef4-bf0e-49b7-7e1c-34851eb8b19d"), "08003 Michele Light", "Square", "Georgia", 2, 2, null, null, "03352" },
                    { new Guid("8cefe58f-d43b-4320-c506-fce3fcdaedff"), "Colorado", "West Kaitlinmouth", "Ghana", new DateTime(2024, 7, 21, 7, 4, 53, 106, DateTimeKind.Local).AddTicks(2634), "Wellington96@yahoo.com", null, null, new Guid("17d11798-8759-377d-3445-894abde44b2f"), "84521 Fletcher Pike", "Oval", "Connecticut", 2, 2, null, null, "14426-2883" },
                    { new Guid("95703a36-5550-5596-6c87-06378aefcc3b"), "Colorado", "Pierrefort", "Japan", new DateTime(2024, 7, 16, 15, 31, 56, 566, DateTimeKind.Local).AddTicks(115), "Boris40@hotmail.com", null, null, new Guid("9d04d428-af16-1ed6-c95d-db76ed6d033c"), "2265 Boyle Run", "Villages", "Florida", 2, 0, null, null, "52749-7629" },
                    { new Guid("978c3d0a-eb96-b22c-5dca-04aefd1f2e46"), "Florida", "South Emanueltown", "Panama", new DateTime(2024, 8, 29, 5, 4, 35, 421, DateTimeKind.Local).AddTicks(8569), "Tyrell38@yahoo.com", null, null, new Guid("6fb841a4-5aaf-bb02-8eca-96d9bcba8018"), "435 Ward Forge", "Forge", "Maine", 0, 1, null, null, "26729" },
                    { new Guid("9e5abeca-d807-eb9d-b379-566de5444fba"), "Oklahoma", "Lavonberg", "Rwanda", new DateTime(2024, 1, 16, 9, 8, 24, 289, DateTimeKind.Local).AddTicks(6451), "Pascale.Bosco@gmail.com", null, null, new Guid("ad15bbc0-2cad-fd78-f122-6ac50a0678ff"), "165 Pouros Drives", "Tunnel", "Arkansas", 0, 0, null, null, "84193" },
                    { new Guid("9f81fb09-8573-c0f2-ad57-144835ee7e18"), "Rhode Island", "New Winfield", "Palau", new DateTime(2024, 6, 5, 2, 4, 39, 545, DateTimeKind.Local).AddTicks(2769), "Joanny46@hotmail.com", null, null, new Guid("ece5bad9-e0a9-e2b5-9199-3a65e28c45e7"), "17738 Ismael Turnpike", "Fork", "Arkansas", 2, 0, null, null, "20797" },
                    { new Guid("a18531b1-8a5d-ace7-b610-322368e9321b"), "Alabama", "South Ianburgh", "Mauritania", new DateTime(2024, 3, 8, 4, 32, 31, 700, DateTimeKind.Local).AddTicks(3398), "Phyllis.Hoeger55@gmail.com", null, null, new Guid("f15c7248-0270-e2e0-7851-eaaf9d656f94"), "5028 Bednar Inlet", "Way", "Arizona", 0, 0, null, null, "60706-1291" },
                    { new Guid("a360d2c8-228f-415e-2c43-76dba86957d3"), "Colorado", "South Sheldon", "Bouvet Island (Bouvetoya)", new DateTime(2024, 3, 7, 4, 0, 37, 565, DateTimeKind.Local).AddTicks(4220), "Noe_Johns63@gmail.com", null, null, new Guid("fe409e34-b53d-ef0a-0622-ac2c8f7af69f"), "1694 Emmet Extensions", "Summit", "Ohio", 1, 0, null, null, "95508" },
                    { new Guid("a93a5cec-8cbc-b6e6-39a1-064095ef9a0b"), "Louisiana", "Darienland", "Wallis and Futuna", new DateTime(2024, 5, 18, 6, 47, 54, 656, DateTimeKind.Local).AddTicks(5820), "Ismael.Schmitt15@hotmail.com", null, null, new Guid("fd0b4d6a-f197-ae36-f97e-7a521eb211f3"), "710 Gleason Mission", "Course", "Delaware", 2, 1, null, null, "53511" },
                    { new Guid("aee22d82-186a-e141-0c8d-b003e1d60fd4"), "Arizona", "Emardside", "Antigua and Barbuda", new DateTime(2024, 8, 17, 4, 40, 13, 808, DateTimeKind.Local).AddTicks(5672), "Curt44@hotmail.com", null, null, new Guid("2eb48373-4a76-dbbc-50e2-9383eb7acc6f"), "4186 Kellie Heights", "Inlet", "Mississippi", 0, 1, null, null, "08995" },
                    { new Guid("b492864c-b551-6e51-e99a-291245bf2ae9"), "West Virginia", "Bergnaumhaven", "Saudi Arabia", new DateTime(2024, 8, 25, 1, 56, 43, 304, DateTimeKind.Local).AddTicks(3500), "Rogelio.Gutmann52@hotmail.com", null, null, new Guid("e750ffe3-8dfe-5c13-8157-b73b549356df"), "6988 Boehm Island", "Loaf", "Utah", 2, 0, null, null, "44421" },
                    { new Guid("ba214317-ef06-b635-b558-c8fb95da9ef3"), "Massachusetts", "Port Camilla", "Samoa", new DateTime(2024, 4, 13, 10, 41, 18, 253, DateTimeKind.Local).AddTicks(8537), "Hazle.Roob@gmail.com", null, null, new Guid("b78896af-c55d-5a4c-1c70-962f6bc1eee3"), "01673 Zieme Dale", "Plaza", "North Carolina", 2, 0, null, null, "57795-8205" },
                    { new Guid("c26feb24-1155-36cd-7c91-644efb7d0bd5"), "Washington", "Autumnville", "French Southern Territories", new DateTime(2023, 12, 12, 22, 26, 20, 22, DateTimeKind.Local).AddTicks(8328), "Natalie.Nikolaus59@gmail.com", null, null, new Guid("e89e37fe-6167-f410-b616-32a96fa25b33"), "4014 Freda Way", "Circle", "Michigan", 2, 1, null, null, "01447" },
                    { new Guid("c6dae981-fedb-9e8d-b72a-0ca67eda2e84"), "Indiana", "North Nigelton", "Macedonia", new DateTime(2024, 10, 17, 11, 50, 32, 228, DateTimeKind.Local).AddTicks(2368), "Alivia.Kozey@yahoo.com", null, null, new Guid("ee85d431-4a33-0496-24d9-df54fe3fa31b"), "20606 Schumm Cove", "Estate", "Oklahoma", 1, 0, null, null, "16292" },
                    { new Guid("c8fa2211-7d04-a877-0afd-a13f1938914c"), "North Carolina", "Stammhaven", "Bosnia and Herzegovina", new DateTime(2024, 4, 27, 2, 56, 46, 514, DateTimeKind.Local).AddTicks(2970), "Cristina.Koss61@gmail.com", null, null, new Guid("2eb48373-4a76-dbbc-50e2-9383eb7acc6f"), "0586 Lysanne Walk", "Fords", "Washington", 2, 1, null, null, "00154-7193" },
                    { new Guid("cbbf8b15-ccd7-477b-fb3b-cfd013a6d0f0"), "Maryland", "South Rubiefurt", "Kuwait", new DateTime(2024, 3, 20, 23, 13, 30, 996, DateTimeKind.Local).AddTicks(8074), "Walter62@hotmail.com", null, null, new Guid("8d92ee06-e2c5-1e4b-e217-0fb5dbe2ec2d"), "4276 Randall Well", "Mountains", "Tennessee", 1, 0, null, null, "10895" },
                    { new Guid("cfba0dfc-755e-cc4c-a144-2e1e05dc2f13"), "Wisconsin", "Port Salvatorestad", "Belarus", new DateTime(2023, 12, 1, 16, 12, 14, 169, DateTimeKind.Local).AddTicks(5626), "Nellie_Gorczany90@hotmail.com", null, null, new Guid("a01f102b-2ddd-db7a-afec-5f932cbfc9ba"), "898 Rhoda Isle", "Branch", "Indiana", 1, 1, null, null, "48160" },
                    { new Guid("d0df78a6-8eda-57bc-ffc5-07f5fedf5f02"), "Delaware", "Fritschburgh", "Spain", new DateTime(2024, 9, 3, 17, 23, 47, 715, DateTimeKind.Local).AddTicks(2255), "Mozell.Heidenreich@gmail.com", null, null, new Guid("2d75e257-5e3e-ec39-dd29-4c44bdbdb99a"), "36521 Welch Ranch", "Neck", "Iowa", 0, 0, null, null, "19328-5087" },
                    { new Guid("d4f77e3c-1249-c8f3-ce58-ec59fe60c43a"), "Maryland", "Schimmelbury", "Equatorial Guinea", new DateTime(2024, 6, 8, 7, 7, 7, 775, DateTimeKind.Local).AddTicks(2556), "Lukas.Swift37@gmail.com", null, null, new Guid("ece5bad9-e0a9-e2b5-9199-3a65e28c45e7"), "4669 Zboncak Trace", "Mountain", "Florida", 0, 1, null, null, "89748" },
                    { new Guid("e94f0c34-5d18-c2c9-c534-6b1e7754b596"), "Oklahoma", "Lake Isaiah", "Equatorial Guinea", new DateTime(2024, 7, 17, 11, 57, 24, 675, DateTimeKind.Local).AddTicks(8566), "Sebastian81@hotmail.com", null, null, new Guid("f7d359dd-c909-76e7-4aad-2f0693ed8fa0"), "66063 Carson Roads", "Parkway", "New York", 2, 2, null, null, "20204-0933" },
                    { new Guid("ee551d89-1223-2938-eab7-e80b58a9f985"), "Utah", "O'Konland", "Saint Lucia", new DateTime(2024, 3, 29, 19, 34, 30, 13, DateTimeKind.Local).AddTicks(4896), "Gloria_Walsh32@yahoo.com", null, null, new Guid("593e6613-25af-1ead-e666-c5dc66e349c6"), "778 Adela Keys", "Stravenue", "Indiana", 1, 2, null, null, "61931" },
                    { new Guid("efb5e0a0-0323-c3d4-07b1-0eddc1fae4af"), "Michigan", "McClurebury", "Heard Island and McDonald Islands", new DateTime(2024, 7, 24, 17, 55, 9, 74, DateTimeKind.Local).AddTicks(722), "Ida.Harber95@hotmail.com", null, null, new Guid("8242dfbf-54de-73bd-ee70-0311a7f19389"), "56174 Lockman Land", "Estate", "North Dakota", 0, 0, null, null, "78407" },
                    { new Guid("f151887c-fc41-7968-c679-61d955b966ba"), "Mississippi", "New Alfberg", "Dominican Republic", new DateTime(2024, 2, 5, 0, 45, 36, 935, DateTimeKind.Local).AddTicks(6572), "Jenifer.Parker44@yahoo.com", null, null, new Guid("d63eafff-7a89-d600-d7ba-6a3c2c961778"), "649 Beer Crescent", "Gateway", "Illinois", 1, 0, null, null, "88005" },
                    { new Guid("f416696a-cb86-2209-c41f-2f6cbf36ea19"), "South Carolina", "East Ethylhaven", "Cuba", new DateTime(2024, 2, 1, 21, 41, 58, 422, DateTimeKind.Local).AddTicks(7930), "Delaney.Russel63@gmail.com", null, null, new Guid("308671a2-fa9a-0ef4-89e5-9fcbcf119b7f"), "005 O'Reilly Estate", "Gardens", "Alabama", 0, 0, null, null, "34852-4103" },
                    { new Guid("f8cd0232-e6f8-3786-46af-292dc96e6084"), "Virginia", "Johnston", "Ireland", new DateTime(2024, 5, 31, 15, 18, 59, 709, DateTimeKind.Local).AddTicks(6797), "Lillian36@hotmail.com", null, null, new Guid("11f91228-b00e-721a-53cd-5cf3ce1bca96"), "93008 Estell Summit", "Forest", "Delaware", 0, 2, null, null, "19925-1960" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EmployeeId", "IsPrimary", "Status", "Type", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { new Guid("04f1d8b3-d886-47a6-1367-0bbff5de074f"), new DateTime(2024, 1, 16, 23, 46, 8, 453, DateTimeKind.Local).AddTicks(9032), "Joseph0@gmail.com", null, null, new Guid("c9c0909d-96a4-fe1a-0a56-c27d0e9cf5ad"), true, 0, 0, null, null, "1-724-933-7024 x6098" },
                    { new Guid("0a92e338-875e-abe1-28c3-e344d77caa60"), new DateTime(2024, 5, 28, 3, 45, 51, 121, DateTimeKind.Local).AddTicks(6354), "Isaac61@hotmail.com", null, null, new Guid("4f9cfd74-ecdd-d308-87be-f45420df42ee"), false, 2, 1, null, null, "1-514-736-8483 x932" },
                    { new Guid("0ac49dd7-0fea-4fb2-4d0a-54a618760f1a"), new DateTime(2024, 3, 15, 2, 15, 0, 553, DateTimeKind.Local).AddTicks(1531), "Freeda.Beatty64@hotmail.com", null, null, new Guid("852e96d6-4288-2ab2-0325-dc405877d86f"), true, 2, 2, null, null, "Fern24@hotmail.com" },
                    { new Guid("0e902228-767b-4fc2-171c-14afcda95d5f"), new DateTime(2024, 4, 15, 23, 2, 24, 608, DateTimeKind.Local).AddTicks(6158), "Ora6@yahoo.com", null, null, new Guid("035bdee8-a73f-1794-90a1-9a8dd1d2ead2"), false, 0, 1, null, null, "(703) 711-9377" },
                    { new Guid("1178bdb2-f865-18f8-2351-a27dad9cbfa1"), new DateTime(2024, 3, 19, 6, 12, 36, 845, DateTimeKind.Local).AddTicks(9205), "Shea64@yahoo.com", null, null, new Guid("e2159279-75dd-73b8-c220-d75a782ca63c"), true, 2, 2, null, null, "Carmelo_Wiza@yahoo.com" },
                    { new Guid("1571b36e-69c6-b178-5fa2-674d3849380c"), new DateTime(2024, 2, 16, 0, 52, 51, 768, DateTimeKind.Local).AddTicks(5322), "Dahlia_Carroll46@yahoo.com", null, null, new Guid("e2159279-75dd-73b8-c220-d75a782ca63c"), true, 0, 1, null, null, "1-878-544-7804 x230" },
                    { new Guid("1cf538d1-d37f-f698-2df0-37d58ca129b8"), new DateTime(2024, 11, 10, 4, 22, 51, 95, DateTimeKind.Local).AddTicks(5959), "Keyshawn_Witting@yahoo.com", null, null, new Guid("499b8f8d-af64-cfb2-72d0-8eca8a68a932"), false, 2, 0, null, null, "1-463-394-0618" },
                    { new Guid("1dea9ed6-35a4-0859-e770-76c60e0e5c39"), new DateTime(2024, 11, 11, 19, 44, 56, 843, DateTimeKind.Local).AddTicks(3941), "Naomie_Reilly14@gmail.com", null, null, new Guid("409d249a-43f6-f154-d137-1d65585f4d02"), true, 2, 0, null, null, "(559) 619-6521" },
                    { new Guid("2335a71f-4617-a01b-57cc-64541da5520d"), new DateTime(2024, 2, 29, 12, 54, 9, 634, DateTimeKind.Local).AddTicks(1787), "German.Stracke@gmail.com", null, null, new Guid("349eea88-5437-2753-3e02-af3e69c45195"), false, 0, 1, null, null, "(906) 227-7691 x73129" },
                    { new Guid("2dde13e3-1eb9-356b-b074-ee4f9173cc63"), new DateTime(2024, 6, 17, 18, 53, 22, 984, DateTimeKind.Local).AddTicks(565), "Marielle0@yahoo.com", null, null, new Guid("ae16a6cd-9e72-6e98-e378-4d8a6c2874d9"), false, 2, 1, null, null, "(859) 640-0392 x8497" },
                    { new Guid("2dfc2e6e-7e6e-2df9-dd3b-b8497dec3c8f"), new DateTime(2024, 9, 12, 21, 44, 22, 576, DateTimeKind.Local).AddTicks(7986), "Delphine.Friesen58@gmail.com", null, null, new Guid("2192bc6d-0dc0-0d07-79e2-d01a1d5a3814"), true, 2, 1, null, null, "(327) 359-2664" },
                    { new Guid("3b15dc8b-8a5a-eff9-7da1-8d3e214f774b"), new DateTime(2024, 6, 17, 1, 56, 25, 642, DateTimeKind.Local).AddTicks(1871), "Mireya_Jacobs@yahoo.com", null, null, new Guid("770f79bc-f690-489d-442a-bf84f8e42385"), false, 1, 0, null, null, "207.507.0045 x6153" },
                    { new Guid("3cbdfecb-ec40-7993-313c-5089c1613c04"), new DateTime(2023, 11, 27, 8, 31, 30, 626, DateTimeKind.Local).AddTicks(1416), "Lia2@yahoo.com", null, null, new Guid("43d6010a-5fd8-0b17-f092-b4427bef760d"), false, 0, 2, null, null, "Ali_Kirlin6@hotmail.com" },
                    { new Guid("3f6806d5-8ff6-64d3-9f2b-f723e4ae3b01"), new DateTime(2024, 2, 15, 22, 27, 5, 739, DateTimeKind.Local).AddTicks(1015), "Destinee_Buckridge@yahoo.com", null, null, new Guid("346cc8fe-d1de-4e05-f1d6-9278ee092474"), true, 1, 2, null, null, "Molly.Reichel@yahoo.com" },
                    { new Guid("4004566f-70c7-925f-8079-de2d649dfeb4"), new DateTime(2024, 2, 9, 23, 26, 26, 155, DateTimeKind.Local).AddTicks(4223), "Paris.Hilll57@gmail.com", null, null, new Guid("65ea95f2-e001-b149-580f-a7d830bc6515"), true, 1, 2, null, null, "Yvette49@yahoo.com" },
                    { new Guid("491e91c5-54a7-494c-49f6-ec768f37986b"), new DateTime(2024, 10, 3, 17, 44, 19, 200, DateTimeKind.Local).AddTicks(8335), "Caleigh.Orn@gmail.com", null, null, new Guid("95dcb80a-17c0-93bb-a54f-3dfb9778057d"), true, 0, 0, null, null, "896.862.1371 x745" },
                    { new Guid("4ce7c8ff-4c3b-c1d7-4455-ef485dee8d81"), new DateTime(2024, 3, 12, 2, 52, 59, 120, DateTimeKind.Local).AddTicks(3372), "Deion.Feeney91@yahoo.com", null, null, new Guid("9d6e5ef4-bf0e-49b7-7e1c-34851eb8b19d"), false, 1, 1, null, null, "(324) 604-4451" },
                    { new Guid("4e629b5a-ee92-0937-0a76-ab722a3fc5c6"), new DateTime(2024, 7, 11, 19, 25, 28, 793, DateTimeKind.Local).AddTicks(2157), "Fae.Pacocha62@yahoo.com", null, null, new Guid("d0e77273-c3cf-cbbc-3871-b792ef3db7e8"), true, 2, 2, null, null, "Clarissa.Gislason@hotmail.com" },
                    { new Guid("50993fd5-fee7-f7cb-7ac1-e810d87363e7"), new DateTime(2024, 3, 6, 18, 36, 16, 380, DateTimeKind.Local).AddTicks(8351), "Kiara.Windler@hotmail.com", null, null, new Guid("4d5e1801-d086-e38e-572a-44ca8a69ab4e"), false, 1, 0, null, null, "271-800-7435 x1436" },
                    { new Guid("513d0da9-6a34-8946-8402-f821f46ae95d"), new DateTime(2024, 7, 27, 6, 8, 10, 480, DateTimeKind.Local).AddTicks(8501), "Alexandre_Bechtelar20@hotmail.com", null, null, new Guid("2d75e257-5e3e-ec39-dd29-4c44bdbdb99a"), false, 1, 0, null, null, "627.299.2859" },
                    { new Guid("5566dc49-8c12-6baf-032b-5cd3d83643e7"), new DateTime(2024, 11, 9, 17, 27, 43, 751, DateTimeKind.Local).AddTicks(5965), "Curtis.Mohr@gmail.com", null, null, new Guid("349eea88-5437-2753-3e02-af3e69c45195"), true, 1, 1, null, null, "530-937-1842" },
                    { new Guid("5ff3c325-bfb3-81f7-d72e-33fc83b09523"), new DateTime(2024, 7, 7, 1, 18, 28, 186, DateTimeKind.Local).AddTicks(5733), "Floy30@gmail.com", null, null, new Guid("d63eafff-7a89-d600-d7ba-6a3c2c961778"), true, 1, 1, null, null, "764.967.1231" },
                    { new Guid("5ffc40dd-499a-d270-3476-b50197a2513d"), new DateTime(2024, 11, 8, 13, 45, 52, 551, DateTimeKind.Local).AddTicks(2757), "Haleigh_Muller@gmail.com", null, null, new Guid("f602630f-6f34-8e2f-56c7-2f862e72d578"), false, 0, 1, null, null, "322.277.1935" },
                    { new Guid("6354a318-9145-69cc-cd6d-cae066d1f89a"), new DateTime(2024, 6, 13, 10, 23, 7, 26, DateTimeKind.Local).AddTicks(3912), "Antone38@yahoo.com", null, null, new Guid("6901692c-d46f-69ad-b86b-47f0abca0b0e"), false, 1, 2, null, null, "Darby_Maggio46@hotmail.com" },
                    { new Guid("636aff40-aa2a-9d78-d7cd-a55e89047249"), new DateTime(2024, 5, 22, 10, 50, 28, 462, DateTimeKind.Local).AddTicks(5394), "Velva69@gmail.com", null, null, new Guid("d63eafff-7a89-d600-d7ba-6a3c2c961778"), false, 1, 0, null, null, "(708) 870-4668 x8076" },
                    { new Guid("6592e704-8cb2-7305-afab-c21a344c2f80"), new DateTime(2024, 8, 2, 3, 18, 59, 736, DateTimeKind.Local).AddTicks(6826), "Moses60@yahoo.com", null, null, new Guid("7026b9b5-7571-ff0b-6a2e-bd92c47a6e22"), false, 2, 0, null, null, "313-274-7079" },
                    { new Guid("70bc5a23-55ff-faef-872c-10d02a967bb6"), new DateTime(2024, 3, 30, 12, 27, 4, 165, DateTimeKind.Local).AddTicks(5862), "Bill.Stracke81@gmail.com", null, null, new Guid("e2486cb0-ce51-540b-fbbb-87599c25d7b8"), false, 1, 0, null, null, "(401) 773-7179" },
                    { new Guid("72132bd6-29ed-f931-18c5-9ca913b6b666"), new DateTime(2024, 3, 8, 19, 41, 47, 673, DateTimeKind.Local).AddTicks(4282), "Judson_Reilly@hotmail.com", null, null, new Guid("6901692c-d46f-69ad-b86b-47f0abca0b0e"), true, 1, 0, null, null, "(898) 285-2491 x849" },
                    { new Guid("7b37646d-3167-6b3c-0138-3d3640a92df2"), new DateTime(2024, 8, 13, 17, 22, 2, 561, DateTimeKind.Local).AddTicks(7564), "Willa_Botsford@gmail.com", null, null, new Guid("2669835a-03d6-f4b1-0d5c-ce770d7d2511"), false, 1, 0, null, null, "1-486-359-4302" },
                    { new Guid("7f7e8fba-e44b-ac5c-26cc-def7c74c4d31"), new DateTime(2024, 5, 30, 16, 56, 28, 379, DateTimeKind.Local).AddTicks(2917), "Litzy_Gulgowski77@gmail.com", null, null, new Guid("6fb841a4-5aaf-bb02-8eca-96d9bcba8018"), false, 1, 1, null, null, "425.744.6660" },
                    { new Guid("83bae1dd-d1f4-e0ff-6f31-ffd0136723c6"), new DateTime(2024, 1, 1, 19, 5, 57, 228, DateTimeKind.Local).AddTicks(8454), "Colin_Zulauf73@yahoo.com", null, null, new Guid("c9c0909d-96a4-fe1a-0a56-c27d0e9cf5ad"), false, 0, 0, null, null, "(765) 400-3409" },
                    { new Guid("8f91395e-31ed-38a2-82fb-2260810776fa"), new DateTime(2024, 9, 17, 16, 6, 3, 934, DateTimeKind.Local).AddTicks(2652), "Alize.Kub56@yahoo.com", null, null, new Guid("95cbf859-e28b-ad5c-2a79-f04c6c3ef4e8"), true, 1, 0, null, null, "1-922-335-6028 x913" },
                    { new Guid("91981a2c-b4e9-a95e-a209-732c3955915a"), new DateTime(2024, 2, 8, 4, 38, 55, 821, DateTimeKind.Local).AddTicks(8902), "Alek56@gmail.com", null, null, new Guid("8242dfbf-54de-73bd-ee70-0311a7f19389"), true, 0, 1, null, null, "(356) 922-0858 x40955" },
                    { new Guid("97b8e6d9-d23a-52e2-5994-15e642d45c99"), new DateTime(2024, 10, 29, 23, 20, 18, 168, DateTimeKind.Local).AddTicks(4952), "Alek33@gmail.com", null, null, new Guid("2e3c7085-4eaf-b05c-995c-d1674d4e7e74"), true, 2, 1, null, null, "243.957.0368 x7752" },
                    { new Guid("a1a866c4-2309-17d7-a4bf-3aa0a407ae82"), new DateTime(2024, 7, 3, 17, 41, 20, 825, DateTimeKind.Local).AddTicks(6461), "Deondre34@gmail.com", null, null, new Guid("852e96d6-4288-2ab2-0325-dc405877d86f"), true, 2, 1, null, null, "1-860-758-0144" },
                    { new Guid("a2168c8a-903b-5468-f375-53b821ece3d2"), new DateTime(2024, 7, 14, 23, 46, 24, 362, DateTimeKind.Local).AddTicks(6545), "Elton78@hotmail.com", null, null, new Guid("499b8f8d-af64-cfb2-72d0-8eca8a68a932"), false, 0, 1, null, null, "1-836-719-4009" },
                    { new Guid("a7933a3b-7e5b-8467-612b-90112cf24add"), new DateTime(2023, 12, 25, 0, 18, 33, 499, DateTimeKind.Local).AddTicks(6477), "Crystal71@hotmail.com", null, null, new Guid("3a17ed9c-56e7-8d61-0828-167ac498ce52"), true, 2, 1, null, null, "1-765-995-6655 x966" },
                    { new Guid("a89c5b46-c71b-23c2-6398-52977cded79e"), new DateTime(2024, 9, 14, 19, 55, 10, 105, DateTimeKind.Local).AddTicks(607), "Charlotte.Johnston@gmail.com", null, null, new Guid("d5e6d946-91a8-0c4b-b149-6f1d42c6634d"), false, 0, 0, null, null, "(352) 233-3806 x70244" },
                    { new Guid("a9799f0c-6420-8090-0b81-bfa9f5cd9cdf"), new DateTime(2024, 9, 12, 4, 4, 40, 396, DateTimeKind.Local).AddTicks(3286), "Justus.Runolfsson@hotmail.com", null, null, new Guid("308671a2-fa9a-0ef4-89e5-9fcbcf119b7f"), false, 1, 2, null, null, "Jamir.Hermann@hotmail.com" },
                    { new Guid("b583ffcc-a1ea-0c25-5567-83413952ddc1"), new DateTime(2024, 2, 2, 9, 46, 44, 682, DateTimeKind.Local).AddTicks(1020), "Margarette25@hotmail.com", null, null, new Guid("409d249a-43f6-f154-d137-1d65585f4d02"), true, 0, 0, null, null, "1-597-741-5435" },
                    { new Guid("b9e9240d-033d-4915-a84d-df5fb6875052"), new DateTime(2024, 6, 28, 20, 58, 56, 176, DateTimeKind.Local).AddTicks(177), "Riley_Schoen62@yahoo.com", null, null, new Guid("fe409e34-b53d-ef0a-0622-ac2c8f7af69f"), false, 0, 2, null, null, "Lorenz.Thiel@hotmail.com" },
                    { new Guid("bc489a5d-317f-056b-92da-5515a9d7d5d8"), new DateTime(2024, 1, 21, 14, 4, 51, 447, DateTimeKind.Local).AddTicks(1250), "Daisy37@hotmail.com", null, null, new Guid("50c5b7f3-412f-a49f-67d8-bc0f7eb83405"), true, 0, 0, null, null, "970-415-7788 x679" },
                    { new Guid("c07ad191-fce3-370e-4962-695f5e4ff232"), new DateTime(2024, 8, 7, 10, 40, 59, 660, DateTimeKind.Local).AddTicks(6068), "Marielle_Hoeger31@hotmail.com", null, null, new Guid("e2486cb0-ce51-540b-fbbb-87599c25d7b8"), true, 1, 1, null, null, "(714) 907-2196" },
                    { new Guid("c7859406-f4ec-628d-e98a-7df768cf30ae"), new DateTime(2024, 6, 14, 17, 16, 58, 960, DateTimeKind.Local).AddTicks(4084), "Bertram.Christiansen@hotmail.com", null, null, new Guid("349eea88-5437-2753-3e02-af3e69c45195"), true, 2, 0, null, null, "1-514-715-8086 x60767" },
                    { new Guid("ce45982a-42cc-aa93-7e81-417a1ac0c362"), new DateTime(2024, 1, 16, 14, 45, 19, 430, DateTimeKind.Local).AddTicks(8223), "Yvette.Hodkiewicz@gmail.com", null, null, new Guid("18cef689-80aa-1713-a86e-9df38e5488cb"), false, 1, 1, null, null, "(332) 901-4325 x36837" },
                    { new Guid("ce63878c-675e-675f-f74d-77b9a02e6ddd"), new DateTime(2024, 6, 11, 21, 37, 3, 775, DateTimeKind.Local).AddTicks(2971), "Nasir59@hotmail.com", null, null, new Guid("770f79bc-f690-489d-442a-bf84f8e42385"), false, 2, 0, null, null, "(867) 317-7446 x8261" },
                    { new Guid("e593152c-e520-4f01-76c7-dabae1f3d739"), new DateTime(2024, 3, 9, 5, 11, 56, 576, DateTimeKind.Local).AddTicks(2746), "Elliot_Stiedemann29@gmail.com", null, null, new Guid("f950af8d-8e63-e14c-3f5a-997b058a8d99"), false, 0, 1, null, null, "1-428-656-5840" },
                    { new Guid("e6892431-be4f-4617-c037-0bbf01935008"), new DateTime(2024, 8, 25, 4, 50, 25, 355, DateTimeKind.Local).AddTicks(6679), "Lucas_Mertz@yahoo.com", null, null, new Guid("4f9cfd74-ecdd-d308-87be-f45420df42ee"), false, 1, 0, null, null, "1-529-912-3169" },
                    { new Guid("fdaa37c2-f15a-75b2-5fd7-f2659a7f1176"), new DateTime(2024, 11, 10, 23, 32, 34, 796, DateTimeKind.Local).AddTicks(5955), "Gilbert82@yahoo.com", null, null, new Guid("5eb8b7f4-9f0f-3cac-ace9-9b7b1f171445"), false, 1, 1, null, null, "1-995-288-0695" },
                    { new Guid("fe22b825-9a0e-b123-2e0d-aa8a729dd3b5"), new DateTime(2024, 1, 2, 19, 52, 57, 551, DateTimeKind.Local).AddTicks(1983), "Jasper_Gottlieb@hotmail.com", null, null, new Guid("9d04d428-af16-1ed6-c95d-db76ed6d033c"), true, 2, 0, null, null, "324-445-1995" }
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
