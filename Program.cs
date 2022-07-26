namespace matcom_domino.Interfaces
{
    class Program
    {
        private static IMesa<int> ChooseTable()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("BIENVENIDO A TU PERDICION");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Inserte 1 o 2 para elegir el tipo de mesa en la que quiere jugar");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1:Mesa Clasica => la valides de la jugada es semejante a la del domino normal" + '\n' +
                              "2:Mesa Doble Supremo => " +
                              "La jugada posee la misma valides que la clasica pero los dobles siempre se pueden jugar");

            IMesa<int> mesa;
            while (true)
            {
                int aux = int.Parse(Console.ReadLine());
                if (aux == 1)
                {
                    mesa = new Mesa();
                    break;
                }
                else if (aux == 2)
                {
                    mesa = new MesaDobleSupremo();
                    break;
                }
                else
                {
                    Console.WriteLine("escoje el numero 1 o 2");
                }
            }

            return mesa;
        }

        private static IGenerarFichas<int> ChooseGenerateTokens()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Selecione la manera en que desea generar las fichas");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1:Generador Clasico=> Te genera todas fichas posibles con n caras difentes" + '\n'
                + "2:Generador Primo=> Genera todas las fichas posibles pero las fichas n caras se refieren a numeros primos" +
                "" + '\n' +
                "Usted prodra generar hasta la data 20, si desearia jugar con una data mayor debe insertar los numeros" +
                "" + '\n' + "en LA LISTA #TEM# DE LA CLASE #GERADORPRIMO# ");
            string auxgenerate = Console.ReadLine();
            IGenerarFichas<int> generador;
            while (true)
            {
                if (auxgenerate == "1")
                {
                    generador = new GeneradorClasico();
                    break;
                }
                else if (auxgenerate == "2")
                {
                    generador = new GeneradorPrimo();
                    break;
                }
                else
                {
                    Console.WriteLine("escoje el numero 1 o 2");
                    auxgenerate = Console.ReadLine();
                }
            }

            return generador;
        }

        private static int ChooseData()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Diga hasta que data desea jugar ");
            string auxdata = Console.ReadLine();
            while (true)
            {
                if (auxdata==null || int.Parse(auxdata)<1)
                {
                    Console.WriteLine("Elija un numero positivo!!!");
                    auxdata = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            return int.Parse(auxdata);
        }

        private static IGameOrden<int> ChooseGameOrder()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elija el orden del juego");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1: Orden Clasico" + '\n' + "2: Orden Inverso");
            int auxorden = int.Parse(Console.ReadLine());
            IGameOrden<int> gameOrder;
            while (true)
            {
                if (auxorden == 1)
                {
                    gameOrder = new OrdenClasico();
                    break;
                }
                else if (auxorden == 2)

                {
                    gameOrder = new OrdenclasicoIinverso();
                    break;
                }
                else
                {
                    Console.WriteLine("Escoje el numero 1 o 2");
                    auxorden = int.Parse(Console.ReadLine());
                }
            }

            return gameOrder;
        }

        private static IRepartirFichas<int> ChooseHowtoDeliverTokens()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elija como repartir las fichas");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(
                "1:Reparticion en orden => Se le da a cada jugador 1 ficha y asi seguidamente pero la segunda ficha entregada " +
                '\n' +
                "al sigiente jugador es la que es adyacente a la anterior Ej:jugador1 => (0,1) y jugador2 => (0,2)" +
                '\n' + "" +
                "2:Reparticion Random" + '\n' +
                "3:Reparticion Par => Suma las 2 caras de la ficha y reparte de manera random las fichas cuya suma sea par");
            int auxrepartidor = int.Parse(Console.ReadLine());
            IRepartirFichas<int> repartidor;
            while (true)
            {
                if (auxrepartidor == 1)
                {
                    repartidor = new RepartirEnOrden();
                    break;
                }
                else if (auxrepartidor == 2)
                {
                    repartidor = new RepartirRandom();
                    break;
                }
                else if (auxrepartidor == 3)
                {
                    repartidor = new RepartirPar();
                    break;
                }
                else
                {
                    Console.WriteLine("Elija el numero 1, 2 o 3!!!!");
                    auxrepartidor = int.Parse(Console.ReadLine());
                }
            }

            return repartidor;
        }

        private static ITranke<int> ChooseTranke()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elija el tipo de tranque ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1:Tranque Clasico=> El juego se acaba cuando nadie tiene una ficha diponible valida" +
                              '\n' + "2:Tranque doble:=> El juego se acaba cuando" +
                              " un jugador se pasa 2 veces");
            int auxtranke = int.Parse(Console.ReadLine());
            ITranke<int> tranke;
            while (true)
            {
                if (auxtranke == 1)
                {
                    tranke = new TrankeClasico();
                    break;
                }
                else if (auxtranke == 2)
                {
                    tranke = new DobleTranke();
                    break;
                }
                else
                {
                    Console.WriteLine("Escoja el numero 1 o 2!!!! ");
                    auxtranke = int.Parse(Console.ReadLine());
                }
            }

            return tranke;
        }

        private static IWinner<int> ChooseWinMethod()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elija cual sea el ganador al terminar el juego");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1:Menor puntuacion" + '\n' + "2:Mayor puntuacion");
            int auxwinner = int.Parse(Console.ReadLine());
            IWinner<int> winner;
            while (true)
            {
                if (auxwinner == 2)
                {
                    winner = new HighScoreWinner();
                    break;
                }

                if (auxwinner == 1)
                {
                    winner = new LowScoreWinner();
                    break;
                }
                else
                {
                    Console.WriteLine("Elija el numero 1 o 2");
                    auxwinner = int.Parse(Console.ReadLine());
                }
            }

            return winner;
        }

        private static IDomino<int> ChooseGameType(IMesa<int> table, int data, ITranke<int> tranke, IWinner<int> winner,
            IGameOrden<int> gameOrden, IRepartirFichas<int> delivery, IGenerarFichas<int> generador)
        {
            IDomino<int> domino;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elija el tipo de domino que desea jugar");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1:Domino Clasico" + '\n' +
                              "2:Domino Robaito => Consiste en que cuando no lleves ficha valida" +
                              "robes una de las que sobran,en caso de que esas se acaben le robas fichas al jugador " +
                              '\n' + "del" +
                              "sigiente turno hasta que obtengas una ficha valida");
            int auxdomino = int.Parse(Console.ReadLine());
            while (true)
            {
                if (auxdomino == 1)
                {
                    domino = new DominoClassic(table, data, tranke, winner, gameOrden, delivery, generador);
                    break;
                }
                else if (auxdomino == 2)

                {
                    domino = new DominoRobaito(table, data, tranke, winner, gameOrden, delivery, generador);
                    break;
                }
                else
                {
                    Console.WriteLine("Escoja el numero 1 o 2");
                    auxdomino = int.Parse(Console.ReadLine());
                }
            }

            return domino;
        }

        private static void AddPlayers(IDomino<int> domino, IMesa<int> mesa)
        {
            IPlayer<int> player;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elija los jugadores que usted desea que juegen segun la dificultad");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(
                "1:Player Usuario => Es el jugador de usted el k usted controla puede agragar mas si desea" + '\n' + "" +
                "2:Player Facil => Jugador con pocoas tecnicas en el juego ,hace lo que puede" + '\n' + "3:Player Medio" +
                " => Jugador con poca estrategia ,que siempre decide soltar la ficha de mas valor " + '\n' + "4:" +
                "Player Dificil => Jugador con un poco mas de estrategia basada practicamente en sotar la ficha " +
                "de mayor data.");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("5:Player Invencible => Es un jugador desconocido del cual ,cuya estrategia nunca " +
                              "se ha podido averiguar, dice el que juega por intuicion");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-1: Para no agregar mas jugadores");
            int auxplayer = int.Parse(Console.ReadLine());
            while (true)
            {
                
                if (auxplayer == 1)
                {
                    Console.WriteLine("Pongale el nombre que usted desee al jugador");
                    string nombre = Console.ReadLine();
                    player = new Player(mesa, nombre);
                    domino.AgregarJugador(player);
                    Console.WriteLine("Agregue un Jugador:");
                    auxplayer = int.Parse(Console.ReadLine());
                }
                else if (auxplayer == 2)
                {
                    Console.WriteLine("Pongale el nombre que usted desee al jugador");
                    string nombre = Console.ReadLine();
                    player = new PlayerRandom(mesa, nombre);
                    domino.AgregarJugador(player);
                    Console.WriteLine("Agregue un Jugador:");
                    auxplayer = int.Parse(Console.ReadLine());
                }
                else if (auxplayer == 3)
                {
                    Console.WriteLine("Pongale el nombre que usted desee al jugador");
                    string nombre = Console.ReadLine();
                    player = new PlayerBotaGorda(mesa, nombre);
                    domino.AgregarJugador(player);
                    Console.WriteLine("Agregue un Jugador:");
                    auxplayer = int.Parse(Console.ReadLine());
                }
                else if (auxplayer == 4)
                {
                    Console.WriteLine("Pongale el nombre que usted desee al jugador");
                    string nombre = Console.ReadLine();
                    player = new PlayerSobreviviente(mesa, nombre);
                    domino.AgregarJugador(player);
                    Console.WriteLine("Agregue un Jugador:");
                    auxplayer = int.Parse(Console.ReadLine());
                }
                else if (auxplayer == 5)
                {
                    Console.WriteLine("Pongale el nombre que usted desee al jugador");
                    string nombre = Console.ReadLine();
                    player = new PlayerTramposo(mesa, nombre);
                    domino.AgregarJugador(player);
                    Console.WriteLine("Agregue un Jugador:");
                    auxplayer = int.Parse(Console.ReadLine());
                }
                else if (auxplayer == -1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Escriba un numero de los posibles");
                    auxplayer = int.Parse(Console.ReadLine());
                }
            }
        }

        private static void PlayerTokensNumbers(IDomino<int> domino)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Escriba la cantidad de fichas que quiere asignarle a cada jugador " + '\n' +
                              "NOTA: Recuerde" +
                              " que la cantidad de fichas a repartir por cada jugador tiene que ser menor o igual que {0} ya que " +
                              "esta es la divicion entre el total de fichas y el total de jugadores  ",
                domino.ConjuntodeFichas.Count() / domino.Jugadores.Count());
            Console.WriteLine("ES IMPORNTE QUE RECUERDE SI ESTABLECIO EL TIPO DE REPARTICION PAR :" + '\n' +
                              "serian la mitad de las cantidad de fichas que existen");
            Console.WriteLine("Se jugara con las fichas que se hallan podido repartir");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int cant_repartir = int.Parse(Console.ReadLine());
            while (true)
            {
                if (cant_repartir > (domino.ConjuntodeFichas.Count() / domino.Jugadores.Count()) || cant_repartir <= 0)
                {
                    Console.WriteLine(
                        "ERROR, elija una cantidad menor igual a {0} y que no sea negativa, ni igual a 0,esto en caso de el repartidor" +
                        "clasico," + '\n' + "en caso del par seria la mitad",
                        domino.ConjuntodeFichas.Count() / domino.Jugadores.Count());
                    cant_repartir = int.Parse(Console.ReadLine());
                }
                else
                {
                    domino.RepartirFichas(cant_repartir);
                    break;
                }
            }
        }

        private static void PrintLog(IMesa<int> Table)
        {
            
            foreach (var log in Table.Log)
            {
                 Console.WriteLine(log);
            }
        }

        public static void Main(string[] args)
        {
            IMesa<int> mesa = ChooseTable();
            IGenerarFichas<int> generador = ChooseGenerateTokens();
            int auxdata = ChooseData();
            IGameOrden<int> ordengame = ChooseGameOrder();
            IRepartirFichas<int> repartidor = ChooseHowtoDeliverTokens();
            ITranke<int> tranke = ChooseTranke();
            IWinner<int> winner = ChooseWinMethod();
            IDomino<int> domino = ChooseGameType(mesa, auxdata, tranke, winner, ordengame, repartidor, generador);
            AddPlayers(domino, mesa);
            PlayerTokensNumbers(domino);
            Console.Clear();
            domino.StartGame();
            PrintLog(mesa);
        }
    }
}