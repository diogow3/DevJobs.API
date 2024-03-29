﻿// <auto-generated />
using System;
using DevJobs.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DevJobs.API.Migrations
{
    [DbContext(typeof(DevJobsContext))]
    partial class DevJobsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DevJobs.API.Models.JobApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicantEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApplicantName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdJobVacancy")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdJobVacancy");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("DevJobs.API.Models.JobVacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRemote")
                        .HasColumnType("boolean");

                    b.Property<string>("SalaryRange")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("JobVacancies");
                });

            modelBuilder.Entity("DevJobs.API.Models.JobApplication", b =>
                {
                    b.HasOne("DevJobs.API.Models.JobVacancy", null)
                        .WithMany("Applications")
                        .HasForeignKey("IdJobVacancy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DevJobs.API.Models.JobVacancy", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
