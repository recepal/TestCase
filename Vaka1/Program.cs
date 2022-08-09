
//int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
int[] prices = new int[] {  2, 5 };

int result = FindMaxProfit(prices);

Console.WriteLine(result);

int FindMaxProfit(int[] nums)
{
    Dictionary<int, int> dict = new Dictionary<int, int>();

    for (int i = 0; i < nums.Count() - 1; i++)
    {
        int key = nums[i];
        int val = 0;
        for (int j = i + 1; j < nums.Count(); j++)
        {
            if (nums[j] - key > val)
            {
                val = nums[j] - key;
            }
        }

        if (!dict.ContainsKey(key)) dict.Add(key, val);
    }

    return dict.Values.Any() ? dict.Values.Max() : 0;
}

//dictionaryde max karları tutarız, return olarak da dictionaryinin max value değerini döneriz.