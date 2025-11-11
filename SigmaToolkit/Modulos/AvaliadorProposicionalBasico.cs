using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaToolkit.Modulos
{
    internal static class AvaliadorProposicionalBasico
    {
        public static void Rodar()
        {
            FuncoesAuxiliares.LimparTela();
            Console.WriteLine("\nDigite a fórmula usando P, Q, R, operadores & (AND), | (OR), ! (NOT), -> (IMPLICAÇÃO):");
            string? formula = Console.ReadLine().Replace(" ", "");

            if (string.IsNullOrEmpty(formula))
            {
                FuncoesAuxiliares.LimparTela();
                Console.WriteLine("Fórmula inválida.");
                return;
            }
            if (!formula.All(c => "PQR&|!->()01".Contains(c) || char.IsWhiteSpace(c)))
            {
                FuncoesAuxiliares.LimparTela();
                Console.WriteLine("Fórmula contém caracteres inválidos.");
                return;
            }

            Console.WriteLine("Deseja gerar tabela-verdade? (S/N):");
            string? escolha = Console.ReadLine().ToUpper();

            if (escolha == "S")
            {
                GerarTabelaVerdade(formula);
            }
            else
            {
                bool P = LerValor("P");
                bool Q = LerValor("Q");
                bool R = LerValor("R");

                bool resultado = Avaliar(formula, P, Q, R);
                Console.WriteLine($"Resultado: {(resultado ? "V" : "F")}");
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            FuncoesAuxiliares.LimparTela();
        }
        static bool LerValor(string varName)
        {
            while (true)
            {
                Console.Write($"Digite o valor de {varName} (V/F): ");
                string? input = Console.ReadLine().ToUpper();
                if (input == "V") return true;
                if (input == "F") return false;
                Console.WriteLine("Entrada inválida. Digite V ou F.");
            }
        }

        static bool Avaliar(string expr, bool P, bool Q, bool R)
        {
            // Substitui variáveis pelos valores
            expr = expr.Replace("P", P ? "1" : "0")
                       .Replace("Q", Q ? "1" : "0")
                       .Replace("R", R ? "1" : "0");

            // Avalia parênteses recursivamente
            while (expr.Contains('('))
            {
                int ultimoAbre = expr.LastIndexOf('(');
                int fecha = expr.IndexOf(')', ultimoAbre);
                string? sub = expr.Substring(ultimoAbre + 1, fecha - ultimoAbre - 1);
                bool subResult = Avaliar(sub, P, Q, R);
                expr = expr.Substring(0, ultimoAbre) + (subResult ? "1" : "0") + expr.Substring(fecha + 1);
            }

            // Avaliar NOT
            while (expr.Contains('!'))
            {
                int idx = expr.IndexOf('!');
                char prox = expr[idx + 1];
                bool valor = prox == '1';
                bool negado = !valor;
                expr = expr.Substring(0, idx) + (negado ? "1" : "0") + expr.Substring(idx + 2);
            }

            // Avaliar IMPLICAÇÃO (->)
            while (expr.Contains("->"))
            {
                int idx = expr.IndexOf("->");
                bool left = expr[idx - 1] == '1';
                bool right = expr[idx + 2] == '1';
                bool res = !left || right;
                expr = expr.Substring(0, idx - 1) + (res ? "1" : "0") + expr.Substring(idx + 3);
            }

            // Avaliar AND (&)
            while (expr.Contains('&'))
            {
                int idx = expr.IndexOf('&');
                bool left = expr[idx - 1] == '1';
                bool right = expr[idx + 1] == '1';
                bool res = left && right;
                expr = expr.Substring(0, idx - 1) + (res ? "1" : "0") + expr.Substring(idx + 2);
            }

            // Avaliar OR (|)
            while (expr.Contains('|'))
            {
                int idx = expr.IndexOf('|');
                bool left = expr[idx - 1] == '1';
                bool right = expr[idx + 1] == '1';
                bool res = left || right;
                expr = expr.Substring(0, idx - 1) + (res ? "1" : "0") + expr.Substring(idx + 2);
            }

            return expr == "1";
        }

        static void GerarTabelaVerdade(string formula)
        {
            Console.WriteLine("P\tQ\tR\tResultado");
            for (int i = 0; i < 8; i++)
            {
                bool P = (i & 4) != 0;
                bool Q = (i & 2) != 0;
                bool R = (i & 1) != 0;

                bool resultado = Avaliar(formula, P, Q, R);

                Console.WriteLine($"{(P ? "V" : "F")}\t{(Q ? "V" : "F")}\t{(R ? "V" : "F")}\t{(resultado ? "V" : "F")}");
            }
        }
    }
}
