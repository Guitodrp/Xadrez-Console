namespace xadrez_console.Tabuleiro.Xadrez;

class PosicaoXadrez(char coluna, int linha)
{
    #region Campos

    public char Coluna { get; set; } = coluna;
    public int Linha { get; set; } = linha;

    #endregion

    #region Metodos

    public override string ToString()
    {
        return "" + Coluna + Linha;
    }

    public Posicao ToPosicao()
    {
        return new Posicao(8 - Linha, Coluna - 'a');
    }

    #endregion
}
