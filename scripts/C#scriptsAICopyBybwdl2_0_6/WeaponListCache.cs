using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json; // ȷ������ Newtonsoft.Json �����ռ�



// ����������
public static class WeaponListCache
{
    // ��̬�б����ڴ洢��������
    public static List<Weapon> weaponList;


    /*
    // ��ʼ������
    public static void Init(System.Random random, byte[] data)
    {
        int index = 0;
        // ��ȡ����������
        byte weaponNum = CommonUtils.byte_bR_a(data[index++], random);

        // �����ʼ����ʼ����־
        Debug.Log($"��ʼ��������Ϣ��ʼ������: {weaponNum}");

        // ����ÿ������
        for (int i = 0; i < weaponNum; i++)
        {
            Weapon weapon = new Weapon();

            // ��������ID
            weapon.weaponId = CommonUtils.byte_bR_a(data[index++], random);
            // ��ȡ�������Ƶĳ���
            byte weaponNameLength = CommonUtils.byte_bR_a(data[index++], random);

            // ��ȡ��������
            byte[] weaponNameBytes = new byte[weaponNameLength];
            for (int j = 0; j < weaponNameLength; j++)
            {
                weaponNameBytes[j] = CommonUtils.byte_bR_a(data[index++], random);
            }
            weapon.weaponName = Encoding.UTF8.GetString(weaponNameBytes);

            // ��ȡ�����۸�
            byte byte0 = CommonUtils.byte_bR_a(data[index++], random);
            byte byte1 = CommonUtils.byte_bR_a(data[index++], random);
            weapon.weaponPrice = (short)((byte1 << 8) | (byte0 & 0xFF));

            // ��ȡ��������
            weapon.weaponProperties = CommonUtils.byte_bR_a(data[index++], random);
            // ��ȡ��������
            weapon.weaponWeight = CommonUtils.byte_bR_a(data[index++], random);
            // ��ȡ��������
            weapon.weaponType = CommonUtils.byte_bR_a(data[index++], random);

            // ��������ӵ��б���
            addWeapon(weapon);

            // ���������ӵ���־
            Debug.Log($"����ID: {weapon.weaponId}, ����: {weapon.weaponName}, ����: {weapon.weaponType} ��ӵ�����");
        }

        // �����ʼ����ɵ���־
        Debug.Log($"��ʼ��������Ϣ��ɣ���������: {getWeaponSize()}");
    }
    */
    // ����������б�
    public static void addWeapon(Weapon weapon)
    {
        weaponList.Add(weapon);
        // ���������ӳɹ�����־
        Debug.Log($"���� {weapon.weaponName} ����ӵ��б���ǰ��������: {weaponList.Count}");
    }

    // ��ȡ�����б�Ĵ�С
    public static byte getWeaponSize()
    {
        return (byte)weaponList.Count;
    }

    // ��������ID��ȡ����
    public static Weapon getWeapon(byte weaponId)
    {
        foreach (Weapon weapon in weaponList)
        {
            if (weapon.weaponId == weaponId)
            {
                // ����ҵ���������־
                Debug.Log($"�ҵ�����: {weapon.weaponName} (ID: {weaponId})");
                return weapon;
            }
        }
        // ���δ�ҵ���������־
        Debug.LogWarning($"δ�ҵ�����ID: {weaponId}");
        return null;
    }

    // �����������
    public static void clearAllWeapons()
    {
        int count = weaponList.Count;
        weaponList.Clear();
        // ��������������־
        Debug.Log($"������������գ������� {count} ������");
    }
}

// ���ù�����
public static class CommonUtils
{
    // ������л�����Ϣ
    public static void CleanAllInfo()
    {
        CityListCache.clearAllCities();
        CountryListCache.clearAllCountries();
        GeneralListCache.clearAllGenerals();
        GeneralListCache.clearAllNoDebutGenerals();
        WeaponListCache.clearAllWeapons();
        ProfileListCache.clearAllProfiles();
        // ������������Ϣ����־
        Debug.Log("���л�����Ϣ������");
    }

    // �Դ����short����������򣬲�������������������
    public static byte[] Xhpx(short[] val)
    {
        byte[] da = new byte[val.Length];
        for (byte b = 0; b < da.Length; b++)
            da[b] = b;

        for (int i = 0; i < val.Length - 1; i++)
        {
            int min = i;
            for (int k = i + 1; k < val.Length; k++)
            {
                if (val[min] > val[k])
                    min = k;
            }
            if (min != i)
            {
                short temp = val[min];
                val[min] = val[i];
                val[i] = temp;

                byte t = da[i];
                da[i] = da[min];
                da[min] = t;
            }
        }
        return da;
    }

    // ʹ�õ�ǰʱ�����ӳ�ʼ���������������
    private static System.Random random = new System.Random(DateTime.Now.Millisecond);

    // ��ȡһ���������
    public static int getRandomInt()
    {
        return Math.Abs(random.Next());
    }

    // ���ֽڽ�������Ŷ��������ڼ��ܻ����������
    public static byte byte_bR_a(byte byte0, System.Random random)
    {
        byte byte1 = (byte)(byte0 ^ random.Next());
        return byte1;
    }

    // ��鼼�ܵĶ����Ʊ�ʾ�У�������������iλ�Ƿ�Ϊ1
    public static bool HaveSkill(short skill, int i)
    {
        return ((skill >> (10 - i) & 0x1) == 1);
    }
}