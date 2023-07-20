using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BigEvent.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    event_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    event_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maximum_guests = table.Column<int>(type: "int", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_event = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_event = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.event_Id);
                });

            migrationBuilder.CreateTable(
                name: "allotments",
                columns: table => new
                {
                    id_allotment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    num_allotment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price_allotment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    limit_guest = table.Column<int>(type: "int", nullable: false),
                    initial_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    finish_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    event_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allotments", x => x.id_allotment);
                    table.ForeignKey(
                        name: "FK_allotments_events_event_id",
                        column: x => x.event_id,
                        principalTable: "events",
                        principalColumn: "event_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "speakers",
                columns: table => new
                {
                    id_speaker = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_speaker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resume_speaker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo_speaker_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_speaker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_speaker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speakers", x => x.id_speaker);
                    table.ForeignKey(
                        name: "FK_speakers_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "event_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "social_medias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_social_media = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url_social_media = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    event_id = table.Column<int>(type: "int", nullable: true),
                    speaker_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social_medias", x => x.id);
                    table.ForeignKey(
                        name: "FK_social_medias_events_event_id",
                        column: x => x.event_id,
                        principalTable: "events",
                        principalColumn: "event_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_social_medias_speakers_speaker_id",
                        column: x => x.speaker_id,
                        principalTable: "speakers",
                        principalColumn: "id_speaker",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "speaker_event",
                columns: table => new
                {
                    speaker_id = table.Column<int>(type: "int", nullable: false),
                    event_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speaker_event", x => new { x.event_id, x.speaker_id });
                    table.ForeignKey(
                        name: "FK_speaker_event_events_event_id",
                        column: x => x.event_id,
                        principalTable: "events",
                        principalColumn: "event_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_speaker_event_speakers_speaker_id",
                        column: x => x.speaker_id,
                        principalTable: "speakers",
                        principalColumn: "id_speaker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_allotments_event_id",
                table: "allotments",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_social_medias_event_id",
                table: "social_medias",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_social_medias_speaker_id",
                table: "social_medias",
                column: "speaker_id");

            migrationBuilder.CreateIndex(
                name: "IX_speaker_event_speaker_id",
                table: "speaker_event",
                column: "speaker_id");

            migrationBuilder.CreateIndex(
                name: "IX_speakers_EventId",
                table: "speakers",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allotments");

            migrationBuilder.DropTable(
                name: "social_medias");

            migrationBuilder.DropTable(
                name: "speaker_event");

            migrationBuilder.DropTable(
                name: "speakers");

            migrationBuilder.DropTable(
                name: "events");
        }
    }
}
