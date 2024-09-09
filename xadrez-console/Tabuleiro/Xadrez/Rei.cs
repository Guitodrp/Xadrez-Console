namespace xadrez_console.Tabuleiro;

class Rei : Peca
{
    public Rei(Tabuleiros tab, Cor cor) : base(tab, cor)
    {

    }

    public override string ToString() {
        return "R";
    }
}
