namespace matcom_domino.Interfaces;

public interface IDomino<T>
{
    // Lista con todas las fichas que se generaron
    List<IFichas<T>> ConjuntodeFichas { get; }
    // Lista con los jugadores
    List<IPlayer<T>> Jugadores { get; }
    // Robar una ficha de las sobrantes
    void Robar();
    // Interfaz que decide cuando se tranca el juego
    ITranke<T> _tranke { get; }
    // Agregar un jugador al juego
    void AgregarJugador(IPlayer<T> a);
    // Interfaz que decide como se reparten las fichas a los jugadores
    IRepartirFichas<T> _repartirFichas { get; }
    // Metodo para repartir las fichas
    void RepartirFichas(int k);
    // Interfaz que decide como se generan las fichas
    IGenerarFichas<T> _generarFichas { get; }
    // Interfaz que decide el orden del juego
    IGameOrden<int> orden { get; }
    // Metodo para comenzar el juego
    void StartGame();
    // Verificar sie el juego ha terminado
    bool EndGame();
    // Interfaz que decide quien ha ganado el juego
    IWinner<T> Winner { get; set; }
}