﻿// <auto-generated />
using HalfboardStats.Core.ObjectRelationalMappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HalfboardStats.Migrations
{
    [DbContext(typeof(HalfboardContext))]
    [Migration("20221031005334_AddRegularPlayerSeason")]
    partial class AddRegularPlayerSeason
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HalfboardStats.Core.ObjectRelationalMappers.Player", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("BirthCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthStateProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentAge")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAlternateCaptain")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCaptain")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRookie")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayingPosition")
                        .HasColumnType("int");

                    b.Property<string>("PrimaryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RosterStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShootsCatches")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("HalfboardStats.Core.ObjectRelationalMappers.PlayerSeason", b =>
                {
                    b.Property<int>("PlayerSeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("BlockedShots")
                        .HasColumnType("int");

                    b.Property<string>("EvenStrengthTimeOnIce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EvenTimeOnIcePerGame")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FaceOffPct")
                        .HasColumnType("int");

                    b.Property<int>("GameWinningGoals")
                        .HasColumnType("int");

                    b.Property<int>("Games")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int>("Hits")
                        .HasColumnType("int");

                    b.Property<int>("OverTimeGoals")
                        .HasColumnType("int");

                    b.Property<string>("PenaltyMinutes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pim")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("PlusMinus")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("PowerPlayGoals")
                        .HasColumnType("int");

                    b.Property<int>("PowerPlayPoints")
                        .HasColumnType("int");

                    b.Property<string>("PowerPlayTimeOnIce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PowerPlayTimeOnIcePerGame")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Season")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeasonSplit")
                        .HasColumnType("int");

                    b.Property<int>("Shifts")
                        .HasColumnType("int");

                    b.Property<int>("ShortHandedGoals")
                        .HasColumnType("int");

                    b.Property<int>("ShortHandedPoints")
                        .HasColumnType("int");

                    b.Property<string>("ShortHandedTimeOnIce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortHandedTimeOnIcePerGame")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShotPct")
                        .HasColumnType("int");

                    b.Property<int>("Shots")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("TimeOnIce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeOnIcePerGame")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerSeasonId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerSeasons");
                });

            modelBuilder.Entity("HalfboardStats.Core.ObjectRelationalMappers.RegularSeasonStats", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<string>("EvenStrengthTimeOnIce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EvenTimeOnIcePerGame")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FaceOffPct")
                        .HasColumnType("float");

                    b.Property<int>("GameWinningGoals")
                        .HasColumnType("int");

                    b.Property<int>("Games")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int>("Hits")
                        .HasColumnType("int");

                    b.Property<int>("OverTimeGoals")
                        .HasColumnType("int");

                    b.Property<string>("PenaltyMinutes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pim")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("PlusMinus")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("PowerPlayGoals")
                        .HasColumnType("int");

                    b.Property<int>("PowerPlayPoints")
                        .HasColumnType("int");

                    b.Property<string>("PowerPlayTimeOnIce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PowerPlayTimeOnIcePerGame")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Shifts")
                        .HasColumnType("int");

                    b.Property<int>("ShortHandedGoals")
                        .HasColumnType("int");

                    b.Property<int>("ShortHandedPoints")
                        .HasColumnType("int");

                    b.Property<string>("ShortHandedTimeOnIce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortHandedTimeOnIcePerGame")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ShotPct")
                        .HasColumnType("float");

                    b.Property<int>("Shots")
                        .HasColumnType("int");

                    b.Property<int>("ShotsBlocked")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("TimeOnIcePerGame")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("RegularSeasonStats");
                });

            modelBuilder.Entity("HalfboardStats.Core.ObjectRelationalMappers.Team", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DivisionId")
                        .HasColumnType("int");

                    b.Property<int>("FirstYearOfPlay")
                        .HasColumnType("int");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficialSiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("HalfboardStats.Core.ObjectRelationalMappers.TeamSeason", b =>
                {
                    b.Property<int>("TeamSeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("TeamSeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamSeason");
                });

            modelBuilder.Entity("HalfboardStats.Core.ObjectRelationalMappers.Player", b =>
                {
                    b.HasOne("HalfboardStats.Core.ObjectRelationalMappers.Team", "CurrentTeam")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentTeam");
                });

            modelBuilder.Entity("HalfboardStats.Core.ObjectRelationalMappers.PlayerSeason", b =>
                {
                    b.HasOne("HalfboardStats.Core.ObjectRelationalMappers.Player", null)
                        .WithMany("PlayerSeasons")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HalfboardStats.Core.ObjectRelationalMappers.RegularSeasonStats", b =>
                {
                    b.HasOne("HalfboardStats.Core.ObjectRelationalMappers.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HalfboardStats.Core.ObjectRelationalMappers.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("HalfboardStats.Core.ObjectRelationalMappers.TeamSeason", b =>
                {
                    b.HasOne("HalfboardStats.Core.ObjectRelationalMappers.Team", null)
                        .WithMany("TeamSeasons")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HalfboardStats.Core.ObjectRelationalMappers.Player", b =>
                {
                    b.Navigation("PlayerSeasons");
                });

            modelBuilder.Entity("HalfboardStats.Core.ObjectRelationalMappers.Team", b =>
                {
                    b.Navigation("TeamSeasons");
                });
#pragma warning restore 612, 618
        }
    }
}
