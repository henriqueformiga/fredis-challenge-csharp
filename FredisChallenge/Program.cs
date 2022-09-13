using System;
using FredisChallenge.Entities;

namespace FredisChallenge
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Fredis fredis = new Fredis();
            fredis.Begin();

            fredis.Set("teste", "value");
            fredis.Set("teste2", "value2");

            fredis.Commit();

            // Console.WriteLine(fredis.Get("teste"));
        }

    }
}
