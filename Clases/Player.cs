namespace matcom_domino.Interfaces
{

    public class Player : IPlayer<int> //despues hay k hacerlo generico
    {
        public int player_score { get; set; }
        private List<IFichas<int>> manoficha;

        public List<IFichas<int>> ManoDeFichas
        {
            get => this.manoficha;
        }

        public int time_passed { get; set; }
        public IMesa<int> table { get; }

        public bool in_turn { get; set; }

        public string name { get; set; }

        public Player(IMesa<int> Table, string Name)
        {
            manoficha = new List<IFichas<int>>();
            this.table = Table;
            this.name = Name;
            this.in_turn = false;
            time_passed = 0;
            player_score = 0;
        }

        // Este metodo no se implementa en player 
        public virtual void SelectCard()
        {
            throw new NotImplementedException();
        }


        public bool Pasarse
        {
            get => paso;
            set { }
        }

        public bool paso = false;

        // Recibe una ficha y el lado por el que jugarla (-1 por la izquierda, 1 por la derecha, 0 para pasarse)
        // Por defecto esta en 2 para que los jugadores IA jueguen por defecto por el lado que se pueda
        public void Play(IFichas<int> ficha, int side = 2)
        {
            if (side == 0)
            {
                time_passed++;
                paso = true;
                return;
            }

            if (table.IsValido(ficha))
            {
                this.paso = false;
                table.Log.Add($"EL Jugador {name} ha jugado la ficha: {ficha}");
                table.RecibirJugada(ficha, side);
                manoficha.Remove(ficha);
                player_score += ficha.FichaValue();
                in_turn = false;
            }
        }
    }

    class PlayerRandom : Player
    {
        public PlayerRandom(IMesa<int> table, string name) : base(table, name)
        {
        }


        public override void SelectCard()
        {
            in_turn = true;
            List<IFichas<int>> fichasjugables = new List<IFichas<int>>();
            Random r = new Random();

            foreach (var ficha in ManoDeFichas)
            {
                if (table.IsValido(ficha))
                {
                    fichasjugables.Add(ficha);
                }
            }

            if (fichasjugables.Count > 0)
            {
                Play(fichasjugables[r.Next(fichasjugables.Count)]);
            }
            else
            {
                table.Log.Add($"EL Jugador {name} no lleva: {table.fichaJugable}");
                Play(ManoDeFichas[0], 0);
            }
        }
    }

    class PlayerBotaGorda : Player
    {
        public PlayerBotaGorda(IMesa<int> table, string name) : base(table, name)
        {
        }

        public int SumaFicha(IFichas<int> Ficha)
        {
            return Ficha.FichaValue();
        }

        public void SortHand()
        {
            for (int i = 0; i < ManoDeFichas.Count; i++)
            {
                for (int j = i + 1; j < ManoDeFichas.Count; j++)
                {
                    if (SumaFicha(ManoDeFichas[i]) < SumaFicha(ManoDeFichas[j]))
                    {
                        Fichas9 repuesto = new Fichas9(ManoDeFichas[i].GetFace(1), ManoDeFichas[i].GetFace(2));
                        ManoDeFichas[i] = ManoDeFichas[j];
                        ManoDeFichas[j] = repuesto;
                    }
                }
            }
        }

        public override void SelectCard()
        {
            SortHand();
            in_turn = true;
            foreach (var ficha in ManoDeFichas)
            {
                if (table.IsValido(ficha))
                {
                    Play(ficha);
                    break;
                }

                // Si es la ultima ficha y no se jugo se pasa
                if (ficha == ManoDeFichas[ManoDeFichas.Count - 1])
                {
                    table.Log.Add($"El Jugador {name} no lleva: {table.fichaJugable}");
                    Play(ManoDeFichas[0], 0);
                }
            }
        }
    }

    class PlayerSobreviviente : Player
    {
        public PlayerSobreviviente(IMesa<int> table, string name) : base(table, name)
        {
            ValorJugable = new List<int>();
        }

        private List<int> ValorJugable;


        public void Posivilidad(List<IFichas<int>> FichasJugables)
        {
            // Por todas las fichas validas
            for (int i = 0; i < FichasJugables.Count; i++)
            {
                int token_value = 0;

                // Por toda las fichas de la mano
                for (int j = 0; j < ManoDeFichas.Count; j++)
                {
                    // Si encuentra fichas con la misma cara aumenta el valor jugable de la ficha i
                    if (FichasJugables[i].GetFace(1) == ManoDeFichas[j].GetFace(1) ||
                        FichasJugables[i].GetFace(1) == ManoDeFichas[j].GetFace(2))
                    {
                        token_value++;
                    }

                    if (FichasJugables[i].GetFace(2) == ManoDeFichas[j].GetFace(1) ||
                        FichasJugables[i].GetFace(2) == ManoDeFichas[j].GetFace(2))
                    {
                        token_value++;
                    }
                }

                // Adiciona el valor jugable a la lista
                ValorJugable.Add(token_value);
            }
        }
        

        public int IndexOf(int a)
        {
            for (int i = 0; i < ValorJugable.Count(); i++)
            {
                if (a == ValorJugable[i])
                {
                    return i;
                }
            }

            throw new Exception("Cannot Find value on list");
            //return -1;
        }

        public override void SelectCard()
        {
            in_turn = true;
            List<IFichas<int>> temp_fichas = new List<IFichas<int>>();

            //Agregando fichas jugables a la lista
            for (int i = 0; i < ManoDeFichas.Count(); i++)
            {
                if (table.IsValido(ManoDeFichas[i]))
                {
                    temp_fichas.Add(ManoDeFichas[i]);
                }
            }

            // Calculando la posivilidad de cada ficha jugable
            Posivilidad(temp_fichas);

            // //eliminando los k estan en false
            // for (int i = 0; i < temp_fichas.Count(); i++)
            // {
            //     temp_valor_jugable.Add(ValorJugable[i]);
            // }

            // Si no hay fichas jugables se pasa
            if (temp_fichas.Count == 0)
            {
                Play(ManoDeFichas[0], 0);
            }
            else
            {
                //Juega la ficha jugable con mayor posibilidad
                Play(temp_fichas[IndexOf(ValorJugable.Max())]);
                ValorJugable.Clear();
            }
        }
    }

    class PlayerTramposo : PlayerBotaGorda
    {
        public PlayerTramposo(IMesa<int> table, string name) : base(table, name)
        {
        }

        public override void SelectCard()
        {
            in_turn = true;
            SortHand();
            for (int i = 0; i < ManoDeFichas.Count; i++)
            {
                if (table.IsValido(ManoDeFichas[i]))
                {
                    Play(ManoDeFichas[i]);
                    break;
                }

                // Si es la ultima ficha y no la jugo... no lleva y roba de la pila
                if (i == ManoDeFichas.Count - 1)
                {
                    foreach (var token in table.FichasSobrantes)
                    {
                        if (table.IsValido(token))
                        {
                            table.FichasSobrantes.Add(ManoDeFichas[0]);
                            ManoDeFichas.RemoveAt(0);
                            Play(token);
                            break;
                        }
                    }

                    // Si Miro todas las fichas de la mesa y no robo ninguna bota una ficha de su mano
                    if (in_turn)
                    {
                        ManoDeFichas.RemoveAt(0);
                        break;
                    }
                }
            }
        }
    }
}