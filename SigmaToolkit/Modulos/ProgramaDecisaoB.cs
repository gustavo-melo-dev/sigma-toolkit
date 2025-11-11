using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SigmaToolkit.Modulos
{
    internal static class ProgramaDecisaoB
    {
        public static void Rodar()
        {
            FuncoesAuxiliares.LimparTela();
            String? cadeia = FuncoesAuxiliares.LerCadeia();
            if (cadeia == null || cadeia.Length == 0)
            {
                Console.WriteLine("CADEIA VAZIA");
            }
            else if (cadeia.EndsWith('b'))
            {
                Console.WriteLine("SIM");
            }
            else
            {
                Console.WriteLine("NAO");
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            FuncoesAuxiliares.LimparTela();
        }
    }
}
