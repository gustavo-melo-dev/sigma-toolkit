using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaToolkit.Modulos
{
    internal static class ClassificadorProblemas
    {
        // Cache JsonSerializerOptions (CA1869)
        private static readonly System.Text.Json.JsonSerializerOptions s_jsonOptions =
            new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public static void Rodar()
        {
            FuncoesAuxiliares.LimparTela();
            Console.WriteLine("Classificador T/I/N por JSON");
            Console.WriteLine("Digite T (tratável), I (intratável) ou N (não computável) para cada item.");

            var itens = CarregarItens();
            int acertos = 0;
            int erros = 0;
            var resultados = new List<string>();

            for (int i = 0; i < itens.Count; i++)
            {
                var item = itens[i];
                Console.WriteLine();
                Console.WriteLine($"Item {i + 1}/{itens.Count}");
                Console.WriteLine($"Descricao: {item.Descricao}");

                char resposta = LerClassificacaoUsuario();
                bool acertou = Normalizar(resposta) == Normalizar(item.Correta);
                if (acertou)
                {
                    acertos++;
                }
                else
                {
                    erros++;
                }

                resultados.Add($"{i + 1}. {(acertou ? "Acertou" : "Errou")} - {item.Descricao} (sua: {char.ToUpperInvariant(resposta)}, correta: {char.ToUpperInvariant(item.Correta)})");
            }

            Console.WriteLine();
            Console.WriteLine("Resultados por item");
            foreach (var linha in resultados)
            {
                Console.WriteLine(linha);
            }

            Console.WriteLine();
            Console.WriteLine("Resumo");
            Console.WriteLine($"Total: {itens.Count} | Acertos: {acertos} | Erros: {erros}");

            Console.WriteLine();
            Console.Write("Aperte para Continuar...");
            Console.ReadLine();
        }

        private static List<ItemProblema> CarregarItens()
        {
            // Lista embutida em JSON
            string json = @"[
                { ""descricao"": ""Soma de dois inteiros"", ""correta"": ""T"" },
                { ""descricao"": ""Problema do Caixeiro Viajante (otimização exata)"", ""correta"": ""I"" },
                { ""descricao"": ""Parada de um programa arbitrário (Halting Problem)"", ""correta"": ""N"" },
                { ""descricao"": ""Ordenar uma lista"", ""correta"": ""T"" },
                { ""descricao"": ""SAT (satisfatibilidade booleana)"", ""correta"": ""I"" }
            ]";

            try
            {
                var itens = System.Text.Json.JsonSerializer.Deserialize<List<ItemProblema>>(
                    json,
                    s_jsonOptions
                );
                return itens ?? [];
            }
            catch
            {
                return [];
            }
        }

        private static char LerClassificacaoUsuario()
        {
            while (true)
            {
                Console.Write("Classificação (T/I/N): ");
                string? texto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(texto))
                {
                    char c = char.ToUpperInvariant(texto.Trim()[0]);
                    if (c == 'T' || c == 'I' || c == 'N')
                    {
                        return c;
                    }
                }
                Console.WriteLine("Entrada inválida. Digite T, I ou N.");
            }
        }

        private static char Normalizar(char c) => char.ToUpperInvariant(c);

        private class ItemProblema
        {
            public string Descricao { get; set; } = string.Empty;
            public char Correta { get; set; }
        }
    }
}
