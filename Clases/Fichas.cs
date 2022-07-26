namespace matcom_domino.Interfaces
{
    public class Fichas9 : IFichas<int> //se puede implementar tambien con arrays
    {
        public Fichas9(int a, int b)
        {
            //ficha[0]=a;
            //ficha[1]=b;
            ficha = new Tuple<int, int>(a, b);

        }

        public  int CantdeCaras
        {
            get => this.cantdecaras;
        }

        private int cantdecaras=2;
        

       
        public int FichaValue()
        {
            return GetFace(1) + GetFace(2);
        }
        
        private Tuple<int, int> ficha;

        public int GetFace(int a)
        {
            
            if (a == 1) return ficha.Item1;
            if (a == 2) return ficha.Item2;
            else
            {
                return 0;
            }

        }
        public override string ToString()
        {
            return "["+this.ficha.Item1.ToString() + "*" + this.ficha.Item2.ToString()+"]";
        }

        
        
       

    }
}