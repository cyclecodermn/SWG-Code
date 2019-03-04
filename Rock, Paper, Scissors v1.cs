using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
    {
    class Program
    {

        static void Main(string[] args)
        {
            // Rock loses to paper  -- Paper loses to Scissors  -- Paper loses to Scissors
            //      1 loses to 2            2 loses to 3        --      3 loses to 1


            int numRounds = -1, continueChoice = -1;
            bool playAgain = true;
            do
            {
                ShowIntro();
                numRounds = GetNumRounds();
                DoAllRounds(numRounds);
                Console.WriteLine("Would you like to play again (1=Yes, 2=No)");
                continueChoice = GetNumFromUser(2)+1;
                if (continueChoice==2) { playAgain = false; }

            } while (playAgain);
        }

        static void DoAllRounds(int numRounds)
        {
            int roundOutCome, computerWon = 0, userWon = 0, ties = 0;

            for (int i = 1; i <= numRounds; i++)
            {
                roundOutCome = Do1Round(i, numRounds, computerWon, userWon, ties);
                if (roundOutCome == 0) { userWon++; }
                else if (roundOutCome == 1) { computerWon++; }
                else { ties++; }
            }
            Console.Clear();
            Console.WriteLine("---- Round Summary ----");
            ShowHeader(numRounds, numRounds, userWon, computerWon, ties);
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            
        }

        static void ShowHeader(int roundNum, int numRounds, int userWon, int computerWon, int ties)
        {
            Console.WriteLine($"Round {roundNum} of {numRounds}.");
            Console.WriteLine($"You won {userWon}. You lost {computerWon}, and there are {ties} tie(s)");
            Console.WriteLine();
        }
        static int Do1Round(int roundNum, int numRounds, int computerWon, int userWon, int ties)
        {
            int cmptrNum = -1, userNum = -1, roundOutcome = -1;

            Console.Clear();
            ShowHeader (roundNum, numRounds, userWon, computerWon, ties);

            ShowRules();
            userNum = GetNumFromUser(3);
            cmptrNum = cmpterGuess();

            showChoices(userNum, cmptrNum);
            roundOutcome = GetGameOutcome(userNum, cmptrNum);
            showWinner(roundOutcome);

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            return roundOutcome;
        }

        static int GetNumRounds()
        {
            Console.WriteLine("You can play up to 10 rounds. How many would you like to play?");
            return GetNumFromUser(10)+1;
            // Note +1 is added to the return statement because the same input
            // routine is used for all input. That routine subtracts 1 in the return
            // since people start at 1 and C starts at zero, which is used elsewhere.
        }

        static void ShowIntro()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Rock, Paper, Scissors--by Steven Malikowski.");
            Console.WriteLine();
        }

        static void ShowRules()
        {
            Console.WriteLine("You can choose 1 for rock, 2 for paper, and 3 for scissors.");
        }

        static int GetNumFromUser(int maxNum)
            // Return a number from user that's between 1 and maxNum
            // The end of this routine decrements the number,
            // so the range is between zero and maxNum.
        {
            int userNum = -1;
            string userChoice = "";
            bool invalidChoice = true;

            do
            {
                Console.WriteLine($"Please choose a number between 1 and {maxNum}.");
                userChoice = Console.ReadLine();

                if (!int.TryParse(userChoice, out userNum))
                {
                    Console.WriteLine("That was not a valid number.");
                }
                else if ((userNum > maxNum) || (userNum < 1))
                {
                    Console.WriteLine("That was not a valid number.");
                }
                else
                {
                    invalidChoice = false;
                }
            } while (invalidChoice);
            return userNum-1;
        }

        static void showChoices(int userNum, int cmptrNum)
        {
            string[] theChoice = { "rock", "paper", "scissors" };
            string userChoice = "", compChoice = "";

            userChoice = theChoice[userNum];
            compChoice = theChoice[cmptrNum];
            Console.WriteLine($"User chose {userChoice}, and computer chose {compChoice}.");
        }

        static int cmpterGuess()
        {
            // Return a random number between 0 and 2 for the computer's guess.

            int computerGuess = -1;

            Random random = new Random();
            computerGuess = random.Next(0, 3);
            return computerGuess;
        }

        static void testResults()
        {
            //Test all possible options, including ties

            string[] theChoice = { "Rock", "Paper", "Scissors" }, theWinner = { "User", "Computer", "Tie" };
            string userChoice = "", compChoice = "";
            int roundOutcome = -1;
            // int cmptrNum = 2, userNum,;

            bool userWon = false;

            for (int cmptrNum = 0; cmptrNum <= 2; cmptrNum++)
            {
                for (int userNum = 0; userNum <= 2; userNum++)
                {

                    roundOutcome = GetGameOutcome(userNum, cmptrNum);

                    userChoice = theChoice[userNum];
                    compChoice = theChoice[cmptrNum];
                    Console.WriteLine($"User chose {userChoice}, and Computer chose {compChoice}. Winner is {theWinner[roundOutcome]}.");
                    //cmptrNum--;
                }
                //Console.WriteLine( DidUserWin(1,2));
                Console.ReadLine();
            }
        }

        static int GetGameOutcome(int gameUser, int gameComp)
        {

            int rock = 0, paper = 1, scis = 2;
            int userWon = 0, compWon = 1, tie = 2;

            int outcome = -1;

            if ((gameUser == rock) && (gameComp == paper)) { outcome = compWon; }
            else if ((gameUser == paper) && (gameComp == scis)) { outcome = compWon; }
            else if ((gameUser == scis) && (gameComp == rock)) { outcome = compWon; }

            else if ((gameComp == rock) && (gameUser == paper)) { outcome = userWon; }
            else if ((gameComp == paper) && (gameUser == scis)) { outcome = userWon; }
            else if ((gameComp == scis) && (gameUser == rock)) { outcome = userWon; }

            if (gameUser == gameComp) { outcome = tie; }

            return outcome;

        }
        static void showWinner(int roundOutcome)
        {
            string[] theWinner = { "won", "lost", "tied" };
            Console.WriteLine($"You {theWinner[roundOutcome]} this round.");
        }

    }
}
