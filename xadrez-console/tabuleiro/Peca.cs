namespace xadrez_console.Tabuleiro;

abstract class Peca(Tabuleiros tab, Cor cor)
{
    #region Campos

    public Posicao? Posicao { get; set; } = null;
    public Cor Cor { get; protected set; } = cor;
    public int QtdMovimentos { get; protected set; } = 0;
    public Tabuleiros Tab { get; protected set; } = tab;

    #endregion

    #region Metodos

    public abstract bool[,] MovimentosPossiveis();

    public bool MovimentoPossivel(Posicao pos) => MovimentosPossiveis()[pos.Linha, pos.Coluna];

    public bool ExistemMovimentosPossiveis()
    {
        bool[,] mat = MovimentosPossiveis();
        for (int i = 0; i < Tab.Linhas; i++)
        {
            for (int j = 0; j < Tab.Colunas; j++)
            {
                if (mat[i, j])
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void IncrementarQtdMovimentos() => QtdMovimentos++;

    public void DecrementarQtdMovimentos() => QtdMovimentos--;

    #endregion
}
