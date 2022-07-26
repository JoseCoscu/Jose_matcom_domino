namespace matcom_domino.Interfaces
{


    public class TrankeClasico : ITranke<int>
    {
        public TrankeClasico()
        {
        
        }

        public bool Tranke(List<IPlayer<int>> PlayersList, IMesa<int> Table)
        {

            foreach (var player in PlayersList)
            {
                foreach (var ficha in player.ManoDeFichas)
                {
                    if (Table.IsValido(ficha))
                        return false;
                }
            }

            return true;
        }
    }

    public class DobleTranke : ITranke<int>
    {
        private int[] pass_count;
        public DobleTranke()
        {
            
        }
        public bool Tranke(List<IPlayer<int>> PlayersList, IMesa<int> table)
        {
            foreach (var player in PlayersList)
            {
                if (player.time_passed >= 2)
                    return true;
            }

            return false;
        }
    }
}