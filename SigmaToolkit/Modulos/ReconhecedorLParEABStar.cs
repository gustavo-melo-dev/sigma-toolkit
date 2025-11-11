using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaToolkit.Modulos
{
    internal static class ReconhecedorLParEABStar
    {
        public static void Rodar()
        {
            FuncoesAuxiliares.LimparTela();
            Console.WriteLine("1) L_par_a");
            Console.WriteLine("2) L = ab*");
            switch (FuncoesAuxiliares.LerOpcaoDoMenu(1, 2))
            {
                case 1:
                    FuncoesAuxiliares.LimparTela();
                    AvaliadorProposicionalLParA();
                    FuncoesAuxiliares.LimparTela();
                    break;
                case 2:
                    FuncoesAuxiliares.LimparTela();
                    AvaliadorProposicionalABStar();
                    FuncoesAuxiliares.LimparTela();
                    break;
            }

        }

        /// <summary>
        /// dada a cadeia w, avaliar se w pertence a L sendo que L = { w | w tem numero par de 'a's } com alfabeto {a,b}
        /// ou seja, w deve ter numero par de 'a's
        /// </summary>
        private static void AvaliadorProposicionalLParA()
        {
            char[] alfabeto = { 'a', 'b' };
            var cadeia = FuncoesAuxiliares.LerCadeia().ToLower();

            bool cadeiaEhValida = FuncoesAuxiliares.EncontrarSimboloNaCadeiaQueNaoPertenceALinguagem(cadeia, alfabeto) == -1;
            bool contagemEhPar = cadeia.Count(c => c == 'a') % 2 == 0;

            string mensagem = cadeiaEhValida && contagemEhPar ? "ACEITA" : "REJEITA";
            
            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ReadLine();
        }

        /// <summary>
        /// dada a cadeia w, avaliar se w pertence a L sendo que L = { w | w = ab* } com alfabeto {a,b}
        /// ou seja, w deve começar com 'a' e depois ter zero ou mais 'b's
        /// </summary>
        private static void AvaliadorProposicionalABStar()
        {
            char[] alfabeto = { 'a', 'b' };
            var cadeia = FuncoesAuxiliares.LerCadeia().ToLower();

            bool cadeiaEhValida = FuncoesAuxiliares.EncontrarSimboloNaCadeiaQueNaoPertenceALinguagem(cadeia, alfabeto) == -1;
            bool cadeiaComecaComA = cadeia.StartsWith('a');
            bool cadeiaTemZeroOuMaisB = cadeia.Skip(1).All(c => c == 'b');

            string mensagem = cadeiaEhValida && cadeiaComecaComA && cadeiaTemZeroOuMaisB ? "ACEITA" : "REJEITA";
            
            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ReadLine();
        }
    }
}
