using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameInfo
{
    // ��Ϸ�·�
    public static byte month = 1;
    // ��Ϸ���
    public static short years = 189;
    // ��������ID
    public static byte humanCountryId=1;
    // ��Ϸ�Ѷ�
    public static byte difficult = 3;
    // ��¼��Ϣ����
    public static string[] recordInfo = new string[3];
    // ������б�
    public static List<string> maxRestainList = new List<string>();
    // ѡ����佫����
    public static string chooseGeneralName;
    // ѡ��ľ籾
    public static string chooseScript;
    // ����������ʾ
    public static byte countryDieTips = 0;
    // �Ƿ�ۿ�ģʽ
    public static bool isWatch = false;
    // ��ʾ����Ϣ
    public static string ShowInfo;

    // ��ȡ�û���������
    public static byte GetUserOrderNum()
    {
        // ��ȡ��������ӵ�еĳ�������
        byte CITY_NUM = CountryListCache.GetCountryByCountryId(humanCountryId).GetHaveCityNum();
        
        // ���ݳ�������������������
        if (CITY_NUM < 3)
        {
            CITY_NUM = 3;
        }
        else if (CITY_NUM >= 3 && CITY_NUM <= 4)
        {
            CITY_NUM = 4;
        }
        else if (CITY_NUM >= 5 && CITY_NUM <= 7)
        {
            CITY_NUM = 6;
        }
        else if (CITY_NUM >= 8 && CITY_NUM <= 10)
        {
            CITY_NUM = 7;
        }
        else if (CITY_NUM >= 11)
        {
            CITY_NUM = 8;
        }

        return CITY_NUM;
    }

    // ������Ϸ�·�
    public static void addMonth()
    {
        month = (byte)(month + 1);
        
        if (month > 12)
        {
            years = (short)(years + 1);
            month = 1;
        }
    }



    // ���� maxrestainList ��һ����̬�ֶΣ��洢 General ���͵Ķ���
    public static List<General> maxrestainList = new List<General>();

    /// <summary>
    /// �����佫ID��ȡ�佫����
    /// </summary>
    /// <param name="generalId">�佫��ID��</param>
    /// <returns>����ҵ����򷵻��佫���󣻷��򷵻�null��</returns>
    public static General GetGeneral(short generalId)
    {
        // �����б��е�ÿ��Ԫ��
        foreach (General general in maxrestainList)
        {
            // ����ҵ���ƥ����佫ID���򷵻ظ��佫����
            if (general.generalId == generalId)
            {
                return general;
            }
        }
        Debug.Log("δ�ҵ�ƥ����佫");
        // û���ҵ�ƥ����佫������null
        return null;
    }

    /// <summary>
    /// �ж��Ƿ����Զ�����佫��
    /// </summary>
    /// <returns>������Զ�����佫���򷵻�true�����򷵻�false��</returns>
    public static bool haveCustomGeneral()
    {
        // ��ȡ�佫����
        ReadMaxrestainGeneralFromFile();

        // �ж��б��Ƿ�Ϊ��
        return maxrestainList.Count != 0;
    }

    /// <summary>
    /// ���б���ɾ��ָ�����佫�������浽�ļ���
    /// </summary>
    /// <param name="general">Ҫɾ�����佫����</param>
    /*
    public static void deleteMaxrestainGeneralToFile(General general)
    {
        // ���б����Ƴ�ָ�����佫
        maxrestainList.Remove(general);

        // �����޸ĺ���б��ļ�
        saveMaxrestainGeneralToFile();
    }
    */



    // �����佫��Ϣ���ļ�
    public static void saveMaxRestainGeneralToFile()
    {
        // ����һ���ֽ��������ڴ洢����
        List<General> maxRestainList = getMaxRestainList(); // ��������һ���Ѿ�����õ��б�
        int listSize = maxRestainList.Count;
        byte[] data = new byte[listSize * 200 + 1];

        // ��ǰ����λ��
        int index = 0;

        // �洢�б��С
        data[index++] = (byte)listSize;

        // �����б�
        foreach (var general in maxRestainList)
        {
            // �洢�佫ID
            data[index++] = (byte)(general.generalId & 0xFF);
            data[index++] = (byte)(general.generalId >> 8);

            // ����ͷ��ͼ���ַ���
            string headImageString = general.headImage;
            byte[] headImageBytes = Encoding.UTF8.GetBytes(headImageString);
            data[index++] = (byte)headImageBytes.Length;
            for (int i = 0; i < headImageBytes.Length; i++)
            {
                data[index++] = headImageBytes[i];
            }

            // �����佫�����ַ���
            string generalName = general.generalName;
            byte[] generalNameBytes = Encoding.UTF8.GetBytes(generalName);
            data[index++] = (byte)generalNameBytes.Length;
            for (int j = 0; j < generalNameBytes.Length; j++)
            {
                data[index++] = generalNameBytes[j];
            }

            // �洢��������
            data[index++] = general.level;
            data[index++] = general.force;
            data[index++] = (byte)(general.generalSoldier & 0xFF);
            data[index++] = (byte)(general.generalSoldier >> 8);
            data[index++] = general.lead;
            data[index++] = general.political;
            data[index++] = general.getCurPhysical();
            data[index++] = general.IQ;
            data[index++] = general.getLoyalty();
            data[index++] = (byte)(general.experience & 0xFF);
            data[index++] = (byte)(general.experience >> 8);
            data[index++] = general.weapon;
            data[index++] = general.armor;
            data[index++] = general.army[0];
            data[index++] = general.army[1];
            data[index++] = general.army[2];
            data[index++] = general.maxPhysical;
            data[index++] = general.moral;
            data[index++] = general.leadExp;
            data[index++] = general.forceExp;
            data[index++] = general.IQExp;
            data[index++] = general.moralExp;
            data[index++] = general.politicalExp;
            data[index++] = (byte)(general.phase & 0xFF);
            data[index++] = (byte)(general.phase >> 8);
            data[index++] = (byte)(general.skills[0] & 0xFF);
            data[index++] = (byte)(general.skills[0] >> 8);
            data[index++] = (byte)(general.skills[1] & 0xFF);
            data[index++] = (byte)(general.skills[1] >> 8);
            data[index++] = (byte)(general.skills[2] & 0xFF);
            data[index++] = (byte)(general.skills[2] >> 8);
            data[index++] = (byte)(general.skills[3] & 0xFF);
            data[index++] = (byte)(general.skills[3] >> 8);
            data[index++] = (byte)(general.skills[4] & 0xFF);
            data[index++] = (byte)(general.skills[4] >> 8);
        }

        // �������ݵ��ļ�
        try
        {
            // ʹ��FileStream��������ļ�
            using (FileStream fileStream = File.OpenWrite("newps"))
            {
                // д������
                fileStream.Write(data, 0, index);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("��������ʱ��������: " + ex.Message);
        }
    }

    // ʾ�����������ڻ�ȡ�佫�б�
    private static List<General> getMaxRestainList()
    {
        // ����Ӧ�÷���һ��ʵ�ʵ��佫�б�
        return new List<General>();
    }





    // ���ļ��ж�ȡ�������佫��Ϣ
    public static void ReadMaxrestainGeneralFromFile()
    {
        FileStream fileStream = null;
        try
        {
            // ���Դ��ļ���
            string filePath = Path.Combine(Application.persistentDataPath, "newps.dat"); // �����ļ�Ϊ"newps.dat"
            if (File.Exists(filePath))
            {
                fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                // ����ļ��������ݣ���ȡ���ݲ�����
                if (fileStream.Length > 0)
                {
                    byte[] data = new byte[fileStream.Length];
                    fileStream.Read(data, 0, data.Length);
                    analysisMaxrestainGeneralInfoFromData(data, 0);
                }
            }

            // ���Թر��ļ���
            try
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            catch (IOException e)
            {
                // �����ļ�δ�򿪵��쳣
                Debug.LogError("Error closing file stream: " + e.Message);
            }
            finally
            {
                fileStream = null;
            }
        }
        catch (System.Exception ex)
        {
            // �����쳣�����Թر��ļ���
            Debug.LogError("Error reading general data: " + ex.Message);

            if (fileStream != null)
            {
                try
                {
                    fileStream.Close();
                }
                catch (IOException e)
                {
                    Debug.LogError("Error closing file stream after exception: " + e.Message);
                }
                finally
                {
                    fileStream = null;
                }
            }
        }
    }


    /// <summary>
    /// ������������佫��Ϣ
    /// </summary>
    /// <param name="data">����</param>
    /// <param name="offset">ƫ����</param>


    // �������ݲ�����General�����б�
    private static int analysisMaxrestainGeneralInfoFromData(byte[] data, int index)
    {
        // ������е�General�б�
        maxrestainList.Clear();

        // ��ȡGeneral���������
        byte generalNum = data[index++];
        byte byte1 = 0;
        byte byte2 = 0;

        // ����ÿһ��General����
        for (short i = 0; i < generalNum; i++)
        {
            General general = new General();

            // ����generalId
            byte1 = data[index++];
            byte2 = data[index++];
            general.generalId = (short)((byte2 << 8) | (byte1 & 0xFF));

            // ����headImage
            byte headImageLength = data[index++];
            byte[] headImageBytes = new byte[headImageLength];
            for (byte m = 0; m < headImageLength; m++)
            {
                headImageBytes[m] = data[index++];
            }
            try
            {
                general.headImage = Encoding.UTF8.GetString(headImageBytes);
            }
            catch (System.Exception)
            {
                // �����쳣���
            }

            // ����generalName
            byte generalNameLength = data[index++];
            byte[] generalNameBytes = new byte[generalNameLength];
            for (byte b1 = 0; b1 < generalNameLength; b1++)
            {
                generalNameBytes[b1] = data[index++];
            }
            try
            {
                general.generalName = Encoding.UTF8.GetString(generalNameBytes);
            }
            catch (System.Exception)
            {
                // �����쳣���
            }

            // ������������
            general.level = data[index++];
            general.force = data[index++];
            byte1 = data[index++];
            byte2 = data[index++];
            general.generalSoldier = (short)((byte2 << 8) | (byte1 & 0xFF));
            general.lead = data[index++];
            general.political = data[index++];
            general.setCurPhysical(data[index++]);
            general.IQ = data[index++];
            general.SetLoyalty(data[index++]);
            byte1 = data[index++];
            byte2 = data[index++];
            general.experience = (short)((byte2 << 8) | (byte1 & 0xFF));

            if (general.experience > 0)
            {
                general.experience = 0;
            }

            general.weapon = data[index++];
            general.armor = data[index++];
            general.army[0] = data[index++];
            general.army[1] = data[index++];
            general.army[2] = data[index++];
            general.maxPhysical = data[index++];
            general.moral = data[index++];
            general.leadExp = data[index++];
            general.forceExp = data[index++];
            general.IQExp = data[index++];
            general.moralExp = data[index++];
            general.politicalExp = data[index++];
            general.phase = (short)((data[index + 1] << 8) | (data[index] & 0xFF));
            index += 2;

            // ��������
            for (int j = 0; j < 5; j++)
            {
                general.skills[j] = (short)((data[index + 1] << 8) | (data[index] & 0xFF));
                index += 2;
            }

            // ���������General������ӵ��б�
            maxrestainList.Add(general);
        }

        // ���ص�ǰ��������
        return index;
    }

}
 



