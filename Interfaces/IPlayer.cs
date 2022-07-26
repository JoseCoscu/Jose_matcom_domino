namespace matcom_domino.Interfaces;

public interface IPlayer<T>
{
    // Campo que acumula la puntuacion del player
    int player_score { get; set; }

    // Campo para saber si el jugador se paso 
    bool Pasarse { get; set; }

    // Lista que contiene las fichas del jugador
    List<IFichas<T>> ManoDeFichas { get; }

    // Decide como cada jugador selecciona la ficha a jugar
    void SelectCard();

    // Campo para saber si el jugador esta en turno
    public bool in_turn { get; set; }

    // Campo que da nombre al jugador
    string name { get; }

    // Metodo que juega una Ficha
    void Play(IFichas<T> ficha, int side = -1);

    // Campo que dice las veces que se ha pasado el jugador
    int time_passed { get; set; }
}