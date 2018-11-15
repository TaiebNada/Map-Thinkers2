namespace MapData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fllll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "FolderId", "dbo.Folders");
            DropForeignKey("dbo.Folders", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.QuestionTests", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionTests", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.Tests", "Folder_FolderId", "dbo.Folders");
            DropIndex("dbo.Folders", new[] { "Test_TestId" });
            DropIndex("dbo.Tests", new[] { "FolderId" });
            DropIndex("dbo.Tests", new[] { "Folder_FolderId" });
            DropIndex("dbo.QuestionTests", new[] { "Question_QuestionId" });
            DropIndex("dbo.QuestionTests", new[] { "Test_TestId" });
            CreateTable(
                "dbo.TestMarks",
                c => new
                    {
                        TestId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        mark = c.Int(nullable: false),
                        c_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.TestId, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.c_Id)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId)
                .Index(t => t.c_Id);
            
            CreateTable(
                "dbo.TestCandidates",
                c => new
                    {
                        Test_TestId = c.Int(nullable: false),
                        Candidate_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_TestId, t.Candidate_Id })
                .ForeignKey("dbo.Tests", t => t.Test_TestId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Candidate_Id, cascadeDelete: true)
                .Index(t => t.Test_TestId)
                .Index(t => t.Candidate_Id);
            
            AddColumn("dbo.Questions", "Question_QuestionId", c => c.Int());
            AddColumn("dbo.Questions", "Test_TestId", c => c.Int());
            CreateIndex("dbo.Questions", "Question_QuestionId");
            CreateIndex("dbo.Questions", "Test_TestId");
            AddForeignKey("dbo.Questions", "Question_QuestionId", "dbo.Questions", "QuestionId");
            AddForeignKey("dbo.Questions", "Test_TestId", "dbo.Tests", "TestId");
            DropColumn("dbo.Folders", "Test_TestId");
            DropColumn("dbo.Tests", "FolderId");
            DropColumn("dbo.Tests", "Folder_FolderId");
            DropTable("dbo.QuestionTests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuestionTests",
                c => new
                    {
                        Question_QuestionId = c.Int(nullable: false),
                        Test_TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_QuestionId, t.Test_TestId });
            
            AddColumn("dbo.Tests", "Folder_FolderId", c => c.Int());
            AddColumn("dbo.Tests", "FolderId", c => c.Int(nullable: false));
            AddColumn("dbo.Folders", "Test_TestId", c => c.Int());
            DropForeignKey("dbo.Questions", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.Questions", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.TestMarks", "TestId", "dbo.Tests");
            DropForeignKey("dbo.TestMarks", "c_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestCandidates", "Candidate_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestCandidates", "Test_TestId", "dbo.Tests");
            DropIndex("dbo.TestCandidates", new[] { "Candidate_Id" });
            DropIndex("dbo.TestCandidates", new[] { "Test_TestId" });
            DropIndex("dbo.Questions", new[] { "Test_TestId" });
            DropIndex("dbo.Questions", new[] { "Question_QuestionId" });
            DropIndex("dbo.TestMarks", new[] { "c_Id" });
            DropIndex("dbo.TestMarks", new[] { "TestId" });
            DropColumn("dbo.Questions", "Test_TestId");
            DropColumn("dbo.Questions", "Question_QuestionId");
            DropTable("dbo.TestCandidates");
            DropTable("dbo.TestMarks");
            CreateIndex("dbo.QuestionTests", "Test_TestId");
            CreateIndex("dbo.QuestionTests", "Question_QuestionId");
            CreateIndex("dbo.Tests", "Folder_FolderId");
            CreateIndex("dbo.Tests", "FolderId");
            CreateIndex("dbo.Folders", "Test_TestId");
            AddForeignKey("dbo.Tests", "Folder_FolderId", "dbo.Folders", "FolderId");
            AddForeignKey("dbo.QuestionTests", "Test_TestId", "dbo.Tests", "TestId", cascadeDelete: true);
            AddForeignKey("dbo.QuestionTests", "Question_QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
            AddForeignKey("dbo.Folders", "Test_TestId", "dbo.Tests", "TestId");
            AddForeignKey("dbo.Tests", "FolderId", "dbo.Folders", "FolderId", cascadeDelete: true);
        }
    }
}
