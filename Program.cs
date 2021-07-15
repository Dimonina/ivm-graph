using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using IvmGraph.Reactive;

namespace IvmGraph
{
    static class Program
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        static void Main(string[] args)
        {
            // initialise input variables
            Observable<int> aStream = new();
            Observable<int> bStream = new();
            Observable<int> cStream = new();
            Observable<int> dStream = new();
            Observable<int> eStream = new();
            Observable<int> xStream = new();
            Observable<int> yStream = new();
            
            // initialize functions
            Observable<int> f_ab_stream = Unions.CombineLatest(@aStream, bStream)
                .Map(x => x.Item1 + x.Item2)
                .Tap(x => Console.WriteLine("Fab called"));

            Observable<int> f_y_stream = yStream
                .Map(x => x * 2)
                .Tap(x => Console.WriteLine("Fy called"));
            
            Observable<int> f_x_stream = xStream
                .Map(x => x + 1)
                .Tap(x => Console.WriteLine("Fx called"));
            
            Observable<int> f_cd_stream = Unions.CombineLatest(cStream, dStream, f_ab_stream, f_y_stream)
                .Map(x => x.Item1 + x.Item2 + x.Item3 - x.Item4)
                .Tap(x => Console.WriteLine("Fcd called"));
            
            Observable<int> f_e_stream = Unions.CombineLatest(eStream, f_cd_stream, f_x_stream)
                .Map(x => x.Item1 + 100 + x.Item2 * 2 + x.Item3)
                .Tap(x => Console.WriteLine("Fe called"));
            
            
            f_e_stream.OnChange(val => Console.WriteLine($"Calculation result: {val}"));
            
            // initialize streams with zeroes
            Console.WriteLine("First time initialization by zeroes");
            aStream.Next(0);
            bStream.Next(0);
            cStream.Next(0);
            dStream.Next(0);
            eStream.Next(0);
            xStream.Next(0);
            yStream.Next(0);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("For changing a variable please type \"x=5\", type \"q\" for exit)");
            
            while (true)
            {
                string? s = Console.ReadLine();
                if (s == "q") break;
                
                var parsed = ParseValue(s);
                if (parsed == null) continue;
                if (parsed.Value.var == "a") { aStream.Next(parsed.Value.value); }
                if (parsed.Value.var == "b") { bStream.Next(parsed.Value.value); }
                if (parsed.Value.var == "c") { cStream.Next(parsed.Value.value); }
                if (parsed.Value.var == "d") { dStream.Next(parsed.Value.value); }
                if (parsed.Value.var == "e") { eStream.Next(parsed.Value.value); }
                if (parsed.Value.var == "x") { xStream.Next(parsed.Value.value); }
                if (parsed.Value.var == "y") { yStream.Next(parsed.Value.value); }
            }
            
        }

        private static (string var, int value)? ParseValue(string? s)
        {
            if (s == null) return null;
            try
            {
                var split = s.Split('=');
                if (split.Length != 2 || new [] { "a", "b", "c", "d", "e", "x", "y" }.Contains(split[0].ToLowerInvariant()) == false || int.TryParse(split[1], out int val) == false)
                {
                    Console.WriteLine("Can't parse string");
                    return null;
                }

                return (split[0].ToLowerInvariant(), int.Parse(split[1]));
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't parse string");
            }

            return null;
        }
    }
}
