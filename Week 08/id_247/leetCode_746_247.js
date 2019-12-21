/**
 * 746. ʹ����С������¥��
     �����ÿ��������Ϊһ�����ݣ���?i�����ݶ�Ӧ��һ���Ǹ�������������ֵ?cost[i](������0��ʼ)��
     ÿ��������һ�������㶼Ҫ���Ѷ�Ӧ����������ֵ��Ȼ�������ѡ�������һ�����ݻ������������ݡ�
     ����Ҫ�ҵ��ﵽ¥�㶥������ͻ��ѡ��ڿ�ʼʱ�������ѡ�������Ϊ 0 �� 1 ��Ԫ����Ϊ��ʼ���ݡ�
     cost = [10, 15, 20] �� 15
     cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1] �� 6
 *
 * https://leetcode-cn.com/problems/min-cost-climbing-stairs/
 *
 * 1. 84 ms , ������ javascript �ύ�л����� 23.90% ���û�
 * 2. 72 ms , ������ javascript �ύ�л����� 72.20% ���û�
 */

const minCostClimbingStairs = (cost) => {

    const dp = []
    dp[0] = cost[0]
    dp[1] = cost[1]
    const n = cost.length

    for (let i = 2; i < n; i++) {
        dp[i] = Math.min(dp[i-1], dp[i-2]) + cost[i]
    }

    return dp[n - 1] > dp[n-2] ? dp[n-2] : dp[n-1]
}

const minCostClimbingStairs2 = (cost) => {

    const dp = []
    dp[0] = cost[0]
    dp[1] = cost[1]
    cost.push(0)
    const n = cost.length

    for (let i = 2; i < n; i++) {
        dp[i] = Math.min(dp[i-1], dp[i-2]) + cost[i]
    }

    return dp[n - 1]
}


let cost = [0,0,0,1]
console.log( minCostClimbingStairs2(cost) )