using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SigmaToolkit.Modulos
{
    internal class ClassificadorProblemaInstancia
    {
        // Cache JsonSerializerOptions
        private static readonly JsonSerializerOptions s_jsonOptions =
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public static void Rodar()
        {
            FuncoesAuxiliares.LimparTela();
            Console.WriteLine("Classificador Problema x Instância por JSON");
            Console.WriteLine("Digite P (problema) ou I (instância) para cada item.");

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

            Console.WriteLine("\nResultados por item");
            foreach (var linha in resultados)
            {
                Console.WriteLine(linha);
            }

            Console.WriteLine("\nResumo");
            Console.WriteLine($"Total: {itens.Count} | Acertos: {acertos} | Erros: {erros}");

            Console.Write("\nAperte ENTER para Continuar...\n");
            Console.ReadLine();
            FuncoesAuxiliares.LimparTela();
        }

        private static List<ItemProblemaInstancia> CarregarItens()
        {
            string json = @"[
                { ""descricao"": ""Encontrar um caminho mínimo em um grafo"", ""correta"": ""P"" },
                { ""descricao"": ""Dado o grafo G e vértices A e B, existe um caminho de custo ≤ 10?"", ""correta"": ""I"" },
                { ""descricao"": ""Verificar se um número é primo"", ""correta"": ""P"" },
                { ""descricao"": ""O número 97 é primo?"", ""correta"": ""I"" },
                { ""descricao"": ""Coloração de grafos com 3 cores"", ""correta"": ""P"" },
                { ""descricao"": ""O grafo X pode ser colorido com 3 cores?"", ""correta"": ""I"" }
            ]";

            try
            {
                var itens = JsonSerializer.Deserialize<List<ItemProblemaInstancia>>(
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
            while(true)
            {
                Console.Write("Classificação (P/I): ");
                string? texto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(texto))
                {
                    char c = char.ToUpperInvariant(texto.Trim()[0]);
                    if ( c == 'P' || c == 'I')
                    {
                        return c;
                    }
                }
                Console.WriteLine("Entrada inválida. Digite P ou I.");
            }
        }

        private static char Normalizar(char c) => char.ToUpperInvariant(c);

        private class ItemProblemaInstancia
        {
            public string Descricao { get; set; } = string.Empty;
            public char Correta { get; set;  }
        }
    }
}
