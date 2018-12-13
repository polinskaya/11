using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1:");
            string[] year = { "january", "february","march","april","may","june","july","august","september","october","november","december" };
            int n = 4;
            var selectedMonthWithNLetters = from m in year
                                where m.Length == n
                                select m;
            foreach(var i in selectedMonthWithNLetters)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            var selectedSummerWinterMonth = from m in year
                                            where m.Contains("january") || m.Contains("february") || m.Contains("december") || m.Contains("june") || m.Contains("july") || m.Contains("august")
                                            select m;
            foreach(var i in selectedSummerWinterMonth)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            var selectedMonthAtoZ = from m in year
                                    orderby m
                                    select m;
            foreach (var i in selectedMonthAtoZ)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            var selectedMonthWithMoreThenFourLettersAndContainsU = from m in year
                                                                   where m.Contains('u') && m.Length > 4
                                                                   select m;
            foreach (var i in selectedMonthWithMoreThenFourLettersAndContainsU)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            Console.WriteLine("Задание 2-3:");
            List<Rectangle> rectangles = new List<Rectangle>();
            rectangles.Add(new Rectangle(2));
            rectangles.Add(new Rectangle(5,3,RectangleType.Rectangle));
            rectangles.Add(new Rectangle(3,RectangleType.Romb));
            rectangles.Add(new Rectangle(6,5, RectangleType.Free));
            rectangles.Add(new Rectangle(4));
            rectangles.Add(new Rectangle(3, 2, RectangleType.Rectangle));
            rectangles.Add(new Rectangle(8, RectangleType.Romb));
            rectangles.Add(new Rectangle(7, 5, RectangleType.Free));

            var countOfRomb = (from s in rectangles
                                  where s.RectangleType == RectangleType.Romb
                                  select s).Count();

            var countOfRect = (from s in rectangles
                where s.RectangleType == RectangleType.Rectangle
                select s).Count();

            var countOfSq = (from s in rectangles
                where s.RectangleType == RectangleType.Square
                select s).Count();

            var countOfFree = (from s in rectangles
                where s.RectangleType == RectangleType.Free
                select s).Count();

            Console.WriteLine($"Free rect's count: {countOfFree}");
            Console.WriteLine($"Count of rects: {countOfRect}");
            Console.WriteLine($"Count of squares: {countOfSq}");
            Console.WriteLine($"Count of rombs: {countOfRomb}");


            Console.WriteLine("//////////////////////////////////////////////////////");

            var maxPerimObjFree = (from s in rectangles
                where s.RectangleType == RectangleType.Free
                orderby s.Square()
                select s).First();

            var minPerimObjFree = (from s in rectangles
                where s.RectangleType == RectangleType.Free
                orderby s.Square() descending select s).First();

            Console.WriteLine($"min square type{minPerimObjFree.RectangleType.ToString()}: {minPerimObjFree}");
            Console.WriteLine($"max square type{minPerimObjFree.RectangleType.ToString()}: {maxPerimObjFree}");

            var maxPerimObjRect = (from s in rectangles
                where s.RectangleType == RectangleType.Rectangle
                orderby s.Square()
                select s).First();

            var minPerimObjRect = (from s in rectangles
                where s.RectangleType == RectangleType.Rectangle
                orderby s.Square() descending
                select s).First();

            Console.WriteLine($"min square type{minPerimObjFree.RectangleType.ToString()}: {minPerimObjRect}");
            Console.WriteLine($"max square type{minPerimObjFree.RectangleType.ToString()}: {maxPerimObjRect}");

            var maxPerimObjSq = (from s in rectangles
                where s.RectangleType == RectangleType.Square
                orderby s.Square()
                select s).First();

            var minPerimObjSq = (from s in rectangles
                where s.RectangleType == RectangleType.Square
                orderby s.Square() descending
                select s).First();

            Console.WriteLine($"min square type{minPerimObjFree.RectangleType.ToString()}: {minPerimObjSq}");
            Console.WriteLine($"max square type{minPerimObjFree.RectangleType.ToString()}: {maxPerimObjSq}");

            var maxPerimObjRomb = (from s in rectangles
                where s.RectangleType == RectangleType.Romb
                orderby s.Square()
                select s).First();

            var minPerimObjRomb = (from s in rectangles
                where s.RectangleType == RectangleType.Romb
                orderby s.Square() descending
                select s).First();

            Console.WriteLine($"min square type{minPerimObjFree.RectangleType.ToString()}: {minPerimObjRomb}");
            Console.WriteLine($"max square type{minPerimObjFree.RectangleType.ToString()}: {maxPerimObjRomb}");

            Console.WriteLine("//////////////////////////////////////////////////////");

            var sqrtsWith = (from s in rectangles
                where s.RectangleType == RectangleType.Square && s.Height <= 3
                select s);


            foreach (var i in sqrtsWith)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("//////////////////////////////////////////////////////");

            var oderdRectsByPerim = from s in rectangles
                where s.RectangleType == RectangleType.Rectangle
                orderby s.Perimeter()
                select s;

            foreach (var i in oderdRectsByPerim)
            {
                Console.WriteLine($"{i}|perimetr:{i.Perimeter()}");
            }

            Console.WriteLine("//////////////////////////////////////////////////////");

            Console.WriteLine();

            Console.WriteLine("Задание 4-5:");
            Console.WriteLine();

            List<Rectangle> rectangles1 = new List<Rectangle>();
            rectangles1.Add(new Rectangle(2));
            rectangles1.Add(new Rectangle(5, 3, RectangleType.Rectangle));
            rectangles1.Add(new Rectangle(3, RectangleType.Romb));
            rectangles1.Add(new Rectangle(6, 5, RectangleType.Free));
            rectangles1.Add(new Rectangle(4));
            rectangles1.Add(new Rectangle(3, 2, RectangleType.Rectangle));
            rectangles1.Add(new Rectangle(8, RectangleType.Romb));
            rectangles1.Add(new Rectangle(7, 5, RectangleType.Free));

            List<Rectangle> rectangles2 = new List<Rectangle>();
            rectangles2.Add(new Rectangle(2));
            rectangles2.Add(new Rectangle(5, 3, RectangleType.Rectangle));
            rectangles2.Add(new Rectangle(3, RectangleType.Romb));
            rectangles2.Add(new Rectangle(5, 5, RectangleType.Free));
            rectangles2.Add(new Rectangle(4));
            rectangles2.Add(new Rectangle(3, 2, RectangleType.Rectangle));
            rectangles2.Add(new Rectangle(7, RectangleType.Romb));
            rectangles2.Add(new Rectangle(6, 5, RectangleType.Free));

            var selectedList = from rec1 in rectangles1
                               join rec2 in rectangles2 on rec1.Perimeter() equals rec2.Perimeter()
                               orderby rec1.Square()
                               select rec1;

            foreach (var s in selectedList)
            {
                Console.WriteLine($"{s}|perimetr:{s.Square()}");
            }
            Console.ReadKey();
        }
    }
}
