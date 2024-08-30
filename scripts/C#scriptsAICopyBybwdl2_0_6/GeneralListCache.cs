using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;


public class GeneralListCache 
{
    private static short maxGeneralId = 0;
    public static List<General> totalGeneralList = new List<General>();
    public static List<General> generalList = new List<General>();
    public static List<General> noDebutGeneralList = new List<General>();


    public static void clearAllGenerals()
    {
        // ������н����б�
        generalList.Clear();
    }

    public static void clearAllNoDebutGenerals()
    {
        // ���δ�ǳ��Ľ����б�
        noDebutGeneralList.Clear();
        maxGeneralId = 0;
    }

    public static void DebutByYears(short years)
    {
        // ����ָ��������ý���ǳ�
        if (noDebutGeneralList.Count == 0)
        {
            return; // ���û��δ�ǳ��Ľ��죬��ֱ�ӷ���
        }

        for (int i = 0; i < noDebutGeneralList.Count; i++)
        {
            General general = noDebutGeneralList[i];
            if (general.debutYears <= years) // ����ý���ĵǳ����С�ڻ���ڵ�ǰ���
            {
                // �Ƴ�δ�ǳ������б��еĵ�ǰ���죬����������ѵǳ������б�
                noDebutGeneralList.RemoveAt(i);
                i--; // ��Ϊ�Ƴ���Ԫ�أ�������Ҫ����������һλ
                generalList.Add(general);
                noDebutGeneralList.Remove(general);

                byte cityId = general.debutCity; // ��ȡ����ĵǳ�����ID
                if (general.followGeneralId != 0) // ����ý��������������
                {
                    short followCityId = general.followGeneralId;
                    General followGeneral = GetGeneral(followCityId); // ��ȡ����Ľ���
                    if (followGeneral != null)
                    {
                        cityId = followGeneral.debutCity; // ���³���IDΪ���潫��ĵǳ�����
                        City city = CityListCache.GetCityByCityId(cityId);
                        if (followGeneral.isOffice == 1) // �������Ľ����ǹ�Ա
                        {
                            if (city.getCityGeneralNum() >= 10) // ������й�Ա��������
                            {
                                if (city.GetOppositionGeneralNum() < 10) // ������зǹ�Ա����δ��
                                {
                                    city.AddOppositionGeneralId(general.generalId);
                                    Debug.Log("���潫"+general.generalName+"ǰ��"+city.cityName+"��Ұ");
                                }
                            }
                            else // ������й�Ա����δ��
                            {
                                city.AddOfficeGeneralId(general.generalId);
                                Debug.Log("���潫"+general.generalName+"��Ϊ"+city.cityName+"�Ĺ�Ա");
                            }
                        }
                        else if (city != null) // ������д���
                        {
                            if (city.GetOppositionGeneralNum() < 10) // ������зǹ�Ա����δ��
                            {
                                city.AddOppositionGeneralId(general.generalId);
                                Debug.Log("�佫"+general.generalName+"ǰ��"+city.cityName+"��Ұ");
                            }
                        }
                    }
                }
                else if (general.debutCity == 0) // �������û��ָ���ĵǳ�����
                {
                    cityId = (byte) UnityEngine.Random.Range(0,CityListCache.CITY_NUM); // ���ѡ��һ������ID
                    City city = CityListCache.GetCityByCityId(cityId);
                    city.AddNotFoundGeneralId(general.generalId); // ��������ӵ����е�δ�ҵ������б�
                    Debug.Log("�佫"+general.generalName+"ǰ��"+city.cityName+"����");
                }
                else
                {
                    City city = CityListCache.GetCityByCityId(general.debutCity);
                    city.AddNotFoundGeneralId(general.generalId); // ��������ӵ�ָ�����е�δ�ҵ������б�
                    Debug.Log("�佫"+general.generalName+"ǰ��"+city.cityName+"����");
                }
            }
        }
    }


    /// <summary>
    /// �����佫ID��ȡ�佫����
    /// </summary>
    /// <param name="generalId">�佫ID</param>
    /// <returns>�ҵ����佫�������û���ҵ��򷵻�null</returns>
    public static General GetGeneral(int generalId)
    {
        // �����佫�б�
        for (int i = 0; i < generalList.Count; i++)
        {
            General general = generalList[i];
            // ����ҵ�ƥ����佫ID���򷵻ظ��佫����
            if (general.generalId == generalId)
            {
                return general;
            }
        }
        // ���û���ҵ�ƥ����佫����ӡ������Ϣ������null
        UnityEngine.Debug.Log("��ȡ�佫����,generalId:" + generalId);
        return null;
    }

    /// <summary>
    /// ����������ȡ�佫����
    /// </summary>
    /// <param name="indexId">����ID</param>
    /// <returns>ָ������λ�õ��佫����</returns>
    public static General GetGeneralByIndex(short indexId)
    {
        // ֱ��ͨ��������ȡ�佫����
        return generalList[indexId];
    }

    /// <summary>
    /// ����������ȡδ�ǳ����佫����
    /// </summary>
    /// <param name="indexId">����ID</param>
    /// <returns>ָ������λ�õ�δ�ǳ��佫����</returns>
    public static General GetNoDebutGeneralByIndex(short indexId)
    {
        // ֱ��ͨ��������ȡδ�ǳ����佫����
        return noDebutGeneralList[indexId];
    }

    /// <summary>
    /// ��ȡδ�ǳ����佫����
    /// </summary>
    /// <returns>δ�ǳ��佫������</returns>
    public static short GetTotalNoDebutGeneralNum()
    {
        // ����δ�ǳ��佫������
        int count = 0;
        for (int i = 0; i < noDebutGeneralList.Count; i++)
        {
            General general = noDebutGeneralList[i];
            // �������Ϊ�գ��������һ
            if (general != null) count++;
        }
        // ����δ�ǳ��佫������
        return (short)count;
    }



    /// <summary>
    /// ��ȡ�����佫����
    /// </summary>
    /// <returns>�ܵ��佫����</returns>
    public static short GetTotalGeneralNum()
    {
        int count = 0; // ��ʼ��������

        foreach (General general in generalList) // �����佫�б�
        {
            if (general == null)
            {
                break; // ���Ԫ��Ϊ�գ����˳�ѭ��
            }
            count++; // ���Ӽ�����
        }

        return (short)count; // ���ؼ������
    }

    /// <summary>
    /// ���δ������佫
    /// </summary>
    /// <param name="general">�佫����</param>
    public static void AddNoDebutGeneral(General general)
    {
        if (general.generalId > maxGeneralId)
        {
            maxGeneralId = general.generalId; // ��������佫ID
        }

        noDebutGeneralList.Add(general); // ��ӵ�δ�����佫�б�
    }

    /// <summary>
    /// ����佫
    /// </summary>
    /// <param name="general">�佫����</param>
    public static void AddGeneral(General general)
    {
        if (general.generalId == -1)
        {
            general.generalId = (short)(maxGeneralId + 1); // ���IDΪ0��������µ�ID
        }

        if (general.generalId > maxGeneralId)
        {
            maxGeneralId = general.generalId; // ��������佫ID
        }

        generalList.Add(general); // ��ӵ��佫�б�
    }



    // ���佫����ʱ���ô˷���
    public static void GeneralDie(short generalId)
    {
        // ��ȡָ��ID���佫����
        General general = GetGeneral(generalId);

        // ����佫�����ڣ��򷵻�
        if (general == null)
            return;

        // ���õ�ǰѡ����佫����
        GameInfo.chooseGeneralName = general.generalName;

        // ��ȡ�佫���ڵĳ���ID
        byte cityId = general.debutCity;

        // ͨ������ID��ȡ���ж���
        City city = CityListCache.GetCityByCityId(cityId);

        // �Ƴ������еĹ�Ա�б��е��佫ID
        city.removeOfficeGeneralId(generalId);

        // �Ƴ������е�ʧ���佫�б��е��佫ID
        city.removeNotFoundGeneralId(generalId);

        // �Ƴ������еĵж��佫�б��е��佫ID
        city.RemoveOppositionGeneralId(generalId);

        // ���佫�Ƿ���ְ����Ϊ0���ٶ�0��ʾ����ְ��
        general.isOffice = 0;

        // ͨ������ID��ȡ��������
        Country country = CountryListCache.GetCountryByKingId(generalId);

        // �����������
        if (country != null)
        {
            // ���������������Ϣ
            Debug.Log("������" + general.generalName + "������!!");

            // �������ҿ��Ƶ�����
            if (GameInfo.humanCountryId == country.countryId)
            {
                // ������ʾ��ϢΪ��������
                GameInfo.ShowInfo = general.generalName + " ��������!";

                // ����������г���
                if (country.GetHaveCityNum() > 0)
                {
                    // ��������������ʾΪ�ض�ֵ
                    GameInfo.countryDieTips = 2;
                }
                else
                {
                    // ��������������ʾΪ��һ��ֵ
                    GameInfo.countryDieTips = 3;

                    // ������ʾ��ϢΪ��������
                    GameInfo.ShowInfo = general.generalName + " ����������!";
                }
            }
            else
            {
                // ��ȡ����ӵ�еĳ�������
                byte CITY_NUM = country.GetHaveCityNum();

                // ����������г���
                if (CITY_NUM > 0)
                {
                    // ���ֻ��һ������������ս����
                    if (CITY_NUM == 1 && WarInfo.curWarCityId == country.getCity(0))
                    {
                        // ��������������ʾΪ�ض�ֵ
                        GameInfo.countryDieTips = 4;

                        // ������ʾ��ϢΪ��������
                        GameInfo.ShowInfo = general.generalName + " ����������!";
                    }
                    else
                    {
                        // ��������������ʾΪ��һ��ֵ
                        GameInfo.countryDieTips = 1;

                        // �̳��µľ���
                        int newKingGeneralId = country.Inherit();

                        // ������ʾ��ϢΪ�¾�����λ
                        GameInfo.ShowInfo = general.generalName + "����,�¾��� " + GetGeneral(newKingGeneralId).generalName + " ��λ!";
                    }
                }
                else
                {
                    // ��������������ʾΪ�ض�ֵ
                    GameInfo.countryDieTips = 4;

                    // ������ʾ��ϢΪ��������
                    GameInfo.ShowInfo = general.generalName + " ����������!";
                }
            }
        }
        else
        {
            // ������Ǿ������������ͨ�佫��������Ϣ
            Debug.Log("�佫��" + general.generalName + "������!!");
        }
    }




    /// <summary>
    /// �����쵼������ֵ
    /// </summary>
    /// <param name="generalId">�佫ID</param>
    /// <param name="exp">����ֵ</param>
    public static void addLeadExp(short generalId, byte exp)
    {
        General general = GetGeneral(generalId);
        if (general != null)
        {
            general.addLeadExp(exp);
        }
    }

    /// <summary>
    /// ������������ֵ
    /// </summary>
    /// <param name="generalId">�佫ID</param>
    /// <param name="exp">����ֵ</param>
    public static void addforceExp(short generalId, byte exp)
    {
        General general = GetGeneral(generalId);
        if (general != null)
        {
            general.addforceExp(exp);
        }
    }

    /// <summary>
    /// �������̾���ֵ
    /// </summary>
    /// <param name="generalId">�佫ID</param>
    /// <param name="exp">����ֵ</param>
    public static void addIQExp(short generalId, byte exp)
    {
        General general = GetGeneral(generalId);
        if (general != null)
        {
            general.addIQExp(exp);
        }
    }

    /// <summary>
    /// ����������������ֵ
    /// </summary>
    /// <param name="generalId">�佫ID</param>
    /// <param name="exp">����ֵ</param>
    public static void addPoliticalExp(short generalId, byte exp)
    {
        General general = GetGeneral(generalId);
        if (general != null)
        {
            general.addPoliticalExp(exp);
        }
    }

    /// <summary>
    /// ���ӵ��о���ֵ
    /// </summary>
    /// <param name="generalId">�佫ID</param>
    /// <param name="exp">����ֵ</param>
    public static void addMoralExp(short generalId, byte exp)
    {
        General general = GetGeneral(generalId);
        if (general != null)
        {
            general.addMoralExp(exp);
        }
    }
}


// ս����Ϣ�࣬���ڴ洢��ս����صľ�̬����
public static class WarInfo
{
    // ��ǰս�������ĳ���ID
    public static byte curWarCityId;
}

[System.Serializable]
public class RootObject
{
    public List<General> generals;
}