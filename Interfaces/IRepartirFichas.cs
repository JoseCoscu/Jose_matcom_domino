namespace matcom_domino.Interfaces;

public interface IRepartirFichas<T>
{
    // Forma de repartir las fichas a los jugadores
    void Repartir(List<IFichas<T>> AllTokens, List<IPlayer<T>> PlayerList, int TokenQty);
}