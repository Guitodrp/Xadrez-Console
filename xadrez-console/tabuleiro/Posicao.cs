namespace xadrez_console.Tabuleiro;

class Posicao(int linha, int coluna)
{
    #region Campos

    public int Linha { get; set; } = linha;
    public int Coluna { get; set; } = coluna;

    #endregion

    #region Metodos

    public void DefinirValores(int linha, int coluna)
    {
        Linha = linha;
        Coluna = coluna;
    }

    public override string ToString()
    {
        return Linha
            + ", "
            + Coluna;
    }

    #endregion
}


