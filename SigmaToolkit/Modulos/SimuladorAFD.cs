using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SigmaToolkit.Modulos
{
    internal class EstadoAFD
    {
        public string Nome { get; set; } = string.Empty;
        public bool EhFinal { get; set; }
        public Dictionary<char, string> Transicoes { get; set; } = new Dictionary<char, string>();
    }

    internal class AFD
    {
        public Dictionary<string, EstadoAFD> Estados { get; set; } = new Dictionary<string, EstadoAFD>();
        public string EstadoInicial { get; set; } = string.Empty;
        public char[] Alfabeto { get; set; } = [];
    }

    internal static class SimuladorAFD
    {
        public static void Rodar()
        {
            FuncoesAuxiliares.LimparTela();

            Console.WriteLine();
            Console.WriteLine("Simulador de AFD - Σ = { a, b }");
            Console.WriteLine();
            Console.WriteLine("AFD configurado: reconhece cadeias que terminam com 'b'");
            Console.WriteLine("Estados: q0 (inicial), q1 (final)");
            Console.WriteLine("Transições:");
            Console.WriteLine("  q0 --a--> q0");
            Console.WriteLine("  q0 --b--> q1");
            Console.WriteLine("  q1 --a--> q0");
            Console.WriteLine("  q1 --b--> q1");

            AFD afd = CriarAFDTerminaComB();

            Console.WriteLine();
            Console.Write("Digite uma cadeia sobre { a, b }: ");
            string entrada = Console.ReadLine() ?? string.Empty;

            // Validação da entrada
            char[] alfabeto = ['a', 'b'];
            int posicaoInvalida = FuncoesAuxiliares.EncontrarSimboloNaCadeiaQueNaoPertenceALinguagem(entrada, alfabeto);
            if (posicaoInvalida >= 0)
            {
                Console.WriteLine();
                Console.WriteLine($"Entrada inválida: símbolo '{entrada[posicaoInvalida]}' não pertence ao alfabeto.");
                Console.WriteLine();
                Console.Write("Aperte para Continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("--- Simulação ---");

            bool aceita = SimularAFD(afd, entrada);

            Console.WriteLine();
            Console.WriteLine("--- Resultado ---");
            if (aceita)
            {
                Console.WriteLine("Cadeia ACEITA pelo AFD.");
            }
            else
            {
                Console.WriteLine("Cadeia REJEITADA pelo AFD.");
            }

            Console.WriteLine();
            Console.Write("Aperte para Continuar...");
            Console.ReadLine();
        }

        // Cria AFD que reconhece cadeias terminadas em 'b'
        private static AFD CriarAFDTerminaComB()
        {
            AFD afd = new AFD
            {
                EstadoInicial = "q0",
                Alfabeto = ['a', 'b']
            };

            // Estado q0 (inicial, não final)
            EstadoAFD q0 = new EstadoAFD
            {
                Nome = "q0",
                EhFinal = false
            };
            q0.Transicoes['a'] = "q0";
            q0.Transicoes['b'] = "q1";

            // Estado q1 (final)
            EstadoAFD q1 = new EstadoAFD
            {
                Nome = "q1",
                EhFinal = true
            };
            q1.Transicoes['a'] = "q0";
            q1.Transicoes['b'] = "q1";

            afd.Estados["q0"] = q0;
            afd.Estados["q1"] = q1;

            return afd;
        }

        // Simula a execução do AFD sobre a entrada
        private static bool SimularAFD(AFD afd, string entrada)
        {
            string estadoAtual = afd.EstadoInicial;
            Console.WriteLine($"Estado inicial: {estadoAtual}\n");

            // Processa cadeia vazia
            if (entrada.Length == 0)
            {
                Console.WriteLine("Cadeia vazia (ε)");
                return afd.Estados[estadoAtual].EhFinal;
            }

            // Processa cada símbolo
            for (int i = 0; i < entrada.Length; i++)
            {
                char simbolo = entrada[i];
                EstadoAFD estado = afd.Estados[estadoAtual];

                if (!estado.Transicoes.ContainsKey(simbolo))
                {
                    Console.WriteLine($"Erro: sem transição para '{simbolo}' no estado {estadoAtual}");
                    return false;
                }

                string proximoEstado = estado.Transicoes[simbolo];
                Console.WriteLine($"  δ({estadoAtual}, '{simbolo}') = {proximoEstado}");
                estadoAtual = proximoEstado;
            }

            Console.WriteLine($"\nEstado final: {estadoAtual}");
            return afd.Estados[estadoAtual].EhFinal;
        }
    }
}
