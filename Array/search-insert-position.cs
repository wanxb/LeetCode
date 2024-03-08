using System.Reflection;

namespace Array
{
    #region 35. 搜索插入位置
    /*
     * 给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
        请必须使用时间复杂度为 O(log n) 的算法。
     
        示例 1:
        输入: nums = [1,3,5,6], target = 5
        输出: 2

        示例 2:
        输入: nums = [1,3,5,6], target = 2
        输出: 1

        示例 3:
        输入: nums = [1,3,5,6], target = 7
        输出: 4

        提示:
        1 <= nums.length <= 104
        -104 <= nums[i] <= 104
        nums 为 无重复元素 的 升序 排列数组
        -104 <= target <= 104
     */
    #endregion
    internal class search_insert_position
    {
        /// <summary>
        /// 根据二分查找左闭右闭方法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int SearchInsert(int[] nums, int target)
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
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return right + 1;
        }
        /// <summary>
        /// 根据二分查找左闭右开方法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>

        public static int SearchInsert2(int[] nums, int target)
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
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return right;
        }

        /// <summary>
        /// 暴力解法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int SearchInsert3(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                {
                    return i;
                }
            }
            return nums.Length;
        }

        /// <summary>
        /// 35. 搜索插入位置
        /// </summary>
        public static void TestCase()
        {
            int[] nums = [1, 3, 5, 6];
            int target = 5;
            Console.WriteLine(SearchInsert(nums, target));
            Console.WriteLine(SearchInsert2(nums, target));
            Console.WriteLine(SearchInsert3(nums, target));

            int target2 = 2;
            Console.WriteLine(SearchInsert(nums, target2));
            Console.WriteLine(SearchInsert2(nums, target2));
            Console.WriteLine(SearchInsert3(nums, target2));

            int target3 = 7;
            Console.WriteLine(SearchInsert(nums, target3));
            Console.WriteLine(SearchInsert2(nums, target3));
            Console.WriteLine(SearchInsert3(nums, target3));
        }
    }
}
