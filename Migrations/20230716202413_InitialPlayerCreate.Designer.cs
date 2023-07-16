﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBAGraphs.Data;

#nullable disable

namespace NBAGraphs.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230716202413_InitialPlayerCreate")]
    partial class InitialPlayerCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NBAGraphs.Models.Player", b =>
                {
                    b.Property<string>("player_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("fk_team_idteam_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("games_played")
                        .HasColumnType("int");

                    b.Property<string>("lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("points_per_game")
                        .HasColumnType("real");

                    b.Property<int>("total_points")
                        .HasColumnType("int");

                    b.HasKey("player_id");

                    b.HasIndex("fk_team_idteam_id");

                    b.ToTable("players");
                });

            modelBuilder.Entity("NBAGraphs.Models.Team", b =>
                {
                    b.Property<string>("team_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logo_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("team_id");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("NBAGraphs.Models.Player", b =>
                {
                    b.HasOne("NBAGraphs.Models.Team", "fk_team_id")
                        .WithMany()
                        .HasForeignKey("fk_team_idteam_id");

                    b.Navigation("fk_team_id");
                });
#pragma warning restore 612, 618
        }
    }
}
