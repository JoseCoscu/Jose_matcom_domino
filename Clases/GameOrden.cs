namespace matcom_domino.Interfaces;


public class OrdenClasico : IGameOrden<int>
{
    public void OrdendelJuego(List<IPlayer<int>>jugadores)
    {
        
    }
}

public class OrdenclasicoIinverso : IGameOrden<int>
{
    public void OrdendelJuego(List<IPlayer<int>>jugadores)
    {
        jugadores.Reverse();
    }
}

public class OrdenDespuesDePase : IGameOrden<int>
{
    public void OrdendelJuego(List<IPlayer<int>> jugadores)
    {
        List<IPlayer<int>> aux = new List<IPlayer<int>>();
        for (int i = 0; i < jugadores.Count(); i++)
        {
            if (jugadores[i].Pasarse)
            {
                jugadores.Reverse();
                /*int k = i;
                for (int j = 1; j < jugadores.Count(); j++)
                {
                    aux[j] = jugadores[((j - k) + jugadores.Count()) % (jugadores.Count())];
                }
                aux.Reverse();
                jugadores.Clear();
                for (int j = 0; j < jugadores.Count(); j++)
                {
                    jugadores[j] = aux[((j - k) + aux.Count()) % (aux.Count())];
                }*/
            }
        }
    }
}