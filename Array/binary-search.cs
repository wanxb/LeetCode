namespace Array
{

    #region 704. 二分查找
    /*
     * 给定一个 n 个元素有序的（升序）整型数组 nums 和一个目标值 target  ，写一个函数搜索 nums 中的 target，如果目标值存在返回下标，否则返回 -1。 
        示例 1:
        输入: nums = [-1,0,3,5,9,12], target = 9
        输出: 4
        解释: 9 出现在 nums 中并且下标为 4

        示例 2:
        输入: nums = [-1,0,3,5,9,12], target = 2
        输出: -1
        解释: 2 不存在 nums 中因此返回 -1

        提示：
        你可以假设 nums 中的所有元素是不重复的。
        n 将在 [1, 10000]之间。
        nums 的每个元素都将在 [-9999, 9999]之间。
     */
    #endregion
    internal class binary_search
    {
        /// <summary>
        /// 关键词：有序的（升序）整型数组，所有元素是不重复
        /// 二分查找，注意左闭右闭区间 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;//目标可能在右侧
                }
                else
                {
                    right = mid - 1;//目标可能在左侧
                }
            }
            return -1;
        }

        /// <summary>
        /// 二分查找，注意左闭右开区间 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search2(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;//目标可能在右侧
                }
                else
                {
                    right = mid;//目标可能在左侧
                }
            }
            return -1;
        }

        /// <summary>
        /// 暴力搜索
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search3(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }


        /// <summary>
        /// 704. 二分查找
        /// </summary>
        public static void TestCase()
        {
            int[] nums = [-1, 0, 3, 5, 9, 12];
            int target = 9;
            Console.WriteLine(Search(nums, target));
            Console.WriteLine(Search2(nums, target));
            Console.WriteLine(Search3(nums, target));

            int target2 = 2;
            Console.WriteLine(Search(nums, target2));
            Console.WriteLine(Search2(nums, target2));
            Console.WriteLine(Search3(nums, target2));

            int[] nums3 = [-1];
            int target3 = 1;
            Console.WriteLine(Search(nums3, target3));
            Console.WriteLine(Search2(nums3, target3));
            Console.WriteLine(Search3(nums3, target3));

            int[] nums4 = [-1];
            int target4 = -1;
            Console.WriteLine(Search(nums4, target4));
            Console.WriteLine(Search2(nums4, target4));
            Console.WriteLine(Search3(nums4, target4));

            int[] nums5 = [];
            int target5 = 0;
            Console.WriteLine(Search(nums5, target5));
            Console.WriteLine(Search2(nums5, target5));
            Console.WriteLine(Search3(nums5, target5));
        }
    }
}
