namespace xadrez_console.Tabuleiro;

abstract class Peca(Tabuleiros tab, Cor cor)
{
    public Posicao? Posicao { get; set; } = null;
    public Cor Cor { get; protected set; } = cor;
    public int QtdMovimentos { get; protected set; } = 0;
    public Tabuleiros Tab { get; protected set; } = tab;

    public void IncrementarQtdMovimentos() => QtdMovimentos++;

    public bool ExistemMovimentosPossiveis()
    {
        bool[,] mat = MovimentosPossiveis();
        for (int i = 0; i < Tab.Linhas; i++)
        {
            for (int j = 0; j < Tab.Colunas; j++)
            {
                if (mat[i, j]) { 
                    return true;
                }
            }
        }
        return false;
    }

    public abstract bool[,] MovimentosPossiveis();

}
