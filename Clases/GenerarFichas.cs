namespace matcom_domino.Interfaces;

public class GeneradorClasico : IGenerarFichas<int>
{
    private List<IFichas<int>> conjuntodeFichas;

    private int cant;
    public List<IFichas<int>> GenerateCards(int a)
    {
        conjuntodeFichas = new List<IFichas<int>>();
        for (int i = 0; i <= a; i++)
        {
            for (int j = i; j <= a; j++)
            {
                this.conjuntodeFichas.Add(new Fichas9(i, j));
            }
        }

        return conjuntodeFichas;

    }
}

public class GeneradorPrimo : IGenerarFichas<int>
{
    private int[] temp = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61 };
    private List<IFichas<int>> conjuntodefichas;
    public List<IFichas<int>> GenerateCards(int a)
    {
        conjuntodefichas = new List<IFichas<int>>();
        for (int i = 0; i <= a; i++)
        {
            for (int j = i; j <= a; j++)
            {
                this.conjuntodefichas.Add(new Fichas9(temp[i],temp[j]));
            }
        }

        return conjuntodefichas;

    }

}