namespace matcom_domino.Interfaces;

public interface IGameOrden<T>
{
    // Decide el orden del juego
    void OrdendelJuego(List<IPlayer<T>> jugadores);
}
