using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MisalignedSpace
{
    class Misaligned
    {
        static readonly string[] majorColors = { "White", "Red", "Black", "Yellow", "Violet" };
        static readonly string[] minorColors = { "Blue", "Orange", "Green", "Brown", "Slate" };

        // Return the list of all color pairs as strings with their pair number
        public static List<string> GetColorMap()
        {
            List<string> colorMap = new List<string>();
            for (int i = 0; i < majorColors.Length; i++)
            {
                for (int j = 0; j < minorColors.Length; j++)
                {
                    colorMap.Add($"{i * 5 + j} | {majorColors[i]} | {minorColors[i]}"); // BUG still here: minorColors[i]
                }
            }
            return colorMap;
        }

        static void Main(string[] args)
        {
            var colorMap = GetColorMap();

            // Assert length is 25 (5x5)
            Debug.Assert(colorMap.Count == 25);

            // New stronger test: check that each minor color in each row matches minorColors[j]
            for (int i = 0; i < majorColors.Length; i++)
            {
                for (int j = 0; j < minorColors.Length; j++)
                {
                    string expected = $"{i * 5 + j} | {majorColors[i]} | {minorColors[j]}";
                    string actual = colorMap[i * 5 + j];
                    // This assert will fail due to bug
                    Debug.Assert(expected == actual, $"Mismatch at pair {i * 5 + j}: expected '{expected}', got '{actual}'");
                }
            }

            Console.WriteLine("Tests done (should fail now).");
        }
    }
}
