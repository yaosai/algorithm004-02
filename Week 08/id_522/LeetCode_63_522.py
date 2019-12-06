
# 48ms   99%
class Solution:
    def uniquePathsWithObstacles(self, obstacleGrid: List[List[int]]) -> int:

        y=len(obstacleGrid)

        x=len(obstacleGrid[0])

        if not obstacleGrid :return 0
        if obstacleGrid[y-1][x-1]==1:return 0
        if obstacleGrid[0][0]==1:return 0

        dp=[[0 for _ in range(x) ] for _ in range(y)]
        #print(dp)
        #for x1 in range(x):
            #dp[y-1][x1]=1
        #for y1 in range(y):
            #dp[y1][x-1]=1

        for y2 in range(y-1,-1,-1):
            for x2 in range(x-1,-1,-1):
                if y2==y-1 and x2==x-1:
                    dp[y2][x2] =1
                    continue
                if obstacleGrid[y2][x2] ==1:continue #it is stone

                if x2==x-1: #reach the right
                    dp[y2][x2]=dp[y2+1][x2]
                elif y2==y-1: #bottom
                    dp[y2][x2]=dp[y2][x2+1]
                else:  #既不是石头，也不是右边和底边
                    dp[y2][x2]=dp[y2+1][x2]+dp[y2][x2+1]

        return dp[0][0]

'''

题解，是从左上角向下推，我是从右下角，反推。

它是初始化后，再进入双重循环，而且利用原来的矩阵，我是新开辟空间。

class Solution(object):
    def uniquePathsWithObstacles(self, obstacleGrid):
        """
        :type obstacleGrid: List[List[int]]
        :rtype: int
        """

        m = len(obstacleGrid)
        n = len(obstacleGrid[0])

        # If the starting cell has an obstacle, then simply return as there would be
        # no paths to the destination.
        if obstacleGrid[0][0] == 1:
            return 0

        # Number of ways of reaching the starting cell = 1.
        obstacleGrid[0][0] = 1

        # Filling the values for the first column
        for i in range(1,m):
            obstacleGrid[i][0] = int(obstacleGrid[i][0] == 0 and obstacleGrid[i-1][0] == 1)

        # Filling the values for the first row        
        for j in range(1, n):
            obstacleGrid[0][j] = int(obstacleGrid[0][j] == 0 and obstacleGrid[0][j-1] == 1)

        # Starting from cell(1,1) fill up the values
        # No. of ways of reaching cell[i][j] = cell[i - 1][j] + cell[i][j - 1]
        # i.e. From above and left.
        for i in range(1,m):
            for j in range(1,n):
                if obstacleGrid[i][j] == 0:
                    obstacleGrid[i][j] = obstacleGrid[i-1][j] + obstacleGrid[i][j-1]
                else:
                    obstacleGrid[i][j] = 0

        # Return value stored in rightmost bottommost cell. That is the destination.            
        return obstacleGrid[m-1][n-1]

作者：LeetCode
链接：https://leetcode-cn.com/problems/unique-paths-ii/solution/bu-tong-lu-jing-ii-by-leetcode/
来源：力扣（LeetCode）
著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。

'''
