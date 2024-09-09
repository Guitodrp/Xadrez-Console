namespace xadrez_console.Tabuleiro;

class Peca
{
    public Posicao? Posicao { get; set; }
    public Cor Cor { get; protected set; }
    public int QtdMovimentos { get; protected set; }
    public Tabuleiros Tab { get; protected set; }

    public Peca(Tabuleiros tab, Cor cor)
    {
        this.Posicao = null;
        this.Cor = cor;
        this.QtdMovimentos = 0;
        this.Tab = tab;
    }

    public void IncrementarQtdMovimentos()
    {
        QtdMovimentos++;
    }
}
