

using System.Text;
using System.Text.RegularExpressions;

namespace testTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstPart();
            Console.WriteLine();            
            
            SecondPart();
            Console.WriteLine();            

            ThirdPart();
        }

        static void FirstPart()
        {
            int[] taskInput = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>()
            {
                { 3, "fizz" },
                { 5, "buzz" }
            };

                
            Console.WriteLine("First Part. Input numbers: ");
            for (int i = 0; i < taskInput.Length; i++)
            {
                Console.Write(taskInput[i] + ", ");
            }

            Replacer replacer = new Replacer(taskInput, keyValuePairs);
            replacer.ReplaceWithKeywords();
            string[] answer = replacer.GetResult();

            Console.WriteLine();
            Console.WriteLine("First Part. output strings: ");
            for (int i = 0; i < answer.Length; i++)
            {
                Console.Write(answer[i] + ", ");
            }

        }
        static void SecondPart()
        {
            int[] taskInput = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>()
            {
                { 3, "fizz" },
                { 5, "buzz" },
                { 4, "muzz" },
                { 7, "guzz" }
            };


            Console.WriteLine("Second Part. Input numbers: ");
            for (int i = 0; i < taskInput.Length; i++)
            {
                Console.Write(taskInput[i] + ", ");
            }

            Replacer replacer = new Replacer(taskInput, keyValuePairs);
            replacer.ReplaceWithKeywords();
            string[] answer = replacer.GetResult();

            Console.WriteLine();
            Console.WriteLine("Second Part. output strings: ");
            for (int i = 0; i < answer.Length; i++)
            {
                Console.Write(answer[i] + ", ");
            }

        }

        static void ThirdPart()
        {
            int[] taskInput = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>()
            {
                { 3, "dog" },
                { 5, "cat" },
                { 4, "muzz" },
                { 7, "guzz" }
            };


            Console.WriteLine("Third Part. Input numbers: ");
            for (int i = 0; i < taskInput.Length; i++)
            {
                Console.Write(taskInput[i] + ", ");
            }

            Replacer replacer = new Replacer(taskInput, keyValuePairs);
            replacer.ReplaceWithKeywords();
            replacer.GoodBoyChange();
            string[] answer = replacer.GetResult();

            Console.WriteLine();
            Console.WriteLine("Third Part. output strings: ");
            for (int i = 0; i < answer.Length; i++)
            {
                Console.Write(answer[i] + ", ");
            }

        }
    }
    class Replacer
    {
        private int[] primaryArray;
        private Dictionary<int, string> replacePairs;
        string[] resultList;

        public Replacer(int[] primaryArray, Dictionary<int,string> replacePairs) 
        {
            this.primaryArray = primaryArray;
            this.replacePairs = replacePairs;
            resultList = new string[primaryArray.Length];
        }


        
        public void ReplaceWithKeywords()
        {
            StringBuilder variableResultValue = new StringBuilder();
            
            for (int i = 0; i < primaryArray.Length; i++)
            {
                foreach(var pairs in replacePairs) // Create string that replaces a number
                {
                    if (primaryArray[i]%pairs.Key == 0)
                    {
                        variableResultValue.Append(pairs.Value + "-");                                                
                    }
                }
                if (variableResultValue.Length != 0) // fill with a keywords
                {
                    variableResultValue.Remove(variableResultValue.Length - 1, 1);
                    resultList[i] = variableResultValue.ToString();
                    variableResultValue.Clear();
                }
                else // fill with a primary number
                {
                    resultList[i] = primaryArray[i].ToString();
                }

            }
        }

        public void GoodBoyChange()
        {
            StringBuilder GBResult = new StringBuilder("good-boy-");
            string pattern = @"[a-z]*";
            Regex regex = new Regex(pattern);


            for (int i = 0; i < resultList.Length; i++)
            {
                if (Regex.IsMatch(resultList[i], @"dog") && Regex.IsMatch(resultList[i], @"cat"))
                {
                    resultList[i] = Regex.Replace(resultList[i], @"dog", "");
                    resultList[i] = Regex.Replace(resultList[i], @"cat", "");                    
                    
                    foreach (Match item in regex.Matches(resultList[i]))
                    {
                        if(item.Value != "")
                        {
                            GBResult.Append(item.Value + "-");
                        }
                    }
                    GBResult.Remove(GBResult.Length - 1, 1);

                    resultList[i] = GBResult.ToString();
                    GBResult.Clear();
                    GBResult.Append("good-boy-");
                }
            }
        }

        public string[] GetResult()
        {
            return resultList;
        }
    }
}