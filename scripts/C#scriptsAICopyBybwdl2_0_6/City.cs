using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class City 
{
    public byte cityId { get; set; }

    public string cityName { get; set; }

    public short cityBelongKing { get; set; }

    public short prefectId { get; set; }

    public byte rule { get; set; }

    public short money { get; set; }

    public short food { get; set; }

    public short agro { get; set; }

    public short trade { get; set; }

    public int population { get; set; }

    public byte floodControl { get; set; }

    private short[] cityOfficeGeneralId = new short[0];

    private short[] cityOppositionGeneralId = new short[0];

    private short[] cityNotFoundGeneralId = new short[0];

    public int cityTotalSoldier { get; set; }

    public int cityReserveSoldier { get; set; }

    [SerializeField] public int j_byte_array1d_fld=0;

    [SerializeField] public byte k_byte_array1d_fld;

    public bool cityWeaponShop { get; set; }

    public bool warWeaponShop { get; set; }

    public int treasureNum { get; set; }

    public int development { get; set; }

    [SerializeField] public byte[] citySellWeapons;

    [SerializeField] public byte[] warSellWeapons;

    [JsonProperty("connectCityId[]")]public short[] connectCityId;

    [JsonProperty("mapPosition[]")] public short[] mapPosition=new short[2];

    // ���ý�Ǯ
    public void SetMoney(short _money)
    {
        if (_money > 30000 || _money < 0)
        {
            this.money = 30000;
        }
        else
        {
            this.money = _money;
        }
    }

    // ��ȡ��Ǯ
    public short GetMoney()
    {
        return this.money;
    }

    // ���ӽ�Ǯ
    public short AddMoney(short _money)
    {
        if (this.money + _money > 30000 || this.money + _money < 0)
        {
            _money = (short)(30000 - this.money);
            this.money = 30000;
        }
        else
        {
            this.money = (short)(this.money + _money);
        }
        return _money;
    }

    // ���ٽ�Ǯ
    public short DecreaseMoney(short _money)
    {
        if (this.money - _money > 30000 || this.money - _money < 0)
        {
            _money = this.money;
            this.money = 0;
        }
        else
        {
            this.money = (short)(this.money - _money);
        }
        return _money;
    }

    // ����ʳ��
    public void SetFood(short _food)
    {
        if (_food > 30000 || _food < 0)
        {
            this.food = 30000;
        }
        else
        {
            this.food = _food;
        }
    }

    // ��ȡʳ��
    public short GetFood()
    {
        return this.food;
    }

    // ����ʳ��
    public short AddFood(short _food)
    {
        if (this.food + _food > 30000 || this.food + _food < 0)
        {
            _food = (short)(30000 - this.food);
            this.food = 30000;
        }
        else
        {
            this.food = (short)(this.food + _food);
        }
        return _food;
    }

    // ����ʳ��
    public short DecreaseFood(short _food)
    {
        if (this.food - _food > 30000 || this.food - _food < 0)
        {
            _food = this.food;
            this.food = 0;
        }
        else
        {
            this.food = (short)(this.food - _food);
        }
        return _food;
    }




    // ʿ������ʳ��
    public void soldierEatFood()
    {
        short needFood = (short)(getAlreadyAllSoldierNum() / 100 + this.cityReserveSoldier / 300);
        if (needFood > this.food)
        {
            this.food = 0;
            if (this.cityReserveSoldier > 100)
            {
                this.cityReserveSoldier -= 100;
            }
            else
            {
                this.cityReserveSoldier = 0;
            }
            for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
            {
                General general = GeneralListCache.GetGeneral(this.cityOfficeGeneralId[i]);
                if (general.generalSoldier > 100)
                {
                    general.generalSoldier = (short)(general.generalSoldier - 100);
                }
                else
                {
                    general.generalSoldier = 0;
                }
            }
        }
        else
        {
            this.food = (short)(this.food - needFood);
        }
    }


    // ֧����Աнˮ
    public void paySalaries()
    {
        for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
        {
            General general = GeneralListCache.GetGeneral(this.cityOfficeGeneralId[i]);
            if (this.money <= 0)
            {
                if (general.generalId != this.cityBelongKing)
                {
                    general.decreaseLoyalty((byte)(UnityEngine.Random.Range(0, 4) + 1));
                    Debug.Log($"{this.cityName} + general.generalName");
                }
            }
            else
            {
                DecreaseMoney(general.getSalary());
            }
        }
    }

    // ��ȡ̫��
    public int getprefectId()
    {
        return this.prefectId;
    }

    // ��ȡ������������
    public int getcityBelongKing()
    {
        return this.cityBelongKing;
    }



    // ��ȡδ��������Ա������
    public byte getCityNotFoundGeneralNum()
    {
        byte count = 0;
        for (int i = 0; i < this.cityNotFoundGeneralId.Length; i++)
        {
            if (this.cityNotFoundGeneralId[i] > 0)
                count = (byte)(count + 1);
        }
        return count;
    }

    // ��ȡδ��������Ա��ID����
    public short[] getCityNotFoundGeneralIdArray()
    {
        byte generalNum = getCityNotFoundGeneralNum();
        short[] result = new short[generalNum];
        byte index = 0;
        for (int i = 0; i < this.cityNotFoundGeneralId.Length; i++)
        {
            short generalId = this.cityNotFoundGeneralId[i];
            if (generalId > 0)
            {
                result[index] = generalId;
                index = (byte)(index + 1);
            }
        }
        return result;
    }

    // ��ȡδ��������Ա��ID
    public short getNotFoundGeneralId(byte index)
    {
        return this.cityNotFoundGeneralId[index];
    }

    /// <summary>
    /// ���δ��������Ա��ID
    /// </summary>
    /// <param name="generalId"></param>
    /// <returns></returns>
    public bool AddNotFoundGeneralId(short generalId)
    {
        if (this.cityOppositionGeneralId.Length > 9)
            return false;
        for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
        {
            if (this.cityOfficeGeneralId[i] == generalId)
                removeOfficeGeneralId(generalId);
        }
        General general = GeneralListCache.GetGeneral(generalId);
        if (general == null)
            return false;
        for (byte b = 0; b < CityListCache.getCityNum(); b = (byte)(b + 1))
        {
            City city = CityListCache.getCityByIndex(b);
            for (byte index = 0; index < city.getCityGeneralNum(); index = (byte)(index + 1))
            {
                if (city.getCityOfficeGeneralIdArray()[index] == generalId)
                {
                    city.removeOfficeGeneralId(general.generalId);
                    Debug.Log($"+ general.generalName + {city.cityName}");
                }
            }
        }
        general.isOffice = 0;
        general.debutCity = this.cityId;
        if (this.cityNotFoundGeneralId.Length >= 10)
        {
            Debug.Log($"+ general.generalName + ");
            GeneralListCache.GeneralDie(generalId);
            return false;
        }
        short[] tempOppositionGeneralId = new short[this.cityNotFoundGeneralId.Length + 1];
        for (int j = 0; j < this.cityNotFoundGeneralId.Length; j++)
        {
            short tempGeneralId = this.cityNotFoundGeneralId[j];
            if (tempGeneralId > 0)
                tempOppositionGeneralId[j] = tempGeneralId;
        }
        tempOppositionGeneralId[this.cityNotFoundGeneralId.Length] = generalId;
        this.cityNotFoundGeneralId = tempOppositionGeneralId;
        return true;
    }

    // �Ƴ�δ��������Ա��ID
    public void removeNotFoundGeneralId(short generalId)
    {
        bool isExistence = false;
        for (int i = 0; i < this.cityNotFoundGeneralId.Length; i++)
        {
            short tempGeneralId = this.cityNotFoundGeneralId[i];
            if (tempGeneralId == generalId)
            {
                isExistence = true;
                break;
            }
        }
        if (!isExistence)
            return;
        short[] tempOfficeGeneralId = new short[this.cityNotFoundGeneralId.Length - 1];
        int index = 0;
        for (int j = 0; j < this.cityNotFoundGeneralId.Length; j++)
        {
            short tempGeneralId = this.cityNotFoundGeneralId[j];
            if (tempGeneralId > 0 && tempGeneralId != generalId)
            {
                tempOfficeGeneralId[index] = tempGeneralId;
                index++;
            }
        }
        this.cityNotFoundGeneralId = tempOfficeGeneralId;
    }

    // ����Ԥ����ʿ��
    public void distributionSoldier()
    {
        if (this.cityReserveSoldier <= 0)
            return;
        short[] officeGeneralIdArray = getCityOfficeGeneralIdArray();
        for (int i = 0; i < officeGeneralIdArray.Length && this.cityReserveSoldier > 0; i++)
        {
            short generalId = officeGeneralIdArray[i];
            General general = GeneralListCache.GetGeneral(generalId);
            if (general.generalSoldier < general.getMaxGeneralSoldier())
            {
                short needSoldier = (short)(general.getMaxGeneralSoldier() - general.generalSoldier);
                if (needSoldier <= this.cityReserveSoldier)
                {
                    this.cityReserveSoldier -= needSoldier;
                    general.generalSoldier = general.getMaxGeneralSoldier();
                }
                else
                {
                    general.generalSoldier = (short)(general.generalSoldier + this.cityReserveSoldier);
                    this.cityReserveSoldier = 0;
                }
            }
        }
    }

    // ��ȡ��ԱID����
    public short[] getCityOfficeGeneralIdArray()
    {
        byte generalNum = getCityGeneralNum();
        short[] result = new short[generalNum];
        byte index = 0;

        for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
        {
            short generalId = this.cityOfficeGeneralId[i];
            if (generalId > 0)
            {
                result[index] = generalId;
                index++;
            }
        }
        Debug.Log($"��ְ��Ա"+ "getCityOfficeGeneralIdArray()" +"��{cityName}");
        return result;
    }


    // ��ȡ��Ұ�佫����
    public byte GetOppositionGeneralNum()
    {
        byte count = 0;
        for (int i = 0; i < this.cityOppositionGeneralId.Length; i++)
        {
            if (this.cityOppositionGeneralId[i] > 0)
                count = (byte)(count + 1);
        }
        return count;
    }

    // ��ȡ��Ұ�佫ID
    public short GetOppositionGeneralId(byte index)
    {
        return this.cityOppositionGeneralId[index];
    }




    // �����Ұ�佫ID
    public bool AddOppositionGeneralId(short generalId)
    {
        if (GetOppositionGeneralNum() > 9)
            return false;
        for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
        {
            if (this.cityOfficeGeneralId[i] == generalId)
            {
                Debug.Log("��Ա��ְλ���Ƴ�");

                removeOfficeGeneralId(generalId);
            }
        }
        General general = GeneralListCache.GetGeneral(generalId);
        if (general == null)
            return false;
        general.isOffice = 0;
        general.debutCity = this.cityId;
        short[] tempOppositionGeneralId = new short[this.cityOppositionGeneralId.Length + 1];
        for (int j = 0; j < this.cityOppositionGeneralId.Length; j++)
        {
            short tempGeneralId = this.cityOppositionGeneralId[j];
            if (tempGeneralId > 0)
                tempOppositionGeneralId[j] = tempGeneralId;
        }
        tempOppositionGeneralId[this.cityOppositionGeneralId.Length] = generalId;
        this.cityOppositionGeneralId = tempOppositionGeneralId;
        return true;
    }

    // �Ƴ������ɹ�ԱID
    public void RemoveOppositionGeneralId(short generalId)
    {
        bool isExistence = false;
        for (int i = 0; i < this.cityOppositionGeneralId.Length; i++)
        {
            short tempGeneralId = this.cityOppositionGeneralId[i];
            if (tempGeneralId == generalId)
            {
                isExistence = true;
                break;
            }
        }
        if (!isExistence)
            return;
        short[] tempOfficeGeneralId = new short[this.cityOppositionGeneralId.Length - 1];
        int index = 0;
        for (int j = 0; j < this.cityOppositionGeneralId.Length; j++)
        {
            short tempGeneralId = this.cityOppositionGeneralId[j];
            if (tempGeneralId > 0 && tempGeneralId != generalId)
            {
                tempOfficeGeneralId[index] = tempGeneralId;
                index++;
            }
        }
        this.cityOppositionGeneralId = tempOfficeGeneralId;
    }

    // ������й�Ա
    public void ClearAllOfficeGeneral()
    {
        this.cityOfficeGeneralId = new short[0];
    }

    // ��ӵ�����ԱID
    public bool AddOfficeGeneralId(short generalId)
    {
        General general = GeneralListCache.GetGeneral(generalId);
        if (general == null)
        {
            removeOfficeGeneralId(generalId);
            return false;
        }
        for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
        {
            if (this.cityOfficeGeneralId[i] == generalId)
            {
                Debug.Log("��Ա����ְλ��");
                return true;
            }
        }
        general.isOffice = 1;
        general.debutCity = this.cityId;
        byte generalNum = getCityGeneralNum();
        if (generalNum > 9)
        {
            short minGeneralId = getMinBattlePowerGeneralId();
            Country country = CountryListCache.GetCountryByKingId(generalId);
            if (country != null)
            {
                for (int j = 0; j < this.cityOfficeGeneralId.Length; j++)
                {
                    if (this.cityOfficeGeneralId[j] == minGeneralId)
                    {
                        this.cityOfficeGeneralId[j] = this.cityOfficeGeneralId[0];
                        this.cityOfficeGeneralId[0] = generalId;
                        this.prefectId = generalId;
                        AddNotFoundGeneralId(minGeneralId);
                        return true;
                    }
                }
            }
            else
            {
                int generalScore = general.getGeneralScore();
                General minGeneral = GeneralListCache.GetGeneral(minGeneralId);
                if (generalScore > minGeneral.getGeneralScore())
                {
                    for (int j = 0; j < this.cityOfficeGeneralId.Length; j++)
                    {
                        if (this.cityOfficeGeneralId[j] == minGeneralId)
                        {
                            this.cityOfficeGeneralId[j] = generalId;
                            if (j == 0)
                                this.prefectId = generalId;
                            AddNotFoundGeneralId(minGeneralId);
                            return true;
                        }
                    }
                }
                else
                {
                    AddNotFoundGeneralId(generalId);
                    return false;
                }
            }
        }
        else
        {
            short[] tempOfficeGeneralId = new short[generalNum + 1];
            System.Array.Copy(this.cityOfficeGeneralId, 0, tempOfficeGeneralId, 0, this.cityOfficeGeneralId.Length);
            if (CountryListCache.GetCountryByKingId(generalId) != null)
            {
                if (generalNum != 0)
                {
                    short tempGeneralId = this.cityOfficeGeneralId[0];
                    tempOfficeGeneralId[generalNum] = tempGeneralId;
                }
                tempOfficeGeneralId[0] = generalId;
                this.prefectId = generalId;
                this.cityOfficeGeneralId = tempOfficeGeneralId;
                return true;
            }
            tempOfficeGeneralId[generalNum] = generalId;
            this.cityOfficeGeneralId = tempOfficeGeneralId;
            if (this.cityOfficeGeneralId.Length == 1)
                this.prefectId = generalId;
            return true;
        }
        return false;
    }





    // �Ƴ���ԱID
    public void removeOfficeGeneralId(short generalId)
    {
        bool isExistence = false;
        for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
        {
            short tempGeneralId = this.cityOfficeGeneralId[i];
            if (tempGeneralId == generalId)
            {
                isExistence = true;
                break;
            }
        }
        if (!isExistence)
            return;

        short[] tempOfficeGeneralId = new short[this.cityOfficeGeneralId.Length - 1];
        int index = 0;
        for (int j = 0; j < this.cityOfficeGeneralId.Length; j++)
        {
            short tempGeneralId = this.cityOfficeGeneralId[j];
            if (tempGeneralId > 0 && tempGeneralId != generalId)
            {
                tempOfficeGeneralId[index] = tempGeneralId;
                index++;
            }
        }
        this.cityOfficeGeneralId = tempOfficeGeneralId;

        if (getCityGeneralNum() < 1)
        {
            Country country = CountryListCache.GetCountryByKingId(this.cityBelongKing);
            country.RemoveCity(this.cityId);
            this.cityBelongKing = 0;
            this.prefectId = 0;
        }
        else if (this.prefectId == generalId)
        {
            AppointmentPrefect();
        }
    }

    // ��ȡ��չ�̶�
    public byte getDevelopment()
    {
        return 0;
    }

    // ��ȡ��������ʿ������
    public int GetCityAllSoldierNum()
    {
        return getAlreadyAllSoldierNum() + this.cityReserveSoldier;
    }

    // ��ȡ�������ʿ������
    public int getAllSoldierNum()
    {
        int count = 0;
        for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
        {
            short generalId = this.cityOfficeGeneralId[i];
            if (generalId > 0)
            {
                General general = GeneralListCache.GetGeneral(generalId);
                count += general.getMaxGeneralSoldier();
            }
        }
        return count;
    }

    // ��ȡ��������ʿ������
    public int getAlreadyAllSoldierNum()
    {
        int count = 0;
        for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
        {
            short generalId = this.cityOfficeGeneralId[i];
            if (generalId > 0)
            {
                General general = GeneralListCache.GetGeneral(generalId);
                count += general.generalSoldier;
            }
        }
        return count;
    }

    // ��ȡ���й�Ա����
    public  byte getCityGeneralNum()
    {
        byte count = 0;
        for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
        {
            if (this.cityOfficeGeneralId[i] > 0)
                count = (byte)(count + 1);
        }
        return count;
    }

    // ָ������̫��
    public void AppointmentPrefect(int generalId)
    {
        int index = 0;
        for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
        {
            if (this.cityOfficeGeneralId[i] == generalId)
                index = i;
        }
        if (index == 0)
        {
            Debug.Log("��ԱID������: " + generalId);
            return;
        }
        if (index == 0)
        {
            Debug.Log("��Ա�Ѿ���̫��: " + generalId);
        }
        else
        {
            short tempGeneralId = this.cityOfficeGeneralId[0];
            this.cityOfficeGeneralId[0] = this.cityOfficeGeneralId[index];
            this.cityOfficeGeneralId[index] = tempGeneralId;
        }
        this.prefectId = (short)generalId;
    }

    /// <summary>
    /// �Զ�����̫��
    /// </summary>
    public void AppointmentPrefect()
    {
        Country userCountry = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);
        if (userCountry != null && this.cityBelongKing == userCountry.countryKingId)
            return;

        int i1 = 0;
        int prefectValue = 0;
        short prefectId = 0;
        short[] cityOfficeGeneralIdArray = getCityOfficeGeneralIdArray();
        if (cityOfficeGeneralIdArray.Length <= 0)
            return;
        if (cityOfficeGeneralIdArray.Length == 1)
        {
            this.prefectId = cityOfficeGeneralIdArray[0];
            return;
        }

        for (byte index = 0; index < cityOfficeGeneralIdArray.Length; index = (byte)(index + 1))
        {
            short generalId = cityOfficeGeneralIdArray[index];
            General general = GeneralListCache.GetGeneral(generalId);
            if (generalId == this.cityBelongKing)
            {
                prefectValue = 1000;
                prefectId = generalId;
                i1 = index;
                break;
            }
            if (general.getLoyalty() >= 60 && general.getSatrapValue() > prefectValue)
            {
                prefectValue = general.getSatrapValue();
                prefectId = cityOfficeGeneralIdArray[index];
                i1 = index;
            }
        }

        if (prefectValue == 0)
        {
            i1 = 0;
            prefectId = cityOfficeGeneralIdArray[0];
            for (byte byte3 = 1; byte3 < cityOfficeGeneralIdArray.Length; byte3 = (byte)(byte3 + 1))
            {
                if (GeneralListCache.GetGeneral(prefectId).getLoyalty() < GeneralListCache.GetGeneral(cityOfficeGeneralIdArray[byte3]).getLoyalty())
                {
                    prefectId = cityOfficeGeneralIdArray[byte3];
                    i1 = byte3;
                }
            }
        }

        this.prefectId = prefectId;
        for (byte byte4 = (byte)i1; byte4 > 0; byte4 = (byte)(byte4 - 1))
            cityOfficeGeneralIdArray[byte4] = cityOfficeGeneralIdArray[byte4 - 1];
        cityOfficeGeneralIdArray[0] = prefectId;
        this.cityOfficeGeneralId = cityOfficeGeneralIdArray;
    }




    // ��ȡ��󹥻���
    public int getMaxAtkPower()
    {
        short[] cityOfficeGeneralIdArray = getCityOfficeGeneralIdArray();
        if (cityOfficeGeneralIdArray.Length < 1)
            return 0;
        double[] power = new double[cityOfficeGeneralIdArray.Length];
        for (byte index = 0; index < cityOfficeGeneralIdArray.Length; index = (byte)(index + 1))
        {
            short generalId = cityOfficeGeneralIdArray[index];
            General general = GeneralListCache.GetGeneral(generalId);
            power[index] = general.GetBattlePower();
        }
        double totalPower = 0.0;
        for (int i = 0; i < power.Length; i++)
            totalPower += power[i];
        if (this.cityBelongKing != CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).countryKingId)
        {
            double minPower = power[0];
            for (int j = 1; j < power.Length; j++)
            {
                if (minPower > power[j])
                    minPower = power[j];
            }
            totalPower -= minPower;
        }
        else
        {
            totalPower *= 1.2;
        }
        int needFood = getAlreadyAllSoldierNum() / 8 + 1;
        if (this.food < needFood)
            totalPower = totalPower * this.food / needFood;
        short needMoney = (short)(getAllSoldierNum() / 10);
        if (this.money > needMoney)
            totalPower = totalPower * 5.0 / 3.0;
        return (int)totalPower;
    }

    // ��ȡ������
    public int GetDefenseAbility()
    {
        int curEnemyCityDefPower;
        if (this.cityBelongKing == CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).countryKingId)
        {
            curEnemyCityDefPower = (int)(GetCityDefPower() * 1.2);
        }
        else
        {
            curEnemyCityDefPower = (int)GetCityDefPower();
        }
        return curEnemyCityDefPower;
    }

    // ��ȡAI���еķ�����
    private int getAICityDefPower()
    {
        int power = 1;
        short[] cityOfficeGeneralIdArray = getCityOfficeGeneralIdArray();
        int needFood = getAlreadyAllSoldierNum() / 8 + 1;
        for (byte index = 0; index < cityOfficeGeneralIdArray.Length; index = (byte)(index + 1))
        {
            short generalId = cityOfficeGeneralIdArray[index];
            General general = GeneralListCache.GetGeneral(generalId);
            if (generalId == this.prefectId)
            {
                power += getSatrapGenPower();
            }
            else
            {
                power += general.getGeneralPower();
            }
        }
        if (this.food < needFood)
            power = power * (this.food + 1) / needFood;
        return power;
    }

    // ��ȡ���еķ�����
    public double GetCityDefPower()
    {
        double power = 0.0;
        short[] cityOfficeGeneralIdArray = getCityOfficeGeneralIdArray();
        for (byte index = 0; index < cityOfficeGeneralIdArray.Length; index = (byte)(index + 1))
        {
            short generalId = cityOfficeGeneralIdArray[index];
            General general = GeneralListCache.GetGeneral(generalId);
            if (generalId == this.prefectId)
            {
                power += general.GetBattlePower() * 1.2;
            }
            else
            {
                power += general.GetBattlePower();
            }
        }
        int needFood = cityOfficeGeneralIdArray.Length / 8 + 1;
        if (this.food < needFood)
            power = power * this.food / needFood;
        return power;
    }

    // ��ȡ������еķ�����
    private int getHmCityDefPower()
    {
        int power = 1;
        int needFood = getAllSoldierNum() / 8 + 1;
        for (byte index = 0; index < getCityGeneralNum(); index = (byte)(index + 1))
        {
            short generalId = this.cityOfficeGeneralId[index];
            General general = GeneralListCache.GetGeneral(generalId);
            if (generalId == this.prefectId)
            {
                if (general.generalSoldier < 800)
                {
                    power += getSatrapGenPower() / 2;
                    continue;
                }
            }
            power += general.getGeneralPower();
        }
        if (this.food < needFood)
            power = power * (this.food + 1) / needFood * 2;
        power -= power / 2;
        return power;
    }

    // ��ȡս����ԱID����
    public short[] GetWarOfficeGeneralIdArray(int power)
    {
        short[] result = getCityOfficeGeneralIdArray();
        if (result.Length < 2)
            return new short[0];
        do
        {
            short minBattlePowerGeneralId = getMinBattlePowerGeneralId(result);
            short[] tempResult = new short[result.Length - 1];
            int index = 0;
            for (int j = 0; j < result.Length; j++)
            {
                if (result[j] != minBattlePowerGeneralId)
                {
                    tempResult[index] = result[j];
                    index++;
                }
            }
            result = tempResult;
            power = (int)(power - GeneralListCache.GetGeneral(minBattlePowerGeneralId).GetBattlePower());
        } while (power > 0 && result.Length > 1);
        for (int i = 0; i < result.Length; i++)
        {
            short generalId = result[i];
            if (generalId == this.cityBelongKing || generalId == this.prefectId)
            {
                if (i == 0)
                    break;
                short otherGeneralId = result[0];
                result[0] = generalId;
                result[i] = otherGeneralId;
                break;
            }
        }
        return result;
    }


    // ��ȡս��ֵ��͵��佫ID
    private short getMinBattlePowerGeneralId(short[] generals)
    {
        if (generals.Length < 1)
            return 0;
        double minBattlePower = GeneralListCache.GetGeneral(generals[0]).GetBattlePower();
        short resultGeneralId = generals[0];
        for (int i = 1; i < generals.Length; i++)
        {
            if (minBattlePower > GeneralListCache.GetGeneral(generals[i]).GetBattlePower())
            {
                minBattlePower = GeneralListCache.GetGeneral(generals[i]).GetBattlePower();
                resultGeneralId = generals[i];
            }
        }
        return resultGeneralId;
    }

    // ��ȡ������ս��ֵ��͵��佫ID
    public short getMinBattlePowerGeneralId()
    {
        return getMinBattlePowerGeneralId(this.cityOfficeGeneralId);
    }

    // ��ȡ������ս��ֵ��ߵ��佫ID
    public short getMaxBattlePowerGeneralId()
    {
        if (this.cityOfficeGeneralId.Length < 1)
            return 0;
        double maxBattlePower = GeneralListCache.GetGeneral(this.cityOfficeGeneralId[0]).GetBattlePower();
        short resultGeneralId = this.cityOfficeGeneralId[0];
        for (int i = 1; i < this.cityOfficeGeneralId.Length; i++)
        {
            if (maxBattlePower < GeneralListCache.GetGeneral(this.cityOfficeGeneralId[i]).GetBattlePower())
            {
                maxBattlePower = GeneralListCache.GetGeneral(this.cityOfficeGeneralId[i]).GetBattlePower();
                resultGeneralId = this.cityOfficeGeneralId[i];
            }
        }
        return resultGeneralId;
    }

    // ����̫�ص�ս����
    private int getSatrapGenPower()
    {
        General general = GeneralListCache.GetGeneral(this.prefectId);
        int power = 1;
        short gjl = (short)((int)(general.getSatrapValue() * 1.3));
        long gjl_jq = (1 + gjl * gjl * gjl / 100000);
        if (general.generalSoldier < 500)
            gjl_jq = (long)Mathf.Min(150L, gjl_jq);
        if (gjl_jq < 20L)
            gjl_jq = (long)Mathf.Max((general.generalSoldier / 150), gjl_jq);
        power = (int)(power + gjl_jq * (general.generalSoldier + 1));
        return power;
    }

    // �����ջ������ʳ����
    public short needFoodToHarvest()
    {
        int need = getAlreadyAllSoldierNum() / 100 + this.cityReserveSoldier / 300;
        if (GameInfo.month >= 5 && GameInfo.month < 10)
        {
            need = (10 - GameInfo.month) * need;
        }
        else if (GameInfo.month < 5)
        {
            need = (5 - GameInfo.month) * need;
        }
        else
        {
            need = (12 - GameInfo.month - 5) * need;
        }
        return (short)need;
    }

    // ���������佫��нˮ�ܺ�
    public int needAllSalariesMoney()
    {
        int result = 0;
        for (int i = 0; i < this.cityOfficeGeneralId.Length; i++)
        {
            General general = GeneralListCache.GetGeneral(this.cityOfficeGeneralId[i]);
            result += general.getSalary();
        }
        return result;
    }

    // ����һ����ս�������ʳ����
    public short needFoodWarAMonth()
    {
        return (short)(getAlreadyAllSoldierNum() / 8 + 1);
    }

    // ���������佫��ѧϰ����
    public short studyOfAllGeneral()
    {
        short learnNum = 0;
        short[] officeGeneralIdArray = getCityOfficeGeneralIdArray();
        for (byte byte1 = 0; byte1 < getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
        {
            short generalId = officeGeneralIdArray[byte1];
            General general = GeneralListCache.GetGeneral(generalId);
            general.study(learnNum);
        }
        return learnNum;
    }

    // ����Ƿ�����һ����������
    public bool isConnected(byte beCityId)
    {
        short[] cityIds = this.connectCityId;
        for (byte index = 0; index < cityIds.Length; index = (byte)(index + 1))
        {
            if (cityIds[index] == beCityId)
                return true;
        }
        return false;
    }



}