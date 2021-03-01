using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2_ComputationalProbSolv_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question1:
            Console.WriteLine("Question 1");
            int[] ar1 = { 2, 5, 1, 3, 4, 7 };
            int n1 = 3;
            ShuffleArray(ar1, n1);

            //Question 2
            Console.WriteLine("Question 2");
            int[] ar2 = { 0, 1, 0, 3, 12 };
            MoveZeroes(ar2);
            Console.WriteLine("");

            //Question3:
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            ////Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 2, 7, 11, 15 };
            int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            ////Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s5, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s61 = "bulls";
            string s62 = "sunny";
            if (Isomorphic(s61, s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 }, { 2, 50 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            if (HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number", n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }
            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if (profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}", profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 3;
            Stairs(n10);
            Console.WriteLine();
        }

        // Question1:
        private static void ShuffleArray(int[] nums, int n)
        {
            try
            {
                int[] final = new int[2 * n];
                int a = 0;
                for (int i = 0; i < n; i++) //looping till middle of array(n)
                {
                    // compute first element of final array from first half of input array
                    final[a++] = nums[i];
                    // compute second element of final array from second half of input array
                    final[a++] = nums[i + n];
                }
                Console.Write("shuffled array: ");
                //looping till total length of ar1(2n) and printing final array
                for (int i = 0; i < 2 * n; i++)
                {
                    Console.Write(final[i] + " ");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question2:
        private static void MoveZeroes(int[] nums)
        {
            try
            {
                int currentFirstZero = -1; //initializing current first zero position to -1 because first zero not found yet
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0 && currentFirstZero == -1) continue; //if current zero not found and element is non-zero we continue
                    if (nums[i] == 0 && currentFirstZero != -1) continue; //if current zero is found and element is zero, we continue
                    if (currentFirstZero == -1) //if current first zero not found and element is zero, we consider current position of zero as first zero
                    {
                        currentFirstZero = i;
                        continue;
                    }
                    //Swapping element in ithe index with element in current first zeroth element
                    int t = nums[currentFirstZero];
                    nums[currentFirstZero] = nums[i];
                    nums[i] = t;
                    currentFirstZero++;
                }
                var result = $"[{string.Join(", ", nums)}]"; //making result in the relevant string form
                Console.WriteLine(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question3:
        private static void CoolPairs(int[] nums)
        {
            try
            {
                Dictionary<int, int> allPairs = new Dictionary<int, int>();
                //adding key(distinct elements) value(count) pairs to allPairs dictionary if key does not exist already for each element in input array 
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!allPairs.ContainsKey(nums[i]))
                    {
                        allPairs.Add(nums[i], 1);
                    }
                    else
                    {
                        allPairs[nums[i]] += 1;
                    }
                }
                // computing no.of cool pairs possible using count information
                Dictionary<int, int>.KeyCollection CoolKeys = allPairs.Keys;
                int total = 0;
                foreach (int k in CoolKeys)
                {
                    total += (allPairs[k] * (allPairs[k] - 1) / 2);
                }
                Console.WriteLine("No. of cool pairs: " + total);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question4:
        private static void TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> allIndices = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    //for every element, checking if (target - element) is present in the dictionary keys and printing the correspinding indices
                    if (allIndices.ContainsKey(target - nums[i]))
                    {
                        Console.WriteLine("Indices:" + allIndices[target - nums[i]] + "," + i);
                        break;
                    }
                    //adding the key-value pairs to dictionary as we iterate through all elements of array
                    allIndices.Add(nums[i], i);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question5:
        private static void RestoreString(string s, int[] indices)
        {
            try
            {
                //create new dictionary and add keys(indices) and values(items)
                Dictionary<int, String> shuffle = new Dictionary<int, String>();
                for (int i = 0; i < s.Length; i++)
                {
                    shuffle.Add(indices[i], s[i].ToString());
                }
                string result = "";
                //fetching element corresonding to each index from the dictionary and printing result
                for (int i = 0; i < s.Length; i++)
                {
                    result += shuffle[i];
                }
                Console.WriteLine("shuffled string: " + result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question6:
        private static bool Isomorphic(string s, string t)
        {
            try
            {
                Dictionary<char, char> isomorphic = new Dictionary<char, char>();
                //case where strings are not of equal length
                if (s.Length != t.Length)
                {
                    return false;
                }
                for (int i = 0; i < s.Length; i++)
                {
                    //check if two diffrent keys are mapped to the same values.
                    if (!(isomorphic.ContainsKey(s[i]) || isomorphic.ContainsValue(t[i])))
                    {
                        isomorphic.Add(s[i], t[i]);
                    }
                    // case where same key not there in dictionary or value does not match
                    else if (!isomorphic.ContainsKey(s[i]) || isomorphic[s[i]] != t[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question7:
        private static void HighFive(int[,] items)
        {
            try
            {
                //create dictionary with ID and list of scores as key value pairs
                Dictionary<int, List<int>> scoresById = new Dictionary<int, List<int>>();
                for (int i = 0; i < items.GetLength(0); i++)
                {
                    int thisId = items[i, 0];
                    int thisScore = items[i, 1];
                    if (!scoresById.ContainsKey(thisId))
                    {
                        scoresById.Add(thisId, new List<int>()); //if ID already not encountered, add ID and empty list pair
                    }
                    scoresById[thisId].Add(thisScore); //if same ID encountered again, add the score to the internal list
                }
                int[][] result = new int[scoresById.Count][]; //initializing result wanted
                var index = 0;
                foreach (var keyValuePair in scoresById.OrderBy(kvp => kvp.Key)) //sorting elements by ID
                {
                    //storing keys in id and values in scores variables
                    //computing sum of top5 scores and average from it
                    var id = keyValuePair.Key;
                    var scores = keyValuePair.Value;
                    var top5Sum = scores.OrderByDescending(s => s).Take(5).Aggregate(0, (sum, score) => sum + score); //sort by descending order so we consider top five scores
                    int average = top5Sum / 5;
                    result[index++] = new int[] { id, average }; //store array having ID and Average inside index of result
                }
                //preparing the result array in relevant string format
                var finalResultStringArray = result.Select(ele => $"[{string.Join(", ", ele)}]");
                var finalResultString = $"[{string.Join(", ", finalResultStringArray)}]";
                Console.WriteLine(finalResultString); //printing output string
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Question8:
        private static bool HappyNumber(int n)
        {
            Func<int, HashSet<int>, bool> HappyNumberInternal = null; //function with integer and hashset parameters and returns bool result
            HappyNumberInternal = (int n, HashSet<int> alreadyEncountered) => //recursive function 
            {
                if (n == 1) return true; //if n=1, it is already happy
                if (alreadyEncountered.Contains(n)) return false; //if n is already present in hashset, it is not happy
                alreadyEncountered.Add(n); //storing n in hashset
                //computing sum of squares of the digit
                int sum = 0;
                while (n != 0)
                {
                    int currentDigit = n % 10;
                    sum += currentDigit * currentDigit;
                    n = n / 10;
                }
                return HappyNumberInternal(sum, alreadyEncountered); //returning if sum is a happy number or not by recursively calling same function
            };
            try
            {
                //initializing new hashset
                HashSet<int> alreadyEncountered = new HashSet<int>();
                return HappyNumberInternal(n, alreadyEncountered); //returning if n is happy number or not
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Question9:
        private static int Stocks(int[] prices)
        {
            try
            {
                //initialize current highest(sell value) and highest profit values to minimum
                int currentHighest = int.MinValue;
                int highestProfit = int.MinValue;
                //
                for (int i = prices.Length - 1; i >= 0; i--)
                {
                    int current = prices[i];
                    //case where buy value is more than sell value, set new sell value = current buy value
                    if (current > currentHighest)
                    {
                        currentHighest = current;
                        continue;
                    }
                    //calculating the profit and compare it with already encountered max.
                    int currentProfit = currentHighest - current;                  
                    if (currentProfit > highestProfit)
                        highestProfit = currentProfit;
                }
                return highestProfit; //return max profit that can be earned
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question10:
        private static void Stairs(int n)
        {
            try
            {
                //initialize result to 0 and first second variables to 1
                int result = 0;
                int first = 1;
                int second = 1;
                //if 0 or 1 steps, the no. of ways equals no. of steps itself
                if (n <= 1)
                {
                    result = n;
                }
                //Each time we increment n, the number of ways to climb the staircase(current number)equals the sum of the previous two ways(first and second)
                for (int i = 2; i <= n; i++)
                {
                    int curr = first + second;
                    //move first over to equal second, and second to equal current
                    first = second;
                    second = curr;
                }
                //return second and print result
                result = second;
                Console.WriteLine("No. of unique ways:" + result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}




