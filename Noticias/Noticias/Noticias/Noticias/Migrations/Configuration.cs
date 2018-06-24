namespace Noticias.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Noticias.Models.NoticiasDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Noticias.Models.NoticiasDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Categoria.AddOrUpdate(x => x.CategoriaID,
                new Models.Categorias() { CategoriaID = 1, Nome = "Desporto" },
                new Models.Categorias() { CategoriaID = 2, Nome = "Pol�tica" },
                new Models.Categorias() { CategoriaID = 3, Nome = "Sociedade" },
                new Models.Categorias() { CategoriaID = 4, Nome = "Internacional" },
                new Models.Categorias() { CategoriaID = 5, Nome = "Economia" },
                new Models.Categorias() { CategoriaID = 6, Nome = "Desporto" },
                new Models.Categorias() { CategoriaID = 7, Nome = "Cultura" },
                new Models.Categorias() { CategoriaID = 8, Nome = "Opini�o" },
                new Models.Categorias() { CategoriaID = 9, Nome = "Cartoons" },
                new Models.Categorias() { CategoriaID = 10, Nome = "Est� dito" }
);


            context.Imagem.AddOrUpdate(x => x.ImagemID,
                new Models.Imagens { ImagemID = 1, Descricao = "Mariana Mort�gua, do Bloco de Esquerda, durante o debate desta ter�a-feira na Assembleia da Rep�blica", Tipo = "Cabe�alho", Directorio = "Mariana_Mortagua", NoticiaFK = 1 },
                new Models.Imagens { ImagemID = 2, Descricao = "", Tipo = "Cabe�alho", Directorio = "A_Luta", NoticiaFK = 2 },
                new Models.Imagens { ImagemID = 3, Descricao = "", Tipo = "Cabe�alho", Directorio = "Marcelo", NoticiaFK = 3 },
                new Models.Imagens { ImagemID = 4, Descricao = "", Tipo = "Cabe�alho", Directorio = "Milhares", NoticiaFK = 4 }

                );

            context.Jornalista.AddOrUpdate(x => x.JornalistasID,
                new Models.Jornalistas() { JornalistasID = 1, Nome = " Jo�o Santos" },
                new Models.Jornalistas() { JornalistasID = 2, Nome = " Daniel Soares" },
                new Models.Jornalistas() { JornalistasID = 3, Nome = " Adriana Rodrigues" },
                new Models.Jornalistas() { JornalistasID = 4, Nome = " Rosa Fernandes" },
                new Models.Jornalistas() { JornalistasID = 5, Nome = " Carolina Oliveira" },
                new Models.Jornalistas() { JornalistasID = 6, Nome = " C�sar Sousa" },
                new Models.Jornalistas() { JornalistasID = 7, Nome = " Maria Teixeira" },
                new Models.Jornalistas() { JornalistasID = 8, Nome = " Maria Melo" },
                new Models.Jornalistas() { JornalistasID = 9, Nome = " Francisco Vieira" },
                new Models.Jornalistas() { JornalistasID = 10, Nome = " Leonardo Marques" },
                new Models.Jornalistas() { JornalistasID = 11, Nome = " F�bio Carvalho" },
                new Models.Jornalistas() { JornalistasID = 12, Nome = " Tiago Vieira" },
                new Models.Jornalistas() { JornalistasID = 13, Nome = " Rosana Soares" },
                new Models.Jornalistas() { JornalistasID = 14, Nome = " Rui Freitas" },
                new Models.Jornalistas() { JornalistasID = 15, Nome = " C�sar Soares" },
                new Models.Jornalistas() { JornalistasID = 16, Nome = " M�rcio Sousa" },
                new Models.Jornalistas() { JornalistasID = 17, Nome = " Eduardo Vieira" },
                new Models.Jornalistas() { JornalistasID = 18, Nome = " Adriana Oliveira" }

                );

            context.Noticia.AddOrUpdate(x => x.NoticiasID,
                   new Models.Noticias() { NoticiasID = 1, Resumo = "Na concentra��o nacional da CGTP, Mariana Mort�gua fez quest�o de recordar ao PS que n�o tem maioria absoluta. Jer�nimo de Sousa tamb�m comentou os �desabafos� do presidente da Rep�blica, que desvalorizou a tens�o � esquerda - e recusou �press�es� sobre o PCP, que n�o passa �cheques em branco�", Texto = "Bloco de Esquerda admitiu este s�bado que as negocia��es com o Governo para o pr�ximo Or�amento do Estado ser�o mais tensas, lembrando o Partido Socialista de que n�o governa com maioria absoluta.", Titulo = "BE admite que negocia��es para o OE est�o mais tensas, Jer�nimo recusa �press�es", Data = new DateTime(2031, 6, 9), CategoriaFK = 2, JornalistaFK = 1 },
                   new Models.Noticias() { NoticiasID = 2, Resumo = "Os sindicatos afetos � CGTP reuniram-se nas ruas de Lisboa para carregar o tom no mesmo dia em que Jer�nimo de Sousa assumiu que o ambiente das negocia��es para o pr�ximo Or�amento est� �toldado�. Houve gritos contra o ministro da Educa��o e ficou combinada nova concentra��o, frente ao Parlamento e contra os �neg�cios� de Costa com os patr�es. �L� estaremos�, prometeram", Texto = "� porta da pastelaria Coringa, por onde passa quem desce a Avenida Fontes Pereira de Melo quase a chegar ao Marqu�s de Pombal, o rebuli�o � pouco habitual. Saem past�is de massa tenra, croquetes e, sobretudo, cervejas - imperiais ou finos, porque o evento que traz tanta gente ali � nacional - a uma velocidade not�vel. J� passa das 17h40, a concentra��o da CGTP terminou e os manifestantes aproveitam para lanchar antes do regresso a casa.", Titulo ="� Tiago, � Costa�, a luta veio para ficar", Data = new DateTime(2031, 6, 9), CategoriaFK = 2, JornalistaFK = 2 },
                   new Models.Noticias() { NoticiasID = 3, Resumo = "O Presidente da Rep�blica desvaloriza o �ambiente toldado� � esquerda - como Jer�nimo de Sousa descreveu ao Expresso - e diz que os partidos t�m �bom senso� para n�o criarem complica��es �c� dentro�, quando h� tantas �complica��es� na Europa", Texto = "Marcelo Rebelo de Sousa n�o fez um apelo, mas quase. Foi mais uma constata��o com misto de chamamento dos partidos ao bom senso, dando a entender que a esquerda n�o vai chumbar o Or�amento do Estado (OE) para 2019. Tudo para que Portugal n�o contribua para avolumar as crises pol�ticas que grassam na Europa, casos de Espanha e de It�lia. Na manh� deste s�bado, em Ponta Delgada, nos A�ores � onde se prepara para presidir �s comemora��es do 10 de junho �, o Presidente da Rep�blica foi confrontado pelos jornalistas com os sinais de crise � esquerda que podem p�r o OE em perigo: N�o, penso que n�o est� em perigo, respondeu Marcelo.", Titulo = "Marcelo: �Bom - senso faz com que n�o haja crise or�amental a temer", Data = new DateTime(2031, 6, 9), CategoriaFK = 2, JornalistaFK = 3 },
                   new Models.Noticias() { NoticiasID = 4, Resumo = "s manifestantes v�o desfilar, ao in�cio da tarde, entre o Campo Pequeno e o Marqu�s de Pombal. Lutar Pelos Direitos, Valorizar Os Trabalhadores!, ser� o lema do protesto", Texto = "Milhares de trabalhadores de todo o pa�s deslocam-se hoje a Lisboa para participar na manifesta��o nacional da CGTP contra a pol�tica laboral e em defesa da valoriza��o do trabalho e dos trabalhadores.", Titulo = "Milhares de trabalhadores participam na manifesta��o nacional da CGTPM", Data = new DateTime(2031, 6, 9), CategoriaFK = 2, JornalistaFK = 4 }
                   );

            context.SaveChanges();
        }
    }
}
