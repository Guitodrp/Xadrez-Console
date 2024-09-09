namespace xadrez_console.Tabuleiro;

class Torre : Peca
{
    public Torre(Tabuleiros tab, Cor cor) : base(tab, cor)
    {

    }

    public override string ToString()
    {
        return "T";
    }
}
