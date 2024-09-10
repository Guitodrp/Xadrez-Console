namespace xadrez_console.Tabuleiro;

class Rei : Peca
{
    public Rei(Tabuleiros tab, Cor cor) : base(tab, cor)
    {

    }

    public override string ToString()
    {
        return "R";
    }

    private bool PodeMover(Posicao pos)
    {
        Peca p = Tab.Peca(pos);
        return p == null || p.Cor != Cor;
    }

    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
        Posicao pos = new Posicao(0, 0);

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
        pos.DefinirValores(Posicao.Linha +1, Posicao.Coluna + 1);
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

        return mat;

    }
}
