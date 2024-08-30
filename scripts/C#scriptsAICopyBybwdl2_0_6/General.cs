using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using System.Text;


public class General  // �佫��
{
    [SerializeField] public short generalId;         // �佫ID
    [SerializeField] public string headImage;        // ͷ��ͼƬ·��
    [SerializeField] public string generalName;      // �佫����
    [SerializeField] public byte lead;               // �쵼��
    [SerializeField] public byte political;          // ��������
    [SerializeField] public short phase;             // ��ǰ�׶�
    [SerializeField] public byte isOffice;           // �Ƿ���ְ
    [SerializeField] public byte level;              // �ȼ�
    [JsonProperty("army[]")][SerializeField] public byte[] army = new byte[3];  // ���ӹ���
    [SerializeField] public byte force;              // ����ֵ
    [SerializeField] public short generalSoldier;    // ����ʿ������                               
    [SerializeField] public int maxSoldiers; // ���ʿ����
    [SerializeField] public int maxAttributeValue = 120; // �������ֵ
    [SerializeField] public byte moral;              // ����
    [SerializeField] public byte curPhysical; // ��ǰ����
    [SerializeField] public byte maxPhysical = 100;  // �������
    [SerializeField] public byte IQ;                 // ����
    [SerializeField] public short debutYears;        // �������
    public byte loyalty=99;           // �ҳ϶�
    [SerializeField] public byte debutCity;          // ��������
    [SerializeField] public short followGeneralId;   // ������佫ID
    [SerializeField] public int experience;        // ����ֵ
    [SerializeField] public byte weapon;             // ����
    [SerializeField] public byte armor;              // ����
    [JsonProperty("skills[]")] public short[] skills = new short[5]; // �����б�
    public byte leadExp;            // �쵼������ֵ
    public byte forceExp;           // ��������ֵ
    public byte IQExp;              // ���̾���ֵ
    public byte moralExp;           // ���о���ֵ
    public byte politicalExp;       // ������������ֵ
    private byte salary = 1;        // ����
    public short haveMoney = 0;     // ӵ�еĽ�Ǯ
    public bool IsDie = false;      // �Ƿ�����
    public string profile = "";     // ���˼��



    // ���������е�ֵ�����ض���ʽ���ַ���
    public string GetArmyS()
    {
        // ����ÿ�����ֶ�Ӧ�ĺ�׺�ַ�
        char[] suffixes = { 'C', 'B', 'A', 'S' }; // ����0-3�ֱ��Ӧ'C', 'S', 'A', 'B'

        // ����ǰ׺�ַ�������
        string[] prefixes = { "ƽ", "ɽ", "ˮ" };

        // ʹ��StringBuilder����������ַ���
        StringBuilder result = new StringBuilder();

        // ȷ�����鳤�Ȳ�����prefixes���鳤��
        int Length = Mathf.Min(army.Length, prefixes.Length);

        // ���������е�ÿ��Ԫ��
        for (int i = 0; i < Length; i++)
        {
            // �������ֵ�Ƿ���suffixes�����������Χ��
            if (army[i] < suffixes.Length)
            {
                // ���ǰ׺�Ͷ�Ӧ�ĺ�׺�ַ�
                result.Append(prefixes[i]);
                result.Append(suffixes[army[i]]);
            }
            else
            {
                // �������ֵ������Χ��������Ӵ���������׷��һ�������ַ����ߺ���
                result.Append("?");
            }
        }

        return result.ToString();
    }


    /// <summary>
    /// ��ȡ��ǰ����ֵ
    /// </summary>
    /// <returns>��ǰ����ֵ</returns>
    public byte getCurPhysical()
    {
        return curPhysical;
    }

    /// <summary>
    /// ���õ�ǰ����ֵ
    /// </summary>
    /// <param name="curPhysical">�µ�����ֵ</param>
    public void setCurPhysical(byte curPhysical)
    {
        if (curPhysical > maxPhysical)
        {
            curPhysical = maxPhysical;
        }
        else if (curPhysical < 0)
        {
            curPhysical = 0;
        }

        this.curPhysical = curPhysical;
    }

    /// <summary>
    /// ��������ֵ
    /// </summary>
    /// <param name="physical">���ӵ�����ֵ</param>
    public void addCurPhysical(byte physical)
    {
        if (physical > maxPhysical - curPhysical)
        {
            physical = (byte)(maxPhysical - curPhysical);
        }

        curPhysical = (byte)(curPhysical + physical);
    }

    /// <summary>
    /// ��������ֵ
    /// </summary>
    /// <param name="physical">���ٵ�����ֵ</param>
    /// <returns>�Ƿ�������Ϊ0</returns>
    public bool decreaseCurPhysical(byte physical)
    {
        if (physical < 0)
        {
            physical = (byte)-physical;
        }

        curPhysical = (byte)(curPhysical - physical);

        if (curPhysical <= 0)
        {
            curPhysical = 0;
            return true;
        }

        return false;
    }



    /// <summary>
    /// ��ȡ�������нˮ
    /// </summary>
    /// <returns>���ص������нˮ</returns>
    public byte getSalary()
    {
        return (byte)(salary + level * 2);
    }

    /// <summary>
    /// �����ҳ϶ȣ����ֵΪ100
    /// </summary>
    /// <param name="tempLoyalty">�µ��ҳ϶�ֵ</param>
    public void SetLoyalty(byte tempLoyalty)
    {
        if (tempLoyalty > 100)
        {
            tempLoyalty = 100;
        }
        loyalty = tempLoyalty;
    }

    /// <summary>
    /// ��ȡ��ǰ�ҳ϶�
    /// </summary>
    /// <returns>���ص�ǰ�ҳ϶�</returns>
    public byte getLoyalty()
    {
        return loyalty;
    }

    /// <summary>
    /// �����ҳ϶ȣ���СֵΪ0
    /// </summary>
    /// <param name="tempLoyalty">���ٵ��ҳ϶�ֵ</param>
    public void decreaseLoyalty(byte tempLoyalty)
    {
        if (loyalty - tempLoyalty < 0)
        {
            loyalty = 0;
        }
        else
        {
            loyalty = (byte)(loyalty - tempLoyalty);
        }
    }

    /// <summary>
    /// �����ҳ϶ȣ����ֵΪ100
    /// </summary>
    /// <param name="tempLoyalty">���ӵ��ҳ϶�ֵ</param>
    public void AddLoyalty(byte tempLoyalty)
    {
        if (tempLoyalty + loyalty >= 100)
        {
            // ���� CountryListCache �� GetCountryByKingId �������ط����塣
            Country country = CountryListCache.GetCountryByKingId(generalId);
            if (country == null)
            {
                loyalty = 99;
            }
            else
            {
                loyalty = 100;
            }
        }
        else
        {
            loyalty = (byte)(loyalty + tempLoyalty);
        }
    }

    /// <summary>
    /// �������������ҳ϶�
    /// </summary>
    /// <param name="useMoney">�Ƿ�ʹ�ý�Ǯ</param>
    /// <returns>�����ҳ϶ȵı仯��</returns>
    public byte AddLoyalty(bool useMoney)
    {
        byte tempLoyalty = loyalty;
        if (loyalty < 30)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 11) + 20);
        }
        else if (loyalty < 50)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 11) + 10);
        }
        else if (loyalty < 70)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 11) + 5);
        }
        else if (loyalty < 80)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 8) + 3);
        }
        else if (loyalty < 85)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 7) + 1);
        }
        else if (loyalty < 90)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 5) + 1);
        }
        if (!useMoney)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 10));
        }
        if (loyalty > 99)
        {
            loyalty = 99;
        }
        return (byte)(loyalty - tempLoyalty);
    }



    /// <summary>
    /// ��ȡ��������һ������������ֵ
    /// </summary>
    /// <returns>�����ֵ</returns>
    public short getMaxExp()
    {
        switch (this.level)
        {
            case 1: return 6000;
            case 2: return 10000;
            case 3: return 14000;
            case 4: return 18000;
            case 5: return 22000;
            case 6: return 26000;
            case 7: return 30000;
            case 8: return short.MaxValue;
            default: return short.MaxValue;
        }
    }

    /// <summary>
    /// �������Ӿ���ֵ
    /// </summary>
    /// <param name="exp">Ҫ��ӵľ���ֵ</param>
    public void addexperience(int exp)
    {
        while (exp > 0)
        {
            exp--;
            experience++;

            // ��鵱ǰ����ֵ�Ƿ���ڻ���������ֵ
            if (experience >= getMaxExp())
            {
                // �����󽫾���ֵ����Ϊ��
                experience = 0;
                levelUp();
            }
        }
    }

    /// <summary>
    /// ������������
    /// </summary>
    private void levelUp()
    {
        level++;
        generalUpgrade();
    }



    /// <summary>
    /// ��ȡս������
    /// </summary>
    /// <returns>���ؼ�����ս����</returns>
    public double GetBattlePower()
    {
        double power = 0.0D;

        // ��ȡ��������
        Weapon weaponObj = WeaponListCache.getWeapon(this.weapon);
        if (weaponObj != null)
        {
            // ����������ս������Ӱ��
            power += weaponObj.weaponProperties * 1.3D;
        }

        // ��ȡ���߶���
        // ע��: ͨ�����߲���������б��л�ȡ�������������ȷ���߼�
        Weapon armorObj = WeaponListCache.getWeapon(this.armor);
        if (armorObj != null)
        {
            // ������߶�ս������Ӱ��
            power += armorObj.weaponProperties * 1.3D;
        }

        // �����������Զ�ս������Ӱ��
        power += this.force * 1.3D + this.IQ * 1.2D + this.curPhysical * 1.1D + (this.generalSoldier / 5);

        return power;
    }

    /// <summary>
    /// ��ȡ����÷�
    /// </summary>
    /// <returns>���ؽ���ĸ��������ܺ�</returns>
    public int getGeneralScore()
    {
        return this.lead + this.political + this.force + this.moral + this.IQ;
    }

    /// <summary>
    /// ��ȡ����ȼ�
    /// </summary>
    /// <returns>���ؽ���ĵȼ�</returns>
    public byte getGeneralGrade()
    {
        int generalScore = getGeneralScore();
        if (generalScore <= 297)
        {
            return 1;
        }
        else if (generalScore >= 298 && generalScore <= 338)
        {
            return 2;
        }
        else if (generalScore >= 339 && generalScore <= 449)
        {
            return 3;
        }
        else if (generalScore >= 450)
        {
            return 4;
        }
        return 0;
    }

    public string getGeneralGradeS()
    {
        // �������е�getGeneralGrade������ȡ�ȼ���ֵ
        byte grade = getGeneralGrade();

        // ���ݵȼ���ֵ������Ӧ������
        switch (grade)
        {
            case 1:
                return "�޶�";
            case 2:
                return "ƽӹ";
            case 3:
                return "��Ӣ";
            case 4:
                return "���";
            default:
                // ����ȼ�����Ԥ��ֵ������"δ֪"
                return "δ֪";
        }
    }

    /// <summary>
    /// ��������
    /// </summary>
    public void generalUpgrade()
    {
        if (this.level >= 8)
        {
            // ����ȼ��Ѿ��ﵽ���ֵ���򲻽�������
            return;
        }

        this.level = (byte)(this.level + 1); // �����ȼ�
        this.curPhysical = 100; // �ظ�����

        byte grade = getGeneralGrade(); // ��ȡ��ǰ�ȼ�

        // ���ݵȼ�����������Ե�
        int totalValue = UnityEngine.Random.Range(0, grade) + 1;
        for (int i = 0; i < totalValue; i++)
        {
            int index = UnityEngine.Random.Range(0, 5);
            addGeneralAttributeValue(index, 0); // ע��: �ڶ�������Ϊ0��������Ҫ�޸�Ϊʵ�����ӵ����Ե���
        }
    }



    // ���佫�������ֵ
    public void addGeneralAttributeValue(int attributeIndex, int iterationCount)
    {
        // ������������ﵽ5�Σ����˳��ݹ�
        if (iterationCount >= 5) return;

        switch (attributeIndex)
        {
            // ����쵼��С�����ֵ���������쵼��
            case 0 when lead < maxAttributeValue:
                lead++;
                break;
            // ���������С�����ֵ��������������
            case 1 when political < maxAttributeValue:
                political++;
                break;
            // �������С�����ֵ������������
            case 2 when force < maxAttributeValue:
                force++;
                break;
            // �������С�����ֵ�������ӵ���
            case 3 when moral < maxAttributeValue:
                moral++;
                break;
            // �������С�����ֵ������������
            case 4 when IQ < maxAttributeValue:
                IQ++;
                break;
            // Ĭ�������������������Ϊ0
            default:
                attributeIndex = 0;
                break;
        }

        // ���������������0����������������������ݹ�
        if (attributeIndex != 0)
        {
            attributeIndex++;
            iterationCount++;
            addGeneralAttributeValue(attributeIndex, iterationCount);
        }
    }


    // ��ȡ�佫�����ʿ����
    public short getMaxGeneralSoldier()
    {
        // ֱ��ʹ�� haveKill �߼�������ض�����
        // ���� 5 �����ܣ�����Ϊ 4���Ƿ񱻡�ɱ���������
        bool GetSkill_4 = ((this.skills[4] >> 10 - 0) & 0x1) == 1;

        if (GetSkill_4)
        {
            // ����ض����ܱ����������� 3000
            return 3000;
        }
        else
        {
            // ����ض�����δ�����������쵼���͵ȼ�����ʿ������
            return (short)(1000 + 12 * this.lead + 10 * this.level);
        }
    }


    /// <summary>
    ///�趨�ܶ�ֵ
    /// <summary>
    /// <returns>�ܶ�ֵ</returns>
    public int getSatrapValue()
    {
        // ���㹫ʽ
        return (int)(this.lead * 1.42f + this.IQ * 0.25f + this.force * 0.33f + ((this.lead * 2 + this.force + this.IQ) * (this.level - 1)) * 0.04f);
    }

    /// <summary>
    /// ��ȡ�佫��ս����
    /// </summary>
    /// <returns>ս����</returns>
    public int getGeneralPower()
    {
        int power = 1;
        short satrapValue = (short)getSatrapValue();
        long adjustedValue = (1 + satrapValue * satrapValue * satrapValue / 100000);

        if (this.generalSoldier < 100)
        {
            adjustedValue = Math.Min(100L, adjustedValue);
            return 0;
        }

        if (adjustedValue < 20L)
        {
            adjustedValue = Math.Max((this.generalSoldier / 150), adjustedValue);
        }

        power += (int)(adjustedValue * (this.generalSoldier + 1));
        return power;
    }

    /// <summary>
    /// �����쵼����
    /// </summary>
    /// <param name="exp">���ӵľ���ֵ</param>
    public void addLeadExp(byte exp)
    {
        if (this.lead < 120)
        {
            for (int i = 0; i < exp; i++)
            {
                this.leadExp = (byte)(this.leadExp + 1);
                if (this.leadExp >= 100)
                {
                    this.leadExp = (byte)(this.leadExp - 100);
                    this.lead = (byte)(this.lead + 1);
                    if (this.lead == 120)
                    {
                        this.leadExp = 100;
                        return;
                    }
                }
            }
        }
    }



    /// <summary>
    /// ������������ֵ��
    /// </summary>
    /// <param name="exp">����ֵ</param>
    public void addforceExp(byte exp)
    {
        // �������ֵС�����ֵ
        if (force < 120)
        {
            for (int i = 0; i < exp; i++)
            {
                // ������������ֵ
                forceExp = (byte)(forceExp + 1);
                // �����������ֵ�ﵽ�򳬹�100
                if (forceExp >= 100)
                {
                    // ������������ֵ
                    forceExp = (byte)(forceExp - 100);
                    // ��������ֵ
                    force = (byte)(force + 1);
                    // �������ֵ�ﵽ���ֵ
                    if (force == 120)
                    {
                        // ������������ֵ��100
                        forceExp = 100;
                        // ����ѭ��
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// ������������ֵ��
    /// </summary>
    /// <param name="exp">����ֵ</param>
    public void addIQExp(byte exp)
    {
        // �������ֵС�����ֵ
        if (IQ < 120)
        {
            for (int i = 0; i < exp; i++)
            {
                // ������������ֵ
                IQExp = (byte)(IQExp + 1);
                // �����������ֵ�ﵽ�򳬹�100
                if (IQExp >= 100)
                {
                    // ������������ֵ
                    IQExp = (byte)(IQExp - 100);
                    // ��������ֵ
                    IQ = (byte)(IQ + 1);
                    // �������ֵ�ﵽ���ֵ
                    if (IQ == 120)
                    {
                        // ������������ֵ��100
                        IQExp = 100;
                        // ����ѭ��
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// �������ξ���ֵ��
    /// </summary>
    /// <param name="exp">����ֵ</param>
    public void addPoliticalExp(byte exp)
    {
        // �������ֵС�����ֵ
        if (political < 120)
        {
            // ֱ���������ξ���ֵ
            politicalExp = (byte)(politicalExp + exp);
            // ������ξ���ֵ�ﵽ�򳬹�100
            if (politicalExp >= 100)
            {
                // �������ξ���ֵ
                politicalExp = (byte)(politicalExp - 100);
                // ��������ֵ
                political = (byte)(political + 1);
                // �������ֵ�ﵽ���ֵ
                if (political == 120)
                {
                    // �������ξ���ֵ��100
                    politicalExp = 100;
                }
            }
        }
    }

    /// <summary>
    /// ���ӵ��¾���ֵ��
    /// </summary>
    /// <param name="exp">����ֵ</param>
    public void addMoralExp(byte exp)
    {
        // �������ֵС�����ֵ
        if (moral < 120)
        {
            // ֱ�����ӵ��¾���ֵ
            moralExp = (byte)(moralExp + exp);
            // ������¾���ֵ�ﵽ�򳬹�100
            if (moralExp >= 100)
            {
                // ���õ��¾���ֵ
                moralExp = (byte)(moralExp - 100);
                // ��������ֵ
                moral = (byte)(moral + 1);
                // �������ֵ�ﵽ���ֵ
                if (moral == 120)
                {
                    // ���õ��¾���ֵ��100
                    moralExp = 100;
                }
            }
        }
    }



    /// <summary>
    /// ѧϰ����
    /// </summary>
    /// <param name="learnNum">��ʼѧϰ����</param>
    public void study(short learnNum)
    {
        // �����������120
        if (this.IQ < 120)
        {
            // ��������ֵ����10�Ľ�����в�ͬ�Ĵ���
            switch (this.IQ / 10)
            {
                // ������0-40֮��
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    // �������ֵ�㹻ѧϰ
                    if (this.experience >= getLearnNeedExp())
                    {
                        startStudy();
                    }
                    // ����ѧϰ����
                    learnNum = (short)(learnNum + 1);
                    break;
                // ����Ϊ50
                case 5:
                    // �������ֵ�㹻�ҵȼ����ڵ���2
                    if (this.experience >= getLearnNeedExp() && this.level >= 2)
                    {
                        startStudy();
                    }
                    // ����ѧϰ����
                    learnNum = (short)(learnNum + 1);
                    break;
                // ����Ϊ60
                case 6:
                    // �������ֵ�㹻�ҵȼ����ڵ���3
                    if (this.experience >= getLearnNeedExp() && this.level >= 3)
                    {
                        startStudy();
                    }
                    // ����ѧϰ����
                    learnNum = (short)(learnNum + 1);
                    break;
                // ����Ϊ70
                case 7:
                    // �������ֵ�㹻�ҵȼ����ڵ���4
                    if (this.experience >= getLearnNeedExp() && this.level >= 4)
                    {
                        startStudy();
                    }
                    // ����ѧϰ����
                    learnNum = (short)(learnNum + 1);
                    break;
                // ����Ϊ80
                case 8:
                    // �������ֵ�㹻�ҵȼ����ڵ���7
                    if (this.experience >= getLearnNeedExp() && this.level >= 7)
                    {
                        startStudy();
                    }
                    break;
                // ����Ϊ90��120֮��
                case 9:
                case 10:
                case 11:
                case 12:
                    // �������ֵ�㹻�ҵȼ�����8
                    if (this.experience >= getLearnNeedExp() && this.level == 8)
                    {
                        startStudy();
                    }
                    // ����ѧϰ����
                    learnNum = (short)(learnNum + 1);
                    break;
            }
        }
    }

    /// <summary>
    /// ��ʼѧϰ
    /// </summary>
    void startStudy()
    {
        // ��������ľ���ֵ
        this.experience = (short)(this.experience - getLearnNeedExp());
        // ��������
        this.IQ = (byte)(this.IQ + 5);
        // ���ѧϰ���
        Debug.Log("�佫: " + this.generalName + " ѧϰ�� IQ ���� 5.");
    }

    /// <summary>
    /// ��ȡѧϰ�������С����ֵ
    /// </summary>
    /// <returns>���辭��ֵ</returns>
    short getLearnNeedExp()
    {
        // �������辭��ֵ
        return (short)(200 + this.IQ * 50);
    }


    /// <summary>
    /// ����IQ�͵ȼ������佫�ƻ�������
    /// </summary>
    /// <returns>���ؼƻ�����</returns>
    public byte getGeneralPlanNum()
    {
        // ������̴��ڵ���100�ҵȼ����ڵ���8���򷵻�16
        if (IQ >= 100 && level >= 8)
            return 16;

        // ������̴��ڵ���95�ҵȼ����ڵ���7���򷵻�15
        if (IQ >= 95 && level >= 7)
            return 15;

        // ������̴��ڵ���93�ҵȼ����ڵ���5���򷵻�14
        if (IQ >= 93 && level >= 5)
            return 14;

        // ������̴��ڵ���90�ҵȼ����ڵ���4���򷵻�12
        if (IQ >= 90 && level >= 4)
            return 12;

        // ������̴��ڵ���85���򷵻�10
        if (IQ >= 85)
            return 10;

        // ������̴��ڵ���80���򷵻�8
        if (IQ >= 80)
            return 8;

        // ������̴��ڵ���60���򷵻�6
        if (IQ >= 60)
            return 6;

        // �������С��40���򷵻�2�����򷵻�4
        return (byte)((IQ < 40) ? 2 : 4);
    }

    public static string GetActiveSkills(General general)
    {
        if (general.skills == null || general.skills.Length != 5)
        {
            Debug.LogError("�������鲻��Ϊ���ұ������ 5 ��Ԫ�ء�");
            return string.Empty;
        }

        // �ؼ���ӳ���50 ������
        string[] skillNames = new string[]
        {
            "����", "��ı", "�ٳ�", "��ʦ", "��", "����", "����", "����", "Ϯ��", "��ڧ",
            "����", "�ｫ", "����", "����", "ˮ��", "��ս", "����", "���", "����", "�ͽ�",
            "����", "��Ϯ", "����", "����", "�س�", "����", "����", "����", "����", "����",
            "����", "����", "����", "�̲�", "��ʿ", "��ˮ", "���", "����", "����", "����",
            "ͳ��", "�Ӷ�", "����", "һ��", "ˮ��", "����", "����", "�Խ�", "�侲", "����"
        };

        List<string> activeSkills = new List<string>();

        // ���� skills[] ����
        for (int i = 0; i < general.skills.Length; i++)
        {
            short skillValue = general.skills[i];

            // �����һ�е�ֵΪ 0������
            if (skillValue == 0)
            {
                Debug.Log($"����[{i}]��ֵΪ0��������");
                continue;
            }

            // ����ÿ�� skillValue �� 10 λ
            for (int bitPosition = 0; bitPosition < 11; bitPosition++)
            {
                // ��� skillValue �ĵ� (10 - bitPosition) λ�Ƿ�Ϊ 1
                if ((skillValue & (1 << (10 - bitPosition))) != 0)
                {
                    int skillIndex = i * 10 + bitPosition;

                    // ȷ�������ڼ��ܱ�ķ�Χ��
                    if (skillIndex < skillNames.Length)
                    {
                        Debug.Log($"�����ؼ�: {skillNames[skillIndex]} (����[{i}]�ĵ� {bitPosition + 1} λ)");
                        activeSkills.Add(skillNames[skillIndex]);
                    }
                    else
                    {
                        Debug.LogWarning($"��������������Χ: {skillIndex}");
                    }
                }
            }
        }

        // ����ƴ�Ӻ���ؼ��ַ�����ʹ�������ո�ָ�
        return string.Join("  ", activeSkills);
    }
}
