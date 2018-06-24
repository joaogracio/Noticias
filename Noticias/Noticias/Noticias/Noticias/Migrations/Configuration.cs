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
                new Models.Categorias() { CategoriaID = 2, Nome = "Política" },
                new Models.Categorias() { CategoriaID = 3, Nome = "Sociedade" },
                new Models.Categorias() { CategoriaID = 4, Nome = "Internacional" },
                new Models.Categorias() { CategoriaID = 5, Nome = "Economia" },
                new Models.Categorias() { CategoriaID = 6, Nome = "Desporto" },
                new Models.Categorias() { CategoriaID = 7, Nome = "Cultura" },
                new Models.Categorias() { CategoriaID = 8, Nome = "Opinião" },
                new Models.Categorias() { CategoriaID = 9, Nome = "Cartoons" },
                new Models.Categorias() { CategoriaID = 10, Nome = "Está dito" }
);


            context.Imagem.AddOrUpdate(x => x.ImagemID,
                new Models.Imagens { ImagemID = 1, Descricao = "Mariana Mortágua, do Bloco de Esquerda, durante o debate desta terça-feira na Assembleia da República", Tipo = "Cabeçalho", Directorio = "Mariana_Mortagua", NoticiaFK = 1 },
                new Models.Imagens { ImagemID = 2, Descricao = "", Tipo = "Cabeçalho", Directorio = "A_Luta", NoticiaFK = 2 },
                new Models.Imagens { ImagemID = 3, Descricao = "", Tipo = "Cabeçalho", Directorio = "Marcelo", NoticiaFK = 3 },
                new Models.Imagens { ImagemID = 4, Descricao = "", Tipo = "Cabeçalho", Directorio = "Milhares", NoticiaFK = 4 }

                );

            context.Jornalista.AddOrUpdate(x => x.JornalistasID,
                new Models.Jornalistas() { JornalistasID = 1, Nome = " João Santos" },
                new Models.Jornalistas() { JornalistasID = 2, Nome = " Daniel Soares" },
                new Models.Jornalistas() { JornalistasID = 3, Nome = " Adriana Rodrigues" },
                new Models.Jornalistas() { JornalistasID = 4, Nome = " Rosa Fernandes" },
                new Models.Jornalistas() { JornalistasID = 5, Nome = " Carolina Oliveira" },
                new Models.Jornalistas() { JornalistasID = 6, Nome = " César Sousa" },
                new Models.Jornalistas() { JornalistasID = 7, Nome = " Maria Teixeira" },
                new Models.Jornalistas() { JornalistasID = 8, Nome = " Maria Melo" },
                new Models.Jornalistas() { JornalistasID = 9, Nome = " Francisco Vieira" },
                new Models.Jornalistas() { JornalistasID = 10, Nome = " Leonardo Marques" },
                new Models.Jornalistas() { JornalistasID = 11, Nome = " Fábio Carvalho" },
                new Models.Jornalistas() { JornalistasID = 12, Nome = " Tiago Vieira" },
                new Models.Jornalistas() { JornalistasID = 13, Nome = " Rosana Soares" },
                new Models.Jornalistas() { JornalistasID = 14, Nome = " Rui Freitas" },
                new Models.Jornalistas() { JornalistasID = 15, Nome = " César Soares" },
                new Models.Jornalistas() { JornalistasID = 16, Nome = " Márcio Sousa" },
                new Models.Jornalistas() { JornalistasID = 17, Nome = " Eduardo Vieira" },
                new Models.Jornalistas() { JornalistasID = 18, Nome = " Adriana Oliveira" }

                );

            context.Noticia.AddOrUpdate(x => x.NoticiasID,
                   new Models.Noticias() { NoticiasID = 1, Resumo = "Na concentração nacional da CGTP, Mariana Mortágua fez questão de recordar ao PS que não tem maioria absoluta. Jerónimo de Sousa também comentou os “desabafos” do presidente da República, que desvalorizou a tensão à esquerda - e recusou “pressões” sobre o PCP, que não passa “cheques em branco”", Texto = "Bloco de Esquerda admitiu este sábado que as negociações com o Governo para o próximo Orçamento do Estado serão mais tensas, lembrando o Partido Socialista de que não governa com maioria absoluta.", Titulo = "BE admite que negociações para o OE estão mais tensas, Jerónimo recusa “pressões", Data = new DateTime(2031, 6, 9), CategoriaFK = 2, JornalistaFK = 1 },
                   new Models.Noticias() { NoticiasID = 2, Resumo = "Os sindicatos afetos à CGTP reuniram-se nas ruas de Lisboa para carregar o tom no mesmo dia em que Jerónimo de Sousa assumiu que o ambiente das negociações para o próximo Orçamento está “toldado”. Houve gritos contra o ministro da Educação e ficou combinada nova concentração, frente ao Parlamento e contra os “negócios” de Costa com os patrões. “Lá estaremos”, prometeram", Texto = "Á porta da pastelaria Coringa, por onde passa quem desce a Avenida Fontes Pereira de Melo quase a chegar ao Marquês de Pombal, o rebuliço é pouco habitual. Saem pastéis de massa tenra, croquetes e, sobretudo, cervejas - imperiais ou finos, porque o evento que traz tanta gente ali é nacional - a uma velocidade notável. Já passa das 17h40, a concentração da CGTP terminou e os manifestantes aproveitam para lanchar antes do regresso a casa.", Titulo ="Ó Tiago, ó Costa”, a luta veio para ficar", Data = new DateTime(2031, 6, 9), CategoriaFK = 2, JornalistaFK = 2 },
                   new Models.Noticias() { NoticiasID = 3, Resumo = "O Presidente da República desvaloriza o “ambiente toldado” à esquerda - como Jerónimo de Sousa descreveu ao Expresso - e diz que os partidos têm “bom senso” para não criarem complicações “cá dentro”, quando há tantas “complicações” na Europa", Texto = "Marcelo Rebelo de Sousa não fez um apelo, mas quase. Foi mais uma constatação com misto de chamamento dos partidos ao bom senso, dando a entender que a esquerda não vai chumbar o Orçamento do Estado (OE) para 2019. Tudo para que Portugal não contribua para avolumar as crises políticas que grassam na Europa, casos de Espanha e de Itália. Na manhã deste sábado, em Ponta Delgada, nos Açores – onde se prepara para presidir às comemorações do 10 de junho –, o Presidente da República foi confrontado pelos jornalistas com os sinais de crise à esquerda que podem pôr o OE em perigo: Não, penso que não está em perigo, respondeu Marcelo.", Titulo = "Marcelo: “Bom - senso faz com que não haja crise orçamental a temer", Data = new DateTime(2031, 6, 9), CategoriaFK = 2, JornalistaFK = 3 },
                   new Models.Noticias() { NoticiasID = 4, Resumo = "s manifestantes vão desfilar, ao início da tarde, entre o Campo Pequeno e o Marquês de Pombal. Lutar Pelos Direitos, Valorizar Os Trabalhadores!, será o lema do protesto", Texto = "Milhares de trabalhadores de todo o país deslocam-se hoje a Lisboa para participar na manifestação nacional da CGTP contra a política laboral e em defesa da valorização do trabalho e dos trabalhadores.", Titulo = "Milhares de trabalhadores participam na manifestação nacional da CGTPM", Data = new DateTime(2031, 6, 9), CategoriaFK = 2, JornalistaFK = 4 }
                   );

            context.SaveChanges();
        }
    }
}
