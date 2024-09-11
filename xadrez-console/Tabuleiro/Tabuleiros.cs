namespace xadrez_console.Tabuleiro;

class Tabuleiros(int linhas, int colunas)
{
    #region Campos

    public int Linhas { get; set; } = linhas;
    public int Colunas { get; set; } = colunas;

    private Peca[,] Pecas = new Peca[linhas, colunas];

    #endregion

    #region Metodos
    public Peca Peca(int linha, int coluna) => Pecas[linha, coluna];

    public Peca Peca(Posicao pos) => Pecas[pos.Linha, pos.Coluna];

    public bool ExistePeca(Posicao pos)
    {
        ValidarPosicao(pos);
        return Peca(pos) != null;
    }

    public void ColocarPeca(Peca p, Posicao pos)
    {
        if (ExistePeca(pos))
        {
            throw new TabuleiroException("Já existe uma peça nessa posição!");
        }
        Pecas[pos.Linha, pos.Coluna] = p;
        p.Posicao = pos;
    }

    public Peca RetirarPeca(Posicao pos)
    {
        if (Peca(pos) == null)
        {
            return null;
        }
        Peca p = Peca(pos);
        p.Posicao = null;
        Pecas[pos.Linha, pos.Coluna] = null;
        return p;
    }

    public bool PosicaoValida(Posicao pos)
    {
        if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
        {
            return false;
        }
        return true;
    }

    public void ValidarPosicao(Posicao pos)
    {
        if (!PosicaoValida(pos))
        {
            throw new TabuleiroException("Posição Invalida !");
        }
    }

    #endregion
}
