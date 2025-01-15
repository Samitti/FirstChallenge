using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstChallenge
{
    internal class Program
    {
        public static Func<int> GetRandomNumber = () => new Random().Next(1, 10000);

        public static Func<int, string> GenerateMessage = (number) => $"the random numer is: {number}";
        static void Main(string[] args)
        {
            //Console.WriteLine(GetRndomNumer());
            //Console.WriteLine(GenerateMessage(2));

            var task = Task.Factory.StartNew(() => GetRandomNumber())  
                .ContinueWith(t => GenerateMessage(t.Result))  
                .ContinueWith(t => Console.WriteLine(t.Result));

            task.Wait();
        }
    }
}
