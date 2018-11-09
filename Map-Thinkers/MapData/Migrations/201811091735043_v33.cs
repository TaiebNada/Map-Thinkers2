namespace MapData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v33 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        FolderId = c.Int(nullable: false, identity: true),
                        LettreDefault = c.String(),
                        LettreSigned = c.String(),
                        Condition = c.Int(nullable: false),
                        FolderState = c.Int(nullable: false),
                        MinisterState = c.Int(nullable: false),
                        Test_TestId = c.Int(),
                    })
                .PrimaryKey(t => t.FolderId)
                .ForeignKey("dbo.Tests", t => t.Test_TestId)
                .Index(t => t.Test_TestId);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        InterviewId = c.Int(nullable: false, identity: true),
                        InterviewDate = c.DateTime(nullable: false),
                        InterviewType = c.Int(nullable: false),
                        InterviewState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InterviewId);
            
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        JobOfferId = c.Int(nullable: false, identity: true),
                        JobOfferDesrip = c.String(),
                        Required_Profile = c.String(),
                        DateDeb = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        Experience = c.String(),
                        Function = c.String(),
                        Poste_numb = c.Int(nullable: false),
                        JobRequest_JobRequestId = c.Int(),
                    })
                .PrimaryKey(t => t.JobOfferId)
                .ForeignKey("dbo.JobRequests", t => t.JobRequest_JobRequestId)
                .Index(t => t.JobRequest_JobRequestId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        subject = c.String(),
                        choice1 = c.String(),
                        choice2 = c.String(),
                        choice3 = c.String(),
                        validchoice = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.TestId);
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        Test_TestId = c.Int(nullable: false),
                        Question_QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_TestId, t.Question_QuestionId })
                .ForeignKey("dbo.Tests", t => t.Test_TestId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .Index(t => t.Test_TestId)
                .Index(t => t.Question_QuestionId);
            
            AddColumn("dbo.AspNetUsers", "FirstName1", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName1", c => c.String());
            AddColumn("dbo.AspNetUsers", "Picture1", c => c.String());
            AddColumn("dbo.AspNetUsers", "WorkType1", c => c.Int());
            AddColumn("dbo.AspNetUsers", "JobRequest_JobRequestId", c => c.Int());
            AddColumn("dbo.JobRequests", "JobRequest_Motivation", c => c.String());
            AddColumn("dbo.JobRequests", "Interview_InterviewId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "JobRequest_JobRequestId");
            CreateIndex("dbo.JobRequests", "Interview_InterviewId");
            AddForeignKey("dbo.AspNetUsers", "JobRequest_JobRequestId", "dbo.JobRequests", "JobRequestId");
            AddForeignKey("dbo.JobRequests", "Interview_InterviewId", "dbo.Interviews", "InterviewId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestQuestions", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.TestQuestions", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.Folders", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.JobRequests", "Interview_InterviewId", "dbo.Interviews");
            DropForeignKey("dbo.JobOffers", "JobRequest_JobRequestId", "dbo.JobRequests");
            DropForeignKey("dbo.AspNetUsers", "JobRequest_JobRequestId", "dbo.JobRequests");
            DropIndex("dbo.TestQuestions", new[] { "Question_QuestionId" });
            DropIndex("dbo.TestQuestions", new[] { "Test_TestId" });
            DropIndex("dbo.JobOffers", new[] { "JobRequest_JobRequestId" });
            DropIndex("dbo.JobRequests", new[] { "Interview_InterviewId" });
            DropIndex("dbo.Folders", new[] { "Test_TestId" });
            DropIndex("dbo.AspNetUsers", new[] { "JobRequest_JobRequestId" });
            DropColumn("dbo.JobRequests", "Interview_InterviewId");
            DropColumn("dbo.JobRequests", "JobRequest_Motivation");
            DropColumn("dbo.AspNetUsers", "JobRequest_JobRequestId");
            DropColumn("dbo.AspNetUsers", "WorkType1");
            DropColumn("dbo.AspNetUsers", "Picture1");
            DropColumn("dbo.AspNetUsers", "LastName1");
            DropColumn("dbo.AspNetUsers", "FirstName1");
            DropTable("dbo.TestQuestions");
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.JobOffers");
            DropTable("dbo.Interviews");
            DropTable("dbo.Folders");
        }
    }
}
