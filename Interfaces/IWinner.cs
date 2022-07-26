namespace matcom_domino.Interfaces;

public interface IWinner<T>
{
    //Forma de decidir quien gana el juego
    IPlayer<T> PlayerWinner(List<IPlayer<T>> PlayerList);
}
