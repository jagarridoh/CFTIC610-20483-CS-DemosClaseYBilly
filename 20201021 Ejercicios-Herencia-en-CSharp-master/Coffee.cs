namespace Heritage05
{
    public class Coffee : Beverage
    {
        public string Bean { get; set; }
        public string Roast { get; set; }
        public string CountryOfOrigin { get; set; }

        private int servingTempWithMilk;
        private int servingTempWithoutMilk;

        //Overriding a Virtual Method by Using the override Keyword 
        /*public override int GetServingTemperature()
        {
            if (includesMilk)
                return servingTempWithMilk;
            else
                return servingTempWithoutMilk;
            //return base.GetServingTemperature();
        }*/

        private bool includesMilk;
        public new int GetServingTemperature()
        {
            if (base.servingTemperature > 0)
            {
                includesMilk = true;
            }
            if (includesMilk)
                return servingTempWithMilk;
            else
                return servingTempWithoutMilk;
        }
        /*sealed public override int GetServingTemperature()
        {
            // Derived classes cannot override this method.
        }*/

        public int OtherServingTemperatura()
        {
            return base.servingTemperature;
        }
        //Coffee() :base() //Llamando al constructor de la clase Base
        /*{

        }*/
    }

}