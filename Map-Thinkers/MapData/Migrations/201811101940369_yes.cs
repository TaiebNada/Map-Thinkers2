namespace MapData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "JobRequest_JobRequestId", "dbo.JobRequests");
            DropForeignKey("dbo.JobRequestFolders", "JobRequest_JobRequestId", "dbo.JobRequests");
            DropForeignKey("dbo.JobRequestFolders", "Folder_FolderId", "dbo.Folders");
            DropForeignKey("dbo.JobOffers", "JobRequest_JobRequestId", "dbo.JobRequests");
            DropForeignKey("dbo.JobRequests", "Interview_InterviewId", "dbo.Interviews");
            DropForeignKey("dbo.Tests", "Question_QuestionId", "dbo.Questions");
            DropIndex("dbo.AspNetUsers", new[] { "JobRequest_JobRequestId" });
            DropIndex("dbo.JobRequests", new[] { "Interview_InterviewId" });
            DropIndex("dbo.JobOffers", new[] { "JobRequest_JobRequestId" });
            DropIndex("dbo.Tests", new[] { "Question_QuestionId" });
            DropIndex("dbo.JobRequestFolders", new[] { "JobRequest_JobRequestId" });
            DropIndex("dbo.JobRequestFolders", new[] { "Folder_FolderId" });
            CreateTable(
                "dbo.QuestionTests",
                c => new
                    {
                        Question_QuestionId = c.Int(nullable: false),
                        Test_TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_QuestionId, t.Test_TestId })
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.Test_TestId, cascadeDelete: true)
                .Index(t => t.Question_QuestionId)
                .Index(t => t.Test_TestId);
            
            AddColumn("dbo.Folders", "JobRequestId", c => c.Int(nullable: false));
            AddColumn("dbo.JobRequests", "UserId", c => c.Int());
            AddColumn("dbo.JobRequests", "JobOfferId", c => c.Int(nullable: false));
            AddColumn("dbo.JobRequests", "Candidate_Id", c => c.Int());
            AddColumn("dbo.Interviews", "JobRequestId", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "FolderId", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "Folder_FolderId", c => c.Int());
            CreateIndex("dbo.Folders", "JobRequestId");
            CreateIndex("dbo.JobRequests", "JobOfferId");
            CreateIndex("dbo.JobRequests", "Candidate_Id");
            CreateIndex("dbo.Interviews", "JobRequestId");
            CreateIndex("dbo.Tests", "FolderId");
            CreateIndex("dbo.Tests", "Folder_FolderId");
            AddForeignKey("dbo.JobRequests", "Candidate_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Interviews", "JobRequestId", "dbo.JobRequests", "JobRequestId", cascadeDelete: true);
            AddForeignKey("dbo.JobRequests", "JobOfferId", "dbo.JobOffers", "JobOfferId", cascadeDelete: true);
            AddForeignKey("dbo.Folders", "JobRequestId", "dbo.JobRequests", "JobRequestId", cascadeDelete: true);
            AddForeignKey("dbo.Tests", "FolderId", "dbo.Folders", "FolderId", cascadeDelete: true);
            AddForeignKey("dbo.Tests", "Folder_FolderId", "dbo.Folders", "FolderId");
            DropColumn("dbo.AspNetUsers", "JobRequest_JobRequestId");
            DropColumn("dbo.JobRequests", "Interview_InterviewId");
            DropColumn("dbo.JobOffers", "JobRequest_JobRequestId");
            DropColumn("dbo.Tests", "Question_QuestionId");
            DropTable("dbo.JobRequestFolders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobRequestFolders",
                c => new
                    {
                        JobRequest_JobRequestId = c.Int(nullable: false),
                        Folder_FolderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobRequest_JobRequestId, t.Folder_FolderId });
            
            AddColumn("dbo.Tests", "Question_QuestionId", c => c.Int());
            AddColumn("dbo.JobOffers", "JobRequest_JobRequestId", c => c.Int());
            AddColumn("dbo.JobRequests", "Interview_InterviewId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "JobRequest_JobRequestId", c => c.Int());
            DropForeignKey("dbo.Tests", "Folder_FolderId", "dbo.Folders");
            DropForeignKey("dbo.QuestionTests", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.QuestionTests", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Tests", "FolderId", "dbo.Folders");
            DropForeignKey("dbo.Folders", "JobRequestId", "dbo.JobRequests");
            DropForeignKey("dbo.JobRequests", "JobOfferId", "dbo.JobOffers");
            DropForeignKey("dbo.Interviews", "JobRequestId", "dbo.JobRequests");
            DropForeignKey("dbo.JobRequests", "Candidate_Id", "dbo.AspNetUsers");
            DropIndex("dbo.QuestionTests", new[] { "Test_TestId" });
            DropIndex("dbo.QuestionTests", new[] { "Question_QuestionId" });
            DropIndex("dbo.Tests", new[] { "Folder_FolderId" });
            DropIndex("dbo.Tests", new[] { "FolderId" });
            DropIndex("dbo.Interviews", new[] { "JobRequestId" });
            DropIndex("dbo.JobRequests", new[] { "Candidate_Id" });
            DropIndex("dbo.JobRequests", new[] { "JobOfferId" });
            DropIndex("dbo.Folders", new[] { "JobRequestId" });
            DropColumn("dbo.Tests", "Folder_FolderId");
            DropColumn("dbo.Tests", "FolderId");
            DropColumn("dbo.Interviews", "JobRequestId");
            DropColumn("dbo.JobRequests", "Candidate_Id");
            DropColumn("dbo.JobRequests", "JobOfferId");
            DropColumn("dbo.JobRequests", "UserId");
            DropColumn("dbo.Folders", "JobRequestId");
            DropTable("dbo.QuestionTests");
            CreateIndex("dbo.JobRequestFolders", "Folder_FolderId");
            CreateIndex("dbo.JobRequestFolders", "JobRequest_JobRequestId");
            CreateIndex("dbo.Tests", "Question_QuestionId");
            CreateIndex("dbo.JobOffers", "JobRequest_JobRequestId");
            CreateIndex("dbo.JobRequests", "Interview_InterviewId");
            CreateIndex("dbo.AspNetUsers", "JobRequest_JobRequestId");
            AddForeignKey("dbo.Tests", "Question_QuestionId", "dbo.Questions", "QuestionId");
            AddForeignKey("dbo.JobRequests", "Interview_InterviewId", "dbo.Interviews", "InterviewId");
            AddForeignKey("dbo.JobOffers", "JobRequest_JobRequestId", "dbo.JobRequests", "JobRequestId");
            AddForeignKey("dbo.JobRequestFolders", "Folder_FolderId", "dbo.Folders", "FolderId", cascadeDelete: true);
            AddForeignKey("dbo.JobRequestFolders", "JobRequest_JobRequestId", "dbo.JobRequests", "JobRequestId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "JobRequest_JobRequestId", "dbo.JobRequests", "JobRequestId");
        }
    }
}
