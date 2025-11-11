using SigmaToolkit.Modulos;

namespace SigmaToolkit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Sigma Toolkit");
                Console.WriteLine("---- AV1 ----");
                Console.WriteLine("1) Verificar alfabeto e cadeia (Sigma={ a,b})");
                Console.WriteLine("2) Classificador T/I/N por JSON");
                Console.WriteLine("3) Decisor: termina com 'b'?");
                Console.WriteLine("4) Avaliador proposicional (P,Q,R)");
                Console.WriteLine("5) Reconhecedor: L_par_a e a b*");
                //Console.WriteLine("---- AV2 ----");
                //Console.WriteLine("6) Problema x instancia por JSON");
                //Console.WriteLine("7) Decisores: L_fim_b e L_mult3_b");
                //Console.WriteLine("8) Reconhecedor que pode nao terminar (a^i b ^ i)");
                //Console.WriteLine("9) Detector ingenuo de loop");
                //Console.WriteLine("10) Simulador AFD simples (termina com 'b')");
                Console.WriteLine("0) Sair");
                switch (FuncoesAuxiliares.LerOpcaoDoMenu(0, 10))
                {
                    case 0:
                        return;
                    case 1:
                        VerificadorDeAlfabetoCadeia.Rodar();
                        break;
                    case 2:
                        ClassificadorProblemas.Rodar();
                        break;
                    case 3:
                        ProgramaDecisaoB.Rodar();
                        break;
                    case 4:
                        AvaliadorProposicionalBasico.Rodar();
                        break;
                    case 5:
                        ReconhecedorLParEABStar.Rodar();
                        break;
                }
                FuncoesAuxiliares.LimparTela();
            }
        }
    }
}