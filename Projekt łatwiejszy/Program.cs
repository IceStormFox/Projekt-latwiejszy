using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekt_łatwiejszy
{
    public class Program
    {
        public static string imie, nazwisko;
        public static long nrPESEL;
        public static string[,] table = new string[10, 3];
        public static StreamWriter sw;
        public static int i;
        static void Main(string[] args)
        {

            i = 0;


            Console.WriteLine("Witaj w programie tworzącym listę mieszkańców!");

            string path = @"ZbiorMieszkancow.txt";

            sw = File.CreateText(path);
            Console.WriteLine("Plik został utworzony!");

            Console.WriteLine("Wprowadź dane:");
            Console.WriteLine("Imię: ");
            imie = Console.ReadLine();
            Console.WriteLine("Nazwisko: ");
            nazwisko = Console.ReadLine();
            Console.Write("PESEL: ");
            nrPESEL = long.Parse(Console.ReadLine());

            PESEL p = new PESEL();
            p.obliczonka();
        }
    }
    class kolejny
    {
        public void kolejnym()
        {
            Console.WriteLine("Imię: ");
            Program.imie = Console.ReadLine();
            Console.WriteLine("Nazwisko: ");
            Program.nazwisko = Console.ReadLine();
            Console.Write("PESEL: ");
            Program.nrPESEL = long.Parse(Console.ReadLine());
            PESEL p = new PESEL();
            p.obliczonka();

        }
    }
    class Tabelson
    {
        public void tabela()
        {
            int j;
            for (j = Program.i; j < 10; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    if (Program.table[k, 2] == Convert.ToString(Program.nrPESEL))
                    {
                        Console.WriteLine("k = {0}", k);
                        Console.WriteLine("PESEL został powtórzony! Nadpisywanie danych...");
                        Program.table[k, 0] = Program.imie;
                        Program.table[k, 1] = Program.nazwisko;
                        Wybor c = new Wybor();
                        c.Choice();
                    }
                    if (Program.table[k, 2] != Convert.ToString(Program.nrPESEL))
                    {
                        Program.table[j, 0] = Program.imie;
                        Program.table[j, 1] = Program.nazwisko;
                        Program.table[j, 2] = Convert.ToString(Program.nrPESEL);
                        Wybor c = new Wybor();
                        c.Choice();
                    }
                }



            }
        }
    }

    public class PESEL
    {

        public static long liczbak;
        public void obliczonka()
        {
            long w1, w2, w3, w4, w5, w6, w7, w8, w9, w10, S, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, M;
            s11 = Program.nrPESEL % 10;
            s10 = Program.nrPESEL / 10 % 10;
            s9 = Program.nrPESEL / 100 % 10;
            s8 = Program.nrPESEL / 1000 % 10;
            s7 = Program.nrPESEL / 10000 % 10;
            s6 = Program.nrPESEL / 100000 % 10;
            s5 = Program.nrPESEL / 1000000 % 10;
            s4 = Program.nrPESEL / 10000000 % 10;
            s3 = Program.nrPESEL / 100000000 % 10;
            s2 = Program.nrPESEL / 1000000000 % 10;
            s1 = Program.nrPESEL / 10000000000 % 10;
            w1 = 1;
            w2 = 3;
            w3 = 7;
            w4 = 9;
            w5 = 1;
            w6 = 3;
            w7 = 7;
            w8 = 9;
            w9 = 1;
            w10 = 3;

            S = (s1 * w1) + (s2 * w2) + (s3 * w3) + (s4 * w4) + (s5 * w5) + (s6 * w6) + (s7 * w7) + (s8 * w8) + (s9 * w9) + (s10 * w10);
            M = S % 10;
           
            if (M == 0)
            {
                if (M == s11)
                {
                    Tabelson t = new Tabelson();
                    t.tabela();
                }
                if (M != s11)
                {
                    Console.WriteLine("Numer PESEL jest niepoprawny!");
                    Console.WriteLine("Proszę wprowadzić poprawne dane!");
                    kolejny m = new kolejny();
                    m.kolejnym();

                }
            }
            if (M != 0)
            {
                if (10 - M == s11)
                {
                    Tabelson t = new Tabelson();
                    t.tabela();
                }
                if (10 - M != s11)
                {
                    Console.WriteLine("Numer PESEL jest niepoprawny!");
                    Console.WriteLine("Proszę wprowadzić poprawne dane!");
                    kolejny m = new kolejny();
                    m.kolejnym();

                }
            }
        }
    }

    class koniec
    {

        public void end()
        {
            Console.WriteLine("Naciśnij dowolny przycisk, aby wyjść z programu");
            Console.ReadKey();
            System.Environment.Exit(1);
        }

    }
    class Wybor
    {
        public void Choice()
        {
            Console.WriteLine("Czy chcesz wprowadzić następnego mieszkańca? y/n");
            string wybor;
            wybor = Console.ReadLine();

            if (wybor == "y")
            {
                Program.i++;
                kolejny m = new kolejny();
                m.kolejnym();
            }
            else
            {
                for (int l = 0; l < 10; l++)
                {
                    Program.sw.WriteLine(Program.table[l, 0]);
                    Program.sw.WriteLine(Program.table[l, 1]);
                    Program.sw.WriteLine(Program.table[l, 2]);
                }
                Program.sw.Close();
                koniec k = new koniec();
                k.end();
                
            }
        }
    }
}