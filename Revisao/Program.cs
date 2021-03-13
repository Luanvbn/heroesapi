using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];   
            var i= 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do Aluno:");

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
                            aluno.Nota = nota;
                        } else{
                            throw new ArgumentOutOfRangeException();
                        }
                        alunos[i] = aluno;
                        i++;
                        break;
                    case "2":
                        foreach(var a in alunos){
                            if(!string.IsNullOrEmpty(a.Nome)){
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                        }

                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for(int indice = 0; indice < alunos.Length; indice++){
                            if(!string.IsNullOrEmpty(alunos[indice].Nome)){
                                notaTotal += alunos[indice].Nota;
                                nrAlunos ++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Console.WriteLine($"Media: {mediaGeral}");

                        break;
                    default:

                        throw new ArgumentException("Valor da Nota deve ser Decimal");
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static String ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir Aluno");
            Console.WriteLine("2- Listar Alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X - Sair");

            Console.WriteLine("");
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine("");
            return opcaoUsuario;
        }
    }


}
