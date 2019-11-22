// Created by Joshua Boniek 11/21/2019
using System;
using System.Linq;

namespace Mastermind {
  class Gameplay
  {
    int[] answerArray = new int[4];
    int[] userArray   = new int[4];
    string userInput;
    public void GenerateAnswer ()
    {
      Random rnd = new Random();
      for (int i = 0; i < 4; i++)
      {
        answerArray[i] = rnd.Next(1, 7);
      }
    }
    public void Play ()
    {
      Console.WriteLine("Welcome to Mastermind!\nPlease enter a 4 digit number, with each digit between the numbers 1 and 6. (ex: 1246)");
      for(int i=1; i<11; i++){
        Console.Write("Attempt({0}): ",i);
        userInput = Console.ReadLine();
        ParseInput();
        string answer = CheckAnswer();
        if (answer == "++++"){
          Console.WriteLine("Congratulations, you won the game.");
          break;
        }
        else if (i == 10){
          Console.WriteLine("You lost the game.\nCorrect answer: {0}{1}{2}{3}", answerArray[0],answerArray[1],answerArray[2],answerArray[3]);
        }
        else{
          Console.WriteLine(" Result({0}): {1}", i, answer);
        }
      }
    }
    // Converts the user input string into and intiger array and checks for bad input
    void ParseInput ()
    {
      while(true)
      {
        int userInt;
        if(int.TryParse(userInput, out userInt) && userInt >=1111 && userInt <= 6666){
          userArray[0] = userInt / 1000;
          userArray[1] = (userInt - userArray[0] * 1000) / 100;
          userArray[2] = ( (userInt - userArray[0] * 1000) - (userArray[1] * 100) ) / 10;
          userArray[3] = userInt % 10;
          break;
        }
        else{
          Console.WriteLine("Error: \"{0}\" is not a valid input", userInput);
          Console.Write("Please enter a 4 digit number: ");
          userInput = Console.ReadLine();
        }
      }
    }
    // Compares the user input to the actual answer, then formats the output string
    string CheckAnswer ()
    {
      string response = "";
      // countAns & countUsr count the frequency the numbers 1-6 appear
      int[] countAns = new int[6];
      int[] countUsr = new int[6];
      for (int i=0; i<4; i++)
      {
        if (userArray[i] == answerArray[i]){
          response += "+";
        }
        else{
          countAns[answerArray[i]-1] += 1;
          countUsr[userArray[i]-1] += 1;
        }
      }
      for (int i=0; i<6; i++)
      {
        if (countUsr[i] <= countAns[i] && countAns[i] > 0){
          for (int j=0;j<countUsr[i];j++)
          {
            response += "-";
          }
        }
      }
      return response;
    }
  }
  public class ExecuteMastermind
  {
    public static void Main()
    {
      Gameplay g = new Gameplay();
      g.GenerateAnswer();
      g.Play();
      Console.ReadLine();
    }
  }
}
