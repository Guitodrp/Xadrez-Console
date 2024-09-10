using xadrez_console.Tabuleiro.Xadrez;
using xadrez_console.Tabuleiro;

namespace xadrez_console;

class Program
{
    static void Main(string[] args)
    {

        try
        {
            PartidaXadrez partida = new();

            while (!partida.Terminada)
            {
                Console.Clear();
                Tela.ImprimirTabuleiro(partida.Tab);

                Console.WriteLine();
                Console.Write("Origem: ");
                Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                Console.Clear();
                Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                Console.WriteLine();
                Console.Write("Destino: ");
                Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                partida.ExecutaMovimento(origem, destino);
            }

            Tela.ImprimirTabuleiro(partida.Tab);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}