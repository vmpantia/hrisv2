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
                name: "Address",
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
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
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
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Employees_EmployeeId",
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
                    { "ID_NUMBER_EMPPLOYEE_PREFIX", "SYSTEM", "EMP" },
                    { "ID_NUMBER_FORMAT", "SYSTEM", "{0}-{1}-{2}" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "FirstName", "Gender", "LastName", "MiddleName", "Number", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0105ce8f-a89c-5b5f-fb99-5a82f4e6ff74"), new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 26, 13, 16, 10, 371, DateTimeKind.Local).AddTicks(9551), "Carolyne84@gmail.com", null, null, "Sid", "Female", "Cummerata", "ദ￈ࢯ᪂蹅㷉ᑦᚶͅ", "뇞鲤퇁瀏￑漭芊鬖쓚", 2, null, null },
                    { new Guid("0290d299-6ee8-98e8-17c4-09205c2f5dc2"), new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 30, 22, 47, 3, 235, DateTimeKind.Local).AddTicks(6860), "Evalyn48@yahoo.com", null, null, "Roma", "Female", "Baumbach", "ᵣ蓑䤬䚐ꮗ᪴᧗�뜜", "겢聗ꬹ䳉勃帵絀뺧䣹覇", 1, null, null },
                    { new Guid("11261073-5e49-995f-70d8-5c3b47ff7697"), new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 3, 23, 50, 268, DateTimeKind.Local).AddTicks(1744), "Jordy7@yahoo.com", null, null, "Hugh", "Male", "Bins", "䒦妝欔甑⍗駽톰䄫⍨", "᱋믹彀ꋯ곹ᱦՠ꤮ⲛ", 1, null, null },
                    { new Guid("114a576e-be80-7cdf-9a5f-4fab364058a8"), new DateTime(2023, 4, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 3, 11, 16, 43, 389, DateTimeKind.Local).AddTicks(4271), "Jaquan23@yahoo.com", null, null, "Alessia", "Female", "Flatley", "믴ꁿ靚ꉺ赦楾䝏州", "ɼ焧搎䭙ယ臭澐㑸豚", 2, null, null },
                    { new Guid("13e1a3e1-e43c-1e6e-cb54-2063010dc7c4"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 2, 18, 34, 28, 961, DateTimeKind.Local).AddTicks(835), "Cicero65@yahoo.com", null, null, "Caroline", "Female", "Fahey", "Ỗ췀炻륃ꀉ∶턲㓌⾛", "�毵ᮮ眵靜踣ㅼ⾰놼", 2, null, null },
                    { new Guid("176ed201-fb45-c349-9565-a03d0787bbbc"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 1, 12, 42, 13, 896, DateTimeKind.Local).AddTicks(4180), "Micah_Schamberger@hotmail.com", null, null, "Mohammed", "Female", "Will", "埩ﻵ�瓨빜叾⻠㴌◚睜", "鮉鎱푙�鳨좔瓵�቏", 0, null, null },
                    { new Guid("188079b9-1013-d796-8969-bbb3fd03ee19"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 11, 42, 48, 723, DateTimeKind.Local).AddTicks(6064), "Kaley_Lynch5@yahoo.com", null, null, "Kendra", "Female", "Harvey", "ꕨ១⫾㞸䙊賉퇾᷆Ǝ胒", "ਦ醢椯ᅡ㊃뷟", 0, null, null },
                    { new Guid("1b64513b-afd4-cc1d-70f5-3ae1fc10fb93"), new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 18, 21, 51, 16, 528, DateTimeKind.Local).AddTicks(387), "Robert_Hodkiewicz@gmail.com", null, null, "Shaniya", "Female", "Greenholt", "㊠饏꧍꟟顂඘魴绝␌�", "ɮﹱᦢ輮秗櫿楽ﺄҤᯀ", 2, null, null },
                    { new Guid("1e38db0d-db28-5f5c-4efa-604b4f119ac5"), new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 6, 9, 43, 47, 606, DateTimeKind.Local).AddTicks(5414), "Vallie81@gmail.com", null, null, "Shea", "Male", "Runolfsdottir", "嵫郗쌲ꒀ毿⅝匱则柏", "Ⓤ䐮省㸥巾஼썱惇䅔蘵", 2, null, null },
                    { new Guid("201cdcb0-f913-6809-51e4-4f2290dbad71"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 14, 11, 21, 32, 972, DateTimeKind.Local).AddTicks(8943), "Richie_McGlynn9@gmail.com", null, null, "Jan", "Male", "Pagac", "¬敕暋꽣ꌝ蠒嚺", "뷅쓄⿢淴�履ᒖკ醜", 2, null, null },
                    { new Guid("2121b38f-a594-09a8-e0fe-24e797f1dd96"), new DateTime(2023, 9, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 5, 2, 21, 29, 412, DateTimeKind.Local).AddTicks(5389), "Scotty.Hansen@gmail.com", null, null, "Rupert", "Male", "Kihn", "佲꣆씠紷즉⪿❋挘餳", "⼷娎쐈⏽࿏룴ᵉ׺ⱟ", 1, null, null },
                    { new Guid("23af449c-ee97-8292-e7db-202a6ba9bed8"), new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 9, 25, 35, 377, DateTimeKind.Local).AddTicks(2911), "Esmeralda_Bergnaum@gmail.com", null, null, "Rory", "Male", "Walker", "熄櫙宋츠␬ぐ嗝ﭟ㏯㽓", "�葫㟟倶訣䢘쳩汗謩", 2, null, null },
                    { new Guid("27d0f7c8-16f7-7ea8-5c9e-e1a54178d1b6"), new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 11, 6, 46, 38, 35, DateTimeKind.Local).AddTicks(1859), "Treva.Mante@gmail.com", null, null, "Roman", "Male", "Hartmann", "᪝૴懭渱픶嬔㽼袩⛐", "ߠ쀝ꠅ瀃࠶Ŵ蚶㈅ᔜ芄", 2, null, null },
                    { new Guid("284029fb-aea9-1935-dcfc-8fb5f78554ad"), new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 5, 6, 36, 48, 348, DateTimeKind.Local).AddTicks(3310), "Emile11@hotmail.com", null, null, "Eleazar", "Male", "Stehr", "딴랃粜䮢餪休먫값쓻", "㘣s►ꃔ꩎ᦢ挈眮㭭죦", 0, null, null },
                    { new Guid("2b11c3b8-2f3f-c69e-7e34-007a59ca09c0"), new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 29, 5, 33, 10, 856, DateTimeKind.Local).AddTicks(5321), "Noemie_Bergstrom64@yahoo.com", null, null, "Donato", "Female", "Mann", "籋螘떴䍥马䛊ﾦ沍譴", "ᛧՂ礡澲سꓴ䴮皮㧬", 0, null, null },
                    { new Guid("2b76e857-9906-7a30-c7c1-229cd8c67123"), new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 29, 7, 36, 12, 607, DateTimeKind.Local).AddTicks(2924), "Jameson_Boyle@gmail.com", null, null, "Kristoffer", "Female", "Moen", "띠嗟쯄뛉瞞뮖匩ꮮ鼝", "冷闲蜖勫쒍ꎠ壂鍹", 1, null, null },
                    { new Guid("2ba797b6-7264-f1ee-772f-97875e9c6965"), new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 12, 3, 54, 41, 768, DateTimeKind.Local).AddTicks(5994), "Peggie.Brown@hotmail.com", null, null, "Tremayne", "Female", "Gerhold", "䊶ﻟ㬥笇划쬴却Щ鑘�", "븂㘢ō뽢ꋪ仄늜诨핌", 0, null, null },
                    { new Guid("2c889ace-9f51-f3bf-2e20-5946ecc59a67"), new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 20, 28, 20, 811, DateTimeKind.Local).AddTicks(7425), "Wilmer_Mills@yahoo.com", null, null, "Agnes", "Male", "Kilback", "뗵掮竡々㏣녮䰺", "謚⬉릇厕㵦낛℀㸙ࢀ", 0, null, null },
                    { new Guid("2fb78f10-d5b3-84e0-00c4-c82e048d87a1"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 22, 14, 48, 31, 38, DateTimeKind.Local).AddTicks(2995), "Francesca41@gmail.com", null, null, "Isabell", "Male", "Bartell", "咒㛅嬖跜簼胴㳰뤍᰿爄", "츟ꞯ㳐쑯⹎뎁盞ﵗᣣⰂ", 1, null, null },
                    { new Guid("328f3de8-99ae-d915-9ee6-07ebd8a670f3"), new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 20, 1, 4, 0, 493, DateTimeKind.Local).AddTicks(5631), "Garnet.Beier27@yahoo.com", null, null, "Zoila", "Female", "Hane", "匨眬⚤縨Ƀ宺䖧", "㣦歅咁䊖밴ᶙ닋ꟁﶡ", 0, null, null },
                    { new Guid("33f9180a-fc32-aabb-a0b8-bba411a22ed7"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 5, 19, 37, 49, 978, DateTimeKind.Local).AddTicks(9750), "Logan.Kshlerin53@gmail.com", null, null, "Blake", "Male", "Reichert", "ዌꖎJ౬ꬉ貅螼⑉躻", "�汐ʸ玧䱢烬槻볓ෳ⵸", 1, null, null },
                    { new Guid("33fb6f8a-cf99-ff13-c495-26d528d861c1"), new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 30, 6, 13, 13, 655, DateTimeKind.Local).AddTicks(2157), "Justen_Stroman@hotmail.com", null, null, "Kristoffer", "Male", "Satterfield", "�줏먥펹Ỳ꺮䌐䢊", "볙尗뮅龜괃쌛潒쯌ᄆ", 1, null, null },
                    { new Guid("34708cce-5cb8-96db-e88d-67ef48aa1e05"), new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 19, 9, 38, 6, 473, DateTimeKind.Local).AddTicks(254), "Nicholaus_Maggio53@gmail.com", null, null, "Brady", "Female", "Dare", "朘遲蓕秤�辕㾨㷣�", "槂⚳╚頕垺ﱡ㈱随밉", 2, null, null },
                    { new Guid("3797a52d-1544-571d-9fd6-f3ada1878868"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 7, 10, 26, 5, 533, DateTimeKind.Local).AddTicks(5553), "Annetta_Rau@gmail.com", null, null, "Diana", "Male", "Volkman", "娶땡�﹔䬠翧�㴳㟡隊", "츣ۨҷꎮṑࡘ툙왌Ꮶ", 0, null, null },
                    { new Guid("38ce019a-f508-ae4b-5743-3ba114d967c4"), new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 5, 44, 15, 504, DateTimeKind.Local).AddTicks(7178), "Trinity39@yahoo.com", null, null, "Patsy", "Female", "Bauch", "㲚朊띬餭㿨⁦ꬢ⑓清", "㦲ᯕ⅕㪫뉒銠죂溠", 0, null, null },
                    { new Guid("3a36db39-70f4-f750-26f9-97f9d0c541e9"), new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 1, 9, 21, 50, 567, DateTimeKind.Local).AddTicks(6546), "Ryley92@yahoo.com", null, null, "Marlene", "Male", "Kling", "�ย鹞舥廫鱭뢖秽尫", "墁ﲽ莅춿㓵즚됼꼐찶", 1, null, null },
                    { new Guid("3b41dd43-2439-7e9a-3247-d430d11c1aca"), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 11, 5, 8, 13, 375, DateTimeKind.Local).AddTicks(2515), "Dee.Nitzsche56@gmail.com", null, null, "Nikki", "Male", "Herzog", "⩅鷘ᦷ峟❔䴍谸쁽寺", "ூ斠ꚡᚅ㇇ꯊ랚ꇿ䶱", 1, null, null },
                    { new Guid("3da8b2ef-ac58-c1bc-269e-1afad72a0522"), new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 20, 1, 31, 50, 937, DateTimeKind.Local).AddTicks(5973), "Lottie83@hotmail.com", null, null, "Halle", "Female", "Mayer", "쑍灶�音㑛妪利鲈ધҰ", "�⃅রꋬꍓ�漐뭷﫤", 2, null, null },
                    { new Guid("3eae0044-12f3-b0c6-0ca5-08b0a7f2230f"), new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 25, 23, 12, 8, 369, DateTimeKind.Local).AddTicks(9657), "Nyasia_Schimmel@yahoo.com", null, null, "Walker", "Male", "Kautzer", "뱿㊵後↪濓श΅툥識逻", "�祯㾑䁡횩ꕱ堍悻옥", 1, null, null },
                    { new Guid("3ff1e06a-c569-5a28-aa03-b21e765dc014"), new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 21, 2, 49, 6, 999, DateTimeKind.Local).AddTicks(9333), "Alena_Keeling@hotmail.com", null, null, "Melody", "Male", "Satterfield", "穻ꘗ朠ᚧ䰉尿쪰잵", "�ﺭ類ᤋ瘩竽應憵ⷺ", 1, null, null },
                    { new Guid("45d2733a-46cb-7949-c160-76834e4483cf"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 27, 2, 31, 33, 267, DateTimeKind.Local).AddTicks(8633), "Grady15@hotmail.com", null, null, "Edyth", "Male", "Mante", "阮➡㫒쿝띤╲陷骙偞圧", "昅⩪⚵灛吇䋎ⳉ뜌黹", 1, null, null },
                    { new Guid("45f32d40-7227-d303-d990-cfdac0c1991b"), new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 12, 4, 21, 22, 307, DateTimeKind.Local).AddTicks(6730), "Gaetano_Hagenes@yahoo.com", null, null, "Alyce", "Female", "Lesch", "턗叭ݍ؆爉�縩琲ᗤ觰", "稒樐콼ꘫ屛蚇템", 0, null, null },
                    { new Guid("466d5888-cfea-c213-bfc2-1bc479dc145e"), new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 31, 2, 54, 56, 50, DateTimeKind.Local).AddTicks(5035), "Harmony.OConnell3@gmail.com", null, null, "Trevor", "Male", "Senger", "쪳ᄕ촹쩆챮并켸", "擉䩄獢ᾭጘ壥馴༓볿", 1, null, null },
                    { new Guid("5091c787-9f7f-09b1-1ba3-a060a6a52e3d"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 31, 1, 47, 20, 528, DateTimeKind.Local).AddTicks(5044), "Ivah.Wuckert8@yahoo.com", null, null, "Alanna", "Male", "Wyman", "饄誨뫨뢓껰雕摞묟甔", "棴䬳┎矇후鈲쾮ﾦꙠ儷", 2, null, null },
                    { new Guid("579a32ec-1ef9-0323-c889-9b39cef68272"), new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 10, 17, 13, 25, 337, DateTimeKind.Local).AddTicks(8305), "Shaniya.Johns69@gmail.com", null, null, "Lucy", "Female", "Stracke", "营㉲Ҭ亡튄❎", "㐲쥡곖먓藠퍃問蒯츟罳", 0, null, null },
                    { new Guid("582a5e08-fd4d-3801-b2c0-63199fc76279"), new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 3, 23, 4, 8, 139, DateTimeKind.Local).AddTicks(9574), "Ernie.Lind85@hotmail.com", null, null, "Joshua", "Female", "Kerluke", "풩朁㵒츐薠䮫ꩴ톛改", "犤⤋攓�峚錝傣휱榪", 0, null, null },
                    { new Guid("597a13d8-231d-5e98-a5da-f20128f8cbaf"), new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 18, 3, 23, 58, 431, DateTimeKind.Local).AddTicks(695), "Miles31@yahoo.com", null, null, "Moriah", "Female", "Stiedemann", "䴬璦弘᎞굃뀫ㆣ덅�⌉", "瓗콿捕劥싥㋗圥�蕝", 1, null, null },
                    { new Guid("597a8e45-b68e-045d-b256-741fd2120ba6"), new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 17, 4, 18, 12, 738, DateTimeKind.Local).AddTicks(8003), "Lelah_Blick@hotmail.com", null, null, "Florencio", "Female", "Gusikowski", "㳪앍埨쫴핍擐皈徠饲챉", "灍삇辊錤ᘉ䥡䅜ꢢꗔ", 1, null, null },
                    { new Guid("5a829ffd-41b8-5369-9d2e-e4221c75ddc6"), new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 8, 2, 22, 42, 526, DateTimeKind.Local).AddTicks(3534), "Telly_Collier60@gmail.com", null, null, "Kyler", "Male", "Ledner", "汸䋎斊ẫ슔쐌倾̛", "ꌰ䍏┍ś辸ಳ搆", 0, null, null },
                    { new Guid("5b4beeec-511f-dc99-0ba1-236ef2dab8a9"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 20, 0, 6, 56, 777, DateTimeKind.Local).AddTicks(1814), "Amparo.Bailey59@yahoo.com", null, null, "Cedrick", "Female", "Cronin", "�隮浥䮢郸�釳ꤋ戦", "睞ꤲ㖸벜丒硚ﬗ", 1, null, null },
                    { new Guid("5cd65792-d673-a9e5-a469-b6b4fcfea53e"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 8, 11, 47, 3, 812, DateTimeKind.Local).AddTicks(642), "Dejuan.Rau@yahoo.com", null, null, "Theresia", "Male", "Marks", "’Ｉ䟑ᡋ蒞㯀孾✂쵊উ", "ັ焧䱵ᾤ幊솋윰ᦝ㠇색", 1, null, null },
                    { new Guid("62c5d4fb-ab60-a24c-3958-2113c0eb4dfa"), new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 21, 8, 36, 33, 830, DateTimeKind.Local).AddTicks(3600), "Ida.Homenick53@yahoo.com", null, null, "Alysha", "Male", "Barton", "暋㞹臻棜靍ݚ�냇쿷峜", "썹듄叽鬆�京쟖Óꉡ", 0, null, null },
                    { new Guid("63bd06ab-61ba-b20e-3d5e-26b7aa680666"), new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 11, 16, 56, 20, 75, DateTimeKind.Local).AddTicks(7404), "Libbie59@gmail.com", null, null, "Eddie", "Female", "Sauer", "兞龭㍃⽃뽠≵彾鎏೰", "긨僷康ﭙ朗۟敓ホ렘皙", 0, null, null },
                    { new Guid("6518fe02-02cc-6cc5-1d6d-78d0cffabc05"), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 5, 10, 4, 53, 15, DateTimeKind.Local).AddTicks(8225), "Adriana51@hotmail.com", null, null, "Emmett", "Male", "Rippin", "深㚏�㣬돁䈇Ⴞ൒", "蘵筌☂�眮ᒆ॒ড়둊", 0, null, null },
                    { new Guid("6caf8879-52f9-a83d-5663-c8f4423efe2c"), new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 4, 13, 10, 49, 381, DateTimeKind.Local).AddTicks(4966), "Jordy.Glover59@gmail.com", null, null, "Eudora", "Male", "Welch", "힎豹㸎嚛쩳薗ක㣣ᶷ忰", "뜹뽡ᠱ䶒õ霆⤛", 2, null, null },
                    { new Guid("6dba36c3-d8b3-aca7-fa77-b68e9164652b"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 18, 5, 31, 17, 270, DateTimeKind.Local).AddTicks(6780), "Wilson_Hammes94@gmail.com", null, null, "Forest", "Male", "Simonis", "뜉䑳究脣췢鉞崣郍Ꙙ掆", "妫�嶱絡胥贞웈氏꘮鐛", 1, null, null },
                    { new Guid("71db419c-bac0-b2c7-2809-d675eeeba8fc"), new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 5, 0, 4, 35, 647, DateTimeKind.Local).AddTicks(7093), "Shawn89@yahoo.com", null, null, "Nels", "Male", "Aufderhar", "ㅤ괽蠯䱎氷哝灍߭嘄", "蔵꡺繇ग䢣￥횟ጶ︚몶", 0, null, null },
                    { new Guid("77341573-6bcc-9b66-5878-24f78fa05da9"), new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 25, 23, 43, 40, 321, DateTimeKind.Local).AddTicks(8127), "Della_Schmitt@gmail.com", null, null, "Henriette", "Female", "Heathcote", "弖턐楳ꝉ崷ᬆ昴ꆺ첸", "ꢐᔍ悮脩꡵⏐ꐓ乭", 0, null, null },
                    { new Guid("791e1f57-9fec-5b56-8a06-08c446d84ef4"), new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 28, 5, 25, 20, 531, DateTimeKind.Local).AddTicks(3820), "Hilton.Howell@yahoo.com", null, null, "Amira", "Male", "Greenholt", "ᡤҜȲ尜埾諞낌嫢圞鞘", "슍搈蘾坍媅뮛蚻�쾞", 1, null, null },
                    { new Guid("794b98c3-7615-939a-f740-9c714bb98be5"), new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 30, 21, 32, 56, 951, DateTimeKind.Local).AddTicks(8062), "Melba.Renner@gmail.com", null, null, "Arvilla", "Male", "Langworth", "ਠ贯煬≒蒊க恎띋谢嫵", "惭琈茿ᆆ䅕ὦ殔዇", 0, null, null },
                    { new Guid("7f7f0723-2bcd-321b-29de-8739050e4e31"), new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 7, 16, 31, 46, 582, DateTimeKind.Local).AddTicks(1380), "Jolie_Jacobson@yahoo.com", null, null, "Raina", "Female", "Wiza", "륋슕腯坖噮巂辍协ɽ", "⻵賔ᓐ엌䦚⤂딷φ䓂", 0, null, null },
                    { new Guid("814180d1-0f08-0568-a5c3-ab1132298093"), new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 2, 21, 7, 29, 974, DateTimeKind.Local).AddTicks(772), "Cordia94@gmail.com", null, null, "Laury", "Female", "Shanahan", "䳈Ⱒ먋䡐撉⊼⾸ⶬתּ鱤", "상坥罕ꐸ爼邀窞ꝁ崑峛", 1, null, null },
                    { new Guid("84dc292a-35ef-ef22-f223-44db3e9e5e34"), new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 1, 2, 1, 54, 443, DateTimeKind.Local).AddTicks(6504), "Henri.Goodwin95@yahoo.com", null, null, "Hanna", "Male", "Von", "케⎕熅ㅽ᤽Ⅸ筞ಆ", "ᱥ趔碭陎⑊灖炕ㄽ混", 1, null, null },
                    { new Guid("85d2ae44-f4a8-2871-3a33-6aa13fc8a32e"), new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 14, 15, 6, 155, DateTimeKind.Local).AddTicks(7876), "Margie.Considine65@gmail.com", null, null, "Emmet", "Female", "Collins", "抉킭魀䶙﨨᫗뚥鶌룟", "X㾈ꁔ肇姘戲ꫮ䔱䀕쒥", 0, null, null },
                    { new Guid("8777fadd-723e-e160-b990-29fd2f338529"), new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 15, 15, 48, 21, 681, DateTimeKind.Local).AddTicks(8866), "Schuyler36@yahoo.com", null, null, "Dariana", "Male", "Howell", "⒂壯⍅Ӧ鿡טថ⋵麽", "śᴛՍ䧺퓶Ȕ伞쏸⪥콠", 1, null, null },
                    { new Guid("8ac522fa-1f03-3893-1d94-f274e8bc0ff2"), new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 25, 6, 55, 1, 314, DateTimeKind.Local).AddTicks(2035), "Isabelle_Fisher@yahoo.com", null, null, "Verla", "Male", "Ziemann", "흤ꤸ恠ꃌ水ꑆ灛৽", "ਮ๧鉣ꅠ䛌삠﫠߮", 1, null, null },
                    { new Guid("8af91e79-e926-0ba0-519b-04078d2d2041"), new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 4, 10, 35, 46, 383, DateTimeKind.Local).AddTicks(7956), "Willard.Beatty2@yahoo.com", null, null, "Gerda", "Female", "Schowalter", "屚ꃏ샘⣗⓴䬢幹ᆳ릾", "븫ﰘ㣚萈蘚䑋빆₢퀆⚯", 1, null, null },
                    { new Guid("8b1b206b-10da-70df-6f94-1fb2084c2d53"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 11, 10, 26, 13, 379, DateTimeKind.Local).AddTicks(8352), "Clyde_Daugherty@yahoo.com", null, null, "Orin", "Male", "Hane", "㞲ॎ伋呷傒�葹摔먎ਸ਼", "翬墤숒恂삔˂裆ᰢ", 2, null, null },
                    { new Guid("8c8dac88-5d3b-1e80-cfb1-e3d2a4b9cbca"), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 16, 4, 28, 40, 862, DateTimeKind.Local).AddTicks(6661), "Leif.Nader73@gmail.com", null, null, "Manuel", "Male", "Wuckert", "쯞篏륰뺴Ｌ♖秴Ჟ", "氕볋숌䟄槿瓘쬱탄脡", 2, null, null },
                    { new Guid("8cbcf5df-efae-457f-c9b3-0891a77031da"), new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 23, 10, 14, 13, 519, DateTimeKind.Local).AddTicks(4359), "Lela_Borer@gmail.com", null, null, "Lesley", "Female", "Wolff", "᳽蠏呫Ӣ㮃浵旭", "ꏝ�庢㖸谎촽ꇪ㒘䍞", 1, null, null },
                    { new Guid("8f7cbc77-5ce3-1445-379d-39c3e97dd222"), new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 8, 8, 51, 51, 818, DateTimeKind.Local).AddTicks(8512), "Petra71@yahoo.com", null, null, "Willard", "Male", "Hills", "⟥㎅⻎ꖶ葨੥촐飷誾ࠕ", "덧蒲곛䨠룮⎉仐棐ṁ", 1, null, null },
                    { new Guid("900f44d7-2494-c44c-1d9d-32bc18375f8a"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 14, 3, 2, 50, 323, DateTimeKind.Local).AddTicks(6148), "Idella.Hamill@gmail.com", null, null, "Hailee", "Female", "Fay", "㇧얙ᄪ�잔", "彠ㅿ젤��⊂᪄㑑", 0, null, null },
                    { new Guid("96488a78-dca7-a138-574e-73f0967e3b99"), new DateTime(2023, 10, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 9, 12, 35, 3, 358, DateTimeKind.Local).AddTicks(4438), "Dale96@gmail.com", null, null, "Adah", "Male", "Mann", "塉̱ޭǽ筀ྠ방뒢ꃰ弨", "侺ꮏ贎壘ō凤䇈둇�", 1, null, null },
                    { new Guid("99276973-3fee-bbf7-1f33-82a1c5ec51d4"), new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 8, 6, 18, 26, 869, DateTimeKind.Local).AddTicks(486), "Roxane.Weber35@yahoo.com", null, null, "Vito", "Female", "Skiles", "ⅇ뇱縤᜺퓗鰉끑幡⮚", "逧핼촐雳渄ᶺ䌱◻遳穯", 0, null, null },
                    { new Guid("9b31c41f-2b65-814f-63ae-b2ca7e95e69d"), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 17, 1, 43, 58, 684, DateTimeKind.Local).AddTicks(3767), "Samir_Blick@hotmail.com", null, null, "Boyd", "Female", "Dietrich", "㷝엒⬑ꒈଚ牳慖≄蒂ﷷ", "᫂⛤뿖ミ咄쒑粌�ᇪ㊈", 1, null, null },
                    { new Guid("9bf87d2a-7043-0562-fda6-ce327ed3b37b"), new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 2, 0, 37, 57, 406, DateTimeKind.Local).AddTicks(6754), "Brennon69@yahoo.com", null, null, "Emilio", "Female", "Kunze", "꫋ᴝ䀏ꪊᔏ쭙爢с谌套", "긏⋓᧯㳆햸콘䣕ﴍ㉷臕", 1, null, null },
                    { new Guid("9e217ff9-5d3e-019a-a14c-5431c1931e28"), new DateTime(2023, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 2, 7, 11, 37, 427, DateTimeKind.Local).AddTicks(6180), "Nellie.Beer59@gmail.com", null, null, "Tavares", "Male", "O'Reilly", "䐢ᾶ忸�௕偋䕄㢮뾊ﴭ", "䇀ﳡꔯ碚唀₝？そ", 1, null, null },
                    { new Guid("a2bb0320-ea48-a8b3-a601-9d55ef8c2d9d"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 2, 19, 37, 8, 265, DateTimeKind.Local).AddTicks(5714), "Vergie_Labadie@yahoo.com", null, null, "Lavonne", "Male", "Franecki", "�愶�ꎔ歺↚帠蚌춢", "ﰰ苔룶≲ꓰ৆硕皾쿝볁", 1, null, null },
                    { new Guid("a9547b4a-ba3e-5276-1ba5-be8f95760556"), new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 8, 15, 15, 0, 842, DateTimeKind.Local).AddTicks(8256), "Gwen_Walsh@yahoo.com", null, null, "Camila", "Female", "Wintheiser", "郟꯫吐꯱퇷抗ႌ茑핃", "⢶慂ꋩҁ윮㭉㸫㞊砚", 1, null, null },
                    { new Guid("aa0f09df-e92b-463c-eab3-c2ea1b9ecbe5"), new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 19, 4, 14, 52, 731, DateTimeKind.Local).AddTicks(724), "Ally27@yahoo.com", null, null, "Braxton", "Female", "Leffler", "珖ُ缋㺳欴䑹禥檪屣", "傜ꢫ꬈䐠ɸ鈶ྒ", 1, null, null },
                    { new Guid("b09bb99d-0864-88ba-00e8-2d64874ec64f"), new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 5, 23, 0, 10, 468, DateTimeKind.Local).AddTicks(5952), "Isaiah_Schneider@hotmail.com", null, null, "Beth", "Male", "Johns", "䵥抨髚䀕ዛ橆�爆⢳雈", "蟮쓱ﱻᄚ齻牁聵퐻", 0, null, null },
                    { new Guid("b19f58be-1188-b29c-64b9-6f6724a9f668"), new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 19, 2, 17, 20, 984, DateTimeKind.Local).AddTicks(8271), "Frances97@gmail.com", null, null, "Jacquelyn", "Male", "Funk", "ᖔ︾ꆙ퇽㒉า㒾笪錦", "췸࢐ꋈ䠥⦙읊荄烦", 2, null, null },
                    { new Guid("b22cbbb9-4252-4faa-655d-daeb92251150"), new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 10, 6, 44, 24, 652, DateTimeKind.Local).AddTicks(1081), "Cortney.Shanahan33@hotmail.com", null, null, "Ben", "Female", "Schowalter", "ᗫ伣�箄䊕࠷�↫죬", "퐵ᔸࡳ蚕씄瞒懺ꀏᑮ⯵", 1, null, null },
                    { new Guid("b44be0b7-976d-8822-fce8-d546597595e7"), new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 18, 10, 2, 40, 974, DateTimeKind.Local).AddTicks(5362), "Daren40@hotmail.com", null, null, "Sofia", "Male", "Pouros", "剸ࣵ폻苄汉﫣ꋯ㇛੅", "뢍ァ⳽⤵ꎿ㮭ꟹ輏畉ⶰ", 0, null, null },
                    { new Guid("b5e7d1ee-31a3-e9cb-d480-6150f182287f"), new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 28, 20, 15, 16, 728, DateTimeKind.Local).AddTicks(5559), "Breana_Williamson39@hotmail.com", null, null, "Maurice", "Male", "Rogahn", "ɢ核爍⋷枢䴽뺠᝽蹦", "⏇廦勋⬸⼅詪鴨ꕜ왐숅", 2, null, null },
                    { new Guid("bd57575b-6506-edfb-da26-2bc9da462e2a"), new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 9, 12, 9, 40, 764, DateTimeKind.Local).AddTicks(112), "Elouise_Ratke@hotmail.com", null, null, "Ressie", "Female", "Rutherford", "霩㜾먾꤮珿ꐄ㜆⊳⟓猙", "䢦뵕劜ボ悟䤋拾攛鰝", 1, null, null },
                    { new Guid("bf29eaa5-ea7b-3aba-1f68-083f94a7f8e1"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 19, 6, 1, 3, 196, DateTimeKind.Local).AddTicks(1795), "Salvador63@yahoo.com", null, null, "Maximillian", "Female", "Kerluke", "批᫗袵샘ᑱתּꟳ螏ﶧ", "聶拂삟྅螿珪⇮㶂ꁕ", 0, null, null },
                    { new Guid("c0b6faf8-93be-e88d-8dd1-dc8e06409e07"), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 6, 10, 19, 5, 0, DateTimeKind.Local).AddTicks(3657), "Jarvis82@yahoo.com", null, null, "Dean", "Female", "Hoeger", "즯О깧섷ﻢ짗蔑勢ຓ", "腸暛᥽直⋾弜蹼݊", 2, null, null },
                    { new Guid("c25eb813-a961-bb95-c542-5a40df26e901"), new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 30, 9, 32, 33, 536, DateTimeKind.Local).AddTicks(4098), "Maximillia20@gmail.com", null, null, "Jonatan", "Male", "Nikolaus", "आ뇁迾秥蝔뷦捾ᲇ舨뤠", "ᶸꇩ먅릃괡�⤶淴걇ü", 2, null, null },
                    { new Guid("c2dfcecc-f60e-4feb-fe60-d089d31197c9"), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 18, 23, 56, 11, 160, DateTimeKind.Local).AddTicks(6998), "Rae_Kertzmann85@gmail.com", null, null, "Henderson", "Male", "Hand", "씭쮅䲾൴栎흄㞵荿䙸", "⼦㌏೑水Ϗᙫ찪", 2, null, null },
                    { new Guid("c4334d3b-4612-366d-7a90-25ab7a7d5c76"), new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 7, 11, 3, 36, 726, DateTimeKind.Local).AddTicks(611), "Edythe20@yahoo.com", null, null, "Ayana", "Female", "Strosin", "꿳뢟㛦뒰烰㯎㚁䤢", "闪�捞嵯랄鯿൤ﳖ", 0, null, null },
                    { new Guid("c5436476-f46f-6d25-11cb-6b4d024ef980"), new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 20, 20, 28, 18, 519, DateTimeKind.Local).AddTicks(8703), "Percival28@yahoo.com", null, null, "Taryn", "Female", "Gerlach", "뤶叒ﴞ篫쐇졕ꩊ䱲", "嶬妺퍤瞅쵹ƃ趪㴗䇅", 2, null, null },
                    { new Guid("c872bb1c-95bf-3f12-7d35-dad9ac028d73"), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 22, 2, 39, 1, 607, DateTimeKind.Local).AddTicks(114), "Jeffrey_Kunde69@hotmail.com", null, null, "Matilde", "Female", "Smitham", "竆衧吴ᢕ轩丒ೂ扗", "䘰省퐪䖗岻쟼㏦ⶊ孃", 2, null, null },
                    { new Guid("c92d943a-66ca-3d0f-8221-69e9bed1d7f4"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 27, 2, 50, 59, 24, DateTimeKind.Local).AddTicks(1810), "Ruby_Wisozk@yahoo.com", null, null, "Judah", "Male", "Kihn", "䪫懍齃Ꙣ奰㿥", "⢐栎챾躴잯儥쉘錷綕፠", 1, null, null },
                    { new Guid("ca8bf803-dc46-61be-0f50-068306050467"), new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 13, 1, 20, 35, 115, DateTimeKind.Local).AddTicks(9223), "Josiah25@gmail.com", null, null, "Leonor", "Female", "Dibbert", "䏑僌䮴ﻅউ뎗宐䝿婁ⴟ", "쵭馪�槊㌧곫�酑檦၅", 2, null, null },
                    { new Guid("ccb75935-a6ed-9592-d8c7-60c2d5ce72e0"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 4, 4, 6, 6, 795, DateTimeKind.Local).AddTicks(5225), "Crystel54@hotmail.com", null, null, "Everett", "Female", "Romaguera", "笮튋俩�싁⃯嵊윚䶸", "ԏ힏닜핼椒滓ฃ", 1, null, null },
                    { new Guid("d86ea596-b075-6aa3-71b3-60944262c081"), new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 18, 11, 41, 6, 365, DateTimeKind.Local).AddTicks(3021), "Elliott.Brakus57@hotmail.com", null, null, "Desmond", "Female", "Purdy", "癵๬ఌឆ鞡⿶츔㐩", "㽊㓙◠躒⃬忼뽿풨", 1, null, null },
                    { new Guid("e3a6e995-8787-bd42-49f1-dccd86eeafb8"), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 17, 16, 5, 42, 738, DateTimeKind.Local).AddTicks(1130), "Claud_Daniel@hotmail.com", null, null, "Alvera", "Male", "Jerde", "䬻᳟毎힌䆠莆핎ퟟ⯞", "㺥廨㡴٠ ᾝ㘭ꖚ㮐ជ", 2, null, null },
                    { new Guid("e3cb89ea-a4f5-c71a-da5f-b50bb1bc5a76"), new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 26, 20, 49, 59, 311, DateTimeKind.Local).AddTicks(3770), "Erika.Bode@yahoo.com", null, null, "Angeline", "Female", "Lebsack", "햚ॳ立滤룾䔃쯑ἠ", "ဦ䕌䋿쐄漄᭚뜖㡾呏ጽ", 0, null, null },
                    { new Guid("e84334a4-5359-c309-7092-79ed735a2d64"), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 3, 2, 55, 6, 886, DateTimeKind.Local).AddTicks(2671), "Isabell_Yost80@gmail.com", null, null, "Isaiah", "Male", "Langosh", "氿뿚貨洫ự胅鑗䫫", "�쭺狾辡㇒丹⁩謩ᾇ", 0, null, null },
                    { new Guid("ecf0df93-9b08-b00c-8b68-8485649878b4"), new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 4, 18, 48, 46, 962, DateTimeKind.Local).AddTicks(2980), "Lucinda.Robel52@hotmail.com", null, null, "Tavares", "Female", "Schmeler", "꺝⟑搾磧멇ͣ탾㛶ฦ", "妈瑟ᙤ앬油霙똮劝ᘼҞ", 0, null, null },
                    { new Guid("ee944e9e-22fb-92c1-1a6b-5062115984a0"), new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 25, 5, 0, 22, 456, DateTimeKind.Local).AddTicks(749), "Chelsie_Greenholt@yahoo.com", null, null, "Louvenia", "Male", "Gutkowski", "鑩俻�菶儱�暐㖥垶糈", "狫숈䑜㸇鎈献뉿", 2, null, null },
                    { new Guid("ef0ed8be-7d3f-7684-4e9d-9c725917a044"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 25, 14, 8, 28, 339, DateTimeKind.Local).AddTicks(4639), "Kristina_Fritsch97@hotmail.com", null, null, "Kailyn", "Female", "Dare", "ັ䷼⑜ꒃⱫ谐勜曦�㋆", "蚈廒⅘套힧´﹊軼Ằ", 2, null, null },
                    { new Guid("f131c3ca-01c9-334a-76d7-db4d92ac1b1e"), new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 8, 23, 15, 596, DateTimeKind.Local).AddTicks(6890), "Nettie.Turner26@hotmail.com", null, null, "Adolph", "Female", "McLaughlin", "♚朜Ы㏜ߘ吋쵣葮쭐", "ꋶ⿸Ồ셰�暸잵�䂫", 0, null, null },
                    { new Guid("f37d3093-a3f4-2709-2297-73eeb2cb1e25"), new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 17, 14, 52, 20, 945, DateTimeKind.Local).AddTicks(5485), "Jeramy36@yahoo.com", null, null, "Ewell", "Male", "Mante", "鵊ରטּ⯷뜏쨚䭍닱", "編쵱逼눳眳�艞ﵧஔ", 1, null, null },
                    { new Guid("f4df87e2-b955-bfbd-fe03-73b393fd65b3"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 2, 1, 46, 34, 614, DateTimeKind.Local).AddTicks(5139), "Sedrick.Koss@hotmail.com", null, null, "Jameson", "Female", "Kuhlman", "䬻孌撿饗멤お殱붾튩஧", "賩畱ᚍ쳿훓룩ꐎ擐蒢", 1, null, null },
                    { new Guid("f5799447-fdd4-7061-6a6e-dae5db6f9693"), new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 26, 4, 47, 56, 3, DateTimeKind.Local).AddTicks(1174), "Jean59@hotmail.com", null, null, "Filiberto", "Female", "Gerlach", "୿忩毄䶲ヹ윗ၽረ뮅䊹", "熒㩡般ﷶ䕹䪁腵뛓", 0, null, null },
                    { new Guid("f89ecefd-822f-3293-e6dd-83a823a42ace"), new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 10, 13, 47, 35, 52, DateTimeKind.Local).AddTicks(4191), "Bette.Lemke11@hotmail.com", null, null, "Leonie", "Male", "Davis", "脵䨖붆骭笹⭻䜯탞旁", "걙ⵌ㶘尙荑＠鼖隯", 1, null, null },
                    { new Guid("fadc0569-4c48-63dd-9ee4-3d45adabbac9"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 21, 3, 44, 16, 470, DateTimeKind.Local).AddTicks(4812), "Trystan_Tillman77@yahoo.com", null, null, "Aurore", "Male", "Monahan", "颔ꌲ䤖轼志웣㋽欄꥓ȡ", "᧲에빎夌谔灘韂幛ᡆ", 1, null, null },
                    { new Guid("fcf39862-abf5-b06f-a0fc-bda199d5ea48"), new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 27, 11, 5, 33, 317, DateTimeKind.Local).AddTicks(6616), "Meghan.Koss99@yahoo.com", null, null, "Thomas", "Male", "Roberts", "鲈♸䷰팡ÖøϷ䡶", "龍囂☧솸姸聋៴퓴ᖣ", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "Barangay", "City", "Country", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EmployeeId", "Line1", "Line2", "Province", "Status", "Type", "UpdatedAt", "UpdatedBy", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("00ab3df8-6bcf-e08d-cfe9-0701b0f7aa21"), "Arizona", "West Dovie", "Canada", new DateTime(2024, 6, 11, 3, 16, 34, 620, DateTimeKind.Local).AddTicks(4274), "Isidro.Lebsack@yahoo.com", null, null, new Guid("e3cb89ea-a4f5-c71a-da5f-b50bb1bc5a76"), "419 Fae Mount", "Expressway", "Idaho", 2, 0, null, null, "22077-5493" },
                    { new Guid("08382ccd-fc9a-d6e0-cbdf-b61568c23721"), "Florida", "North Dennisfurt", "Uzbekistan", new DateTime(2024, 6, 13, 20, 4, 45, 468, DateTimeKind.Local).AddTicks(8408), "Deondre19@hotmail.com", null, null, new Guid("38ce019a-f508-ae4b-5743-3ba114d967c4"), "436 Alysa Lodge", "Mission", "Delaware", 1, 2, null, null, "42100-5490" },
                    { new Guid("0b3512bc-cb3f-ef62-dd38-7a93e445a44a"), "Washington", "Walkerchester", "Comoros", new DateTime(2024, 2, 10, 4, 5, 4, 692, DateTimeKind.Local).AddTicks(5011), "Frederique_Olson50@yahoo.com", null, null, new Guid("fcf39862-abf5-b06f-a0fc-bda199d5ea48"), "59525 Grimes Parkways", "Shores", "Illinois", 0, 2, null, null, "72060" },
                    { new Guid("0bfbeca9-0262-2982-7e55-52618974cdc1"), "Louisiana", "Port Aliceton", "Tokelau", new DateTime(2024, 6, 21, 13, 9, 51, 221, DateTimeKind.Local).AddTicks(4221), "Bernita60@hotmail.com", null, null, new Guid("2fb78f10-d5b3-84e0-00c4-c82e048d87a1"), "5431 Silas Trail", "Stream", "West Virginia", 0, 0, null, null, "22834-8118" },
                    { new Guid("1d8a449c-afa2-9a3f-e50c-0b7a2fc0dbb9"), "Ohio", "Port Ebba", "Chile", new DateTime(2024, 6, 19, 12, 51, 34, 661, DateTimeKind.Local).AddTicks(2633), "Ericka_Kohler53@gmail.com", null, null, new Guid("466d5888-cfea-c213-bfc2-1bc479dc145e"), "94642 West Mountain", "Heights", "Minnesota", 0, 1, null, null, "79071-3217" },
                    { new Guid("2622e747-7ba6-8a9f-7d9b-79cb5aab5eae"), "Montana", "New Alysha", "Cote d'Ivoire", new DateTime(2024, 6, 4, 2, 48, 7, 447, DateTimeKind.Local).AddTicks(7530), "Pablo39@hotmail.com", null, null, new Guid("2121b38f-a594-09a8-e0fe-24e797f1dd96"), "5671 Gorczany Meadows", "Point", "Minnesota", 1, 1, null, null, "15821" },
                    { new Guid("2c290290-6ee4-0560-5bae-635198fcaed0"), "Iowa", "Port Javonstad", "Argentina", new DateTime(2023, 12, 21, 6, 44, 44, 858, DateTimeKind.Local).AddTicks(7199), "Howell.Shanahan89@gmail.com", null, null, new Guid("5cd65792-d673-a9e5-a469-b6b4fcfea53e"), "5225 Alexandrine Flats", "Vista", "Montana", 2, 0, null, null, "27837-9764" },
                    { new Guid("330b91e5-c707-0e3c-9376-7390a7479cec"), "California", "East Kiel", "Uganda", new DateTime(2024, 9, 3, 9, 30, 53, 778, DateTimeKind.Local).AddTicks(3412), "Yasmeen_Corwin22@gmail.com", null, null, new Guid("ecf0df93-9b08-b00c-8b68-8485649878b4"), "8522 Javier Corner", "Roads", "Montana", 2, 0, null, null, "84333" },
                    { new Guid("38887cdc-e899-aea6-c81d-dd7c8f2e308d"), "Connecticut", "Larkinmouth", "Jordan", new DateTime(2023, 12, 13, 0, 47, 29, 289, DateTimeKind.Local).AddTicks(3864), "Lorenz.Hand@yahoo.com", null, null, new Guid("33fb6f8a-cf99-ff13-c495-26d528d861c1"), "0316 Nakia View", "Grove", "Alabama", 0, 0, null, null, "96047" },
                    { new Guid("3ded91ba-8935-05c3-9d9c-ab9056754d13"), "Massachusetts", "North Glenniemouth", "Turkmenistan", new DateTime(2024, 6, 8, 21, 19, 22, 398, DateTimeKind.Local).AddTicks(2314), "Nelson26@yahoo.com", null, null, new Guid("fadc0569-4c48-63dd-9ee4-3d45adabbac9"), "659 Christy Meadow", "Avenue", "Mississippi", 0, 1, null, null, "55871" },
                    { new Guid("403b888c-f0ec-88cd-e982-9d0dd5d0c5e7"), "Oklahoma", "Lake Grady", "Turkey", new DateTime(2024, 3, 7, 2, 43, 10, 952, DateTimeKind.Local).AddTicks(8095), "Verna_Kunde@hotmail.com", null, null, new Guid("8777fadd-723e-e160-b990-29fd2f338529"), "2012 Tromp Flats", "Club", "New Mexico", 0, 2, null, null, "54192" },
                    { new Guid("42491b8e-88a0-0f0c-778f-0d24c55c62d8"), "Illinois", "West Judy", "French Guiana", new DateTime(2024, 5, 11, 9, 3, 6, 796, DateTimeKind.Local).AddTicks(3189), "Alek_Gerhold60@yahoo.com", null, null, new Guid("13e1a3e1-e43c-1e6e-cb54-2063010dc7c4"), "472 Wintheiser Forks", "Mount", "Vermont", 0, 2, null, null, "64685-0422" },
                    { new Guid("4684f76d-aff3-2554-81c0-da16ee38cef1"), "Illinois", "Sauerland", "San Marino", new DateTime(2024, 3, 12, 15, 4, 11, 787, DateTimeKind.Local).AddTicks(530), "Gerardo98@hotmail.com", null, null, new Guid("0105ce8f-a89c-5b5f-fb99-5a82f4e6ff74"), "60871 Fahey Extension", "Trail", "California", 2, 1, null, null, "85822-0505" },
                    { new Guid("4717714c-2766-83f6-ff53-5794661ef217"), "Alaska", "Beiertown", "Samoa", new DateTime(2024, 7, 18, 21, 26, 25, 252, DateTimeKind.Local).AddTicks(6858), "Santiago.Miller10@yahoo.com", null, null, new Guid("8b1b206b-10da-70df-6f94-1fb2084c2d53"), "05727 Annamarie Divide", "Avenue", "Wisconsin", 1, 1, null, null, "84052-7292" },
                    { new Guid("4c39da38-4bf6-84ac-b69b-cb5e0501095d"), "Vermont", "East Easterside", "Thailand", new DateTime(2024, 10, 1, 19, 14, 43, 907, DateTimeKind.Local).AddTicks(9636), "Toney57@yahoo.com", null, null, new Guid("f89ecefd-822f-3293-e6dd-83a823a42ace"), "17396 Adelia Terrace", "Gardens", "New Mexico", 0, 1, null, null, "63179-4337" },
                    { new Guid("577261e2-7a0a-7122-1f40-4f094214ab77"), "West Virginia", "Naomiville", "Malaysia", new DateTime(2023, 12, 30, 5, 18, 33, 161, DateTimeKind.Local).AddTicks(1290), "Brant46@hotmail.com", null, null, new Guid("6caf8879-52f9-a83d-5663-c8f4423efe2c"), "76911 Will Village", "Curve", "North Dakota", 0, 2, null, null, "48212-8089" },
                    { new Guid("58b7b028-7a3a-76e6-a334-d4c847942e3c"), "Texas", "East Luigi", "Colombia", new DateTime(2024, 3, 2, 2, 25, 12, 594, DateTimeKind.Local).AddTicks(6146), "Delphia.Feeney96@hotmail.com", null, null, new Guid("794b98c3-7615-939a-f740-9c714bb98be5"), "1370 Hildegard Underpass", "Locks", "Wyoming", 1, 1, null, null, "99295" },
                    { new Guid("5ee88a31-3dea-4f3d-4f7e-5ade0ce39751"), "Oklahoma", "North Jedediah", "Mexico", new DateTime(2024, 6, 14, 22, 8, 14, 982, DateTimeKind.Local).AddTicks(9137), "Gerard.Kling14@hotmail.com", null, null, new Guid("1b64513b-afd4-cc1d-70f5-3ae1fc10fb93"), "2267 Rosenbaum Mountain", "Valleys", "Florida", 1, 2, null, null, "44784" },
                    { new Guid("60293afe-9f1e-3046-f311-9600b9c44d38"), "Mississippi", "Halvorsonchester", "Lebanon", new DateTime(2024, 2, 29, 12, 40, 43, 958, DateTimeKind.Local).AddTicks(8479), "Ronny.Schiller45@yahoo.com", null, null, new Guid("1e38db0d-db28-5f5c-4efa-604b4f119ac5"), "403 Gabrielle Skyway", "Summit", "New Hampshire", 0, 2, null, null, "35722-6141" },
                    { new Guid("62a4ec2f-63de-1ed1-499d-12a4b4b8dd85"), "Missouri", "Sallymouth", "Denmark", new DateTime(2024, 7, 16, 23, 16, 35, 563, DateTimeKind.Local).AddTicks(9696), "Jake_Rempel56@gmail.com", null, null, new Guid("ccb75935-a6ed-9592-d8c7-60c2d5ce72e0"), "580 Elyse Avenue", "Canyon", "Indiana", 1, 2, null, null, "55677" },
                    { new Guid("69ebc0ee-143d-8bf0-f08e-fbba6cf55187"), "New Mexico", "New Ulises", "Zambia", new DateTime(2024, 7, 19, 17, 10, 12, 142, DateTimeKind.Local).AddTicks(2513), "Jessie_Yost15@yahoo.com", null, null, new Guid("f89ecefd-822f-3293-e6dd-83a823a42ace"), "1514 Parisian Extensions", "Meadows", "Michigan", 2, 0, null, null, "27462" },
                    { new Guid("6bb53455-2c4c-23a5-53bd-21df007d31f7"), "Michigan", "Lake Rebeccaburgh", "Tunisia", new DateTime(2024, 5, 28, 16, 5, 50, 535, DateTimeKind.Local).AddTicks(2044), "Murl_Hermiston@gmail.com", null, null, new Guid("d86ea596-b075-6aa3-71b3-60944262c081"), "46616 Una Haven", "Pine", "Illinois", 1, 1, null, null, "78492" },
                    { new Guid("6de7284a-fd98-d8ce-8ce3-fe77a9744be1"), "Illinois", "Westside", "Solomon Islands", new DateTime(2024, 11, 7, 20, 36, 53, 605, DateTimeKind.Local).AddTicks(1108), "Roberto79@yahoo.com", null, null, new Guid("3b41dd43-2439-7e9a-3247-d430d11c1aca"), "043 Greenholt Branch", "View", "Texas", 0, 0, null, null, "53438-5128" },
                    { new Guid("6f651d6b-635b-4698-e988-7fd4ea06a83d"), "Vermont", "Mathiasville", "Bahamas", new DateTime(2024, 10, 1, 13, 33, 19, 192, DateTimeKind.Local).AddTicks(9770), "Viviane64@yahoo.com", null, null, new Guid("8ac522fa-1f03-3893-1d94-f274e8bc0ff2"), "3851 Howell Fork", "Stravenue", "Arizona", 0, 0, null, null, "75853-7411" },
                    { new Guid("7724778b-b751-0eb6-a568-563a1303c449"), "Kentucky", "Port Brendanside", "Dominica", new DateTime(2024, 11, 1, 17, 45, 37, 356, DateTimeKind.Local).AddTicks(7490), "Gretchen_Stanton96@gmail.com", null, null, new Guid("ecf0df93-9b08-b00c-8b68-8485649878b4"), "12180 Zemlak Field", "Fields", "Colorado", 0, 1, null, null, "51225-8376" },
                    { new Guid("78c0a525-c502-856d-9315-afe60a769139"), "Florida", "South Audreyshire", "Bermuda", new DateTime(2024, 2, 13, 22, 38, 56, 667, DateTimeKind.Local).AddTicks(3231), "Maud_Towne26@yahoo.com", null, null, new Guid("7f7f0723-2bcd-321b-29de-8739050e4e31"), "763 Schulist Pass", "Greens", "Kentucky", 0, 2, null, null, "12182-9472" },
                    { new Guid("823420ed-f6ea-5e72-d5c3-2b3f7cefb11e"), "North Carolina", "Valerieville", "Gambia", new DateTime(2024, 5, 15, 6, 17, 26, 119, DateTimeKind.Local).AddTicks(9044), "Fernando26@gmail.com", null, null, new Guid("c4334d3b-4612-366d-7a90-25ab7a7d5c76"), "34790 Jalyn Islands", "Spurs", "Utah", 0, 1, null, null, "96935" },
                    { new Guid("84fce474-0455-e562-b865-633f5d510b6c"), "Washington", "South Maddison", "Solomon Islands", new DateTime(2024, 10, 9, 17, 43, 13, 355, DateTimeKind.Local).AddTicks(6361), "Keon_Luettgen41@gmail.com", null, null, new Guid("5a829ffd-41b8-5369-9d2e-e4221c75ddc6"), "22371 Thurman Plain", "Highway", "Arkansas", 2, 1, null, null, "59920" },
                    { new Guid("8fbd3738-dae4-c8c6-1768-2530ac074b54"), "Georgia", "Ambroseberg", "Czech Republic", new DateTime(2024, 3, 17, 6, 14, 0, 575, DateTimeKind.Local).AddTicks(1779), "Juliet62@yahoo.com", null, null, new Guid("7f7f0723-2bcd-321b-29de-8739050e4e31"), "224 Bryana Ridge", "Inlet", "Wyoming", 1, 1, null, null, "95778" },
                    { new Guid("90445977-c96b-dfc3-c9e9-b2aaac90e3ad"), "Washington", "Pourostown", "Fiji", new DateTime(2024, 3, 22, 9, 40, 10, 534, DateTimeKind.Local).AddTicks(219), "Tia.Mayert87@hotmail.com", null, null, new Guid("38ce019a-f508-ae4b-5743-3ba114d967c4"), "762 Grant Islands", "Knolls", "South Carolina", 0, 0, null, null, "10438-8351" },
                    { new Guid("95d84cc5-a8b0-9de5-013f-a72588fa6f99"), "Georgia", "West Edna", "Mexico", new DateTime(2024, 5, 1, 6, 21, 6, 448, DateTimeKind.Local).AddTicks(5906), "Ernestina14@gmail.com", null, null, new Guid("8c8dac88-5d3b-1e80-cfb1-e3d2a4b9cbca"), "1908 Hoeger Path", "Valleys", "Oregon", 2, 2, null, null, "07130-1113" },
                    { new Guid("9cf0904f-59e0-8518-ad99-06c09840dbbd"), "New Hampshire", "Robertsland", "Monaco", new DateTime(2024, 7, 21, 10, 23, 15, 985, DateTimeKind.Local).AddTicks(5341), "Alena91@hotmail.com", null, null, new Guid("34708cce-5cb8-96db-e88d-67ef48aa1e05"), "36967 Wiley Roads", "Run", "Kentucky", 2, 1, null, null, "93456" },
                    { new Guid("a002c61a-5e4b-6003-0d31-cbcd5bf90033"), "Arkansas", "Winonaton", "Croatia", new DateTime(2024, 10, 15, 6, 28, 22, 400, DateTimeKind.Local).AddTicks(7630), "Rocky.Gleason@gmail.com", null, null, new Guid("2c889ace-9f51-f3bf-2e20-5946ecc59a67"), "2809 Altenwerth Isle", "Shores", "Alaska", 1, 0, null, null, "62162-4999" },
                    { new Guid("a458b596-753d-5724-8ba9-c84cc3a20677"), "Oklahoma", "Juddfurt", "France", new DateTime(2024, 8, 9, 19, 59, 4, 32, DateTimeKind.Local).AddTicks(1875), "Arlene_Buckridge@hotmail.com", null, null, new Guid("2fb78f10-d5b3-84e0-00c4-c82e048d87a1"), "443 Mercedes Vista", "Views", "New Jersey", 2, 2, null, null, "65491" },
                    { new Guid("a9f5fc5b-49c1-0836-212c-3aaf907c503f"), "Massachusetts", "Greenholtshire", "Iraq", new DateTime(2024, 2, 26, 17, 58, 25, 465, DateTimeKind.Local).AddTicks(2458), "Mathilde25@gmail.com", null, null, new Guid("9b31c41f-2b65-814f-63ae-b2ca7e95e69d"), "76105 Adrienne Locks", "Isle", "Idaho", 2, 1, null, null, "72140-5697" },
                    { new Guid("b1546f71-0a36-d7ec-903f-d8312844169d"), "Rhode Island", "East Myah", "Micronesia", new DateTime(2024, 9, 17, 1, 29, 2, 377, DateTimeKind.Local).AddTicks(3405), "Timmothy82@yahoo.com", null, null, new Guid("c5436476-f46f-6d25-11cb-6b4d024ef980"), "429 Danielle Pass", "Courts", "Tennessee", 0, 2, null, null, "60965-4463" },
                    { new Guid("b529bd7d-38a3-2370-6052-ef93667f6c84"), "Mississippi", "Port Eliezer", "Botswana", new DateTime(2024, 4, 1, 4, 21, 33, 641, DateTimeKind.Local).AddTicks(9318), "Kamron16@hotmail.com", null, null, new Guid("3ff1e06a-c569-5a28-aa03-b21e765dc014"), "11037 Toy Summit", "Crossroad", "Wyoming", 0, 0, null, null, "75878" },
                    { new Guid("ba14ec4d-e76f-d62c-15fd-8676ef9f3105"), "Florida", "West Lawrenceport", "Cambodia", new DateTime(2024, 1, 6, 18, 27, 58, 841, DateTimeKind.Local).AddTicks(225), "Rubie.Hartmann@yahoo.com", null, null, new Guid("c92d943a-66ca-3d0f-8221-69e9bed1d7f4"), "6598 Larkin Stravenue", "Turnpike", "Alabama", 0, 1, null, null, "79734" },
                    { new Guid("bc8810e9-553a-63ba-18e7-d632646e71a6"), "Nevada", "Bartellview", "Dominica", new DateTime(2024, 5, 11, 19, 6, 54, 316, DateTimeKind.Local).AddTicks(3558), "Ayana.Torp48@hotmail.com", null, null, new Guid("ef0ed8be-7d3f-7684-4e9d-9c725917a044"), "242 Jaylin Ports", "Parks", "Hawaii", 2, 1, null, null, "25262" },
                    { new Guid("bc8ab03e-0e3e-5bf2-eaab-b4d113094998"), "Connecticut", "Tessberg", "Philippines", new DateTime(2024, 9, 18, 0, 9, 44, 24, DateTimeKind.Local).AddTicks(4852), "Mireille_Hand@hotmail.com", null, null, new Guid("fadc0569-4c48-63dd-9ee4-3d45adabbac9"), "53437 Tamara Keys", "Station", "Ohio", 1, 1, null, null, "17177" },
                    { new Guid("be6bf95f-19da-17ad-f55f-df7831c0849b"), "Missouri", "Gleichnerport", "Belarus", new DateTime(2024, 8, 5, 16, 56, 0, 74, DateTimeKind.Local).AddTicks(3202), "Henderson_Little@hotmail.com", null, null, new Guid("3a36db39-70f4-f750-26f9-97f9d0c541e9"), "936 Feeney Overpass", "Wall", "South Carolina", 1, 0, null, null, "31283" },
                    { new Guid("bf732e70-eaf2-eabd-08c7-25a1232b3724"), "Georgia", "East Toneyside", "Palestinian Territory", new DateTime(2024, 5, 17, 22, 2, 13, 74, DateTimeKind.Local).AddTicks(108), "Lindsey_Kertzmann@hotmail.com", null, null, new Guid("9bf87d2a-7043-0562-fda6-ce327ed3b37b"), "40730 Kilback Burg", "Brook", "Kansas", 1, 1, null, null, "32820-9838" },
                    { new Guid("c14fcb83-43f1-22c3-f541-e15d03950bc4"), "New York", "Lake Fredbury", "Turks and Caicos Islands", new DateTime(2024, 7, 7, 16, 26, 0, 737, DateTimeKind.Local).AddTicks(9143), "Terrell25@gmail.com", null, null, new Guid("f4df87e2-b955-bfbd-fe03-73b393fd65b3"), "934 Haylee Mews", "Summit", "New Hampshire", 2, 1, null, null, "89489-5556" },
                    { new Guid("c2ce7137-9fa3-1b7a-a143-857e1a74a8ab"), "Louisiana", "West Kattieville", "Bolivia", new DateTime(2024, 4, 6, 3, 44, 59, 103, DateTimeKind.Local).AddTicks(1136), "Stuart_Bernhard45@hotmail.com", null, null, new Guid("201cdcb0-f913-6809-51e4-4f2290dbad71"), "3437 Yesenia Lodge", "Stream", "Colorado", 2, 2, null, null, "76207" },
                    { new Guid("c48bfaad-c1a4-ee4b-979c-43ae3f178657"), "Illinois", "Botsfordhaven", "Slovakia (Slovak Republic)", new DateTime(2024, 7, 13, 13, 58, 21, 4, DateTimeKind.Local).AddTicks(152), "Fleta28@gmail.com", null, null, new Guid("aa0f09df-e92b-463c-eab3-c2ea1b9ecbe5"), "13755 Andreanne Burgs", "Park", "West Virginia", 2, 2, null, null, "87836-8370" },
                    { new Guid("cc750641-d13b-4ca3-7081-4aadf9260437"), "Nevada", "South Kurtport", "British Indian Ocean Territory (Chagos Archipelago)", new DateTime(2024, 2, 17, 1, 37, 26, 780, DateTimeKind.Local).AddTicks(1160), "Noe12@gmail.com", null, null, new Guid("188079b9-1013-d796-8969-bbb3fd03ee19"), "10633 Kunde Overpass", "Via", "Mississippi", 0, 2, null, null, "44678" },
                    { new Guid("cef02dcb-68d1-3e7b-cbb3-13cf5ce017d4"), "Idaho", "East Kendrick", "Anguilla", new DateTime(2024, 3, 18, 10, 10, 10, 948, DateTimeKind.Local).AddTicks(4191), "Curtis.Fritsch51@hotmail.com", null, null, new Guid("85d2ae44-f4a8-2871-3a33-6aa13fc8a32e"), "66867 Dayne Lakes", "Meadow", "Hawaii", 1, 2, null, null, "38718" },
                    { new Guid("f3189536-9221-267f-b35c-a7875e195700"), "Vermont", "Lake Nicomouth", "Virgin Islands, British", new DateTime(2024, 10, 11, 3, 24, 12, 778, DateTimeKind.Local).AddTicks(3694), "Deron_DAmore@gmail.com", null, null, new Guid("c4334d3b-4612-366d-7a90-25ab7a7d5c76"), "82383 Daniel Stravenue", "Motorway", "Florida", 1, 2, null, null, "09303" },
                    { new Guid("f46143ad-00ed-a926-62e9-c85f43ee1c6d"), "California", "Starkville", "Bhutan", new DateTime(2024, 10, 10, 12, 10, 56, 724, DateTimeKind.Local).AddTicks(215), "Everardo_Berge54@yahoo.com", null, null, new Guid("2ba797b6-7264-f1ee-772f-97875e9c6965"), "447 Crooks Extensions", "Locks", "Massachusetts", 2, 2, null, null, "34052-8851" },
                    { new Guid("fbf12ba8-89b5-2c1f-629c-042489b32ffa"), "West Virginia", "Gerlachstad", "Ukraine", new DateTime(2024, 1, 17, 21, 50, 49, 331, DateTimeKind.Local).AddTicks(4844), "Lindsay59@gmail.com", null, null, new Guid("597a8e45-b68e-045d-b256-741fd2120ba6"), "657 Ledner Inlet", "Row", "Arkansas", 0, 2, null, null, "74378-4405" }
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EmployeeId", "IsPrimary", "Status", "Type", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { new Guid("0366282d-cae2-fe06-cde3-23b0bb6ce412"), new DateTime(2024, 4, 30, 0, 23, 16, 158, DateTimeKind.Local).AddTicks(6236), "Jarrell_Reichert69@hotmail.com", null, null, new Guid("c92d943a-66ca-3d0f-8221-69e9bed1d7f4"), false, 0, 1, null, null, "337-955-6882 x289" },
                    { new Guid("102a297b-dfd2-09d2-bfab-c4d8a2c8b7c0"), new DateTime(2024, 2, 18, 18, 10, 45, 627, DateTimeKind.Local).AddTicks(92), "Karolann24@gmail.com", null, null, new Guid("597a13d8-231d-5e98-a5da-f20128f8cbaf"), false, 0, 1, null, null, "223-977-6430 x3238" },
                    { new Guid("14ca8288-2da6-ac4c-ddb4-be26c40b4559"), new DateTime(2024, 8, 24, 12, 50, 37, 418, DateTimeKind.Local).AddTicks(9265), "Eric38@gmail.com", null, null, new Guid("f5799447-fdd4-7061-6a6e-dae5db6f9693"), false, 0, 0, null, null, "692-473-5242" },
                    { new Guid("18326327-df29-a881-17ad-67a9435b2583"), new DateTime(2024, 11, 2, 21, 31, 9, 916, DateTimeKind.Local).AddTicks(3306), "Gregoria_Keebler54@yahoo.com", null, null, new Guid("34708cce-5cb8-96db-e88d-67ef48aa1e05"), true, 0, 1, null, null, "647.301.4129 x996" },
                    { new Guid("19b162fb-6497-b490-4ccc-f12df56937ad"), new DateTime(2024, 1, 26, 20, 6, 21, 842, DateTimeKind.Local).AddTicks(6403), "Roy_Denesik@hotmail.com", null, null, new Guid("d86ea596-b075-6aa3-71b3-60944262c081"), false, 1, 2, null, null, "Elmore_Walter@gmail.com" },
                    { new Guid("1e43b070-da0e-4a03-46d3-10b503ea6523"), new DateTime(2024, 4, 18, 3, 8, 3, 761, DateTimeKind.Local).AddTicks(4866), "Lisandro28@hotmail.com", null, null, new Guid("7f7f0723-2bcd-321b-29de-8739050e4e31"), false, 1, 2, null, null, "Sabina.Predovic68@hotmail.com" },
                    { new Guid("2860836f-b570-bde6-57da-c7113f7b385d"), new DateTime(2023, 12, 9, 17, 26, 33, 834, DateTimeKind.Local).AddTicks(5531), "Rick.Dach@gmail.com", null, null, new Guid("fcf39862-abf5-b06f-a0fc-bda199d5ea48"), false, 0, 1, null, null, "357-361-4599" },
                    { new Guid("2a4052ff-de21-ac6c-9c77-820af5150a76"), new DateTime(2023, 12, 19, 8, 16, 14, 887, DateTimeKind.Local).AddTicks(4265), "Precious5@yahoo.com", null, null, new Guid("900f44d7-2494-c44c-1d9d-32bc18375f8a"), false, 2, 0, null, null, "1-533-273-2405 x62811" },
                    { new Guid("2f1a3701-7a67-f5bb-1765-b6976f5b5dd1"), new DateTime(2024, 1, 11, 16, 40, 8, 789, DateTimeKind.Local).AddTicks(8980), "Coralie76@hotmail.com", null, null, new Guid("f5799447-fdd4-7061-6a6e-dae5db6f9693"), true, 0, 2, null, null, "Clay_Fritsch31@yahoo.com" },
                    { new Guid("339a28d2-e1a2-86d1-1ab3-20f369b48ea7"), new DateTime(2024, 4, 11, 16, 10, 26, 464, DateTimeKind.Local).AddTicks(9519), "Mario.Howell@hotmail.com", null, null, new Guid("11261073-5e49-995f-70d8-5c3b47ff7697"), false, 0, 1, null, null, "(362) 654-5356 x053" },
                    { new Guid("348190c9-f46e-f4e9-9f6c-a588be2c09a4"), new DateTime(2024, 3, 10, 19, 54, 52, 987, DateTimeKind.Local).AddTicks(7163), "Dawson.Prosacco@yahoo.com", null, null, new Guid("8c8dac88-5d3b-1e80-cfb1-e3d2a4b9cbca"), false, 1, 2, null, null, "Georgiana_Wunsch@gmail.com" },
                    { new Guid("3c9908be-294a-e52e-1a9e-cc1a2fcf5514"), new DateTime(2024, 7, 13, 5, 28, 54, 346, DateTimeKind.Local).AddTicks(890), "Verona_Block31@hotmail.com", null, null, new Guid("d86ea596-b075-6aa3-71b3-60944262c081"), true, 0, 1, null, null, "652.351.7071" },
                    { new Guid("4375c362-58a9-36fc-f04a-c927d0b21d28"), new DateTime(2024, 10, 24, 1, 53, 25, 691, DateTimeKind.Local).AddTicks(8548), "Brody_Volkman@yahoo.com", null, null, new Guid("bd57575b-6506-edfb-da26-2bc9da462e2a"), true, 2, 0, null, null, "374-292-4234 x2223" },
                    { new Guid("48859f77-9405-a7ed-3a74-ff943f4bc194"), new DateTime(2024, 5, 23, 8, 42, 10, 430, DateTimeKind.Local).AddTicks(3645), "Vincenza.Langosh89@gmail.com", null, null, new Guid("96488a78-dca7-a138-574e-73f0967e3b99"), true, 0, 0, null, null, "(716) 478-7494 x42608" },
                    { new Guid("5a392c35-f370-0442-d5fd-6ae6f58b177e"), new DateTime(2023, 11, 18, 20, 9, 49, 915, DateTimeKind.Local).AddTicks(6470), "Silas.Stokes24@gmail.com", null, null, new Guid("814180d1-0f08-0568-a5c3-ab1132298093"), false, 0, 0, null, null, "726.937.6455 x464" },
                    { new Guid("5a9cade3-0871-be87-bc65-a5e9ac8072be"), new DateTime(2024, 6, 18, 9, 31, 7, 177, DateTimeKind.Local).AddTicks(9696), "Cooper_Kerluke@gmail.com", null, null, new Guid("d86ea596-b075-6aa3-71b3-60944262c081"), false, 0, 1, null, null, "881.643.6329 x4926" },
                    { new Guid("5aaf312c-3b2c-0712-f4e4-522763fc1760"), new DateTime(2024, 7, 21, 17, 46, 36, 564, DateTimeKind.Local).AddTicks(30), "Paris.Kassulke@hotmail.com", null, null, new Guid("466d5888-cfea-c213-bfc2-1bc479dc145e"), true, 0, 2, null, null, "Fannie.Kirlin54@hotmail.com" },
                    { new Guid("60702d7d-8173-db61-15ba-4def65cfac89"), new DateTime(2024, 3, 7, 3, 10, 27, 911, DateTimeKind.Local).AddTicks(8862), "Kaylie49@hotmail.com", null, null, new Guid("c5436476-f46f-6d25-11cb-6b4d024ef980"), true, 0, 2, null, null, "Ansel_Grady@yahoo.com" },
                    { new Guid("6ba1234b-53af-66fa-b500-c63b1492f06c"), new DateTime(2024, 3, 26, 22, 14, 3, 915, DateTimeKind.Local).AddTicks(5297), "Vivien_Johnston@yahoo.com", null, null, new Guid("284029fb-aea9-1935-dcfc-8fb5f78554ad"), true, 0, 0, null, null, "795-207-8295 x58447" },
                    { new Guid("6d9862ed-0475-b58b-3855-6e76181e9457"), new DateTime(2023, 11, 29, 15, 49, 50, 405, DateTimeKind.Local).AddTicks(6907), "Laverna.Considine@gmail.com", null, null, new Guid("5b4beeec-511f-dc99-0ba1-236ef2dab8a9"), false, 2, 2, null, null, "Josiane_Simonis@gmail.com" },
                    { new Guid("6fbf1bf5-7918-52a4-70b0-64613ad797a6"), new DateTime(2024, 1, 16, 3, 0, 34, 185, DateTimeKind.Local).AddTicks(1984), "Dewitt_Parker18@gmail.com", null, null, new Guid("3da8b2ef-ac58-c1bc-269e-1afad72a0522"), false, 2, 2, null, null, "Harvey.Lindgren@hotmail.com" },
                    { new Guid("703585c9-af25-e4a2-80e3-c07fa534b684"), new DateTime(2024, 10, 20, 23, 51, 14, 635, DateTimeKind.Local).AddTicks(8965), "Bianka91@yahoo.com", null, null, new Guid("5a829ffd-41b8-5369-9d2e-e4221c75ddc6"), false, 0, 2, null, null, "Derrick.Fahey@hotmail.com" },
                    { new Guid("70ea48fb-a7b1-6454-74eb-b175ef06c3cc"), new DateTime(2024, 8, 14, 23, 3, 49, 889, DateTimeKind.Local).AddTicks(2117), "Ahmad_Klocko91@yahoo.com", null, null, new Guid("188079b9-1013-d796-8969-bbb3fd03ee19"), true, 2, 1, null, null, "1-567-263-6450 x9005" },
                    { new Guid("7363bc35-9047-01dc-dc60-ac88e53c8033"), new DateTime(2024, 7, 5, 14, 8, 39, 340, DateTimeKind.Local).AddTicks(5952), "Jacynthe.Orn97@hotmail.com", null, null, new Guid("2b11c3b8-2f3f-c69e-7e34-007a59ca09c0"), false, 1, 2, null, null, "Finn34@gmail.com" },
                    { new Guid("73f384da-af5f-39c5-a8f3-e377b9ad648d"), new DateTime(2024, 5, 28, 17, 49, 48, 575, DateTimeKind.Local).AddTicks(4425), "Hellen26@gmail.com", null, null, new Guid("fcf39862-abf5-b06f-a0fc-bda199d5ea48"), false, 1, 2, null, null, "Javonte51@gmail.com" },
                    { new Guid("77920727-2194-8bb2-c595-95cae4874c03"), new DateTime(2024, 3, 4, 3, 55, 50, 565, DateTimeKind.Local).AddTicks(9770), "Alexanne.Raynor@hotmail.com", null, null, new Guid("3a36db39-70f4-f750-26f9-97f9d0c541e9"), true, 0, 0, null, null, "1-668-566-6238" },
                    { new Guid("79ce8322-9f42-4131-3fb7-4e6922057b9f"), new DateTime(2024, 3, 28, 4, 48, 32, 762, DateTimeKind.Local).AddTicks(7345), "Katrine.Keebler@gmail.com", null, null, new Guid("c92d943a-66ca-3d0f-8221-69e9bed1d7f4"), false, 1, 2, null, null, "Jarod63@gmail.com" },
                    { new Guid("7a23e245-7d6d-9e1f-77fb-f2abcb5d4826"), new DateTime(2024, 1, 9, 12, 7, 52, 517, DateTimeKind.Local).AddTicks(1123), "Korey_Parisian99@hotmail.com", null, null, new Guid("328f3de8-99ae-d915-9ee6-07ebd8a670f3"), false, 0, 1, null, null, "1-937-272-8470" },
                    { new Guid("90cc0cfd-aa45-942e-03ad-1dd415e9165f"), new DateTime(2024, 6, 23, 0, 1, 50, 23, DateTimeKind.Local).AddTicks(7615), "King.Raynor@hotmail.com", null, null, new Guid("3a36db39-70f4-f750-26f9-97f9d0c541e9"), true, 1, 2, null, null, "Hollie_Abshire@hotmail.com" },
                    { new Guid("92aa3af9-d942-72fe-ee15-a3aaaf2c3b32"), new DateTime(2024, 11, 5, 1, 51, 38, 268, DateTimeKind.Local).AddTicks(6654), "Ophelia.OConnell@gmail.com", null, null, new Guid("8ac522fa-1f03-3893-1d94-f274e8bc0ff2"), false, 2, 0, null, null, "(259) 687-4911 x43116" },
                    { new Guid("98296c2e-06cf-02e3-5501-f10e015b8dfd"), new DateTime(2024, 8, 7, 10, 18, 51, 214, DateTimeKind.Local).AddTicks(3118), "Bella58@hotmail.com", null, null, new Guid("85d2ae44-f4a8-2871-3a33-6aa13fc8a32e"), true, 0, 2, null, null, "Lambert_Bruen47@yahoo.com" },
                    { new Guid("add194d5-8a00-541e-a4d5-0c525f58cc8b"), new DateTime(2024, 5, 12, 21, 44, 57, 261, DateTimeKind.Local).AddTicks(9644), "Rosie_Mraz@hotmail.com", null, null, new Guid("34708cce-5cb8-96db-e88d-67ef48aa1e05"), false, 2, 0, null, null, "1-927-617-0502" },
                    { new Guid("af8b060c-2271-f8b5-2558-41daf4c59f85"), new DateTime(2024, 7, 14, 4, 53, 21, 55, DateTimeKind.Local).AddTicks(9915), "Donavon_Nolan@yahoo.com", null, null, new Guid("582a5e08-fd4d-3801-b2c0-63199fc76279"), true, 2, 1, null, null, "964.538.0997" },
                    { new Guid("b73934cb-0d6a-d8a2-456e-8ca5bcfd24c2"), new DateTime(2024, 5, 23, 13, 47, 8, 699, DateTimeKind.Local).AddTicks(3508), "Gaylord.Metz@gmail.com", null, null, new Guid("814180d1-0f08-0568-a5c3-ab1132298093"), true, 1, 2, null, null, "Alena67@hotmail.com" },
                    { new Guid("b8f1956f-0e94-a652-f8d1-7508ad6450ca"), new DateTime(2024, 5, 26, 23, 12, 19, 750, DateTimeKind.Local).AddTicks(9758), "Devyn50@hotmail.com", null, null, new Guid("188079b9-1013-d796-8969-bbb3fd03ee19"), true, 0, 2, null, null, "Estelle.DAmore59@gmail.com" },
                    { new Guid("b927a920-3311-4ab1-aea1-31ae94c25d80"), new DateTime(2024, 8, 14, 4, 1, 17, 127, DateTimeKind.Local).AddTicks(5391), "Elenor.Bergstrom@yahoo.com", null, null, new Guid("aa0f09df-e92b-463c-eab3-c2ea1b9ecbe5"), true, 2, 1, null, null, "635.235.5786" },
                    { new Guid("bbd10189-8925-85fb-9078-8e15675d9a85"), new DateTime(2024, 7, 3, 16, 1, 6, 323, DateTimeKind.Local).AddTicks(917), "Raoul_Rath@gmail.com", null, null, new Guid("38ce019a-f508-ae4b-5743-3ba114d967c4"), false, 0, 2, null, null, "Micheal_Hammes61@yahoo.com" },
                    { new Guid("bdeb825a-6c7a-a303-1aa6-63e7672710e6"), new DateTime(2024, 5, 26, 16, 16, 40, 269, DateTimeKind.Local).AddTicks(2117), "Karelle.Stracke@yahoo.com", null, null, new Guid("b22cbbb9-4252-4faa-655d-daeb92251150"), true, 2, 2, null, null, "Adrain22@yahoo.com" },
                    { new Guid("c8040e9c-6d09-2d23-8dbc-7e946ad851ed"), new DateTime(2024, 9, 13, 2, 23, 5, 843, DateTimeKind.Local).AddTicks(4028), "Dee_Brekke@gmail.com", null, null, new Guid("5a829ffd-41b8-5369-9d2e-e4221c75ddc6"), true, 2, 2, null, null, "Broderick.Kuhic@gmail.com" },
                    { new Guid("d17ebd94-2540-ee4b-8ba0-e426a77c8507"), new DateTime(2024, 3, 23, 14, 52, 22, 579, DateTimeKind.Local).AddTicks(3776), "Alisha91@gmail.com", null, null, new Guid("13e1a3e1-e43c-1e6e-cb54-2063010dc7c4"), false, 1, 1, null, null, "1-892-472-8428 x520" },
                    { new Guid("d41262b8-b5a5-4e08-7623-1cd488c75866"), new DateTime(2024, 7, 30, 10, 42, 6, 666, DateTimeKind.Local).AddTicks(3929), "Bonita.Schoen@gmail.com", null, null, new Guid("e84334a4-5359-c309-7092-79ed735a2d64"), false, 2, 2, null, null, "Lisa29@hotmail.com" },
                    { new Guid("da181732-4a14-dc56-d516-f299a7717665"), new DateTime(2024, 10, 6, 21, 37, 25, 96, DateTimeKind.Local).AddTicks(4141), "Stevie.Herzog19@hotmail.com", null, null, new Guid("201cdcb0-f913-6809-51e4-4f2290dbad71"), false, 2, 2, null, null, "Vita74@hotmail.com" },
                    { new Guid("db7f452a-d5bf-92da-da6c-ca2c6db2a805"), new DateTime(2024, 8, 16, 9, 36, 31, 286, DateTimeKind.Local).AddTicks(6477), "Edmund.Schaefer@gmail.com", null, null, new Guid("96488a78-dca7-a138-574e-73f0967e3b99"), false, 2, 2, null, null, "Saige61@hotmail.com" },
                    { new Guid("de166900-04e7-04c3-e2eb-fdd7021730aa"), new DateTime(2024, 5, 2, 8, 50, 31, 717, DateTimeKind.Local).AddTicks(3591), "Elta_Huels@gmail.com", null, null, new Guid("ee944e9e-22fb-92c1-1a6b-5062115984a0"), true, 0, 1, null, null, "438-346-6446" },
                    { new Guid("dfba9869-648c-052f-5d9c-3f83396df40d"), new DateTime(2024, 11, 12, 21, 19, 58, 73, DateTimeKind.Local).AddTicks(1777), "Giovanny_Hintz@yahoo.com", null, null, new Guid("13e1a3e1-e43c-1e6e-cb54-2063010dc7c4"), true, 2, 1, null, null, "(965) 634-7032 x596" },
                    { new Guid("e3e165a6-9f15-eff8-01fb-b7cf9bfcc9a1"), new DateTime(2024, 1, 30, 3, 6, 41, 612, DateTimeKind.Local).AddTicks(7550), "Ellie94@hotmail.com", null, null, new Guid("c0b6faf8-93be-e88d-8dd1-dc8e06409e07"), false, 2, 0, null, null, "(863) 664-4134 x780" },
                    { new Guid("ed2edcdb-105b-a47e-6c5f-c0e0a5b76935"), new DateTime(2024, 7, 21, 16, 31, 50, 375, DateTimeKind.Local).AddTicks(2341), "Mose22@yahoo.com", null, null, new Guid("a2bb0320-ea48-a8b3-a601-9d55ef8c2d9d"), true, 0, 2, null, null, "Janessa_Jacobson@hotmail.com" },
                    { new Guid("f1f7468c-930a-6acb-78f5-7461babbfe57"), new DateTime(2024, 9, 23, 5, 17, 4, 759, DateTimeKind.Local).AddTicks(7843), "Sarina2@gmail.com", null, null, new Guid("3797a52d-1544-571d-9fd6-f3ada1878868"), true, 2, 2, null, null, "Buster.Yost99@hotmail.com" },
                    { new Guid("f98096ab-ce47-9582-605e-316fe29db875"), new DateTime(2024, 3, 2, 23, 12, 0, 741, DateTimeKind.Local).AddTicks(71), "Stephen.MacGyver68@gmail.com", null, null, new Guid("99276973-3fee-bbf7-1f33-82a1c5ec51d4"), true, 1, 1, null, null, "986-510-9958" },
                    { new Guid("fc64e143-8fb2-a870-429d-b8679628b52b"), new DateTime(2024, 9, 23, 16, 24, 42, 544, DateTimeKind.Local).AddTicks(6796), "Lillian58@hotmail.com", null, null, new Guid("84dc292a-35ef-ef22-f223-44db3e9e5e34"), true, 2, 2, null, null, "Bria.Macejkovic@yahoo.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId",
                table: "Address",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_EmployeeId",
                table: "Contact",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "EmployeeVersions");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
