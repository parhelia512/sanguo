using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;


// �����黺����
public class ProfileListCache
{
    // �洢����Profile������б�
    public static List<Profile> profiles = new List<Profile>();

    // ��ʼ���������Ӷ����������ж�ȡProfile��Ϣ
    public static void Init(System.Random random, byte[] data)
    {
        int index = 0;

        // ��ȡ�����ֽڣ������н���
        byte byte0 = CommonUtils.byte_bR_a(data[index++], random);
        byte byte1 = CommonUtils.byte_bR_a(data[index++], random);

        // ����profile������
        short profileNum = (short)((byte1 << 8) | (byte0 & 0xFF));

        // ѭ����ȡÿ��Profile
        for (int i = 0; i < profileNum; i++)
        {
            Profile profile = new Profile();

            // ��ȡgeneralId
            byte0 = CommonUtils.byte_bR_a(data[index++], random);
            byte1 = CommonUtils.byte_bR_a(data[index++], random);
            profile.generalId = (short)((byte1 << 8) | (byte0 & 0xFF));

            // ��ȡprofile�ĳ���
            byte profileLength = CommonUtils.byte_bR_a(data[index++], random);
            byte[] profileBytes = new byte[profileLength];

            // ��ȡprofile����
            for (int j = 0; j < profileLength; j++)
            {
                profileBytes[j] = CommonUtils.byte_bR_a(data[index++], random);
            }

            // ����ȡ���ֽ�ת��Ϊ�ַ����������õ�profile������
            string profileStr = Encoding.UTF8.GetString(profileBytes);
            profile.profile = profileStr;

            // ���profile��������
            AddProfile(profile);
        }

        // ��ӡ��ǰ�����е�profile����
        UnityEngine.Debug.Log("Profile����: " + GetProfileSize());
    }

    // ���Profile���б�
    public static void AddProfile(Profile profile)
    {
        profiles.Add(profile);
    }

    // ��ȡ������Profile������
    public static int GetProfileSize()
    {
        return profiles.Count;
    }

    // ����generalId��ȡ��Ӧ��Profile�ַ���
    public static string GetProfile(short generalId)
    {
        string result = string.Empty;

        // ��������Profile������ƥ���generalId
        foreach (Profile profile in profiles)
        {
            if (profile.generalId == generalId)
            {
                if (!string.IsNullOrEmpty(profile.profile?.Trim()))
                {
                    result = profile.profile;
                }
                break;
            }
        }

        return result;
    }

    // ������л����Profile
    public static void clearAllProfiles()
    {
        profiles.Clear();
    }
}
