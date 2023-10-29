using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab04.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletionMarks_Tests_TestId",
                table: "CompletionMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletionMarks_Users_UserId",
                table: "CompletionMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Tests_TestId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Difficulties_DifficultyId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Topics_TopicId",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Difficulties",
                table: "Difficulties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletionMarks",
                table: "CompletionMarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "Topics",
                newName: "TopicID");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "Tests",
                newName: "TopicID");

            migrationBuilder.RenameColumn(
                name: "DifficultyId",
                table: "Tests",
                newName: "DifficultyID");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Tests",
                newName: "TestID");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_TopicId",
                table: "Tests",
                newName: "IX_Tests_TopicID");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_DifficultyId",
                table: "Tests",
                newName: "IX_Tests_DifficultyID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Results",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Results",
                newName: "TestID");

            migrationBuilder.RenameColumn(
                name: "ResultId",
                table: "Results",
                newName: "ResultID");

            migrationBuilder.RenameIndex(
                name: "IX_Results_UserId",
                table: "Results",
                newName: "IX_Results_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Results_TestId",
                table: "Results",
                newName: "IX_Results_TestID");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Questions",
                newName: "TestID");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Questions",
                newName: "QuestionID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                newName: "IX_Questions_TestID");

            migrationBuilder.RenameColumn(
                name: "DifficultyId",
                table: "Difficulties",
                newName: "DifficultyID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CompletionMarks",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "CompletionMarks",
                newName: "TestID");

            migrationBuilder.RenameColumn(
                name: "CompletionMarkId",
                table: "CompletionMarks",
                newName: "CompletionMarkID");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "CompletionMarks",
                newName: "CompletionMark");

            migrationBuilder.RenameIndex(
                name: "IX_CompletionMarks_UserId",
                table: "CompletionMarks",
                newName: "IX_CompletionMarks_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_CompletionMarks_TestId",
                table: "CompletionMarks",
                newName: "IX_CompletionMarks_TestID");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answers",
                newName: "QuestionID");

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "Answers",
                newName: "AnswerID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                newName: "IX_Answers_QuestionID");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Topics",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tests",
                type: "varchar(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Questions",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Questions",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Difficulties",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Answers",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Users__1788CCACBF033E00",
                table: "Users",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Topics__022E0F7DDFB58306",
                table: "Topics",
                column: "TopicID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Tests__8CC331006DCB1598",
                table: "Tests",
                column: "TestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Results__976902287723EA0B",
                table: "Results",
                column: "ResultID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Question__0DC06F8C92BF712B",
                table: "Questions",
                column: "QuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Difficul__161A32079577B302",
                table: "Difficulties",
                column: "DifficultyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Completi__D103376E36146DE0",
                table: "CompletionMarks",
                column: "CompletionMarkID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Answers__D4825024DAF3A50D",
                table: "Answers",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__5E55825B2AA016D8",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D1053482AE52CD",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Topics__737584F6BE11C4B6",
                table: "Topics",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Difficul__737584F6F5794362",
                table: "Difficulties",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Answers__Questio__5EBF139D",
                table: "Answers",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Completio__TestI__6383C8BA",
                table: "CompletionMarks",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "TestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Completio__UserI__628FA481",
                table: "CompletionMarks",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Questions__TestI__5BE2A6F2",
                table: "Questions",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "TestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Results__TestID__5812160E",
                table: "Results",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "TestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Results__UserID__59063A47",
                table: "Results",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Tests__Difficult__5535A963",
                table: "Tests",
                column: "DifficultyID",
                principalTable: "Difficulties",
                principalColumn: "DifficultyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Tests__TopicID__5441852A",
                table: "Tests",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Answers__Questio__5EBF139D",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK__Completio__TestI__6383C8BA",
                table: "CompletionMarks");

            migrationBuilder.DropForeignKey(
                name: "FK__Completio__UserI__628FA481",
                table: "CompletionMarks");

            migrationBuilder.DropForeignKey(
                name: "FK__Questions__TestI__5BE2A6F2",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK__Results__TestID__5812160E",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK__Results__UserID__59063A47",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK__Tests__Difficult__5535A963",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK__Tests__TopicID__5441852A",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Users__1788CCACBF033E00",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "UQ__Users__5E55825B2AA016D8",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "UQ__Users__A9D1053482AE52CD",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Topics__022E0F7DDFB58306",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "UQ__Topics__737584F6BE11C4B6",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Tests__8CC331006DCB1598",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Results__976902287723EA0B",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Question__0DC06F8C92BF712B",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Difficul__161A32079577B302",
                table: "Difficulties");

            migrationBuilder.DropIndex(
                name: "UQ__Difficul__737584F6F5794362",
                table: "Difficulties");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Completi__D103376E36146DE0",
                table: "CompletionMarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Answers__D4825024DAF3A50D",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TopicID",
                table: "Topics",
                newName: "TopicId");

            migrationBuilder.RenameColumn(
                name: "TopicID",
                table: "Tests",
                newName: "TopicId");

            migrationBuilder.RenameColumn(
                name: "DifficultyID",
                table: "Tests",
                newName: "DifficultyId");

            migrationBuilder.RenameColumn(
                name: "TestID",
                table: "Tests",
                newName: "TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_TopicID",
                table: "Tests",
                newName: "IX_Tests_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_DifficultyID",
                table: "Tests",
                newName: "IX_Tests_DifficultyId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Results",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TestID",
                table: "Results",
                newName: "TestId");

            migrationBuilder.RenameColumn(
                name: "ResultID",
                table: "Results",
                newName: "ResultId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_UserID",
                table: "Results",
                newName: "IX_Results_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_TestID",
                table: "Results",
                newName: "IX_Results_TestId");

            migrationBuilder.RenameColumn(
                name: "TestID",
                table: "Questions",
                newName: "TestId");

            migrationBuilder.RenameColumn(
                name: "QuestionID",
                table: "Questions",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TestID",
                table: "Questions",
                newName: "IX_Questions_TestId");

            migrationBuilder.RenameColumn(
                name: "DifficultyID",
                table: "Difficulties",
                newName: "DifficultyId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "CompletionMarks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TestID",
                table: "CompletionMarks",
                newName: "TestId");

            migrationBuilder.RenameColumn(
                name: "CompletionMarkID",
                table: "CompletionMarks",
                newName: "CompletionMarkId");

            migrationBuilder.RenameColumn(
                name: "CompletionMark",
                table: "CompletionMarks",
                newName: "Mark");

            migrationBuilder.RenameIndex(
                name: "IX_CompletionMarks_UserID",
                table: "CompletionMarks",
                newName: "IX_CompletionMarks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletionMarks_TestID",
                table: "CompletionMarks",
                newName: "IX_CompletionMarks_TestId");

            migrationBuilder.RenameColumn(
                name: "QuestionID",
                table: "Answers",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "AnswerID",
                table: "Answers",
                newName: "AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionID",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldUnicode: false,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Difficulties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "ResultId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Difficulties",
                table: "Difficulties",
                column: "DifficultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletionMarks",
                table: "CompletionMarks",
                column: "CompletionMarkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletionMarks_Tests_TestId",
                table: "CompletionMarks",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletionMarks_Users_UserId",
                table: "CompletionMarks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Tests_TestId",
                table: "Results",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Difficulties_DifficultyId",
                table: "Tests",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "DifficultyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Topics_TopicId",
                table: "Tests",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
