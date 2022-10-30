using System;
using System.IO;
using System.Linq;

namespace WeirdFriends
{
    public sealed class Program
    {
        private Program() { }
        const byte MAX_SCORE = 10;
        const String inputFile = "inputs.txt";

        static void Main()
        {
            if(File.Exists(inputFile) == false)
            {
                Console.Error.WriteLine("ERROR: Input file does not exist. Show this to the instructor ASAP.");
                return;
            }

            (int[] nums, int answer)[] inputs = File.ReadAllLines(inputFile).Select(x => (x.Split().SkipLast<String>(1).Select(x => Convert.ToInt32(x)).ToArray(), Convert.ToInt32(x.Split().Last()))).ToArray();
            float score = MAX_SCORE;
            float scoreDecrement = score / inputs.Length;

            foreach ((int[] nums, int answer) input in inputs)
            {
                int studentAnswer = Source.HowManyFriendshipsSaved(input.nums.Length, input.nums);

                if(studentAnswer != input.answer)
                {
                    Console.WriteLine("Incorrect answer. Expected " + input.answer + " but received " + studentAnswer + ".");
                    score -= scoreDecrement;
                }
            }

            Console.WriteLine($"***Final score: {Math.Round(score, 2)}/{MAX_SCORE}");
        }
    }
}