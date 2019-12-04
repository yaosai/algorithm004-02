/*
 * @lc app=leetcode.cn id=1122 lang=java
 *
 * [1122] 数组的相对排序
 *
 * https://leetcode-cn.com/problems/relative-sort-array/description/
 *
 * algorithms
 * Easy (62.73%)
 * Likes:    21
 * Dislikes: 0
 * Total Accepted:    7.3K
 * Total Submissions: 11.4K
 * Testcase Example:  '[2,3,1,3,2,4,6,7,9,2,19]\n[2,1,4,3,9,6]'
 *
 * 给你两个数组，arr1 和 arr2，
 * 
 * 
 * arr2 中的元素各不相同
 * arr2 中的每个元素都出现在 arr1 中
 * 
 * 
 * 对 arr1 中的元素进行排序，使 arr1 中项的相对顺序和 arr2 中的相对顺序相同。未在 arr2 中出现过的元素需要按照升序放在 arr1
 * 的末尾。
 * 
 * 
 * 
 * 示例：
 * 
 * 输入：arr1 = [2,3,1,3,2,4,6,7,9,2,19], arr2 = [2,1,4,3,9,6]
 * 输出：[2,2,2,1,4,3,3,9,6,7,19]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * arr1.length, arr2.length <= 1000
 * 0 <= arr1[i], arr2[i] <= 1000
 * arr2 中的元素 arr2[i] 各不相同
 * arr2 中的每个元素 arr2[i] 都出现在 arr1 中
 * 
 * 
 */

// @lc code=start
class Solution {
    public int[] relativeSortArray(int[] arr1, int[] arr2) {
        int[] nums = new int[1001];
        int[] result = new int[arr1.length];
        //遍历arr1,统计每个元素的数量
        for (int i : arr1) {
            nums[i]++;
        }
        //遍历arr2,处理arr2中出现的元素
        int index = 0;
        for (int i : arr2) {
            while (nums[i]>0){
                result[index++] = i;
                nums[i]--;
            }
        }
        //遍历nums,处理剩下arr2中未出现的元素
        for (int i = 0; i < nums.length; i++) {
            while (nums[i]>0){
                result[index++] = i;
                nums[i]--;
            }
        }
        return result;
    }
}
// @lc code=end

