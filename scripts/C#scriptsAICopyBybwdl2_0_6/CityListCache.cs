using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


// City ��������ڱ�ʾ���еĸ�������
[System.Serializable]
public class CityListCache : MonoBehaviour
{

    // ��̬�б����ڴ洢��������
    public static List<City> cityList;

    // �����������+1�ĳ���
    public static byte CITY_NUM = 49;
    // �ճǼ���
    public static List<City> unassignedCities = new List<City>();


    //��ӿճǼ���
    public static void addUnassignedCities()
    {
        foreach (City city in cityList)
        {
            if (city.cityBelongKing == 0)
            {
                unassignedCities.Add(city);
            }
        }
    }

    // ������г����б�
    public static void clearAllCities()
    {
        cityList.Clear();
    }

    // ���ݳ���ID��ȡ���ж���
    public static City GetCityByCityId(byte id)
    {
        foreach (City city in cityList)
        {
            if (city.cityId == id)
            {
                return city;
            }
        }

        Debug.LogError("��ȡ�ǳش���, CityId: " + id);
        return null;
    }


    // ����������ȡ���ж���
    public static City getCityByIndex(int index)
    {
        // ���������Χ�������ض�Ӧ�ĳ���
        if (index >= 0 && index < cityList.Count)
            return cityList[index];

        Debug.Log("����������Χ: " + index);
        return null;
    }

    // ��ӳ��е��б�
    public static void AddCity(City city)
    {
        cityList.Add(city);
    }

    // ��ȡ��������
    public static byte getCityNum()
    {
        return (byte)cityList.Count;
    }
}

