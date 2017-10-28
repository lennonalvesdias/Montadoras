namespace Montadoras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carros",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Modelo = c.String(nullable: false, maxLength: 100),
                        Blindagem = c.Boolean(nullable: false),
                        Portas = c.Int(nullable: false),
                        Cor = c.String(nullable: false, maxLength: 80),
                        TipoVeiculo = c.Int(nullable: false),
                        TipoCombustivel = c.Int(nullable: false),
                        TipoCambio = c.Int(nullable: false),
                        MontadoraCodigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Montadoras", t => t.MontadoraCodigo, cascadeDelete: true)
                .Index(t => t.MontadoraCodigo);
            
            CreateTable(
                "dbo.Montadoras",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(nullable: false, maxLength: 250),
                        NomeFantasia = c.String(nullable: false, maxLength: 100),
                        Nacionalidade = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carros", "MontadoraCodigo", "dbo.Montadoras");
            DropIndex("dbo.Carros", new[] { "MontadoraCodigo" });
            DropTable("dbo.Montadoras");
            DropTable("dbo.Carros");
        }
    }
}
