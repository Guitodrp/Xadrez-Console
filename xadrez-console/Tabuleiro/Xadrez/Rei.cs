using xadrez_console.Tabuleiro.Xadrez;

namespace xadrez_console.Tabuleiro;

class Rei(Tabuleiros tab, Cor cor, PartidaXadrez partida) : Peca(tab, cor)
{
    private PartidaXadrez Partida = partida;
    public override string ToString() => "R";

    private bool PodeMover(Posicao pos)
    {
        Peca p = Tab.Peca(pos);
        return p == null || p.Cor != Cor;
    }

    private bool TesteTorreRoque(Posicao pos)
    {
        Peca p = Tab.Peca(pos);
        return p != null && p is Torre && p.Cor == cor && p.QtdMovimentos == 0;
    }

    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
        Posicao pos = new(0, 0);

        //Cima
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //NORDESTE
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //Direita
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //SUDESTE
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //ABAIXO

        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //SUDOESTE
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //ESQUERDA
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //NOROESTE
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //#JOGADAESPECIAL ROQUE
        if (QtdMovimentos == 0 && !Partida.Xeque)
        {
            Posicao posT1 = new(Posicao.Linha, Posicao.Coluna + 3);
            if (TesteTorreRoque(posT1))
            {
                Posicao p1 = new(Posicao.Linha, Posicao.Coluna + 1);
                Posicao p2 = new(Posicao.Linha, Posicao.Coluna + 2);
                if (Tab.Peca(p1) == null && Tab.Peca(p2) == null)
                {
                    mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                }
            }
        }

        //#JOGADAESPECIAL ROQUE GRANDE
        if (QtdMovimentos == 0 && !Partida.Xeque)
        {
            Posicao posT2 = new(Posicao.Linha, Posicao.Coluna - 4);
            if (TesteTorreRoque(posT2))
            {
                Posicao p1 = new(Posicao.Linha, Posicao.Coluna - 1);
                Posicao p2 = new(Posicao.Linha, Posicao.Coluna - 2);
                Posicao p3 = new(Posicao.Linha, Posicao.Coluna - 3);
                if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3) == null)
                {
                    mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                }
            }
        }

        return mat;

    }
}
