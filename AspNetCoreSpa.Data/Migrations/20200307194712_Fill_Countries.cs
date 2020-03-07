using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSpa.Data.Migrations
{
    public partial class Fill_Countries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8ede10e9-4443-47a9-b342-e58b485d461f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ad45d8db-07f6-4b03-adb9-169c21e8682d"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "RegionCode" },
                values: new object[,]
                {
                    { new Guid("8a6ccdee-7cb5-4f7d-a138-a0280ae18434"), "Afghanistan", "AFG" },
                    { new Guid("b514cd7f-e8c2-47f6-8a53-15e898d448d5"), "Norfolk Island", "NFK" },
                    { new Guid("a3e73fff-c491-4401-91b3-ee10ac7c73c5"), "North Korea", "PRK" },
                    { new Guid("b38c12f6-5075-4d63-b59c-01f5a82ee604"), "Northern Mariana Islands", "MNP" },
                    { new Guid("4a2ae710-a1fa-47da-8567-9619ead35007"), "Norway", "NOR" },
                    { new Guid("97426f38-ce9c-40cc-91bc-056a1b5e1c33"), "Oman", "OMN" },
                    { new Guid("fb062b0b-b5a2-4437-998c-fd971b259987"), "Pakistan", "PAK" },
                    { new Guid("8c74c902-3932-40b7-9fa6-829aade592a8"), "Palau", "PLW" },
                    { new Guid("36112f03-36b2-49fe-95cf-827a52d388e3"), "Palestine", "PSE" },
                    { new Guid("068034d9-9cde-42c6-bba1-d98e13863c07"), "Panama", "PAN" },
                    { new Guid("e25b0975-cdc1-4400-ad43-d23192cba24a"), "Papua New Guinea", "PNG" },
                    { new Guid("9df7c8b7-9598-4260-b8f0-f60fa662f71d"), "Paraguay", "PRY" },
                    { new Guid("d9597381-99fe-4e76-8851-a7a1eba3162d"), "Peru", "PER" },
                    { new Guid("9635e7f0-0487-4f9d-935b-eb9cdd50837c"), "Philippines", "PHL" },
                    { new Guid("06180615-62b8-4c31-8df9-bea774b097c2"), "Poland", "POL" },
                    { new Guid("98e2972e-fd62-451f-8644-02b3583d486e"), "Portugal", "PRT" },
                    { new Guid("7aa21b5a-1c8f-498b-8894-fc1b8c8a377a"), "Puerto Rico", "PRI" },
                    { new Guid("a0b98187-d853-410b-9912-e2696003a64c"), "Qatar", "QAT" },
                    { new Guid("fecca425-4190-4f5b-a3f9-0879763c827f"), "Congo", "COG" },
                    { new Guid("b920afb8-8877-4c92-939d-29e3dcc1e65a"), "Réunion", "REU" },
                    { new Guid("96a85540-a5b7-450c-9142-81c1789a75f3"), "Romania", "ROU" },
                    { new Guid("9238d4ce-b50e-4b39-be5d-04b6eac94689"), "Russia", "RUS" },
                    { new Guid("733eefe1-8824-467e-8b0d-e840668c1aa2"), "Rwanda", "RWA" },
                    { new Guid("00ee0ba9-7e01-42a2-8256-233d7883bc69"), "Saint Barthélemy", "BLM" },
                    { new Guid("e279ee55-ef69-46b6-85d8-8498134ff5ad"), "Saint Helena", "SHN" },
                    { new Guid("4f43e434-d5d5-45ff-8823-36359794b37f"), "Saint Kitts and Nevis", "KNA" },
                    { new Guid("4c0f1804-5aab-4513-ae68-7555288727c7"), "Niue", "NIU" },
                    { new Guid("2b9d2a06-fec2-4835-b3cf-018315c5de95"), "Saint Martin", "MAF" },
                    { new Guid("a84fd59a-a34c-4fd7-a732-ced62b636a79"), "Nigeria", "NGA" },
                    { new Guid("46f576b8-043f-4d97-b0c4-ac70c2307509"), "Nicaragua", "NIC" },
                    { new Guid("4fc48814-f89d-40cd-a519-49096de71c5b"), "Malawi", "MWI" },
                    { new Guid("e897607d-caa5-4600-a730-a1773ddf78dc"), "Malaysia", "MYS" },
                    { new Guid("70a4a353-bcb2-4d81-bd0c-de61fb02d2d2"), "Maldives", "MDV" },
                    { new Guid("2069296b-5a6f-4307-a024-4718046969e9"), "Mali", "MLI" },
                    { new Guid("86704fa4-1a45-4edf-9f9a-cb514b323c26"), "Malta", "MLT" },
                    { new Guid("d671ea5a-5ca5-4627-911a-02ab5d2720f7"), "Marshall Islands", "MHL" },
                    { new Guid("4da76031-86b0-4ca6-ba4c-9e5264ec28bb"), "Martinique", "MTQ" },
                    { new Guid("4ff9d14f-973a-48c8-b468-ff2b9360f85a"), "Mauritania", "MRT" },
                    { new Guid("cbc0780c-1c7c-4385-92a3-cac700e9383e"), "Mauritius", "MUS" },
                    { new Guid("0689e7db-1c26-4927-a6e5-9060c5e37ef6"), "Mayotte", "MYT" },
                    { new Guid("3beff3ec-d592-4e64-8141-ede0d7926d9d"), "Mexico", "MEX" },
                    { new Guid("69114e5e-5291-490c-9546-86f7f7db5ed9"), "Moldova", "MDA" },
                    { new Guid("75cd247e-7a92-407d-ab02-ea555db956f5"), "Monaco", "MCO" },
                    { new Guid("f224e513-82d1-4b02-ad14-da99c58dec5f"), "Mongolia", "MNG" },
                    { new Guid("ff5afbf0-bc33-456b-8c6e-b4eb10e1974a"), "Montenegro", "MNE" },
                    { new Guid("816ff37c-39bd-433d-93b9-7380426e0a80"), "Montserrat", "MSR" },
                    { new Guid("402fabc6-831c-40c0-8b6e-97a92a6cfca2"), "Morocco", "MAR" },
                    { new Guid("95f64d39-97f3-4437-b8bd-808131d6a378"), "Mozambique", "MOZ" },
                    { new Guid("a03d69c5-f1c2-4961-a5a3-dc66d87e2e8a"), "Namibia", "NAM" },
                    { new Guid("a8b8698e-6aa3-46a6-a936-56165fe06453"), "Nauru", "NRU" },
                    { new Guid("576495e5-df84-425a-b7fc-c395dc469059"), "Nepal", "NPL" },
                    { new Guid("ea477cc6-2983-42d8-a640-2f82ed16bbb5"), "Netherlands", "NLD" },
                    { new Guid("27fe9e3e-59e7-4148-bf6a-642b59d308fc"), "Netherlands Antilles", "ANT" },
                    { new Guid("9b7e6263-ae2f-48fd-85d4-e964330c8bc3"), "New Caledonia", "NCL" },
                    { new Guid("2e008a42-65b9-476b-b2b8-29c2ebfeac02"), "New Zealand", "NZL" },
                    { new Guid("f95cb30f-05b0-415f-a490-028ecd7287c6"), "Niger", "NER" },
                    { new Guid("b31f8b76-418b-4281-a69d-58aaa91f6f6a"), "Saint Pierre and Miquelon", "SPM" },
                    { new Guid("ea999b03-3dd8-4c27-a1cd-c2e3871f50c0"), "Saint Vincent and the Grenadines", "VCT" },
                    { new Guid("02c0dc8d-b263-4660-b732-2265c5d13e69"), "Samoa", "WSM" },
                    { new Guid("42955299-cef4-4bf9-b6cd-d790c7aa32e6"), "Gambia", "GMB" },
                    { new Guid("7692fd4b-3ca2-42f0-b48c-9b5f1772d83b"), "Timor-Leste", "TLS" },
                    { new Guid("18cc6fbb-9901-4323-8395-a91255a327db"), "Togo", "TGO" },
                    { new Guid("8182fe27-e767-4a6f-9953-4e79830f53aa"), "Tokelau", "TKL" },
                    { new Guid("e3c1979a-91fa-4ba0-a463-f9020fa62107"), "Tonga", "TON" },
                    { new Guid("3d341b6b-393d-4685-80cf-df2b90f76c9b"), "Trinidad and Tobago", "TTO" },
                    { new Guid("8dc81940-df37-4300-b831-d6748ca5b006"), "Tunisia", "TUN" },
                    { new Guid("d87f4c8c-7c76-4c8d-9c2e-0369aaa95dca"), "Turkey", "TUR" },
                    { new Guid("4017a8a5-4009-4c60-a8e5-9008ee143e78"), "Turkmenistan", "TKM" },
                    { new Guid("cb613895-5d9b-4d63-a3e0-8126fcddbb73"), "Turks and Caicos Islands", "TCA" },
                    { new Guid("7a8ebb2b-3ff4-4ea1-b3a9-34f8beffee17"), "Tuvalu", "TUV" },
                    { new Guid("0fc1434b-7bda-4dc6-8113-9d3e964dd1ba"), "Uganda", "UGA" },
                    { new Guid("50fbfe12-6996-41c7-a80b-1dc68cca64c3"), "Ukraine", "UKR" },
                    { new Guid("9dead4d9-c580-4671-9274-f7c914bfc69f"), "United Arab Emirates", "ARE" },
                    { new Guid("04c34188-2795-4261-9a3a-cc438d4dc077"), "United Kingdom", "GBR" },
                    { new Guid("22920a80-a37c-4c6d-9f4a-4987f19f01cb"), "United States", "USA" },
                    { new Guid("72cbd740-c660-4bfd-b330-752e85e13336"), "Uruguay", "URY" },
                    { new Guid("3ab696b0-aee2-4719-8bf4-27d82dd21add"), "U.S. Virgin Islands", "VIR" },
                    { new Guid("a774386a-7a4c-4a96-9e68-b314eb43f071"), "Uzbekistan", "UZB" },
                    { new Guid("7ef2f495-062a-41f3-8656-55a6fce77d5e"), "Vanuatu", "VUT" },
                    { new Guid("08291284-85a1-4b7b-a5cf-ca2b66a40492"), "Vatican City", "VAT" },
                    { new Guid("b20a48df-b3ee-4381-82d5-99fd0a2f86f6"), "Venezuela", "VEN" },
                    { new Guid("7259f1ea-8276-4148-8fb2-9c184d5e8fce"), "Vietnam", "VNM" },
                    { new Guid("94f11506-8574-40b4-8527-150726421558"), "Wallis and Futuna", "WLF" },
                    { new Guid("6de2322d-4fee-46c8-9e32-0afda7b72764"), "Yemen", "YEM" },
                    { new Guid("9ff96a93-405c-4c4a-b350-9142b54798ba"), "Bahamas", "BHS" },
                    { new Guid("289fc561-290d-475e-9955-0c443b7eca28"), "Thailand", "THA" },
                    { new Guid("f336f2ba-cd3f-4acd-a487-176e3d52f861"), "Tanzania", "TZA" },
                    { new Guid("2b2ffa09-0a22-41d0-a5b3-480ecef730f8"), "Tajikistan", "TJK" },
                    { new Guid("56e024f5-cc64-4a98-8d34-f93e36106e85"), "San Marino", "SMR" },
                    { new Guid("64a6c93a-6a8c-4177-b64f-8f64742f787d"), "São Tomé and Príncipe", "STP" },
                    { new Guid("575644b9-32a0-4ad1-84a9-75187199fcbf"), "Saudi Arabia", "SAU" },
                    { new Guid("ed595310-bbfd-45a8-80df-8f3b6ee18796"), "Senegal", "SEN" },
                    { new Guid("6ef6c0df-a021-4502-9ff9-0e96b78804da"), "Serbia", "SRB" },
                    { new Guid("fa4eb665-9b96-4889-9794-1481efaed2e3"), "Seychelles", "SYC" },
                    { new Guid("2e4c64a4-bff6-4397-a981-5238ca8aa427"), "Sierra Leone", "SLE" },
                    { new Guid("55c659d0-759f-41df-af18-d6c5838c9d42"), "Singapore", "SGP" },
                    { new Guid("ac601f9a-7f48-4305-a1b4-9ef5f295cd88"), "Sint Maarten (Dutch part)", "SXM" },
                    { new Guid("7b8fe5ae-b4f8-4559-a6c8-7af8aaf8a4ec"), "Slovakia", "SVK" },
                    { new Guid("1576d87b-ef8f-48a9-884b-e8e7e03fca3e"), "Slovenia", "SVN" },
                    { new Guid("f22051e1-43b2-44d7-9ac2-3bb84a40f0d1"), "Solomon Islands", "SLB" },
                    { new Guid("2b332487-53c8-4ab0-b307-d622251863a5"), "Madagascar", "MDG" },
                    { new Guid("12e42f7d-3246-4478-8183-e981b213af83"), "Somalia", "SOM" },
                    { new Guid("1c582cb7-f8f7-4f48-9f1b-f10e8f340c14"), "South Korea", "KOR" },
                    { new Guid("7ace4da6-d415-425c-8648-565e9e6f37db"), "South Sudan", "SSD" },
                    { new Guid("c4724071-5e46-41be-876f-1e82b5c03cfc"), "Spain", "ESP" },
                    { new Guid("5caa4073-6545-4fbc-adc1-4f0fe49e1366"), "Sri Lanka", "LKA" },
                    { new Guid("3ff57e57-2cd0-44b9-9ebc-7eb7f81ce721"), "Saint Lucia", "LCA" },
                    { new Guid("66095e2c-b4fc-4b7f-83f8-ad4cc779713e"), "Sudan", "SDN" },
                    { new Guid("04b4af98-a797-430b-807d-2eb5e2e72ef9"), "Suriname", "SUR" },
                    { new Guid("3cc9ccd0-de2c-416b-8ffb-5afc1b474eb1"), "Swaziland", "SWZ" },
                    { new Guid("af7d6acf-4ef8-47c4-b0b9-158a3026568f"), "Sweden", "SWE" },
                    { new Guid("47e14ca6-b241-4adb-9228-ac7c69ae72a0"), "Switzerland", "CHE" },
                    { new Guid("70767f56-e268-4631-bdda-312852df1391"), "Syrian Arab Republic", "SYR" },
                    { new Guid("d3c5afc6-3b04-4151-9e09-df55e9925a8c"), "Taiwan", "TWN" },
                    { new Guid("c6094038-756a-4f14-bb19-cb8064430e19"), "South Africa", "ZAF" },
                    { new Guid("41a14971-09fd-417d-b535-d2acd3b950de"), "Macedonia", "MKD" },
                    { new Guid("c0e66abb-31dd-4549-be00-3db15cba0757"), "Macao", "MAC" },
                    { new Guid("7ca749a2-ca96-4d56-b1bc-00add6a62812"), "Luxembourg", "LUX" },
                    { new Guid("0b2c02c8-12e9-470b-b73e-8dee524ece33"), "Bulgaria", "BGR" },
                    { new Guid("27ec05e6-99a7-4476-9670-bf6efdef1822"), "Burkina Faso", "BFA" },
                    { new Guid("cf827c66-9701-4f20-8ac4-5980ede49b24"), "Myanmar", "MMR" },
                    { new Guid("99dbbdf2-efd3-4796-9da4-74ab77efe689"), "Burundi", "BDI" },
                    { new Guid("d985a4c7-9225-4753-8bec-af4af19d03a4"), "Cambodia", "KHM" },
                    { new Guid("439e5deb-07d5-4b9d-9cfa-8c8edd3f9c6f"), "Cameroon", "CMR" },
                    { new Guid("cf38b8ba-fe1e-46d0-8a54-145bba370af4"), "Canada", "CAN" },
                    { new Guid("98c13966-de3b-4663-9be6-df7875065092"), "Cabo Verde", "CPV" },
                    { new Guid("24e63bf3-791e-45b9-b608-f2dc2ae9a013"), "Cayman Islands", "CYM" },
                    { new Guid("9272bddc-4c44-4062-a1d1-cc5e136bbd09"), "Central African Republic", "CAF" },
                    { new Guid("0881abb3-a144-4d0d-8fdf-09a9d3fd9680"), "Chad", "TCD" },
                    { new Guid("78146aa4-3d13-4802-b94a-1fd9da247b9f"), "Chile", "CHL" },
                    { new Guid("f4f4af18-22ec-407f-9987-81d3b8b0ffc8"), "China", "CHN" },
                    { new Guid("5eae5887-8601-4138-9d52-5a2ceb763644"), "Colombia", "COL" },
                    { new Guid("703a767b-a4b4-4393-9aa2-9f2bb638e2e8"), "Comoros", "COM" },
                    { new Guid("7ae4db89-8c8d-4e4c-b16e-a20306bbb1e1"), "Cook Islands", "COK" },
                    { new Guid("c3f25679-15dc-472e-af78-b2675bf5e284"), "Costa Rica", "CRI" },
                    { new Guid("6f7f4cdb-3849-4b9e-9145-69a1f07d3304"), "Côte dIvoire", "CIV" },
                    { new Guid("28454fee-cafe-43ea-b6b9-d2901dcd00d8"), "Croatia", "HRV" },
                    { new Guid("6bb50cc3-64d7-4c3b-8b02-ae1fdb909764"), "Cuba", "CUB" },
                    { new Guid("c729fd06-8453-4609-9246-97f577d6329a"), "Curaçao", "CUW" },
                    { new Guid("ab9700a9-8475-4a2a-9e30-617479000848"), "Cyprus", "CYP" },
                    { new Guid("c8a2b90f-83f7-4573-a957-20bb17623cf6"), "Czechia", "CZE" },
                    { new Guid("4535aa6c-02f4-4a68-9ec3-079168dfa269"), "Denmark", "DNK" },
                    { new Guid("cee404b0-56f3-4fa7-b736-17dd3d9dee25"), "Djibouti", "DJI" },
                    { new Guid("8329b6bf-a79a-4670-94f9-aafc437e176b"), "Brunei Darussalam", "BRN" },
                    { new Guid("1c63135e-6377-4ec2-bfe9-5182debf7284"), "British Virgin Islands", "VGB" },
                    { new Guid("60c46921-6d88-4d2e-9a4d-8f4d149d3bc1"), "British Indian Ocean Territory", "IOT" },
                    { new Guid("9bd7e393-e95b-477e-9dd0-5b55dec0bc53"), "Brazil", "BRA" },
                    { new Guid("d67accbb-525b-4d95-83b4-f568d8b9ebda"), "Albania", "ALB" },
                    { new Guid("673a513c-141a-4175-b7b8-54f2741e5b9c"), "Algeria", "DZA" },
                    { new Guid("73155220-36c2-4011-98de-c3cfbea2981c"), "American Samoa", "ASM" },
                    { new Guid("2f0cdc4b-6850-4172-a2aa-59d28d04ebc9"), "Andorra", "AND" },
                    { new Guid("ce6daf31-2239-4448-a79a-42f3d58a3258"), "Angola", "AGO" },
                    { new Guid("ad27c9cf-b81c-4ae7-bfd4-84cfd92e911d"), "Anguilla", "AIA" },
                    { new Guid("e44fb2a3-c535-492a-ae6c-fe67fe338c21"), "Antigua and Barbuda", "ATG" },
                    { new Guid("58edadf2-91aa-405b-a52d-bf4040df45c5"), "Argentina", "ARG" },
                    { new Guid("219238e8-dfbe-4142-b3f4-47ecdd5c8f5e"), "Armenia", "ARM" },
                    { new Guid("eb3359ad-d4fe-465b-98b1-e633cc92bc06"), "Aruba", "ABW" },
                    { new Guid("9eac06ed-c820-4c8c-8915-f9105556b90d"), "Australia", "AUS" },
                    { new Guid("694aad40-f8e3-4f84-8fe1-1afb48f8cb3d"), "Austria", "AUT" },
                    { new Guid("8a1b58da-1f38-4ef2-aa2b-c79c3b170507"), "Dominica", "DMA" },
                    { new Guid("a8b621dc-9d3f-4aee-9a70-e0c203dfec1d"), "Azerbaijan", "AZE" },
                    { new Guid("144d772f-1036-4dae-9b3c-a7fcddf11824"), "Bangladesh", "BGD" },
                    { new Guid("a6d0522f-d1bc-43c8-acb9-3cb76e1c2ec8"), "Barbados", "BRB" },
                    { new Guid("5d2553c6-fb7c-4e2a-84b1-c1d092f24539"), "Belarus", "BLR" },
                    { new Guid("4a3425ae-6a3c-4a4c-9496-10ac6cc27d50"), "Belgium", "BEL" },
                    { new Guid("35361cc0-ce05-4413-9eed-5b2ae625f966"), "Belize", "BLZ" },
                    { new Guid("828f9137-a10b-49e1-afef-aa90ea66296a"), "Benin", "BEN" },
                    { new Guid("97cd6b4e-25c9-48a6-a1b2-49dd19b3061d"), "Bermuda", "BMU" },
                    { new Guid("36fc9479-812f-4ce3-bccc-cd73ae61225f"), "Bhutan", "BTN" },
                    { new Guid("9f102ae1-5116-4bcf-9ef0-c18ecaa28663"), "Bolivia", "BOL" },
                    { new Guid("3305ce72-7a64-4e8c-bd00-7e9c00c912f4"), "Bonaire, Sint Eustatius and Saba", "BES" },
                    { new Guid("33d7f0a1-8cc7-48e2-a653-d290846e2ac4"), "Bosnia and Herzegovina", "BIH" },
                    { new Guid("d76e82a3-529c-4f8a-b9f9-a93e581c3196"), "Botswana", "BWA" },
                    { new Guid("dc3c7cea-5ce5-4f1f-a063-5886dff190af"), "Bahrain", "BHR" },
                    { new Guid("a641bc11-0727-42f1-a643-bcc871d19dc5"), "Zambia", "ZMB" },
                    { new Guid("e25bce5d-c337-4dd4-93fd-6f8e94f08d03"), "Dominican Republic", "DOM" },
                    { new Guid("45efd885-0ee0-4f17-b668-909c4df57e08"), "Egypt", "EGY" },
                    { new Guid("48a13235-44f0-4f56-92ae-fce4aa83bb58"), "Hungary", "HUN" },
                    { new Guid("0a693cbc-65f5-4ffb-8922-b0a55553a38d"), "Iceland", "ISL" },
                    { new Guid("c28548b5-729a-4ebc-83bf-ec6984d63239"), "India", "IND" },
                    { new Guid("388c899b-0d72-47b0-8dff-bbdcd4f46802"), "Indonesia", "IDN" },
                    { new Guid("e06bea91-ad9d-462a-be55-410494666022"), "Iran", "IRN" },
                    { new Guid("1072344e-805b-4f1f-93f6-5af5b0c8031b"), "Iraq", "IRQ" },
                    { new Guid("a2088b83-ff3a-49b2-ae8b-911e89c958bc"), "Ireland", "IRL" },
                    { new Guid("946d06ad-1895-4da4-8905-7a9fae77c9df"), "Israel", "ISR" },
                    { new Guid("6b7ba4c5-c0ee-4833-8190-d99d298a680d"), "Italy", "ITA" },
                    { new Guid("f9466109-d0df-4f62-a2c3-9cd59beff7ab"), "Jamaica", "JAM" },
                    { new Guid("52aacdb4-7b87-4083-bd8c-c3b790069518"), "Japan", "JPN" },
                    { new Guid("f545f055-1362-44d4-817a-5cc192b46779"), "Jordan", "JOR" },
                    { new Guid("9d833226-370e-473a-89c6-c0f60102079e"), "Kazakhstan", "KAZ" },
                    { new Guid("7c168d82-7141-4842-8619-c37ca0f6e391"), "Kenya", "KEN" },
                    { new Guid("3c180902-a6ad-4a71-8ae0-54f061c4d8c8"), "Kiribati", "KIR" },
                    { new Guid("cbbd86e4-e97e-46d8-a77d-6e8c59735139"), "Kuwait", "KWT" },
                    { new Guid("1ba40b1a-3875-4d58-8659-8bcbea3cbaf6"), "Kyrgyzstan", "KGZ" },
                    { new Guid("368a872d-7673-430e-8c61-23473abeb488"), "Laos", "LAO" },
                    { new Guid("cc0574c2-2b77-4021-833b-591725bd5522"), "Latvia", "LVA" },
                    { new Guid("690a7a9c-cc32-4114-bb33-3f40c0a0c46d"), "Lebanon", "LBN" },
                    { new Guid("e7fa5cfc-4edd-4bfc-a260-0472fb5fb6cd"), "Lesotho", "LSO" },
                    { new Guid("e8091d31-eb72-49ae-8fee-cd6f18fda83c"), "Liberia", "LBR" },
                    { new Guid("bdf6d028-c631-4173-b49f-2172a6931e64"), "Libya", "LBY" },
                    { new Guid("5e30a0fd-ffd1-4622-9bd4-01cf0ed7375c"), "Liechtenstein", "LIE" },
                    { new Guid("eac40c7d-f66b-4b2f-9c11-ea3f07653d39"), "Lithuania", "LTU" },
                    { new Guid("126d4542-a972-40c5-8e9b-4d12ee1f0913"), "Hong Kong", "HKG" },
                    { new Guid("e996c821-907d-488b-a1df-e7d8c340f960"), "Honduras", "HND" },
                    { new Guid("1ef147ef-5f54-413d-b2c7-241c1193870d"), "Haiti", "HTI" },
                    { new Guid("ae5e0e81-1f98-402e-9d08-e7e06b2a9649"), "Guyana", "GUY" },
                    { new Guid("02d59fec-7e67-4fea-bbe2-cd9383f9fa1d"), "El Salvador", "SLV" },
                    { new Guid("f9a56b1d-a894-48d2-b63d-17bf5dbe8c34"), "Equatorial Guinea", "GNQ" },
                    { new Guid("a79b95a1-8b33-450f-a1e4-ed816a97841a"), "Eritrea", "ERI" },
                    { new Guid("a428fc44-7c9b-4239-a7d2-515966cfd972"), "Estonia", "EST" },
                    { new Guid("44d99676-ec83-46f3-b90b-46159a4a1500"), "Ethiopia", "ETH" },
                    { new Guid("905697e2-ee4a-41bc-9224-bb0d4a6d7a9e"), "Falkland Islands", "FLK" },
                    { new Guid("7e677911-79b8-43b2-a356-2261eb642d67"), "Faroe Islands", "FRO" },
                    { new Guid("ef888bda-ab5c-4aa7-8949-4619ab56b6a5"), "Federated States of Micronesia", "FSM" },
                    { new Guid("1cd55df4-0887-40d9-98c7-54f48805bdac"), "Fiji", "FJI" },
                    { new Guid("6da8d7f6-2a4d-47f6-90a0-903715ba9d6b"), "Finland", "FIN" },
                    { new Guid("a090bb45-52f6-4f43-a9ba-70151a966f44"), "France", "FRA" },
                    { new Guid("fceee3f9-7111-4a00-a175-35560726cfc5"), "French Guiana", "GUF" },
                    { new Guid("c7afdb0d-d3e0-4190-b490-4627d60c7b24"), "Ecuador", "ECU" },
                    { new Guid("9f27c12a-b015-4fc4-905b-9d193b774d65"), "French Polynesia", "PYF" },
                    { new Guid("9c899c11-ac55-4cbd-84d5-0d068af5269b"), "Georgia", "GEO" },
                    { new Guid("028d5555-f865-4849-8d9e-38add4ed3652"), "Germany", "DEU" },
                    { new Guid("9b9dde4a-103e-4d5c-be3c-14a6400928fc"), "Ghana", "GHA" },
                    { new Guid("8ea7a073-3a21-4a68-a48f-7cd8147d3aa8"), "Gibraltar", "GIB" },
                    { new Guid("0cbdf9a3-7423-44a4-b913-1998e1356665"), "Greece", "GRC" },
                    { new Guid("f5977133-5aa0-429b-b775-2ae8a300bdd7"), "Greenland", "GRL" },
                    { new Guid("2286efda-f9a8-413c-b20b-86423d37b0ea"), "Grenada", "GRD" },
                    { new Guid("607494b8-629e-4631-be41-7ba73075d15a"), "Guadeloupe", "GLP" },
                    { new Guid("30c63016-7050-4004-9517-828e82b251f2"), "Guam", "GUM" },
                    { new Guid("551a2d52-f553-44ea-ba18-ee8950c7f4d5"), "Guatemala", "GTM" },
                    { new Guid("16688199-f2e4-40e3-89f7-4cb44eb49435"), "Guinea", "GIN" },
                    { new Guid("83ac82f6-ca09-46fb-a821-cc1784d323f1"), "Guinea-Bissau", "GNB" },
                    { new Guid("51302767-5984-4a24-a2be-5b3fac89ddb9"), "Gabon", "GAB" },
                    { new Guid("ab4ef8a3-6be2-4d47-a6c4-22ab63cbfac2"), "Zimbabwe", "ZWE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00ee0ba9-7e01-42a2-8256-233d7883bc69"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("028d5555-f865-4849-8d9e-38add4ed3652"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("02c0dc8d-b263-4660-b732-2265c5d13e69"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("02d59fec-7e67-4fea-bbe2-cd9383f9fa1d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("04b4af98-a797-430b-807d-2eb5e2e72ef9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("04c34188-2795-4261-9a3a-cc438d4dc077"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("06180615-62b8-4c31-8df9-bea774b097c2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("068034d9-9cde-42c6-bba1-d98e13863c07"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0689e7db-1c26-4927-a6e5-9060c5e37ef6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("08291284-85a1-4b7b-a5cf-ca2b66a40492"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0881abb3-a144-4d0d-8fdf-09a9d3fd9680"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0a693cbc-65f5-4ffb-8922-b0a55553a38d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0b2c02c8-12e9-470b-b73e-8dee524ece33"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0cbdf9a3-7423-44a4-b913-1998e1356665"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0fc1434b-7bda-4dc6-8113-9d3e964dd1ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1072344e-805b-4f1f-93f6-5af5b0c8031b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("126d4542-a972-40c5-8e9b-4d12ee1f0913"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("12e42f7d-3246-4478-8183-e981b213af83"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("144d772f-1036-4dae-9b3c-a7fcddf11824"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1576d87b-ef8f-48a9-884b-e8e7e03fca3e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("16688199-f2e4-40e3-89f7-4cb44eb49435"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("18cc6fbb-9901-4323-8395-a91255a327db"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ba40b1a-3875-4d58-8659-8bcbea3cbaf6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1c582cb7-f8f7-4f48-9f1b-f10e8f340c14"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1c63135e-6377-4ec2-bfe9-5182debf7284"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1cd55df4-0887-40d9-98c7-54f48805bdac"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ef147ef-5f54-413d-b2c7-241c1193870d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2069296b-5a6f-4307-a024-4718046969e9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("219238e8-dfbe-4142-b3f4-47ecdd5c8f5e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2286efda-f9a8-413c-b20b-86423d37b0ea"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("22920a80-a37c-4c6d-9f4a-4987f19f01cb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("24e63bf3-791e-45b9-b608-f2dc2ae9a013"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("27ec05e6-99a7-4476-9670-bf6efdef1822"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("27fe9e3e-59e7-4148-bf6a-642b59d308fc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("28454fee-cafe-43ea-b6b9-d2901dcd00d8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("289fc561-290d-475e-9955-0c443b7eca28"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2b2ffa09-0a22-41d0-a5b3-480ecef730f8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2b332487-53c8-4ab0-b307-d622251863a5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2b9d2a06-fec2-4835-b3cf-018315c5de95"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2e008a42-65b9-476b-b2b8-29c2ebfeac02"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2e4c64a4-bff6-4397-a981-5238ca8aa427"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2f0cdc4b-6850-4172-a2aa-59d28d04ebc9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("30c63016-7050-4004-9517-828e82b251f2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3305ce72-7a64-4e8c-bd00-7e9c00c912f4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("33d7f0a1-8cc7-48e2-a653-d290846e2ac4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("35361cc0-ce05-4413-9eed-5b2ae625f966"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("36112f03-36b2-49fe-95cf-827a52d388e3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("368a872d-7673-430e-8c61-23473abeb488"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("36fc9479-812f-4ce3-bccc-cd73ae61225f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("388c899b-0d72-47b0-8dff-bbdcd4f46802"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3ab696b0-aee2-4719-8bf4-27d82dd21add"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3beff3ec-d592-4e64-8141-ede0d7926d9d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3c180902-a6ad-4a71-8ae0-54f061c4d8c8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3cc9ccd0-de2c-416b-8ffb-5afc1b474eb1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3d341b6b-393d-4685-80cf-df2b90f76c9b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3ff57e57-2cd0-44b9-9ebc-7eb7f81ce721"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4017a8a5-4009-4c60-a8e5-9008ee143e78"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("402fabc6-831c-40c0-8b6e-97a92a6cfca2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("41a14971-09fd-417d-b535-d2acd3b950de"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("42955299-cef4-4bf9-b6cd-d790c7aa32e6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("439e5deb-07d5-4b9d-9cfa-8c8edd3f9c6f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("44d99676-ec83-46f3-b90b-46159a4a1500"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4535aa6c-02f4-4a68-9ec3-079168dfa269"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("45efd885-0ee0-4f17-b668-909c4df57e08"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("46f576b8-043f-4d97-b0c4-ac70c2307509"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("47e14ca6-b241-4adb-9228-ac7c69ae72a0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("48a13235-44f0-4f56-92ae-fce4aa83bb58"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4a2ae710-a1fa-47da-8567-9619ead35007"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4a3425ae-6a3c-4a4c-9496-10ac6cc27d50"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4c0f1804-5aab-4513-ae68-7555288727c7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4da76031-86b0-4ca6-ba4c-9e5264ec28bb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4f43e434-d5d5-45ff-8823-36359794b37f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4fc48814-f89d-40cd-a519-49096de71c5b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4ff9d14f-973a-48c8-b468-ff2b9360f85a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("50fbfe12-6996-41c7-a80b-1dc68cca64c3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("51302767-5984-4a24-a2be-5b3fac89ddb9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("52aacdb4-7b87-4083-bd8c-c3b790069518"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("551a2d52-f553-44ea-ba18-ee8950c7f4d5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("55c659d0-759f-41df-af18-d6c5838c9d42"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("56e024f5-cc64-4a98-8d34-f93e36106e85"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("575644b9-32a0-4ad1-84a9-75187199fcbf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("576495e5-df84-425a-b7fc-c395dc469059"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("58edadf2-91aa-405b-a52d-bf4040df45c5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5caa4073-6545-4fbc-adc1-4f0fe49e1366"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5d2553c6-fb7c-4e2a-84b1-c1d092f24539"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5e30a0fd-ffd1-4622-9bd4-01cf0ed7375c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5eae5887-8601-4138-9d52-5a2ceb763644"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("607494b8-629e-4631-be41-7ba73075d15a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("60c46921-6d88-4d2e-9a4d-8f4d149d3bc1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("64a6c93a-6a8c-4177-b64f-8f64742f787d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("66095e2c-b4fc-4b7f-83f8-ad4cc779713e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("673a513c-141a-4175-b7b8-54f2741e5b9c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("690a7a9c-cc32-4114-bb33-3f40c0a0c46d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("69114e5e-5291-490c-9546-86f7f7db5ed9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("694aad40-f8e3-4f84-8fe1-1afb48f8cb3d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6b7ba4c5-c0ee-4833-8190-d99d298a680d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6bb50cc3-64d7-4c3b-8b02-ae1fdb909764"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6da8d7f6-2a4d-47f6-90a0-903715ba9d6b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6de2322d-4fee-46c8-9e32-0afda7b72764"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6ef6c0df-a021-4502-9ff9-0e96b78804da"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6f7f4cdb-3849-4b9e-9145-69a1f07d3304"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("703a767b-a4b4-4393-9aa2-9f2bb638e2e8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("70767f56-e268-4631-bdda-312852df1391"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("70a4a353-bcb2-4d81-bd0c-de61fb02d2d2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7259f1ea-8276-4148-8fb2-9c184d5e8fce"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("72cbd740-c660-4bfd-b330-752e85e13336"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("73155220-36c2-4011-98de-c3cfbea2981c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("733eefe1-8824-467e-8b0d-e840668c1aa2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("75cd247e-7a92-407d-ab02-ea555db956f5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7692fd4b-3ca2-42f0-b48c-9b5f1772d83b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("78146aa4-3d13-4802-b94a-1fd9da247b9f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7a8ebb2b-3ff4-4ea1-b3a9-34f8beffee17"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7aa21b5a-1c8f-498b-8894-fc1b8c8a377a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7ace4da6-d415-425c-8648-565e9e6f37db"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7ae4db89-8c8d-4e4c-b16e-a20306bbb1e1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7b8fe5ae-b4f8-4559-a6c8-7af8aaf8a4ec"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7c168d82-7141-4842-8619-c37ca0f6e391"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7ca749a2-ca96-4d56-b1bc-00add6a62812"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7e677911-79b8-43b2-a356-2261eb642d67"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7ef2f495-062a-41f3-8656-55a6fce77d5e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("816ff37c-39bd-433d-93b9-7380426e0a80"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8182fe27-e767-4a6f-9953-4e79830f53aa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("828f9137-a10b-49e1-afef-aa90ea66296a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8329b6bf-a79a-4670-94f9-aafc437e176b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("83ac82f6-ca09-46fb-a821-cc1784d323f1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("86704fa4-1a45-4edf-9f9a-cb514b323c26"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8a1b58da-1f38-4ef2-aa2b-c79c3b170507"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8a6ccdee-7cb5-4f7d-a138-a0280ae18434"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c74c902-3932-40b7-9fa6-829aade592a8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8dc81940-df37-4300-b831-d6748ca5b006"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8ea7a073-3a21-4a68-a48f-7cd8147d3aa8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("905697e2-ee4a-41bc-9224-bb0d4a6d7a9e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9238d4ce-b50e-4b39-be5d-04b6eac94689"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9272bddc-4c44-4062-a1d1-cc5e136bbd09"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("946d06ad-1895-4da4-8905-7a9fae77c9df"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("94f11506-8574-40b4-8527-150726421558"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("95f64d39-97f3-4437-b8bd-808131d6a378"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9635e7f0-0487-4f9d-935b-eb9cdd50837c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("96a85540-a5b7-450c-9142-81c1789a75f3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("97426f38-ce9c-40cc-91bc-056a1b5e1c33"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("97cd6b4e-25c9-48a6-a1b2-49dd19b3061d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("98c13966-de3b-4663-9be6-df7875065092"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("98e2972e-fd62-451f-8644-02b3583d486e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("99dbbdf2-efd3-4796-9da4-74ab77efe689"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9b7e6263-ae2f-48fd-85d4-e964330c8bc3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9b9dde4a-103e-4d5c-be3c-14a6400928fc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9bd7e393-e95b-477e-9dd0-5b55dec0bc53"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9c899c11-ac55-4cbd-84d5-0d068af5269b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9d833226-370e-473a-89c6-c0f60102079e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9dead4d9-c580-4671-9274-f7c914bfc69f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9df7c8b7-9598-4260-b8f0-f60fa662f71d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9eac06ed-c820-4c8c-8915-f9105556b90d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9f102ae1-5116-4bcf-9ef0-c18ecaa28663"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9f27c12a-b015-4fc4-905b-9d193b774d65"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9ff96a93-405c-4c4a-b350-9142b54798ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a03d69c5-f1c2-4961-a5a3-dc66d87e2e8a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a090bb45-52f6-4f43-a9ba-70151a966f44"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a0b98187-d853-410b-9912-e2696003a64c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a2088b83-ff3a-49b2-ae8b-911e89c958bc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a3e73fff-c491-4401-91b3-ee10ac7c73c5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a428fc44-7c9b-4239-a7d2-515966cfd972"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a641bc11-0727-42f1-a643-bcc871d19dc5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a6d0522f-d1bc-43c8-acb9-3cb76e1c2ec8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a774386a-7a4c-4a96-9e68-b314eb43f071"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a79b95a1-8b33-450f-a1e4-ed816a97841a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a84fd59a-a34c-4fd7-a732-ced62b636a79"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a8b621dc-9d3f-4aee-9a70-e0c203dfec1d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a8b8698e-6aa3-46a6-a936-56165fe06453"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ab4ef8a3-6be2-4d47-a6c4-22ab63cbfac2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ab9700a9-8475-4a2a-9e30-617479000848"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ac601f9a-7f48-4305-a1b4-9ef5f295cd88"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ad27c9cf-b81c-4ae7-bfd4-84cfd92e911d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ae5e0e81-1f98-402e-9d08-e7e06b2a9649"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("af7d6acf-4ef8-47c4-b0b9-158a3026568f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b20a48df-b3ee-4381-82d5-99fd0a2f86f6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b31f8b76-418b-4281-a69d-58aaa91f6f6a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b38c12f6-5075-4d63-b59c-01f5a82ee604"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b514cd7f-e8c2-47f6-8a53-15e898d448d5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b920afb8-8877-4c92-939d-29e3dcc1e65a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bdf6d028-c631-4173-b49f-2172a6931e64"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c0e66abb-31dd-4549-be00-3db15cba0757"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c28548b5-729a-4ebc-83bf-ec6984d63239"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c3f25679-15dc-472e-af78-b2675bf5e284"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c4724071-5e46-41be-876f-1e82b5c03cfc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c6094038-756a-4f14-bb19-cb8064430e19"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c729fd06-8453-4609-9246-97f577d6329a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c7afdb0d-d3e0-4190-b490-4627d60c7b24"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c8a2b90f-83f7-4573-a957-20bb17623cf6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cb613895-5d9b-4d63-a3e0-8126fcddbb73"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cbbd86e4-e97e-46d8-a77d-6e8c59735139"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cbc0780c-1c7c-4385-92a3-cac700e9383e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cc0574c2-2b77-4021-833b-591725bd5522"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ce6daf31-2239-4448-a79a-42f3d58a3258"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cee404b0-56f3-4fa7-b736-17dd3d9dee25"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cf38b8ba-fe1e-46d0-8a54-145bba370af4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cf827c66-9701-4f20-8ac4-5980ede49b24"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d3c5afc6-3b04-4151-9e09-df55e9925a8c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d671ea5a-5ca5-4627-911a-02ab5d2720f7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d67accbb-525b-4d95-83b4-f568d8b9ebda"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d76e82a3-529c-4f8a-b9f9-a93e581c3196"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d87f4c8c-7c76-4c8d-9c2e-0369aaa95dca"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d9597381-99fe-4e76-8851-a7a1eba3162d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d985a4c7-9225-4753-8bec-af4af19d03a4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dc3c7cea-5ce5-4f1f-a063-5886dff190af"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e06bea91-ad9d-462a-be55-410494666022"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e25b0975-cdc1-4400-ad43-d23192cba24a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e25bce5d-c337-4dd4-93fd-6f8e94f08d03"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e279ee55-ef69-46b6-85d8-8498134ff5ad"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e3c1979a-91fa-4ba0-a463-f9020fa62107"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e44fb2a3-c535-492a-ae6c-fe67fe338c21"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e7fa5cfc-4edd-4bfc-a260-0472fb5fb6cd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e8091d31-eb72-49ae-8fee-cd6f18fda83c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e897607d-caa5-4600-a730-a1773ddf78dc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e996c821-907d-488b-a1df-e7d8c340f960"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ea477cc6-2983-42d8-a640-2f82ed16bbb5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ea999b03-3dd8-4c27-a1cd-c2e3871f50c0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eac40c7d-f66b-4b2f-9c11-ea3f07653d39"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eb3359ad-d4fe-465b-98b1-e633cc92bc06"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ed595310-bbfd-45a8-80df-8f3b6ee18796"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ef888bda-ab5c-4aa7-8949-4619ab56b6a5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f22051e1-43b2-44d7-9ac2-3bb84a40f0d1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f224e513-82d1-4b02-ad14-da99c58dec5f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f336f2ba-cd3f-4acd-a487-176e3d52f861"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f4f4af18-22ec-407f-9987-81d3b8b0ffc8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f545f055-1362-44d4-817a-5cc192b46779"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f5977133-5aa0-429b-b775-2ae8a300bdd7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f9466109-d0df-4f62-a2c3-9cd59beff7ab"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f95cb30f-05b0-415f-a490-028ecd7287c6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f9a56b1d-a894-48d2-b63d-17bf5dbe8c34"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fa4eb665-9b96-4889-9794-1481efaed2e3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fb062b0b-b5a2-4437-998c-fd971b259987"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fceee3f9-7111-4a00-a175-35560726cfc5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fecca425-4190-4f5b-a3f9-0879763c827f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ff5afbf0-bc33-456b-8c6e-b4eb10e1974a"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnum", "RoleName" },
                values: new object[] { new Guid("8ede10e9-4443-47a9-b342-e58b485d461f"), 0, "User" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnum", "RoleName" },
                values: new object[] { new Guid("ad45d8db-07f6-4b03-adb9-169c21e8682d"), 1, "Admin" });
        }
    }
}
