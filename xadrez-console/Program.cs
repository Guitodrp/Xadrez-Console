using xadrez_console.Tabuleiro.Xadrez;

namespace xadrez_console;

class Program
{
    static void Main(string[] args)
    {
        PosicaoXadrez pos = new('a', 1);
        PosicaoXadrez pos2 = new('c', 7);

        Console.WriteLine(pos);
        Console.WriteLine(pos.ToPosicao());
        Console.WriteLine(pos2.ToPosicao());
        //try
        //{
        //    Tabuleiros tab = new(8, 8);

        //    tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
        //    tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
        //    tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));
        //    tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));

        //    Tela.ImprimirTabuleiro(tab);
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine(e.Message);
        //}
    }
}