namespace matcom_domino.Interfaces;


public class HighScoreWinner:IWinner<int>
{
    public HighScoreWinner()
    {
        
    }
    public IPlayer<int> PlayerWinner(List<IPlayer<int>> PlayerList)
    {
        IPlayer<int> winner=null;
        for (int i = 0; i+1 < PlayerList.Count; i++)
        {
            if (PlayerList[i].player_score < PlayerList[i + 1].player_score)
                winner = PlayerList[i + 1];
            else
            {
                winner = PlayerList[i];
            }
            
        }
        return winner;
    }
}

public class LowScoreWinner : IWinner<int>
{
    public IPlayer<int> PlayerWinner(List<IPlayer<int>> PlayerList)
    {
        int[] score_on_hand = new int[PlayerList.Count];

        for (int i = 0; i < PlayerList.Count; i++)
        {
            PlayerList[i].player_score = 0;
            
            foreach (var token in PlayerList[i].ManoDeFichas)
            {
                score_on_hand[i] += token.FichaValue();
            }

            PlayerList[i].player_score = score_on_hand[i];
        }
        
        int index = Array.IndexOf(score_on_hand, score_on_hand.Min());
        return PlayerList[index];
    }
}