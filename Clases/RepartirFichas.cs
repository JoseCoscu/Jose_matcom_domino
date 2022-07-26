namespace matcom_domino.Interfaces;



public class RepartirEnOrden : IRepartirFichas<int>
{
    public bool RepartoCompleto(List<IPlayer<int>> PlayersList, int TokenQty)
    {
        foreach (var player in PlayersList)
        {
            if (player.ManoDeFichas.Count != TokenQty)
            {
                return false;
            }
        }

        return true;
    }

    public void Repartir(List<IFichas<int>> AllTokens, List<IPlayer<int>> PlayerList, int TokenQty)
    {
        while (true)
        {
            foreach (var player in PlayerList)
            {
                if (player.ManoDeFichas.Count == TokenQty)
                    continue;
                player.ManoDeFichas.Add(AllTokens[0]);
                AllTokens.RemoveAt(0);
            }

            if (RepartoCompleto(PlayerList, TokenQty))
                break;
        }
    }
}

public class RepartirRandom : IRepartirFichas<int>
{
    public void Repartir(List<IFichas<int>> AllTokens, List<IPlayer<int>> PlayerList, int TokenQty)
    {
        Random r = new Random();

        while (PlayerList[PlayerList.Count - 1].ManoDeFichas.Count != TokenQty)
        {
            for (int i = 0; i < PlayerList.Count; i++)
            {
                int k = r.Next(AllTokens.Count);
                PlayerList[i].ManoDeFichas.Add(AllTokens[k]);
                AllTokens.RemoveAt(k);
            }
        }
    }
}

public class RepartirPar : RepartirEnOrden, IRepartirFichas<int>
{
    public void Repartir(List<IFichas<int>> AllTokens, List<IPlayer<int>> PlayerList, int TokenQty)
    {
        List<IFichas<int>> FichasSumaPar = new List<IFichas<int>>();

        
        // Agregando las fichas con suma par
        foreach (var token in AllTokens)
        {
            if (token.FichaValue() % 2 == 0)
            {
                FichasSumaPar.Add(token);
            }
        }
        
        // Removiendo las fichas con suma par del conjunto de todas las fichas
        foreach (var token in FichasSumaPar)
        {
            AllTokens.Remove(token);
        }

        Random r = new Random();
        
        // Se Reparten las fichas hasta que cada jugador tenga la cantidad pedida o se acaben las fichas con suma par
        while (true)
        {
            foreach (var player in PlayerList)
            {
                    
                int index = r.Next(FichasSumaPar.Count);
                
                if (player.ManoDeFichas.Count == TokenQty)
                    continue;
                player.ManoDeFichas.Add(FichasSumaPar[index]);
                FichasSumaPar.RemoveAt(index);

                if (FichasSumaPar.Count == 0)
                {
                    Console.WriteLine("ATENCION!!!!!");

                    Console.WriteLine("Se han acabado las fichas con suma par");
                    Console.WriteLine("Considere jugar con menos jugadores o con menos fichas");
                    Console.WriteLine("El juego comenzara con las fichas que se hallan podido repartir");

                    break;
                }
                    
            }
            
            // Si se hizo un reparto completo o se acabaron las fichas a repartir
            if (RepartoCompleto(PlayerList, TokenQty)||FichasSumaPar.Count==0)
                break;
        }
    }
}