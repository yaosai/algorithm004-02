/**
 * 64. ��С·����
 ����һ�������Ǹ������� m * n �������ҳ�һ�������Ͻǵ����½ǵ�·����ʹ��·���ϵ������ܺ�Ϊ��С��
 ˵����ÿ��ֻ�����»��������ƶ�һ����
 [
 [1,3,1],
 [1,5,1],
 [4,2,1]
 ]
 �� 7
 *
 * https://leetcode-cn.com/problems/minimum-path-sum/
 *
 * 1. dp: 64 ms , ������ javascript �ύ�л����� 94.09% ���û�
 */

const minPathSum = (grid) => {

    if (grid.length === 0)  return 0

    const r = grid.length
    const c = grid[0].length

    for (let i = 0; i < r; i++) {

        for (let j = 0; j < c; j++) {

            if (i === 0 && j === 0)
                continue
            if (i === 0)
                grid[i][j] += grid[i][j - 1]
            else if (j === 0)
                grid[i][j] += grid[i - 1][j]
            else
                grid[i][j] += Math.min(grid[i][j - 1], grid[i - 1][j])
        }
    }

    return grid[r - 1][c - 1]
}