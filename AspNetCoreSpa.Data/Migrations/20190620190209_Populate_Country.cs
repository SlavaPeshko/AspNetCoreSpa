using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSpa.Data.Migrations
{
    public partial class Populate_Country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("960d66cb-4e0e-49a4-a56c-31dc69034c9c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f6505f3e-0f99-4d93-8887-8ce489b51375"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "RegioneCode" },
                values: new object[,]
                {
                    { new Guid("2def92d2-fff9-419c-ab65-d6aae8a04c26"), "Afghanistan", "AFG" },
                    { new Guid("a5abcc74-893d-4ff4-a207-7ef89d9005c9"), "New Caledonia", "NCL" },
                    { new Guid("0d8ab0e0-41ff-4561-b52d-e1b79ff825aa"), "New Zealand", "NZL" },
                    { new Guid("cecc5511-a2ea-4a8e-8311-c43175b09397"), "Nicaragua", "NIC" },
                    { new Guid("3c52c724-ad05-4fae-8390-542c201c81b8"), "Niger", "NER" },
                    { new Guid("70824528-59a8-4437-a802-47e70b6017ee"), "Nigeria", "NGA" },
                    { new Guid("fbaf7237-0f64-48c3-b4c9-b729e8e68df3"), "Niue", "NIU" },
                    { new Guid("8ed54c9f-ec6f-4515-ada3-569dc855944c"), "Norfolk Island", "NFK" },
                    { new Guid("c3ba17e9-c383-456a-af5b-c668d9bffa5e"), "North Macedonia", "MKD" },
                    { new Guid("c992f142-73ff-4d79-b1b4-353c50ee911f"), "Northern Mariana Islands", "MNP" },
                    { new Guid("be9f403e-d045-4188-867b-0a36deb99f77"), "Norway", "NOR" },
                    { new Guid("950959ff-35cb-46da-a435-3ff01d0c88e2"), "Oman", "OMN" },
                    { new Guid("7f596dac-f3dc-423a-8368-a0f31a0abed3"), "Pakistan", "PAK" },
                    { new Guid("4b7aa8b0-7713-407b-b06c-f467a522ce08"), "Palau", "PLW" },
                    { new Guid("f2c1b5ba-0191-4e67-a890-c8cb9faf684a"), "Palestine, State of", "PSE" },
                    { new Guid("51bb855c-1e3c-431a-bcd0-a17e54a303ea"), "Panama", "PAN" },
                    { new Guid("c8f30883-962a-4462-9357-0747da55151e"), "Papua New Guinea", "PNG" },
                    { new Guid("fab433f1-08d1-4759-8afc-1e4210a7783c"), "Paraguay", "PRY" },
                    { new Guid("c89fc0d5-2564-48cf-8003-c048dd294010"), "Peru", "PER" },
                    { new Guid("baa3e035-0181-404a-a5f8-c3980c1ce675"), "Philippines", "PHL" },
                    { new Guid("59a4d65c-6417-4b80-96b2-f076a924f6ce"), "Pitcairn", "PCN" },
                    { new Guid("4957da7a-e5e7-4a4d-982b-09d88d4a58b4"), "Poland", "POL" },
                    { new Guid("ce700e52-a116-4bf0-85ed-a8db59caab46"), "Portugal", "PRT" },
                    { new Guid("bbf1c954-5390-4488-b309-d3ec6d027dd2"), "Puerto Rico", "PRI" },
                    { new Guid("fcbbe8df-4e4f-45a5-b803-3519a075bb3e"), "Qatar", "QAT" },
                    { new Guid("63efded4-bc57-445f-b703-981e7eca8907"), "Réunion", "REU" },
                    { new Guid("2cb6716d-44fd-48f2-a123-f298909e682b"), "Romania", "ROU" },
                    { new Guid("eecc4787-2310-4331-b2b7-84036ccab00a"), "Russian Federation", "RUS" },
                    { new Guid("98478c9e-4483-43af-ab88-2c8a388cd2a1"), "Netherlands", "NLD" },
                    { new Guid("bf0e880e-b1cd-4db1-9050-ef04ca780d57"), "Rwanda", "RWA" },
                    { new Guid("e510b38a-09e3-48e9-a7fd-6c010a38ca34"), "Nepal", "NPL" },
                    { new Guid("0b415a8d-952e-4a63-8089-64cdf7505ae5"), "Namibia", "NAM" },
                    { new Guid("3ff5dac9-dc46-488c-b9e9-13ee966a9a89"), "Liberia", "LBR" },
                    { new Guid("fed9a761-08e7-419d-a492-1e6c48f46871"), "Libya", "LBY" },
                    { new Guid("f346e252-a66e-4a4f-a5ff-355bfe5278d9"), "Liechtenstein", "LIE" },
                    { new Guid("567c7931-64f7-4550-9104-993c65763c31"), "Lithuania", "LTU" },
                    { new Guid("0101ff6d-07ea-41bc-a333-135364750871"), "Luxembourg", "LUX" },
                    { new Guid("bf9d86f4-0259-437e-9158-0c64ea2e4908"), "Macao", "MAC" },
                    { new Guid("92b59f12-67bf-4af8-9e36-7c85c4157f34"), "Madagascar", "MDG" },
                    { new Guid("2c7e8888-9290-469b-838e-b00eb5dec82c"), "Malawi", "MWI" },
                    { new Guid("1c3a7637-71c0-4fbf-8961-544bc244a026"), "Malaysia", "MYS" },
                    { new Guid("fbd22e13-4904-40a2-9226-891c9e37f545"), "Maldives", "MDV" },
                    { new Guid("1e1a95b3-9b08-4a75-acce-8df68ba91961"), "Mali", "MLI" },
                    { new Guid("3784dc7c-ac72-4740-bb27-180d1b7b2bf9"), "Malta", "MLT" },
                    { new Guid("f404b953-fee8-4fd1-8fc3-b98376854611"), "Marshall Islands", "MHL" },
                    { new Guid("855d8836-1170-493a-b6ca-ce78004c3dc6"), "Martinique", "MTQ" },
                    { new Guid("2934d47e-295f-4dd2-b01e-a3705143b92d"), "Mauritania", "MRT" },
                    { new Guid("2713665f-68d3-46bc-836e-458cae90822b"), "Mauritius", "MUS" },
                    { new Guid("3c236c8d-c8a2-4419-849c-f7782ee46088"), "Mayotte", "MYT" },
                    { new Guid("090c428f-fd76-464d-aefc-a72e98272075"), "Mexico", "MEX" },
                    { new Guid("db494eac-17f3-4199-bb7b-c85315de067e"), "Micronesia (Federated States of)", "FSM" },
                    { new Guid("a78c31ca-d55d-439e-b035-2faa7611820e"), "Moldova, Republic of", "MDA" },
                    { new Guid("6e3a6afc-dc11-4efc-9ee5-d45a886543cd"), "Monaco", "MCO" },
                    { new Guid("483bcaf9-0883-483a-9a6b-ad4fd35ff342"), "Mongolia", "MNG" },
                    { new Guid("f39ce47d-20eb-4c02-a90c-acfd2d801200"), "Montenegro", "MNE" },
                    { new Guid("0e584561-4e3e-4fac-91c2-dcc304a188f6"), "Montserrat", "MSR" },
                    { new Guid("352c0ed1-5175-4526-a6b4-5fb86334bb2d"), "Morocco", "MAR" },
                    { new Guid("0367a937-51a8-4b3a-b227-f2c714d4735e"), "Mozambique", "MOZ" },
                    { new Guid("03444756-c9e2-485e-8458-5960956a0d16"), "Myanmar", "MMR" },
                    { new Guid("7fcf8d00-64b9-4019-a726-32aac7e25393"), "Nauru", "NRU" },
                    { new Guid("8dbef785-3def-4933-829d-e64b564fa749"), "Saint Barthélemy", "BLM" },
                    { new Guid("cddef1f1-e474-44a3-a11d-83deb1aedd69"), "Saint Helena, Ascension and Tristan da Cunha", "SHN" },
                    { new Guid("a304c9e0-8b99-420b-99a9-55f982085e60"), "Saint Kitts and Nevis", "KNA" },
                    { new Guid("35d3fd7b-eedb-418d-b6e9-90f7785b573a"), "Thailand", "THA" },
                    { new Guid("6e1f14db-b837-4726-9b96-ac697f4996de"), "Timor-Leste", "TLS" },
                    { new Guid("2b06a269-1d04-4bf2-af36-c9f361ad788c"), "Togo", "TGO" },
                    { new Guid("3c8105e2-891d-438a-88a6-5f2a4d18e633"), "Tokelau", "TKL" },
                    { new Guid("06d38b68-8685-4e95-860f-6d87e1975bae"), "Tonga", "TON" },
                    { new Guid("fbca0aa4-423f-4249-8b70-72d505a606ca"), "Trinidad and Tobago", "TTO" },
                    { new Guid("baee5c83-2005-4778-acec-92443bbbd12a"), "Tunisia", "TUN" },
                    { new Guid("940f282e-6437-420b-8350-13130cddec05"), "Turkey", "TUR" },
                    { new Guid("de7f691f-124e-4b5f-8274-42c90c9d1ba3"), "Turkmenistan", "TKM" },
                    { new Guid("a60120ba-f2cf-48e9-a0a0-63afa9408622"), "Turks and Caicos Islands", "TCA" },
                    { new Guid("d3b79d2c-82ae-4696-9f4c-12cd764c3a71"), "Tuvalu", "TUV" },
                    { new Guid("103333bc-e1e2-4417-b9ba-8901934d3290"), "Uganda", "UGA" },
                    { new Guid("bd339386-c85e-4e65-91a7-9796cd13bf4f"), "Ukraine", "UKR" },
                    { new Guid("de7cee70-f6fe-4848-92a6-1f6a0c641bd5"), "United Arab Emirates", "ARE" },
                    { new Guid("53a6908b-261b-40af-96e9-d038e6f8ea67"), "United Kingdom of Great Britain and Northern Ireland", "GBR" },
                    { new Guid("32ca3434-2aab-4da9-84b8-51f5a02f4fb0"), "United States of America", "USA" },
                    { new Guid("c455b9c4-3fbc-40ee-84bb-07b5dceaca45"), "United States Minor Outlying Islands", "UMI" },
                    { new Guid("6e621a84-082b-401a-a7c7-798c89996b89"), "Uruguay", "URY" },
                    { new Guid("f0edfc8d-2aae-4e12-a0dd-222009cd043d"), "Uzbekistan", "UZB" },
                    { new Guid("2c67bf06-a319-4fad-8e05-51015038c7e0"), "Vanuatu", "VUT" },
                    { new Guid("febaeda1-1a1e-441a-a56a-ea6d413981b8"), "Venezuela (Bolivarian Republic of)", "VEN" },
                    { new Guid("140e9df2-1bd3-4570-837b-b4dc1f6f595f"), "Viet Nam", "VNM" },
                    { new Guid("4a37fcdb-4e03-4ca4-870c-7d7bfd2ecf70"), "Virgin Islands (British)", "VGB" },
                    { new Guid("e72810f4-49be-4a59-a637-3bf9876fdb68"), "Virgin Islands (U.S.)", "VIR" },
                    { new Guid("8a37fef9-32e9-4b44-af93-8d06fbc6bb64"), "Wallis and Futuna", "WLF" },
                    { new Guid("ad4e18a2-5674-4626-b6f6-6a63f4e86898"), "Western Sahara", "ESH" },
                    { new Guid("bacdd7af-593c-4a76-aeaf-a7589fdc6699"), "Yemen", "YEM" },
                    { new Guid("de0fe66d-c987-45d9-b980-b1ec6ac0e1bd"), "Tanzania, United Republic of", "TZA" },
                    { new Guid("c8880fa8-24d5-4020-b7d0-3113b2e72495"), "Tajikistan", "TJK" },
                    { new Guid("ce6f9d26-155a-494c-a4e3-35f27cf288b9"), "Taiwan, Province of China", "TWN" },
                    { new Guid("f6dd679e-7db0-4da5-9a3c-a93cfad7d664"), "Syrian Arab Republic", "SYR" },
                    { new Guid("d22c6d83-539e-4b9e-a7da-588ba42c1b13"), "Saint Lucia", "LCA" },
                    { new Guid("8e6681d9-1a4a-42d1-9b15-9124ca0e731b"), "Saint Martin (French part)", "MAF" },
                    { new Guid("72bd85fb-d407-454c-b56d-2545bb9a3163"), "Saint Pierre and Miquelon", "SPM" },
                    { new Guid("26869242-ed06-4ecd-af8d-c6f5cf2dbde1"), "Saint Vincent and the Grenadines", "VCT" },
                    { new Guid("8d729739-8078-4f61-bbe5-4dc5c3b3f0f5"), "Samoa", "WSM" },
                    { new Guid("95ac011a-d215-45a1-ae69-2b0fef7484c8"), "San Marino", "SMR" },
                    { new Guid("d74ce2da-f161-439d-9d28-7a2f978c1e32"), "Sao Tome and Principe", "STP" },
                    { new Guid("aefde2cd-8432-40f9-8412-4dbfdc37a44c"), "Saudi Arabia", "SAU" },
                    { new Guid("1b9ab440-e873-4cfa-a240-712ab853c74b"), "Senegal", "SEN" },
                    { new Guid("476696b8-6b65-4037-a13f-fc016039c38e"), "Serbia", "SRB" },
                    { new Guid("bd0e60cd-0ae5-4bae-87c9-1281c332ef2e"), "Seychelles", "SYC" },
                    { new Guid("f22cff9a-e540-4553-9ad0-7853803a776d"), "Sierra Leone", "SLE" },
                    { new Guid("3e3ec23e-1289-4777-a60a-fe2ba3b5462b"), "Singapore", "SGP" },
                    { new Guid("70557e42-0145-405a-b517-5c5d0aff46c1"), "Lesotho", "LSO" },
                    { new Guid("7637fafb-b984-462a-ab61-c66a9d38ab63"), "Sint Maarten (Dutch part)", "SXM" },
                    { new Guid("ab0bc840-59d3-42ba-9133-1359fcea1a98"), "Slovenia", "SVN" },
                    { new Guid("e8491314-2068-4e37-a5a2-45ad470ecd60"), "Solomon Islands", "SLB" },
                    { new Guid("9302db2f-f71a-4ca0-8558-9c6ada76456a"), "Somalia", "SOM" },
                    { new Guid("0b6c7c28-bf8b-4fd1-9756-fcacae1ed891"), "South Africa", "ZAF" },
                    { new Guid("049091b8-c64a-4030-963e-5bc11a77c3ea"), "South Georgia and the South Sandwich Islands", "SGS" },
                    { new Guid("3c0328ef-87e9-412e-9eb1-3ca1d6f16ab3"), "South Sudan", "SSD" },
                    { new Guid("c7e2bddc-9717-42d1-a2af-e0258ccda160"), "Spain", "ESP" },
                    { new Guid("a866e93e-35fd-44a1-81ea-0e8811a9ece5"), "Sri Lanka", "LKA" },
                    { new Guid("678f3bca-888e-4db5-90a1-c31dc3230e7f"), "Sudan", "SDN" },
                    { new Guid("5a027f90-b79c-44bf-9f1d-661c85911d65"), "Suriname", "SUR" },
                    { new Guid("8c52ef52-4380-48c7-8a46-046983e33cb8"), "Svalbard and Jan Mayen", "SJM" },
                    { new Guid("5770a7b9-2c21-4d37-909b-d2a17c0c7a2f"), "Sweden", "SWE" },
                    { new Guid("eb18d5e8-6489-4c75-8934-6b3e7c441b11"), "Switzerland", "CHE" },
                    { new Guid("7318e8dc-4fc1-49df-bb58-816fda9a0337"), "Slovakia", "SVK" },
                    { new Guid("39227311-c6c7-4d02-b7b4-c5a4332b91b1"), "Zambia", "ZMB" },
                    { new Guid("b41d287a-20f7-4c31-8f84-e9aaa24139f5"), "Lebanon", "LBN" },
                    { new Guid("d4b39e27-94a9-470b-840f-cb5c3dd21533"), "Lao People's Democratic Republic", "LAO" },
                    { new Guid("2689acd3-3894-4cb4-ba72-b7c7d505f955"), "British Indian Ocean Territory", "IOT" },
                    { new Guid("0ee077fe-41de-460e-bf23-807a0d8168ae"), "Brunei Darussalam", "BRN" },
                    { new Guid("6fd47f87-2550-4f34-a265-e93cf791485e"), "Bulgaria", "BGR" },
                    { new Guid("e19c097b-d7a4-4201-b239-767264c75104"), "Burkina Faso", "BFA" },
                    { new Guid("a42f3752-d76a-41ea-a6e9-cdf41dc3343b"), "Burundi", "BDI" },
                    { new Guid("6ac45f00-68ae-4c32-82b0-b21a0c173abf"), "Cabo Verde", "CPV" },
                    { new Guid("b60bc2be-5dae-4284-a300-f5026e83616a"), "Cambodia", "KHM" },
                    { new Guid("69c588f5-aa7c-4926-96d8-22da7f5767ad"), "Cameroon", "CMR" },
                    { new Guid("a97fa95d-7cb6-4f49-bf15-de959b807978"), "Canada", "CAN" },
                    { new Guid("6c85b1ab-fb12-4441-b9d6-7d5a3574d4ad"), "Cayman Islands", "CYM" },
                    { new Guid("87204e73-b151-42f2-b860-74de3a3dce24"), "Central African Republic", "CAF" },
                    { new Guid("87399cf5-6683-46d9-908f-1e85293beb15"), "Chad", "TCD" },
                    { new Guid("7be61c14-2f77-4d99-9035-f87933c6269b"), "Chile", "CHL" },
                    { new Guid("2cd1226c-3af5-4ab8-a1d1-69eb9cce77d2"), "China", "CHN" },
                    { new Guid("52738049-028c-4059-aa1f-910d405d0891"), "Christmas Island", "CXR" },
                    { new Guid("4d8f296a-9c4b-4344-8bf9-dcde821988ea"), "Cocos (Keeling) Islands", "CCK" },
                    { new Guid("43a15750-ca95-4f6e-861f-bf1bf42649f6"), "Colombia", "COL" },
                    { new Guid("0ac03e09-8332-47a2-b3e9-1960c830e0d4"), "Comoros", "COM" },
                    { new Guid("a0bb5f6e-ce20-44dc-a5a4-e8ac6abc6600"), "Congo", "COG" },
                    { new Guid("bb8c173c-2a90-41d1-8434-120319577e84"), "Congo, Democratic Republic of the", "COD" },
                    { new Guid("e954cfdb-cc6b-4cb0-8c15-7d601ae16f76"), "Cook Islands", "COK" },
                    { new Guid("78245d1e-4afa-456c-a04d-d08933237823"), "Costa Rica", "CRI" },
                    { new Guid("12d3223f-7543-4932-96a2-808dddd1acf0"), "Côte d'Ivoire", "CIV" },
                    { new Guid("7ec787ba-ab76-44f0-8f9f-a12f67cc81d0"), "Croatia", "HRV" },
                    { new Guid("0fb25f41-e9f6-4b86-8f8f-4d54af348ead"), "Cuba", "CUB" },
                    { new Guid("ed304576-0848-42dc-861b-f48a3614bb73"), "Curaçao", "CUW" },
                    { new Guid("2146c53f-c8b4-46d6-bc34-f92b9cbd99f9"), "Cyprus", "CYP" },
                    { new Guid("6d73d59d-f354-4e54-810c-5d1a0dda961b"), "Brazil", "BRA" },
                    { new Guid("409a2699-165f-4a72-adc4-de26edfeee89"), "Czechia", "CZE" },
                    { new Guid("28b1aa8e-e337-45b0-a18d-e3edbf2ab3c4"), "Bouvet Island", "BVT" },
                    { new Guid("7543fa8e-b16b-4476-bc8f-7becb815cf17"), "Bosnia and Herzegovina", "BIH" },
                    { new Guid("80338b82-972c-4ea2-bae9-6656107a1202"), "Åland Islands", "ALA" },
                    { new Guid("4a556545-16a4-4414-90e1-5a2ee2847d77"), "Albania", "ALB" },
                    { new Guid("f39873ac-b41d-466a-a6c5-b1bf03910f17"), "Algeria", "DZA" },
                    { new Guid("0e89af10-978e-443e-9de0-f498543e533e"), "American Samoa", "ASM" },
                    { new Guid("06df6c08-cea7-441c-91b4-6cd55d81f4cd"), "Andorra", "AND" },
                    { new Guid("24bbf0bf-f5e1-4944-90fb-1f17f0aa5ba9"), "Angola", "AGO" },
                    { new Guid("ac6b2eb9-8061-45da-a938-3809cf81918e"), "Anguilla", "AIA" },
                    { new Guid("2e0eef48-9c21-431b-a387-e5b18ff1458f"), "Antarctica", "ATA" },
                    { new Guid("683b32c5-b003-4ad4-9115-8b0e11d8eebe"), "Antigua and Barbuda", "ATG" },
                    { new Guid("58ed9a0d-0648-4138-a64a-f54b4091720c"), "Argentina", "ARG" },
                    { new Guid("d531bc17-0c16-4233-9eac-5fd7984448d8"), "Armenia", "ARM" },
                    { new Guid("688ddb6a-c8e9-4902-8573-a4b91bbe7741"), "Aruba", "ABW" },
                    { new Guid("bbbbe4c1-3a70-44ee-9669-a68b811f8418"), "Australia", "AUS" },
                    { new Guid("9e2f96d7-e472-4ed9-961f-14013bffed55"), "Austria", "AUT" },
                    { new Guid("1cbb91a4-a0f5-4cdb-be86-9bfd1fadadc3"), "Azerbaijan", "AZE" },
                    { new Guid("00867684-e79d-44b6-990f-f70e6c53baf5"), "Bahamas", "BHS" },
                    { new Guid("5637d6bc-0f9e-44fa-9208-8263354943f2"), "Bahrain", "BHR" },
                    { new Guid("bb59f368-8a5e-41ff-812a-d2f316c17b58"), "Bangladesh", "BGD" },
                    { new Guid("a5f2dd71-a903-4110-a6b6-2df6d16d50cd"), "Barbados", "BRB" },
                    { new Guid("c0711155-b598-407a-91c4-86310bc239d7"), "Belarus", "BLR" },
                    { new Guid("50555b0f-d488-499f-b8b2-7cde84e57fc7"), "Belgium", "BEL" },
                    { new Guid("ebe36781-d6e2-42b7-be85-4e9560d86326"), "Belize", "BLZ" },
                    { new Guid("219018b7-0710-4d3c-a7b4-ccf7f82e4e42"), "Benin", "BEN" },
                    { new Guid("13071079-48b5-40a9-9fa4-5dfac572dca4"), "Bermuda", "BMU" },
                    { new Guid("e051e72f-7539-4e60-bfe8-f7409b8fe158"), "Bhutan", "BTN" },
                    { new Guid("3084983e-ce03-4255-a715-6e6998519ebc"), "Bolivia (Plurinational State of)", "BOL" },
                    { new Guid("7f33ff02-3975-4b9b-a899-9503e815d581"), "Bonaire, Sint Eustatius and Saba", "BES" },
                    { new Guid("597c64ff-7d44-44b8-95ce-2afc6ce4acc8"), "Botswana", "BWA" },
                    { new Guid("6704cf6d-49a4-4dd8-9e14-c5fe97d32120"), "Denmark", "DNK" },
                    { new Guid("871b69e3-0d94-4e3e-a486-928c73f36972"), "Djibouti", "DJI" },
                    { new Guid("b15ceebe-81b3-4657-9150-62551829949f"), "Dominica", "DMA" },
                    { new Guid("0e52dc84-af44-46f7-aea0-9e0b597a2cd3"), "Guyana", "GUY" },
                    { new Guid("c0a2ef8a-c1a8-4c34-aa16-7744df5ca399"), "Haiti", "HTI" },
                    { new Guid("485d8a42-a7eb-4ad8-a1d4-c7196d265d38"), "Heard Island and McDonald Islands", "HMD" },
                    { new Guid("276c19f3-230f-4c19-b817-0db872e9af2a"), "Holy See", "VAT" },
                    { new Guid("81f619fa-72b0-436f-b62b-569ead37acbc"), "Honduras", "HND" },
                    { new Guid("5bd51888-9274-4e5b-a12b-9effaf0b19a0"), "Hong Kong", "HKG" },
                    { new Guid("ac479611-5f2c-4a1c-ac86-103027585d22"), "Hungary", "HUN" },
                    { new Guid("fba4a763-335b-4565-aa83-f40e769fa037"), "Iceland", "ISL" },
                    { new Guid("d2af06aa-f830-4eff-b74a-5d43201c2fc3"), "India", "IND" },
                    { new Guid("904c67ee-8938-43d3-9cf1-a08fe66558ad"), "Indonesia", "IDN" },
                    { new Guid("af93b424-922b-4c9e-beeb-18a2566ca5b7"), "Iran (Islamic Republic of)", "IRN" },
                    { new Guid("b6cdfc5f-6618-4bab-954c-fbd11879ff03"), "Iraq", "IRQ" },
                    { new Guid("32bf1e47-7690-4c30-a9b3-4bdb11a55513"), "Ireland", "IRL" },
                    { new Guid("4973db54-5e64-4a13-8d15-cd6f23a848ba"), "Isle of Man", "IMN" },
                    { new Guid("b8662c14-c6ec-4cc8-9635-e9a907e9d2dc"), "Israel", "ISR" },
                    { new Guid("18beeda3-36ff-437f-ab66-04199c324a63"), "Italy", "ITA" },
                    { new Guid("b787c80f-b034-40af-ae6a-8981557293cc"), "Jamaica", "JAM" },
                    { new Guid("eed6efdf-fedd-460a-bb46-d23c1b23e9fc"), "Japan", "JPN" },
                    { new Guid("ed29c6ab-a272-43eb-aa91-f256f6765287"), "Jersey", "JEY" },
                    { new Guid("8c8658e0-f841-47cd-9672-6481854b959b"), "Jordan", "JOR" },
                    { new Guid("435aef1a-075c-4105-acd0-7e6b0ff0d824"), "Kazakhstan", "KAZ" },
                    { new Guid("4a5d51dd-5f1b-448c-a84d-b0ae8208c6ae"), "Kenya", "KEN" },
                    { new Guid("330c51e7-8463-4493-a33d-96db7916f72f"), "Kiribati", "KIR" },
                    { new Guid("0dc20b4f-fe29-4ccd-893d-0a02f7c4b275"), "Korea (Democratic People's Republic of)", "PRK" },
                    { new Guid("5652e664-3cf2-4149-b1fd-b65e21f6b703"), "Korea, Republic of", "KOR" },
                    { new Guid("b833970a-f3fc-479f-847f-c22bd126865c"), "Kuwait", "KWT" },
                    { new Guid("d42facde-95ae-4e2d-84e7-23b60aafe2b3"), "Kyrgyzstan", "KGZ" },
                    { new Guid("b384155f-7d7e-430b-b367-76c4126d7186"), "Guinea-Bissau", "GNB" },
                    { new Guid("ab6280e7-229e-4191-aded-e829e96d2602"), "Guinea", "GIN" },
                    { new Guid("fa260694-c3ab-4bb2-9033-5104b196ac9d"), "Guernsey", "GGY" },
                    { new Guid("edcbbafd-8a87-4c77-8fbd-2e952a2da7ac"), "Guatemala", "GTM" },
                    { new Guid("35ae1ae8-f07f-4ca0-aeff-157252f4d4fe"), "Dominican Republic", "DOM" },
                    { new Guid("15f9ccf7-dbda-47cb-95aa-55135a888c36"), "Ecuador", "ECU" },
                    { new Guid("52f61d46-bf77-494c-a05d-33e0abf29a0f"), "Egypt", "EGY" },
                    { new Guid("bf896bc0-305a-402c-a940-67e430834fa0"), "El Salvador", "SLV" },
                    { new Guid("4b641190-3d6a-4eee-9f06-d5ce825a6d36"), "Equatorial Guinea", "GNQ" },
                    { new Guid("68432341-8ec9-4b2e-84b0-34725f5cbe28"), "Eritrea", "ERI" },
                    { new Guid("159a79fc-f215-4181-b25e-3bf8133b11a0"), "Estonia", "EST" },
                    { new Guid("ca877833-6b7a-400c-b975-5b451e3b7acb"), "Eswatini", "SWZ" },
                    { new Guid("9ff8ede6-6161-4923-85ae-a4cc71cf6772"), "Ethiopia", "ETH" },
                    { new Guid("fea72906-c869-45fa-9126-b87d8873614d"), "Falkland Islands (Malvinas)", "FLK" },
                    { new Guid("56ffbb40-1097-421c-bd84-3f1ce141ec4b"), "Faroe Islands", "FRO" },
                    { new Guid("b6c00c67-6a10-471d-aaa5-7e4badf2568e"), "Fiji", "FJI" },
                    { new Guid("7cbc558b-ead5-41da-9a95-180b2ecd3379"), "Finland", "FIN" },
                    { new Guid("209db596-175f-461f-930d-d68b662fcd7b"), "Latvia", "LVA" },
                    { new Guid("c556a75f-7186-4a4c-a21b-c5a264633df3"), "France", "FRA" },
                    { new Guid("cd48f169-746a-47e4-ab99-901a5f1397f4"), "French Polynesia", "PYF" },
                    { new Guid("bf29d02c-2eb7-4af8-b5ae-6621e55bbba2"), "French Southern Territories", "ATF" },
                    { new Guid("10cf0be8-bca8-4430-80d7-ec3851b2ad19"), "Gabon", "GAB" },
                    { new Guid("438ee27e-f6b6-4d57-8e9f-72ec4b5d52c0"), "Gambia", "GMB" },
                    { new Guid("4d715b5a-a39a-45cb-a2aa-babe741a7158"), "Georgia", "GEO" },
                    { new Guid("d74bace3-2dfa-4ba1-8d22-4956939c442b"), "Germany", "DEU" },
                    { new Guid("c0030b32-cbfc-4d8f-bde1-00ebc6fdcac6"), "Ghana", "GHA" },
                    { new Guid("ba209907-281e-446a-a97a-9303e0e4030b"), "Gibraltar", "GIB" },
                    { new Guid("5cbdf134-408e-4c0e-bc4b-5698f58a0be0"), "Greece", "GRC" },
                    { new Guid("2f95f5ff-3d15-45a3-8a87-91ff768d9ecb"), "Greenland", "GRL" },
                    { new Guid("3eb44ca7-f491-4e23-b8e9-0225b492cfde"), "Grenada", "GRD" },
                    { new Guid("68235833-d0c2-42e1-bc52-544c75ff25ab"), "Guadeloupe", "GLP" },
                    { new Guid("0bac8afd-e9d4-498f-be13-42f623290cfb"), "Guam", "GUM" },
                    { new Guid("49dc8a79-12bc-4efe-ac71-9186e711afd5"), "French Guiana", "GUF" },
                    { new Guid("28bfaac8-294d-48d1-8ae5-ce0e703041af"), "Zimbabwe", "ZWE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00867684-e79d-44b6-990f-f70e6c53baf5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0101ff6d-07ea-41bc-a333-135364750871"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("03444756-c9e2-485e-8458-5960956a0d16"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0367a937-51a8-4b3a-b227-f2c714d4735e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("049091b8-c64a-4030-963e-5bc11a77c3ea"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("06d38b68-8685-4e95-860f-6d87e1975bae"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("06df6c08-cea7-441c-91b4-6cd55d81f4cd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("090c428f-fd76-464d-aefc-a72e98272075"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0ac03e09-8332-47a2-b3e9-1960c830e0d4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0b415a8d-952e-4a63-8089-64cdf7505ae5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0b6c7c28-bf8b-4fd1-9756-fcacae1ed891"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0bac8afd-e9d4-498f-be13-42f623290cfb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0d8ab0e0-41ff-4561-b52d-e1b79ff825aa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0dc20b4f-fe29-4ccd-893d-0a02f7c4b275"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0e52dc84-af44-46f7-aea0-9e0b597a2cd3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0e584561-4e3e-4fac-91c2-dcc304a188f6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0e89af10-978e-443e-9de0-f498543e533e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0ee077fe-41de-460e-bf23-807a0d8168ae"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0fb25f41-e9f6-4b86-8f8f-4d54af348ead"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("103333bc-e1e2-4417-b9ba-8901934d3290"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("10cf0be8-bca8-4430-80d7-ec3851b2ad19"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("12d3223f-7543-4932-96a2-808dddd1acf0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("13071079-48b5-40a9-9fa4-5dfac572dca4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("140e9df2-1bd3-4570-837b-b4dc1f6f595f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("159a79fc-f215-4181-b25e-3bf8133b11a0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("15f9ccf7-dbda-47cb-95aa-55135a888c36"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("18beeda3-36ff-437f-ab66-04199c324a63"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1b9ab440-e873-4cfa-a240-712ab853c74b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1c3a7637-71c0-4fbf-8961-544bc244a026"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1cbb91a4-a0f5-4cdb-be86-9bfd1fadadc3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1e1a95b3-9b08-4a75-acce-8df68ba91961"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("209db596-175f-461f-930d-d68b662fcd7b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2146c53f-c8b4-46d6-bc34-f92b9cbd99f9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("219018b7-0710-4d3c-a7b4-ccf7f82e4e42"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("24bbf0bf-f5e1-4944-90fb-1f17f0aa5ba9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("26869242-ed06-4ecd-af8d-c6f5cf2dbde1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2689acd3-3894-4cb4-ba72-b7c7d505f955"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2713665f-68d3-46bc-836e-458cae90822b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("276c19f3-230f-4c19-b817-0db872e9af2a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("28b1aa8e-e337-45b0-a18d-e3edbf2ab3c4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("28bfaac8-294d-48d1-8ae5-ce0e703041af"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2934d47e-295f-4dd2-b01e-a3705143b92d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2b06a269-1d04-4bf2-af36-c9f361ad788c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2c67bf06-a319-4fad-8e05-51015038c7e0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2c7e8888-9290-469b-838e-b00eb5dec82c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2cb6716d-44fd-48f2-a123-f298909e682b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2cd1226c-3af5-4ab8-a1d1-69eb9cce77d2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2def92d2-fff9-419c-ab65-d6aae8a04c26"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2e0eef48-9c21-431b-a387-e5b18ff1458f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2f95f5ff-3d15-45a3-8a87-91ff768d9ecb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3084983e-ce03-4255-a715-6e6998519ebc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("32bf1e47-7690-4c30-a9b3-4bdb11a55513"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("32ca3434-2aab-4da9-84b8-51f5a02f4fb0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("330c51e7-8463-4493-a33d-96db7916f72f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("352c0ed1-5175-4526-a6b4-5fb86334bb2d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("35ae1ae8-f07f-4ca0-aeff-157252f4d4fe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("35d3fd7b-eedb-418d-b6e9-90f7785b573a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3784dc7c-ac72-4740-bb27-180d1b7b2bf9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("39227311-c6c7-4d02-b7b4-c5a4332b91b1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3c0328ef-87e9-412e-9eb1-3ca1d6f16ab3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3c236c8d-c8a2-4419-849c-f7782ee46088"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3c52c724-ad05-4fae-8390-542c201c81b8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3c8105e2-891d-438a-88a6-5f2a4d18e633"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3e3ec23e-1289-4777-a60a-fe2ba3b5462b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3eb44ca7-f491-4e23-b8e9-0225b492cfde"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3ff5dac9-dc46-488c-b9e9-13ee966a9a89"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("409a2699-165f-4a72-adc4-de26edfeee89"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("435aef1a-075c-4105-acd0-7e6b0ff0d824"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("438ee27e-f6b6-4d57-8e9f-72ec4b5d52c0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("43a15750-ca95-4f6e-861f-bf1bf42649f6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("476696b8-6b65-4037-a13f-fc016039c38e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("483bcaf9-0883-483a-9a6b-ad4fd35ff342"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("485d8a42-a7eb-4ad8-a1d4-c7196d265d38"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4957da7a-e5e7-4a4d-982b-09d88d4a58b4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4973db54-5e64-4a13-8d15-cd6f23a848ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("49dc8a79-12bc-4efe-ac71-9186e711afd5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4a37fcdb-4e03-4ca4-870c-7d7bfd2ecf70"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4a556545-16a4-4414-90e1-5a2ee2847d77"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4a5d51dd-5f1b-448c-a84d-b0ae8208c6ae"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4b641190-3d6a-4eee-9f06-d5ce825a6d36"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4b7aa8b0-7713-407b-b06c-f467a522ce08"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4d715b5a-a39a-45cb-a2aa-babe741a7158"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4d8f296a-9c4b-4344-8bf9-dcde821988ea"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("50555b0f-d488-499f-b8b2-7cde84e57fc7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("51bb855c-1e3c-431a-bcd0-a17e54a303ea"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("52738049-028c-4059-aa1f-910d405d0891"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("52f61d46-bf77-494c-a05d-33e0abf29a0f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("53a6908b-261b-40af-96e9-d038e6f8ea67"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5637d6bc-0f9e-44fa-9208-8263354943f2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5652e664-3cf2-4149-b1fd-b65e21f6b703"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("567c7931-64f7-4550-9104-993c65763c31"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("56ffbb40-1097-421c-bd84-3f1ce141ec4b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5770a7b9-2c21-4d37-909b-d2a17c0c7a2f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("58ed9a0d-0648-4138-a64a-f54b4091720c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("597c64ff-7d44-44b8-95ce-2afc6ce4acc8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("59a4d65c-6417-4b80-96b2-f076a924f6ce"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5a027f90-b79c-44bf-9f1d-661c85911d65"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5bd51888-9274-4e5b-a12b-9effaf0b19a0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5cbdf134-408e-4c0e-bc4b-5698f58a0be0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("63efded4-bc57-445f-b703-981e7eca8907"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6704cf6d-49a4-4dd8-9e14-c5fe97d32120"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("678f3bca-888e-4db5-90a1-c31dc3230e7f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("68235833-d0c2-42e1-bc52-544c75ff25ab"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("683b32c5-b003-4ad4-9115-8b0e11d8eebe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("68432341-8ec9-4b2e-84b0-34725f5cbe28"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("688ddb6a-c8e9-4902-8573-a4b91bbe7741"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("69c588f5-aa7c-4926-96d8-22da7f5767ad"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6ac45f00-68ae-4c32-82b0-b21a0c173abf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6c85b1ab-fb12-4441-b9d6-7d5a3574d4ad"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6d73d59d-f354-4e54-810c-5d1a0dda961b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6e1f14db-b837-4726-9b96-ac697f4996de"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6e3a6afc-dc11-4efc-9ee5-d45a886543cd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6e621a84-082b-401a-a7c7-798c89996b89"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6fd47f87-2550-4f34-a265-e93cf791485e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("70557e42-0145-405a-b517-5c5d0aff46c1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("70824528-59a8-4437-a802-47e70b6017ee"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("72bd85fb-d407-454c-b56d-2545bb9a3163"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7318e8dc-4fc1-49df-bb58-816fda9a0337"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7543fa8e-b16b-4476-bc8f-7becb815cf17"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7637fafb-b984-462a-ab61-c66a9d38ab63"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("78245d1e-4afa-456c-a04d-d08933237823"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7be61c14-2f77-4d99-9035-f87933c6269b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7cbc558b-ead5-41da-9a95-180b2ecd3379"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7ec787ba-ab76-44f0-8f9f-a12f67cc81d0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7f33ff02-3975-4b9b-a899-9503e815d581"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7f596dac-f3dc-423a-8368-a0f31a0abed3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7fcf8d00-64b9-4019-a726-32aac7e25393"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("80338b82-972c-4ea2-bae9-6656107a1202"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("81f619fa-72b0-436f-b62b-569ead37acbc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("855d8836-1170-493a-b6ca-ce78004c3dc6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("871b69e3-0d94-4e3e-a486-928c73f36972"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("87204e73-b151-42f2-b860-74de3a3dce24"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("87399cf5-6683-46d9-908f-1e85293beb15"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8a37fef9-32e9-4b44-af93-8d06fbc6bb64"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c52ef52-4380-48c7-8a46-046983e33cb8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c8658e0-f841-47cd-9672-6481854b959b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8d729739-8078-4f61-bbe5-4dc5c3b3f0f5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8dbef785-3def-4933-829d-e64b564fa749"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8e6681d9-1a4a-42d1-9b15-9124ca0e731b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8ed54c9f-ec6f-4515-ada3-569dc855944c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("904c67ee-8938-43d3-9cf1-a08fe66558ad"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("92b59f12-67bf-4af8-9e36-7c85c4157f34"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9302db2f-f71a-4ca0-8558-9c6ada76456a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("940f282e-6437-420b-8350-13130cddec05"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("950959ff-35cb-46da-a435-3ff01d0c88e2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("95ac011a-d215-45a1-ae69-2b0fef7484c8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("98478c9e-4483-43af-ab88-2c8a388cd2a1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9e2f96d7-e472-4ed9-961f-14013bffed55"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9ff8ede6-6161-4923-85ae-a4cc71cf6772"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a0bb5f6e-ce20-44dc-a5a4-e8ac6abc6600"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a304c9e0-8b99-420b-99a9-55f982085e60"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a42f3752-d76a-41ea-a6e9-cdf41dc3343b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a5abcc74-893d-4ff4-a207-7ef89d9005c9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a5f2dd71-a903-4110-a6b6-2df6d16d50cd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a60120ba-f2cf-48e9-a0a0-63afa9408622"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a78c31ca-d55d-439e-b035-2faa7611820e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a866e93e-35fd-44a1-81ea-0e8811a9ece5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a97fa95d-7cb6-4f49-bf15-de959b807978"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ab0bc840-59d3-42ba-9133-1359fcea1a98"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ab6280e7-229e-4191-aded-e829e96d2602"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ac479611-5f2c-4a1c-ac86-103027585d22"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ac6b2eb9-8061-45da-a938-3809cf81918e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ad4e18a2-5674-4626-b6f6-6a63f4e86898"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aefde2cd-8432-40f9-8412-4dbfdc37a44c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("af93b424-922b-4c9e-beeb-18a2566ca5b7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b15ceebe-81b3-4657-9150-62551829949f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b384155f-7d7e-430b-b367-76c4126d7186"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b41d287a-20f7-4c31-8f84-e9aaa24139f5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b60bc2be-5dae-4284-a300-f5026e83616a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b6c00c67-6a10-471d-aaa5-7e4badf2568e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b6cdfc5f-6618-4bab-954c-fbd11879ff03"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b787c80f-b034-40af-ae6a-8981557293cc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b833970a-f3fc-479f-847f-c22bd126865c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b8662c14-c6ec-4cc8-9635-e9a907e9d2dc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ba209907-281e-446a-a97a-9303e0e4030b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("baa3e035-0181-404a-a5f8-c3980c1ce675"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bacdd7af-593c-4a76-aeaf-a7589fdc6699"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("baee5c83-2005-4778-acec-92443bbbd12a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bb59f368-8a5e-41ff-812a-d2f316c17b58"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bb8c173c-2a90-41d1-8434-120319577e84"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bbbbe4c1-3a70-44ee-9669-a68b811f8418"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bbf1c954-5390-4488-b309-d3ec6d027dd2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bd0e60cd-0ae5-4bae-87c9-1281c332ef2e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bd339386-c85e-4e65-91a7-9796cd13bf4f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("be9f403e-d045-4188-867b-0a36deb99f77"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bf0e880e-b1cd-4db1-9050-ef04ca780d57"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bf29d02c-2eb7-4af8-b5ae-6621e55bbba2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bf896bc0-305a-402c-a940-67e430834fa0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bf9d86f4-0259-437e-9158-0c64ea2e4908"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c0030b32-cbfc-4d8f-bde1-00ebc6fdcac6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c0711155-b598-407a-91c4-86310bc239d7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c0a2ef8a-c1a8-4c34-aa16-7744df5ca399"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c3ba17e9-c383-456a-af5b-c668d9bffa5e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c455b9c4-3fbc-40ee-84bb-07b5dceaca45"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c556a75f-7186-4a4c-a21b-c5a264633df3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c7e2bddc-9717-42d1-a2af-e0258ccda160"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c8880fa8-24d5-4020-b7d0-3113b2e72495"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c89fc0d5-2564-48cf-8003-c048dd294010"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c8f30883-962a-4462-9357-0747da55151e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c992f142-73ff-4d79-b1b4-353c50ee911f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ca877833-6b7a-400c-b975-5b451e3b7acb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cd48f169-746a-47e4-ab99-901a5f1397f4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cddef1f1-e474-44a3-a11d-83deb1aedd69"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ce6f9d26-155a-494c-a4e3-35f27cf288b9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ce700e52-a116-4bf0-85ed-a8db59caab46"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cecc5511-a2ea-4a8e-8311-c43175b09397"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d22c6d83-539e-4b9e-a7da-588ba42c1b13"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d2af06aa-f830-4eff-b74a-5d43201c2fc3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d3b79d2c-82ae-4696-9f4c-12cd764c3a71"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d42facde-95ae-4e2d-84e7-23b60aafe2b3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d4b39e27-94a9-470b-840f-cb5c3dd21533"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d531bc17-0c16-4233-9eac-5fd7984448d8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d74bace3-2dfa-4ba1-8d22-4956939c442b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d74ce2da-f161-439d-9d28-7a2f978c1e32"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("db494eac-17f3-4199-bb7b-c85315de067e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("de0fe66d-c987-45d9-b980-b1ec6ac0e1bd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("de7cee70-f6fe-4848-92a6-1f6a0c641bd5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("de7f691f-124e-4b5f-8274-42c90c9d1ba3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e051e72f-7539-4e60-bfe8-f7409b8fe158"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e19c097b-d7a4-4201-b239-767264c75104"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e510b38a-09e3-48e9-a7fd-6c010a38ca34"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e72810f4-49be-4a59-a637-3bf9876fdb68"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e8491314-2068-4e37-a5a2-45ad470ecd60"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e954cfdb-cc6b-4cb0-8c15-7d601ae16f76"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eb18d5e8-6489-4c75-8934-6b3e7c441b11"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ebe36781-d6e2-42b7-be85-4e9560d86326"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ed29c6ab-a272-43eb-aa91-f256f6765287"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ed304576-0848-42dc-861b-f48a3614bb73"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("edcbbafd-8a87-4c77-8fbd-2e952a2da7ac"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eecc4787-2310-4331-b2b7-84036ccab00a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eed6efdf-fedd-460a-bb46-d23c1b23e9fc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f0edfc8d-2aae-4e12-a0dd-222009cd043d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f22cff9a-e540-4553-9ad0-7853803a776d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f2c1b5ba-0191-4e67-a890-c8cb9faf684a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f346e252-a66e-4a4f-a5ff-355bfe5278d9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f39873ac-b41d-466a-a6c5-b1bf03910f17"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f39ce47d-20eb-4c02-a90c-acfd2d801200"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f404b953-fee8-4fd1-8fc3-b98376854611"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f6dd679e-7db0-4da5-9a3c-a93cfad7d664"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fa260694-c3ab-4bb2-9033-5104b196ac9d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fab433f1-08d1-4759-8afc-1e4210a7783c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fba4a763-335b-4565-aa83-f40e769fa037"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fbaf7237-0f64-48c3-b4c9-b729e8e68df3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fbca0aa4-423f-4249-8b70-72d505a606ca"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fbd22e13-4904-40a2-9226-891c9e37f545"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fcbbe8df-4e4f-45a5-b803-3519a075bb3e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fea72906-c869-45fa-9126-b87d8873614d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("febaeda1-1a1e-441a-a56a-ea6d413981b8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fed9a761-08e7-419d-a492-1e6c48f46871"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("960d66cb-4e0e-49a4-a56c-31dc69034c9c"), "User" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f6505f3e-0f99-4d93-8887-8ce489b51375"), "Admin" });
        }
    }
}
