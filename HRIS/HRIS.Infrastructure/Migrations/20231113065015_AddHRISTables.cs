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
                    { new Guid("05f7fb9a-bbfd-86a8-2304-99e30984734d"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 15, 17, 9, 0, 693, DateTimeKind.Local).AddTicks(6632), "Sylvan47@gmail.com", null, null, "Casimer", "Female", "Abshire", "첐氨壳짥䏳紃岒὚濕췒", "ᣎጂሖ軦췎➱丰᳊ﳁㆳ", 2, null, null },
                    { new Guid("09c7536a-1f9c-a250-0f4c-33cbae99ef91"), new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 30, 20, 30, 35, 763, DateTimeKind.Local).AddTicks(5719), "Theresia83@hotmail.com", null, null, "Granville", "Female", "DuBuque", "먆콖䞘ᣡ풣纂穑ᗩᣡ煙", "볒卐�⊮쿃㑬ⶕ", 0, null, null },
                    { new Guid("0bad8d4e-cf3f-8fef-939a-0f47106cdee4"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 3, 12, 53, 47, 367, DateTimeKind.Local).AddTicks(2592), "Camren.Bradtke25@yahoo.com", null, null, "Ernestina", "Male", "Bosco", "౵ꢶ䔌ㄝ杠嚏旀糏欃", "沌ⲓ움뒩산쟇폏昝যد", 1, null, null },
                    { new Guid("0bad9c90-a898-20f1-28a4-a518958a1390"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 14, 20, 4, 39, 705, DateTimeKind.Local).AddTicks(3386), "Daphney_Corwin98@hotmail.com", null, null, "Rowena", "Male", "Hane", "哱ኞ周仉葷롕눿₫뾗", "륥Ჹ៾�╩╹긏옒炙", 2, null, null },
                    { new Guid("0bccea20-602e-97a0-756d-7596cf597d2b"), new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 17, 1, 4, 43, 562, DateTimeKind.Local).AddTicks(2763), "Shyanne37@gmail.com", null, null, "Torrey", "Male", "Hammes", "�㚔웽蝌엔盙꬯⣨賯ၹ", "짯ғဂ⡣왂䅪⌂ᜂ阁", 1, null, null },
                    { new Guid("0c12a4b7-1263-4825-6204-eab83fe2bc9b"), new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 7, 7, 52, 30, 898, DateTimeKind.Local).AddTicks(9988), "Toney.Gibson93@gmail.com", null, null, "Maurice", "Female", "Toy", "쯋盨鲠룡地੻蓅佸䴼䌄", "ࣃ圑㓞躨儱齭ꌸꭉ撪�", 2, null, null },
                    { new Guid("0d34999f-7057-bb4c-36c6-c98aa1b8ef90"), new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 12, 11, 52, 36, 750, DateTimeKind.Local).AddTicks(8912), "Jordon12@gmail.com", null, null, "Cleora", "Female", "Cummings", "큦뿎脗ྕឤ肤띵밀↪ស", "ꭩʜ瑬ਞჀ柀ꢖ᡼벩˳", 1, null, null },
                    { new Guid("0e62f746-e4fc-b40b-5de9-6c2c45e8f493"), new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 11, 2, 11, 58, 818, DateTimeKind.Local).AddTicks(5347), "Garrison_Terry16@gmail.com", null, null, "Audrey", "Female", "Upton", "訤ꢱ玚脥᳌音떢", "顺绦겞쑔益作茻쇝", 1, null, null },
                    { new Guid("0f0377ea-06f8-acdd-96cf-f32506761903"), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 28, 1, 35, 57, 281, DateTimeKind.Local).AddTicks(213), "Alexa.Dickens8@yahoo.com", null, null, "Brenden", "Female", "Feest", "䠞睓黦욂⾏ᰑ᧧ἲ", "抍睤傹奉칗箈龊梐ッ忇", 1, null, null },
                    { new Guid("12eaecf9-7692-c4ff-a401-6a58c11831f9"), new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 3, 8, 23, 15, 705, DateTimeKind.Local).AddTicks(8033), "Monique85@hotmail.com", null, null, "Rowena", "Female", "DuBuque", "ઓ까࢜꺇湠䚳⦐ᩗօ", "㺯ᐩ鯷䡎䠰䚬慪昁㯮", 2, null, null },
                    { new Guid("1339bf5f-0178-da1e-adb1-9e4463110821"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 6, 10, 42, 29, 299, DateTimeKind.Local).AddTicks(4136), "Jackeline_Walsh30@yahoo.com", null, null, "Concepcion", "Male", "Nicolas", "밎됲욧�쭍丱犥㭠ウ", "�禖ﳬ햪籹汊쿃゚좸㍜", 2, null, null },
                    { new Guid("1951e95f-2623-7a93-9ced-14f96258569d"), new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 3, 15, 55, 36, 223, DateTimeKind.Local).AddTicks(8332), "Kamron24@gmail.com", null, null, "Gladyce", "Male", "Abernathy", "ℌ�遟ᅱ癅ࡖ꽏k", "ᆦ墶퉉忂ꯩ䆆剤ⶉ᝶", 1, null, null },
                    { new Guid("1e3fc74a-6fd4-e8fd-afcf-89a1068c6dee"), new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 12, 15, 20, 49, 211, DateTimeKind.Local).AddTicks(5859), "Gay.Littel@hotmail.com", null, null, "Eda", "Male", "Johnston", "稉㈯땋鋯搒裗첑언嚙", "ᗢᜰ뢞㤔쎪看ᖻ渻", 0, null, null },
                    { new Guid("1ed16f43-95b9-4756-e664-57a1c93f11d5"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 10, 14, 54, 51, 736, DateTimeKind.Local).AddTicks(6244), "Immanuel56@hotmail.com", null, null, "Makenna", "Male", "VonRueden", "꘍ﶚ鳜钯ꈮ鞵�퇺䚠鳍", "罹ⅽ猻杶륄桹騫௄侬蹌", 1, null, null },
                    { new Guid("1fa5a138-b717-aa73-0d68-8ce08305ad0b"), new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 18, 22, 27, 19, 361, DateTimeKind.Local).AddTicks(3559), "Kadin_Robel96@yahoo.com", null, null, "Gabriella", "Male", "Lebsack", "堲窳ែ᫑鹥祑ヸ踏⾸Ꞣ", "嫡漧ꧪ珁焵﷉ড়缮鴻", 0, null, null },
                    { new Guid("21027bf0-fd99-5d2b-47a0-a255b2eedc52"), new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 9, 0, 17, 43, 875, DateTimeKind.Local).AddTicks(2917), "Emile59@yahoo.com", null, null, "Estrella", "Female", "Hilll", "瞸㌒侓괩㺝衄ﶪ㎍하", "篗穆ᒓ끠頛焿嚞⩢�", 2, null, null },
                    { new Guid("245cc7ba-f395-74da-954b-f88ef451b309"), new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 19, 8, 15, 49, 576, DateTimeKind.Local).AddTicks(8903), "Glenna.Durgan46@gmail.com", null, null, "Molly", "Male", "Stehr", "頧䤊꡿ଂ硲ﾖ睎Ệ듢", "ஶ쟂떣砗ⰉԎ᪃ﻍ४", 1, null, null },
                    { new Guid("2891d5d2-4977-3c10-b5fe-3561c031c315"), new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 31, 13, 59, 51, 861, DateTimeKind.Local).AddTicks(6115), "Donny_OHara79@gmail.com", null, null, "Connie", "Female", "Sawayn", "베桴槹﵎§쮞張ᠤꐙ୯", "蟃炷㲯돭汯⹕䗜ᲀ", 2, null, null },
                    { new Guid("2bbbee4c-25cd-4de5-5453-547ded6fa41f"), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 9, 23, 9, 56, 895, DateTimeKind.Local).AddTicks(7161), "Lavina.Hand@gmail.com", null, null, "Lester", "Male", "O'Kon", "蜌휐휕ﺸ櫓睾鍶ꁋ쬁", "蟣畄ோ螉쾽횠䯐ﯔ䚃", 1, null, null },
                    { new Guid("2eaf6ee2-3238-4736-740d-2d47632b3508"), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 10, 6, 52, 27, 4, DateTimeKind.Local).AddTicks(8595), "Laura2@hotmail.com", null, null, "Lorenza", "Female", "Nitzsche", "煶䗐╠Ɠ耺諷낙넵땒㝜", "픏讏攈ﳰ䙺㾣䇕⤞", 0, null, null },
                    { new Guid("307bcba8-846f-364b-c5a2-c769f554ad07"), new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 21, 1, 2, 25, 4, DateTimeKind.Local).AddTicks(2974), "Marshall22@hotmail.com", null, null, "William", "Female", "Mertz", "㰬걮㈫畠앖璽럌쥐鳿", "ⴐ㙨鲦樒닓萧激忳㳮", 0, null, null },
                    { new Guid("3250fa3a-fe86-88ab-08c4-9688c3e6b401"), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 24, 2, 52, 23, 123, DateTimeKind.Local).AddTicks(1647), "Rafael_Murazik@yahoo.com", null, null, "Ally", "Female", "Zboncak", "鞱ⷮ㼷✭㢏ꀉ咩늁臦䎥", "薢힆넪盟餹彸梔礄", 2, null, null },
                    { new Guid("32a7a197-c125-2516-0aed-9532e3302f0c"), new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 22, 1, 18, 11, 942, DateTimeKind.Local).AddTicks(1863), "Sage18@hotmail.com", null, null, "Dominic", "Female", "Tillman", "鷺햸篺撶␃ʐ즮�䥗", "絇꾀㊽놧瀻䭀壪㬘呏ꗇ", 1, null, null },
                    { new Guid("36c23d42-b626-7db2-b9fb-73b5331bcded"), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 17, 8, 49, 8, 878, DateTimeKind.Local).AddTicks(609), "Lindsey.Miller@hotmail.com", null, null, "Richie", "Male", "Mayer", "▜枔꫆﹝潢鉛Л᫫૯", "�逡ዥ⺈؁秜౴ﭷ堷", 0, null, null },
                    { new Guid("38283774-380f-af82-abb9-120c33206c37"), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 29, 9, 0, 7, 467, DateTimeKind.Local).AddTicks(7051), "Miller_Bode@gmail.com", null, null, "Rory", "Female", "Zulauf", "뺚ꍅ넷첈륋瘖㙴弨醐⽱", "肒䲢쪗澺롭玽�劣횰", 1, null, null },
                    { new Guid("38396acc-3fdd-c893-252f-de4c4e3f613d"), new DateTime(2023, 7, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 29, 22, 17, 25, 973, DateTimeKind.Local).AddTicks(9538), "Alivia42@yahoo.com", null, null, "Columbus", "Female", "Walker", "歓熛洋弡ⷽŉ⎮濆∘", "꥟ਠ㸱뻝㧎鼇㏞ꧡ䬆촴", 1, null, null },
                    { new Guid("3953bc7a-326b-27bd-3d2a-b30a57283cb3"), new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 15, 5, 3, 17, 178, DateTimeKind.Local).AddTicks(1506), "Ralph3@gmail.com", null, null, "Erick", "Male", "Heathcote", "≡ई荮㑩싪俼嗤Ȝᆡ甽", "賤ዼ昐쿏肸숴ᙏ", 2, null, null },
                    { new Guid("3990ba6c-fc61-bc7d-755e-8caa123b49d2"), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 1, 4, 35, 35, 753, DateTimeKind.Local).AddTicks(8651), "Alessandro_Conroy63@gmail.com", null, null, "Joe", "Male", "Legros", "䇞蝙䊜୪⁺㧠Ꮶ걔掤", "９�驲郇锦⋞鱢䴌�", 1, null, null },
                    { new Guid("3be346f9-80b7-1faa-da59-af021c85e9c0"), new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 23, 17, 30, 15, 738, DateTimeKind.Local).AddTicks(7623), "Jimmy.Hilpert@hotmail.com", null, null, "Anika", "Male", "Hilll", "抗诐༂鉄柣媬Ⓓ鸕䑀殷", "߈ἵ䲺돴ಏ뾎운辄䛭", 0, null, null },
                    { new Guid("3e530cd9-f93e-9ff9-6f5d-703344b2b82b"), new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 24, 13, 39, 9, 93, DateTimeKind.Local).AddTicks(8381), "Cristina_Herzog50@hotmail.com", null, null, "Bernita", "Male", "Lakin", "튊尼謝⎉嘘䃬셎㐟", "룎릙歽鹛챟뱬纺ᐁ덫筂", 1, null, null },
                    { new Guid("40ca5130-28cc-223d-74c7-e701d8822520"), new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 25, 3, 28, 55, 661, DateTimeKind.Local).AddTicks(9096), "Mario_Jenkins@gmail.com", null, null, "Reba", "Female", "Cartwright", "䢖썡赛誇㱠៦穇䭳륵", "ߚŶ텀뇱◒Ἧꔪ�໽푻", 1, null, null },
                    { new Guid("4104b05f-9fcc-a4cf-89aa-33549f3f567c"), new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 4, 14, 16, 20, 181, DateTimeKind.Local).AddTicks(3883), "Rowena65@hotmail.com", null, null, "Don", "Female", "Dibbert", "퐰禡惽劕Ꞅ狆㏨函舘ܗ", "坑숱뙈⋗눇眙띪睟⇋", 1, null, null },
                    { new Guid("421a72bd-f62e-5651-e95c-5ea44a5efeeb"), new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 3, 14, 59, 45, 268, DateTimeKind.Local).AddTicks(4965), "Casper_Green70@gmail.com", null, null, "Kian", "Female", "Johnston", "돽믞嗔豎꽲쒊珢왩崊", "ᘅ焲汆ꉦาḔ繻펪皁", 0, null, null },
                    { new Guid("4cf57b4c-fa61-8362-7081-697e47a28af8"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 15, 5, 42, 27, 52, DateTimeKind.Local).AddTicks(3271), "Floyd.Marvin@gmail.com", null, null, "Rusty", "Male", "Bogisich", "ꃇ槇䓘秂辶혶습喼쪪꾙", "窎눴㐎ത횫谼ờ芜墸펰", 2, null, null },
                    { new Guid("4f0d94b7-a3fe-3c0b-a801-6bfb1b4243c2"), new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 2, 20, 22, 19, 444, DateTimeKind.Local).AddTicks(2414), "Zetta.Carter@hotmail.com", null, null, "Berneice", "Male", "Ankunding", "辚爲錴뾯蔚毦좞ᄧޛ", "걇꘲뫱⭽퐒댑炵褤뉙ో", 2, null, null },
                    { new Guid("522e4e1a-48ec-b392-7e1b-ebe5f0dba4e3"), new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 23, 8, 17, 42, 407, DateTimeKind.Local).AddTicks(6747), "Cyril18@gmail.com", null, null, "Lucas", "Female", "Schumm", "뚼ꎊ�謏ꎬ亡堿", "⿯㜌Ðḅ達ູ㥀唄㾞", 2, null, null },
                    { new Guid("574bccc4-823b-a038-a0ac-b3b9d1c80095"), new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 27, 11, 35, 56, 455, DateTimeKind.Local).AddTicks(8299), "Johanna31@yahoo.com", null, null, "Gerry", "Female", "Pfannerstill", "�뭤浮갱ﰝ焢䴸苊辂쮫", "⑧铩뚍㌾ﳞ兯魳ﲻ纲ဍ", 1, null, null },
                    { new Guid("589ae92a-6f89-b2bd-9864-b397ecb33d6a"), new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 28, 16, 50, 37, 919, DateTimeKind.Local).AddTicks(5659), "Mafalda.Lakin30@hotmail.com", null, null, "Reuben", "Female", "Bashirian", "ꏻ咗린岛萉᪐۱몯", "媬�緤萭ẗ螫擘ෝ", 1, null, null },
                    { new Guid("5a798d23-88e4-cbe1-8b88-7f73d35490f1"), new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 16, 9, 14, 27, 114, DateTimeKind.Local).AddTicks(6481), "Elenor_Davis@yahoo.com", null, null, "Colten", "Female", "Lindgren", "똪講퓹伄စ圵篳말喅㦇", "鮥ⴕ菢쀳侺쩃櫤돸뵛", 1, null, null },
                    { new Guid("5bc5b3c7-6104-949b-6151-251c73d9c3c9"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 31, 18, 18, 2, 320, DateTimeKind.Local).AddTicks(745), "Wiley.Watsica@hotmail.com", null, null, "Elliot", "Female", "Wolf", "惣简委촭쬇鬘＾ٳᝦ㉗", "춰뇝怸ἥ䌷❑鷾㹸威", 0, null, null },
                    { new Guid("5c4e369e-a4de-896f-73bc-70a810107330"), new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 20, 11, 51, 40, 52, DateTimeKind.Local).AddTicks(8718), "Norene.Hermiston@hotmail.com", null, null, "Natalie", "Male", "Muller", "탙岱쌻߉ԇዳ雞᭴㊾塺", "ꔟ솁坖囘帹ᡴ䇁梉溙", 0, null, null },
                    { new Guid("5e31878a-27dc-bc1e-0ad6-ea5ebfb40e67"), new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 5, 17, 37, 33, 167, DateTimeKind.Local).AddTicks(1907), "Shaun.Lowe8@gmail.com", null, null, "Dagmar", "Female", "Gibson", "胘�뭫龙拆䔱㮣즸", "尽땍㞂盦玩㹆뒸仫쏂", 0, null, null },
                    { new Guid("639d07f3-729a-3099-5af8-48fde6b7b012"), new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 6, 0, 40, 29, 735, DateTimeKind.Local).AddTicks(153), "Jaden_Johns21@gmail.com", null, null, "Abbey", "Female", "Gleichner", "ῢ㏘变⌅妎룽⡕斬勶", "羄슓豋뒅恬ص、ﴤ䜹", 2, null, null },
                    { new Guid("64a88f11-09c8-e3d8-0820-0b22e68a4078"), new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 6, 18, 4, 0, 66, DateTimeKind.Local).AddTicks(5950), "Florence_Gaylord70@hotmail.com", null, null, "May", "Female", "Howell", "j缑똌岛杌᱌遢ၪ䶞䲞", "䟎赚罌驲꼥뙟", 0, null, null },
                    { new Guid("65f30850-3fae-d256-f585-a844d9123b10"), new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 15, 10, 17, 20, 440, DateTimeKind.Local).AddTicks(1358), "Miller74@yahoo.com", null, null, "Cornell", "Male", "Konopelski", "툒ꢟ☥䭋ሊ⻁ᢞꈟ巴", "锼䎌੥̓䆺៿瘍ݧ﫷䃃", 1, null, null },
                    { new Guid("66e0d778-d89c-772a-1e12-67cc1ead081a"), new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 10, 9, 32, 55, 186, DateTimeKind.Local).AddTicks(8465), "Terrance.Rippin23@yahoo.com", null, null, "Jean", "Female", "Klein", "땺윢ᷝ퉰騼澪头匮집", "ꌔ畍⛴ᨣ밑鱠ꮕ壜稑籢", 0, null, null },
                    { new Guid("67739aec-eb78-9aef-e0a6-9c7aaf6b5af1"), new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 28, 15, 33, 31, 496, DateTimeKind.Local).AddTicks(8436), "Preston39@yahoo.com", null, null, "Berenice", "Female", "Walsh", "浄웹竏鞒衅嬫췜Ꝏ꾷", "늁㝶⊟媍蘙웿氈溂ꐅ", 0, null, null },
                    { new Guid("69485f87-f8ac-9c92-e60d-bd72aa6df9d3"), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 6, 23, 22, 49, 739, DateTimeKind.Local).AddTicks(4413), "Sadye_Gerhold@yahoo.com", null, null, "Jayde", "Female", "Macejkovic", "硾ꘔ㶊欿椉黣姤韑郄꟟", "Ϣ↓臗躄ꠚ뼈℧赽", 0, null, null },
                    { new Guid("69dff5bb-ce1a-3fdc-e4ca-c6ac5c54bac7"), new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 14, 5, 53, 42, 16, DateTimeKind.Local).AddTicks(2455), "Tyreek_Nader@yahoo.com", null, null, "Augustus", "Female", "Boehm", "꯶ᠯ쭶儏淘㍴ꭙ酤ಃ", "ル摲ည짙ퟜ랤豑䩙", 0, null, null },
                    { new Guid("6a8372ab-3a90-33a4-b79e-f47c8d95bdab"), new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 5, 21, 21, 36, 398, DateTimeKind.Local).AddTicks(7462), "Maude_Schuppe@yahoo.com", null, null, "Adaline", "Male", "Ruecker", "턞학娞嬋봩஫뼈爿", "濨㙍뿢햷긺젯᝾ᜭ푲쏒", 2, null, null },
                    { new Guid("6a933246-2ba8-0c10-f44b-c73ae109f6d5"), new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 29, 16, 33, 8, 311, DateTimeKind.Local).AddTicks(207), "Jailyn_Thompson@gmail.com", null, null, "Obie", "Male", "Cruickshank", "摐裫瀘頉�凜冑ꅦ哈짪", "濰䩰嫹仩⽸鞲䦦䢷ퟆ൞", 1, null, null },
                    { new Guid("72d21fba-3724-47c5-4682-4201c938e103"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 6, 16, 15, 45, 890, DateTimeKind.Local).AddTicks(2664), "Woodrow.Hahn79@gmail.com", null, null, "Jadon", "Female", "Walker", "௼䍃﵅儂䜚��凢ݓ", "㨥᤿ꪌ研펢泅⌮欓대ᴖ", 0, null, null },
                    { new Guid("76895c73-e301-7823-f330-490e9e64e841"), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 25, 0, 10, 14, 4, DateTimeKind.Local).AddTicks(8540), "Heloise.Collier3@yahoo.com", null, null, "Shanon", "Male", "Bode", "鈛樤퓤ﭻ엎䊗䕂ꑕ⿞탅", "첳퇣ᦥ郥淾괘喦", 2, null, null },
                    { new Guid("78b03e07-dc3c-c7aa-a2d3-2650ac577ada"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 13, 6, 37, 54, 452, DateTimeKind.Local).AddTicks(272), "Casimer_Blick@gmail.com", null, null, "Breanne", "Female", "Mueller", "贅炤⺨逻◌�诰⒡溴ꞧ", "⾲荥䘦⦪̍忙謯疐✬", 0, null, null },
                    { new Guid("7f95f2a9-ac0b-5e14-ea26-20707a3d3ebd"), new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 25, 13, 48, 30, 115, DateTimeKind.Local).AddTicks(2084), "Matilda.Nicolas@hotmail.com", null, null, "Fleta", "Female", "Windler", "癍닮ᒍ쯀质韀䩗⬔", "�뽷拆閟歱賬≰", 2, null, null },
                    { new Guid("82a72215-10a1-8287-8b1a-fd5bed0127da"), new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 12, 9, 57, 1, 123, DateTimeKind.Local).AddTicks(3095), "Graciela3@yahoo.com", null, null, "Ettie", "Male", "Ankunding", "惏磀封竑䍅梛蔎䘫～筝", "⭤䮃�豇겕銋讀ꋥ螞", 1, null, null },
                    { new Guid("8e2b8823-9a4e-ee54-21ed-d770af98d2ed"), new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 28, 14, 40, 31, 448, DateTimeKind.Local).AddTicks(6023), "Pattie_Wisoky9@yahoo.com", null, null, "Bert", "Female", "King", "풸閼ᑁḼ椩蘢洢诗ūዟ", "⢃尸쏣ﾔ䅫ὖ⋽娐閤", 2, null, null },
                    { new Guid("8e776fde-df9c-b418-16f1-af78161d9dc8"), new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 9, 15, 39, 979, DateTimeKind.Local).AddTicks(1070), "Colton_Labadie54@gmail.com", null, null, "Shawn", "Male", "Thompson", "斩鞕⚱蜉�ﰱ鲴꒨ର⭏", "첝頻었ˁ悹꤀醨唂�", 0, null, null },
                    { new Guid("959702e4-5711-c401-6d17-ac21c5d4da60"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 5, 2, 17, 55, 958, DateTimeKind.Local).AddTicks(1552), "Gonzalo.Sauer64@yahoo.com", null, null, "Sidney", "Male", "Mayert", "进莨⊟뉲꿮艦͇갵", "跊㾃㭾髄ቀ眾ﳩ̚", 1, null, null },
                    { new Guid("96eecc70-9731-e246-48e5-5fd3e81d58c4"), new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 14, 14, 20, 29, 198, DateTimeKind.Local).AddTicks(9321), "Lenora_Breitenberg91@hotmail.com", null, null, "Earnest", "Female", "Terry", "Ɜ㼃愒䋨얬﹥맶Ộ㇥", "黓腣짔汢᭧즯見ウ", 2, null, null },
                    { new Guid("99797dab-1bfb-52c2-d891-3747209def86"), new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 12, 22, 45, 36, 862, DateTimeKind.Local).AddTicks(6449), "Alize13@hotmail.com", null, null, "Zachary", "Female", "Denesik", "狟ꛛ便罖풔덺뵃༔⛆", "惪秞ɂ馸읡᭗꬀ⲷ캫", 2, null, null },
                    { new Guid("9d4580c5-604f-3d51-e300-cd57d32ff547"), new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 14, 23, 41, 38, 814, DateTimeKind.Local).AddTicks(213), "Hanna.Kshlerin14@yahoo.com", null, null, "Kurtis", "Female", "Beer", "⮾屐脔鏭㥓⯫蓮蹛롖", "ﶻ쁛歸櫴庌얨鹼惻㋻", 1, null, null },
                    { new Guid("a1f4faee-539c-d0b8-1916-b960394c64a0"), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 10, 1, 38, 39, 367, DateTimeKind.Local).AddTicks(4703), "Wyatt_Steuber@hotmail.com", null, null, "Kennith", "Male", "Berge", "緊担㘍縅ꂑ蘲Ẏ絓滫屰", "ȱ㜆兄㔾뢓벱닉ኡࣀ鄦", 0, null, null },
                    { new Guid("a2497ba2-0f2f-7755-5f7b-2bf028817fe5"), new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 2, 3, 58, 32, 635, DateTimeKind.Local).AddTicks(4835), "Jameson12@gmail.com", null, null, "Toby", "Female", "Hegmann", "ᘖ↌鼊Ⳍ뛼腨熕蔮녉", "뉩臟ᑯ絭靾䚀뜺粁⧕", 0, null, null },
                    { new Guid("a7046255-59ff-b486-dd53-45dbfdf5d128"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 17, 8, 3, 13, 183, DateTimeKind.Local).AddTicks(455), "Ashlynn79@yahoo.com", null, null, "Christop", "Male", "Herman", "싾᫅쨡닩荷ॊ틌䨕䂖", "聹⿫ダན基�睬鬱公", 0, null, null },
                    { new Guid("a7387916-b23a-aef6-d431-0dbf5d9c4198"), new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 29, 14, 45, 31, 797, DateTimeKind.Local).AddTicks(3881), "Kian_OHara@yahoo.com", null, null, "Evangeline", "Male", "Bechtelar", "欧ަⰺꈾ颍퓺텫ⅺ᩼︣", "᝛焼ቨ๫窖茐﨡郥낊ｹ", 1, null, null },
                    { new Guid("a858d93d-0fbf-7f32-690a-98c355d1cb52"), new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 11, 18, 55, 48, 479, DateTimeKind.Local).AddTicks(3538), "Jessie_Streich44@gmail.com", null, null, "Maiya", "Female", "Steuber", "빸鍝ᯣꥋ̚㝧郐燺蛴憿", "᮴㩇捇殞闒滒먽ﭻ里℡", 2, null, null },
                    { new Guid("ad126b3a-af02-1f24-0ae3-143a231d5695"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 2, 3, 41, 25, 299, DateTimeKind.Local).AddTicks(2912), "Ara_Grady13@hotmail.com", null, null, "Alejandra", "Male", "Hayes", "㱻䐬�㾊珼舕陝퐹ꠧ", "螃丁廹袾䓖셤ᄾ䯮㗁䢛", 2, null, null },
                    { new Guid("ae48ac6f-f0c2-1fbb-25ca-f18e44d6b72d"), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 19, 6, 51, 11, 942, DateTimeKind.Local).AddTicks(3443), "Felipa_Altenwerth99@gmail.com", null, null, "Maegan", "Female", "Ebert", "ꉣﾃ奈�诟茛㪂", "㨬Ⅻ탗嵨ꗰ�팠푹喩̕", 1, null, null },
                    { new Guid("b3e3b638-a432-b5d9-7cad-5f7c6b11253b"), new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 22, 21, 16, 28, 260, DateTimeKind.Local).AddTicks(1790), "Nathanael.Nicolas97@gmail.com", null, null, "Adolfo", "Male", "Bahringer", "ଦ䛥鐎엨�淬Ȱﳘ姝", "ᬆ䛆ኇ௺採續಍㽵ᶙ팊", 1, null, null },
                    { new Guid("b4d11b30-1c2d-aac5-5a34-2cf401ac0004"), new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 9, 5, 3, 59, 800, DateTimeKind.Local).AddTicks(3600), "Lesley18@gmail.com", null, null, "Avery", "Male", "Nitzsche", "訁�낏烝ن侭긤ƺଡ଼", "识ᵒ蛪潽ⱄ탴ⴘ", 2, null, null },
                    { new Guid("b53957f5-593c-342c-0303-f63193d63148"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 3, 20, 49, 15, 74, DateTimeKind.Local).AddTicks(7997), "Cali.Emard@hotmail.com", null, null, "Santino", "Female", "Borer", "�粴昲ᱚķ઱㘆剓愝䌺", "羲菴욂솛뵻��볒ᥤ", 2, null, null },
                    { new Guid("bba555f5-1c76-2071-e73a-39ccfe32b969"), new DateTime(2023, 4, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 29, 2, 13, 18, 254, DateTimeKind.Local).AddTicks(6276), "Werner.Schneider@yahoo.com", null, null, "Elvie", "Female", "Bayer", "砵㘓運窉㤟䪓褌湏⁝", "ꢨ鴉ﺳ܃㶔뉨�汾", 1, null, null },
                    { new Guid("bec9aaca-5e97-5bff-143f-1e929902372d"), new DateTime(2023, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 7, 16, 46, 8, 196, DateTimeKind.Local).AddTicks(2617), "Bud23@yahoo.com", null, null, "Garnett", "Male", "Goldner", "猉⯋룹鎆뽜⏖歔銽䑻㞍", "ꆗ׼䨺ޖꏯ枺쥭핝끨", 2, null, null },
                    { new Guid("bf8759b8-5935-d3e0-7e85-d87cc47adc1b"), new DateTime(2023, 4, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 25, 12, 0, 49, 527, DateTimeKind.Local).AddTicks(8140), "Karen78@hotmail.com", null, null, "Una", "Male", "Kovacek", "꾹慁螵闁䷃ꂱ뽤䍐ặ啈", "烴쟠嚨駜䶵䶩뢅倨ힴ", 0, null, null },
                    { new Guid("c3eadbd8-6984-221d-1c26-291dffc9c3b3"), new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 21, 8, 19, 59, 315, DateTimeKind.Local).AddTicks(2979), "Olen_Romaguera66@hotmail.com", null, null, "Willa", "Male", "Herzog", "ቡր䩸⠪링靾鞌�貇핑", "꺐넚夆狝ꠗ鏏姩�ퟁ퉁", 2, null, null },
                    { new Guid("c5cea935-9b55-8d80-4e05-1466538d901f"), new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 5, 11, 51, 59, 798, DateTimeKind.Local).AddTicks(262), "Allene52@yahoo.com", null, null, "Maida", "Female", "Hintz", "ϖ梖厵膃ꖮ愆燴뀗荜팓", "Ꜻ魼ꔭ␷ﮘዒ尽瀝㿧䰑", 1, null, null },
                    { new Guid("ca1853ad-3d23-39fa-807a-3a9d7eacef4f"), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 27, 20, 56, 20, 697, DateTimeKind.Local).AddTicks(7564), "Janelle29@gmail.com", null, null, "Jena", "Female", "Tromp", "ᡳ滿�﶐읲鶑掲ᅑᇭ反", "᳗蜯锨腵埥댰ゅ諃춲俷", 0, null, null },
                    { new Guid("cbd098f3-04d5-deac-4101-3b057f897bb1"), new DateTime(2023, 10, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 20, 5, 45, 56, 708, DateTimeKind.Local).AddTicks(3990), "Evelyn_Jenkins@hotmail.com", null, null, "Katrina", "Female", "Purdy", "㝹쿚世ᄛ玚輊⪾呈䪢홳", "㱃쳻襘㧙ᘅ̈፰┻螟뎺", 1, null, null },
                    { new Guid("ce058b36-8464-3d72-57e8-3978674a3cc3"), new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 10, 18, 47, 24, 301, DateTimeKind.Local).AddTicks(2906), "Hildegard.Schaden@hotmail.com", null, null, "Cameron", "Female", "Ortiz", "箑縁ß긱诼ﵒ텞ḃﱏ", "뻺꿁嗭䤩ﰊ泊￁郲ꂕ", 0, null, null },
                    { new Guid("d03fc0fd-11eb-b1bb-c1f9-90c47b501888"), new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 2, 7, 27, 9, 40, DateTimeKind.Local).AddTicks(6362), "Lemuel21@hotmail.com", null, null, "Erich", "Male", "Stokes", "텔ၽ쓹⑄熌会玹㶳", "䤰눀칩㹇묮腧�卮깘筂", 0, null, null },
                    { new Guid("d67ad5e6-8fcc-27f1-ce2b-ecc500183800"), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 11, 10, 0, 54, 976, DateTimeKind.Local).AddTicks(7733), "Verda94@yahoo.com", null, null, "Julio", "Female", "Bogisich", "発굲㗬㤱彵棍弌הּ쌋", "崜ꕖ⡢롙孵ꅒ炭䗙幀渜", 1, null, null },
                    { new Guid("d92cc03c-23a2-7d67-134d-6c96ed87f959"), new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 18, 0, 24, 51, 418, DateTimeKind.Local).AddTicks(3459), "Yesenia_Wyman34@hotmail.com", null, null, "Nels", "Male", "Pfeffer", "杓ᨨሺ硦韟瓸푬", "吘婪從苻ဨ蟪ᣂ巪", 1, null, null },
                    { new Guid("d9c9994e-d33a-b594-83f7-2b6787668b73"), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 23, 7, 9, 10, 637, DateTimeKind.Local).AddTicks(4811), "Gwendolyn91@hotmail.com", null, null, "Katheryn", "Male", "Treutel", "�䊵씾ᱴ졗䃷蹕槀獆", "㓙౜㾿멯ℰ䓥悌별Ӧ憎", 1, null, null },
                    { new Guid("da2d8833-861c-62b8-d029-b108885a1c45"), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 24, 17, 35, 51, 546, DateTimeKind.Local).AddTicks(2861), "Chadd5@yahoo.com", null, null, "Casimir", "Male", "Nader", "ꓚ璼臭윌䴄葥털빠쯓㡗", "ᡂ煹䕴뒔ꭗ组㭒璶匈่", 2, null, null },
                    { new Guid("da41e7c8-765a-446e-a68f-6855e41000e6"), new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 28, 21, 27, 31, 29, DateTimeKind.Local).AddTicks(7508), "Laverne.Nikolaus@gmail.com", null, null, "Dexter", "Male", "Rempel", "�鶏�劌뤻úⅹ啶箛", "䮕❥苃ꊇᱜ軚ͮɒ焽", 0, null, null },
                    { new Guid("da9f5920-0841-3cfe-289c-283a6cc6d42a"), new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 22, 8, 27, 0, 793, DateTimeKind.Local).AddTicks(761), "Rosendo_Cormier@gmail.com", null, null, "Melany", "Female", "Marks", "㚦鵞퓐兪䪥喏㍸焾᭜欜", "䰠�尣ꖩ轸釥ఞ雅㳇惖", 0, null, null },
                    { new Guid("dc734178-b2bd-9f75-38a8-928cc25ebbe0"), new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 13, 10, 23, 44, 868, DateTimeKind.Local).AddTicks(7089), "Jamie.Botsford46@hotmail.com", null, null, "Rosalyn", "Male", "Trantow", "㿪▋⿿䤠镭䫝㟛沗", "멟ㇳ腊钪㬏㌹⧋꒽뽫", 2, null, null },
                    { new Guid("dd3ce7cb-5d3b-1ca6-a1af-86ac08c10978"), new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 13, 5, 51, 961, DateTimeKind.Local).AddTicks(3027), "Jada91@hotmail.com", null, null, "Alice", "Male", "Rowe", "턷�灾悶嘞摫ቸ諘", "㝇索Ⲥ�蝽㸺鉼氃ڱ", 2, null, null },
                    { new Guid("def53f0e-f4ef-cf0d-a273-7b5822350737"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 25, 17, 14, 44, 119, DateTimeKind.Local).AddTicks(5960), "Bethany_Powlowski90@gmail.com", null, null, "Magdalena", "Male", "Mann", "ר㖟礩죣顮랠讀脴毧솿", "惡Ꮈ姗눹憅桌羲", 2, null, null },
                    { new Guid("e1cec46e-e8e7-23b9-18b2-54c0c7d27751"), new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 7, 14, 37, 30, 777, DateTimeKind.Local).AddTicks(6766), "Bridget.King@yahoo.com", null, null, "Kenyatta", "Female", "Trantow", "넚娸❑斯ޕ췽꩘꺽豀", "Ỳ䚌怳肁ᣲˢ뜂�晫ꊟ", 2, null, null },
                    { new Guid("e4372be3-37b8-ae80-f6a5-f0d8e2082631"), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 19, 10, 20, 57, 866, DateTimeKind.Local).AddTicks(4977), "Murray22@gmail.com", null, null, "Leanne", "Male", "Carroll", "坬ほ䦡淸㇪ཱི鰷ꀣ⑐", "�ꛪ㉣䭱崙◢禞◓", 0, null, null },
                    { new Guid("e5d720dc-2b8c-6ebc-c848-3458887dd7dd"), new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 4, 53, 4, 146, DateTimeKind.Local).AddTicks(8726), "Savion_Sipes@gmail.com", null, null, "Iva", "Female", "Hoppe", "삳楩遹꩖艺嘾’맺礡噩", "眷ඇꅸ཈禸Ŗ鷖陁蜈�", 2, null, null },
                    { new Guid("ef1b4f0a-dde4-9fde-c1bf-e6dea7688813"), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 19, 6, 14, 994, DateTimeKind.Local).AddTicks(632), "Maddison33@hotmail.com", null, null, "Enos", "Male", "Schmitt", "�띎㘎�뇍浒僃뇗䙏", "騂毒门Ⅷ퀍菵뭍떞�豓", 0, null, null },
                    { new Guid("ef292764-4e1e-7159-6947-8078c1930e9d"), new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 22, 16, 18, 28, 144, DateTimeKind.Local).AddTicks(8209), "Gayle.Bins4@hotmail.com", null, null, "Ricardo", "Male", "Langworth", "藾尹ᬲ歬஼脶ꐡ봌", "㠬퇋焞㯝裏酏庎ር", 0, null, null },
                    { new Guid("f0b16ca0-501f-d402-c9d9-195084137bbd"), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 17, 13, 27, 53, 683, DateTimeKind.Local).AddTicks(5374), "Gretchen_Hudson@gmail.com", null, null, "Diego", "Female", "Turner", "揦瞓頔̋직慾屭", "鳋ﺫڙ㒧䦀셲㓒既썗䐁", 2, null, null },
                    { new Guid("f448a69e-1c80-82d8-3b75-0a35ee74cdba"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 13, 3, 17, 26, 383, DateTimeKind.Local).AddTicks(7663), "Gerald66@gmail.com", null, null, "Deron", "Female", "Strosin", "⊚㾓Ἶᖘﶍ툲ꨢݱ菎ᧅ", "袈혎ﰚ룚㢿♺츠瓃�欚", 2, null, null },
                    { new Guid("f6a1b377-c8d0-bcb5-4af3-9b3f7cac1278"), new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 2, 52, 38, 89, DateTimeKind.Local).AddTicks(5892), "Tanya37@gmail.com", null, null, "Ashleigh", "Female", "Bernhard", "ܖ୼춑Ԥ�悽찷삝", "�꬞퐙ꔆ๫�ܜꮍለ", 0, null, null },
                    { new Guid("f864e468-3ef4-37d3-320c-cc1d369dc3b5"), new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 24, 5, 36, 9, 780, DateTimeKind.Local).AddTicks(9731), "Darrell91@yahoo.com", null, null, "Morgan", "Male", "Champlin", "ﲹ鍥䧇廅䧝黬ᄬ춙秢⢩", "ႋ菖쵳᪔㰯Ỻ留蔠", 2, null, null },
                    { new Guid("fb100e8c-5051-7373-b97e-c25202896c8d"), new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 17, 21, 40, 26, 756, DateTimeKind.Local).AddTicks(4272), "Misael_Gulgowski98@yahoo.com", null, null, "Roxanne", "Male", "Bauch", "ꭻဋ䲳䖳打ࣄ媄揘✍", "뽸莰ꊝᡎ誅퓾昬㑔䧹呌", 2, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeVersions");
        }
    }
}
