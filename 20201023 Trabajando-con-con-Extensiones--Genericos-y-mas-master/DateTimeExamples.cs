using System;
using static System.Console;
using static System.ConsoleColor;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
namespace Extending06
{

    public class UsingDateTime
    {

        public void UsingDateTimes()
        {
            DateTime myValue = DateTime.Now;
            WriteLine(myValue.ToString());
            int currentForegroundColor = (int)ForegroundColor;
            ForegroundColor = DarkYellow;
            WriteLine($"ToShortDateString:{myValue.ToShortDateString()} " +
                $"\nToShortTimeString:{myValue.ToShortTimeString()}");
            ForegroundColor = (ConsoleColor)currentForegroundColor;
            WriteLine($"ToLongDateString:{myValue.ToLongDateString()}" +
                $"\nToLongTimeString:{myValue.ToLongTimeString()}");
            WriteLine($"AddDays:{myValue.AddDays(3).ToLongDateString()}" +
                $"\nAddHours:{myValue.AddHours(3)}-");
            ForegroundColor = White;
            WriteLine($"Month:{myValue.Month}");
            DateTime myBirthday = new DateTime(1988, 12, 31);
            WriteLine(myBirthday.ToShortDateString());
            //Format of DateTime.Parse("dia/mes/año");
            try
            {
                myBirthday = DateTime.Parse("31/12/1968");
            }
            catch (SystemException e)
            {
                WriteLine(new String('=', 120));
                WriteLine($"{e}");
                WriteLine(new String('=', 120));
            }
            //Represent a interval of time
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
            WriteLine(myAge.TotalDays);
            string dateInput = "Dec 21, 2018"; // Esto no funciona si la cadena es "Dic 21, 2018"
            DateTime parsedDated = DateTime.Parse(dateInput);
            WriteLine("{0}", parsedDated);
            CultureInfo myCultureInfo = new CultureInfo("es-ES");
            string mySpanishDate = "21 Diciembre 2018";
            DateTime myDateTime = DateTime.Parse(mySpanishDate, myCultureInfo);
            WriteLine("Fecha corta: {0}", myDateTime.ToShortDateString());
            WriteLine("Fecha larga: {0}", myDateTime.ToLongDateString());
            ForegroundColor = (ConsoleColor)currentForegroundColor;
        }

        public void UsingDateTimeTwo()
        {
            //Display the name of the current thread culture
            WriteLine($"La cultura actual es:{CultureInfo.CurrentCulture.Name}");
            //UTC date using currently
            DateTime myCurrentUTCDate = DateTime.UtcNow.Date;
            WriteLine($"Fecha en la cultura actual:{myCurrentUTCDate.ToString("d")}");
            //Date of today
            DateTime myValue = DateTime.Now;
            WriteLine(myValue.ToString());
            int currentForegroundColor = (int)ForegroundColor;
            ForegroundColor = DarkGreen;
            WriteLine($"ToShortDateString:{myValue.ToShortDateString()} " +
                $"\nToShortTimeString:{myValue.ToShortTimeString()}");
            ForegroundColor = (ConsoleColor)currentForegroundColor;
            WriteLine($"ToLongDateString:{myValue.ToLongDateString()}" +
                $"\nToLongTimeString:{myValue.ToLongTimeString()}");
            WriteLine($"AddDays:{myValue.AddDays(3).ToLongTimeString()}" +
                $"\nAddHours:{myValue.AddHours(3)}-");
            WriteLine($"Month:{myValue.Month}");
            DateTime myBirthday = new DateTime(day: 31, year: 1988, month: 12);
            WriteLine(myBirthday.ToShortDateString());
            //Format of DateTime.Parse("dia/mes/año");
            string fechaNacimiento = "31/12/1988";
            if (DateTime.TryParse(fechaNacimiento, out myBirthday))
            {
                ForegroundColor = DarkGreen;
                WriteLine($"La Fecha:{fechaNacimiento} correcta para la actual cultura");
            }
            else
            {
                ForegroundColor = DarkMagenta;
                WriteLine($"La Fecha:{fechaNacimiento} es incorrecta para la actual cultura");
            }
            ForegroundColor = (ConsoleColor)currentForegroundColor;
            //Represent a interval of time
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
            WriteLine(myAge.TotalDays);
            string dateInput = "Dec 21, 2018"; // Esto no funciona si la cadena es "Dic 21, 2018"
            DateTime parsedDated = DateTime.Parse(dateInput);
            WriteLine("{0}", parsedDated);
            //Establece la cultura de tratamiento de fecha de España
            CultureInfo myCultureInfo = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            string mySpanishDate = "21 Diciembre 2018";
            DateTime myDateTime = DateTime.Parse(mySpanishDate, myCultureInfo);
            WriteLine("La fecha en cultura española:{0}", myDateTime.ToShortDateString());
            WriteLine("La fecha en cultura española:{0}", myDateTime.ToLongDateString());
            //Establece la cultura de tratamiento de fecha de Inglaterra
            myCultureInfo = new CultureInfo("en-UK");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            string myBritishDate = "4/23/2018";
            myDateTime = DateTime.Parse(myBritishDate, myCultureInfo);
            WriteLine("La fecha en cultura inglesa:{0}", myDateTime.ToShortDateString());
            WriteLine("La fecha en cultura inglesa:{0}", myDateTime.ToLongDateString());
            ForegroundColor = (ConsoleColor)currentForegroundColor;
            //Comportamiento de los valores en las diferentes culturas
            int anyo = 2020, mes = 6, dia = 16, hora = 16, minuto = 23, segundo = 59;
            DateTime ValorFecha = new DateTime(anyo, mes, dia, hora, minuto, segundo);
            Write($"Pasamos el valor asi: año ({anyo}), mes ({mes})");
            Write($", dia({dia}), hora ({hora}), minuto ({minuto}), ");
            WriteLine($"segundo ({segundo})");
            //ListaDeCulturas(ValorFecha);
            FechaEnDiferentesCulturas(ValorFecha);
            ForegroundColor = (ConsoleColor)currentForegroundColor;
        }


        public void ListaDeCulturas(DateTime ValorFecha)
        {
            OutputEncoding = System.Text.Encoding.UTF8;

            WriteLine("{0,-15}{0,-5}{0,-45}{0,-40}", "Culture", "ISO",
                "Display name", "English Name");
            int i=0;
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.NeutralCultures))//.AllCultures))
            {
                Write("{0,-15}", culture.Name);
                Write("{0,-5}", culture.TwoLetterISOLanguageName);
                Write("{0,-45}", culture.DisplayName);
                WriteLine("{0,-40}", culture.EnglishName);
                try
                {
                    Thread.CurrentThread.CurrentCulture = culture;
                    DateTime DatesInSomeCultures = DateTime.Parse("01/01/2020", culture);
                    DatesInSomeCultures = stringToDateConversion(ValorFecha.ToString(culture), culture.DateTimeFormat.FullDateTimePattern);
                    WriteLine($"{culture.Name}:{DatesInSomeCultures.ToLongDateString()}");
                }
                catch (Exception ex)
                {
                    WriteLine($"Imposible convertir:{ValorFecha.ToString(culture)}, {ex.ToString().Substring(1, 5)}");
                }
                WriteLine($"{culture.Name} - {ValorFecha.ToString(culture)}");
                if((i%50)==0)
                    ReadLine();
            }

        }




        public DateTime stringToDateConversion(string date, string format)
        {
            /* Convert Date to Currrnt Culture */
            DateTimeFormatInfo dateTimeFormatterProvider = DateTimeFormatInfo.CurrentInfo.Clone() as DateTimeFormatInfo;
            dateTimeFormatterProvider.ShortDatePattern = format; //source date format
            DateTime NewDate = DateTime.Parse(date, dateTimeFormatterProvider);
            return NewDate;
        }

        public void FechaEnDiferentesCulturas(DateTime ValorFecha)
        {
            CultureInfo[] cultures = {  new CultureInfo("en-US"),
                                        new CultureInfo("fr-FR"),
                                        new CultureInfo("it-IT"),
                                        new CultureInfo("de-DE"),
                                        new CultureInfo("pt-PT")
                                     };
            WriteLine("Formato de Fechas en las diferentes culturas");
            foreach (CultureInfo culture in cultures)
            {
                 try
                {
                    Thread.CurrentThread.CurrentCulture = culture;
                    DateTime DatesInSomeCultures = DateTime.Parse("01/01/2020", culture);
                    DatesInSomeCultures = stringToDateConversion(ValorFecha.ToString(culture), culture.DateTimeFormat.FullDateTimePattern);
                    WriteLine($"{culture.Name}:{DatesInSomeCultures.ToLongDateString()}");
                }
                catch (Exception ex)
                {
                    WriteLine($"Imposible convertir:{ValorFecha.ToString(culture)}, {ex.ToString().Substring(1, 5)}");
                }
                WriteLine($"{culture.Name} - {ValorFecha.ToString(culture)}");
            }

        }
    }
}