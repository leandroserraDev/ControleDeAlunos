namespace ControleDeAlunos.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        AlunoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20, unicode: false),
                        Matricula = c.Int(nullable: false),
                        TurmaId = c.Int(),
                    })
                .PrimaryKey(t => t.AlunoId)
                .ForeignKey("dbo.Turma", t => t.TurmaId)
                .Index(t => t.TurmaId);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        TurmaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.TurmaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alunos", "TurmaId", "dbo.Turma");
            DropIndex("dbo.Alunos", new[] { "TurmaId" });
            DropTable("dbo.Turma");
            DropTable("dbo.Alunos");
        }
    }
}
