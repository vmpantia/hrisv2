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
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { new Guid("00530524-f652-a940-67b9-e5771e05e6b3"), new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 9, 4, 8, 48, 255, DateTimeKind.Local).AddTicks(5535), "Theodore.Mills78@yahoo.com", null, null, "Trenton", "Female", "Prosacco", "枨욓ﴭ័잔࿳⮎逦䙫", "㆛땓뻎醋贾﷤䇪", 2, null, null },
                    { new Guid("08dc4d4a-f5fb-bdb3-0e18-f4737679429e"), new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 24, 22, 17, 55, 252, DateTimeKind.Local).AddTicks(956), "Kory_Satterfield40@gmail.com", null, null, "Ezekiel", "Male", "Schuppe", "䇔脈⪼᫼Ṡ䲎�扅⡮⯘", "큔ᣃ跛뼿吢疧쁌杷ￚ힨", 1, null, null },
                    { new Guid("098a3538-98ae-4bb3-1420-b861708f1b90"), new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 10, 0, 31, 25, 578, DateTimeKind.Local).AddTicks(7328), "Carley59@gmail.com", null, null, "Stefan", "Male", "Cassin", "ퟌ᧝䁲涤忡酙⯷ꌲ귗", "窙꙾을�㷷펟繞뢥ള슚", 2, null, null },
                    { new Guid("09f15164-9060-2895-fd4a-b8189a32e9fc"), new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 1, 1, 52, 15, 341, DateTimeKind.Local).AddTicks(4197), "Marley_Jacobi98@gmail.com", null, null, "Evans", "Female", "Conroy", "侶㇛ξꋡ憤뭪輽뾲ॐ", "綉鹲炅擖쐮鷏ܴԷ�", 0, null, null },
                    { new Guid("0e99107d-1e00-14cd-fe3f-dd888b9494dd"), new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 12, 22, 8, 59, 427, DateTimeKind.Local).AddTicks(6544), "Dahlia_Zieme@hotmail.com", null, null, "Arvid", "Male", "Nitzsche", "뜯卍膦ᇞ쯽킝㜌灾뚁播", "ᇳɅ辞员莩ꡞ센碨⮍", 0, null, null },
                    { new Guid("0eea9664-3840-fdfe-560a-7ac4a3c15cd3"), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 23, 15, 52, 9, 166, DateTimeKind.Local).AddTicks(4953), "Rosendo_OReilly9@hotmail.com", null, null, "Roy", "Female", "Nikolaus", "癔눏ᜏ쁐ꔛ謟ꡄ탃", "⯙垰睊쵓걆䪥뙃㏬帝�", 0, null, null },
                    { new Guid("109e1046-98e6-be4d-3b3f-77e604c09e55"), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 30, 15, 46, 28, 693, DateTimeKind.Local).AddTicks(9736), "Carolyne_Hansen@gmail.com", null, null, "Kayley", "Male", "Bogisich", "雱Ꝺὺﲡ킆⫉ꖏཱི䰎亀", "礠囕훵Ր舨钾麟僈牽", 2, null, null },
                    { new Guid("14cc7dd7-274c-f00d-d218-96bf8d5cc99c"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 5, 19, 8, 10, 329, DateTimeKind.Local).AddTicks(268), "Ricardo.Parisian7@gmail.com", null, null, "Jazmyn", "Female", "Stark", "㥄䟦↊朌梺䫨徖䴑", "鈮鄬쫵댞✺噇Ꮮ㒡뛀艰", 0, null, null },
                    { new Guid("1acaab7d-5a6d-32bd-daba-fbd997c2c00c"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 25, 5, 33, 48, 386, DateTimeKind.Local).AddTicks(9759), "Dayana22@yahoo.com", null, null, "Catharine", "Female", "Orn", "䉨࿄ᣉ鸵䳁湳賾ᛅ", "䀌㒿⿫滲㪍湦⎵㈣", 0, null, null },
                    { new Guid("1bf0ab5d-4d71-45fc-f488-4889250c6b93"), new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 4, 9, 15, 37, 694, DateTimeKind.Local).AddTicks(4785), "Tyree.Lind54@hotmail.com", null, null, "Jessie", "Female", "Schaefer", "ᛖ鄳雐◂╭姌킠唻", "Ƿ뷎᷆鴌餯堹ꉢ枡", 1, null, null },
                    { new Guid("245622cd-9173-3216-d501-bf75106365db"), new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 5, 4, 1, 2, 691, DateTimeKind.Local).AddTicks(5852), "Samanta38@gmail.com", null, null, "Lenora", "Female", "Turcotte", "⎶奆���雃丢닎", "ୱ鹖堆붊릥얞㛸羖", 2, null, null },
                    { new Guid("25104cd1-7a67-9185-5cf0-30b2b50efa28"), new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 21, 5, 34, 26, 996, DateTimeKind.Local).AddTicks(4934), "Eleanora_Deckow@hotmail.com", null, null, "Caden", "Male", "Torphy", "繿竄컬炆⎅裡�䖊", "䚮Ϡ黴啢Ồ膹굛鿢㹐", 1, null, null },
                    { new Guid("2812a48f-5b00-8bc0-dee5-c95f47f10752"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 22, 10, 22, 21, 529, DateTimeKind.Local).AddTicks(3034), "Rhiannon_Weissnat@hotmail.com", null, null, "Roberta", "Male", "McDermott", "啽Ⱔꕟ땗�더㤜֗", "剷ᇿ⥂ﰮ鿾䄟摝潼ᦝ▎", 0, null, null },
                    { new Guid("2b3e7ada-0777-47ba-ade0-55b5bd43282a"), new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 26, 9, 47, 26, 5, DateTimeKind.Local).AddTicks(2652), "Maeve90@yahoo.com", null, null, "Layla", "Female", "Volkman", "즩얢蹼꩏෿鳘㩠舷簷夋", "ꀳ�屢ฏм㲝萧靹챏", 1, null, null },
                    { new Guid("32d378b3-349d-5201-5458-6d2833e76740"), new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 21, 5, 32, 37, 121, DateTimeKind.Local).AddTicks(7831), "Cullen_Roberts99@hotmail.com", null, null, "Geovany", "Male", "Satterfield", "驮㷎닖墔嵅阔Ὼ伨", "륥ꩮ蠶괵ꫣﵨ妰࿮捘ᇌ", 0, null, null },
                    { new Guid("348a3466-8070-3d53-3355-e4f4bdc942f2"), new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 9, 19, 30, 57, 911, DateTimeKind.Local).AddTicks(1514), "Antonetta19@yahoo.com", null, null, "Jesse", "Male", "VonRueden", "栲⒃녶뱧擵鞚᫃匐鍽", "ᴻ㨍夃㎴讠策�漂", 0, null, null },
                    { new Guid("36c80997-fca7-1bef-c990-028c4d6061b2"), new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 10, 7, 26, 59, 294, DateTimeKind.Local).AddTicks(2624), "Madisyn.Strosin69@hotmail.com", null, null, "Armando", "Male", "Feeney", "犊Ꟈ㈁ꖾ䂯�䧘꫄顶ꪱ", "馥趧싨쓞ꊉ片賃꺪뷯籰", 0, null, null },
                    { new Guid("37c0c6a0-2662-63db-2fcd-875251d5567e"), new DateTime(2023, 5, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 17, 10, 33, 30, 930, DateTimeKind.Local).AddTicks(6944), "Dulce34@yahoo.com", null, null, "Raphael", "Female", "Hilpert", "䱜៾橷裮⡤桃㴜痬斊", "⟊钓輎ふ縖쿎ⷨ૞榜瓢", 2, null, null },
                    { new Guid("39e22e15-0a7e-3649-9ff4-356a5792db30"), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 6, 5, 15, 59, 889, DateTimeKind.Local).AddTicks(5187), "Florence_Ortiz@hotmail.com", null, null, "Lucas", "Male", "Lueilwitz", "㨳燨볙︨ፓ�졑闽冇", "砇폲쀋뭔錵蒂簫䬴", 0, null, null },
                    { new Guid("3aa543dc-c1f4-c75d-a198-2fff331211fd"), new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 3, 18, 10, 24, 323, DateTimeKind.Local).AddTicks(6763), "Octavia37@yahoo.com", null, null, "Bobbie", "Female", "Olson", "܃爬듶髖㗱骆陋帿덴", "楸⤈罟謂໳鮾", 1, null, null },
                    { new Guid("3c8250af-6a60-609c-5d9a-23f83eac9791"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 29, 16, 41, 35, 577, DateTimeKind.Local).AddTicks(4095), "Sally_Nader66@yahoo.com", null, null, "Mya", "Male", "Steuber", "㮨�㚝腪叱�銅碵榐혦", "䷔´傓鴻৪蹖宍谧ᨀ", 0, null, null },
                    { new Guid("3dea3226-8882-3e34-fd1a-41d508cba01a"), new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 31, 19, 32, 5, 830, DateTimeKind.Local).AddTicks(8050), "Blake.Kreiger@yahoo.com", null, null, "Nyah", "Male", "Kertzmann", "纘ර␮搹ⴰ뮼좂", "믘☶袪敂勀놉⁞飄�", 1, null, null },
                    { new Guid("3ee027a0-13c1-7851-7577-ace534788f90"), new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 5, 8, 37, 12, 81, DateTimeKind.Local).AddTicks(4770), "Ezra.Marquardt73@hotmail.com", null, null, "Eloy", "Male", "Mueller", "⩸굫迋ࡾ⒁꓌఼", "胇啾�掋٣睾䛚묜↙뢔", 2, null, null },
                    { new Guid("3f8a47a4-96a5-5863-ee43-2d83bdd2ad8b"), new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 1, 22, 11, 9, 932, DateTimeKind.Local).AddTicks(2136), "Yasmin_Ryan7@gmail.com", null, null, "Ted", "Female", "Thiel", "霜翡囃摋袁ᗧ�铦", "፦揧䫉ᬈ瓌韅ﶵ꿕蓏ꯃ", 0, null, null },
                    { new Guid("417c1395-2d12-5a4b-41c5-b1e0303da97b"), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 5, 23, 16, 56, 167, DateTimeKind.Local).AddTicks(744), "Dahlia_Toy41@yahoo.com", null, null, "Lourdes", "Male", "Brekke", "燬ꦏ簉�沋껩荑⪘�㉟", "희痯仇홹놂띩獚ే䡘뭖", 2, null, null },
                    { new Guid("4329aadf-efc2-3e93-db09-6b06fbf2d33e"), new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 30, 11, 51, 20, 910, DateTimeKind.Local).AddTicks(9807), "Kaley_Jerde@yahoo.com", null, null, "Rolando", "Male", "Harris", "ׄ㥄ᙗꑏ⺕壋摓Ƙꪥ秽", "㷺蕭鈜ᜈಱ똤妘叻䇝", 0, null, null },
                    { new Guid("4391637e-3623-3977-5c69-8adb1f9d8cda"), new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 18, 19, 29, 13, 440, DateTimeKind.Local).AddTicks(2502), "Eleazar.Schuppe6@yahoo.com", null, null, "Rebecca", "Male", "Corkery", "靡쟖쾑坏�稉瑈", "쀅腱ꌇ괮並寈M㋹Ọ", 2, null, null },
                    { new Guid("4476b8b1-0dec-5aff-03bb-2853ca92172a"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 25, 1, 0, 15, 128, DateTimeKind.Local).AddTicks(8030), "Kristian.Bosco@hotmail.com", null, null, "Vidal", "Female", "Jacobs", "袯츳驚䠏隄銚雃刑욆�", "᱃솒狆ꌓꎢ᳥굮葙ꗜ＝", 1, null, null },
                    { new Guid("4529e205-a653-50bc-f65d-e24609cee40b"), new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 11, 14, 57, 40, 182, DateTimeKind.Local).AddTicks(9277), "Rosalind_Hegmann@hotmail.com", null, null, "Jaylin", "Female", "Flatley", "䶠喞怰㿄새翉⨵葴", "ᄬ狦司펄갿쌢䫠㤚䳗", 1, null, null },
                    { new Guid("4c65a9c0-4e25-7999-3ffa-fc0d90156bca"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 17, 1, 59, 16, 189, DateTimeKind.Local).AddTicks(2439), "Sonny.Gutmann52@hotmail.com", null, null, "Maryse", "Female", "Torphy", "ꄲ剠켅鳄쒞参뫊馻팙唵", "᫊ꧣ쌸飃譖溢虍茡갻", 0, null, null },
                    { new Guid("502fa9b1-2780-1c20-a831-eadd602ac277"), new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 26, 4, 387, DateTimeKind.Local).AddTicks(4944), "Wilhelmine85@gmail.com", null, null, "Anita", "Female", "Franecki", "鯥ॺɽ茖十㧕⇽艏앑鲒", "ަᴠ獦⭀꼣뮕ྜꖑ⒥", 2, null, null },
                    { new Guid("5472e8d7-9058-195b-a48f-9b81b398c227"), new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 3, 22, 43, 30, 298, DateTimeKind.Local).AddTicks(5907), "Petra.Ortiz49@yahoo.com", null, null, "Zaria", "Male", "Lueilwitz", "䩓庛ឨራ⹝Ҩ箈⃩餃罹", "馍❼�뗳彍鑊ꈞ牬謢㎻", 1, null, null },
                    { new Guid("5997e589-67ab-93ce-6e2f-bce5c975ae68"), new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 6, 8, 17, 41, 912, DateTimeKind.Local).AddTicks(9580), "Augusta.Sauer@hotmail.com", null, null, "Jaren", "Male", "Glover", "⌯ჵ镧皠൙ⱛᠭꂕ㤒⎍", "纩袕ᣱ⚙䐚볁ᦳ⮑ጙ", 2, null, null },
                    { new Guid("5f984d4d-619a-5475-8d51-95e6c28118ae"), new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 17, 14, 34, 56, 976, DateTimeKind.Local).AddTicks(4769), "Rene_Ledner@hotmail.com", null, null, "Jaron", "Male", "Hauck", "�鞧ꍲ㳑쳉�㧛夒", "�䪡ᛚꨳ◣甩Ᏽ䪠", 1, null, null },
                    { new Guid("60fe2526-5c78-2644-c06c-9d3e1f5efea4"), new DateTime(2023, 10, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 26, 23, 41, 8, 123, DateTimeKind.Local).AddTicks(5192), "Kali5@yahoo.com", null, null, "Colleen", "Male", "D'Amore", "ꊗꗬ廫檽⪼뱔ᣄ", "깅ࣀ냸㪁㺍뚓錶붍慃চ", 1, null, null },
                    { new Guid("62554f22-2982-6396-324b-22b6d80a3801"), new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 14, 16, 32, 44, 135, DateTimeKind.Local).AddTicks(5510), "Eduardo_Effertz29@yahoo.com", null, null, "Pauline", "Female", "Hermann", "充⋔コ�倈唦ઠ", "ᮨࢲ侭덝뀨᷄ꕲ꽈", 2, null, null },
                    { new Guid("6314e3f5-4868-84b1-54a8-00ac3100a22c"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 1, 8, 6, 41, 114, DateTimeKind.Local).AddTicks(7578), "Bud6@hotmail.com", null, null, "Kattie", "Male", "Schneider", "뫭䢈舥⁇﹢뽕쿨迄콵", "惦ﵦ흦ꄫⱇ梭嬊�Ꭺ", 0, null, null },
                    { new Guid("67f284f2-86ff-7b7b-2940-b8ca1f4f1f7d"), new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 17, 15, 37, 9, 633, DateTimeKind.Local).AddTicks(7673), "Shanel.Bradtke@hotmail.com", null, null, "Maximillian", "Female", "Reynolds", "�繵⊗儘뀸┦랎䷎ඩߗ", "ꢳ鵗걅㕌㾖᭛⇚뇽", 2, null, null },
                    { new Guid("68f44133-4465-04c9-d45e-b8f33d26c2bf"), new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 10, 14, 4, 19, 880, DateTimeKind.Local).AddTicks(7460), "Jaquan_Haley@gmail.com", null, null, "Carmela", "Male", "Dickens", "ꍷ骭횀⻦魎ḻḰꔛ㏇偓", "㲵㞷圻氎쉛懤㨧⠩", 2, null, null },
                    { new Guid("6ff85d89-b671-b79f-533a-1b4e144c2534"), new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 14, 9, 13, 49, 140, DateTimeKind.Local).AddTicks(777), "Reina91@hotmail.com", null, null, "Cesar", "Male", "Wiza", "㖰ꊥ鮐ﮈ䐮䵛⚍襐ᓉꑤ", "郤�躁鲚깘蕬䫷⺳ૂ", 2, null, null },
                    { new Guid("70b429c4-43f3-a5bd-2762-3c7411169f10"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 25, 9, 38, 32, 726, DateTimeKind.Local).AddTicks(9338), "Eriberto23@gmail.com", null, null, "Alfred", "Female", "Cummings", "뫟ﺨᮈ艉㬋仌㸸迌瘋仦", "䰠ᖘ䇑⑟ᦉ腦꭬ት", 1, null, null },
                    { new Guid("739d9238-d188-0690-acc4-4b4835f33d9c"), new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 10, 16, 10, 51, 480, DateTimeKind.Local).AddTicks(5038), "Layla_Weber74@yahoo.com", null, null, "Eva", "Female", "Steuber", "Ꮯﶢ㼴蠴辜ﳶ墸淘㑭", "븗�鰘⦯㨚蚆⺯뮪䷐", 1, null, null },
                    { new Guid("772f6822-02b2-dfa1-2a16-10e612daf8af"), new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 15, 5, 45, 19, 217, DateTimeKind.Local).AddTicks(6536), "Tristian16@gmail.com", null, null, "Annette", "Male", "Gottlieb", "⠭奟寀Ṇ케拿Ց", "ꮎꄂ髀�䝙ꜰ턽䯭", 1, null, null },
                    { new Guid("778988d1-b379-bc36-1ccc-a5058ea79dfb"), new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 16, 19, 9, 37, 622, DateTimeKind.Local).AddTicks(8989), "Talia_Zieme10@gmail.com", null, null, "Hailey", "Male", "Harris", "豑㜰癐ᔁ场⁄桙勹㓁", "ࣄȸ탨㿞�쥐", 1, null, null },
                    { new Guid("79695bdb-6f06-4c48-83ee-931136dd6791"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 11, 21, 32, 13, 728, DateTimeKind.Local).AddTicks(6991), "Molly_Bernhard76@hotmail.com", null, null, "Myrtis", "Male", "Schaden", "穘ຘᭌ끼䩈陝䵈鑢蕕", "᫃ṁꛛ饢讱缹궐牎籁강", 2, null, null },
                    { new Guid("7cd1776f-8378-420c-947f-922799972364"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 9, 0, 29, 27, 633, DateTimeKind.Local).AddTicks(5123), "Jedidiah81@hotmail.com", null, null, "Salma", "Male", "Bahringer", "懞큲登ᚫ⥘⌴쀡ߎ䪎븋", "쵅郤楥ᅑ�綩㫽焒", 0, null, null },
                    { new Guid("7e940b6e-9c6f-a4c7-7510-9a8e34d7aa11"), new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 27, 1, 9, 29, 499, DateTimeKind.Local).AddTicks(439), "Ressie.Emard@yahoo.com", null, null, "Garrison", "Male", "Leuschke", "啙榆Ѳꕩ댘媌䟾〲뒃鹉", "ᡲ⭰ᓁ�٧ﲾ䟙惕ໍ", 0, null, null },
                    { new Guid("81d9ec1c-23d4-f161-0195-b69d4ac0c9c5"), new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 13, 8, 50, 48, 127, DateTimeKind.Local).AddTicks(2243), "Joshuah15@gmail.com", null, null, "Grady", "Female", "D'Amore", "徝ⰴ㭰ͪ㙔ꆡ퍜⎬迗", "�点㨎폽뉅隀ꏋ樰뢰", 2, null, null },
                    { new Guid("824ea798-5aa4-da61-b6fa-38b0e2afc25b"), new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 3, 28, 51, 911, DateTimeKind.Local).AddTicks(924), "Dusty.Walsh@yahoo.com", null, null, "Lacy", "Male", "Zemlak", "�뚗轩俕킟륊詤臯饤ꥮ", "矩赊㡺㈧ㄏჽ禁ꒄ浛幼", 0, null, null },
                    { new Guid("83666d3c-3f21-7ec6-4679-c5f0035e3ac2"), new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 16, 13, 47, 45, 535, DateTimeKind.Local).AddTicks(5050), "Hassie_Orn85@hotmail.com", null, null, "Harley", "Female", "Rath", "�ㄩ剑;䑑贜떙䄲�", "蘿ꣿ濟藥걌倉㝯＠/", 0, null, null },
                    { new Guid("83dd1923-79e0-f05b-be81-977851e1d1d8"), new DateTime(2022, 11, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 11, 17, 2, 4, 357, DateTimeKind.Local).AddTicks(8351), "Lexie.Gutmann54@gmail.com", null, null, "Kelton", "Female", "Connelly", "㟮普絯ゴ龄玁퀋照验", "옆唱蚃ꭑᴈ�芔य़ᙧ㱉", 2, null, null },
                    { new Guid("85244d0d-ad57-f5d2-56e4-4ab5b31b2116"), new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 4, 0, 43, 50, 40, DateTimeKind.Local).AddTicks(3641), "Aric.Feeney@yahoo.com", null, null, "Kareem", "Male", "Auer", "騞硉Ծ霌솖㗷䈇於覓", "♘泓ﰗ簰軀ᆰ⬿퇾", 2, null, null },
                    { new Guid("857526dd-4588-a1af-fde4-4f3d8748f37d"), new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 30, 20, 59, 58, 106, DateTimeKind.Local).AddTicks(5365), "Vern.Schaden20@gmail.com", null, null, "Mireille", "Male", "Kunde", "�솺汱餎蠲ꀱ뷈㷷᪢꣗", "㍑厯仪䇞争魫涝", 0, null, null },
                    { new Guid("86999680-c54a-4b22-2363-d64a9efe5432"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 10, 10, 48, 15, 401, DateTimeKind.Local).AddTicks(1101), "Alec.Borer@gmail.com", null, null, "Regan", "Female", "Spencer", "ꋾದ搇䢠娦껝ࣨ噃", "籦㻇⌕�좁䖡碀꽁䀱", 1, null, null },
                    { new Guid("878fd3f1-de07-169e-c2a8-f5f37f8f224d"), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 16, 22, 47, 55, 549, DateTimeKind.Local).AddTicks(8811), "Cyril89@hotmail.com", null, null, "Elwin", "Female", "Stiedemann", "㵐魰춙뚏䢃䁒闷ʎ좉孄", "먉偓夺꘍佭㱟劫뮧㌗솊", 2, null, null },
                    { new Guid("87a8d2ec-a1b0-509e-5a2d-4ac1e88ef32b"), new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 28, 7, 42, 48, 872, DateTimeKind.Local).AddTicks(4383), "Cleve.Doyle@gmail.com", null, null, "Andreane", "Female", "Goldner", "욳欌渏쓮䍰孹鸘灅䏨投", "쀬얽仾椏䉗菳弎筲", 2, null, null },
                    { new Guid("8926abb5-f0ed-edee-2ea7-7d426184e751"), new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 26, 18, 16, 11, 3, DateTimeKind.Local).AddTicks(4563), "Hilario_Gutmann95@hotmail.com", null, null, "Kitty", "Female", "Welch", "栞纝�☵ꊣ街�鮬", "묦䕖�䥵説숶ꝏ쵌朁푱", 1, null, null },
                    { new Guid("8b9902c9-070d-8399-55cc-05ef94e84f64"), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 10, 19, 33, 39, 152, DateTimeKind.Local).AddTicks(7372), "Uriah.Bogan91@gmail.com", null, null, "Rachel", "Female", "Kertzmann", "䖰蕥맫Ā艇䏞殏㳒낹", "뿞ह⣴繉鯞於ⵙ㒼敆᭢", 2, null, null },
                    { new Guid("8cbe6815-9a33-61ab-2ed7-b69028b4b4bb"), new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 29, 4, 52, 17, 634, DateTimeKind.Local).AddTicks(6266), "Kenyatta_Russel3@yahoo.com", null, null, "Gerardo", "Female", "Wolff", "놂甪帑辪蚖녶訮拾诨", "ꄶ➮�뎥㖸ၙ퀹꘹㗹᳎", 0, null, null },
                    { new Guid("8ceac72e-8357-ee8c-e2e6-25f897626b33"), new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 10, 10, 4, 14, 456, DateTimeKind.Local).AddTicks(9605), "Harvey_Gerlach85@yahoo.com", null, null, "Enrique", "Male", "Schaden", "ʆ雿ﹻ⥨쫽儷옂㍜", "ꬕ畩鎭᭺㘙瓤怢꩑ቤ꠆", 1, null, null },
                    { new Guid("8cfebe70-55af-5b1b-cd74-8a758affdcc6"), new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 3, 6, 29, 47, 178, DateTimeKind.Local).AddTicks(6208), "Vivienne46@hotmail.com", null, null, "Flo", "Female", "Gutkowski", "�ꅱ卻諭黙壐哞厓镰", "嚀ഷ⠏≹睶ӳ窌령", 1, null, null },
                    { new Guid("8d0d4731-ff82-b06b-3ea3-b2d9dd549261"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 30, 1, 29, 11, 546, DateTimeKind.Local).AddTicks(4008), "Izabella_Kreiger@yahoo.com", null, null, "Ferne", "Male", "Schuster", "給葞퐻濍ꮤ䥑ꗫ뀔", "鄖錎兩ೃ癘喵Გ󯜨", 0, null, null },
                    { new Guid("8d387495-fe96-4913-600f-ba0d66c642d5"), new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 27, 2, 57, 16, 942, DateTimeKind.Local).AddTicks(7589), "Allene98@yahoo.com", null, null, "Cindy", "Male", "Flatley", "馆ਅ羮ㇶ�꾼釋ꭍ唑", "엳츎즕砓溸᧒䵤垯", 1, null, null },
                    { new Guid("8d8fd338-88b8-baa2-7bea-aa57349a8e14"), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 6, 11, 45, 42, 426, DateTimeKind.Local).AddTicks(2134), "Xander37@yahoo.com", null, null, "Triston", "Male", "Kassulke", "謲Ủ�ᒾ鍩ꮭ꘮䞡", "靬ގ荮䅟⍚﯆≼촁棔", 2, null, null },
                    { new Guid("9604dcab-2511-1efd-f0ef-386fc932ef67"), new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 28, 21, 44, 39, 650, DateTimeKind.Local).AddTicks(9994), "Kendall_Wuckert@hotmail.com", null, null, "Donald", "Female", "Luettgen", "殂籮嗘缎댧㸇�焿", "熈㮔ᆟᓙ옅첑ﺨࢮά璒", 0, null, null },
                    { new Guid("96309556-d41b-7579-0ad5-3f78e21be0e6"), new DateTime(2023, 7, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 11, 17, 53, 16, 146, DateTimeKind.Local).AddTicks(7635), "Johnathan_Littel@yahoo.com", null, null, "Mervin", "Female", "Stroman", "萖戮殢푯獚飙㈪퍸䗻熮", "沎㷚动㔼糛饣﷯녻", 1, null, null },
                    { new Guid("9c2e9dc9-6171-4718-a53e-6505c238831d"), new DateTime(2023, 7, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 22, 20, 46, 46, 437, DateTimeKind.Local).AddTicks(5487), "Queen_Osinski96@gmail.com", null, null, "Wyatt", "Female", "Jast", "抮臈닽뮚럎癵쀩\r产", "꽘趔饛䍐ᣥڦ㊑蒈唉", 1, null, null },
                    { new Guid("9d008b76-c445-436e-f32b-30354430bf96"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 15, 19, 25, 36, 901, DateTimeKind.Local).AddTicks(7252), "Brent54@hotmail.com", null, null, "Isac", "Female", "Crist", "曭殇웵뿑膵ڐ聚挒쵬", "⾊݁膜鎮Ⰶ놫䘦�묓", 2, null, null },
                    { new Guid("a017fe36-7db2-9c3b-8f04-6184c1493326"), new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 21, 3, 26, 9, 120, DateTimeKind.Local).AddTicks(9348), "Randall.Hansen55@yahoo.com", null, null, "Florida", "Male", "Konopelski", "殊匕낼漋쵹쀺᪷멾㦉燭", "䞉饻憖ᶓ컦틛儮쐸繳", 0, null, null },
                    { new Guid("a26f7677-f234-4685-f7db-9324220da139"), new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 4, 21, 37, 49, 221, DateTimeKind.Local).AddTicks(1588), "Leann.Connelly84@hotmail.com", null, null, "Hassie", "Female", "Morar", "˵ở緥꥙࠳扨ޥﵣ", "숕ቈ䋰�䏣極�䄳ᤗ", 0, null, null },
                    { new Guid("a3c788ae-d8cb-fcb7-14d3-54eb56f38181"), new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 4, 15, 50, 8, 886, DateTimeKind.Local).AddTicks(4170), "Robb_Runolfsson28@gmail.com", null, null, "Audreanne", "Male", "Cassin", "꘦ㇿ飵ꢄ샽囯㦫Ჷ㓥᰺", "に８㔁ݼ賎鄶㸽Ạ", 0, null, null },
                    { new Guid("a3ed64b3-ad22-c8cf-21ad-f7142b2908fd"), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 30, 7, 31, 33, 28, DateTimeKind.Local).AddTicks(1207), "Dion_Heaney@hotmail.com", null, null, "Maegan", "Male", "Jones", "ኒ੏劐ꨖ歳ඛ䋏�鵶", "㶝ᳵ덴豚Ƌ즭鍭烵耺", 1, null, null },
                    { new Guid("a48c5b46-bf04-1398-72a3-baa23887d7a6"), new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 20, 9, 32, 38, 642, DateTimeKind.Local).AddTicks(3306), "Ally.Okuneva33@hotmail.com", null, null, "Aurelia", "Male", "Schneider", "ꔻ㐛»頺맚걆禸ﾞ몪", "ᜳ㪇鞵僷橹䳒衪잂콎", 0, null, null },
                    { new Guid("aca658c0-1e0e-068a-b295-85707e599afa"), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 9, 9, 3, 35, 980, DateTimeKind.Local).AddTicks(1032), "Letitia70@hotmail.com", null, null, "Cheyanne", "Female", "Nikolaus", "뼦弽㛟筥싴㧅ਫ큑䧍", "�事聮ꃅ઴ߎ璠", 2, null, null },
                    { new Guid("ad02d2e6-9308-d242-9a4c-e2867df5c8d4"), new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 30, 20, 57, 44, 993, DateTimeKind.Local).AddTicks(6476), "Hardy_Hessel@gmail.com", null, null, "Eunice", "Female", "Mraz", "팥୚᠀볦ꧦ㧋쵲蕦岰䳶", "ꕕ㑬亼ᷴ龿鞀㸫䍵", 0, null, null },
                    { new Guid("ada78a35-2971-ebd9-6ee6-a67aa396494e"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 15, 1, 42, 30, 460, DateTimeKind.Local).AddTicks(2523), "Jabari.White2@gmail.com", null, null, "Abdiel", "Male", "Armstrong", "ᬘᛷ಍�䅩ᗑ뉅ꪡ쏖", "ꆔ췦�ପ�କ┑橁", 0, null, null },
                    { new Guid("afdd754c-75f3-485d-3b14-29572626c66e"), new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 13, 9, 54, 47, 230, DateTimeKind.Local).AddTicks(1017), "Geraldine_Williamson@hotmail.com", null, null, "Darien", "Male", "Quitzon", "꣉筘颖庑갟毎Ⱕ預䏘劏", "ስ⍴匹೦奍ꧨ嶸գꛬ", 0, null, null },
                    { new Guid("b151d8a0-bb5e-7061-38b5-349d47cc1070"), new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 27, 7, 29, 6, 8, DateTimeKind.Local).AddTicks(3671), "Anastacio24@yahoo.com", null, null, "Beryl", "Male", "Breitenberg", "袱扢蔎苋炍᫂以끗", "顁祡ᛌ؜ℎ䍙䢆뵡톲", 1, null, null },
                    { new Guid("b2ba7bf8-95b1-e4de-f0aa-15afb97d3b93"), new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 9, 1, 11, 28, 444, DateTimeKind.Local).AddTicks(3230), "Erna.Hodkiewicz69@gmail.com", null, null, "Cynthia", "Male", "Harris", "茛㵩嗝칎Ἠ倣Ꮱ珷෾Ĵ", "ؘ໪谑蹙읢㘁轟欔싀", 1, null, null },
                    { new Guid("b80e2d17-e336-ca14-85be-8db10581849b"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 16, 1, 1, 3, 507, DateTimeKind.Local).AddTicks(2470), "Reyna14@hotmail.com", null, null, "Gladyce", "Female", "Cruickshank", "㵑䣷㤴쟕칼朐켤襤ⲩ闛", "ᢙ阜ၐ䳕瘼ç뿧�൳", 1, null, null },
                    { new Guid("bb5a2681-e158-efd9-3e6a-d7b94fb751cf"), new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 5, 17, 34, 39, 853, DateTimeKind.Local).AddTicks(4560), "Makenzie21@gmail.com", null, null, "Kristofer", "Female", "Rogahn", "㷖舀㊿䧂⍄랎䉲䰋婀兑", "통뀻ឳş덢‿賃ඔ㚎뎡", 1, null, null },
                    { new Guid("bff249a1-b165-c87b-0f91-96db5cdcf422"), new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 2, 23, 30, 58, 740, DateTimeKind.Local).AddTicks(7229), "Yasmeen.Kshlerin42@gmail.com", null, null, "Chris", "Male", "Gutmann", "﻿꫅鈶嵂ᵓ招롓", "�窣㏵隥ኵ魚ⱆ⬴팙峸", 0, null, null },
                    { new Guid("c21300bf-6a8d-227a-5223-94dcc2b17c9c"), new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 15, 6, 40, 50, 965, DateTimeKind.Local).AddTicks(4811), "Rico.Ledner39@gmail.com", null, null, "Tristian", "Female", "Greenfelder", "殥精㞢ꈩ覒�뉈ṁ灔緽", "茿鲎Ү黋撊驢袼", 1, null, null },
                    { new Guid("c930a0dd-1ea0-81e8-c31a-332853c628a5"), new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 31, 21, 41, 51, 422, DateTimeKind.Local).AddTicks(6109), "Magdalena6@gmail.com", null, null, "Edgar", "Male", "Schneider", "ᨃ쪤࠱ㄫ엂屒⿟씐퀒", "㉚堌䶵逞悴팭靗䏪ጦ偟", 1, null, null },
                    { new Guid("cac19750-d2ae-3a12-ce24-829bd6a9509e"), new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 12, 7, 56, 1, 520, DateTimeKind.Local).AddTicks(2689), "Gerard.Buckridge@hotmail.com", null, null, "Brett", "Male", "Lueilwitz", "濵뷟썍౏퓰洁윮◼峬䊜", "㙱謿։ࣧ﶐㒠�ｵ쓙", 1, null, null },
                    { new Guid("cd9ad59a-12fa-302d-e4b8-218a7bd28555"), new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 21, 22, 55, 22, 440, DateTimeKind.Local).AddTicks(2794), "Neha52@gmail.com", null, null, "Winston", "Female", "Witting", "Ⓓ擌卸飦䇰Ḍ⚘༳먠", "�巿켮�㵯ҵ矉룡㒜詣", 1, null, null },
                    { new Guid("ceec5e4d-9d06-8a60-5606-7e987ef7f5ee"), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 29, 7, 57, 3, 798, DateTimeKind.Local).AddTicks(371), "Amir.Kilback1@yahoo.com", null, null, "Vida", "Male", "Yost", "睝驪瀋辅⥂둓�ᥜ祀", "ꉸ䝧㻜駈徕珆轚ⵥﮘ", 1, null, null },
                    { new Guid("d18e82da-3411-6bd2-5c5f-d7d4dc6cc9db"), new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 2, 8, 44, 18, 49, DateTimeKind.Local).AddTicks(3963), "Katlynn_Terry63@yahoo.com", null, null, "Trinity", "Male", "Schumm", "੻﬍ᛲ睋퐶埒餺ﾧ┪귺", "푦폪ꯪ⏧浘꩹ꇧ阌嫲", 0, null, null },
                    { new Guid("d2204535-aeae-d700-dc56-deb92dbe2da3"), new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 28, 19, 25, 14, 626, DateTimeKind.Local).AddTicks(108), "Eulalia_Keebler@gmail.com", null, null, "Winona", "Female", "Jaskolski", "徉갴䴁鼁嘒㊐䕥闑攣矟", "汞ㅇ�쿤臜왧鈏쬽", 1, null, null },
                    { new Guid("d2544d81-2a04-a64d-5be4-7feef6e87be0"), new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 11, 21, 50, 6, 438, DateTimeKind.Local).AddTicks(5864), "Angie.Denesik30@hotmail.com", null, null, "Hardy", "Female", "Beier", "鯵漍隥絖運䧂铆☣刚ퟳ", "㱊ǿꙟ췟ꍤ蟌폇嗘", 2, null, null },
                    { new Guid("d42a0150-57f8-e169-26ac-b1900de9bf07"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 5, 7, 37, 48, 957, DateTimeKind.Local).AddTicks(2571), "Malcolm.Hagenes@hotmail.com", null, null, "Cesar", "Female", "Glover", "绂㣌謵ᑣ玐聍킀櫲᝷�", "袞⣿閑姇�⥁诸ᩌ䒫㼕", 0, null, null },
                    { new Guid("d7f9c19f-c5dd-bb88-dd46-c6131e38fb8f"), new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 18, 0, 51, 22, 861, DateTimeKind.Local).AddTicks(8446), "Minerva86@gmail.com", null, null, "Edd", "Female", "Kovacek", "ퟱ귚ᖈᚁ᳛Ⱃ", "榱褆돿♃鴢窢ᗖ쟄翫", 0, null, null },
                    { new Guid("da9b23b3-1db4-5c87-c70f-d35f4121d486"), new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 27, 0, 32, 56, 37, DateTimeKind.Local).AddTicks(5696), "Guillermo5@gmail.com", null, null, "Julius", "Female", "Shanahan", "ꗵ辑䬭콂ㄚ？㑿隟檑脛", "际렧觴㗫鋻딳긷颩츴枠", 1, null, null },
                    { new Guid("de6f110c-a5d2-58b9-9555-b2d0692bb530"), new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 29, 18, 29, 21, 133, DateTimeKind.Local).AddTicks(5685), "Jonathan32@gmail.com", null, null, "Clifford", "Female", "Erdman", "翇鲯映ᘾ勽䀭쐋", "쬼ព傝뤰텿蒽湥탐", 1, null, null },
                    { new Guid("e4edffc1-0d8d-3bf6-6d4b-880f4c4753de"), new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 14, 10, 21, 47, 54, DateTimeKind.Local).AddTicks(4424), "Conor61@hotmail.com", null, null, "Andres", "Male", "Wilderman", "峆㺵㫝콗᾽宴㒑�", "媛②屐姃堟ﭩ是匞שּׂ", 1, null, null },
                    { new Guid("eb3b7b83-2bf6-19de-030a-cd85d68330f6"), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 30, 10, 10, 59, 970, DateTimeKind.Local).AddTicks(2871), "Lois.Glover@gmail.com", null, null, "Abdul", "Male", "Sanford", "惝앾꺄恪젎ആ阥拆", "䂍螤��㩘欋ⰳꦈ쀴", 1, null, null },
                    { new Guid("f62a3b4d-faf0-645a-6860-6207fb17f69c"), new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 5, 1, 53, 25, 747, DateTimeKind.Local).AddTicks(5984), "Lamar.Sauer65@yahoo.com", null, null, "Terry", "Female", "Glover", "뉌膴兼鴣來觻ﶚⲡ✤", "迹꩜ᶷ댐凞螩㕌鵎蠟", 0, null, null },
                    { new Guid("f83ec4c1-7785-b290-b1f9-63fb3eca4953"), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 17, 12, 39, 38, 912, DateTimeKind.Local).AddTicks(9633), "Marion.Padberg14@yahoo.com", null, null, "Geovanny", "Male", "Lynch", "蔹喼嫱ᢡ짻ཨ蔾", "쓥ᭆ鬦⎜趩䅈嫶o鞢揣", 1, null, null },
                    { new Guid("f91032c3-880b-8b7f-c5fa-71523b00ad53"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 29, 12, 27, 43, 749, DateTimeKind.Local).AddTicks(24), "Everardo_Wuckert87@gmail.com", null, null, "Carrie", "Female", "Donnelly", "랲嘯វ绀須쿭䙊쌕ࣤ랝", "儴糖奭⊝␉髿텗ӗ簘", 1, null, null },
                    { new Guid("fd543d5e-cf06-2c79-67f4-bd35d1de58f3"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 29, 4, 28, 59, 386, DateTimeKind.Local).AddTicks(2974), "Eliza_Larson71@hotmail.com", null, null, "Serena", "Female", "Boehm", "῿檻툎節虦⅖⏆뾬搎郯", "臏爜엠뎳伀앝绦ӧ᯵", 0, null, null }
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
