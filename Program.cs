using System;
using DIO.Series.Classes;
using DIO.Series.Enum;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            String opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;  
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        ListarSerieOrdenada();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Desculpe, o código inserido não consta nas opções.");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static void ListarSerieOrdenada()
        {
            Console.WriteLine("Listar séries Ordenada");

            var lista = repositorio.SortList();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach(var serie in lista){
                // Só quero retornar as que não tenham sido excluídas
                if(!serie.retornaExcluido()){
                    Console.WriteLine($"#ID-{serie.retornaId()} -- Série: {serie.retornaTitulo()} -- Rating: {serie.retornaRating()}");
                }
                
            }
        }

        private static void ExcluirSerie()
        {
            int indiceSerie = SelecionaIdSerie();
            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            int indiceSerie = SelecionaIdSerie();
            var serie = repositorio.RetornaPorID(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            int indiceSerie = SelecionaIdSerie();

            EntradaSerie(out int entradaGenero, out string entradaTitulo, out int entradaAno, 
                            out string entradaDescricao, out double entradaRating);

            Serie novaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno,
                                        rating: entradaRating);
            
            repositorio.Atualiza(indiceSerie, novaSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            
            EntradaSerie(out int entradaGenero, out string entradaTitulo, out int entradaAno, 
                            out string entradaDescricao, out double entradaRating);
            

            Serie novaSerie = new Serie(id: repositorio.ProximoID(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno,
                                        rating: entradaRating);
            
            repositorio.Insere(novaSerie);
            
        }

        private static void EntradaSerie(out int entradaGenero,
                                         out string entradaTitulo,
                                         out int entradaAno,
                                         out string entradaDescricao,
                                         out double entradaRating)
        {
            foreach(int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {System.Enum.GetName(typeof(Genero), i)}");
            }
            Console.Write("Digite o valor referente ao genêro entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de ínicio da série: ");
            entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            entradaDescricao = Console.ReadLine();

            Console.Write("Digite sua avaliação da série: ");
            entradaRating = double.Parse(Console.ReadLine());
            
        }

        private static int SelecionaIdSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            return indiceSerie;        
        }
        
        private static void ListarSerie()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach(var serie in lista){
                // Só quero retornar as que não tenham sido excluídas
                if(!serie.retornaExcluido()){
                    Console.WriteLine($"#ID-{serie.retornaId()} -- Série: {serie.retornaTitulo()}");
                }
                
            }
        }

        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir uma nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("6- Listar Séries por Rating");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
