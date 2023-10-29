﻿// <auto-generated />
using Lab04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab04.Migrations
{
    [DbContext(typeof(TestingSystemDbContext))]
    partial class TestingSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab04.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AnswerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("int")
                        .HasColumnName("QuestionID");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("AnswerId")
                        .HasName("PK__Answers__D4825024DAF3A50D");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Lab04.Models.CompletionMark", b =>
                {
                    b.Property<int>("CompletionMarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CompletionMarkID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompletionMarkId"));

                    b.Property<bool>("Mark")
                        .HasColumnType("bit")
                        .HasColumnName("CompletionMark");

                    b.Property<int>("TestId")
                        .HasColumnType("int")
                        .HasColumnName("TestID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("CompletionMarkId")
                        .HasName("PK__Completi__D103376E36146DE0");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("CompletionMarks");
                });

            modelBuilder.Entity("Lab04.Models.Difficulty", b =>
                {
                    b.Property<int>("DifficultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DifficultyID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DifficultyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("DifficultyId")
                        .HasName("PK__Difficul__161A32079577B302");

                    b.HasIndex(new[] { "Name" }, "UQ__Difficul__737584F6F5794362")
                        .IsUnique();

                    b.ToTable("Difficulties");
                });

            modelBuilder.Entity("Lab04.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("QuestionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("NumberOfPoints")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int")
                        .HasColumnName("TestID");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("QuestionId")
                        .HasName("PK__Question__0DC06F8C92BF712B");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Lab04.Models.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ResultID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultId"));

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int")
                        .HasColumnName("TestID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("ResultId")
                        .HasName("PK__Results__976902287723EA0B");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Lab04.Models.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TestID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestId"));

                    b.Property<int>("DifficultyId")
                        .HasColumnType("int")
                        .HasColumnName("DifficultyID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<int>("NumberOfQuestions")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int")
                        .HasColumnName("TopicID");

                    b.HasKey("TestId")
                        .HasName("PK__Tests__8CC331006DCB1598");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("TopicId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Lab04.Models.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TopicID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TopicId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("TopicId")
                        .HasName("PK__Topics__022E0F7DDFB58306");

                    b.HasIndex(new[] { "Name" }, "UQ__Topics__737584F6BE11C4B6")
                        .IsUnique();

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Lab04.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CCACBF033E00");

                    b.HasIndex(new[] { "Login" }, "UQ__Users__5E55825B2AA016D8")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D1053482AE52CD")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lab04.Models.Answer", b =>
                {
                    b.HasOne("Lab04.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Answers__Questio__5EBF139D");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Lab04.Models.CompletionMark", b =>
                {
                    b.HasOne("Lab04.Models.Test", "Test")
                        .WithMany("CompletionMarks")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Completio__TestI__6383C8BA");

                    b.HasOne("Lab04.Models.User", "User")
                        .WithMany("CompletionMarks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Completio__UserI__628FA481");

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lab04.Models.Question", b =>
                {
                    b.HasOne("Lab04.Models.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Questions__TestI__5BE2A6F2");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Lab04.Models.Result", b =>
                {
                    b.HasOne("Lab04.Models.Test", "Test")
                        .WithMany("Results")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Results__TestID__5812160E");

                    b.HasOne("Lab04.Models.User", "User")
                        .WithMany("Results")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Results__UserID__59063A47");

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lab04.Models.Test", b =>
                {
                    b.HasOne("Lab04.Models.Difficulty", "Difficulty")
                        .WithMany("Tests")
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Tests__Difficult__5535A963");

                    b.HasOne("Lab04.Models.Topic", "Topic")
                        .WithMany("Tests")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Tests__TopicID__5441852A");

                    b.Navigation("Difficulty");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Lab04.Models.Difficulty", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Lab04.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Lab04.Models.Test", b =>
                {
                    b.Navigation("CompletionMarks");

                    b.Navigation("Questions");

                    b.Navigation("Results");
                });

            modelBuilder.Entity("Lab04.Models.Topic", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Lab04.Models.User", b =>
                {
                    b.Navigation("CompletionMarks");

                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
