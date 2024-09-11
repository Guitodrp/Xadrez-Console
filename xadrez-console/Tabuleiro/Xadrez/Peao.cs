namespace xadrez_console.Tabuleiro.Xadrez;

class Peao(Tabuleiros tab, Cor cor, PartidaXadrez partida) : Peca(tab, cor)
{
    private readonly PartidaXadrez Partida = partida;

    public override string ToString() => "P";

    private bool ExisteInimigo(Posicao pos)
    {
        Peca p = Tab.Peca(pos);
        return p != null && p.Cor != cor;
    }

    private bool Livre(Posicao pos)
    {
        return Tab.Peca(pos) == null;
    }

    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

        Posicao pos = new(0, 0);

        if (cor == Cor.Branca)
        {
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && Livre(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
            Posicao p2 = new(Posicao.Linha - 1, Posicao.Coluna);
            if (tab.PosicaoValida(p2) && Livre(p2) && tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #JOGADAESPECIAL EN PASSANT
            if (Posicao.Linha == 3)
            {
                Posicao esquerda = new(Posicao.Linha, Posicao.Coluna - 1);
                if (tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                {
                    mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                }
                Posicao direita = new(Posicao.Linha, Posicao.Coluna + 1);
                if (tab.PosicaoValida(direita) && ExisteInimigo(direita) && tab.Peca(direita) == Partida.VulneravelEnPassant)
                {
                    mat[direita.Linha - 1, direita.Coluna] = true;
                }
            }
        }
        else
        {
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (tab.PosicaoValida(pos) && Livre(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
            Posicao p2 = new(Posicao.Linha + 1, Posicao.Coluna);
            if (tab.PosicaoValida(p2) && Livre(p2) && tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #JOGADAESPECIAL EN PASSANT
            if (Posicao.Linha == 4)
            {
                Posicao esquerda = new(Posicao.Linha, Posicao.Coluna - 1);
                if (tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                {
                    mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                }
                Posicao direita = new(Posicao.Linha, Posicao.Coluna + 1);
                if (tab.PosicaoValida(direita) && ExisteInimigo(direita) && tab.Peca(direita) == Partida.VulneravelEnPassant)
                {
                    mat[direita.Linha + 1, direita.Coluna] = true;
                }
            }
        }

        return mat;
    }
}

