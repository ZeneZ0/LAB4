using System;

namespace лаба_4
{
    public enum FruitType { Apple, Orange, Pineapple, Multifruit }
    public enum SodaType { Cola, Lemonade, Tonic, Soda }
    public enum AlcoholType { Beer, Wine, Vodka, Whiskey }

    public class Beverage
    {
        public int Volume { get; set; }
        public static Random rnd = new Random();

        public virtual string GetInfo()
        {
            return $"\nОбъем: {Volume} мл";
        }
    }

    public class Juice : Beverage
    {
        public FruitType Fruit { get; set; }
        public bool HasPulp { get; set; }

        public override string GetInfo()
        {
            return $"Сок {Fruit}\nОбъем: {Volume} мл\nМякоть: {(HasPulp ? "Да" : "Нет")}";
        }

        public static Juice Generate()
        {
            return new Juice
            {
                Volume = 200 + rnd.Next(300),
                Fruit = (FruitType)rnd.Next(4),
                HasPulp = rnd.Next(2) == 0
            };
        }
    }

    public class Soda : Beverage
    {
        public SodaType Type { get; set; }
        public int BubbleCount { get; set; }

        public override string GetInfo()
        {
            return $"Газировка {Type}\nОбъем: {Volume} мл\nПузырьков: ~{BubbleCount}";
        }

        public static Soda Generate()
        {
            return new Soda
            {
                Volume = 250 + rnd.Next(250),
                Type = (SodaType)rnd.Next(4),
                BubbleCount = 1000 + rnd.Next(9000)
            };
        }
    }

    public class Alcohol : Beverage
    {
        public int Strength { get; set; }
        public AlcoholType Type { get; set; }

        public override string GetInfo()
        {
            return $"Алкоголь {Type}\nОбъем: {Volume} мл\nКрепость: {Strength}%";
        }

        public static Alcohol Generate()
        {
            return new Alcohol
            {
                Volume = 100 + rnd.Next(400),
                Strength = 5 + rnd.Next(40),
                Type = (AlcoholType)rnd.Next(4)
            };
        }
    }
}