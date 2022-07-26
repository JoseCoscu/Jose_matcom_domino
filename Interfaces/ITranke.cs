namespace matcom_domino.Interfaces;

public interface ITranke<T>

{
    // Forma de decidir cuando se tranca el juego
    bool Tranke(List<IPlayer<T>> PlayersList, IMesa<T> table);
}
