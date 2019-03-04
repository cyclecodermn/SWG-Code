using System;

namespace FruitSalad
{
    class Program
    {
        static void Main(string[] args)
        {
            //Apparently the best kind of fruit salad has:

            //As many berries as possible
            //No more than 3 kinds of apples
            //No more than 2 kinds of orange
            //Definitely no tomatoes
            //More than 12 kinds of fruit isn't recommended

            //Write some code to sort through fruits below and put all the proper fruits in the fruitSalad 
            //array. Afterwards, print out the total number and types of fruit in your fruit salad!

            String[] fruit = { "Kiwi Fruit", "Gala Apple", "Granny Smith Apple", "Cherry Tomato", "Gooseberry", "Beefsteak Tomato", "Braeburn Apple", "Blueberry", "Strawberry", "Navel Orange", "Pink Pearl Apple", "Raspberry", "Blood Orange", "Sungold Tomato", "Fuji Apple", "Blackberry", "Banana", "Pineapple", "Florida Orange", "Kiku Apple", "Mango", "Satsuma Orange", "Watermelon", "Snozzberry" };
            String[] goodStuff = { "berries", "apples", "orange" };

            string[] fruitSalad = new string[130];
            string[] allBerries = new string[130];
            string[] allApples = new string[130];
            string[] allOranges = new string[130];


            int[] numbers = new int[4];

            // Code Recipe for fruit salad should go here!

            int berryCount =0, appleCount = 0, orangeCount = 0;
            int fruitSaladCount = 0;
            int i = 0, j = 0;

            for (i=0; i< fruit.Length-1; i++)
            {
                //Console.WriteLine(fruit[i]);
                //Console.Write("\t\tberry="+ findFoodType(fruit[i], "berry\tBBB")+ berryCount);
                //Console.WriteLine("\tApple=" + findFoodType(fruit[i], "Apple\tAAA")+ appleCount);

                //if (findFoodType(fruit[i], "berry")) { berryCount++; }
                // if (findFoodType(fruit[i], "Apple")) { appleCount++; }
                // if (findFoodType(fruit[i], "Orange")) { orangeCount++; }


                if (findFoodType(fruit[i], "berry"))
                {
                    allBerries[berryCount] = fruit[i];
                    berryCount++;
                    //fruitSalad[fruitSaladCount] = fruit[i];
                    fruitSaladCount++; }

                if (findFoodType(fruit[i], "Apple"))
                {
                    allApples[appleCount] = fruit[i];
                    appleCount++;
                    //fruitSalad[fruitSaladCount] = fruit[i];
                    fruitSaladCount++; }

                if (findFoodType(fruit[i], "Orange"))
                {
                    allOranges[orangeCount] = fruit[i];
                    orangeCount++;
                    //fruitSalad[fruitSaladCount] = fruit[i];
                    fruitSaladCount++; }

                //                if (i % 2 == 0) Console.WriteLine();
            }
            Console.WriteLine($"There are {berryCount} berries. There are {appleCount} apples. There are {orangeCount} oranges.");

            Console.WriteLine();

            fruitSalad[0] = allApples[0];
            fruitSalad[1] = allApples[1];
            fruitSalad[2] = allApples[2];
            fruitSalad[3] = allOranges[0];
            fruitSalad[4] = allOranges[1];


            j = 0;
            for (i = 5; i < 12; i++)
            {
                fruitSalad[i] = allBerries[j];
                j++;
            }
            //string[] fruitSalad = new string[130];
            //string[] allBerries = new string[130];
            //string[] allApples = new string[130];
            //string[] allOranges = new string[130];


            for (i = 0; i < fruitSaladCount; i++)
            {
                Console.WriteLine(fruitSalad[i]);
            }
            Console.WriteLine(fruitSaladCount);
            Console.ReadKey();

        }
        static bool findFoodType(string aFood, string aType)
        {
            //Console.WriteLine($"Food is {aFood}. Food type is {aType}.");

            int startIndex = aFood.IndexOf(aType);

            return (startIndex>0);

        }
    }
}