using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SigmaToolkit.Modulos
{
    internal class EstadoProcesso
    {
        public int Valor { get; set; }
        public int Passo { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is EstadoProcesso outro)
            {
                return Valor == outro.Valor;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Valor.GetHashCode();
        }
    }

    internal static class DetectorDeLoop
    {
        public static void Rodar()
        {
            FuncoesAuxiliares.LimparTela();

            Console.WriteLine();
            Console.WriteLine("Detector Ingênuo de Loop");
            Console.WriteLine();
            Console.WriteLine("Simula processo discreto: divisão sucessiva por 2 até atingir 1");
            Console.WriteLine("Se ímpar, multiplica por 3 e soma 1 (conjectura de Collatz)");
            Console.WriteLine();

            Console.Write("Digite o valor inicial (número inteiro positivo): ");
            string entradaValor = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(entradaValor, out int valorInicial) || valorInicial <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("Entrada inválida: digite um número inteiro positivo.");
                Console.WriteLine();
                Console.Write("Aperte para Continuar...");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o limite máximo de passos: ");
            string entradaLimite = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(entradaLimite, out int limitePassos) || limitePassos <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("Entrada inválida: digite um número inteiro positivo.");
                Console.WriteLine();
                Console.Write("Aperte para Continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("--- Simulação ---");

            bool loopDetectado = ExecutarProcessoComDeteccao(valorInicial, limitePassos);

            Console.WriteLine();
            Console.WriteLine("--- Resultado ---");

            if (loopDetectado)
            {
                Console.WriteLine("LOOP DETECTADO: estado repetido encontrado.");
            }
            else
            {
                Console.WriteLine("Processo concluído ou limite atingido sem loop detectado.");
            }

            Console.WriteLine();
            Console.WriteLine("--- Reflexão ---");
            Console.WriteLine("Falsos positivos: estados distintos com mesmo valor podem parecer loop.");
            Console.WriteLine("Falsos negativos: loops além do limite não são detectados.");
            Console.WriteLine("Limitação: heurística simples, compara apenas valores numéricos.");

            Console.WriteLine();
            Console.Write("Aperte para Continuar...");
            Console.ReadLine();
        }

        // Executa processo discreto com detecção de loop
        private static bool ExecutarProcessoComDeteccao(int valorInicial, int limitePassos)
        {
            HashSet<int> estadosVisitados = new HashSet<int>();
            int valorAtual = valorInicial;
            int passo = 0;

            Console.WriteLine($"Passo {passo}: valor = {valorAtual}");
            estadosVisitados.Add(valorAtual);

            while (passo < limitePassos)
            {
                passo++;

                // Condição de parada: atingiu 1
                if (valorAtual == 1)
                {
                    Console.WriteLine($"Passo {passo}: processo concluído (atingiu 1).");
                    return false;
                }

                // Aplica regra de Collatz
                if (valorAtual % 2 == 0)
                {
                    valorAtual = valorAtual / 2;
                }
                else
                {
                    valorAtual = valorAtual * 3 + 1;
                }

                Console.WriteLine($"Passo {passo}: valor = {valorAtual}");

                // Verifica se estado já foi visitado
                if (estadosVisitados.Contains(valorAtual))
                {
                    Console.WriteLine($"Estado {valorAtual} já visitado! Loop detectado.");
                    return true;
                }

                estadosVisitados.Add(valorAtual);
            }

            Console.WriteLine($"Limite de {limitePassos} passos atingido.");
            return false;
        }
    }
}
