using System;
using UnityEngine;


// ����ʵ����
public class Weapon
{

    // ����ID
    [SerializeField] public byte weaponId { get; set; }
    // ��������
    [SerializeField] public string weaponName { get; set; }
    // �����۸�
    [SerializeField] public short weaponPrice { get; set; }
    // ��������
    [SerializeField] public byte weaponProperties { get; set; }
    // ��������
    [SerializeField] public byte weaponWeight { get; set; }
    // ��������
    [SerializeField] public byte weaponType { get; set; }
    
    // Ĭ�Ϲ��캯��
    public Weapon() { }

    // ���������캯��
    public Weapon(byte weaponId, string weaponName, short weaponPrice, byte weaponProperties, byte weaponWeight, byte weaponType)
    {
        this.weaponId = weaponId;
        this.weaponName = weaponName;
        this.weaponPrice = weaponPrice;
        this.weaponProperties = weaponProperties;
        this.weaponWeight = weaponWeight;
        this.weaponType = weaponType;
    }
}