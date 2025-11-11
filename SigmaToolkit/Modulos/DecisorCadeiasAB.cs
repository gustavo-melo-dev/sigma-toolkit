using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaToolkit.Modulos
{
    internal static class DecisorCadeiasAB
    {
        public static void Rodar()
        {
            FuncoesAuxiliares.LimparTela();
            Console.WriteLine("Decisores sobre Sigma = {a, b}");
            Console.WriteLine("1) L_fim_b: Termina com 'b'?");
            Console.WriteLine("2) L_mult3_b: Número de 'b's divisível por 3?");
            Console.WriteLine("0) Voltar");

            int opcao = FuncoesAuxiliares.LerOpcaoDoMenu(0, 2);

            switch (opcao)
            {
                case 0:
                    return;
                case 1:
                    DecisorLFimB();
                    break;
                case 2:
                    DecisorLMult3B();
                    break;
            }
        }

        private static void DecisorLFimB()
        {
            FuncoesAuxiliares.LimparTela();
            Console.WriteLine("Decisor: L_fim_b (termina com 'b')");
            Console.WriteLine();

            string? cadeia = FuncoesAuxiliares.LerCadeia();

            // Verificar se a cadeia pertence ao alfabeto {a, b}
            char[] alfabeto = { 'a', 'b' };
            int posicaoInvalida = FuncoesAuxiliares.EncontrarSimboloNaCadeiaQueNaoPertenceALinguagem(cadeia, alfabeto);

            if (posicaoInvalida >= 0)
            {
                Console.WriteLine("NAO - cadeia deve conter apenas 'a' e 'b'.");
            }
            else if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("NAO - Cadeia vazia não termina com 'b'");
            }
            else if (cadeia.EndsWith('b'))
            {
                Console.WriteLine("SIM - A cadeia termina com 'b'");
            }
            else
            {
                Console.WriteLine("NAO - A cadeia não termina com 'b'");
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            FuncoesAuxiliares.LimparTela();
        }

        private static void DecisorLMult3B()
        {
            FuncoesAuxiliares.LimparTela();
            Console.WriteLine("Decisor: L_mult3_b (número de 'b's divisível por 3)");
            Console.WriteLine();

            string? cadeia = FuncoesAuxiliares.LerCadeia();

            // Verificar se a cadeia pertence ao alfabeto {a, b}
            char[] alfabeto = { 'a', 'b' };
            int posicaoInvalida = FuncoesAuxiliares.EncontrarSimboloNaCadeiaQueNaoPertenceALinguagem(cadeia, alfabeto);

            if (posicaoInvalida >= 0)
            {
                Console.WriteLine($"ERRO: Símbolo inválido '{cadeia[posicaoInvalida]}' na posição {posicaoInvalida}");
                Console.WriteLine("A cadeia deve conter apenas 'a' e 'b'.");
            }
            else
            {
                // Contar o número de 'b's na cadeia
                int numeroDeBs = 0;
                if (!string.IsNullOrEmpty(cadeia))
                {
                    foreach (char c in cadeia)
                    {
                        if (c == 'b')
                        {
                            numeroDeBs++;
                        }
                    }
                }

                Console.WriteLine($"Número de 'b's encontrados: {numeroDeBs}");

                if (numeroDeBs % 3 == 0)
                {
                    Console.WriteLine("SIM - O número de 'b's é divisível por 3");
                }
                else
                {
                    Console.WriteLine("NAO - O número de 'b's não é divisível por 3");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            FuncoesAuxiliares.LimparTela();
        }
    }
}
