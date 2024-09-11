namespace xadrez_console.Tabuleiro.Xadrez;

class PartidaXadrez
{
    #region Campos

    public Tabuleiros Tab { get; private set; }
    public int Turno { get; private set; }
    public Cor JogadorAtual { get; private set; }
    public bool Terminada { get; private set; }
    public bool Xeque { get; private set; }
    public Peca? VulneravelEnPassant { get; private set; }

    private HashSet<Peca> Pecas;

    private HashSet<Peca> Capturadas;

    public PartidaXadrez()
    {
        Tab = new Tabuleiros(8, 8);
        Turno = 1;
        JogadorAtual = Cor.Branca;
        Terminada = false;
        Xeque = false;
        VulneravelEnPassant = null;
        Pecas = [];
        Capturadas = [];
        ColocarPecas();
    }

    #endregion

    #region Métodos
    private static Cor Adversaria(Cor cor)
    {
        if (cor == Cor.Branca)
        {
            return Cor.Preta;
        }
        else
        {
            return Cor.Branca;
        }
    }

    public Peca ExecutaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = Tab.RetirarPeca(origem);
        p.IncrementarQtdMovimentos();
        Peca pecaCapturada = Tab.RetirarPeca(destino);
        Tab.ColocarPeca(p, destino);
        if (pecaCapturada != null)
        {
            Capturadas.Add(pecaCapturada);
        }

        //JOGADAESPECIAL ROQUE
        if (p is Rei && destino.Coluna == origem.Coluna + 2)
        {
            Posicao origemTorre = new(origem.Linha, origem.Coluna + 3);
            Posicao destinoTorre = new(origem.Linha, origem.Coluna + 1);
            Peca T = Tab.RetirarPeca(origemTorre);
            T.IncrementarQtdMovimentos();
            Tab.ColocarPeca(T, destinoTorre);
        }

        //JOGADAESPECIAL ROQUE GRANDE
        if (p is Rei && destino.Coluna == origem.Coluna - 2)
        {
            Posicao origemTorre = new(origem.Linha, origem.Coluna - 4);
            Posicao destinoTorre = new(origem.Linha, origem.Coluna - 1);
            Peca T = Tab.RetirarPeca(origemTorre);
            T.IncrementarQtdMovimentos();
            Tab.ColocarPeca(T, destinoTorre);
        }

        // #JOGADAESPECIAL EN PASSANT
        if (p is Peao)
        {
            if (origem.Coluna != destino.Coluna && pecaCapturada == null)
            {
                Posicao posPeao;
                if (p.Cor == Cor.Branca)
                {
                    posPeao = new Posicao(destino.Linha + 1, destino.Coluna);
                }
                else
                {
                    posPeao = new Posicao(destino.Linha - 1, destino.Coluna);
                }
                pecaCapturada = Tab.RetirarPeca(posPeao);
                Capturadas.Add(pecaCapturada);
            }

        }
        return pecaCapturada;
    }

    private Peca Rei(Cor cor)
    {
        foreach (Peca peca in PecasEmJogo(cor))
        {
            {
                if (peca is Rei)
                    return peca;
            }
        }
        return null;
    }

    public HashSet<Peca> PecasCapturadas(Cor cor)
    {
        HashSet<Peca> Aux = [];
        foreach (Peca peca in Capturadas)
        {
            if (peca.Cor == cor)
            {
                Aux.Add(peca);
            }
        }
        return Aux;
    }

    public HashSet<Peca> PecasEmJogo(Cor cor)
    {
        HashSet<Peca> Aux = [];
        foreach (Peca peca in Pecas)
        {
            if (peca.Cor == cor)
            {
                Aux.Add(peca);
            }
        }
        Aux.ExceptWith(PecasCapturadas(cor));
        return Aux;
    }

    public bool EstaEmXeque(Cor cor)
    {
        Peca R = Rei(cor);

        if (R == null)
            throw new TabuleiroException("Não existe o rei da cor " + cor + " no tabuleiro!");

        foreach (Peca peca in PecasEmJogo(Adversaria(cor)))
        {
            bool[,] mat = peca.MovimentosPossiveis();
            if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                return true;
        }
        return false;
    }

    public bool TesteXequeMate(Cor cor)
    {
        if (!EstaEmXeque(cor))
        {
            return false;
        }

        foreach (Peca peca in PecasEmJogo(cor))
        {
            bool[,] mat = peca.MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        Posicao origem = peca.Posicao;
                        Posicao destino = new(i, j);
                        Peca pecaCapturada = ExecutaMovimento(origem, destino);
                        bool testaXeque = EstaEmXeque(cor);
                        DesfazerMovimento(origem, destino, pecaCapturada);
                        if (!testaXeque)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }

    public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
    {
        Peca p = Tab.RetirarPeca(destino);
        p.DecrementarQtdMovimentos();
        if (pecaCapturada != null)
        {
            Tab.ColocarPeca(pecaCapturada, destino);
            Capturadas.Remove(pecaCapturada);
        }
        Tab.ColocarPeca(p, origem);

        //JOGADAESPECIAL ROQUE
        if (p is Rei && destino.Coluna == origem.Coluna + 2)
        {
            Posicao origemTorre = new(origem.Linha, origem.Coluna + 3);
            Posicao destinoTorre = new(origem.Linha, origem.Coluna + 1);
            Peca T = Tab.RetirarPeca(destinoTorre);
            T.DecrementarQtdMovimentos();
            Tab.ColocarPeca(T, origemTorre);
        }

        //JOGADAESPECIAL ROQUE GRANDE
        if (p is Rei && destino.Coluna == origem.Coluna - 2)
        {
            Posicao origemTorre = new(origem.Linha, origem.Coluna - 4);
            Posicao destinoTorre = new(origem.Linha, origem.Coluna - 1);
            Peca T = Tab.RetirarPeca(destinoTorre);
            T.DecrementarQtdMovimentos();
            Tab.ColocarPeca(T, origemTorre);
        }

        //JOGADAESPECIAL EN PASSANT
        if (p is Peao)
        {
            if (origem.Coluna != destino.Coluna && pecaCapturada == VulneravelEnPassant)
            {
                Peca peao = Tab.RetirarPeca(destino);
                Posicao posPeao;
                if (p.Cor == Cor.Branca)
                {
                    posPeao = new Posicao(3, destino.Coluna);
                }
                else { 
                    posPeao = new Posicao(4, destino.Coluna)
                }
            }
        }
    }

    public void RealizaJogada(Posicao origem, Posicao destino)
    {
        Peca pecaCapturada = ExecutaMovimento(origem, destino);

        if (EstaEmXeque(JogadorAtual))
        {
            DesfazerMovimento(origem, destino, pecaCapturada);
            throw new TabuleiroException("Você não pode se colocar em xeque!");
        }

        if (EstaEmXeque(Adversaria(JogadorAtual)))
        {
            Xeque = true;
        }
        else
        {
            Xeque = false;
        }

        if (TesteXequeMate(Adversaria(JogadorAtual)))
        {
            Terminada = true;
        }
        else
        {
            Turno++;
            MudaJogador();
        }

        Peca p = Tab.Peca(destino);

        //JOGADAESPECIAL EN PASSANT
        if (p is Peao && (destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2))
        {
            VulneravelEnPassant = p;
        }
        else
        {
            VulneravelEnPassant = null;
        }

    }

    public void ValidarPosicaoDeOrigem(Posicao pos)
    {
        if (Tab.Peca(pos) == null)
        {
            throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
        }
        if (JogadorAtual != Tab.Peca(pos).Cor)
        {
            throw new TabuleiroException("A peça de origem escolhida nao é a sua!");
        }
        if (!Tab.Peca(pos).ExistemMovimentosPossiveis())
        {
            throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
        }
    }

    public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
    {
        if (!Tab.Peca(origem).MovimentoPossivel(destino))
        {
            throw new TabuleiroException("Não e possivel mover para o local de destino");
        }
    }

    private void MudaJogador()
    {
        if (JogadorAtual == Cor.Branca)
        {
            JogadorAtual = Cor.Preta;
        }
        else
        {
            JogadorAtual = Cor.Branca;
        }
    }

    private void ColocarPecas()
    {
        ColocarNovaPeca('a', 1, new Torre(Tab, Cor.Branca));
        ColocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branca));
        ColocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branca));
        ColocarNovaPeca('d', 1, new Dama(Tab, Cor.Branca));
        ColocarNovaPeca('e', 1, new Rei(Tab, Cor.Branca, this));
        ColocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branca));
        ColocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branca));
        ColocarNovaPeca('h', 1, new Torre(Tab, Cor.Branca));
        ColocarNovaPeca('a', 2, new Peao(Tab, Cor.Branca, this));
        ColocarNovaPeca('b', 2, new Peao(Tab, Cor.Branca, this));
        ColocarNovaPeca('c', 2, new Peao(Tab, Cor.Branca, this));
        ColocarNovaPeca('d', 2, new Peao(Tab, Cor.Branca, this));
        ColocarNovaPeca('e', 2, new Peao(Tab, Cor.Branca, this));
        ColocarNovaPeca('f', 2, new Peao(Tab, Cor.Branca, this));
        ColocarNovaPeca('g', 2, new Peao(Tab, Cor.Branca, this));
        ColocarNovaPeca('h', 2, new Peao(Tab, Cor.Branca, this));

        ColocarNovaPeca('a', 8, new Torre(Tab, Cor.Preta));
        ColocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preta));
        ColocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preta));
        ColocarNovaPeca('d', 8, new Dama(Tab, Cor.Preta));
        ColocarNovaPeca('e', 8, new Rei(Tab, Cor.Preta, this));
        ColocarNovaPeca('f', 8, new Bispo(Tab, Cor.Preta));
        ColocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preta));
        ColocarNovaPeca('h', 8, new Torre(Tab, Cor.Preta));
        ColocarNovaPeca('a', 7, new Peao(Tab, Cor.Preta, this));
        ColocarNovaPeca('b', 7, new Peao(Tab, Cor.Preta, this));
        ColocarNovaPeca('c', 7, new Peao(Tab, Cor.Preta, this));
        ColocarNovaPeca('d', 7, new Peao(Tab, Cor.Preta, this));
        ColocarNovaPeca('e', 7, new Peao(Tab, Cor.Preta, this));
        ColocarNovaPeca('f', 7, new Peao(Tab, Cor.Preta, this));
        ColocarNovaPeca('g', 7, new Peao(Tab, Cor.Preta, this));
        ColocarNovaPeca('h', 7, new Peao(Tab, Cor.Preta, this));
    }

    public void ColocarNovaPeca(char coluna, int linha, Peca peca)
    {
        Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
        Pecas.Add(peca);
    }

    #endregion
}
