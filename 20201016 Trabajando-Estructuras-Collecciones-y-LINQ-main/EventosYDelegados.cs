using System;
namespace EventosYDelegados
{
    class Program
    {
        public struct Clima {
            //public double ValorMatutino {get; set;}
            public double ValorMatutino;
        }
        public static void Main()
        {
            Clima clima = new Clima();
            Clima clima2;
            clima2.ValorMatutino = 1;
            clima.ValorMatutino = 10;

            Coffee coffe = new Coffee
            {
                Bean = "Dark",
                CountryOfOrigin = "Colombia",
                Strength = 4,
                MinimunStockLevel = 15,
                CurrentStockLevel = 20
            };
            //De la siguiente forma se puede suscribir al evento pero en la definición
            //del metodo suscrito en la linea 28 no pude ser "static"
            //      RaisingAnEvent rae = new RaisingAnEvent();
            //      coffe.OutOfBeans += rae.HandlerOutOutBean;
            //De esta forma la suscripción si puede ser a un metodo "static" de la linea 28
            coffe.OutOfBeans += new Coffee.OutOfBeanHandler(HandlerOutOutBean);

            for (int i = 0; i < 20; i++)
            {
                coffe.MakeCoffe();
            }
        }
        public static void HandlerOutOutBean(Coffee cof, EventArgs e)
        {
            Console.WriteLine($"Bean:{cof.Bean}-Nivel de grano muy bajo - alerta - {(e != null ? "roja" : "amarilla")}");
            Console.ReadLine();
        }
    }
    public partial struct Coffee
    {
        //Declara el evento y el delegado //old:Pag. 3.19 mistake
        public BooleanEventArgs e;
        public delegate void OutOfBeanHandler(Coffee coffe, BooleanEventArgs args);
        public event OutOfBeanHandler OutOfBeans;

        public int CurrentStockLevel { get; set; }

        public int MinimunStockLevel { get; set; }

        private int strength;
        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        public string CountryOfOrigin { get; set; }
        public string Bean { get; set; }

        public void MakeCoffe()
        {
            CurrentStockLevel--;
            Console.WriteLine($"Beberge of Coffee:{CurrentStockLevel} - Done");
            //if the stock of level drops below the minimum, raise the event
            if (CurrentStockLevel < MinimunStockLevel)
            {
                // Check whether the event is null
                //Raise the event
                //Podría ser si se va a utilizar: OutOfBeans?Invoke(this, e); e = new EventArgs();

                //Similar of:
                //OutOfBeans?.Invoke(this, null);
                e = new BooleanEventArgs(true);
                if (OutOfBeans != null)
                    OutOfBeans(this, e);
            }
        }
    }
    public class BooleanEventArgs : EventArgs
    {
        public bool Valor { get; set; }

        public BooleanEventArgs(bool valor) : base()
        {
            this.Valor = valor;
        }
    }
}
