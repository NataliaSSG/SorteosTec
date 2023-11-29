using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLootBox {
        public class Lootboxes {
            public static List<(string, double)> Skins = new List<(string, double)>{
                ("4", 0.5),
                ("5", 0.25),
                ("6", 0.15),
                ("7", 0.1)
            };
            public static List<(string, double)> Coins = new List<(string, double)>{
                ("12", 0.7),
                ("13", 0.19),
                ("14", 0.1),
                ("15", 0.01)
            };
            public static List<(string, double)> Discounts = new List<(string, double)>{
                ("8", 0.65),
                ("9", 0.20),
                ("10", 0.10),
                ("11", 0.05)
            };
            public static T WeightedRandomChoice<T>(List<(T, double)> choices){
                double total = choices.Sum(choice => choice.Item2);
                double r = new Random().NextDouble() * total;
                double upTo = 0;

                foreach (var(c, w) in choices)
                {
                    if (upTo + w >= r)
                        return c;
                    upTo += w;
                }
                throw new InvalidOperationException("Weighted random selection failed");
            }
    }
}
