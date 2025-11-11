using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaToolkit
{
    public static class FuncoesAuxiliares
    {
        public static int LerOpcaoDoMenu(int valorMinimo, int valorMaximo)
        {
            while (true)
            {
                Console.Write("Opcao: ");
                string? textoDigitado = Console.ReadLine();
                if (int.TryParse(textoDigitado, out int valorLido))
                {
                    if (valorLido >= valorMinimo && valorLido <= valorMaximo)
                    {
                        return valorLido;
                    }
                }
                Console.WriteLine("Opcao invalida. Tente novamente.");
            }
        }

        public static bool VerificarSeOSimboloFazParteDoAlfabeto(string simbolo, char[] alfabeto)
        {
            if (string.IsNullOrEmpty(simbolo))
                return false;

            simbolo = simbolo.Trim();
            if (simbolo.Length != 1)
                return false;

            return alfabeto.Contains(simbolo[0]);
        }

        public static int EncontrarSimboloNaCadeiaQueNaoPertenceALinguagem(string cadeia, char[] alfabeto)
        {
            if (string.IsNullOrEmpty(cadeia)) return -1;

            for (int i = 0; i < cadeia.Length; i++)
            {
                if (!alfabeto.Contains(cadeia[i]))
                    return i;
            }

            return -1;
        }

        public static string LerCadeia()
        {
            while (true)
            {
                Console.Write("Cadeia: ");
                string? textoDigitado = Console.ReadLine();
                if (textoDigitado != null)
                {
                    return textoDigitado;
                }
                Console.WriteLine("Entrada invalida. Tente novamente.");
            }
        }

        public static void LimparTela()
        {
            Console.Clear();
        }
    }
}
