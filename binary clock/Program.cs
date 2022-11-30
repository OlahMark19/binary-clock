using System;
using System.Text;
using System.Timers;

namespace binaryClock
{
    class Program
    {
        private static DateTime Time;

        static void Main(string[] args)
        {
            Timer clock = new Timer(1000.0);
            clock.Elapsed += new ElapsedEventHandler(OnClockTick);
            clock.Start();
            Console.ReadLine();
        }

        public static int ReadBit(int number, int BitPosition)
        {
            int i = number & (1 << BitPosition);
            return (i > 0 ? 1 : 0);
        }

        private static string MakeDigitalString(string Head, int number)
        {
            string initialValue = " " + Head + " *  * ";
            StringBuilder sb = new StringBuilder(initialValue);
            for (int i = 0; i < 6; i++)
            {
                sb.Insert(5, ReadBit(number, i));
            }
            return sb.ToString();
        }
        private static void OnClockTick(object source, ElapsedEventArgs e)
        {
            Time = DateTime.Now;
            string Hstr = MakeDigitalString("H", Time.Hour);
            string Mstr = MakeDigitalString("M", Time.Minute);
            string Sstr = MakeDigitalString("S", Time.Second);

            Console.SetCursorPosition(2, 1);
            Console.Write(Hstr);
            Console.SetCursorPosition(2, 2);
            Console.Write(Mstr);
            Console.SetCursorPosition(2, 3);
            Console.Write(Sstr);
        }
    }
}