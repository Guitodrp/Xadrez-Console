namespace xadrez_console.Tabuleiro.Xadrez;

class Cavalo(Tabuleiros tab, Cor cor) : Peca(tab, cor)
{
    public override string ToString() => "C";

    private bool PodeMover(Posicao pos)
    {
        Peca p = tab.Peca(pos);
        return p == null || p.Cor != cor;
    }

    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[tab.Linhas, tab.Colunas];

        Posicao pos = new(0, 0);

        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
        if (tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        return mat;
    }
}
