﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubjectWebApi.Data;

#nullable disable

namespace SubjectWebApi.Migrations
{
    [DbContext(typeof(SubjectDbContext))]
    [Migration("20230927023857_SubjectDb6")]
    partial class SubjectDb6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SubjectWebApi.Models.Answer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("SubjectWebApi.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("subjectId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("SubjectWebApi.Models.LessonFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Approve")
                        .HasColumnType("bit");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessionId");

                    b.ToTable("LessonsFile");
                });

            modelBuilder.Entity("SubjectWebApi.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessionId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("SubjectWebApi.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubJectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("star")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SubjectWebApi.Models.Answer", b =>
                {
                    b.HasOne("SubjectWebApi.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("SubjectWebApi.Models.Lesson", b =>
                {
                    b.HasOne("SubjectWebApi.Models.Subject", "Subject")
                        .WithMany("Lession")
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SubjectWebApi.Models.LessonFile", b =>
                {
                    b.HasOne("SubjectWebApi.Models.Lesson", "lession")
                        .WithMany("LessonsFile")
                        .HasForeignKey("LessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lession");
                });

            modelBuilder.Entity("SubjectWebApi.Models.Question", b =>
                {
                    b.HasOne("SubjectWebApi.Models.Lesson", "lession")
                        .WithMany("Question")
                        .HasForeignKey("LessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lession");
                });

            modelBuilder.Entity("SubjectWebApi.Models.Lesson", b =>
                {
                    b.Navigation("LessonsFile");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("SubjectWebApi.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("SubjectWebApi.Models.Subject", b =>
                {
                    b.Navigation("Lession");
                });
#pragma warning restore 612, 618
        }
    }
}
