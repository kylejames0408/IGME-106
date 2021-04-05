using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentTreeTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Tree Levels
            // Level One
            TalentTreeNode magic = new TalentTreeNode("Magic", true);

            // Level Two
            TalentTreeNode fireball = new TalentTreeNode("Fireball", true);
            TalentTreeNode magicArrow = new TalentTreeNode("Magic Arrow", true);

            // Level Three
            TalentTreeNode crazyFireball = new TalentTreeNode("Crazy Big Fireball", false);
            TalentTreeNode tinyFireballs = new TalentTreeNode("1000 Tiny Fireballs", false);
            TalentTreeNode iceArrow = new TalentTreeNode("Ice Arrow", false);
            TalentTreeNode explodingArrow = new TalentTreeNode("Exploding Arrow", false);

            // Hook Up Tree Levels
            // Level One - Level Two
            magic.LeftChildNode = fireball;
            magic.RightChildNode = magicArrow;

            // Level Two - Level Three
            fireball.LeftChildNode = crazyFireball;
            fireball.RightChildNode = tinyFireballs;
            magicArrow.LeftChildNode = iceArrow;
            magicArrow.RightChildNode = explodingArrow;

            // List All Abilities
            Console.WriteLine("==========All Abilities==========");
            magic.ListAllAbilities();

            // List Known Abilities
            Console.WriteLine("\n==========Known Abilities==========");
            magic.ListKnownAbilities();

            // List Possibile Abilities
            Console.WriteLine("\n==========Possible Abilities==========");
            magic.ListPossibleAbilities();

            // Keep Window Open
            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}
