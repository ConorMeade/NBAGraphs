﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBAGraphs.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NBAGraphs.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230717175829_updatePlayerModelFk")]
    partial class updatePlayerModelFk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NBAGraphs.Models.Player", b =>
                {
                    b.Property<string>("player_id")
                        .HasColumnType("text");

                    b.Property<float>("assists_per_game")
                        .HasColumnType("real");

                    b.Property<string>("fname")
                        .HasColumnType("text");

                    b.Property<int>("games_played")
                        .HasColumnType("integer");

                    b.Property<string>("lname")
                        .HasColumnType("text");

                    b.Property<int>("player_team")
                        .HasColumnType("integer");

                    b.Property<float>("points_per_game")
                        .HasColumnType("real");

                    b.Property<int>("rapid_id")
                        .HasColumnType("integer");

                    b.Property<float>("rebounds_per_game")
                        .HasColumnType("real");

                    b.Property<int>("total_points")
                        .HasColumnType("integer");

                    b.HasKey("player_id");

                    b.ToTable("players");
                });

            modelBuilder.Entity("NBAGraphs.Models.Team", b =>
                {
                    b.Property<string>("team_id")
                        .HasColumnType("text");

                    b.Property<string>("city")
                        .HasColumnType("text");

                    b.Property<string>("logo_url")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("primary_color")
                        .HasColumnType("text");

                    b.HasKey("team_id");

                    b.ToTable("teams");
                });
#pragma warning restore 612, 618
        }
    }
}