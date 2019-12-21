/*
  ��Ҫ����ݹ飬�γɻ���˼ά�����ҳ���С�ظ���Ԫ��������״̬��״̬ת�Ʒ��̣�������generate parentheses�ǵ���
  �����ӽṹ����̭���Ƽ���������Ҫ������������
  Intuition:
    ��С��Ԫ��ʲô��һ��parentheses��������ֻ�������������
        1�� ������������������Ƕ��ʽ��
        2�� ��������,���ִ���ʽ��
        Ƕ��ʽ�Ŀ���ͨ�������ŵ�indices��ȥ�����ŵ�indices as long as we have one left parentheses to match with the right one
        This means we have to store the indices of last available left parentheses. This reflectes first recusion relation(״̬ת�Ʒ���)
        which we can use a linked list implemented by an rrray which stores the last available left parentheses for the current element 
        of string. ���˼·����˵�һ�����⡣
        ���ڵڶ���������������ǿ��Կ�������������ʵ�Ǵ�����Ϣֵ�ģ����ڶ��ִ������can only happens when the left parentheses is preceded
        by a  right parentheses.

  dp[i][2]����һ����ά���飬
  ÿһ�е�һ��λ�ô���һ�������ŵ�indices���ڶ���Ԫ�ش浱ǰλ�õ���󳤶�

  DP: 
    a. �����⣬
      1�� �ȶ������Ž��и���
        �������ŵĸ����߼���
         1�� �����һ���������ţ�ֱ�Ӽ�¼��һ��indices
         2. �����һ���������ţ�ֱ��copy���¼����һ�������ŵ�ֵ
         ����ƥ���洢���ϸ������ŵ�ֵ ������
        ��longest valid parenthesesֵ�ĸ��£�
      2��
         1. ����������ţ�֪�����γ�һ���������Ŷ��ˣ����Կ�����û����һ��indices,���û�У�ֵΪ-1),��ʲô��������
            ����У���������������һ��match�������ŵľ��� ���ҿ���һ��������λ�ü�¼��ǰ����മ����ǰ׺����ַ�������
            by default, ֵΪ0. �������ֵ��¼������
         2. ����������ţ���Ҫ�ж���û��ǰ׺�������š���ǰ���ǲ��������ţ�����ǣ������ŵĴ洢��ֵ��
    b. dp[i][0, 1] : dp[i][0]: ǰ׺����ַ�������
                      dp[i][1]: ��һ�������ŵ�indice
    c.
    // ��str�ĵڶ���Ԫ�س����� 
    1) if str[i - 1] == '('
        dp[i][0] = i - 1;
       else
        // have match
        dp[i][0] = dp[i - 1][0];

        2) if str[i] == '('
                if (str[i - 1] == ')' dp[i][1] = dp[i - 1][1];
           if str[i] == ')' && dp[i][0] != -1
            {
                // Find a match
                int match = dp[i][0];
                dp[i][1] = i - match + 1 +dp[match][1];
                dp[i][0] = dp[match][0];
            }

    Test Cases:
      1) ()
      2) ()()
      3) (()
      4) (()())
      5) ""
*/
public class Solution {
    public int LongestValidParentheses(string s) {
        int longest = 0;
        if (string.IsNullOrEmpty(s)) return longest;

        int[][] dp = new int[s.Length][];
        for (int i = 0; i < s.Length; i++)
        {
            dp[i] = new int[2];
            dp[i][0] = -1;
            dp[i][1] = 0;
        }

        for (int i = 1; i < s.Length; i++)
        {
            // step 1, update last left parenthesis indice
            if (s[i - 1] == '(')
            {
                dp[i][0] = i - 1;
            }
            else
            {
                dp[i][0] = dp[i - 1][0];
            }

            // step 2, update valid prentheses length and the longest 
            if (s[i] == '(' && s[i - 1] == ')') 
            {
                dp[i][1] = dp[i - 1][1];
            }
            if(s[i] == ')' && dp[i][0] != -1)
            {
                int matchLeftIndice = dp[i][0];
                dp[i][1] = i - matchLeftIndice + 1 + dp[matchLeftIndice][1];
                
                // update the longest
                // safe to do it only here. Because the valid parentheses always end here at right parenthesis position
                longest = Math.Max(longest, dp[i][1]);
                Console.WriteLine(longest);

                // Don't forget update the last available left parenthesis indice
                dp[i][0] = dp[matchLeftIndice][0];
                Console.WriteLine($"Indices: {dp[i][0]}");
            }
        }

        return longest;

    }
}