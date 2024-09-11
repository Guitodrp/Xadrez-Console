namespace xadrez_console.Tabuleiro.Xadrez;

class Dama(Tabuleiros tab, Cor cor) : Peca(tab, cor)
{
    public override string ToString() => "D";

    private bool PodeMover(Posicao pos)
    {
        Peca p = Tab.Peca(pos);
        return p == null || p.Cor != cor;
    }

    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

        Posicao pos = new(0, 0);

        // ESQUERDA
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna - 1);
        }

        // DIREITA
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna + 1);
        }

        // CIMA
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha - 1, pos.Coluna);
        }

        // ABAIXO
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha + 1, pos.Coluna);
        }

        // NO
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
        }

        // NE
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
        }

        // SE
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
        }

        // SO
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
        }

        return mat;
    }
}
