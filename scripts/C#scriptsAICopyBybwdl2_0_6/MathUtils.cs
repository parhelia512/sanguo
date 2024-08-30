using System;
using System.Text;  // �ṩ�ַ�������
using System.Security.Cryptography;  // ���ڻ�ȡ��ǰʱ��������������

public class MathUtils
{
    // ����m��n���ݣ�long���ͣ�
    public static long pow(long m, long n)
    {
        long result = 1L;
        // ѭ��n�Σ��۳�m
        for (int i = 0; i < n; i++)
        {
            result *= m;
        }
        return result;
    }

    // ����m����n������
    public static int remainder(int m, int n)
    {
        return m % n;
    }

    // ������mתΪ�ֽ����飬���洢��data��
    public static byte[] transToByteArray(int m, byte[] data)
    {
        int i;
        // ���ֽ������ʼ��Ϊ0
        for (i = 0; i < data.Length; i++)
        {
            data[i] = 0;
        }
        // ������mתΪ10���Ƶĸ�λ���֣��������ֽ�����
        for (i = 0; i < data.Length && m > 0; i++)
        {
            int k = remainder(m, 10);  // ��ȡm�ĸ�λ����
            data[i] = (byte)k;  // �����ֽ�����
            m /= 10;  // ȥ��m�ĸ�λ
        }
        return data;
    }

    // ����x��n���ݣ�int���ͣ�
    public static int pow(int x, int n)
    {
        int result = 1;
        // ѭ��n�Σ��۳�x
        for (int i = 0; i < n; i++)
        {
            result *= x;
        }
        return result;
    }

    // ��ʼ���������������ʹ�õ�ǰʱ����Ϊ����
    private static Random random = new Random(DateTime.Now.Millisecond);

    // ��ȡһ��0��maxInt֮����������
    public static int getRandomInt(int maxInt)
    {
        return random.Next(maxInt);
    }

    // �ж��ַ����Ƿ�������
    public static bool isNumeric(string str)
    {
        // ����ַ���Ϊ�գ�����false
        if (string.IsNullOrEmpty(str) || str.Trim() == "")
        {
            return false;
        }

        // �����ַ����е�ÿ���ַ�������Ƿ��������ַ�
        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            if (c < '0' || c > '9')
            {
                return false;
            }
        }

        return true;
    }
}
