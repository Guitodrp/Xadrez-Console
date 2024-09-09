using xadrez_console.Tabuleiro.Xadrez;
using xadrez_console.Tabuleiro;

namespace xadrez_console;

class Program
{
    static void Main(string[] args)
    {
        //PosicaoXadrez pos = new('a', 1);
        //PosicaoXadrez pos2 = new('c', 7);

        //Console.WriteLine(pos);
        //Console.WriteLine(pos.ToPosicao());
        //Console.WriteLine(pos2.ToPosicao());

        try
        {
            PartidaXadrez partida = new();

            Tela.ImprimirTabuleiro(partida.Tab);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}