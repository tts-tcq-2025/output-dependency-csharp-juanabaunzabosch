using System;
using System.Diagnostics;

namespace TshirtSpace
{
    class Tshirt
    {
        // Returns size category for given cms
        public static string Size(int cms)
        {
            if (cms < 38)
            {
                return "S";
            }
            else if (cms > 38 && cms < 42)
            {
                return "M";
            }
            else
            {
                return "L";
            }
        }

        // Stronger tests exposing boundary bugs
        static void Main(string[] args)
        {
            Debug.Assert(Size(37) == "S"); // Passes
            Debug.Assert(Size(40) == "M"); // Passes
            Debug.Assert(Size(43) == "L"); // Passes

            // New boundary tests (these should fail because of bugs)
            Debug.Assert(Size(38) == "M", "Expected M for cms=38 but got " + Size(38));
            Debug.Assert(Size(42) == "M", "Expected M for cms=42 but got " + Size(42));
            Debug.Assert(Size(38) != "L", "cms=38 should not be L");

            // Also test below lower bound and above upper bound explicitly
            Debug.Assert(Size(36) == "S");
            Debug.Assert(Size(44) == "L");

            Console.WriteLine("Tests done (some should fail now).");
        }
    }
}
