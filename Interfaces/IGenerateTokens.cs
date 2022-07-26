namespace matcom_domino.Interfaces;

public interface IGenerarFichas<T>
{
    // Forma de decidir como se generan las fichas
    List<IFichas<T>> GenerateCards(int a);
    
}
