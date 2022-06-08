namespace matcom_domino
{
    public interface IMesa<T>
    {
        //jugar la ficha ,balidar la jugada, ver fichas en la mesa
        bool IsValido(IFichas<T> a); //boliano
        List<IFichas<T>> CardinTable { get; }
        
    }


    public class Mesa : IMesa<int>
    {
        private List<IFichas<int>> cardintable;

        public IFichas<int> fichaJugable;

        public Mesa()
        {
            cardintable = new List<IFichas<int>>();
        }

        public bool IsValido(IFichas<int> a)
        {
            if (cardintable.Count == 0)
            {
                fichaJugable = a;
                return true;
            }
            else if (fichaJugable.GetFace(1) == a.GetFace(1))
            {
                fichaJugable = new Fichas9(a.GetFace(2), fichaJugable.GetFace(2));
                return true;
            }
            else if (fichaJugable.GetFace(2) == a.GetFace(2))
            {
                fichaJugable = new Fichas9(a.GetFace(1), fichaJugable.GetFace(1));
                return true;
            }
            else if (fichaJugable.GetFace(1) == a.GetFace(2))
            {
                fichaJugable = new Fichas9(a.GetFace(1), fichaJugable.GetFace(2));
                return true;
            }
            else if (fichaJugable.GetFace(2) == a.GetFace(1))
            {
                fichaJugable = new Fichas9(a.GetFace(2), fichaJugable.GetFace(1));
                return true;
            }

            return false;
        }

        public List<IFichas<int>> CardinTable
        {
            get => this.cardintable;
        }
    }
}