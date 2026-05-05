using SistemaAcademico.Model;

namespace SistemaAcademico
{
    internal class Program
    {
        static List<Estudante> estudantes = new List<Estudante>();
        static List<Docente> docentes = new List<Docente>();
        static List<UnidadeCurricular> ucs = new List<UnidadeCurricular>();
        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.WriteLine("\n===== SISTEMA DA UNIVERSIDADE =====");
                Console.WriteLine("1 - CADASTRAR ESTUDANTE");
                Console.WriteLine("2 - CADASTRAR DOCENTE");
                Console.WriteLine("3 - CRIAR UNIDADE CURRICULAR");
                Console.WriteLine("4 - INSCREVER ESTUDANTE");
                Console.WriteLine("5 - ADICIONAR AVALIAÇÕES");
                Console.WriteLine("6 - EMITIR PAUTA");
                Console.WriteLine("0 - SAIR");

                Console.Write("OPÇÃO: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: CadastrarEstudante(); break;
                    case 2: CadastrarDocente(); break;
                    case 3: CriarUC(); break;
                    case 4: InscreverEstudante(); break;
                    case 5: AdicionarAvaliacao(); break;
                    case 6: EmitirPauta(); break;
                }

            } while (opcao != 0);
        }

        static void CadastrarEstudante()
        {
            Console.Clear();

            Console.Write("NOME: ");
            string nome = Console.ReadLine();

            Console.Write("IDADE: ");
            int idade = int.Parse(Console.ReadLine());

            Console.Write("NÚMERO: ");
            int numero = int.Parse(Console.ReadLine());

            estudantes.Add(new Estudante(nome, idade, numero));
            Console.WriteLine("ESTUDANTE CADASTRADO COM SUCESSO!!");

            Console.WriteLine("\nCLICA EM QUALQUER TECLA...");
            Console.ReadKey();
            Console.Clear();
        }

        static void CadastrarDocente()
        {
            Console.Clear();

            Console.Write("NOME: ");
            string nome = Console.ReadLine();

            Console.Write("IDADE: ");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("1 - TITULAR | 2 - ASSISTENTE");
            int tipo = int.Parse(Console.ReadLine());

            if (tipo == 1)
                docentes.Add(new Titular(nome, idade));
            else
                docentes.Add(new Assistente(nome, idade));

            Console.WriteLine("DOCENTE CADASTRADO!!");

            Console.WriteLine("\n CLICA EM QUALQUER TECLA...");
            Console.ReadKey();
            Console.Clear();
        }

        static void CriarUC()
        {
            Console.Clear();

            Console.Write("NOME: ");
            string nome = Console.ReadLine();

            ucs.Add(new UnidadeCurricular(nome));
            Console.WriteLine("UNIDADE CURRICULAR CRIADA COM SUCESOO!!");

            Console.WriteLine("\n CLICA EM ALGUMA TECLA...");
            Console.ReadKey();
            Console.Clear();
        }

        static void InscreverEstudante()
        {
            Console.Clear();

            if (ucs.Count == 0 || estudantes.Count == 0)
            {
                Console.WriteLine("CADASTAR UNIDADE CURRICULAR E ESTUDANTE PRIMEIROo.");
                return;
            }

            Console.WriteLine("\n ESCOLHA UMA UNIDADE CURRICULAR:");
            for (int i = 0; i < ucs.Count; i++)
                Console.WriteLine($"{i} - {ucs[i].Nome}");

            int ucIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("\nESCOLHA ESTUDANTE:");
            for (int i = 0; i < estudantes.Count; i++)
                Console.WriteLine($"{i} - {estudantes[i].Nome}");

            int estIndex = int.Parse(Console.ReadLine());

            ucs[ucIndex].Estudantes.Add(estudantes[estIndex]);

            Console.WriteLine("ESTUDANTE INSCRITO!!");

            Console.WriteLine("\n CLICA EM QUALQUER TECLA...");
            Console.ReadKey();
            Console.Clear();
        }

        static void AdicionarAvaliacao()
        {
            Console.Clear();

            if (ucs.Count == 0)
            {
                Console.WriteLine("CRIAR UMA UNIDADE CURRICULAR PRIMEIRO");
                return;
            }

            Console.WriteLine("\nESCOLHA A UNIDADE CURRICULAR:");
            for (int i = 0; i < ucs.Count; i++)
                Console.WriteLine($"{i} - {ucs[i].Nome}");

            int ucIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("1 - TESTE | 2 - PROJECTO | 3 - EXAME");
            int tipo = int.Parse(Console.ReadLine());

            Console.Write("NOTA: ");
            double nota = double.Parse(Console.ReadLine());

            switch (tipo)
            {
                case 1:
                    ucs[ucIndex].Avaliacoes.Add(new Teste(nota));
                    break;
                case 2:
                    ucs[ucIndex].Avaliacoes.Add(new Projecto(nota));
                    break;
                case 3:
                    ucs[ucIndex].Avaliacoes.Add(new ExameFinal(nota));
                    break;
            }

            Console.WriteLine("AVALIAÇÃO ADICIONADA!");

            Console.WriteLine("\nCLICA EM QUALQUER TECLA...");
            Console.ReadKey();
            Console.Clear();
        }

        static void EmitirPauta()
        {
            Console.Clear();

            if (ucs.Count == 0)
            {
                Console.WriteLine("NENHUMA UNIDADE CURRICULAR DISPONIVEL.");
                return;
            }

            Console.WriteLine("\nESCOLHA UNIDADE CURRICULAR:");
            for (int i = 0; i < ucs.Count; i++)
                Console.WriteLine($"{i} - {ucs[i].Nome}");

            int ucIndex = int.Parse(Console.ReadLine());

            ucs[ucIndex].EmitirPauta();

            Console.WriteLine("\n PRESSIONE QUALQUER TECLA...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
