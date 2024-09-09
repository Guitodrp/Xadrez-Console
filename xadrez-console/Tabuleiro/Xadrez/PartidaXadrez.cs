﻿namespace xadrez_console.Tabuleiro.Xadrez;

class PartidaXadrez
{
    public Tabuleiros Tab { get; private set; }
    private int Turno;
    private Cor JogadorAtual;
    public bool Terminada {  get; private set; }

    public PartidaXadrez()
    {
        Tab = new Tabuleiros(8, 8);
        Turno = 1;
        JogadorAtual = Cor.Branca;
        ColocarPecas();
    }

    public void ExecutaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = Tab.RetirarPeca(origem);
        p.IncrementarQtdMovimentos();
        Peca pecaCapturada = Tab.RetirarPeca(destino);
        Tab.ColocarPeca(p, destino);
    }

    private void ColocarPecas()
    {
        Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 1).ToPosicao());
        Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
        Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('c', 5).ToPosicao());
        Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('b', 3).ToPosicao());
    }
}
