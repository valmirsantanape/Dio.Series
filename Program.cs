using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {   
            
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1": 
                    listaSeries();
                    break;
                    
                    case "2":
                    InserirSerie(repositorio);
                    break;  
                    
                    case "3":
                    atualizarSerie(); 
                    
                    break;     
                    
                    case "4":
                    Excluir(); 
                    break;
                    
                    case "5":
                    visualizarSerie(); 
                    break;
                    
                    case "6":
                    Console.Clear(); 
                    break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços ");
            Console.ReadLine();

        }
        
        private static void atualizarSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#{0} - {1}", i, Enum.GetName(typeof(Genero), i));

            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao
                                        );
            repositorio.Atualizar(indiceSerie, atualizaSerie);
        
        }
        private static void listaSeries()
        {
            Console.WriteLine("Listar Série ");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada. ");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();  
                Console.WriteLine("#ID {0}: - {1} - {2}:", serie.retornaId() + 1, serie.retornaTitulo(), excluido ? "Excluido" : "");
            }

        }
        private static void InserirSerie(SerieRepositorio repositorio)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#ID {0}: - {1}:", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao
                                        );
            repositorio.Insere(novaSerie);
        
        }

        private static void visualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void Excluir()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        public static string ObterOpcaoUsuario()
        {
            
            Console.WriteLine();
            Console.WriteLine("Dio Series s seu dispor ");
            Console.WriteLine("1 -  Listar série");
            Console.WriteLine("2 - Inserir série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série ");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Limpar Tela ");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
