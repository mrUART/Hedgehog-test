using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        int[] intOfHedgehoges = new int[3];

        if (HedgehogsTellTruth(Greetings()))
        {
            Console.WriteLine("Please enter the number of desired colour (0,1,2):");
            if (Int32.TryParse(Console.ReadLine(), out Int32 result1))
            {
                if (result1 >= 0 && result1 <= 2)
                {
                    int numberOfSelectedColour = result1;
                    Console.WriteLine("Answer for this case is " + HowManyMeetingsHedgehogsNeed(numberOfSelectedColour, intOfHedgehoges) + " meets");
                    Console.ReadLine();
                }

                else { Console.WriteLine("Wrong Colour, Try Again"); }
            }
            else { Console.WriteLine("Wrong Colour, Try Again"); }


        }
        else { Console.WriteLine("Wrong Hedgehog sequence, Try again"); }



        static string[] Greetings()
        {
            Console.WriteLine("Hello, Admixer team!\n\n   .|||||||||.    \r\n |||||||||||||   \r\n|||||||||||' .\\  \r\n`||||||||||_,__o   \r\n   D      D       \n\nHere is my hedgehog test");
            Console.WriteLine("Write your hedgehog sequence [red,green,blue]: ");
            string[] allHedgehogs = ((Regex.Replace(Console.ReadLine(), @"[\[({\])}']+", string.Empty)).Split(","));
            return allHedgehogs;
        }

        bool HedgehogsTellTruth(string[] stringOfHedgehogs)
        {
            if (stringOfHedgehogs.Length == 3)
            {


                for (int i = 0; i < 3; i++)
                {
                    if (Int32.TryParse(stringOfHedgehogs[i], out int result))
                    {
                        intOfHedgehoges[i] = result;
                    }
                    else { return false; }
                }
                return true;
            }
            else { return false; }
        }

        static int HowManyMeetingsHedgehogsNeed(int colourType, int[] hedgehogsByColours)
        {
            int sumOfAll = 0;
            for (int i = 0; i < 3; i++)
            {
                if (hedgehogsByColours[i] < 0)
                {
                    return (-1);
                    Console.WriteLine("The population of hedgehogs cant be negative");
                }
                else
                {

                    sumOfAll += hedgehogsByColours[i];
                }

            }
            if (sumOfAll < 2)
            {

                if (hedgehogsByColours[colourType] > 0)
                {
                    Console.WriteLine("It looks like this one hedgehog got confused. He already has desired colour.");
                    return (-1);
                }
                else
                {
                    if (sumOfAll <= 0)
                    {
                        Console.WriteLine("The population of hedgehogs cant be negative or zero.Try again");
                        return (-1);
                    }
                    else
                        Console.WriteLine("Oh, poor lonely little creatue, hope he will find a pair to change colour with.");
                    return (-1);
                }
            }
            else
            {
                int[] twoOthercolours = Array.FindAll(hedgehogsByColours, i => i != hedgehogsByColours[colourType]).ToArray();
                if ((twoOthercolours.Max() - twoOthercolours.Min()) % 3 == 0 || twoOthercolours.Max() == twoOthercolours.Min())
                {
                    Console.WriteLine("Wow, colour change is possible!!!");
                    int x = hedgehogsByColours[colourType];
                    int y = twoOthercolours[0];
                    int z = twoOthercolours[1];

                    int meetings = 0;
                    while (z != 0 || y != 0)
                    {

                        if (z == y) { meetings += y; x = z + y; z = 0; y = 0; continue; }
                        if (z == 0) { z = z + 2; y = y - 1; x = x - 1; meetings++; continue; }
                        if (y == 0) { y = y + 2; z = z - 1; x = x - 1; meetings++; continue; }
                        if (z > 0 & y > 0) { z = z - 1; y = y - 1; x = x + 2; meetings++; continue; }
                    }
                    return meetings;
                }
                else { return (-1); }
            }
        }
    }
}






