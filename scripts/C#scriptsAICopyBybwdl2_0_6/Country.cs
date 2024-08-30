using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class Country
{    // ���幫�����ֶ�
    public byte countryId; // ����ID
    public short countryKingId;// ����ID
    public string countryColor;// ������ɫ
    public short power; // ����ֵ
    public bool canBeChoose;// �Ƿ���Ա�ѡ��
    [JsonProperty("inheritGeneralIds[]")] public short[] inheritGeneralIds; // �̳��佫ID����

    // ���ڴ洢���е��б�
    [SerializeField] public List<byte> cities= new List<byte>();//�����б�
    [SerializeField] public List<Alliance> allianceList;// �����б�


    // ʹ��byte����ʾ�Ƿ��ֵ���������ж�
    public byte isTurns = 1; // �Ƿ��ֵ��ж� (1 ��ʾ��)
    

    // ��Ӽ̳��佫ID�ķ���
    public void addInheritGeneralId(short generalId)
    {
        short[] tempInheritGeneralIds = new short[this.inheritGeneralIds.Length + 1];
        Array.Copy(this.inheritGeneralIds, 0, tempInheritGeneralIds, 0, this.inheritGeneralIds.Length);
        tempInheritGeneralIds[tempInheritGeneralIds.Length - 1] = generalId;
        this.inheritGeneralIds = tempInheritGeneralIds;
    }

    public byte getCityId(short generalId)
    {
        foreach (byte cityId in this.cities)
        {
            // ���ݳ���ID��ȡ�����City����
            City city = CityListCache.GetCityByCityId(cityId); // ����Ҫʵ�ֻ�ʹ�õĲ��ҷ���

            // ��ȡ�ó��еĽ���ID����
            short[] generalIdArray = city.getCityOfficeGeneralIdArray();

            for (int i = 0; i < generalIdArray.Length; i++)
            {
                if (generalIdArray[i] == generalId)
                {
                    return cityId;
                }
            }
        }
        return 0; // C#�У�byte����Ϊ0�����Ҫ����ǿ��ת��
    }


    int IntSF(short generalId)
    {
        General general = GeneralListCache.GetGeneral(generalId); // ���� GetGeneral ��һ����̬����
        int score = general.IQ + general.lead + general.moral;

        // IQ ����
        if (general.IQ >= 95) score += 100;
        else if (general.IQ >= 90) score += 70;
        else if (general.IQ >= 80) score += 40;
        else if (general.IQ >= 70) score += 20;

        // lead ����
        if (general.lead >= 95) score += 50;
        else if (general.lead >= 90) score += 30;
        else if (general.lead >= 80) score += 20;
        else if (general.lead >= 70) score += 10;

        // Moral ����
        if (general.moral >= 95) score += 50;
        else if (general.moral >= 90) score += 40;
        else if (general.moral >= 80) score += 20;
        else if (general.moral >= 70) score += 10;

        return score;
    }



    // ��ȡ�̳��佫ID�ķ���
    public short getInheritGeneralId()
    {
        // ���ȼ�� inheritGeneralIds ����
        foreach (short id in inheritGeneralIds)
        {
            General general = GeneralListCache.GetGeneral(id);
            if (general != null && getCityId(id) != 0)
            {
                return id;
            }
        }

        // ��ʼ�����ֵ
        int maxValue = 0;
        short generalId = 0;

        // ����������Ͻ�ĳ��м���
        foreach (byte cityId in this.cities)  // ���� this.citys �� List<City>
        {
            // ���ݳ���ID��ȡ�����City����
            City city = CityListCache.GetCityByCityId(cityId); // ����Ҫʵ�ֻ�ʹ�õĲ��ҷ���
            // ��ȡ�ó��еĽ��� ID ����
            short[] generalIdArray = city.getCityOfficeGeneralIdArray();

            // �������� ID ���鲢���������
            foreach (short id in generalIdArray)
            {
                int value = IntSF(id);
                if (value > maxValue)
                {
                    maxValue = value;
                    generalId = id;
                }
            }
        }

        // ���ط�����ߵĽ��� ID
        return generalId;
    }









    // ��ȡ����ID
    public byte getCityId(int generalId)
    {
        // ���������б�
        foreach (byte cityId in cities) // ʹ��foreach����whileѭ����elements()
        {
            // ��ȡ���е��佫ID����
            short[] generalIdArray = CityListCache.GetCityByCityId(cityId).getCityOfficeGeneralIdArray();

            // ����佫ID�������Ƿ���ڸ������佫ID
            for (int i = 0; i < generalIdArray.Length; i++)
            {
                if (generalIdArray[i] == generalId)
                {
                    // �ҵ��˶�Ӧ���佫ID�����س���ID
                    return cityId;
                }
            }
        }
        UnityEngine.Debug.Log("û���ҵ���Ӧ���佫ID");
        //Debug.Log("û���ҵ���Ӧ���佫ID");
        // ���û���ҵ���Ӧ���佫ID������0
        return 0xFF;
    }

    // �����佫���ۺϷ���
    public int CalculateGeneralScore(short generalId)
    {
        // ��ȡ�佫����
        General general = GeneralListCache.GetGeneral(generalId);

        // ��ʼ���ۺϷ���
        int score = general.IQ + general.lead + general.moral;

        // ����IQ���ӷ���
        if (general.IQ >= 95)
        {
            score += 100;
        }
        else if (general.IQ >= 90)
        {
            score += 70;
        }
        else if (general.IQ >= 80)
        {
            score += 40;
        }
        else if (general.IQ >= 70)
        {
            score += 20;
        }

        // ����lead���ӷ���
        if (general.lead >= 95)
        {
            score += 50;
        }
        else if (general.lead >= 90)
        {
            score += 30;
        }
        else if (general.lead >= 80)
        {
            score += 20;
        }
        else if (general.lead >= 70)
        {
            score += 10;
        }

        // ����moral���ӷ���
        if (general.moral >= 95)
        {
            score += 50;
        }
        else if (general.moral >= 90)
        {
            score += 40;
        }
        else if (general.moral >= 80)
        {
            score += 20;
        }
        else if (general.moral >= 70)
        {
            score += 10;
        }

        // �����ۺϷ���
        return score;
    }

    

    // ִ�м̳��佫����
    public short Inherit()
    {
        // ��ȡ�̳��佫ID
        short inheritGeneralIds = ((short)getInheritGeneralId());

        // ����ҵ��˷����������佫ID
        if (inheritGeneralIds != 0)
        {
            // ִ�м̳в���
            Inherit(inheritGeneralIds);
        }

        // ���ؼ̳е��佫ID
        return inheritGeneralIds;
    }



    // ִ�м̳в���
    public void Inherit(int inheritGeneralIds)
    {
        // ��ȡӵ�еĳ�������
        int CITY_NUM = GetHaveCityNum();

        // ����ÿ�����еĹ���
        for (byte i = 0; i < CITY_NUM; i++)
        {
            // ��ȡ���ж��󲢸��¹�������ID
            City curCity = CityListCache.GetCityByCityId(getCity(i));
            curCity.cityBelongKing = (short)inheritGeneralIds;
        }

        // ��ȡ�̳��佫���ڵĳ���ID
        byte cityId = getCityId((int)inheritGeneralIds);

        // ����Ҳ�����Ӧ���佫���ڳ��У���ֱ�ӷ���
        if (cityId == 0)
            return;

        // ��ȡ���ж�������̫��
        City liveCity = CityListCache.GetCityByCityId(cityId);
        liveCity.AppointmentPrefect(inheritGeneralIds);

        // �����佫���ҳ϶�
        General general = GeneralListCache.GetGeneral(inheritGeneralIds);
        general.SetLoyalty(100);

        // ������������ID
        this.countryKingId = (short)inheritGeneralIds;
    }

    // ��ȡ����������ֵ
    public short getPower()
    {
        // ��������ֵ
        return 0;
    }

    // ��ȡӵ�еĳ�������
    public byte GetHaveCityNum()
    {
        Debug.Log("������ӵ��"+cities.Count+"���ǳ�");
        // ֱ�ӷ��س����б�Ĵ�С
        return (byte)cities.Count;
    }

    public void AddCity(byte cityId)
    {
        // �������ID�Ѿ����б��У��������
        if (cities.Contains(cityId))
        {
            return;
        }

        // ��ȡ���ж���
        City city = CityListCache.GetCityByCityId(cityId);

        // �����е���������ID����Ϊ��ǰ���ҵĹ���ID
        city.cityBelongKing = this.countryKingId;

        // ������ID��ӵ��б���
        this.cities.Add(cityId);
    }

    // �Ƴ�����
    public void RemoveCity(byte cityId)
    {
        City city = CityListCache.GetCityByCityId(cityId);  // ��ȡ���ж���
        if (city != null)
        {
            city.prefectId = 0;  // ������е�̫��ID
            city.cityBelongKing = 0;  // ������еĹ�������

            this.cities.Remove(cityId);  // �ӳ����б����Ƴ�����

            byte count = GetHaveCityNum();  // ��ȡ��ǰӵ�еĳ�������
        }
    }



    // ��ȡ�����������е�ID����
    public byte[] GetCities()
    {
        byte[] result = new byte[this.cities.Count];
        for (int i = 0; i < this.cities.Count; i++)
        {
            result[i] = this.cities[i];
        }
        return result;
    }


    // ͨ������ID��ȡ������Ϣ
    public byte GetCity(byte cityId)
    {
        foreach (byte id in this.cities)
        {
            // ��ȡ���ж���
            City city = CityListCache.GetCityByCityId(id);

            if (city.cityId == cityId)
            {
                return city.cityId; // �ҵ����У����س���ID
            }
        }

        // ���û���ҵ����У���ӡ������Ϣ
        Console.Error.WriteLine("δ��ѯ���ǳر�ţ�" + cityId);

        // ���� 0 ��Ϊ��Ч�ĳ���ID
        return 0;
    }



    // ͨ��������ȡ����ID
    public byte getCity(int index)
    {
        // ��������Ƿ��ںϷ���Χ��
        if (index < 0 || index >= this.cities.Count)
        {
            Debug.LogError("�±� " + index + " δ��ѯ���ǳ�");
            return 0; // ʹ��0����0��Ϊ��ЧID
        }

        // ֱ�ӷ��س���ID
        return this.cities[index];
    }





    /*     */
    /*     */

    // �������Ƿ���������
    public bool isAlliance(byte cityId)
    {
        // ��ȡ���ж���
        City city = CityListCache.GetCityByCityId(cityId);

        // ��ȡ��������ID
        short belongKing = city.cityBelongKing;

        // �����������IDΪ0���������κ�����
        if (belongKing == 0)
            return false;

        // ��ȡ������������������
        Country otherCountry = CountryListCache.GetCountryByKingId(belongKing);

        // ���û���ҵ���Ӧ���������������κ�����
        if (otherCountry == null)
            return false;

        // ����Ƿ������˹�ϵ
        Alliance alliance = getAllianceById(otherCountry.countryId);

        // ���û���ҵ���Ӧ�����ˣ��������κ�����
        if (alliance == null)
            return false;

        // ��������
        return true;
    }



    // ��ȡ���˴�С
    public byte GetAllianceSize()
    {
        // ��ʼ��������
        byte size = 0;

        // ���������б�
        foreach (var alliance in allianceList)
        {
            // ������˶���Ϊ��
            if (alliance != null)
            {
                // ��������һ
                size++;
            }
        }

        // �������˴�С
        return size;
    }

    // ͨ��������ȡ���˶���
    public Alliance getAlliance(int index)
    {
        // ��ȡָ���������Ķ���
        object obj = allianceList[index];

        // �������Ϊ��
        if (obj == null)
        {
            // ����null
            return null;
        }

        // ǿ��ת��ΪAlliance����
        Alliance alliance = (Alliance)obj;

        // �������˶���
        return alliance;
    }


    /*     */
    /*     */
    /*     */

    // ͨ������ID��ȡ���˶���
    public Alliance getAllianceById(byte countryId)
    {
        // ���������б�
        foreach (var alliance in allianceList)
        {
            // ����ҵ���ƥ�������ID
            if (alliance.countryId == countryId)
            {
                // �������˶���
                return alliance;
            }
        }

        // ���û���ҵ���Ӧ������
        return null;
    }

    // �������
    public void AddAlliance(Alliance alliance)
    {
        // ����Ƿ��Ѿ����������������
        Alliance existingAlliance = getAllianceById(alliance.countryId);

        // ����Ѿ���������������ˣ���ֱ�ӷ���
        if (existingAlliance != null)
            return;

        // ����µ����˵��б�
        allianceList.Add(alliance);

        // ��ȡ��Ӧ������
        Country country = CountryListCache.GetCountryByCountryId(alliance.countryId);

        // ���û���ҵ���Ӧ����������ֱ�ӷ���
        if (country == null)
            return;

        // �ڶ�Ӧ���������������
        Alliance reverseAlliance = new Alliance(this.countryId, alliance.Months);
        country.AddAlliance(reverseAlliance);
    }

    // ͨ����һ������ID�������
    public void AddAlliance(byte otherCountryId)
    {
        // ����Ƿ��Ѿ����������������
        Alliance existingAlliance = getAllianceById(otherCountryId);

        // ����Ѿ���������������ˣ���ֱ�ӷ���
        if (existingAlliance != null)
            return;

        // �����µ�����
        Alliance alliance = new Alliance();
        alliance.countryId = otherCountryId;
        alliance.Months = 12;

        // ����µ����˵��б�
        allianceList.Add(alliance);

        // ��ȡ��Ӧ������
        Country country = CountryListCache.GetCountryByCountryId(otherCountryId);

        // ������������
        Alliance reverseAlliance = new Alliance(this.countryId, 12);

        // �ڶ�Ӧ���������������
        country.AddAlliance(reverseAlliance);
    }
    
   
    // �Ƴ�����
    public bool removeAlliance(byte countryId)
    {
        bool result = false;

        for (int i = 0; i < allianceList.Count; i++)
        {
            Alliance alliance = allianceList[i];
            if (alliance.countryId == countryId)
            {
                allianceList.Remove(alliance); // ��C#��ֱ�Ӵ�List��ɾ����Ԫ��
                Country country = CountryListCache.GetCountryByCountryId(countryId);
                if (country == null) return false;
                //if (countryId == GameInfo.humanCountryId)
                //{
                    //result = true;
                //}
                //country.removeAlliance(this.countryId);
                break;
            }
        }

        return result;
    }
    

    // �Ƴ���������
    public void removeAllAlliance()
    {
        while (allianceList.Count > 0)
        {
            Alliance alliance = allianceList[0];
            allianceList.RemoveAt(0); // �Ƴ��б��еĵ�һ��Ԫ��
            Country country = CountryListCache.GetCountryByCountryId(alliance.countryId);
            if (country != null)
            {
                country.removeAlliance(this.countryId);
            }
        }
    }


    // ��ȡû�����˹�ϵ������ID����
    public byte[] GetNoCountryIdAllianceCountryIdArray()
    {
        // ��ʼ������ID����
        List<byte> countryIdList = new List<byte>();

        // ������������
        for (byte i = 0; i < CountryListCache.getCountrySize(); i++)
        {
            // ��ȡ��ǰ����
            Country country = CountryListCache.getCountryByIndexId(i);

            // ����ҵ��˶�Ӧ���������Ҹ�����������һ������
            if (country != null && country.GetHaveCityNum() >= 1 &&
                country.countryId != this.countryId)
            {
                // ����Ƿ�������
                bool haveAlliance = false;

                // ���������б�
                foreach (var alliance in allianceList)
                {
                    // ����ҵ���ƥ�������
                    if (alliance.countryId == country.countryId)
                    {
                        // ���������˱��
                        haveAlliance = true;
                        // ����ѭ��
                        break;
                    }
                }

                // ���û������
                if (!haveAlliance)
                {
                    // ����ǰ����ID��ӵ��б�
                    countryIdList.Add(country.countryId);
                }
            }
        }

        // ���б�ת��Ϊ���鲢����
        return countryIdList.ToArray();
    }
    
    // ��ȡû�����˹�ϵ����������
    public byte getNoAllianceCountrySize()
    {
        // ���÷�����ȡû�����˹�ϵ������ID����
        byte[] noAllianceCountryIds = GetNoCountryIdAllianceCountryIdArray();

        // �������鳤����Ϊ��������
        return (byte)noAllianceCountryIds.Length;
    }



    // ��ȡ��ж��������ڵĳ���ID����
    public byte[] GetEnemyAdjacentCityIdArray()
    {
        // ����һ���յ��ֽ��б�����Ž��
        List<byte> resultCityIdList = new List<byte>();

        // ��������ID�б�
        foreach (byte cityId in cities)
        {
            // ��ȡ��ǰ���е����ӳ���ID����
            short[] cityIdArray = CityListCache.GetCityByCityId(cityId).connectCityId;

            // ����Ƿ��ежԳ���
            bool haveEnemyCity = false;

            // �������ӳ���ID����
            foreach (byte connectCityId in cityIdArray)
            {
                // ��ȡ���ӳ��е���������ID
                short belongKing = CityListCache.GetCityByCityId(connectCityId).cityBelongKing;

                // ������ӳ��еľ���ID���ǵ�ǰ�����ľ���ID
                if (belongKing != this.countryKingId)
                {
                    // ��ȡ��Ӧ������
                    Country otherCountry = CountryListCache.GetCountryByKingId(belongKing);

                    // ����ҵ��˶�Ӧ���������Ҹ�����û������
                    if (otherCountry != null && otherCountry.getAllianceById(otherCountry.countryId) == null)
                    {
                        // �����ежԳ��б��
                        haveEnemyCity = true;
                        // ����ѭ��
                        break;
                    }
                }
            }

            // ����ежԳ���
            if (haveEnemyCity)
            {
                // ����ǰ���е�ID��ӵ�����б�
                resultCityIdList.Add(cityId);
            }
        }

        // ���б�ת��Ϊ���鲢����
        return resultCityIdList.ToArray();
    }



    // ��ȡ��ǵж��������ڵĳ���ID����
    public byte[] GetNoEnemyAdjacentCityIdArray()
    {
        // ����һ���յ��ֽ���������Ž��
        List<byte> resultCityIdList = new List<byte>();

        // ��ȡ��ж��������ڵĳ���ID����
        byte[] enemyAdjacentCityIdArray = GetEnemyAdjacentCityIdArray();

        // ������г��ж�����ж��������ڣ���ֱ�ӷ��ؿ�����
        if (enemyAdjacentCityIdArray.Length == GetHaveCityNum())
        {
            return resultCityIdList.ToArray();
        }

        // ���������б�
        foreach (byte cityId in cities)
        {
            // ����Ƿ�����ж��������ڵĳ���
            bool isAdjacentCity = false;

            // ������ж��������ڵĳ���ID����
            foreach (byte adjacentCityId in enemyAdjacentCityIdArray)
            {
                // ����ҵ���ƥ��ĳ���ID
                if (adjacentCityId == cityId)
                {
                    // ��������ж��������ڵĳ��б��
                    isAdjacentCity = true;
                    // ����ѭ��
                    break;
                }
            }

            // ���������ж��������ڵĳ���
            if (!isAdjacentCity)
            {
                // ����ǰ���е�ID��ӵ�����б�
                resultCityIdList.Add(cityId);
            }
        }

        // ���б�ת��Ϊ���鲢����
        return resultCityIdList.ToArray();
    }



    // ��������
    public bool mustShangRen()
    {
        byte[] adjacentCity = GetEnemyAdjacentCityIdArray();
        bool flag = false;

        if (!haveGrainShop())
            return flag;

        for (int index = 0; index < adjacentCity.Length; index++)
        {
            byte curCity = adjacentCity[index];
            if (curCity <= 0)
                break;

            City city = CityListCache.GetCityByCityId(curCity);
            int needFood = city.needFoodToHarvest() + city.needFoodWarAMonth();

            if (city.GetFood() < needFood && city.GetMoney() > 200)
            {
                int buyNum = needFood - city.GetFood();
                buyNum = System.Math.Min(30000 - city.GetFood(), buyNum);

                if (buyNum >= 100 || city.GetFood() <= 100)
                {
                    if (buyNum > city.GetMoney() * 4 / 3)
                    {
                        short buy = (short)((city.GetMoney() - 50) * 4 / 3);
                        city.AddFood(buy);
                        city.SetMoney((short)50);
                        UnityEngine.Debug.Log($"{city.cityName} + buy + {city.GetFood()} + {city.GetMoney()}");
                    }
                    else
                    {
                        city.AddFood((short)buyNum);
                        city.DecreaseMoney((short)(buyNum * 3 / 4));
                        UnityEngine.Debug.Log($"{city.cityName} + buyNum + {city.GetFood()} + {city.GetMoney()}");
                    }
                    flag = true;
                }
            }
        }

        for (int index1 = 0; index1 < adjacentCity.Length; index1++)
        {
            byte curCity = adjacentCity[index1];
            if (curCity <= 0)
                break;

            City city = CityListCache.GetCityByCityId(curCity);
            int needFood = city.needFoodToHarvest() + city.needFoodWarAMonth();

            if (city.GetFood() > needFood + 200)
            {
                int sellNum = city.GetFood() - needFood - 200;
                sellNum = System.Math.Min(30000 - city.GetMoney(), sellNum);

                if (sellNum >= 50)
                {
                    city.DecreaseFood((short)sellNum);
                    city.AddMoney((short)(sellNum * 3 / 4));
                    UnityEngine.Debug.Log($"{city.cityName} + sellNum + {(sellNum * 3 / 4)}+ {city.GetMoney()} + {city.GetFood()}");
                    flag = true;
                }
            }
            else if (city.GetMoney() <= 0)
            {
                int needMoney = city.needAllSalariesMoney();
                int needSellFood = needMoney * 4 / 3;

                if (needSellFood >= city.GetFood() / 2)
                    return flag;

                city.AddMoney((short)needMoney);
                city.DecreaseFood((short)needSellFood);
                UnityEngine.Debug.Log($"{city.cityName} + {needSellFood} + needMoney + {city.GetFood()}");
            }
        }

        byte[] noAdjacentCity = GetNoEnemyAdjacentCityIdArray();
        for (int b1 = 0; b1 < noAdjacentCity.Length; b1++)
        {
            byte curCity = noAdjacentCity[b1];
            if (curCity <= 0)
                break;

            City city = CityListCache.GetCityByCityId(curCity);
            int needFood = city.needFoodToHarvest();

            if (city.GetFood() > needFood + 50)
            {
                int sellNum = city.GetFood() - needFood - 50;
                sellNum = System.Math.Min(30000 - city.GetMoney(), sellNum);

                if (sellNum >= 50)
                {
                    city.DecreaseFood((short)sellNum);
                    city.AddMoney((short)(sellNum * 3 / 4));
                    UnityEngine.Debug.Log($"{city.cityName} + sellNum + {(sellNum * 3 / 4)}+ {city.GetMoney()} + {city.GetFood()}");
                    flag = true;
                }
            }
            else if (city.GetMoney() <= 0)
            {
                int needMoney = city.needAllSalariesMoney();
                int needSellFood = needMoney * 4 / 3;

                if (needSellFood >= city.GetFood() / 2)
                    return flag;

                city.AddMoney((short)needMoney);
                city.DecreaseFood((short)needSellFood);
                UnityEngine.Debug.Log($"{city.cityName} + {needSellFood} + needMoney + {city.GetFood()}");
            }
        }

        return flag;
    }

    // �ж��Ƿ�������ķ���
    public bool haveGrainShop()
    {
        // ���������ڵ����г���
        foreach (byte cityId in cities)
        {
            // ���ݳ���ID�ӻ����л�ȡ���ж���
            City cityFromCache = CityListCache.GetCityByCityId(cityId);

            // �����е�k_byte_array1d_fld�ֶ��Ƿ���������־��0x8��
            if ((cityFromCache.k_byte_array1d_fld & 0x8) == 0x8)
            {
                return true;  // ��������꣬����true
            }
        }
        return false;  // ���û�����꣬����false
    }


    // �����Ǯ
    public bool transportMoney()
    {
        byte[] cityIds = GetCities();
        City bestNeedMoneyCity = null;
        int bestNeedMoney = 0;
        City bestRichMoneyCity = null;
        int bestRichMoney = 0;

        for (int index = 0; index < cityIds.Length; index++)
        {
            byte cityId = cityIds[index];
            City city = CityListCache.GetCityByCityId(cityId);
            int needFood = 0;
            int needMoney = 0;
            bool isNearEnemy = CityIsNearEnemy(cityId);

            if (isNearEnemy)
            {
                needFood = city.needFoodToHarvest() + city.needFoodWarAMonth();
                needMoney += (int)(needMoney + city.getAllSoldierNum() * 0.2 + (city.needAllSalariesMoney() * 12));
            }
            else
            {
                needFood = city.needFoodToHarvest();
                needMoney += city.needAllSalariesMoney() * 12;
            }

            if (city.GetFood() < needFood)
            {
                needMoney = (needFood - city.GetFood()) * 3 / 4;
            }

            if (city.GetMoney() < needMoney)
            {
                if (needMoney - city.GetMoney() > bestNeedMoney)
                {
                    bestNeedMoney = needMoney - city.GetMoney();
                    bestNeedMoneyCity = city;
                }
            }
            else if (city.GetMoney() - needMoney > bestRichMoney)
            {
                bestRichMoney = city.GetMoney() - needMoney;
                bestRichMoneyCity = city;
            }
        }

        if (bestNeedMoneyCity != null && bestRichMoneyCity != null)
        {
            int transportMoney = (bestRichMoney > bestNeedMoney) ? bestNeedMoney : bestRichMoney;
            bestRichMoneyCity.DecreaseMoney((short)transportMoney);
            bestNeedMoneyCity.AddMoney((short)transportMoney);
            UnityEngine.Debug.Log($"{bestRichMoneyCity.cityName} ���� {transportMoney} ��Ǯ�� {bestNeedMoneyCity.cityName}");
            return true;
        }

        return false;
    }



    // ѧϰ
    public bool study()
    {
        short studyCount = 0;

        // ö�����еĳ���
        foreach (byte cityId in this.cities)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            // �ۼ����г��е���ѧϰֵ
            studyCount += city.studyOfAllGeneral();
        }

        // ���ѧϰֵ����0���򷵻�true
        return studyCount > 0;
    }

    // ��������
    private bool ChangeGeneral(City city, City otherCity)
    {
        // ��ȡ����������ս������С���佫��ID
        short minBattlePowerGeneralId = otherCity.getMinBattlePowerGeneralId();
        // ����ID�ӻ����л�ȡ�佫����
        General minBattlePowerGeneral = GeneralListCache.GetGeneral(minBattlePowerGeneralId);
        // ��ȡ���佫��ս����
        double minBattlePower = minBattlePowerGeneral.GetBattlePower();

        // ��ȡ��ǰ������ս���������佫��ID
        short maxBattlePowerGeneralId = city.getMaxBattlePowerGeneralId();
        // ����ID�ӻ����л�ȡ�佫����
        General battlePowerGeneral = GeneralListCache.GetGeneral(maxBattlePowerGeneralId);
        // ��ȡ���佫��ս����
        double battlePower = battlePowerGeneral.GetBattlePower();

        // �����ǰ������ս���������佫��ս������������������ս������С���佫
        if (battlePower > minBattlePower)
        {
            // �����佫������ǰ���е�ս��������佫���������е�ս������С�佫����
            ChangeGeneral(city.cityId, maxBattlePowerGeneralId, otherCity.cityId, minBattlePowerGeneralId);

            // �����־����¼�佫������Ϣ
            UnityEngine.Debug.Log($"{city.cityName} �� {battlePowerGeneral.generalName} �� {otherCity.cityName} �� {minBattlePowerGeneral.generalName} �����˽�����");

            // ���� true����ʾ�����ɹ�
            return true;
        }

        // ��������㽻���������򷵻� false
        return false;
    }


    // ������������ӽ���
    private bool AddGeneralToOtherCity(City city, City otherCity)
    {
        short minBattlePowerGeneralId = city.getMinBattlePowerGeneralId();
        bool isMove = false;

        while (true)
        {
            short generalId = city.getMaxBattlePowerGeneralId();

            if (city.getCityGeneralNum() == 1 || generalId == minBattlePowerGeneralId || otherCity.getCityGeneralNum() >= 10)
            {
                return isMove;
            }

            // �Ƴ�����
            city.removeOfficeGeneralId(generalId);

            // ����ƶ���Ϣ
            UnityEngine.Debug.Log($"��{city.cityName}��{GeneralListCache.GetGeneral(generalId).generalName}�ƶ���{otherCity.cityName}");

            // ��ӽ��쵽��������
            otherCity.AddOfficeGeneralId(generalId);

            isMove = true;
        }
    }





    public bool Boolean_R()
    {
        bool isMove = false;

        // ��ȡ����Ҫս�����ĳ���
        City maxNeedPowerCity = getMaxNeedPowerCity();

        // ���û���ҵ�����һ������
        if (maxNeedPowerCity == null)
        {
            // ��ȡ�з����ڳ��е�ID����
            byte[] adjacentCityIdArray = GetEnemyAdjacentCityIdArray();
            if (adjacentCityIdArray.Length <= 0)
                return isMove;

            // ��ȡû�е������ڵĳ���ID����
            byte[] noEnemyAdjacentCityIdArray = GetNoEnemyAdjacentCityIdArray();

            // ��������û�е������ڵĳ���
            foreach (byte cityId in noEnemyAdjacentCityIdArray)
            {
                City city = CityListCache.GetCityByCityId(cityId);

                // �������ез����ڳ���
                foreach (byte otherCityId in adjacentCityIdArray)
                {
                    City otherCity = CityListCache.GetCityByCityId(otherCityId);

                    // ������н������� <= 1 ���ߵз����ڳ��еĽ������� > 9
                    if (city.getCityGeneralNum() <= 1 || otherCity.getCityGeneralNum() > 9)
                    {
                        if (ChangeGeneral(city, otherCity))
                            isMove = true;
                    }
                    else
                    {
                        if (AddGeneralToOtherCity(city, otherCity))
                            isMove = true;
                    }
                }
            }
            return isMove;
        }

        // ��ȡû�е������ڵĳ���ID����
        byte[] noAdjacentCity = GetNoEnemyAdjacentCityIdArray();

        if (noAdjacentCity.Length > 0)
        {
            // ����û�е������ڵĳ���
            foreach (byte cityId in noAdjacentCity)
            {
                City city = CityListCache.GetCityByCityId(cityId);

                // ������н������� <= 1 ���� maxNeedPowerCity �Ľ������� > 9
                if (city.getCityGeneralNum() <= 1 || maxNeedPowerCity.getCityGeneralNum() > 9)
                {
                    if (ChangeGeneral(city, maxNeedPowerCity))
                        isMove = true;
                }
                else
                {
                    if (AddGeneralToOtherCity(city, maxNeedPowerCity))
                        isMove = true;
                }
            }
        }
        else
        {
            // ����������ڵĳ���
            byte[] adjacentCityIdArray = GetEnemyAdjacentCityIdArray();
            foreach (byte adjacentCityId in adjacentCityIdArray)
            {
                if (adjacentCityId != maxNeedPowerCity.cityId)
                {
                    City adjacentCity = CityListCache.GetCityByCityId(adjacentCityId);
                    byte generalNum = adjacentCity.getCityGeneralNum();
                    int defenseAbility = adjacentCity.GetDefenseAbility();
                    short minBattlePowerGeneralId = adjacentCity.getMinBattlePowerGeneralId();
                    General minBattlePowerGeneral = GeneralListCache.GetGeneral(minBattlePowerGeneralId);
                    double battlePower = minBattlePowerGeneral.GetBattlePower();
                    int enemyAdjacentAtkPower = CountryListCache.GetEnemyAdjacentAtkPowerArray(adjacentCityId);

                    // ������н������� > 1 �� maxNeedPowerCity �Ľ������� < 9
                    if (generalNum > 1 && maxNeedPowerCity.getCityGeneralNum() < 9)
                    {
                        if (defenseAbility - battlePower >= enemyAdjacentAtkPower)
                        {
                            maxNeedPowerCity.AddOfficeGeneralId(minBattlePowerGeneralId);
                            maxNeedPowerCity.AppointmentPrefect();
                            adjacentCity.removeOfficeGeneralId(minBattlePowerGeneralId);
                            adjacentCity.AppointmentPrefect();
                            isMove = true;
                            UnityEngine.Debug.Log($"{adjacentCity.cityName} ��ս������, ���佫: {minBattlePowerGeneral.generalName} �ƶ��� {maxNeedPowerCity.cityName}");
                        }
                    }
                    else
                    {
                        short needMinBattlePowerGeneralId = maxNeedPowerCity.getMinBattlePowerGeneralId();
                        General needMinBattlePowerGeneral = GeneralListCache.GetGeneral(needMinBattlePowerGeneralId);
                        double needBattlePower = needMinBattlePowerGeneral.GetBattlePower();

                        if (needBattlePower < battlePower && defenseAbility - battlePower + needBattlePower >= enemyAdjacentAtkPower)
                        {
                            ChangeGeneral(maxNeedPowerCity.cityId, needMinBattlePowerGeneralId, adjacentCityId, minBattlePowerGeneralId);
                            UnityEngine.Debug.Log($"{maxNeedPowerCity.cityName} �� {needMinBattlePowerGeneral.generalName} �� {adjacentCity.cityName} �� {minBattlePowerGeneral.generalName} ������");
                            isMove = true;
                        }
                    }
                }
            }
        }

        return isMove;
    }







    // ��ȡ����Ҫս�����ĳ���
    public City getMaxNeedPowerCity()
    {
        // ��ȡ�ж��ڽ�����ID����
        byte[] enemyAdjacentCityIds = GetEnemyAdjacentCityIdArray();
        int maxNeedPower = 0;
        City moveCity = null;

        foreach (byte adjacentCityId in enemyAdjacentCityIds)
        {
            City adjacentCity = CityListCache.GetCityByCityId(adjacentCityId);
            if (adjacentCity.getCityGeneralNum() <= 9)
            {
                int defenseAbility = adjacentCity.GetDefenseAbility();
                int enemyAdjacentAtkPower = CountryListCache.GetEnemyAdjacentAtkPowerArray(adjacentCityId);
                int needPower = enemyAdjacentAtkPower - defenseAbility;
                if (needPower > maxNeedPower)
                {
                    maxNeedPower = needPower;
                    moveCity = adjacentCity;
                }
            }
        }

        return moveCity;
    }

    // �жϳ����Ƿ�Ϊ�жԳ���
    public bool CityIsEnemy(byte cityId)
    {
        City city = CityListCache.GetCityByCityId(cityId);
        short[] connectCityIds = city.connectCityId;

        foreach (byte connectCityId in connectCityIds)
        {
            City connectCity = CityListCache.GetCityByCityId(connectCityId);
            if (connectCity.cityBelongKing != city.cityBelongKing)
            {
                return true;
            }
        }

        return false;
    }


    /*     */

    // �������Ƿ��ڽ��з�����
    public bool CityIsNearEnemy(byte cityId)
    {
        // ��ȡ���ж���
        City city = CityListCache.GetCityByCityId(cityId);
        // ��ʼ���Ƿ��ез����б�־
        bool haveEnemyCity = false;

        foreach (byte connectCityId in city.connectCityId)
        {
            // ��ȡ�ڽӳ��еľ���ID
            short belongKing = CityListCache.GetCityByCityId(connectCityId).cityBelongKing;
            // ����ڽӳ��еľ���ID�뵱ǰ������ͬ
            if (belongKing != this.countryKingId)
            {
                // ��ȡ�ڽӳ��е���������
                Country otherCountry = CountryListCache.GetCountryByKingId(belongKing);
                // ����ڽӳ��е��������������Ҳ���ͬ�˹�
                if (otherCountry != null && otherCountry.getAllianceById(otherCountry.countryId) == null)
                {
                    // �����ез����б�־���˳�ѭ��
                    haveEnemyCity = true;
                    break;
                }
            }
        }

        return haveEnemyCity;
    }

    // �����佫���ڳ���
    public void ChangeGeneral(byte cityId1, short generalId1, byte cityId2, short generalId2)
    {
        // ��ȡ���ж���
        City city1 = CityListCache.GetCityByCityId(cityId1);
        City city2 = CityListCache.GetCityByCityId(cityId2);

        // �������1���佫����С��2
        if (city1.getCityGeneralNum() < 2)
        {
            // ��generalId2��ӵ�����1
            city1.AddOfficeGeneralId(generalId2);
            // �ӳ���1�Ƴ�generalId1
            city1.removeOfficeGeneralId(generalId1);

            // �������2���佫����С��10
            if (city2.getCityGeneralNum() < 10)
            {
                // ��generalId1��ӵ�����2
                city2.AddOfficeGeneralId(generalId1);
                // �ӳ���2�Ƴ�generalId2
                city2.removeOfficeGeneralId(generalId2);
            }
            else
            {
                // �ӳ���2�Ƴ�generalId2
                city2.removeOfficeGeneralId(generalId2);
                // ��generalId1��ӵ�����2
                city2.AddOfficeGeneralId(generalId1);
            }
        }
        else
        {
            // �ӳ���1�Ƴ�generalId1
            city1.removeOfficeGeneralId(generalId1);
            // ��generalId2��ӵ�����1
            city1.AddOfficeGeneralId(generalId2);

            // �������2���佫����С��10
            if (city2.getCityGeneralNum() < 10)
            {
                // ��generalId1��ӵ�����2
                city2.AddOfficeGeneralId(generalId1);
                // �ӳ���2�Ƴ�generalId2
                city2.removeOfficeGeneralId(generalId2);
            }
            else
            {
                // �ӳ���2�Ƴ�generalId2
                city2.removeOfficeGeneralId(generalId2);
                // ��generalId1��ӵ�����2
                city2.AddOfficeGeneralId(generalId1);
            }
        }

        // ��������1��̫��
        city1.AppointmentPrefect();
        // ��������2��̫��
        city2.AppointmentPrefect();
    }



    // ʹ�佫���˵�����
    public bool RetreatGeneralToCity(short[] generalIdArray, byte curCityId, int food, int money, bool chiefGeneralCaptured)
    {
        bool retreat = false;
        byte[] cityIdArray = GetCities();
        City curCity = CityListCache.GetCityByCityId(curCityId);

        if (cityIdArray.Length == 0 || (cityIdArray.Length == 1 && cityIdArray[0] == curCityId))
        {
            UnityEngine.Debug.Log($"{GeneralListCache.GetGeneral(this.countryKingId).generalName}�������޳ǳؿɳ��ˣ�");
            for (int j = 0; j < generalIdArray.Length; j++)
            {
                short generalId = generalIdArray[j];
                General general = GeneralListCache.GetGeneral(generalId);
                if (general != null)
                {
                    if (generalId == this.countryKingId)
                    {
                        UnityEngine.Debug.Log($"������{general.generalName}�޳ǳؿɳ��ˣ�������");
                        GeneralListCache.GeneralDie(generalId);
                    }
                    else if (curCity.AddOppositionGeneralId(generalId))
                    {
                        UnityEngine.Debug.Log($"{general.generalName}�޳ǳؿɳ��ˣ���{curCity.cityName}��Ұ��");
                    }
                }
            }

            return retreat;
        }

        int index = 0;
        for (int i = 0; i < generalIdArray.Length; i++)
        {
            short generalId = generalIdArray[i];
            General general = GeneralListCache.GetGeneral(generalId);
            if (general != null)
            {
                for (int j = 0; j < cityIdArray.Length; j++)
                {
                    byte cityId = (byte)cityIdArray[j];
                    if (cityId != curCityId)
                    {
                        City city = CityListCache.GetCityByCityId(cityId);
                        if (city.getCityGeneralNum() <= 9 || generalId == this.countryKingId)
                        {
                            city.AddOfficeGeneralId(generalId);
                            index++;
                            if (i == 0 && !chiefGeneralCaptured)
                            {
                                city.AddFood((short)food);
                                city.AddMoney((short)money);
                                retreat = true;
                                UnityEngine.Debug.Log($"������{general.generalName}���˵�{city.cityName}");
                                break;
                            }
                            UnityEngine.Debug.Log($"�佫��{general.generalName}���˵�{city.cityName}");
                            break;
                        }
                    }
                }
            }
        }

        if (index < generalIdArray.Length - 1)
        {
            for (; index < generalIdArray.Length; index++)
            {
                short generalId = generalIdArray[index];
                General general = GeneralListCache.GetGeneral(generalId);
                if (general != null && curCity.AddOppositionGeneralId(generalId))
                {
                    UnityEngine.Debug.Log($"{general.generalName}�޳ǳؿɳ��ˣ���{curCity.cityName}��Ұ��");
                }
            }
        }

        return chiefGeneralCaptured ? false : retreat;
    }

    class IniClass// �洢IniClass������б���ʾ�����ڵĳ����б�

    {
        public byte cityId;  // ����ID
        private Country country;  // ��������

        // ���캯������ʼ������ID����������
        public IniClass(Country country, byte cityId)
        {
            this.country = country;
            this.cityId = cityId;
        }
    }


}
