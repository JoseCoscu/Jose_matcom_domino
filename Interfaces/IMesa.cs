namespace matcom_domino.Interfaces;

public interface IMesa<T>
{
    // Verificar si es valida una cierta ficha
    bool IsValido(IFichas<T> a); 
    // Lista con las fichas que ese han jugado
    List<IFichas<T>> CardinTable { get; }
    // Recibe una ficha y la pone por el lado especificado
    void RecibirJugada(IFichas<T> ficha, int side);
    // Log que contiene todos los acontecimientos del juego
    List<string> Log { get; }
    // Lista que contiene todas las fichas que sobraron luego de repartir
    List<IFichas<T>> FichasSobrantes { get; set; }
    // Una ficha donde sus caras son los 2 extremos de la mesa
    IFichas<T> fichaJugable { get; }
}
