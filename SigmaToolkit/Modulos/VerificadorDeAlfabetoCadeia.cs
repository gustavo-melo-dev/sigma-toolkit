using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaToolkit.Modulos
{
    internal static class VerificadorDeAlfabetoCadeia
    {
        public static void Rodar()
        {
            FuncoesAuxiliares.LimparTela();

            char[] alfabeto = ['a', 'b'];

            Console.WriteLine();
            Console.WriteLine("Verificador de alfabeto e cadeia (Σ = { a, b })");

            Console.WriteLine();
            Console.WriteLine("--- Verificação de símbolo ---");
            Console.Write("Digite um símbolo: ");
            string simbolo = Console.ReadLine() ?? string.Empty;

            Console.WriteLine();
            Console.WriteLine("--- Verificação de cadeia ---");
            Console.Write("Digite uma cadeia: ");
            string cadeia = Console.ReadLine() ?? string.Empty;

            Console.WriteLine();
            Console.WriteLine("--- Resultado ---");

            if (FuncoesAuxiliares.VerificarSeOSimboloFazParteDoAlfabeto(simbolo, alfabeto))
            {
                Console.WriteLine("Símbolo válido: pertence a Σ.");
            }
            else
            {
                Console.WriteLine("Símbolo inválido: não pertence a Σ.");
            }

            int primeiraPosicaoInvalida = FuncoesAuxiliares.EncontrarSimboloNaCadeiaQueNaoPertenceALinguagem(cadeia, alfabeto);
            if (primeiraPosicaoInvalida < 0)
            {
                Console.WriteLine("Cadeia válida: pertence a Σ*.");
            }
            else
            {
                char invalido = cadeia[primeiraPosicaoInvalida];
                Console.WriteLine($"Cadeia inválida: símbolo '{invalido}' fora de Σ na posição {primeiraPosicaoInvalida + 1}.");
            }

            Console.WriteLine();
            Console.Write("Aperte para Continuar...");
            Console.ReadLine();
        }
    }
}
