using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;


    public class GameThread // ��������һ���µ�����
    {
        // �ֶζ���
        byte txxxx;
        int[] gfZL;
        int[] ffZL;
        int gfZZL;
        int ffZZL;
        short sd1;
        short sd2;
        bool wjct;
        bool ctsb;
        private short jsbl;
        byte fsjl;
        byte gdcs;
        bool bngd;
        bool bxct;
        bool dttb;
        byte[] maxrestrain;
        readonly byte a_byte_fld = 1;
        readonly byte b_byte_fld = 2;
        readonly byte c_byte_fld = 4;
        readonly byte d_byte_fld = 8;
        readonly byte e_byte_fld = 16;
        readonly byte f_byte_fld = 32;

        byte[] k_byte_array1d_fld;

        byte[] warWeaponShop;

        // ���������ߡ���ì����������
        byte[,] swordKind = new byte[,] {
            { 0, 1, 2, 3 },
            { 1, 2, 3, 4 },
            { 1, 2, 3, 4 },
            { 0, 1, 2, 3 },
            { 0, 1, 2, 3 },
            { 0, 1, 2, 3 },
            { 1, 2, 3, 4 }
        };
        byte[,] knifeKind = new byte[,] {
            { 8, 9, 10, 11 },
            { 10, 11, 12, 13 },
            { 10, 11, 12, 13 },
            { 8, 9, 10, 11 },
            { 8, 9, 10, 15 },
            { 8, 9, 10, 11 },
            { 10, 11, 12, 13 }
        };
        byte[,] pikeKind = new byte[,] {
            { 16, 17, 18, 19 },
            { 17, 18, 19, 20 },
            { 17, 18, 19, 20 },
            { 16, 17, 18, 23 },
            { 17, 18, 19, 20 },
            { 17, 18, 19, 22 },
            { 18, 19, 20, 21 }
        };
        byte[,] armorKind = new byte[,] {
            { 24, 25, 26, 27 },
            { 26, 27, 28, 29 },
            { 26, 27, 28, 30 },
            { 24, 25, 26, 27 },
            { 25, 26, 27, 28 },
            { 24, 25, 26, 27 },
            { 26, 27, 28, 29 }
        };
        short[] r_short_array1d_fld;
        byte[] D_byte_array1d_fld;
        short[] s_short_array1d_fld;
        System.Random random;
        byte j_byte_fld;
        byte curTurnsCountryId;
        byte m_byte_fld;
        byte tarCity;
        byte curCity;
        byte p_byte_fld;
        short HMGeneralId;
        short AIGeneralId;
        short[] chooseGeneralIdArray;
        byte chooseGeneralNum;
        byte s_byte_fld;
        byte AIUseOrderNum;
        byte userOrderNum;
        bool a_boolean_fld;
        bool b_boolean_fld;
        bool c_boolean_fld;
        short tipsGeneralId;
        string a_java_lang_String_fld;
        bool d_boolean_fld;
        short[] canToDoGeneral_Array;
        byte canToDoGeneralNum;
        int eventId;
        int b_int_fld;
        byte[] noAllianceCountryIdArray;
        byte[] G_byte_array1d_fld;
        byte disasterThings;
        byte x_byte_fld;
        bool e_boolean_fld;
        short e_short_fld;
        short userKingId;
        short f_short_fld;
        short aiKingId;
        public static byte curWarCityId;
        byte B_byte_fld;
        short humanMoney_inWar;
        short humanGrain_inWar;
        short aiMoney_inWar;
        short aiGrain_inWar;
        short[] humanGeneralId_inWar;
        short[] aiGeneralId_inWar;
        byte humanGeneralNum_inWar;
        byte aiGeneralNum_inWar;
        byte E_byte_fld;
        byte F_byte_fld;
        byte[,] bigWar_coordinate= new byte[19, 32];
        byte cols;
        byte rows;
        bool AIAttackHM;
        byte[] humanUnitCellX;
        byte[] humanUnitCellY;
        byte[] aiUnitCellX;
        byte[] aiUnitCellY;
        byte[] humanUnitTrapped;
        byte[] aiUnitTrapped;
        byte I_byte_fld;
        byte J_byte_fld;
        byte K_byte_fld;
        byte L_byte_fld;
        byte day;
        bool g_boolean_fld;
        byte N_byte_fld;
        string b_java_lang_String_fld;
        bool h_boolean_fld;
        byte O_byte_fld;
        byte warTerrain;
        byte humanSmallSoldierNum;
        byte aiSmallSoldierNum;
        // ��������ʼ��smallWarCoordinate��ά���飬���ڱ�ʾս��������״̬
        byte[][] smallWarCoordinate;

        byte T_byte_fld;
        byte U;
        byte V;
        byte W;
        byte X;
        byte Y;
        byte[][] i_byte_array2d_fld = new byte[][]
        {
        new byte[] { 2, 100 },
        new byte[] { 2, 3, 3, 99, 4, 1 },
        new byte[] { 5, 1 },
        new byte[] { 2, 3, 6, 3, 83, 3, 84, 85, 1 },
        new byte[] { 2, 8 },
        new byte[] { 9, 3, 91, 1 },
        new byte[] { 3, 10, 1 },
        new byte[] { 3, 3, 98, 1 },
        new byte[] { 3, 11, 1 },
        new byte[] { 3, 97 },
        new byte[] { 3, 12, 96, 1 },
        new byte[] { 3, 12, 95, 1 },
        new byte[] { 2, 16, 1 },
        new byte[] { 3, 13, 94, 1 },
        new byte[] { 3, 12, 93, 1 },
        new byte[] { 14, 1 },
        new byte[] { 3, 15, 1 },
        new byte[] { 3, 89 },
        new byte[] { 3, 88, 1 },
        new byte[] { 2, 3, 3, 92, 1 },
        new byte[] { 2, 3, 3, 90, 1 },
        new byte[] { 17, 87 },
        new byte[] { 17, 86 }
        };

        byte[][] smallSoldierCellX;
        byte[][] smallSoldierCellY;
        byte[][] smallSoldierKind;
        short[][] smallSoldierAtk;
        short[][] smallSoldierDef;
        byte[][] smallSoldierAction;
        byte[][] smallSoldierOrder;
        short[][] smallSoldierBlood;
        bool[][] a_boolean_array2d_fld;
        bool[][] smallSoldier_isSurvive;
        byte Z;
        byte aa;
        byte ab;
        byte ac;
        short[] x_short_array1d_fld = new short[4];
        short[] y_short_array1d_fld = new short[4];
        byte ad;
        byte[] P_byte_array1d_fld = new byte[4];

        byte ae;

        bool i_boolean_fld;
        bool j_boolean_fld;
        byte af;
        byte ag;
        byte ah;
        byte ai;
        byte aj;
        byte ak;
        byte al;
        byte am;
        bool k_boolean_fld;
        bool l_boolean_fld;
        short HMSingleAtk;
        short HMSingleDef;
        short AISingleAtk;
        short AISingleDef;
        bool m_boolean_fld;
        byte an;
        int c_int_fld;
        byte ao;
        byte ap;
        byte aq;
        int d_int_fld;
        bool n_boolean_fld;
        byte ar;
        int e_int_fld;
        byte a_s;
        byte at;
        byte[] Q_byte_array1d_fld;
        int f_int_fld;
        bool o_boolean_fld;
        byte au;
        byte av;
        int score;
        int unify;
        byte aw;
        int i_int_fld;
        int j_int_fld;
        byte[] R_byte_array1d_fld;
        byte[] S_byte_array1d_fld;
        byte[] T_byte_array1d_fld;
        string c_java_lang_String_fld;
        string d_java_lang_String_fld;
        string e_java_lang_String_fld;
        byte[] countryOrder;
        short[] countryPhase;

        // λ������
        byte[][] CAS_sc;

        // ������Ϣ
        float[] topInf;

        // ʿ������������
        short[,] soldierAtk;
        short[,] soldierDef;

        // ʿ����������
        byte[][] coodinateSoldierKind;

        // AI ����״̬
        bool aiAtkHm;

        // ս������
        byte hmbattleIndex;
        byte aibettleIndex;

        // AI �������
        byte[] aiGeneralFinshMove;
        byte[] aiGeneralHaveMove;
        byte[] aiGeneralMoveBonus;

        bool lessMoveBouns;
        byte curAIindex;

        // �������ƶ���ͼ
        byte[,] buildingMoveMap;

        // ��ǰ�����ƶ���ͼ
        byte[,] curGeneralMoveMap;

        // �ƶ�·��
        UnityEngine.Vector2 movePath;

        // ���ཫ�����
        byte[] humanGeneralFinshMove;
        byte[] humanGeneralMoveBonus;

        bool DJ;
        bool AIJH;
        bool HMJH;

        // �˺�ͳ��
        short HMTotalSoldierHurt;
        short AITotalSoldierHurt;
        short HMTotalGeneralHurt;
        short AITotalGeneralHurt;

        bool singleFigth;

        // ս����ʼ����
        byte HMfirstPhy;
        byte AIfirstPhy;

        // ģ������
        short moniSd1;
        short moniSd2;
        int fmoney;
        int ffood;
        byte warNum;
        int[] gfzdl;
        int[] ffzdl;

        // ģ��ս������
        byte[][] moniwarT;

        // �����ֶ�
        public string re;
        public byte[] higSort;

        // ���ݵ÷ֵ���R_byte_array1d_fld�����е�Ԫ��ֵ
        void void_ii_a(int i1, int j1)
        {
            if (i1 >= 700)
            {
                this.R_byte_array1d_fld[j1] = 6;
                this.score += 100;
            }
            else if (i1 >= 600)
            {
                this.R_byte_array1d_fld[j1] = 5;
                this.score += 80;
            }
            else if (i1 >= 500)
            {
                this.R_byte_array1d_fld[j1] = 4;
                this.score += 70;
            }
            else if (i1 >= 400)
            {
                this.R_byte_array1d_fld[j1] = 3;
                this.score += 60;
            }
            else if (i1 >= 300)
            {
                this.R_byte_array1d_fld[j1] = 2;
                this.score += 40;
            }
            else if (i1 >= 200)
            {
                this.R_byte_array1d_fld[j1] = 1;
                this.score += 20;
            }
            else
            {
                this.R_byte_array1d_fld[j1] = 0;
            }
            this.unify = 1 + i1 / 100;
        }


        // ����ũҵƽ��ֵ���������ַ���
        void void_a()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                i1 += (CityListCache.GetCityByCityId(byte0)).agro;
            }
            i1 /= CityListCache.CITY_NUM - 1;
            void_ii_a(i1, 0);
        }

        // ����ó��ƽ��ֵ���������ַ���
        void void_b()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < 37; byte0 = (byte)(byte0 + 1))
            {
                i1 += (CityListCache.GetCityByCityId(byte0)).trade;
            }
            i1 /= CityListCache.CITY_NUM - 1;
            void_ii_a(i1, 1);
        }

        // �������ƽ��ֵ���������ַ���
        void void_c()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                i1 += (CityListCache.GetCityByCityId(byte0)).floodControl;
            }
            i1 /= CityListCache.CITY_NUM - 1;
            if (i1 >= 99)
            {
                this.R_byte_array1d_fld[2] = 4;
                this.score += 100;
            }
            else if (i1 >= 80)
            {
                this.R_byte_array1d_fld[2] = 3;
                this.score += 80;
            }
            else if (i1 >= 70)
            {
                this.R_byte_array1d_fld[2] = 2;
                this.score += 70;
            }
            else if (i1 >= 50)
            {
                this.R_byte_array1d_fld[2] = 1;
                this.score += 50;
            }
            else
            {
                this.R_byte_array1d_fld[2] = 0;
            }
            this.unify += 1 + i1 / 10;
        }

        // �����˿�ƽ��ֵ���������ַ���
        void void_d()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                i1 += (CityListCache.GetCityByCityId(byte0)).population;
            }
            i1 /= CityListCache.CITY_NUM - 1;
            if (i1 >= 700000)
            {
                this.R_byte_array1d_fld[3] = 5;
                this.score += 100;
            }
            else if (i1 >= 600000)
            {
                this.R_byte_array1d_fld[3] = 4;
                this.score += 80;
            }
            else if (i1 >= 400000)
            {
                this.R_byte_array1d_fld[3] = 3;
                this.score += 70;
            }
            else if (i1 >= 200000)
            {
                this.R_byte_array1d_fld[3] = 2;
                this.score += 50;
            }
            else if (i1 >= 100000)
            {
                this.R_byte_array1d_fld[3] = 1;
                this.score += 40;
            }
            else
            {
                this.R_byte_array1d_fld[3] = 0;
            }
            this.unify += i1 / 100000 + 1;
        }

    



        // ����ͳ����ƽ��ֵ���������ַ���
        void void_e()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                i1 += (CityListCache.GetCityByCityId(byte0)).rule;
            }
            i1 /= CityListCache.CITY_NUM - 1;
            if (i1 >= 99)
            {
                this.R_byte_array1d_fld[5] = 5;
                this.score += 100;
            }
            else if (i1 >= 90)
            {
                this.R_byte_array1d_fld[5] = 4;
                this.score += 90;
            }
            else if (i1 >= 80)
            {
                this.R_byte_array1d_fld[5] = 3;
                this.score += 80;
            }
            else if (i1 >= 60)
            {
                this.R_byte_array1d_fld[5] = 2;
                this.score += 60;
            }
            else if (i1 >= 30)
            {
                this.R_byte_array1d_fld[5] = 1;
                this.score += 20;
            }
            else
            {
                this.R_byte_array1d_fld[5] = 0;
            }
            this.unify += i1 / 10 + 1;
        }

        // ����ʿ��ƽ��ֵ���������ַ���
        void void_f()
        {
            int i1 = 0;
            short wjsl = 1; byte byte0;
            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte0);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                for (byte byte1 = 1; byte1 < officeGeneralIdArray.Length; byte1 = (byte)(byte1 + 1))
                {
                    i1 += (GeneralListCache.GetGeneral(officeGeneralIdArray[byte1])).generalSoldier;
                }
            }

            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                wjsl = (short)(wjsl + CityListCache.GetCityByCityId(byte0).getCityGeneralNum());
            }

            i1 /= wjsl;
            if (i1 >= 1000)
            {
                this.R_byte_array1d_fld[6] = 5;
                this.score += 100;
            }
            else if (i1 >= 900)
            {
                this.R_byte_array1d_fld[6] = 4;
                this.score += 90;
            }
            else if (i1 >= 800)
            {
                this.R_byte_array1d_fld[6] = 3;
                this.score += 80;
            }
            else if (i1 >= 700)
            {
                this.R_byte_array1d_fld[6] = 2;
                this.score += 70;
            }
            else if (i1 >= 500)
            {
                this.R_byte_array1d_fld[6] = 1;
                this.score += 50;
            }
            else
            {
                this.R_byte_array1d_fld[6] = 0;
                this.score += 30;
            }
            if (i1 >= 1000)
            {
                this.unify += 10;
            }
            else
            {
                this.unify += i1 / 100;
            }
        }

        // �����ҳ϶�ƽ��ֵ���������ַ���
        void void_g()
        {
            int i1 = -100;
            short wjsl = 1; byte byte0;
            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte0);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                for (byte byte1 = 1; byte1 < officeGeneralIdArray.Length; byte1 = (byte)(byte1 + 1))
                {
                    i1 += GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]).getLoyalty();
                }
            }
            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                wjsl = (short)(wjsl + CityListCache.GetCityByCityId(byte0).getCityGeneralNum());
            }

            i1 /= wjsl;
            if (i1 >= 99)
            {
                this.R_byte_array1d_fld[4] = 6;
                this.score += 100;
            }
            else if (i1 >= 95)
            {
                this.R_byte_array1d_fld[4] = 5;
                this.score += 90;
            }
            else if (i1 >= 90)
            {
                this.R_byte_array1d_fld[4] = 4;
                this.score += 80;
            }
            else if (i1 >= 80)
            {
                this.R_byte_array1d_fld[4] = 3;
                this.score += 70;
            }
            else if (i1 >= 60)
            {
                this.R_byte_array1d_fld[4] = 2;
                this.score += 50;
            }
            else if (i1 >= 36)
            {
                this.R_byte_array1d_fld[4] = 1;
                this.score += 20;
            }
            else
            {
                this.R_byte_array1d_fld[4] = 0;
                this.score += 10;
            }
            this.unify += i1 / 10 + 1;
        }




         // ���㽫���ȼ�ƽ��ֵ���������ַ���
        void void_h()
        {
            int i1 = 0;
            short wjsl = 1; byte byte0;
            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte0);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                for (byte byte1 = 1; byte1 < officeGeneralIdArray.Length; byte1 = (byte)(byte1 + 1))
                {
                    i1 += (GeneralListCache.GetGeneral(officeGeneralIdArray[byte1])).level;
                }
            }
            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                wjsl = (short)(wjsl + CityListCache.GetCityByCityId(byte0).getCityGeneralNum());
            }

            i1 /= wjsl;
            if (i1 >= 8)
            {
                this.score += 100;
            }
            else if (i1 >= 7)
            {
                this.score += 90;
            }
            else if (i1 >= 6)
            {
                this.score += 80;
            }
            else if (i1 >= 5)
            {
                this.score += 70;
            }
            else if (i1 >= 4)
            {
                this.score += 60;
            }
            else if (i1 >= 3)
            {
                this.score += 30;
            }
            if (i1 == 8)
            {
                this.unify += 10;
            }
            else
            {
                this.unify += i1;
            }
        }

        // ��������ƽ��ֵ���������ַ���
        void void_i()
        {
            int i1 = 0;
            short wjsl = 1;
            for (byte byte1 = 1; byte1 < CityListCache.CITY_NUM; byte1 = (byte)(byte1 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte1);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                for (byte byte2 = 0; byte2 < officeGeneralIdArray.Length; byte2 = (byte)(byte2 + 1))
                {
                    byte b = (GeneralListCache.GetGeneral(officeGeneralIdArray[byte2])).IQ;
                    i1 += b;
                }
            }

            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                wjsl = (short)(wjsl + CityListCache.GetCityByCityId(byte0).getCityGeneralNum());
            }

            i1 /= wjsl;
            if (i1 >= 90)
            {
                this.score += 100;
            }
            else if (i1 == 80)
            {
                this.score += 80;
            }
            else if (i1 == 70)
            {
                this.score += 60;
            }
            else if (i1 >= 60)
            {
                this.score += 50;
            }
            else if (i1 >= 40)
            {
                this.score += 40;
            }
            if (wjsl >= 150)
            {
                this.unify += 10;
            }
            else
            {
                this.unify += wjsl / 15;
            }
        }

        // ����װ���ӳɲ��������ַ���
        void void_j()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte0);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                for (byte byte1 = 1; byte1 < officeGeneralIdArray.Length; byte1 = (byte)(byte1 + 1))
                {
                    switch ((GeneralListCache.GetGeneral(officeGeneralIdArray[byte1])).weapon)
                    {
                        case 15:
                        case 23:
                            i1 += 2;
                            break;

                        case 22:
                            i1++;
                            break;

                        case 5:
                        case 6:
                        case 7:
                            i1 += 3;
                            break;

                        case 14:
                            i1 += 2;
                            break;
                    }
                    switch ((GeneralListCache.GetGeneral(officeGeneralIdArray[byte1])).armor)
                    {
                        case 30:
                            i1 += 2;
                            break;

                        case 31:
                            i1 += 4;
                            break;
                    }
                }
            }
            this.score += i1 * 50;

            if (i1 > 10)
            {
                this.unify += 10;
            }
            else
            {
                this.unify += i1;
            }
        }




        // ִ��һϵ�з������ã�����������Ƿ��������
        void void_k()
        {
            if (this.txxxx != 1)
            {
                return;
            }
            void_a();
            void_b();
            void_c();
            void_d();
            void_e();
            void_f();
            void_g();
            void_h();
            void_i();
            void_j();

            byte[] abyte0 = new byte[7];
            for (int i = 0; i < this.R_byte_array1d_fld.Length; i++)
            {
                abyte0[i] = this.R_byte_array1d_fld[i];
            }
            bool canSet = true;
            for (int j = 0; j < abyte0.Length; j++)
            {
                if (abyte0[j] < this.higSort[j])
                {
                    canSet = false;
                }
            }
            if (canSet)
            {
                //setHighSort(abyte0);
            }
        }

        // ��ȡ�ֺ�������Ϣ
        string String_i_a(int i1)
        {
            return d.disaster_warning_information[i1][this.R_byte_array1d_fld[i1]];
        }

        // ���ݸ�����ֵ�����Ӧ�ĵȼ�
        public byte Byte_s_a(short word0)
        {
            for (byte i = 15; i > 0; i = (byte)(i - 1))
            {
                if (i * i <= word0)
                    return i;
            }
            return 0;
        }



        // �丿�ɹ��ж�
        bool IsSuccessOfCurse(short generalId, short beGeneralId)
        {
            General general = GeneralListCache.GetGeneral(generalId);
            int i1 = general.IQ - GeneralListCache.GetGeneral(beGeneralId).IQ;
            if (getSkill_5(generalId, 9))
            {
                i1 += 30;
            }

            if (i1 < 0)
                return false;
            byte retreatCityId = getCanRetreatCityId(this.aiKingId);
            if (retreatCityId > 0)
            {
                return (MathUtils.getRandomInt(100) <= i1);
            }
            return (MathUtils.getRandomInt(80) <= i1);
        }

        // �丿�ɹ���Ĵ���
        bool Boolean_a()
        {
            if (IsSuccessOfCurse(this.HMGeneralId, this.AIGeneralId))
            {
                this.aa = 20;
                if (this.HMGeneralId == 161)
                {
                    this.aa = 21;
                }
                return true;
            }
            return false;
        }

        // һ����ս�ɹ��ж�
        bool IsSuccessOfCompetition()
        {
            bool flag = false;
            General general = GeneralListCache.GetGeneral(this.AIGeneralId);
            if (general.getCurPhysical() < 25)
            {
                return false;
            }

            if (getSkill_5(this.HMGeneralId, 3) &&
              general.force > 80)
            {
                return true;
            }

            int ai = (int)Math.Ceiling((getAtkDea(this.AIGeneralId, this.AISingleAtk, this.HMSingleDef) *
                getPercentage(this.AIGeneralId, this.HMGeneralId, false, false) / 100.0));
            int hm = (int)Math.Ceiling((getAtkDea(this.HMGeneralId, this.HMSingleAtk, this.AISingleDef) *
                getPercentage(this.HMGeneralId, this.AIGeneralId, false, false) / 100.0));
            int aival = ai * general.getCurPhysical();

            int hmval = hm * GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical();
            if (aival > hmval + 25 &&
              MathUtils.getRandomInt(aival - hmval) > 25)
            {
                flag = true;
            }

            return flag;
        }



        // ���׳ɹ��ж�
        bool IsSuccessOfBoom()
        {
            short word0 = 0;
            for (byte byte0 = 1; byte0 < this.humanSmallSoldierNum; byte0 = (byte)(byte0 + 1))
            {
                word0 = (short)(word0 + this.smallSoldierBlood[0][byte0]);
            }
            return (word0 >= 1000);
        }

        // ��ս�Ʋ���������
        bool Boolean_b_a(byte byte0)
        {
            this.V = (byte)(this.V - NeedTacticsBonus(byte0));
            switch (byte0)
            {
                case 0:
                    return Boolean_a();

                case 1:
                    return IsSuccessOfCompetition();

                case 2:
                    this.aa = 51;
                    return true;

                case 3:
                    this.aa = 68;
                    return true;

                case 4:
                    this.aa = 83;
                    return true;

                case 5:
                    return IsSuccessOfBoom();
            }
            return false;
        }

        // ��ս�Ʋ�����Ʋߵ���
        byte NeedTacticsBonus(byte byte0)
        {
            switch (byte0)
            {
                case 0:
                    return 5;

                case 1:
                    return 2;

                case 2:
                    return 7;

                case 3:
                    return 8;

                case 4:
                    return 10;

                case 5:
                    return 12;
            }
            return 100;
        }



        // ���ʿ����λ��״̬
        // byte0: ��ʾX�������
        // byte1: ��ʾY�������
        // flag: ��ʾ�Ƿ�Ϊ�о���true: �о�, false: ������
        void SmallWarSoldierStatus(byte byte0, byte byte1, bool flag)
        {
            if (flag)
            {
                // ����ǵо������ø�λ�õ�״̬Ϊ 0x80 (10000000)����ʾ�о�ռ��
                this.smallWarCoordinate[byte1][byte0] = (byte)(this.smallWarCoordinate[byte1][byte0] | 0x80);
            }
            else
            {
                // ����Ǽ��������ø�λ�õ�״̬Ϊ 0x40 (01000000)����ʾ����ռ��
                this.smallWarCoordinate[byte1][byte0] = (byte)(this.smallWarCoordinate[byte1][byte0] | 0x40);
            }
        }


        // ��ʼ��ʿ�������ͺ�λ��
        void defCastleSoldierPos(bool isHm)
        {
            // ��ʼ���������ݣ�7 �� 16 ��
            byte[,] formation = new byte[7, 16];

            if (isHm)
            {
                // ����ʿ�������ļ�·��
                string s = "/formation/hc0.exp";

                // ��ȡ�����ļ�����
                byte[] formationDat = formationArray(s);

                // ������������
                formation = getFormationArray(formationDat, formation);

                // �����������У�����ʿ��λ��
                for (byte celly = 0; celly < 7; celly++)
                {
                    for (byte cellx = 0; cellx < 16; cellx++)
                    {
                        // �����ǰ��Ԫ����ʿ�����
                        if (formation[celly, cellx] < 0) // ���������ж�
                        {
                            // ������������ʿ����ƥ����
                            for (byte index = 0; index < this.humanSmallSoldierNum; index++)
                            {
                                if (formation[celly, cellx] == index)
                                {
                                    // ����ʿ��λ��
                                    this.smallSoldierCellX[0][index] = cellx;
                                    this.smallSoldierCellY[0][index] = celly;

                                    // ����ʿ��λ�ã����ݲ���������x, ����y, �Ƿ�з���
                                    SmallWarSoldierStatus(this.smallSoldierCellX[0][index], this.smallSoldierCellY[0][index], false);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // �з�ʿ�������ļ�·��
                byte fileIndex;
                string s = "/formation/ac";

                // ���ݵз�����ȼ�ѡ��ͬ�����ļ�
                if ((GeneralListCache.GetGeneral(this.AIGeneralId)).level >= 7)
                {
                    fileIndex = 2;
                }
                else if ((GeneralListCache.GetGeneral(this.AIGeneralId)).level >= 4)
                {
                    fileIndex = 1;
                }
                else
                {
                    fileIndex = 0;
                }

                // ƴ���������ļ���
                s = s + fileIndex + ".exp";

                // ��ȡ�����ļ�����
                byte[] formationDat = formationArray(s);

                // ������������
                formation = getFormationArray(formationDat, formation);

                // �����������У�����з�ʿ��λ��
                for (byte celly = 0; celly < 7; celly++)
                {
                    for (byte cellx = 0; cellx < 16; cellx++)
                    {
                        // �����ǰ��Ԫ����ʿ�����
                        if (formation[celly, cellx] < 0) // ���������ж�
                        {
                            // �����з�����ʿ����ƥ����
                            for (byte index = 0; index < this.aiSmallSoldierNum; index++)
                            {
                                if (formation[celly, cellx] == index)
                                {
                                    // ���õз�ʿ��λ��
                                    this.smallSoldierCellX[1][index] = cellx;
                                    this.smallSoldierCellY[1][index] = celly;

                                    // ���µз�ʿ��λ�ã����ݲ���������x, ����y, �Ƿ�з���
                                    SmallWarSoldierStatus(this.smallSoldierCellX[1][index], this.smallSoldierCellY[1][index], true);
                                }
                            }
                        }
                    }
                }
            }
        }




        // ��ʼ��ʿ������
        // ����Ǳ��е�ʿ������
        void defCastleSoldier(bool isHm)
        {
            if (isHm)
            {
                // ���ݽ����ȼ�ȷ��ʿ������ aNum
                byte aNum;
                if (GeneralListCache.GetGeneral(this.HMGeneralId).level >= 7)
                {
                    aNum = 10;
                }
                else if (GeneralListCache.GetGeneral(this.HMGeneralId).level >= 4)
                {
                    aNum = 8;
                }
                else
                {
                    aNum = 6;
                }

                // ѭ������ÿ��ʿ�������࣬�������� 0���� 1 ��ʼ
                for (byte byte1 = 1; byte1 < this.humanSmallSoldierNum; byte1++)
                {
                    if (byte1 <= aNum)
                    {
                        // ��������Ӫ��ʿ����������Ϊ 2
                        this.smallSoldierKind[0][byte1] = 2;
                    }
                    else
                    {
                        // ���� aNum ��ʿ����������Ϊ 3
                        this.smallSoldierKind[0][byte1] = 3;
                    }
                }
            }
            else
            {
                // AI ��Ӫ����������Ӫ�߼����ƣ�ȷ��ʿ������ aNum
                byte aNum;
                if (GeneralListCache.GetGeneral(this.AIGeneralId).level >= 7)
                {
                    aNum = 10;
                }
                else if (GeneralListCache.GetGeneral(this.AIGeneralId).level >= 4)
                {
                    aNum = 8;
                }
                else
                {
                    aNum = 6;
                }

                // ѭ������ AI ��Ӫʿ�������࣬�������� 0���� 1 ��ʼ
                for (byte byte2 = 1; byte2 < this.aiSmallSoldierNum; byte2++)
                {
                    if (byte2 <= aNum)
                    {
                        // AI ��Ӫ��ʿ����������Ϊ 2
                        this.smallSoldierKind[1][byte2] = 2;
                    }
                    else
                    {
                        // ���� aNum ��ʿ����������Ϊ 3
                        this.smallSoldierKind[1][byte2] = 3;
                    }
                }
            }
        }

        // ʿ����������
        void changeAtkCastleSoldier(bool isHm)
        {
            if (isHm)
            {
                // ���幥��ʿ������ gjsl
                byte gjsl;

                // ���ݵз������ȼ����쵼������ʿ�����������
                if (GeneralListCache.GetGeneral(this.AIGeneralId).level == 8 && GeneralListCache.GetGeneral(this.AIGeneralId).lead >= 95)
                {
                    gjsl = 10;
                }
                else if (GeneralListCache.GetGeneral(this.AIGeneralId).level >= 6 && GeneralListCache.GetGeneral(this.AIGeneralId).lead >= 90)
                {
                    gjsl = 8;
                }
                else if (GeneralListCache.GetGeneral(this.AIGeneralId).level >= 4 && GeneralListCache.GetGeneral(this.AIGeneralId).lead >= 80)
                {
                    gjsl = 6;
                }
                else
                {
                    gjsl = 4;
                }

                // ���� AI С�����࣬�������� 0���� 1 ��ʼ
                for (byte byte2 = 1; byte2 < this.aiSmallSoldierNum; byte2++)
                {
                    if (byte2 <= gjsl)
                    {
                        // ʿ��������Ϊ 2
                        this.smallSoldierKind[1][byte2] = 2;
                    }
                    else
                    {
                        // ʿ��������Ϊ 3
                        this.smallSoldierKind[1][byte2] = 3;
                    }
                }
            }
            else
            {
                // ���强��ʿ������ gjsl
                byte gjsl;

                // ���ݼ��������ȼ����쵼������ʿ�����������
                if (GeneralListCache.GetGeneral(this.HMGeneralId).level >= 7 && GeneralListCache.GetGeneral(this.HMGeneralId).lead >= 95)
                {
                    gjsl = 8;
                }
                else if (GeneralListCache.GetGeneral(this.HMGeneralId).level >= 4 && GeneralListCache.GetGeneral(this.HMGeneralId).lead >= 85)
                {
                    gjsl = 6;
                }
                else
                {
                    gjsl = 4;
                }

                // ��������С�����࣬�������� 0���� 1 ��ʼ
                for (byte byte1 = 1; byte1 < this.humanSmallSoldierNum; byte1++)
                {
                    if (byte1 <= gjsl)
                    {
                        // ʿ��������Ϊ 2
                        this.smallSoldierKind[0][byte1] = 2;
                    }
                    else
                    {
                        // ʿ��������Ϊ 3
                        this.smallSoldierKind[0][byte1] = 3;
                    }
                }
            }
        }



        // ��ս���趨�߼�������jDI
        public GameThread()
        {
            // ��ʼ�� CAS_sc ����
            this.CAS_sc = new byte[][]
            {
            new byte[] { 6, 2, 2 },
            new byte[] { 4, 3, 3 },
            new byte[] { 2, 4, 4 },
            new byte[] { 0, 4, 6 },
            new byte[] { 4, 4, 2 },
            new byte[] { 2, 4, 4 },
            new byte[] { 0, 4, 6 },
            new byte[] { 0, 2, 8 },
            new byte[] { 0, 8, 2 },
            new byte[] { 0, 6, 4 },
            new byte[] { 0, 4, 6 },
            new byte[] { 0, 2, 8 }
            };




            // ��ʼ�� topInf ����
            this.topInf = new float[] { 1.1F, 1.0F, 0.9F, 0.8F };

            // ��ʼ�� soldierAtk �� soldierDef ����
            this.soldierAtk = new short[2,4];
            this.soldierDef = new short[2,4];

            // ��ʼ�� aiAtkHm
            this.aiAtkHm = false;

            // ��ʼ�� buildingMoveMap
            this.buildingMoveMap = new byte[19, 32];

            // ��ʼ�� moniSd1 �� moniSd2
            this.moniSd1 = 0;
            this.moniSd2 = 0;


            // ��C#�У���������ڿ����飨{}������Ҫʹ��ռλ������
            this.moniwarT = new byte[][]
            {
                new byte[] { 0, 0 },
                new byte[] { 6, 9 },
                new byte[] { 7, 9 },
                new byte[] { 6, 9 },
                new byte[] { 5, 9 },
                new byte[] { 5, 8 },
                new byte[] { 6, 8 },
                new byte[] { 5, 8 },
                new byte[] { 5, 8 },
                new byte[] { 5, 9 },
                new byte[] { 5, 8 },
                new byte[] { 4, 8 },
                new byte[] { 5, 9 },
                new byte[] { 5, 8 },
                new byte[] { 5, 9 },
                new byte[] { 4, 8 },
                new byte[] { 5, 10 },
                new byte[] { 5, 7 },
                new byte[] { 5, 9 },
                new byte[] { 4, 9 },
                new byte[] { 5, 9 },
                new byte[] { 4, 9 },
                new byte[] { 4, 10 },
                new byte[] { 3, 9 },
                new byte[] { 5, 8 },
                new byte[] { 4, 9 },
                new byte[] { 4, 5 },
                new byte[] { 5, 6 },
                new byte[] { 4, 8 },
                new byte[] { 4, 7 },
                new byte[] { 3, 8 },
                new byte[] { 5, 9 },
                new byte[] { 5, 9 },
                new byte[] { 4, 5 },
                new byte[] { 4, 5 },
                new byte[] { 4, 7 },
                new byte[] { 4, 6 },
                new byte[] { 4, 8 },
                new byte[] { 3, 9 },
                new byte[] { 3, 10 },
                new byte[] { 3, 9 },
                new byte[] { 3, 9 },
                new byte[] { 4, 9 },
                new byte[] { 3, 9 },
                new byte[] { 3, 9 },
                new byte[] { 3, 10 },
                new byte[] { 4, 9 },
                new byte[] { 4, 6 },
                new byte[] { 3, 4 }
            };




            // ��ʼ�� re �ַ���
            this.re = "record";

            // ��ʼ����������ͱ���
            this.higSort = new byte[7];
            this.countryOrder = new byte[10];
            this.countryPhase = new short[9];
            this.k_byte_array1d_fld = new byte[CityListCache.CITY_NUM];
            this.warWeaponShop = new byte[CityListCache.CITY_NUM];
            this.r_short_array1d_fld = new short[3];
            this.D_byte_array1d_fld = new byte[3];
            this.s_short_array1d_fld = new short[3];
            this.random = new System.Random();
            this.j_byte_fld = 0;
            this.chooseGeneralIdArray = new short[10];
            this.s_byte_fld = 0;
            this.AIUseOrderNum = 0;
            this.a_boolean_fld = true;
            this.b_boolean_fld = true;
            this.c_boolean_fld = true;
            this.d_boolean_fld = true;
            this.canToDoGeneral_Array = new short[10];
            this.canToDoGeneralNum = 0;
            this.noAllianceCountryIdArray = new byte[8];
            this.G_byte_array1d_fld = new byte[CityListCache.CITY_NUM];
            this.e_boolean_fld = true;
            this.humanGeneralId_inWar = new short[10];
            this.aiGeneralId_inWar = new short[10];
            this.cols = 32;
            this.rows = 19;
            this.bigWar_coordinate = new byte[this.rows, this.cols];
            this.humanUnitCellX = new byte[10];
            this.humanUnitCellY = new byte[10];
            this.aiUnitCellX = new byte[10];
            this.aiUnitCellY = new byte[10];
            this.humanUnitTrapped = new byte[10];
            this.aiUnitTrapped = new byte[10];
            this.T_byte_fld = 16;
            this.U = 7;
            this.aa = 0;
            this.ab = 0;
            this.ae = 0;
            this.o_boolean_fld = false;
            this.au = 0;
            this.R_byte_array1d_fld = new byte[7];
            this.S_byte_array1d_fld = new byte[10240];
            this.txxxx = 1;

            // ���ö�ȡ�����ֵ�ķ���
            //readMaxRestain();
        }

        // �û��غϽ�������
        public void UserEndTurn()
        {
            this.userOrderNum = 0;
            this.X = 0;
            this.j_byte_fld = 3;
            RefreshFeedBack((byte)4);
        }



        // ���ݲ�ͬ��ս�����κͽ�������������ս���е����ͣ�Combat Array Setup��CAS��
        public void SetCAS(bool isHM)
        {
            short genId;
            float tef = 1.0F;
    
            if (isHM)
            {
                genId = this.HMGeneralId;
            }
            else
            {
                genId = this.AIGeneralId;
            }

            byte[] sc = new byte[3];

            if (this.warTerrain >= 1 && this.warTerrain <= 7)
            {
                switch (GeneralListCache.GetGeneral(genId).army[0])
                {
                    case 0:
                        sc = this.CAS_sc[3];
                        tef = this.topInf[3];
                        break;
                    case 1:
                        sc = this.CAS_sc[2];
                        tef = this.topInf[2];
                        break;
                    case 2:
                        sc = this.CAS_sc[1];
                        tef = this.topInf[1];
                        break;
                    case 3:
                        sc = this.CAS_sc[0];
                        tef = this.topInf[0];
                        break;
                }
            }
            else if (this.warTerrain >= 11 && this.warTerrain <= 12)
            {
                switch (GeneralListCache.GetGeneral(genId).army[1])
                {
                    case 0:
                        sc = this.CAS_sc[7];
                        tef = this.topInf[3];
                        break;
                    case 1:
                        sc = this.CAS_sc[6];
                        tef = this.topInf[2];
                        break;
                    case 2:
                        sc = this.CAS_sc[5];
                        tef = this.topInf[1];
                        break;
                    case 3:
                        sc = this.CAS_sc[4];
                        tef = this.topInf[0];
                        break;
                }
            }
            else if (this.warTerrain == 9)
            {
                switch (GeneralListCache.GetGeneral(genId).army[2])
                {
                    case 0:
                        sc = this.CAS_sc[11];
                        tef = this.topInf[3];
                        break;
                    case 1:
                        sc = this.CAS_sc[10];
                        tef = this.topInf[2];
                        break;
                    case 2:
                        sc = this.CAS_sc[9];
                        tef = this.topInf[1];
                        break;
                    case 3:
                        sc = this.CAS_sc[8];
                        tef = this.topInf[0];
                        break;
                }
            }
            else if (this.warTerrain == 8)
            {
                sc[0] = 0;
                if (!this.i_boolean_fld)
                {
                    if (isHM)
                    {
                        if (GeneralListCache.GetGeneral(genId).level >= 7)
                        {
                            sc[1] = 10;
                            sc[2] = 0;
                        }
                        else if (GeneralListCache.GetGeneral(genId).level >= 4)
                        {
                            sc[1] = 8;
                            sc[2] = 2;
                        }
                        else
                        {
                            sc[1] = 6;
                            sc[2] = 4;
                        }
                    }
                    else if (GeneralListCache.GetGeneral(genId).level >= 7)
                    {
                        sc[1] = 8;
                        sc[2] = 2;
                    }
                    else if (GeneralListCache.GetGeneral(genId).level >= 4)
                    {
                        sc[1] = 6;
                        sc[2] = 4;
                    }
                    else
                    {
                        sc[1] = 4;
                        sc[2] = 6;
                    }
                }
                else if (isHM)
                {
                    if (GeneralListCache.GetGeneral(genId).level >= 7)
                    {
                        sc[1] = 8;
                        sc[2] = 2;
                    }
                    else if (GeneralListCache.GetGeneral(genId).level >= 4)
                    {
                        sc[1] = 6;
                        sc[2] = 4;
                    }
                    else
                    {
                        sc[1] = 4;
                        sc[2] = 6;
                    }
                }
                else if (GeneralListCache.GetGeneral(genId).level >= 7)
                {
                    sc[1] = 10;
                    sc[2] = 0;
                }
                else if (GeneralListCache.GetGeneral(genId).level >= 4)
                {
                    sc[1] = 8;
                    sc[2] = 2;
                }
                else
                {
                    sc[1] = 6;
                    sc[2] = 4;
                }
            }

            SetCAS(sc, isHM, tef);
        }


        // ������Ϸ��ʿ������Ϊ������
        public void SetCAS(byte[] sc, bool isHm, float tef)
        {
            if (isHm)
            {
                int sNum = GeneralListCache.GetGeneral(this.HMGeneralId).generalSoldier;
                for (byte index = 1; index < this.humanSmallSoldierNum; index = (byte)(index + 1))
                {
                    this.smallSoldierAction[0][index] = 3;
                    if (index <= sc[0])
                    {
                        this.smallSoldierKind[0][index] = 1;
                    }
                    else if (index - sc[0] <= sc[1])
                    {
                        this.smallSoldierKind[0][index] = 2;
                    }
                    else
                    {
                        this.smallSoldierKind[0][index] = 3;
                    }
                    this.smallSoldierBlood[0][index] = (short)(sNum / (this.humanSmallSoldierNum - index));
                    sNum -= this.smallSoldierBlood[0][index];
                    SetSoldierAtkDef(true, index, tef);
                    this.smallSoldier_isSurvive[0][index] = true;
                }
            }
            else
            {
                int sNum = GeneralListCache.GetGeneral(this.AIGeneralId).generalSoldier;
                for (byte index = 1; index < this.aiSmallSoldierNum; index = (byte)(index + 1))
                {
                    this.smallSoldierAction[1][index] = 2;
                    if (index <= sc[0])
                    {
                        this.smallSoldierKind[1][index] = 1;
                    }
                    else if (index - sc[0] <= sc[1])
                    {
                        this.smallSoldierKind[1][index] = 2;
                    }
                    else
                    {
                        this.smallSoldierKind[1][index] = 3;
                    }
                    this.smallSoldierBlood[1][index] = (short)(sNum / (this.aiSmallSoldierNum - index));
                    sNum -= this.smallSoldierBlood[1][index];
                    SetSoldierAtkDef(false, index, tef);
                    this.smallSoldier_isSurvive[1][index] = true;
                }
            }
        }

        // ��ʼ����������Ϸ�е�ս����λ���������ǵ����ԡ���Ϊ������
        public void VoidBA(byte byte0)
        {
            this.dttb = false;
            this.sd1 = 0;
            this.sd2 = 0;
            this.wjct = false;
            this.ctsb = false;

            this.smallSoldierKind = new byte[2][];
            this.smallSoldierCellX = new byte[2][];
            this.smallSoldierCellY = new byte[2][];
            this.smallSoldierAction = new byte[2][];
            this.smallSoldierBlood = new short[2][];
            this.a_boolean_array2d_fld = new bool[2][];
            this.smallSoldier_isSurvive = new bool[2][];
            this.smallSoldierAtk = new short[2][];
            this.smallSoldierDef = new short[2][];
            this.smallSoldierOrder = new byte[2][];

            this.smallSoldierKind[0] = new byte[this.humanSmallSoldierNum];
            this.smallSoldierCellX[0] = new byte[this.humanSmallSoldierNum];
            this.smallSoldierCellY[0] = new byte[this.humanSmallSoldierNum];
            this.smallSoldierAction[0] = new byte[this.humanSmallSoldierNum];
            this.smallSoldierBlood[0] = new short[this.humanSmallSoldierNum];
            this.a_boolean_array2d_fld[0] = new bool[this.humanSmallSoldierNum];
            this.smallSoldier_isSurvive[0] = new bool[this.humanSmallSoldierNum];
            this.smallSoldierAtk[0] = new short[this.humanSmallSoldierNum];
            this.smallSoldierDef[0] = new short[this.humanSmallSoldierNum];
            this.smallSoldierOrder[0] = new byte[this.humanSmallSoldierNum];

            this.smallSoldierKind[1] = new byte[this.aiSmallSoldierNum];
            this.smallSoldierCellX[1] = new byte[this.aiSmallSoldierNum];
            this.smallSoldierCellY[1] = new byte[this.aiSmallSoldierNum];
            this.smallSoldierAction[1] = new byte[this.aiSmallSoldierNum];
            this.smallSoldierBlood[1] = new short[this.aiSmallSoldierNum];
            this.a_boolean_array2d_fld[1] = new bool[this.aiSmallSoldierNum];
            this.smallSoldier_isSurvive[1] = new bool[this.aiSmallSoldierNum];
            this.smallSoldierAtk[1] = new short[this.aiSmallSoldierNum];
            this.smallSoldierDef[1] = new short[this.aiSmallSoldierNum];
            this.smallSoldierOrder[1] = new byte[this.aiSmallSoldierNum];

            this.smallSoldierKind[0][0] = 0;
            this.smallSoldierAction[0][0] = 3;
            this.smallSoldierBlood[0][0] = 300;
            this.smallSoldierKind[1][0] = 0;
            this.smallSoldierAction[1][0] = 2;
            this.smallSoldierBlood[1][0] = 300;

            SetAD(true, (byte)0);
            SetCAS(true);
            SetAD(false, (byte)0);
            SetCAS(false);

            if (!this.i_boolean_fld && this.j_boolean_fld)
            {
                defCastleSoldierPos(true);
            }
            else if (this.i_boolean_fld || !this.j_boolean_fld)
            {
                hmSelectFormation(byte0);
            }

            if (this.i_boolean_fld && this.j_boolean_fld)
            {
                defCastleSoldierPos(false);
            }
            else if (!this.i_boolean_fld && this.j_boolean_fld)
            {
                aiSelectFormation(getAIFormation());
            }
            else
            {
                aiSelectFormation((byte)MathUtils.getRandomInt(4));
            }

            SetSingleAtkAndDef();
            InitCSK();
        }


        // ȷ�� AI ������ѡ��
        public byte getAIFormation()
        {
            byte index = 2;
            byte hMatcherNum = 0;
            for (int i = 1; i < this.humanSmallSoldierNum; i++)
            {
                if (this.smallSoldierKind[0][i] == 2)
                    hMatcherNum = (byte)(hMatcherNum + 1);
            }
            if (hMatcherNum >= 3)
                return 1;
            return index;
        }

        // ����Դ�ļ��м�����������
        public byte[] formationArray(string name)
        {
            byte[] abyte0 = null;
            try
            {
                using (Stream inputstream = GetType().Assembly.GetManifestResourceStream(name))
                {
                    if (inputstream != null)
                    {
                        abyte0 = new byte[inputstream.Length];
                        inputstream.Read(abyte0, 0, abyte0.Length);
                    }
                }
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            return abyte0;
        }

        // �����ص��������ݽ�����һ����ά������
        public byte[,] getFormationArray(byte[] dat, byte[,] formation)
        {
            byte star = 0;
            for (byte celly = 0; celly < 7; celly = (byte)(celly + 1))
            {
                for (int cellx = 0; cellx < 16; cellx++)
                {
                    formation[celly,cellx] = dat[star];
                    star = (byte)(star + 1);
                }
            }
            return formation;
        }

        // �����������ѡ������
        public void hmSelectFormation(byte index)
        {
            // ��ʼ��7��16�е���������
            byte[,] hmFormation = new byte[7, 16];

            // ���������ļ�
            string name = $"/formation/h{index}.exp";
            byte[] formationDat = formationArray(name);

            // ���������ļ�����������
            hmFormation = getFormationArray(formationDat, hmFormation);

            // �������ͣ�����ʿ��λ��
            for (byte celly = 0; celly < 7; celly++)
            {
                for (byte cellx = 0; cellx < 16; cellx++)
                {
                    // �ж��Ƿ���ʿ��
                    if (hmFormation[celly, cellx] < 0) // ���������ж�
                    {
                        // ��������ʿ��
                        for (byte i = 0; i < this.humanSmallSoldierNum; i++)
                        {
                            // ���ʿ�����ƥ��
                            if (i == hmFormation[celly, cellx])
                            {
                                // ����ʿ��λ��
                                this.smallSoldierCellX[0][i] = cellx;
                                this.smallSoldierCellY[0][i] = celly;

                                // ����ʿ��λ�ã����ݲ���������x, ����y, �Ƿ�з���
                                SmallWarSoldierStatus(this.smallSoldierCellX[0][i], this.smallSoldierCellY[0][i], false);
                            }
                        }
                    }
                }
            }
        }

        // ���� AI ���ѡ������
        public void aiSelectFormation(byte index)
        {
            // ��ʼ��7��16�е���������
            byte[,] aiFormation = new byte[7, 16];

            // ���������ļ�
            string name = $"/formation/a{index}.exp";
            byte[] formationDat = formationArray(name);

            // ���������ļ�����������
            aiFormation = getFormationArray(formationDat, aiFormation);

            // �������ͣ�����ʿ��λ��
            for (byte celly = 0; celly < 7; celly++)
            {
                for (byte cellx = 0; cellx < 16; cellx++)
                {
                    // �ж��Ƿ���ʿ��
                    if (aiFormation[celly, cellx] < 0) // ���������ж�
                    {
                        // �������ез�ʿ��
                        for (byte i = 0; i < this.aiSmallSoldierNum; i++)
                        {
                            // ���ʿ�����ƥ��
                            if (i == aiFormation[celly, cellx])
                            {
                                // ���õз�ʿ��λ��
                                this.smallSoldierCellX[1][i] = cellx;
                                this.smallSoldierCellY[1][i] = celly;

                                // ���µз�ʿ��λ�ã����ݲ���������x, ����y, �Ƿ�з���
                                SmallWarSoldierStatus(this.smallSoldierCellX[1][i], this.smallSoldierCellY[1][i], true);
                            }
                        }
                    }
                }
            }
        }


        // ���ڼ���������Һ� AI ��ҵ�����λ�Ĺ������ͷ�����
        public void SetSingleAtkAndDef()
        {
            byte force = GeneralListCache.GetGeneral(this.HMGeneralId).force;
            this.HMSingleAtk = (short)(force + force * (WeaponListCache.getWeapon(GeneralListCache.GetGeneral(this.HMGeneralId).weapon)).weaponProperties / 100);
            this.HMSingleDef = (short)(force + force * (WeaponListCache.getWeapon(GeneralListCache.GetGeneral(this.HMGeneralId).armor)).weaponProperties / 100);
            byte aiforce = GeneralListCache.GetGeneral(this.AIGeneralId).force;
            this.AISingleAtk = (short)(aiforce + aiforce * (WeaponListCache.getWeapon(GeneralListCache.GetGeneral(this.AIGeneralId).weapon)).weaponProperties / 100);
            this.AISingleDef = (short)(aiforce + aiforce * (WeaponListCache.getWeapon(GeneralListCache.GetGeneral(this.AIGeneralId).armor)).weaponProperties / 100);
        }

        // ��������Һ� AI ��ҵĽ�����ʿ��������ֵ���и��º��ۼ�
        public void ReGenHPSoldierNum()
        {
            for (byte byte0 = 1; byte0 < 4; byte0 = (byte)(byte0 + 1))
            {
                this.x_short_array1d_fld[byte0] = 0;
                this.y_short_array1d_fld[byte0] = 0;
            }
            this.x_short_array1d_fld[0] = GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical();
            for (byte byte1 = 1; byte1 < this.humanSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                this.x_short_array1d_fld[this.smallSoldierKind[0][byte1]] = (short)(this.x_short_array1d_fld[this.smallSoldierKind[0][byte1]] + this.smallSoldierBlood[0][byte1]);
            this.y_short_array1d_fld[0] = GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical();
            for (byte byte2 = 1; byte2 < this.aiSmallSoldierNum; byte2 = (byte)(byte2 + 1))
                this.y_short_array1d_fld[this.smallSoldierKind[1][byte2]] = (short)(this.y_short_array1d_fld[this.smallSoldierKind[1][byte2]] + this.smallSoldierBlood[1][byte2]);
        }
        //������Ϸ����ͼ��ܵ������㹥����(atk)�ͷ�����(def)��������ʿ��������״̬
        // ����ʿ���Ĺ������ͷ�����
        public void SetSoldierAtkDef(bool flag, byte byte0, float tef)
        {
            byte side;
            short id;

            if (flag)
            {
                side = 0;
                id = this.HMGeneralId;
            }
            else
            {
                side = 1;
                id = this.AIGeneralId;
            }

            short atk = (short)(((GeneralListCache.GetGeneral(id)).lead * 2 + (GeneralListCache.GetGeneral(id)).force) / 3 + ((GeneralListCache.GetGeneral(id)).lead + (GeneralListCache.GetGeneral(id)).force) * ((GeneralListCache.GetGeneral(id)).level - 1) / 25);
            short def = (short)(((GeneralListCache.GetGeneral(id)).lead * 3 + (GeneralListCache.GetGeneral(id)).IQ) / 4 + ((GeneralListCache.GetGeneral(id)).lead + (GeneralListCache.GetGeneral(id)).IQ) * ((GeneralListCache.GetGeneral(id)).level - 1) / 25);

            if (getSkill_3(id, 7))
            {
                atk = (short)(atk + atk / 4);
                def = (short)(def + def / 4);
            }
            else if (getSkill_3(id, 8))
            {
                atk = (short)(atk + atk / 5);
                def = (short)(def + def / 5);
            }
            else if (getSkill_3(id, 3))
            {
                if (this.i_boolean_fld && this.j_boolean_fld && flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
                else if (!this.i_boolean_fld && this.j_boolean_fld && !flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
            }
            else if (getSkill_3(id, 4))
            {
                if (!this.i_boolean_fld && this.j_boolean_fld && flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
                else if (this.i_boolean_fld && this.j_boolean_fld && !flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
            }
            else if ((flag && this.HMJH) || (!flag && this.AIJH))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (getSkill_3(id, 1) && flag && !this.aiAtkHm)
            {
                if (!this.i_boolean_fld || !this.j_boolean_fld)
                {
                    atk = (short)(atk + atk / 7);
                    def = (short)(def + def / 7);
                }
            }
            else if (getSkill_3(id, 1) && !flag && this.aiAtkHm && (this.i_boolean_fld || !this.j_boolean_fld))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (getSkill_3(id, 2) && flag && this.aiAtkHm)
            {
                if (this.i_boolean_fld || !this.j_boolean_fld)
                {
                    atk = (short)(atk + atk / 7);
                    def = (short)(def + def / 7);
                }
            }
            else if (getSkill_3(id, 2) && !flag && !this.aiAtkHm && (!this.i_boolean_fld || !this.j_boolean_fld))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (!this.i_boolean_fld && this.j_boolean_fld && flag)
            {
                atk = (short)(atk * 3 / 2);
                def = (short)(def * 3 / 2);
            }
            else if (this.i_boolean_fld && this.j_boolean_fld && !flag)
            {
                atk = (short)(atk * 3 / 2);
                def = (short)(def * 3 / 2);
            }
            if (!flag)
            {
                atk = (short)(atk * 4 / 3);
                def = (short)(def * 4 / 3);
            }
            atk = (short)(atk * tef);
            def = (short)(def * tef);
            this.a_boolean_array2d_fld[side][byte0] = false;
            this.smallSoldier_isSurvive[side][byte0] = true;
            if (this.smallSoldierKind[side][byte0] == 0)
            {
                this.smallSoldierAtk[side][byte0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).weapon)).weaponProperties / 100);
                this.smallSoldierDef[side][byte0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).armor)).weaponProperties / 100);
            }
            else if (this.smallSoldierKind[side][byte0] == 1)
            {
                this.smallSoldierAtk[side][byte0] = atk;
                this.smallSoldierDef[side][byte0] = def;
            }
            else if (this.smallSoldierKind[side][byte0] == 2)
            {
                this.smallSoldierAtk[side][byte0] = (short)(atk * 2 / 3);
                this.smallSoldierDef[side][byte0] = (short)(def * 4 / 5);
            }
            else if (this.smallSoldierKind[side][byte0] == 3)
            {
                this.smallSoldierAtk[side][byte0] = (short)(atk * 4 / 5);
                this.smallSoldierDef[side][byte0] = (short)(def * 6 / 5);
            }
            if (this.smallSoldierAtk[side][byte0] <= 0)
                this.smallSoldierAtk[side][byte0] = 1;
            if (this.smallSoldierDef[side][byte0] <= 0)
                this.smallSoldierDef[side][byte0] = 1;
        }

        // �����ù������ͷ�����
        public void SetAD(bool flag, byte byte0)
        {
            byte side;
            short id;

            if (flag)
            {
                side = 0;
                id = this.HMGeneralId;
            }
            else
            {
                side = 1;
                id = this.AIGeneralId;
            }

            this.a_boolean_array2d_fld[side][byte0] = false;
            this.smallSoldier_isSurvive[side][byte0] = true;
            if (this.smallSoldierKind[side][byte0] == 0)
            {
                this.smallSoldierAtk[side][byte0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).weapon)).weaponProperties / 100);
                this.smallSoldierDef[side][byte0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).armor)).weaponProperties / 100);
                this.smallSoldierAtk[side][byte0] = (short)(this.smallSoldierAtk[side][byte0] + (short)(int)((this.smallSoldierAtk[side][byte0] * ((GeneralListCache.GetGeneral(id)).level - 1)) * 0.05D));
                this.smallSoldierDef[side][byte0] = (short)(this.smallSoldierDef[side][byte0] + (short)(int)((this.smallSoldierDef[side][byte0] * ((GeneralListCache.GetGeneral(id)).level - 1)) * 0.05D));
            }
            if (this.smallSoldierAtk[side][byte0] <= 0)
                this.smallSoldierAtk[side][byte0] = 1;
            if (this.smallSoldierDef[side][byte0] <= 0)
                this.smallSoldierDef[side][byte0] = 1;
        }

        // ��������ʿ���Ĺ������ͷ�����
        public void SetAtk_Def1()
        {
            float tef = 1.0f;
            tef = GetTef(this.HMGeneralId);
            SetAtk_Def2(true, tef);
            tef = GetTef(this.AIGeneralId);
            SetAtk_Def2(false, tef);
        }

        // ���õ���ʿ���Ĺ������ͷ�����
        public void SetAtk_Def2(bool flag, float tef)
        {
            byte side;
            short id;

            if (flag)
            {
                side = 0;
                id = this.HMGeneralId;
            }
            else
            {
                side = 1;
                id = this.AIGeneralId;
            }

            short atk = (short)(((GeneralListCache.GetGeneral(id)).lead * 2 + (GeneralListCache.GetGeneral(id)).force) / 3 + ((GeneralListCache.GetGeneral(id)).lead + (GeneralListCache.GetGeneral(id)).force) * ((GeneralListCache.GetGeneral(id)).level - 1) / 25);
            short def = (short)(((GeneralListCache.GetGeneral(id)).lead * 3 + (GeneralListCache.GetGeneral(id)).IQ) / 4 + ((GeneralListCache.GetGeneral(id)).lead + (GeneralListCache.GetGeneral(id)).IQ) * ((GeneralListCache.GetGeneral(id)).level - 1) / 25);

            if (getSkill_3(id, 7))
            {
                atk = (short)(atk + atk / 4);
                def = (short)(def + def / 4);
            }
            else if (getSkill_3(id, 8))
            {
                atk = (short)(atk + atk / 5);
                def = (short)(def + def / 5);
            }
            else if (getSkill_3(id, 3))
            {
                if (this.i_boolean_fld && this.j_boolean_fld && flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
                else if (!this.i_boolean_fld && this.j_boolean_fld && !flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
            }
            else if (getSkill_3(id, 4))
            {
                if (!this.i_boolean_fld && this.j_boolean_fld && flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
                else if (this.i_boolean_fld && this.j_boolean_fld && !flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
            }
            else if ((flag && this.HMJH) || (!flag && this.AIJH))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (getSkill_3(id, 1) && flag && !this.aiAtkHm)
            {
                if (!this.i_boolean_fld || !this.j_boolean_fld)
                {
                    atk = (short)(atk + atk / 7);
                    def = (short)(def + def / 7);
                }
            }
            else if (getSkill_3(id, 1) && !flag && this.aiAtkHm && (this.i_boolean_fld || !this.j_boolean_fld))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (getSkill_3(id, 2) && flag && this.aiAtkHm)
            {
                if (this.i_boolean_fld || !this.j_boolean_fld)
                {
                    atk = (short)(atk + atk / 7);
                    def = (short)(def + def / 7);
                }
            }
            else if (getSkill_3(id, 2) && !flag && !this.aiAtkHm && (!this.i_boolean_fld || !this.j_boolean_fld))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (!this.i_boolean_fld && this.j_boolean_fld && flag)
            {
                atk = (short)(atk * 3 / 2);
                def = (short)(def * 3 / 2);
            }
            else if (this.i_boolean_fld && this.j_boolean_fld && !flag)
            {
                atk = (short)(atk * 3 / 2);
                def = (short)(def * 3 / 2);
            }
            if (!flag)
            {
                atk = (short)(atk * 4 / 3);
                def = (short)(def * 4 / 3);
            }
            atk = (short)(atk * tef);
            def = (short)(def * tef);

            // ���õ�һ�����͵�ʿ���Ĺ������ͷ�����
            this.soldierAtk[side,0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).weapon)).weaponProperties / 100);
            this.soldierDef[side,0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).armor)).weaponProperties / 100);
            this.soldierAtk[side,0] = (short)(this.soldierAtk[side,0] + (short)(int)((this.soldierAtk[side,0] * ((GeneralListCache.GetGeneral(id)).level - 1)) * 0.05D));
            this.soldierDef[side,0] = (short)(this.soldierDef[side,0] + (short)(int)((this.soldierDef[side,0] * ((GeneralListCache.GetGeneral(id)).level - 1)) * 0.05D));

            // �����������͵�ʿ���Ĺ������ͷ�����
            this.soldierAtk[side,1] = atk;
            this.soldierDef[side,1] = def;
            this.soldierAtk[side,2] = (short)(atk * 2 / 3);
            this.soldierDef[side,2] = (short)(def * 4 / 5);
            this.soldierAtk[side,3] = (short)(atk * 4 / 5);
            this.soldierDef[side,3] = (short)(def * 6 / 5);
        }

        // ��ȡ����ϵ��
        public float GetTef(short genId)
        {
            float tef = 1.0f;
            if (this.warTerrain >= 1 && this.warTerrain <= 7)
            {
                switch ((GeneralListCache.GetGeneral(genId)).army[0])
                {
                    case 0:
                        tef = this.topInf[3];
                        break;
                    case 1:
                        tef = this.topInf[2];
                        break;
                    case 2:
                        tef = this.topInf[1];
                        break;
                    case 3:
                        tef = this.topInf[0];
                        break;
                }
            }
            else if (this.warTerrain >= 10 && this.warTerrain <= 12)
            {
                switch ((GeneralListCache.GetGeneral(genId)).army[1])
                {
                    case 0:
                        tef = this.topInf[3];
                        break;
                    case 1:
                        tef = this.topInf[2];
                        break;
                    case 2:
                        tef = this.topInf[1];
                        break;
                    case 3:
                        tef = this.topInf[0];
                        break;
                }
            }
            else if (this.warTerrain == 9)
            {
                switch ((GeneralListCache.GetGeneral(genId)).army[2])
                {
                    case 0:
                        tef = this.topInf[3];
                        break;
                    case 1:
                        tef = this.topInf[2];
                        break;
                    case 2:
                        tef = this.topInf[1];
                        break;
                    case 3:
                        tef = this.topInf[0];
                        break;
                }
            }
            return tef;
        }

        // ���� V �� W ��ֵ
        public void TotalTacticsBonus()
        {
            this.V = (byte)((GeneralListCache.GetGeneral(this.HMGeneralId)).IQ * 13 / 100);
            this.W = (byte)((GeneralListCache.GetGeneral(this.AIGeneralId)).IQ * 13 / 100);
        }

        // ���㵥�ι�����ɵ��˺�
        public void singleDea()
        {
            int ai = (int)Math.Ceiling((getAtkDea(this.AIGeneralId, this.AISingleAtk, this.HMSingleDef) * getPercentage(this.AIGeneralId, this.HMGeneralId, false, false) / 100.0));
            int hm = (int)Math.Ceiling((getAtkDea(this.HMGeneralId, this.HMSingleAtk, this.AISingleDef) * getPercentage(this.HMGeneralId, this.AIGeneralId, false, false) / 100.0));
        }

        // �����ƶ�ʿ��
        void UpMoveSoldier(byte byte0, byte byte1)
        {
            // ���ʿ��λ���Ѿ��ڱ߽� (0, 0)������ Y ����û���ƶ�����أ�ֱ�ӷ���
            if (byte0 == 0 && byte1 == 0 && this.smallSoldierCellY[0][0] <= 1)
                return;

            // ȡ��ǰ���괦���ݵĸ� 2 λ (0xC0 = 11000000)
            byte byte2 = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0xC0);

            // �����ǰ��Ԫ���λ����Ϣ (������λ������Ϣ)
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0x32);

            // �����ƶ�ʿ�� (Y ���� - 1)
            this.smallSoldierCellY[byte0][byte1] = (byte)(this.smallSoldierCellY[byte0][byte1] - 1);

            // ����ʿ������ΪΪ���� (0 ��ʾ����)
            this.smallSoldierAction[byte0][byte1] = 0;

            // �����µ�Ԫ������ݣ�����֮ǰ����ĸ� 2 λд��
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] | byte2);
        }

        // �����ƶ�ʿ��
        public void DownMoveSoldier(byte byte0, byte byte1)
        {
            // ���ʿ��λ���Ѿ��ڱ߽� (0, 0)������ Y �����Ѿ�����ײ���ֱ�ӷ���
            if (byte0 == 0 && byte1 == 0 && this.smallSoldierCellY[0][0] >= 5)
                return;

            // ȡ��ǰ���괦���ݵĸ� 2 λ
            byte byte2 = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0xC0);

            // �����ǰ��Ԫ���λ����Ϣ
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0x32);

            // �����ƶ�ʿ�� (Y ���� + 1)
            this.smallSoldierCellY[byte0][byte1] = (byte)(this.smallSoldierCellY[byte0][byte1] + 1);

            // ����ʿ������ΪΪ���� (1 ��ʾ����)
            this.smallSoldierAction[byte0][byte1] = 1;

            // �����µ�Ԫ������ݣ�����֮ǰ����ĸ� 2 λд��
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] | byte2);
        }

        // �����ƶ�ʿ��
        public void LeftMoveSoldier(byte byte0, byte byte1)
        {
            // ȡ��ǰ���괦���ݵĸ� 2 λ
            byte byte2 = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0xC0);

            // �����ǰ��Ԫ���λ����Ϣ
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0x32);

            // �����ƶ�ʿ�� (X ���� - 1)
            this.smallSoldierCellX[byte0][byte1] = (byte)(this.smallSoldierCellX[byte0][byte1] - 1);

            // ����ʿ������ΪΪ���� (2 ��ʾ����)
            this.smallSoldierAction[byte0][byte1] = 2;

            // �����µ�Ԫ������ݣ�����֮ǰ����ĸ� 2 λд��
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] | byte2);
        }

        // �����ƶ�ʿ��
        public void RightMoveSoldier(byte byte0, byte byte1)
        {
            // ȡ��ǰ���괦���ݵĸ� 2 λ
            byte byte2 = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0xC0);

            // �����ǰ��Ԫ���λ����Ϣ
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0x32);

            // �����ƶ�ʿ�� (X ���� + 1)
            this.smallSoldierCellX[byte0][byte1] = (byte)(this.smallSoldierCellX[byte0][byte1] + 1);

            // ����ʿ������ΪΪ���� (3 ��ʾ����)
            this.smallSoldierAction[byte0][byte1] = 3;

            // �����µ�Ԫ������ݣ�����֮ǰ����ĸ� 2 λд��
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] | byte2);
        }


        // ��ʼ��ʿ����������
        void InitCSK()
        {
            // ��ʼ��7��16�еĶ�ά����
            this.coodinateSoldierKind = new byte[7][];
            for (int y = 0; y < 7; y++)
            {
                this.coodinateSoldierKind[y] = new byte[16];
                for (int x = 0; x < 16; x++)
                {
                    // ������������ʼ��Ϊ 0����ʾ��λ��û��ʿ��
                    this.coodinateSoldierKind[y][x] = 0;
                }
            }
        }

        // ����ʿ��������������
        void setCSK()
        {
            // ������ʿ��
            for (int hmindex = 0; hmindex < this.humanSmallSoldierNum; hmindex++)
            {
                // �����ʿ�����
                if (this.smallSoldier_isSurvive[0][hmindex])
                {
                    byte hx = this.smallSoldierCellX[0][hmindex]; // ��ȡX����
                    byte hy = this.smallSoldierCellY[0][hmindex]; // ��ȡY����
                                                                   // ����λ�õ�ʿ����������Ϊ��ǰʿ��������
                    this.coodinateSoldierKind[hy][hx] = this.smallSoldierKind[0][hmindex];
                }
            }

            // ����з�ʿ��
            for (int aiIndex = 0; aiIndex < this.aiSmallSoldierNum; aiIndex++)
            {
                // �����ʿ�����
                if (this.smallSoldier_isSurvive[1][aiIndex])
                {
                    byte aix = this.smallSoldierCellX[1][aiIndex]; // ��ȡX����
                    byte aiy = this.smallSoldierCellY[1][aiIndex]; // ��ȡY����
                                                                    // ����λ�õ�ʿ����������Ϊ��ǰʿ��������
                    this.coodinateSoldierKind[aiy][aix] = this.smallSoldierKind[1][aiIndex];
                }
            }
        }
        /*
        // ������Ϸ����
        public void setGameCanvas(MyGameCanvas c1)
        {
            this.GameCanvas = c1;
            this.e_boolean_fld = true;
        }

        // ��Ϸѭ���߼�
        private void VoidN()
        {
            long l1 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while (true)
            {
                if (this.GameCanvas.GetKeyValue() > 0)
                {
                    this.GameCanvas.VoidK();
                    if (!this.GameCanvas.C_Boolean_Fld)
                        this.GameCanvas.SetKeyValue((byte)0);
                }
                if (this.j_byte_fld <= 0)
                {
                    if (this.X != 111)
                        this.GameCanvas.SetKeyValue((byte)0);
                    long l2 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - l1;
                    if (l2 < 20L)
                    {
                        lock (this)
                        {
                            System.Threading.Thread.Sleep((int)(20L - l2));
                        }
                    }
                    this.GameCanvas.Repaint();
                    l1 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    continue;
                }
                break;
            }
        }

        // ���� void_aq ����
        private void VoidO()
        {
            void_aq();
            this.GameCanvas.SVoidBA((byte)1);
        }

        // ���� s_void_b_a ����
        private void VoidP()
        {
            this.GameCanvas.SVoidBA((byte)18);
        }

        // ���� byte0 ����ִ�в�ͬ�Ĳ���
        private void VoidBB(byte byte0)
        {
            if (byte0 == 5)
            {
                this.GameCanvas.SVoidBA((byte)1);
            }
            else
            {
                this.eventId = byte0;
                ReadRecord();
                this.j_byte_fld = 2;
            }
        }
        */

        // ����Ŀ�����
        private void FindTarCity()
        {
            Country country = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);
            short userKingId = country.countryKingId;
            byte[] cityIds = country.GetCities();
            for (int index = 0; index < cityIds.Length; index++)
            {
                byte cityId = country.GetCity((byte)index);
                City city = CityListCache.GetCityByCityId(cityId);
                if (city.prefectId == userKingId)
                {
                    this.tarCity = cityId;
                    this.p_byte_fld = this.tarCity;
                    break;
                }
            }
        }

        // ����Դ�ļ���ȡ�ַ���
        private string StringSa(string s1)
        {
            string s2 = null;
            try
            {
                using (System.IO.Stream inputstream = this.GetType().Assembly.GetManifestResourceStream(s1))
                {
                    if (inputstream == null)
                        return s2;

                    byte[] abyte0 = new byte[inputstream.Length];
                    inputstream.Read(abyte0, 0, (int)inputstream.Length);
                    s2 = System.Text.Encoding.UTF8.GetString(abyte0);
                }
            }
            catch (Exception exception) { }
            return s2;
        }

        // ���ô��ģս��������״̬
        void SetBigWarStatus(short word0, byte byte0, string s1)
        {
            // ��������ַ���ת��Ϊ�ֽڲ��洢��ָ����������
            this.bigWar_coordinate[word0,byte0] = byte.Parse(s1); // C# �� byte.Parse ���ڽ��ַ���ת��Ϊ byte
        }

        // �����ַ��������� bigWar_coordinate ����
        private void VoidSA(string s1)
        {
            int i1 = 0;
            int j1 = 0;
            byte byte0 = 0;
            byte byte1 = 0;
            try
            {
                while (j1 < s1.Length)
                {
                    if (s1[j1] == ',' || s1[j1] == '\n' || s1[j1] == '\r')
                    {
                        if (j1 != i1)
                        {
                            string s2 = s1.Substring(i1, j1 - i1);
                                SetBigWarStatus((short)byte1, byte0, s2);
                        }
                        i1 = j1 + 1;
                        if (s1[j1] == '\n')
                        {
                            byte1 = (byte)(byte1 + 1);
                            byte0 = 0;
                        }
                        else
                        {
                            byte0 = (byte)(byte0 + 1);
                        }
                    }
                    j1++;
                }
            }
            catch (Exception exception) { }
        }

        // ��ȡ��ͼ���ݲ�����
        private void VoidS()
        {
            string s1 = StringSa("/" + curWarCityId + ".map");
            VoidSA(s1);
        }

        // ��ȡ��ͼ�ļ�
        private void ReadMap()
        {
            // ������ͼ�ļ���·������ǰս������ID��curWarCityId��������ȷ������ĵ�ͼ�ļ�
            string name = "/map/" + curWarCityId + ".map";

            // �洢���ļ���ȡ���ֽ�����
            byte[] abyte0 = null;

            try
            {
                // ʹ��������ȡǶ�����Դ�ļ����ٶ���ͼ�ļ�����ΪǶ����Դ��������Ŀ�У�
                using (System.IO.Stream inputstream = this.GetType().Assembly.GetManifestResourceStream(name))
                {
                    // ����ļ������ڣ���ֱ�ӷ���
                    if (inputstream == null)
                        return;

                    // �����ֽ�����Ĵ�С�������ļ��ĳ���
                    abyte0 = new byte[inputstream.Length];

                    // ���ļ������뵽�ֽ����� abyte0 ��
                    inputstream.Read(abyte0, 0, (int)inputstream.Length);
                }
            }
            catch (Exception e)
            {
                // �����쳣������ӡ�쳣��Ϣ��ʵ��Ӧ���пɿ���ʹ����־��¼��
                e.ToString();
            }

            // ���ļ��ж�ȡ������������䵽 bigWar_coordinate ������
            int num = 0; // ָ�룬ָ�� byte �����еĵ�ǰλ��
            for (byte i = 0; i < 19; i = (byte)(i + 1))
            {
                for (byte j = 0; j < 32; j = (byte)(j + 1))
                {
                    // ����ȡ���ֽ�ֵ�洢�� bigWar_coordinate �����У������ͼ��ĳ��λ�õ�״̬
                    this.bigWar_coordinate[i, j] = abyte0[num];
                    num++; // ����ָ�룬��ȡ��һ���ֽ�
                }
            }
        }


        // ��ȡ��Ԫ��λ����
        private int getCellUnit(byte byte0)
        {
            int i1 = byte0 & 0xC0;
            if (i1 == 64)
                return 1;
            return (i1 != 128) ? 0 : 2;
        }

        // �� AI ���찴�쵼������
        private void SortAiGeneralByLead()
        {
            for (byte byte0 = 1; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                for (byte byte1 = 1; byte1 < this.aiGeneralNum_inWar - 1; byte1 = (byte)(byte1 + 1))
                {
                    General general1 = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[byte1]);
                    General general2 = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[byte1 + 1]);

                    if (general1.lead > general2.lead)
                    {
                        short word0 = this.aiGeneralId_inWar[byte1];
                        this.aiGeneralId_inWar[byte1] = this.aiGeneralId_inWar[byte1 + 1];
                        this.aiGeneralId_inWar[byte1 + 1] = word0;
                    }
                }
            }
        }

        // ���µ�λλ�õĺ���
        void RefreshUnitPosition(byte byte0, int i1)
        {
            if (i1 == 1)
            { // ��� i1 ���� 1
                switch (byte0)
                {
                    case 1:
                        // �����ƶ�
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 1);
                        this.aiUnitCellY[byte0] = this.aiUnitCellY[0];
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 2:
                        // �����ƶ�
                        this.aiUnitCellX[byte0] = this.aiUnitCellX[0];
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] - 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 3:
                        // �����ƶ�
                        this.aiUnitCellX[byte0] = this.aiUnitCellX[0];
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 4:
                        // �����ƶ�
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] - 1);
                        this.aiUnitCellY[byte0] = this.aiUnitCellY[0];
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 5:
                        // �������ƶ�
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 1);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] - 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 6:
                        // �������ƶ�
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 1);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 7:
                        // �������ƶ�������Ԫ��
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 2);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] - 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 8:
                        // �������ƶ�������Ԫ��
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 3);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 9:
                        // �������ƶ�������Ԫ��
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 2);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                }
            }
            else if (i1 == 2)
            { // ��� i1 ���� 2
                switch (byte0)
                {
                    case 1:
                        // �����ƶ�
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 1);
                        this.aiUnitCellY[byte0] = this.aiUnitCellY[0];
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 2:
                        // �����ƶ�
                        this.aiUnitCellX[byte0] = this.aiUnitCellX[0];
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 3:
                        // �����ƶ�
                        this.aiUnitCellX[byte0] = this.aiUnitCellX[0];
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] - 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 4:
                        // �����ƶ�
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] - 1);
                        this.aiUnitCellY[byte0] = this.aiUnitCellY[0];
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 5:
                        // �������ƶ�
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 1);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 6:
                        // �������ƶ�
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] - 1);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 7:
                        // �������ƶ�������Ԫ��
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 2);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 8:
                        // �������ƶ�������Ԫ��
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 3);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 9:
                        // �������ƶ�������Ԫ��
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 2);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] - 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                }
            }
        }


        // ���ݷ����ƶ�AI����
        void void_bb_g(byte byte0, byte byte1)
        {
            if (byte0 == 1 && byte1 == 0)
            {
                for (byte byte2 = 1; byte2 < this.aiGeneralNum_inWar; byte2 = (byte)(byte2 + 1))
                    RefreshUnitPosition(byte2, 1); // �ƶ�AI����
            }
            else if (byte0 == 1 && byte1 == 1)
            {
                for (byte byte3 = 1; byte3 < this.aiGeneralNum_inWar; byte3 = (byte)(byte3 + 1))
                    RefreshUnitPosition(byte3, 2); // �ƶ�AI����
            }
            else if (byte0 == 0 && byte1 == 1)
            {
                for (byte byte4 = 1; byte4 < this.aiGeneralNum_inWar; byte4 = (byte)(byte4 + 1))
                    RefreshUnitPosition(byte4, 3); // �ƶ�AI����
            }
            else if (byte0 == 0 && byte1 == 0)
            {
                for (byte byte5 = 1; byte5 < this.aiGeneralNum_inWar; byte5 = (byte)(byte5 + 1))
                    RefreshUnitPosition(byte5, 4); // �ƶ�AI����
            }
        }

        // ��ʼ��AI����λ��
        void void_u()
        {
            int i1 = 0;
            int j1 = 0;
            for (byte byte4 = 0; byte4 < 32; byte4 = (byte)(byte4 + 1))
            {
                byte byte7 = 0;
                while (byte7 < 19)
                {
                    if (this.bigWar_coordinate[byte7, byte4] == 2)
                    {
                        i1 = byte4;
                        j1 = byte7;
                        if (byte4 > 15)
                        {
                            this.I_byte_fld = 0;
                        }
                        else
                        {
                            this.K_byte_fld = 0;
                        }
                        if (byte7 > 10)
                        {
                            this.J_byte_fld = 0;
                            break;
                        }
                        this.L_byte_fld = 0;
                        break;
                    }
                    byte7 = (byte)(byte7 + 1);
                }
            }
            this.aiUnitCellX[0] = (byte)i1;
            this.aiUnitCellY[0] = (byte)j1;
            this.aiUnitTrapped[0] = 0;
            this.bigWar_coordinate[j1, i1] = (byte)(this.bigWar_coordinate[j1, i1] | 0x80);
            SortAiGeneralByLead(); // ������������
            void_bb_g(this.I_byte_fld, this.J_byte_fld); // ���ݷ����ƶ�AI����
            for (byte byte6 = 0; byte6 < this.humanGeneralNum_inWar; byte6 = (byte)(byte6 + 1))
            {
                byte byte1, byte3;
                do
                {
                    byte1 = (byte)((MathUtils.getRandomInt(2) + 12) * this.I_byte_fld + i1);
                    byte3 = (byte)(MathUtils.getRandomInt(5) * this.J_byte_fld + j1);
                } while (getCellUnit(this.bigWar_coordinate[byte3, byte1]) > 0);
                this.humanUnitCellX[byte6] = byte1;
                this.humanUnitCellY[byte6] = byte3;
                this.bigWar_coordinate[byte3, byte1] = (byte)(this.bigWar_coordinate[byte3, byte1] | 0x40);
                this.humanUnitTrapped[byte6] = 0;
            }
        }

        // ��ʼ�����ཫ��λ��
        void void_v()
        {
            int i1 = 0;
            int j1 = 0;
            for (byte byte4 = 0; byte4 < 31; byte4 = (byte)(byte4 + 1))
            {
                byte byte7 = 0;
                while (byte7 < 19)
                {
                    if (this.bigWar_coordinate[byte7, byte4] == 2)
                    {
                        i1 = byte4;
                        j1 = byte7;
                        if (byte4 > 15)
                        {
                            this.I_byte_fld = 0;
                            this.K_byte_fld = 0;
                        }
                        if (byte7 > 10)
                        {
                            this.J_byte_fld = 0;
                            this.L_byte_fld = 0;
                        }
                        break;
                    }
                    byte7 = (byte)(byte7 + 1);
                }
            }
            this.humanUnitCellX[0] = (byte)i1;
            this.humanUnitCellY[0] = (byte)j1;
            this.humanUnitTrapped[0] = 0;
            this.bigWar_coordinate[j1, i1] = (byte)(this.bigWar_coordinate[j1, i1] | 0x40);
            for (byte byte5 = 1; byte5 < this.humanGeneralNum_inWar; byte5 = (byte)(byte5 + 1))
            {
                byte byte0, byte2;
                do
                {
                    byte0 = (byte)(MathUtils.getRandomInt(2) * this.I_byte_fld + i1);
                    byte2 = (byte)(MathUtils.getRandomInt(5) * this.J_byte_fld + j1);
                } while (getCellUnit(this.bigWar_coordinate[byte2, byte0]) > 0);
                this.humanUnitCellX[byte5] = byte0;
                this.humanUnitCellY[byte5] = byte2;
                this.bigWar_coordinate[byte2, byte0] = (byte)(this.bigWar_coordinate[byte2, byte0] | 0x40);
                this.humanUnitTrapped[byte5] = 0;
            }
            for (byte byte6 = 0; byte6 < this.aiGeneralNum_inWar; byte6 = (byte)(byte6 + 1))
            {
                byte byte1, byte3;
                do
                {
                    byte1 = (byte)((MathUtils.getRandomInt(2) + 12) * this.I_byte_fld + i1);
                    byte3 = (byte)(MathUtils.getRandomInt(5) * this.J_byte_fld + j1);
                } while (getCellUnit(this.bigWar_coordinate[byte3, byte1]) > 0);
                this.aiUnitCellX[byte6] = byte1;
                this.aiUnitCellY[byte6] = byte3;
                this.bigWar_coordinate[byte3, byte1] = (byte)(this.bigWar_coordinate[byte3, byte1] | 0x80);
                this.aiUnitTrapped[byte6] = 0;
            }
        }

        // ����AI���ĳ�ʼλ��
        void AIStance()
        {
            byte[,] ai = new byte[15, 2];
            byte[,] hm = new byte[15, 2];
            byte num1 = 0;
            byte num2 = 0;
            byte hx0 = 0;
            byte hy0 = 0;
            for (byte i = 0; i < 19; i = (byte)(i + 1))
            {
                for (byte j = 0; j < 32; j = (byte)(j + 1))
                {
                    if (this.bigWar_coordinate[i, j] == 2)
                    {
                        ai[num1, 0] = j;
                        ai[num1, 1] = i;
                        num1 = (byte)(num1 + 1);
                    }
                    else if (this.bigWar_coordinate[i, j] == 1)
                    {
                        hm[num2, 0] = j;
                        hm[num2, 1] = i;
                        num2 = (byte)(num2 + 1);
                    }
                    else if (this.bigWar_coordinate[i, j] == 8)
                    {
                        hx0 = j;
                        hy0 = i;
                    }
                }
            }
            this.aiUnitCellX[0] = hx0;
            this.aiUnitCellY[0] = hy0;
            this.aiUnitTrapped[0] = 0;
            this.bigWar_coordinate[hy0, hx0] = (byte)(this.bigWar_coordinate[hy0, hx0] | 0x80);
            for (byte index = 1; index < this.aiGeneralNum_inWar; index = (byte)(index + 1))
            {
                byte x, y;
                do
                {
                    byte index2 = (byte)MathUtils.getRandomInt(15);
                    x = ai[index2, 0];
                    y = ai[index2, 1];
                } while (getCellUnit(this.bigWar_coordinate[y, x]) > 0);
                this.aiUnitCellX[index] = x;
                this.aiUnitCellY[index] = y;
                this.bigWar_coordinate[y, x] = (byte)(this.bigWar_coordinate[y, x] | 0x80);
                this.aiUnitTrapped[index] = 0;
            }
            for (byte byte5 = 0; byte5 < this.humanGeneralNum_inWar; byte5 = (byte)(byte5 + 1))
            {
                byte x, y;
                do
                {
                    byte index2 = (byte)MathUtils.getRandomInt(15);
                    x = hm[index2, 0];
                    y = hm[index2, 1];
                } while (getCellUnit(this.bigWar_coordinate[y, x]) > 0);
                this.humanUnitCellX[byte5] = x;
                this.humanUnitCellY[byte5] = y;
                this.bigWar_coordinate[y, x] = (byte)(this.bigWar_coordinate[y, x] | 0x40);
                this.humanUnitTrapped[byte5] = 0;
            }
        }

        // �������෽�ĳ�ʼλ��
        void HMStance()
        {
            byte[,] ai = new byte[15, 2];
            byte[,] hm = new byte[15, 2];
            byte num1 = 0;
            byte num2 = 0;
            byte hx0 = 0;
            byte hy0 = 0;
            for (byte i = 0; i < 19; i = (byte)(i + 1))
            {
                for (byte j = 0; j < 32; j = (byte)(j + 1))
                {
                    if (this.bigWar_coordinate[i, j] == 1)
                    {
                        ai[num1, 0] = j;
                        ai[num1, 1] = i;
                        num1 = (byte)(num1 + 1);
                    }
                    else if (this.bigWar_coordinate[i, j] == 2)
                    {
                        hm[num2, 0] = j;
                        hm[num2, 1] = i;
                        num2 = (byte)(num2 + 1);
                    }
                    else if (this.bigWar_coordinate[i, j] == 8)
                    {
                        hx0 = j;
                        hy0 = i;
                    }
                }
            }
            for (byte index = 0; index < this.aiGeneralNum_inWar; index = (byte)(index + 1))
            {
                byte x, y;
                do
                {
                    byte index2 = (byte)MathUtils.getRandomInt(15);
                    x = ai[index2, 0];
                    y = ai[index2, 1];
                } while (getCellUnit(this.bigWar_coordinate[y, x]) > 0);
                this.aiUnitCellX[index] = x;
                this.aiUnitCellY[index] = y;
                this.bigWar_coordinate[y, x] = (byte)(this.bigWar_coordinate[y, x] | 0x80);
                this.aiUnitTrapped[index] = 0;
            }
            this.humanUnitCellX[0] = hx0;
            this.humanUnitCellY[0] = hy0;
            this.humanUnitTrapped[0] = 0;
            this.bigWar_coordinate[hy0, hx0] = (byte)(this.bigWar_coordinate[hy0, hx0] | 0x40);
            for (byte byte5 = 1; byte5 < this.humanGeneralNum_inWar; byte5 = (byte)(byte5 + 1))
            {
                byte x, y;
                do
                {
                    byte index2 = (byte)MathUtils.getRandomInt(15);
                    x = hm[index2, 0];
                    y = hm[index2, 1];
                } while (getCellUnit(this.bigWar_coordinate[y, x]) > 0);
                this.humanUnitCellX[byte5] = x;
                this.humanUnitCellY[byte5] = y;
                this.bigWar_coordinate[y, x] = (byte)(this.bigWar_coordinate[y, x] | 0x40);
                this.humanUnitTrapped[byte5] = 0;
            }
        }

        // ��ʼս��ǰ��׼��
        void PrepareWarStance()
        {
            ReadMap();
            if (this.AIAttackHM)
            {
                HMStance(); // ���AI�������࣬�������������λ��
            }
            else
            {
                AIStance(); // ����������AI��λ��
            }
            ////this.gamecanvas.s_void_b_a((byte)20); // ������������
            this.Q_byte_array1d_fld = new byte[this.aiGeneralNum_inWar]; // ��ʼ������
            for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
                this.Q_byte_array1d_fld[byte0] = 0; // �������
            this.f_int_fld = 0; // ��ʼ�����ͱ���
        }

        void void_x()
        {
            this.j_byte_fld = 0; // ��ʼ���ֽ��ͱ���
            this.e_short_fld = (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId; // ��ȡ������ҹ���ID
            this.userKingId = this.e_short_fld; // ���ƹ���ID���û�����
            this.f_short_fld = (CityListCache.GetCityByCityId(this.curCity)).cityBelongKing; // ��ȡ��ǰ������������ID
            this.aiKingId = this.f_short_fld; // ���ƹ���ID��AI����
            this.B_byte_fld = this.tarCity; // ����Ŀ�����ID
            curWarCityId = this.curCity; // ��ǰս������ID
            WarInfo.curWarCityId = curWarCityId; // ����ս����Ϣ�еĳ���ID
            this.humanGeneralNum_inWar = this.chooseGeneralNum; // ���������ս��������
            for (int i = 0; i < this.humanGeneralNum_inWar; i++)
                this.humanGeneralId_inWar[i] = this.chooseGeneralIdArray[i]; // ���������ս����ID
            for (byte byte0 = 0; byte0 < this.humanGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
                this.humanUnitTrapped[byte0] = 0; // ��ʼ�����൥λ����״̬
            City curWarCity = CityListCache.GetCityByCityId(curWarCityId); // ��ȡ��ǰս�����ж���
            this.aiGeneralNum_inWar = curWarCity.getCityGeneralNum(); // ��ȡ�ó��еĽ�������
            short[] officeGeneralIdArray = curWarCity.getCityOfficeGeneralIdArray(); // ��ȡ�ó��еĽ���ID����
            for (int j = 0; j < this.aiGeneralNum_inWar; j++)
                this.aiGeneralId_inWar[j] = officeGeneralIdArray[j]; // ����AI��ս����ID
            if (this.aiGeneralNum_inWar < 10)
            {
                short[] connectCityId = curWarCity.connectCityId; // ��ȡ���ӳ���ID����
                for (int k = 0; k < connectCityId.Length || this.aiGeneralNum_inWar >= 10; k++)
                {
                    byte cityId = (byte)connectCityId[k]; // ��ȡ���ӳ���ID
                    City city = CityListCache.GetCityByCityId(cityId); // ��ȡ���ӳ��ж���
                    if (city.cityBelongKing == this.aiKingId)
                    {
                        while ((city.getCityOfficeGeneralIdArray()).Length < 2 && this.aiGeneralNum_inWar >= 10)
                        {
                            short generalId = city.getMaxBattlePowerGeneralId(); // ��ȡս������ߵĽ���ID
                            if (generalId == this.aiKingId)
                            {
                                short otherGeneralId = this.aiGeneralId_inWar[0]; // ��ȡ��һ����ս����ID
                                this.aiGeneralId_inWar[this.aiGeneralNum_inWar] = otherGeneralId; // �滻���һ����ս����ID
                                this.aiGeneralId_inWar[0] = generalId; // ��ս������ߵĽ���ID�ŵ���һλ
                            }
                            else
                            {
                                this.aiGeneralId_inWar[this.aiGeneralNum_inWar] = generalId; // ����µĲ�ս����ID
                            }
                            this.aiGeneralNum_inWar = (byte)(this.aiGeneralNum_inWar + 1); // ���Ӳ�ս��������
                            city.removeOfficeGeneralId(generalId); // �Ƴ��ý���ID
                        }
                        city.AppointmentPrefect(); // ����̫��
                    }
                }
            }
            for (byte byte1 = 0; byte1 < this.aiGeneralNum_inWar; byte1 = (byte)(byte1 + 1))
                this.aiUnitTrapped[byte1] = 0; // ��ʼ��AI��λ����״̬
            this.AIAttackHM = false; // ����AI�Ƿ񹥻������״̬
            this.I_byte_fld = 1; // ��ʼ���ֽ��ͱ���
            this.J_byte_fld = 1; // ��ʼ���ֽ��ͱ���
            this.K_byte_fld = 1; // ��ʼ���ֽ��ͱ���
            this.L_byte_fld = 1; // ��ʼ���ֽ��ͱ���
            this.day = 0; // ��ʼ������
            this.F_byte_fld = 0; // ��ʼ���ֽ��ͱ���
            this.aiMoney_inWar = curWarCity.GetMoney(); // ��ȡ��ǰ���н�Ǯ
            this.aiGrain_inWar = curWarCity.GetFood(); // ��ȡ��ǰ������ʳ
            this.g_boolean_fld = true; // ��ʼ�������ͱ���
            this.N_byte_fld = 0; // ��ʼ���ֽ��ͱ���
            setHunmanMoveBonus(); // ���������ƶ�����
            PrepareWarStance(); // ����������ʼ������
            /*//this.gamecanvas.void_b(); // ������Ϸ�����ķ���
            //this.gamecanvas.void_a(); // ������Ϸ�����ķ���
            //this.gamecanvas.void_i(); // ������Ϸ�����ķ���*/
        }

        //��Ԫ�����������
        int getCellNeedMoves(byte terrain, short genId)
        {
            if ((terrain & 0xC0) != 0)
                return 100;
            terrain = (byte)(terrain & 0x1F);
            int movesNeed = 0;
            switch (terrain)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 19:
                case 22:
                    movesNeed = 2;
                    return movesNeed;
                case 10:
                case 12:
                    movesNeed = 6;
                    if (getSkill_3(genId, 5))
                        movesNeed--;
                    switch ((GeneralListCache.GetGeneral(genId)).army[1])
                    {
                        case 1:
                            movesNeed--;
                            break;
                        case 2:
                            movesNeed -= 2;
                            break;
                        case 3:
                            movesNeed -= 3;
                            break;
                    }
                    return movesNeed;
                case 9:
                case 15:
                    movesNeed = 6;
                    if (getSkill_5(genId, 4))
                        movesNeed--;
                    switch ((GeneralListCache.GetGeneral(genId)).army[2])
                    {
                        case 1:
                            movesNeed--;
                            break;
                        case 2:
                            movesNeed -= 2;
                            break;
                        case 3:
                            movesNeed -= 3;
                            break;
                    }
                    return movesNeed;
                case 11:
                    movesNeed = 5;
                    switch ((GeneralListCache.GetGeneral(genId)).army[2])
                    {
                        case 1:
                            movesNeed--;
                            break;
                        case 2:
                            movesNeed -= 2;
                            break;
                        case 3:
                            movesNeed -= 3;
                            break;
                    }
                    return movesNeed;
            }
            movesNeed = 120;
            return movesNeed;
        }

        short getAllSoldierCountInWar(short[] generalIdInWarArray, byte generalInWarNum, byte[] unitTrapped)
        {
            short allSoldierCount = 0;
            for (byte index = 0; index < generalInWarNum; index = (byte)(index + 1))
            {
                if (unitTrapped[index] == 0 || unitTrapped[index] > 3)
                    allSoldierCount = (short)(allSoldierCount + (GeneralListCache.GetGeneral(generalIdInWarArray[index])).generalSoldier);
            }
            return allSoldierCount;
        }

        bool getSkill_1(short genId, int skillID)
        {
            return getSkill(0, genId, skillID);
        }

        bool getSkill_2(short genId, int skillID)
        {
            return getSkill(1, genId, skillID);
        }

        bool getSkill_3(short genId, int skillId)
        {
            return getSkill(2, genId, skillId);
        }

        bool GetSkill_4(short genId, int skillID)
        {
            return getSkill(3, genId, skillID);
        }

        bool getSkill_5(short genId, int skillId)
        {
            return getSkill(4, genId, skillId);
        }

        private bool getSkill(int i, short genId, int skillId)
        {
            General general = GeneralListCache.GetGeneral(genId);
            return ((general.skills[i] >> 10 - skillId & 0x1) == 1);
        }

        byte planNeedMoves(byte planIndex, short genId)
        {
            byte need = 0;
            switch (planIndex)
            {
                case 0:
                case 3:
                    need = 6;
                    break;
                case 1:
                    need = 5;
                    break;
                case 2:
                    need = 4;
                    break;
                case 4:
                    need = 7;
                    break;
                case 5:
                case 6:
                case 7:
                case 13:
                    need = 8;
                    break;
                case 9:
                    need = 9;
                    break;
                case 8:
                case 10:
                case 11:
                case 12:
                case 15:
                    need = 10;
                    break;
                case 14:
                    need = 12;
                    break;
                default:
                    need = 100;
                    return need;
            }
            if (getSkill_1(genId, 2))
                need = (byte)(need - 2);
            return need;
        }

        bool isInRange(byte x1, byte y1, byte x2, byte y2, int distance)
        {
            // �����������֮��ľ����Ƿ�С�ڵ���ָ���ľ���
            return (System.Math.Abs(x1 - x2) <= distance && System.Math.Abs(y1 - y2) <= distance);
        }

        bool isAdjacent(byte x1, byte y1, byte x2, byte y2)
        {
            // ������������Ƿ�����
            return (System.Math.Abs(x1 - x2) + System.Math.Abs(y1 - y2) == 1);
        }

            // ��ȡ���ڵ�λ������
            byte getAdjacentUnitNum(byte x, byte y)
            {
                byte byte2 = 0;

                // ���x������ߵĵ�Ԫ��
                if (x > 0)
                {
                    // �����ǰ��Ԫ�����ߵ�Ԫ��ĸ�λ�ֽڶ������ˣ�0xC0��ʾ��λ�ֽڣ��������� byte2 �� 0x10 λ
                    if (((this.bigWar_coordinate[y, x] | this.bigWar_coordinate[y, x - 1]) & 0xC0) == 192)
                    {
                        byte2 = (byte)(byte2 | 0x10);
                    }
                    // �����ǰ��Ԫ�����ߵ�Ԫ��ĸ�λ�ֽڶ����㣬������ byte2 �� 0x1 λ
                    else if ((this.bigWar_coordinate[y, x] & this.bigWar_coordinate[y, x - 1] & 0xC0) != 0)
                    {
                        byte2 = (byte)(byte2 | 0x1);
                    }
                }

                // ���x�����ұߵĵ�Ԫ��
                if (x < this.bigWar_coordinate.GetLength(1) - 1)
                {
                    // �����ǰ��Ԫ����ұߵ�Ԫ��ĸ�λ�ֽڶ������ˣ������� byte2 �� 0x10 λ
                    if (((this.bigWar_coordinate[y, x] | this.bigWar_coordinate[y, x + 1]) & 0xC0) == 192)
                    {
                        byte2 = (byte)(byte2 | 0x10);
                    }
                    // �����ǰ��Ԫ����ұߵ�Ԫ��ĸ�λ�ֽڶ����㣬������ byte2 �� 0x1 λ
                    else if ((this.bigWar_coordinate[y, x] & this.bigWar_coordinate[y, x + 1] & 0xC0) != 0)
                    {
                        byte2 = (byte)(byte2 | 0x1);
                    }
                }

                // ���y�����Ϸ��ĵ�Ԫ��
                if (y > 0)
                {
                    // �����ǰ��Ԫ����Ϸ���Ԫ��ĸ�λ�ֽڶ������ˣ������� byte2 �� 0x10 λ
                    if (((this.bigWar_coordinate[y, x] | this.bigWar_coordinate[y - 1, x]) & 0xC0) == 192)
                    {
                        byte2 = (byte)(byte2 | 0x10);
                    }
                    // �����ǰ��Ԫ����Ϸ���Ԫ��ĸ�λ�ֽڶ����㣬������ byte2 �� 0x1 λ
                    else if ((this.bigWar_coordinate[y, x] & this.bigWar_coordinate[y - 1, x] & 0xC0) != 0)
                    {
                        byte2 = (byte)(byte2 | 0x1);
                    }
                }

                // ���y�����·��ĵ�Ԫ��
                if (y < this.bigWar_coordinate.GetLength(0) - 1)
                {
                    // �����ǰ��Ԫ����·���Ԫ��ĸ�λ�ֽڶ������ˣ������� byte2 �� 0x10 λ
                    if (((this.bigWar_coordinate[y, x] | this.bigWar_coordinate[y + 1, x]) & 0xC0) == 192)
                    {
                        byte2 = (byte)(byte2 | 0x10);
                    }
                    // �����ǰ��Ԫ����·���Ԫ��ĸ�λ�ֽڶ����㣬������ byte2 �� 0x1 λ
                    else if ((this.bigWar_coordinate[y, x] & this.bigWar_coordinate[y + 1, x] & 0xC0) != 0)
                    {
                        byte2 = (byte)(byte2 | 0x1);
                    }
                }

                // �������յ� byte2 ֵ
                return byte2;
            }

            bool curCellCanPlan(short planGenId, int planGeneralIndex, int bePlanCeneralIndex, byte curPlanIndex, bool isHunmanPlan)
        {
            byte[] abyte0, abyte1, abyte2, abyte3;
            if (isHunmanPlan)
            {
                abyte0 = this.humanUnitCellX;
                abyte1 = this.humanUnitCellY;
                abyte2 = this.aiUnitCellX;
                abyte3 = this.aiUnitCellY;
            }
            else
            {
                abyte0 = this.aiUnitCellX;
                abyte1 = this.aiUnitCellY;
                abyte2 = this.humanUnitCellX;
                abyte3 = this.humanUnitCellY;
            }

            byte x1 = abyte0[planGeneralIndex];
            byte y1 = abyte1[planGeneralIndex];
            byte x2 = abyte2[bePlanCeneralIndex];
            byte y2 = abyte3[bePlanCeneralIndex];

            byte planUnitCellType = (byte)(this.bigWar_coordinate[y1,x1] & 0x1F);
            byte bePlanUnitCellType = (byte)(this.bigWar_coordinate[y2,x2] & 0x1F);

            bool canPlan = false;
            byte range = 0;

            switch (curPlanIndex)
            {
                case 0:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (((bePlanUnitCellType >= 1 && bePlanUnitCellType <= 4) || bePlanUnitCellType == 10 || bePlanUnitCellType == 11) && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 1:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType >= 10 && bePlanUnitCellType <= 12 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 2:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType >= 10 && bePlanUnitCellType <= 12 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 3:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType >= 10 && bePlanUnitCellType <= 12 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 4:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType == 9 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 5:
                    range = 2;
                    if (getSkill_1(planGenId, 1))
                    {
                        range = (byte)(range + 1);
                    }
                    else if (getSkill_1(planGenId, 8))
                    {
                        range = (byte)(range + 1);
                    }
                    if (bePlanUnitCellType != 8 && bePlanUnitCellType != 9 && bePlanCeneralIndex == 0 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 6:
                    range = 2;
                    if (getSkill_1(planGenId, 1))
                    {
                        range = (byte)(range + 1);
                    }
                    else if (getSkill_1(planGenId, 9))
                    {
                        range = (byte)(range + 1);
                    }
                    if (bePlanUnitCellType == 12 && isInRange(x1, y1, x2, y2, range) && getAdjacentUnitNum(x2, y2) >= 1)
                        canPlan = true;
                    break;
                case 7:
                    if (getSkill_1(planGenId, 1))
                    {
                        if (bePlanUnitCellType == 8 && isInRange(x1, y1, x2, y2, 1))
                            canPlan = true;
                        break;
                    }
                    if (bePlanUnitCellType == 8 && isAdjacent(x1, y1, x2, y2))
                        canPlan = true;
                    break;
                case 8:
                    range = 2;
                    if (getSkill_1(planGenId, 1))
                    {
                        range = (byte)(range + 1);
                    }
                    else if (getSkill_1(planGenId, 8))
                    {
                        range = (byte)(range + 1);
                    }
                    if ((bePlanUnitCellType == 10 || bePlanUnitCellType == 11) && isInRange(x1, y1, x2, y2, range) && bePlanCeneralIndex == 0)
                        canPlan = true;
                    break;
                case 9:
                    range = 2;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType != 8 && (planUnitCellType == 8 || planUnitCellType == 12) && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 10:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType == 9 && isInRange(x1, y1, x2, y2, range) && getAdjacentUnitNum(x2, y2) >= 1)
                        canPlan = true;
                    break;
                case 11:
                    range = 2;
                    if (getSkill_1(planGenId, 7))
                    {
                        range = (byte)(range + 2);
                    }
                    else if (getSkill_1(planGenId, 1))
                    {
                        range = (byte)(range + 1);
                    }
                    if (planUnitCellType >= 10 && planUnitCellType <= 12 && bePlanUnitCellType != 8 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 12:
                    range = 3;
                    if (getSkill_1(planGenId, 1))
                    {
                        range = (byte)(range + 1);
                    }
                    else if (getSkill_1(planGenId, 9))
                    {
                        range = (byte)(range + 1);
                    }
                    if (bePlanUnitCellType == 9 && isInRange(x1, y1, x2, y2, range) && getAdjacentUnitNum(x2, y2) >= 1)
                        canPlan = true;
                    break;
                case 13:
                    range = 2;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if ((planUnitCellType == 8 || planUnitCellType == 12) && bePlanUnitCellType != 8 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 14:
                    range = 3;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType >= 10 && bePlanUnitCellType <= 11 && isInRange(x1, y1, x2, y2, range) && getAdjacentUnitNum(x2, y2) >= 2)
                        canPlan = true;
                    break;
                case 15:
                    canPlan = false;
                    break;
            }
            return canPlan;
        }

        byte byte_s1bs_a(short[] aword0, byte byte0, short word0)
        {
            for (byte byte1 = 0; byte1 < byte0; byte1 = (byte)(byte1 + 1))
            {
                // Ѱ��������ָ��ֵ��λ��
                if (aword0[byte1] == word0)
                    return byte1;
            }
            return 0;
        }

        bool userRetreatGeneral()
        {
            this.HMGeneralId = this.humanGeneralId_inWar[0];
            FindRetreatCity(curWarCityId);
            if (this.disasterThings == 0 && this.HMGeneralId == this.userKingId)
            {
                if (GeneralDie(this.HMGeneralId, true))
                {
                    this.HMGeneralId = this.humanGeneralId_inWar[this.N_byte_fld];
                    this.j_byte_fld = 0;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                this.N_byte_fld = 0;
                ////this.gamecanvas.void_B_a(true);
            }
            return true;
        }

        void void_s_c(short generalId)
        {
            this.HMGeneralId = generalId;
            byte byte0 = byte_s1bs_a(this.humanGeneralId_inWar, this.humanGeneralNum_inWar, generalId);
            FindRetreatCity(curWarCityId);
            if (byte0 == 0)
            {
                if (this.disasterThings == 0 && this.HMGeneralId == this.userKingId)
                {
                    ////this.gamecanvas.r_byte_fld = 18;//��������
                }
                else
                {
                    this.N_byte_fld = 0;
                }
            }
            else
            {
                this.N_byte_fld = (byte)-byte0;
            }
            ////this.gamecanvas.void_B_a(true);
        }

        void void_sbs_a(short generalId, byte cityId, short belongKing)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            city.AddOfficeGeneralId(generalId);
            if (city.cityBelongKing == 0)
            {
                Country country = CountryListCache.GetCountryByKingId(belongKing);
                country.AddCity(cityId);
                city.prefectId = generalId;
            }
            else if (generalId == belongKing)
            {
                city.prefectId = generalId;
            }
            city.AppointmentPrefect();
        }

        void void_y()
        {
            byte byte0 = (byte)Math.Abs(this.N_byte_fld);
            if (byte0 < this.humanGeneralNum_inWar)
            {
                this.humanUnitTrapped[byte0] = 1;
                this.bigWar_coordinate[this.humanUnitCellY[byte0],this.humanUnitCellX[byte0]] = (byte)(this.bigWar_coordinate[this.humanUnitCellY[byte0],this.humanUnitCellX[byte0]] & 0x3F);
            }
            else
            {
                byte0 = (byte)(byte0 - this.humanGeneralNum_inWar);
                this.aiUnitTrapped[byte0] = 1;
                this.bigWar_coordinate[this.aiUnitCellY[byte0],this.aiUnitCellX[byte0]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[byte0],this.aiUnitCellX[byte0]] & 0x3F);
            }
        }

        void void_z()
        {
            Country userCountry = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);
            userCountry.RemoveCity(curWarCityId);
            if (userCountry.GetHaveCityNum() <= 0)
                GameInfo.countryDieTips = 3;
            CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).AddCity(curWarCityId);
            City city = CityListCache.GetCityByCityId(curWarCityId);
            city.ClearAllOfficeGeneral();
            city.cityBelongKing = (CountryListCache.GetCountryByCountryId(this.curTurnsCountryId)).countryKingId;
            for (int i = 0; i < this.aiGeneralNum_inWar; i++)
                city.AddOfficeGeneralId(this.aiGeneralId_inWar[i]);
            city.AppointmentPrefect();
        }

        void void_A()
        {
            byte byte0 = 0;
            City curWarCity = CityListCache.GetCityByCityId(curWarCityId);
            for (byte byte1 = 0; byte1 < this.aiGeneralNum_inWar; byte1 = (byte)(byte1 + 1))
            {
                if (this.aiUnitTrapped[byte1] == 0 || this.aiUnitTrapped[byte1] > 3)
                {
                    byte0 = (byte)(byte0 + 1);
                    this.aiGeneralId_inWar[byte0] = this.aiGeneralId_inWar[byte1];
                }
            }
            this.aiGeneralNum_inWar = byte0;
            for (byte byte2 = 0; byte2 < this.humanGeneralNum_inWar; byte2 = (byte)(byte2 + 1))
            {
                if (this.humanUnitTrapped[byte2] == 2)
                {
                    short userGeneralId = this.humanGeneralId_inWar[byte2];
                    if (this.aiGeneralNum_inWar < 10)
                    {
                        RandomSetGeneralLoyalty(userGeneralId);
                        this.aiGeneralNum_inWar = (byte)(this.aiGeneralNum_inWar + 1);
                        this.aiGeneralId_inWar[this.aiGeneralNum_inWar] = userGeneralId;
                    }
                    else
                    {
                        curWarCity.AddNotFoundGeneralId(userGeneralId);
                    }
                }
            }
            curWarCity.ClearAllOfficeGeneral();
            for (int i = 0; i < this.aiGeneralNum_inWar; i++)
                curWarCity.AddOfficeGeneralId(this.aiGeneralId_inWar[i]);
            curWarCity.AppointmentPrefect();
            curWarCity.SetMoney(this.aiMoney_inWar);
            curWarCity.SetFood(this.aiGrain_inWar);
            if (this.h_boolean_fld)
            {
                curWarCity.AddMoney(this.humanMoney_inWar);
                curWarCity.AddFood(this.humanGrain_inWar);
            }
            if (GameInfo.countryDieTips > 1)
            {
                //this.gamecanvas.r_byte_fld = 8;
                void_B();
                this.j_byte_fld = 0;
                if (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).GetHaveCityNum() <= 0)
                    GameInfo.countryDieTips = 3;
            }
        }

        void void_b_d(byte cityId)
        {
            if (cityId > 0)
            {
                void_sbs_a(this.HMGeneralId, cityId, (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId);
            }
            else
            {
                if (CountryListCache.GetCountryByKingId(this.HMGeneralId) != null)
                {
                    //this.gamecanvas.void_B_a(false);
                    return;
                }
                CityListCache.GetCityByCityId(curWarCityId).AddNotFoundGeneralId(this.HMGeneralId);
            }
            if (this.N_byte_fld == 0 && cityId > 0)
            {
                City city = CityListCache.GetCityByCityId(cityId);
                city.AddMoney(this.humanMoney_inWar);
                city.AddFood(this.humanGrain_inWar);
            }
            if (this.N_byte_fld < 0)
            {
                //this.gamecanvas.void_B_a(false);
            }
            else
            {
                //this.gamecanvas.s_boolean_fld = true;
                this.N_byte_fld = (byte)(this.N_byte_fld + 1);
                byte byte1;
                for (byte1 = this.N_byte_fld; byte1 < this.humanGeneralNum_inWar && this.humanUnitTrapped[byte1] != 0 && this.humanUnitTrapped[byte1] <= 3;)
                    byte1 = (byte)(byte1 + 1);
                if (byte1 < this.humanGeneralNum_inWar)
                {
                    FindRetreatCity(curWarCityId);
                    this.N_byte_fld = byte1;
                    this.HMGeneralId = this.humanGeneralId_inWar[this.N_byte_fld];
                }
                else
                {
                    if (this.N_byte_fld < this.humanGeneralNum_inWar)
                        this.N_byte_fld = this.humanGeneralNum_inWar;
                    byte byte2;
                    for (byte2 = (byte)(this.N_byte_fld - this.humanGeneralNum_inWar); byte2 < this.aiGeneralNum_inWar && this.aiUnitTrapped[byte2] != 2;)
                        byte2 = (byte)(byte2 + 1);
                    if (byte2 < this.aiGeneralNum_inWar)
                    {
                        FindRetreatCity(curWarCityId);
                        if (this.disasterThings > 0)
                            RandomSetGeneralLoyalty(this.aiGeneralId_inWar[byte2]);
                        this.N_byte_fld = (byte)(this.humanGeneralNum_inWar + byte2);
                        this.HMGeneralId = this.aiGeneralId_inWar[byte2];
                    }
                    else
                    {
                        //this.gamecanvas.void_B_a(false);
                        if (this.AIAttackHM)
                            void_z();
                        void_A();
                        this.j_byte_fld = 4;
                        return;
                    }
                }
            }
            void_y();
        }

        //������м�����Ӻ͹����߼�
        void FindRetreatCity(byte cityId)
        {
            byte byte1 = 0;
            City curCity = CityListCache.GetCityByCityId(cityId);
            for (byte index = 0; index < curCity.connectCityId.Length; index = (byte)(index + 1))
            {
                byte byte3 = (byte)curCity.connectCityId[index];
                City city = CityListCache.GetCityByCityId(byte3);
                if (city.cityBelongKing != 0 && (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId == city.cityBelongKing && city.getCityGeneralNum() < 10)
                {
                    byte1 = (byte)(byte1 + 1);
                    this.G_byte_array1d_fld[byte1] = (byte)byte3;
                }
            }
            this.G_byte_array1d_fld[byte1] = 0;
            this.disasterThings = byte1;
        }

        void void_B()
        {/*
            long l1 = System.Environment.TickCount;
            while (true)
            {
                if (//this.gamecanvas.getKeyValue() != 0)
                {
                    //this.gamecanvas.void_h();
                    if (!//this.gamecanvas.C_boolean_fld)
                        //this.gamecanvas.setKeyValue((byte)0);
                }
                if (this.j_byte_fld <= 0)
                {
                    long l2 = System.Environment.TickCount - l1;
                    if (l2 < 100L)
                        try
                        {
                            System.Threading.Thread.Sleep((int)(100L - l2));
                        }
                        catch (System.Exception exception) { }
                    //this.gamecanvas.repaint();
                    l1 = System.Environment.TickCount;
                    continue;
                }
                break;
            }*/
        }

        void void_s1bb1_a(short[] humanInWarGeneralIdArray, byte humanInWarGeneralNum, byte[] abyte0)
        {
            for (byte index = 0; index < humanInWarGeneralNum; index = (byte)(index + 1))
            {
                if (abyte0[index] >= 4)
                {
                    if (abyte0[index] > 7)
                    {
                        General humanGeneral = GeneralListCache.GetGeneral(humanInWarGeneralIdArray[index]);
                        humanGeneral.generalSoldier = (short)(humanGeneral.generalSoldier - 100 + MathUtils.getRandomInt(150 - humanGeneral.lead));
                        if (humanGeneral.generalSoldier < 0)
                            humanGeneral.generalSoldier = 0;
                    }
                    if (abyte0[index] == 4 || abyte0[index] == 5 || abyte0[index] == 8)
                    {
                        abyte0[index] = 0;
                    }
                    else
                    {
                        abyte0[index] = (byte)(abyte0[index] - 1);
                    }
                }
            }
        }

        // ����Ƿ��п�֧Ԯ�ĳ���
        bool boolean_bsi_a(byte warCityId, short kingId)
        {
            for (byte cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                City city = CityListCache.GetCityByCityId(cityId);
                if (city.cityBelongKing == kingId && cityId != warCityId && city.getCityGeneralNum() < 10)
                    return true;
            }
            return false;
        }

        // ���������Ľ�������
        int TrappedUnitNum()
        {
            int i1 = 0;
            for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                if (this.aiUnitTrapped[byte0] > 0 && this.aiUnitTrapped[byte0] < 4)
                    i1++;
            }
            for (byte byte1 = 0; byte1 < this.humanGeneralNum_inWar; byte1 = (byte)(byte1 + 1))
            {
                if (this.humanUnitTrapped[byte1] == 2)
                    i1++;
            }
            return i1;
        }

        // �ж� AI �Ƿ���Գ���
        bool boolean_d()
        {
            TrappedUnitNum();
            if (!boolean_bsi_a(curWarCityId, this.aiKingId))
                return false;
            return !((GeneralListCache.GetGeneral(this.aiGeneralId_inWar[0])).generalSoldier >= 100 && GeneralListCache.GetGeneral(this.aiGeneralId_inWar[0]).getCurPhysical() >= 15);
        }

        // �������෽��ս����
        short short_a()
        {
            short word0 = 0;
            for (byte byte0 = 0; byte0 < this.humanGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                if (this.humanUnitTrapped[byte0] <= 0 || this.humanUnitTrapped[byte0] >= 4)
                {
                    word0 = (short)(word0 + 500);
                    word0 = (short)(word0 + (GeneralListCache.GetGeneral(this.humanGeneralId_inWar[byte0])).generalSoldier);
                }
            }
            return word0;
        }

        // ���� AI ����ս����
        short short_b()
        {
            short word0 = 0;
            for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                if (this.aiUnitTrapped[byte0] <= 0 || this.aiUnitTrapped[byte0] >= 4)
                {
                    word0 = (short)(word0 + 500);
                    word0 = (short)(word0 + (GeneralListCache.GetGeneral(this.aiGeneralId_inWar[byte0])).generalSoldier);
                }
            }
            return word0;
        }

        // ���ѡ��һ�����Գ��˵ĳ��� ID
        byte RandomRetreatCityId(short word0, byte[] abyte0, byte byte0, byte byte1)
        {
            return abyte0[MathUtils.getRandomInt(byte0)];
        }

        // ��ȡ���Գ��˵ĳ��� ID
        byte getCanRetreatCityId(short aiKingId)
        {
            City curWarCity = CityListCache.GetCityByCityId(curWarCityId);
            byte[] abyte0 = new byte[curWarCity.connectCityId.Length];
            byte byte1 = 0;
            for (int i1 = 0; i1 < curWarCity.connectCityId.Length; i1++)
            {
                byte b = (byte)curWarCity.connectCityId[i1];
                City city = CityListCache.GetCityByCityId(b);
                if (city.cityBelongKing == aiKingId && city.getCityGeneralNum() < 10)
                {
                    abyte0[byte1] = b;
                    byte1 = (byte)(byte1 + 1);
                }
            }
            if (byte1 > 0)
                return getCanRetreatCityId(aiKingId, abyte0, byte1, curWarCityId);
            byte[] abyte1 = new byte[CityListCache.CITY_NUM];
            byte byte2 = 0;
            for (byte cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                if (cityId != curWarCityId)
                {
                    City city = CityListCache.GetCityByCityId(cityId);
                    if (city.cityBelongKing == aiKingId && city.getCityGeneralNum() < 10)
                    {
                        abyte1[byte2] = cityId;
                        byte2 = (byte)(byte2 + 1);
                    }
                }
            }
            if (byte2 > 0)
                return getCanRetreatCityId(aiKingId, abyte1, byte2, curWarCityId);
            return 0;
        }

        // ���ý���Ϊ����״̬
        void GeneralPrepareRetreat(short generalId)
        {
            for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                if (this.aiGeneralId_inWar[byte0] == generalId)
                {
                    this.aiUnitTrapped[byte0] = 1;
                    this.bigWar_coordinate[this.aiUnitCellY[byte0],this.aiUnitCellX[byte0]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[byte0],this.aiUnitCellX[byte0]] & 0x3F);
                    return;
                }
            }
        }

        // ���������˵�ָ������
        void generalRetreat(short generalId, byte cityId)
        {
            CityListCache.GetCityByCityId(curWarCityId).removeOfficeGeneralId(generalId);
            if (cityId > 0)
            {
                void_sbs_a(generalId, cityId, this.aiKingId);
            }
            else if (GeneralListCache.GetGeneral(generalId) != null)
            {
                CityListCache.GetCityByCityId(curWarCityId).AddNotFoundGeneralId(generalId);
            }
            GeneralPrepareRetreat(generalId);
        }

        // ���������뵱ǰս�����еĹ�Ա�б�
        void void_s1b_a(short[] aword0, byte generalNum)
        {
            for (int i1 = 0; i1 < generalNum; i1++)
                CityListCache.GetCityByCityId(curWarCityId).AddOfficeGeneralId(aword0[i1]);
        }

        void void_C()
        {
            // ��ʼ������
            short[] AINoRetreatGeneralIdArray = new short[10];
            short[] generalIdArray = new short[10];
            List<short> aiGeneralIdArray=new List<short>();
            byte generalNum = 0;
            byte AINoRetreatGeneralNum = 0;

            // ��ȡ��ǰս������
            City curWarCity = CityListCache.GetCityByCityId(curWarCityId);
            curWarCity.ClearAllOfficeGeneral();

            // ��ȡ�������� AI ����
            Country attackCountry = CountryListCache.GetCountryByKingId(this.e_short_fld);
            Country aiCountry = CountryListCache.GetCountryByKingId(this.aiKingId);

            // ���ݹ������Ƿ�Ϊ�������ִ�в�ͬ�߼�
            if (attackCountry.countryId == GameInfo.humanCountryId)
            {
                aiCountry.RemoveCity(curWarCityId);
                curWarCity.prefectId = this.humanGeneralId_inWar[0];
                attackCountry.AddCity(curWarCityId);
            }

            // ���õ�ǰս�����е���ʳ�ͽ�Ǯ
            curWarCity.SetFood(this.humanGrain_inWar);
            curWarCity.SetMoney(this.humanMoney_inWar);

            bool masterRetreat = true;

            // ���� AI ����
            for (byte b1 = 0; b1 < this.aiGeneralNum_inWar; b1 = (byte)(b1 + 1))
            {
                if (this.aiUnitTrapped[b1] == 0 || this.aiUnitTrapped[b1] > 3)
                {
                    aiGeneralIdArray.Add(this.aiGeneralId_inWar[b1]);
                    continue;
                }

                if (this.aiUnitTrapped[b1] == 2 || this.aiUnitTrapped[b1] == 3)
                {
                    if (b1 == 0)
                    {
                        masterRetreat = false;
                        Country country = CountryListCache.GetCountryByKingId(this.aiGeneralId_inWar[0]);
                        if (country != null)
                        {
                            GameInfo.chooseGeneralName = (GeneralListCache.GetGeneral(country.countryKingId)).generalName;
                            this.m_byte_fld = country.countryId;
                            if (country.GetHaveCityNum() > 0)
                            {
                                short newKingGeneralId = country.Inherit();
                                if (this.AIAttackHM)
                                {
                                    this.e_short_fld = newKingGeneralId;
                                }
                                else
                                {
                                    this.f_short_fld = newKingGeneralId;
                                }
                                this.aiKingId = newKingGeneralId;
                                GameInfo.countryDieTips = 1;
                                GameInfo.ShowInfo = string.Format("{0} ����, �¾��� {1} ��λ!", GameInfo.chooseGeneralName, GeneralListCache.GetGeneral(newKingGeneralId).generalName);
                            }
                            else
                            {
                                CountryListCache.removeCountry(country.countryId);
                            }
                            continue;
                        }
                    }

                    if (this.aiUnitTrapped[b1] == 2)
                    {
                        AINoRetreatGeneralNum = (byte)(AINoRetreatGeneralNum + 1);
                        AINoRetreatGeneralIdArray[AINoRetreatGeneralNum] = this.aiGeneralId_inWar[b1];
                    }
                    else
                    {
                        GeneralListCache.GeneralDie(this.aiGeneralId_inWar[b1]);
                    }
                }
            }

            // �������ཫ��
            for (byte b1 = 0; b1 < this.humanGeneralNum_inWar; b1 = (byte)(b1 + 1))
            {
                if (this.humanUnitTrapped[b1] == 0 || this.humanUnitTrapped[b1] > 3)
                {
                    generalNum = (byte)(generalNum + 1);
                    generalIdArray[generalNum] = this.humanGeneralId_inWar[b1];
                }
                else if (this.humanUnitTrapped[b1] == 2)
                {
                    if (masterRetreat)
                    {
                        RandomSetGeneralLoyalty(this.humanGeneralId_inWar[b1]);
                        aiGeneralIdArray.Add(this.humanGeneralId_inWar[b1]);
                    }
                    else
                    {
                        generalNum = (byte)(generalNum + 1);
                        generalIdArray[generalNum] = this.humanGeneralId_inWar[b1];
                    }
                }
            }

            // ���������δ���ˣ�����³��еĽ�Ǯ����ʳ
            if (!masterRetreat)
            {
                curWarCity.AddMoney(this.aiMoney_inWar);
                curWarCity.AddFood(this.aiGrain_inWar);
            }

            // AI �������˵�����
            aiCountry.RetreatGeneralToCity(aiGeneralIdArray.ToArray(), curWarCityId, this.aiGrain_inWar, this.aiMoney_inWar, !masterRetreat);

            // �������ཫ���б�
            this.humanGeneralId_inWar = generalIdArray;
            curWarCity.prefectId = this.humanGeneralId_inWar[0];
            this.humanGeneralNum_inWar = generalNum;
            for (int i = 0; i < this.humanGeneralNum_inWar; i++)
                curWarCity.AddOfficeGeneralId(this.humanGeneralId_inWar[i]);

            // ����޷����˵� AI �������������б�
            for (byte byte10 = 0; byte10 < AINoRetreatGeneralNum; byte10 = (byte)(byte10 + 1))
                curWarCity.AddOppositionGeneralId(AINoRetreatGeneralIdArray[byte10]);

            // ����ս��״̬
            this.j_byte_fld = 4;
        }

        void void_D()
        {
            // ���� void_C ����
            void_C();
        }

        short short_c()
        {
            short word0 = 0;
            // ������ʿ����
            for (byte byte0 = 0; byte0 < this.humanGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                if (this.humanUnitTrapped[byte0] <= 0 || this.humanUnitTrapped[byte0] >= 4)
                {
                    word0 = (short)(word0 + 500);
                    word0 = (short)(word0 + (GeneralListCache.GetGeneral(this.humanGeneralId_inWar[byte0])).generalSoldier);
                }
            }
            return word0;
        }

        void void_s_e(short word0)
        {
            // ���ٽ���ʿ������
            int i1 = (GeneralListCache.GetGeneral(word0)).generalSoldier / 2;
            i1 += MathUtils.getRandomInt(200);
            if (i1 < 200)
                i1 = 200 + MathUtils.getRandomInt(100);
            if (i1 > (GeneralListCache.GetGeneral(word0)).generalSoldier)
                i1 = (GeneralListCache.GetGeneral(word0)).generalSoldier;
            (GeneralListCache.GetGeneral(word0)).generalSoldier = (short)((GeneralListCache.GetGeneral(word0)).generalSoldier - i1);
        }

        void void_ii_b(int i1, int j1)
        {
            try
            {
                // ���ý��� ID ������
                this.HMGeneralId = this.humanGeneralId_inWar[i1];
                this.AIGeneralId = this.aiGeneralId_inWar[j1];
                this.hmbattleIndex = (byte)i1;
                this.aibettleIndex = (byte)j1;
                //this.gamecanvas.humanGeneralId = this.HMGeneralId;
                //this.gamecanvas.AIGeneralId = this.AIGeneralId;
                this.warTerrain = (byte)(this.bigWar_coordinate[this.humanUnitCellY[i1],this.humanUnitCellX[i1]] & 0xF);
                //this.gamecanvas.r_byte_fld = 2;
                this.aiAtkHm = true;
                void_B(); // ���� void_B ����
                this.j_byte_fld = 3;
            }
            catch (Exception exception) { }
        }

        byte planSuccessRate(short planGeneralId, short bePlanGeneralId, byte plan)
        {
            int s1, s2, success = 0;
            General planGeneral = GeneralListCache.GetGeneral(planGeneralId);
            General bePlanGeneral = GeneralListCache.GetGeneral(bePlanGeneralId);
            byte IQ1 = planGeneral.IQ;
            byte IQ2 = bePlanGeneral.IQ;
            byte lead1 = planGeneral.lead;
            byte lead2 = bePlanGeneral.lead;
            byte force2 = bePlanGeneral.force;
            byte moral2 = bePlanGeneral.moral;
            byte type = bePlanGeneral.army[2];

            // ���ݲ�ͬ�ļƻ����гɹ��ʼ���
            switch (plan)
            {
                case 0:
                case 1:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - lead2 * 0.05);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 40.0 - (100 - IQ1) * 0.1 - lead2 * 0.05);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    success = Math.Min(s1, s2);
                    break;

                case 4:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - lead2 * 0.05);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 40.0 - (100 - IQ1) * 0.1 - lead2 * 0.05);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    if (type > 0)
                    {
                        s1 -= type * 3;
                        s2 -= type * 2;
                    }
                    success = Math.Min(s1, s2);
                    break;

                case 2:
                case 3:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - force2 * 0.08);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 45.0 - (100 - IQ1) * 0.1 - force2 * 0.08);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    success = Math.Min(s1, s2);
                    break;

                case 5:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - lead2 * 0.05);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 60.0 - (100 - IQ1) * 0.1 - lead2 * 0.05);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    success = Math.Min(s1, s2);
                    break;

                case 6:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - moral2 * 0.05);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 60.0 - (100 - IQ1) * 0.1 - moral2 * 0.05);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    success = Math.Min(s1, s2);
                    break;

                case 7:
                    if (GeneralListCache.GetGeneral(bePlanGeneralId).generalSoldier > 1800 + MathUtils.getRandomInt(300))
                    {
                        s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - moral2 * 0.05);
                        s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 60.0 - (100 - IQ1) * 0.1 - moral2 * 0.05);
                        if (IQ1 < IQ2)
                            s2 -= (IQ2 - IQ1) / 6;
                        success = Math.Min(s1, s2);
                    }
                    else
                    {
                        success = 0;
                    }
                    break;

                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - lead2 * 0.05 + lead1 * 0.08);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 60.0 - (100 - IQ1) * 0.1 - lead2 * 0.05 + lead1 * 0.08);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    success = Math.Min(s1, s2);
                    break;

                case 15:
                    success = 99;
                    break;
            }

            // ���ܵ����ɹ���
            if (getSkill_1(planGeneralId, 5))
            {
                success = (int)(success + success * 0.2);
            }
            else if (getSkill_1(planGeneralId, 4) && (plan == 0 || plan == 14))
            {
                success += success / 3;
            }
            else if (getSkill_1(planGeneralId, 7) && plan == 10)
            {
                success += success / 3;
            }
            else if (getSkill_1(planGeneralId, 8) && (plan == 5 || plan == 8))
            {
                success += success / 3;
            }
            else if (getSkill_1(planGeneralId, 9) && (plan == 6 || plan == 12))
            {
                success += success / 3;
            }

            if (getSkill_1(bePlanGeneralId, 0) || getSkill_1(bePlanGeneralId, 5))
            {
                success -= success / 2;
            }
            else if (getSkill_1(bePlanGeneralId, 5))
            {
                success = (int)(success - success * 0.2);
            }

            // ���Ƴɹ��ʷ�Χ
            if (success > 99)
                success = 99;
            if (success < 0)
                success = 0;

            return (byte)success;
        }


        // �Ʋ߽��
        public int setplanResult(short planGeneralId, short bePlanGeneralId, byte plan, byte index, bool flag)
        {
            byte upday;
            int hurt2, totalhurt, sroundHurt1, totalhurt2;
            byte IQ1 = GeneralListCache.GetGeneral(planGeneralId).IQ; // ��ȡ�������佫������
            General bePlanGeneral = GeneralListCache.GetGeneral(bePlanGeneralId); // ��ȡ���������佫
            byte IQ2 = bePlanGeneral.IQ; // ��ȡ��������������
            int hurt = 0; // ��ʼ���˺�ֵ

            // ���ݲ������ʹ���
            switch (plan)
            {
                case 0:
                case 3:
                case 4:
                case 7:
                    // ���������������ڵ��ڷ�����ʱ
                    if (IQ1 >= IQ2)
                    {
                        hurt = MathUtils.getRandomInt((IQ1 - IQ2) * 2 + 2); // ���������������˺�
                    }
                    else
                    {
                        hurt -= MathUtils.getRandomInt((IQ2 - IQ1) * 2 + 2); // ������������ʱ���͹����˺�
                    }
                    hurt += 250; // �����˺�
                    if (getSkill_1(planGeneralId, 4) && plan == 0)
                    {
                        hurt *= 2; // ���ܼӳɣ����м��ܲ���Ϊ�ض��ƻ���˫���˺�
                    }
                    else if (getSkill_1(planGeneralId, 3))
                    {
                        hurt += hurt / 2; // �������ܼӳ�
                    }
                    // ȷ���������ʿ������������ʿ����
                    if (bePlanGeneral.generalSoldier < hurt)
                        hurt = bePlanGeneral.generalSoldier;
                    bePlanGeneral.generalSoldier = (short)(bePlanGeneral.generalSoldier - hurt); // ����ʿ������
                    this.b_java_lang_String_fld = "ʿ�������� " + hurt; // ���������Ϣ
                    break;

                case 1:
                    hurt = MathUtils.getRandomInt(6) + 15; // �����������ٵ�ֵ
                    if (bePlanGeneral.getCurPhysical() - 1 < hurt)
                        hurt = bePlanGeneral.getCurPhysical() - 1; // ��ֹ�������ٵ���ֵ
                    bePlanGeneral.decreaseCurPhysical((byte)hurt); // ��������
                    this.b_java_lang_String_fld = "�佫�������� " + hurt; // ���������Ϣ
                    break;

                case 2:
                    upday = 4; // ��ʼ��������
                    if (getSkill_1(planGeneralId, 3))
                        upday = 5; // ���ܼӳ�����ʱ��
                    if (flag)
                    {
                        this.aiUnitTrapped[index] = upday; // ����AI��λ�ı���״̬
                    }
                    else
                    {
                        this.humanUnitTrapped[index] = upday; // ������ҵ�λ�ı���״̬
                    }
                    this.b_java_lang_String_fld = "�����мƱ���"; // ���������Ϣ
                    break;

                case 5:
                    if (flag)
                    {
                        hurt = this.aiGrain_inWar / 4; // ������ʳ��ʧ
                        if (getSkill_1(planGeneralId, 3))
                            hurt += hurt / 2; // ���ܼӳ�
                        if (hurt < 200)
                            hurt = this.aiGrain_inWar; // ����ʧ���٣���Ϊȫ����ʧ
                        this.aiGrain_inWar = (short)(this.aiGrain_inWar - hurt); // AI��ʳ����
                        this.humanGrain_inWar = (short)(this.humanGrain_inWar + hurt); // �����ʳ����
                        if (this.humanGrain_inWar > 30000)
                            this.humanGrain_inWar = 30000; // ���������ʳ����
                    }
                    else
                    {
                        hurt = this.humanGrain_inWar / 4; // ͬ����������ʳ��ʧ
                        if (getSkill_1(planGeneralId, 3))
                            hurt += hurt / 2;
                        if (hurt < 200)
                            hurt = this.humanGrain_inWar;
                        this.humanGrain_inWar = (short)(this.humanGrain_inWar - hurt); // �����ʳ����
                        this.aiGrain_inWar = (short)(this.aiGrain_inWar + hurt); // AI��ʳ����
                        if (this.aiGrain_inWar > 30000)
                            this.aiGrain_inWar = 30000; // ����AI��ʳ����
                    }
                    this.b_java_lang_String_fld = "��ʳ���� " + hurt; // ���������Ϣ
                    hurt = 0;
                    break;

                // ���� case �����߼�����������...

                case 15:
                    this.b_java_lang_String_fld = "���Ŷݼ�ʩչ���!"; // ��������Ĵ���
                    break;
            }

            return hurt; // ���������˺�ֵ
        }


        public void getAttackRangeMap(byte[,] attackRangeMap, int unitCellX, int unitCellY)
        {
            // ������С����󹥻���Χ
            int minRange = 1;
            int maxRange = 1;

            // ���㿪ʼ�ͽ�������
            int startCellX = unitCellX - maxRange;
            if (startCellX < 0)
                startCellX = 0;
            int startCellY = unitCellY - maxRange;
            if (startCellY < 0)
                startCellY = 0;
            int endCellX = unitCellX + maxRange;
            if (endCellX >= 19)
                endCellX = 18;
            int endCellY = unitCellY + maxRange;
            if (endCellY >= 32)
                endCellY = 31;

            // ���ݷ�Χ���µ�ͼ
            for (int i = startCellX; i <= endCellX; i++)
            {
                for (int j = startCellY; j <= endCellY; j++)
                {
                    int range = Math.Abs(i - unitCellX) + Math.Abs(j - unitCellY);
                    if (range >= minRange && range <= maxRange && attackRangeMap[i, j] < 0)
                        attackRangeMap[i, j] = byte.MaxValue;
                }
            }
        }

        void getAttackMoveRangeMap(byte[,] attackRangeMap, byte moves, byte index)
        {
            getMoveMap(attackRangeMap, index);
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (attackRangeMap[i, j] >= 0 && attackRangeMap[i, j] != byte.MaxValue)
                        getAttackRangeMap(attackRangeMap, i, j);
                }
            }
        }

        void getMoveMap(byte[,] moveMap, byte index)
        {
            getMoveMap(moveMap, this.humanUnitCellY[index], this.humanUnitCellX[index], this.humanGeneralMoveBonus[index], 0, this.humanGeneralId_inWar[index], (byte)1, false);
        }

        public bool getMoveMap(byte[,] moveMap, int curCellX, int curCellY, int movesLeft, int ignoreDir, short unitType, byte unitSide, bool returnWhenMovable)
        {
            // ���µ�ǰλ�õ��ƶ�����
            if (movesLeft > moveMap[curCellX, curCellY])
            {
                moveMap[curCellX, curCellY] = (byte)movesLeft;
            }
            else
            {
                return false;
            }

            // ����������
            if (ignoreDir != 1)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX, curCellY - 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap(moveMap, curCellX, curCellY - 1, newMovesLeft, 2, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }
            if (ignoreDir != 2)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX, curCellY + 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap(moveMap, curCellX, curCellY + 1, newMovesLeft, 1, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }
            if (ignoreDir != 4)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX - 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap(moveMap, curCellX - 1, curCellY, newMovesLeft, 8, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }
            if (ignoreDir != 8)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX + 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap(moveMap, curCellX + 1, curCellY, newMovesLeft, 4, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            return false;
        }

        public int movesNeededForCell(int cellX, int cellY, short genId)
        {
            if (cellX >= 0 && cellY >= 0 && cellX < 19 && cellY < 32)
            {
                byte terrain = this.bigWar_coordinate[cellX, cellY];
                if (terrain < 0)
                    return 1000;
                return getCellNeedMoves(terrain, genId);
            }
            return 10000;
        }

        void plan(byte aiIndex, byte humanIndex)
        {
            byte plan = getplan(aiIndex, humanIndex);
            if (plan < 0)
                return;

            this.aiGeneralMoveBonus[aiIndex] = (byte)(this.aiGeneralMoveBonus[aiIndex] - planNeedMoves(plan, this.humanGeneralId_inWar[humanIndex]));
            byte su = planSuccessRate(this.aiGeneralId_inWar[aiIndex], this.humanGeneralId_inWar[humanIndex], plan);
            if (MathUtils.getRandomInt(70) < su)
            {
                int exp = setplanResult(this.aiGeneralId_inWar[aiIndex], this.humanGeneralId_inWar[humanIndex], plan, humanIndex, false);
                General aiGeneral = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[aiIndex]);
                aiGeneral.addexperience(exp / 3);
                aiGeneral.addIQExp((byte)(exp / 100));
            }
            else
            {
                if (getSkill_1(this.humanGeneralId_inWar[humanIndex], 6))
                    if (curCellCanPlan(this.humanGeneralId_inWar[humanIndex], humanIndex, aiIndex, plan, true))
                    {
                        byte su2 = planSuccessRate(this.humanGeneralId_inWar[humanIndex], this.aiGeneralId_inWar[aiIndex], plan);
                        if (MathUtils.getRandomInt(100) < su2)
                        {
                            int exp = setplanResult(this.humanGeneralId_inWar[humanIndex], this.aiGeneralId_inWar[aiIndex], aiIndex, humanIndex, true);
                            General general = GeneralListCache.GetGeneral(this.humanGeneralId_inWar[humanIndex]);
                            general.addexperience(exp / 3);
                            general.addIQExp((byte)(exp / 100));
                        }
                    }
                this.b_java_lang_String_fld = "�Ʋ�ʧ�ܣ�";
            }
            //this.gamecanvas.r_byte_fld = 100;
            void_B();
            this.j_byte_fld = 0;
        }

        byte getplan(byte aiIndex, byte humanIndex)
        {
            // ��ȡ AI ������Ϣ
            General aiGeneral = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[aiIndex]);

            // ��ȡ��ҽ�����Ϣ
            General userGeneral = GeneralListCache.GetGeneral(this.humanGeneralId_inWar[humanIndex]);

            // ��ʼ���ƻ�����
            byte[] abyte0 = new byte[16];
            byte byte1 = 0;

            // �������п��ܵļƻ�
            for (byte planIndex = 0; planIndex < aiGeneral.getGeneralPlanNum(); planIndex++)
            {
                // �ж��Ƿ����ִ�иüƻ�
                if (planNeedMoves(planIndex, this.aiGeneralId_inWar[aiIndex]) <= this.aiGeneralMoveBonus[aiIndex] && curCellCanPlan(this.aiGeneralId_inWar[aiIndex], aiIndex, humanIndex, planIndex, false))
                {
                    switch (planIndex)
                    {
                        case 0:
                        case 3:
                        case 4:
                        case 6:
                        case 7:
                        case 9:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            if (userGeneral.generalSoldier > 30)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 1:
                            if (userGeneral.getCurPhysical() > 1)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 2:
                            if (userGeneral.generalSoldier > 30 && this.humanUnitTrapped[humanIndex] == 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 5:
                        case 8:
                            if (this.humanGrain_inWar > 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 10:
                            if (this.humanUnitTrapped[humanIndex] < 6)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                    }
                }
            }

            // ����п��õļƻ�����ѡ��ɹ�����ߵ�һ��
            if (byte1 > 0)
            {
                byte su = 0;
                byte index = 0;
                for (int i = 0; i < byte1; i++)
                {
                    byte tsc = planSuccessRate(this.aiGeneralId_inWar[aiIndex], this.humanGeneralId_inWar[humanIndex], abyte0[i]);
                    if (tsc > su)
                    {
                        su = tsc;
                        index = abyte0[i];
                    }
                }
                return index;
            }

            // ���û�п��õļƻ����򷵻� 0
            return 0;
        }

        void retreat(byte aiIndex)
        {
            // ������Ϸ����״̬
            if (aiIndex == 0)
            {
                //this.gamecanvas.r_byte_fld = 5;
            }
            else
            {
                //this.gamecanvas.r_byte_fld = 3;
                void_B();
                this.j_byte_fld = 0;
                generalRetreat(this.aiGeneralId_inWar[aiIndex], getCanRetreatCityId(this.aiKingId));
            }

            // ģ���ӳ�
            System.Threading.Thread.Sleep(500);

            // ���»�����Ϸ����
            //this.gamecanvas.repaint();
        }

        bool allretreat()
        {
            // ����Ƿ����㳷������
            if (!boolean_bsi_a(curWarCityId, this.aiKingId))
                return false;

            // ����˫��ʿ������
            int i1 = GetTotalGeneralFightValInWar(this.humanGeneralId_inWar, this.humanGeneralNum_inWar, this.humanUnitTrapped);
            int j1 = GetTotalGeneralFightValInWar(this.aiGeneralId_inWar, this.aiGeneralNum_inWar, this.aiUnitTrapped);

            // ��ȡ������Ϣ
            General aiMainGeneral = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[0]);

            // ������������ڣ���������
            if (aiMainGeneral == null)
                return true;

            // �������ʿ������
            int k1 = aiMainGeneral.lead * aiMainGeneral.generalSoldier * 3 / 2;
            j1 += k1;

            // �ж��Ƿ����㳷������
            if (j1 * 3 < i1 * 2 && aiMainGeneral.generalSoldier <= 250)
                return true;

            // �����ж��Ƿ���
            return !(aiMainGeneral.generalSoldier >= 100 && (aiMainGeneral.generalSoldier >= 400 || aiMainGeneral.getCurPhysical() >= 15));
        }

        byte[] randomArray(byte[] array)
        {
            // ���������������
            System.Random random = new System.Random();

            // ������������������
            for (int i = 0; i < array.Length; i++)
            {
                int p = random.Next(array.Length);
                byte tmp = array[i];
                array[i] = array[p];
                array[p] = tmp;
            }

            // ����������������
            return array;
        }

        int[] getAroundMovesHeight(byte aiIndex)
        {
            // ��ʼ���߶�����
            int[] height = new int[4];

            // �Ϸ����ӵĸ߶�
            if (this.aiUnitCellY[aiIndex] - 1 >= 0)
            {
                height[0] = this.buildingMoveMap[this.aiUnitCellY[aiIndex] - 1,this.aiUnitCellX[aiIndex]];
            }
            else
            {
                height[0] = 0;
            }

            // �·����ӵĸ߶�
            if (this.aiUnitCellY[aiIndex] + 1 < 18)
            {
                height[1] = this.buildingMoveMap[this.aiUnitCellY[aiIndex] + 1,this.aiUnitCellX[aiIndex]];
            }
            else
            {
                height[1] = 0;
            }

            // �����ӵĸ߶�
            if (this.aiUnitCellX[aiIndex] - 1 >= 0)
            {
                height[2] = this.buildingMoveMap[this.aiUnitCellY[aiIndex],this.aiUnitCellX[aiIndex] - 1];
            }
            else
            {
                height[2] = 0;
            }

            // �Ҳ���ӵĸ߶�
            if (this.aiUnitCellX[aiIndex] + 1 < 31)
            {
                height[3] = this.buildingMoveMap[this.aiUnitCellY[aiIndex],this.aiUnitCellX[aiIndex] + 1];
            }
            else
            {
                height[3] = 0;
            }

            // ������Χ���ӵĸ߶�����
            return height;
        }

        bool isRetreat(short generalId)
        {
            // ����Ƿ����㳷������
            if (!boolean_bsi_a(curWarCityId, this.aiKingId))
                return false;

            // ��ȡ������Ϣ
            General general = GeneralListCache.GetGeneral(generalId);

            // ������첻���ڣ���������
            if (general == null)
                return false;

            // ���ʿ�������Ƿ����� 100
            return (general.generalSoldier < 100);
        }

        // ������ҹ���AI_test3
        void humanAttackAI_test3()
        {
            // �����洢 AI �佫�ĳ���״̬
            byte[] abyte0 = new byte[this.aiGeneralNum_inWar];
            // �����洢 AI �佫������״̬
            byte[] abyte2 = new byte[this.aiGeneralNum_inWar];

            // ��ʼ������AI�佫��״̬
            for (byte intdex = 0; intdex < this.aiGeneralNum_inWar; intdex++)
            {
                // ������� AI �Ƿ���
                if (allretreat())
                {
                    abyte0[intdex] = 3; // 3 ��ʾ����
                }
                else
                {
                    abyte0[intdex] = 0; // 0 ��ʾ����״̬
                }
                abyte2[intdex] = 0; // ����״̬
            }

            // �����һ�� AI �佫�Ѿ�����
            if (abyte0[0] == 3)
            {
                //this.gamecanvas.r_byte_fld = 5; // ���ó��˱�־
                void_B(); // ִ�г����߼�
                return;
            }

            // ���� AI �佫���ƶ����ж�
            for (byte aiIndex = 1; aiIndex < this.aiGeneralNum_inWar; aiIndex++)
            {
                // ����δ������ AI �佫
                if (this.aiUnitTrapped[aiIndex] <= 0 || this.aiUnitTrapped[aiIndex] >= 4)
                {
                    short generalId = this.aiGeneralId_inWar[aiIndex]; // ��ȡ AI �佫 ID

                    // ��� AI �佫���ڳ���״̬
                    if (isRetreat(generalId))
                    {
                        retreat(aiIndex); // ִ�г��˲���
                        this.aiGeneralFinshMove[aiIndex] = 1; // ����佫�Ѿ��ж����

                        // �߳�˯�ߣ�ģ��ִ�е�ʱ���ӳ�
                        try
                        {
                            Thread.Sleep(200); // 200�����ӳ�
                        }
                        catch (Exception e) { }
                    }
                }
            }

            // �߳�˯�ߣ�ģ���ӳ�
            try
            {
                Thread.Sleep(200); // 200�����ӳ�
            }
            catch (Exception e) { }

            // ���»�����Ϸ����
            //this.gamecanvas.repaint();

            // �� AI ��λ���ƶ�˳���������
            byte[] moveOrder = sortAIUnit();

            // ����ÿ���ƶ�˳��� AI ��λ
            for (byte index = 0; index < moveOrder.Length; index++)
            {
                byte b = moveOrder[index]; // ��ȡ��ǰ AI ��λ����
                this.curAIindex = b; // ��¼��ǰ AI ��λ����

                // ��� AI ��λû�б���ס����δ�ж�
                if (this.aiUnitTrapped[b] <= 0 && this.aiGeneralFinshMove[b] != 1)
                {
                    // ���⴦���һ�� AI ��λ
                    if (b == 0 && !this.AIAttackHM)
                    {
                        // ѭ������ AI ���ж�ֱ�����
                        while (this.aiGeneralFinshMove[b] == 0)
                        {
                            byte planHunmanIndex = 0; // �ƻ������������佫����
                            byte maxsu = 0; // ���ɹ���

                            // �������������佫
                            for (byte humanIndex = 0; humanIndex < this.humanGeneralNum_inWar; humanIndex++)
                            {
                                // ��������佫δ����
                                if (this.humanUnitTrapped[humanIndex] <= 0 || this.humanUnitTrapped[humanIndex] >= 4)
                                {
                                    // ��� AI �Ƿ��ڹ�����Χ��
                                    if (isInRange(this.aiUnitCellX[b], this.aiUnitCellY[b], this.humanUnitCellX[humanIndex], this.humanUnitCellY[humanIndex], 5))
                                    {
                                        // ��ȡ�ƻ��ĳɹ���
                                        byte willPlan = getplan(b, humanIndex);
                                        if (willPlan >= 0)
                                        {
                                            byte su = planSuccessRate(this.aiGeneralId_inWar[b], this.humanGeneralId_inWar[humanIndex], willPlan);

                                            // ����Ƿ�ɹ��ʴ��ڵ�ǰ���ֵ
                                            if ((su > 15 || b == 0) && su > maxsu)
                                            {
                                                maxsu = su; // �������ɹ���
                                                planHunmanIndex = humanIndex; // ��¼�ƻ������������佫����
                                            }
                                        }
                                    }
                                }
                            }

                            // ����ҵ��ƻ������Ķ���ִ�мƻ�
                            if (planHunmanIndex > 0)
                            {
                                plan(b, planHunmanIndex);
                                try
                                {
                                    Thread.Sleep(200); // �ӳ�ģ��
                                }
                                catch (Exception e) {}
                                continue;
                            }

                            // ���û���ҵ��ƻ������ AI �ж����
                            this.aiGeneralFinshMove[b] = 1;
                        }
                    }
                    // �����������ƶ����� AI ��λ
                    else if (this.aiGeneralHaveMove[b] == 1)
                    {
                        // ��鲢���� AI ���ƶ��ͼƻ�
                        while (this.aiGeneralFinshMove[b] == 0)
                        {
                            byte planHunmanIndex = 0;
                            byte maxsu = 0;

                            // �������������佫��Ѱ�ҿ��еļƻ�
                            for (byte humanIndex = 0; humanIndex < this.humanGeneralNum_inWar; humanIndex++)
                            {
                                if (this.humanUnitTrapped[humanIndex] <= 0 || this.humanUnitTrapped[humanIndex] >= 4)
                                {
                                    if (isInRange(this.aiUnitCellX[b], this.aiUnitCellY[b], this.humanUnitCellX[humanIndex], this.humanUnitCellY[humanIndex], 5))
                                    {
                                        byte willPlan = getUsePlan(b, humanIndex);
                                        if (willPlan >= 0)
                                        {
                                            byte su = planSuccessRate(this.aiGeneralId_inWar[b], this.humanGeneralId_inWar[humanIndex], willPlan);
                                            if (su > 35 && su > maxsu)
                                            {
                                                maxsu = su;
                                                planHunmanIndex = humanIndex;
                                            }
                                        }
                                    }
                                }
                            }

                            // ִ�мƻ�
                            if (planHunmanIndex > 0)
                            {
                                plan(b, planHunmanIndex);
                                try
                                {
                                    Thread.Sleep(200); // �ӳ�ģ��
                                }
                                catch (Exception e) { }
                                continue;
                            }

                            // ���δ�ҵ����ʼƻ�������ж�
                            this.aiGeneralFinshMove[b] = 1;
                        }
                    }
                }
            }
        }


        byte[] sortAIUnit()
        {
            // ��ʼ������
            byte[] array = new byte[this.aiGeneralNum_inWar];
            short[] moveNum = new short[this.aiGeneralNum_inWar];

            // ����ÿ�� AI ����
            for (byte aiIndex = 0; aiIndex < this.aiGeneralNum_inWar; aiIndex = (byte)(aiIndex + 1))
            {
                // ��ʼ���ƶ���Χ��Ŀ���ƶ���ͼ
                byte[,] moveRange = new byte[19, 32];
                byte[,] tarMoveMap = new byte[19, 32];

                // ��ȡĿ���ƶ���ͼ
                getMoveMap3(tarMoveMap, this.humanUnitCellY[0], this.humanUnitCellX[0], 90, 0, this.aiGeneralId_inWar[aiIndex], (byte)1, false);

                // ����������ȡ�ƶ���Χ
                if (aiIndex == 0 && this.day <= 3)
                {
                    getMoveMap2(moveRange, this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex], this.aiGeneralMoveBonus[aiIndex] - 10, 0, this.aiGeneralId_inWar[aiIndex], false);
                }
                else
                {
                    getMoveMap2(moveRange, this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex], this.aiGeneralMoveBonus[aiIndex], 0, this.aiGeneralId_inWar[aiIndex], false);
                }

                // �����ƶ���ֵ
                for (int i = 0; i < 19; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        if (moveRange[i, j] > 0)
                        {
                            if (aiIndex == 0 && tarMoveMap[i, j] >= 86)
                            {
                                moveNum[aiIndex] = (short)(moveNum[aiIndex] + tarMoveMap[i, j] * 2 / 3);
                            }
                            else
                            {
                                moveNum[aiIndex] = (short)(moveNum[aiIndex] + tarMoveMap[i, j]);
                            }
                        }
                    }
                }

                // ���⴦���һ�� AI ����
                if (aiIndex == 0)
                    moveNum[aiIndex] = 0;
            }

            // ����ͨ�ù������������
            array = CommonUtils.Xhpx(moveNum);

            // ��������������
            return array;
        }

        public void moveUnit(byte aiIndex, int x, int y)
        {
            // ģ���ӳ�
            System.Threading.Thread.Sleep(50);

            // ������Ҫ���ƶ�����
            byte needMoves = (byte)getCellNeedMoves(this.bigWar_coordinate[y, x], this.aiGeneralId_inWar[aiIndex]);

            // �����ƶ�ʣ�����
            this.aiGeneralMoveBonus[aiIndex] = (byte)(this.aiGeneralMoveBonus[aiIndex] - needMoves);

            // ���µ�ǰ�����״̬
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] & 0x3F);
            this.aiUnitCellX[aiIndex] = (byte)x;
            this.aiUnitCellY[aiIndex] = (byte)y;
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] | 0x80);

            // ˢ�½���
            //this.gamecanvas.repaint();

            // �ٴ�ģ���ӳ�
            System.Threading.Thread.Sleep(50);

            // ���������¼�
            if ((this.bigWar_coordinate[y, x] & 0x20) != 0)
            {
                this.aiUnitTrapped[aiIndex] = 17;
                this.b_java_lang_String_fld = "�м�ı���Ŷݼ�";
                //this.gamecanvas.r_byte_fld = 100;
                void_B();
                this.j_byte_fld = 0;
                this.aiGeneralFinshMove[aiIndex] = 1;
            }
        }

        public System.Collections.Generic.List<short[]> getPathToCell(int curCellX, int curCellY, int destCellX, int destCellY)
        {
            // ��ʼ��·���б�
            System.Collections.Generic.List<short[]> returnPath = null;

            // ��ǰĿ������
            short[] thisCell = { (short)destCellX, (short)destCellY };

            // �����ǰλ�þ���Ŀ��λ��
            if (curCellX == destCellX && curCellY == destCellY)
            {
                returnPath = new System.Collections.Generic.List<short[]>();
                returnPath.Add(thisCell);
                return returnPath;
            }

            // ��ʼ�������ϵ�ֵ
            int upVal = 0, downVal = 0, leftVal = 0, rightVal = 0;

            // �����Ϸ���ֵ
            if (destCellY > 0)
                upVal = this.curGeneralMoveMap[destCellY - 1, destCellX];

            // �����·���ֵ
            if (destCellY < this.rows - 1)
                downVal = this.curGeneralMoveMap[destCellY + 1, destCellX];

            // ��������ֵ
            if (destCellX > 0)
                leftVal = this.curGeneralMoveMap[destCellY, destCellX - 1];

            // �����Ҳ��ֵ
            if (destCellX < this.cols - 1)
                rightVal = this.curGeneralMoveMap[destCellY, destCellX + 1];

            // �ҳ����ֵ�ķ���
            int maxVal = System.Math.Max(System.Math.Max(upVal, downVal), System.Math.Max(leftVal, rightVal));

            // �������ֵ�ķ���ݹ����·��
            if (maxVal == upVal)
            {
                returnPath = getPathToCell(curCellX, curCellY, destCellX, destCellY - 1);
            }
            else if (maxVal == downVal)
            {
                returnPath = getPathToCell(curCellX, curCellY, destCellX, destCellY + 1);
            }
            else if (maxVal == leftVal)
            {
                returnPath = getPathToCell(curCellX, curCellY, destCellX - 1, destCellY);
            }
            else if (maxVal == rightVal)
            {
                returnPath = getPathToCell(curCellX, curCellY, destCellX + 1, destCellY);
            }

            // ��ӵ�ǰ���굽·���б�
            returnPath.Add(thisCell);

            // ����·���б�
            return returnPath;
        }

        public bool getMoveMap2(byte[,] moveMap, int curCellX, int curCellY, int movesLeft, int ignoreDir, short unitType, bool returnWhenMovable)
        {
            // �����ƶ���ͼ�е��ƶ�����
            if (movesLeft > moveMap[curCellX, curCellY] - 1)
            {
                moveMap[curCellX, curCellY] = (byte)(movesLeft + 1);
            }
            else
            {
                return false;
            }

            // ����̽��
            if (ignoreDir != 1)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX, curCellY - 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap2(moveMap, curCellX, curCellY - 1, newMovesLeft, 2, unitType, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // ����̽��
            if (ignoreDir != 2)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX, curCellY + 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap2(moveMap, curCellX, curCellY + 1, newMovesLeft, 1, unitType, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // ����̽��
            if (ignoreDir != 4)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX - 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap2(moveMap, curCellX - 1, curCellY, newMovesLeft, 8, unitType, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // ����̽��
            if (ignoreDir != 8)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX + 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap2(moveMap, curCellX + 1, curCellY, newMovesLeft, 4, unitType, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            return false;
        }

        byte getAIThinkPlan(byte aiIndex, byte humanIndex, byte moves, byte willX, byte willY)
        {
            // ��ȡ AI ������Ϣ
            General aiGeneral = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[aiIndex]);

            // ��ȡ��ҽ�����Ϣ
            General userGeneral = GeneralListCache.GetGeneral(this.humanGeneralId_inWar[humanIndex]);

            // ��ʼ���ƻ�����
            byte planNum = aiGeneral.getGeneralPlanNum();

            // ��ʼ���ƻ�����
            byte[] abyte0 = new byte[16];
            byte byte1 = 0;

            // ����ԭʼ����
            byte OriginalX = this.aiUnitCellX[aiIndex];
            byte OriginalY = this.aiUnitCellY[aiIndex];

            // ��������״̬
            this.aiUnitCellX[aiIndex] = willX;
            this.aiUnitCellY[aiIndex] = willY;
            this.bigWar_coordinate[OriginalY, OriginalX] = (byte)(this.bigWar_coordinate[OriginalY, OriginalX] & 0x3F);
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] | 0x80);

            // �������мƻ�
            for (byte planIndex = 0; planIndex < planNum; planIndex = (byte)(planIndex + 1))
            {
                // ����Ƿ������ƶ�����
                if (planNeedMoves(planIndex, this.aiGeneralId_inWar[aiIndex]) <= moves && curCellCanPlan(this.aiGeneralId_inWar[aiIndex], aiIndex, humanIndex, planIndex, false))
                {
                    // ���ݲ�ͬ�ļƻ�����ѡ����ʵļƻ�
                    switch (planIndex)
                    {
                        case 0:
                        case 3:
                        case 4:
                        case 6:
                        case 7:
                        case 9:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            if (userGeneral.generalSoldier > 30)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 1:
                            if (userGeneral.getCurPhysical() > 1)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 2:
                            if (userGeneral.generalSoldier > 30 && this.humanUnitTrapped[humanIndex] == 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 5:
                        case 8:
                            if (this.humanGrain_inWar > 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 10:
                            if (this.humanUnitTrapped[humanIndex] < 6)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                    }
                }
            }

            // �ָ�ԭʼ����״̬
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] & 0x3F);
            this.aiUnitCellX[aiIndex] = OriginalX;
            this.aiUnitCellY[aiIndex] = OriginalY;
            this.bigWar_coordinate[OriginalY, OriginalX] = (byte)(this.bigWar_coordinate[OriginalY, OriginalX] | 0x80);

            // ����п��õļƻ�
            if (byte1 > 0)
            {
                byte minsu = 35;
                byte num = 0;
                byte[] wellplan = new byte[byte1];
                for (int i = 0; i < wellplan.Length; i++)
                    wellplan[i] = 0;

                // ɸѡ�ɹ��ʽϸߵļƻ�
                for (int i = 0; i < byte1; i++)
                {
                    byte tsc = planSuccessRate(this.aiGeneralId_inWar[aiIndex], this.humanGeneralId_inWar[humanIndex], abyte0[i]);
                    if (tsc > minsu)
                    {
                        wellplan[num] = abyte0[i];
                        num = (byte)(num + 1);
                    }
                }

                byte tsh = 0;
                // �����ƻ���ֵ
                for (int j = 0; j < wellplan.Length; j++)
                {
                    byte sh = 0;
                    switch (wellplan[j])
                    {
                        case 0:
                        case 3:
                        case 4:
                            sh = 3;
                            break;
                        case 1:
                            sh = 1;
                            break;
                        case 2:
                            if (userGeneral.generalSoldier > 1400)
                            {
                                sh = 4;
                                break;
                            }
                            sh = 2;
                            break;
                        case 6:
                        case 7:
                        case 9:
                            sh = 6;
                            break;
                        case 5:
                        case 8:
                            sh = 10;
                            break;
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            sh = 8;
                            break;
                    }
                    if (sh > tsh)
                        tsh = sh;
                }

                return tsh;
            }

            // ���û�п��õļƻ�
            return 0;
        }

        byte getHMThinkPlan(byte humanIndex, byte aiIndex, byte moves, byte willX, byte willY)
        {
            // ��ȡ��ҽ���ID
            short humanGeneralId = this.humanGeneralId_inWar[humanIndex];

            // ��ȡ��ҽ�����Ϣ
            General general = GeneralListCache.GetGeneral(humanGeneralId);

            // ��ʼ���ƻ�����
            byte planNum = general.getGeneralPlanNum();

            // ��ʼ���ƻ�����
            byte[] abyte0 = new byte[16];
            byte byte1 = 0;

            // ����ԭʼ����
            byte OriginalX = this.aiUnitCellX[aiIndex];
            byte OriginalY = this.aiUnitCellY[aiIndex];

            // ��������״̬
            this.aiUnitCellX[aiIndex] = willX;
            this.aiUnitCellY[aiIndex] = willY;
            this.bigWar_coordinate[OriginalY, OriginalX] = (byte)(this.bigWar_coordinate[OriginalY, OriginalX] & 0x3F);
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] | 0x80);

            // �������мƻ�
            for (byte planIndex = 0; planIndex < planNum; planIndex = (byte)(planIndex + 1))
            {
                // ����Ƿ������ƶ�����
                if (planNeedMoves(planIndex, humanGeneralId) <= moves && curCellCanPlan(humanGeneralId, humanIndex, aiIndex, planIndex, true))
                {
                    // ���ݲ�ͬ�ļƻ�����ѡ����ʵļƻ�
                    switch (planIndex)
                    {
                        case 0:
                        case 3:
                        case 4:
                        case 6:
                        case 7:
                        case 9:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            if (general.generalSoldier > 30)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 1:
                            if (general.getCurPhysical() > 1)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 2:
                            if (general.generalSoldier > 1 && this.aiUnitTrapped[humanIndex] == 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 5:
                        case 8:
                            if (this.aiGrain_inWar > 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 10:
                            if (this.aiUnitTrapped[humanIndex] < 6)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                    }
                }
            }

            // �ָ�ԭʼ����״̬
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] & 0x3F);
            this.aiUnitCellX[aiIndex] = OriginalX;
            this.aiUnitCellY[aiIndex] = OriginalY;
            this.bigWar_coordinate[OriginalY, OriginalX] = (byte)(this.bigWar_coordinate[OriginalY, OriginalX] | 0x80);

            // ����п��õļƻ�
            if (byte1 > 0)
            {
                byte su = 40;
                byte index = 0;
                byte[] planwell = new byte[byte1];
                for (int i = 0; i < planwell.Length; i++)
                    planwell[i] = 0;

                // ɸѡ�ɹ��ʽϸߵļƻ�
                for (int i = 0; i < byte1; i++)
                {
                    byte tsc = planSuccessRate(humanGeneralId, this.aiGeneralId_inWar[aiIndex], abyte0[i]);
                    if (tsc > su)
                    {
                        planwell[index] = abyte0[i];
                        index = (byte)(index + 1);
                    }
                }

                byte tsh = 0;
                // �����ƻ���ֵ
                for (int j = 0; j < planwell.Length; j++)
                {
                    byte sh = 0;
                    switch (planwell[j])
                    {
                        case 0:
                        case 1:
                        case 4:
                            sh = 1;
                            break;
                        case 2:
                        case 3:
                            sh = 3;
                            break;
                        case 6:
                        case 7:
                        case 9:
                            sh = 4;
                            break;
                        case 5:
                        case 8:
                            sh = 10;
                            break;
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            sh = 7;
                            break;
                    }
                    if (sh > tsh)
                        tsh = sh;
                }

                return tsh;
            }

            // ���û�п��õļƻ�
            return 0;
        }

        public bool getMoveMap3(byte[,] moveMap, int curCellX, int curCellY, int movesLeft, int ignoreDir, short unitType, byte unitSide, bool returnWhenMovable)
        {
            // ���ʣ���ƶ��������ڵ�ǰ���ӵ��ƶ�����������¸��ӵ��ƶ�����
            if (movesLeft > moveMap[curCellX, curCellY])
            {
                moveMap[curCellX, curCellY] = (byte)movesLeft;
            }
            else
            {
                return false;
            }

            // ������Է������򱱣��������ƶ�
            if (ignoreDir != 1)
            {
                int newMovesLeft = movesLeft - movesNeededForCell3(curCellX, curCellY - 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap3(moveMap, curCellX, curCellY - 1, newMovesLeft, 2, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // ������Է������򶫣��������ƶ�
            if (ignoreDir != 2)
            {
                int newMovesLeft = movesLeft - movesNeededForCell3(curCellX, curCellY + 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap3(moveMap, curCellX, curCellY + 1, newMovesLeft, 1, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // ������Է��������������������ƶ�
            if (ignoreDir != 4)
            {
                int newMovesLeft = movesLeft - movesNeededForCell3(curCellX - 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap3(moveMap, curCellX - 1, curCellY, newMovesLeft, 8, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // ������Է��������ϣ����������ƶ�
            if (ignoreDir != 8)
            {
                int newMovesLeft = movesLeft - movesNeededForCell3(curCellX + 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap3(moveMap, curCellX + 1, curCellY, newMovesLeft, 4, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            return false;
        }

        public int movesNeededForCell3(int cellX, int cellY, short genId)
        {
            // ��������Ƿ���Ч
            if (cellX >= 0 && cellY >= 0 && cellX < 19 && cellY < 32)
            {
                // ��ȡ��������
                byte terrain = (byte)(this.bigWar_coordinate[cellX, cellY] & 0x1F);
                byte movesNeed = 0;

                // ���ݵ������ͼ���������ƶ�����
                switch (terrain)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 5:
                    case 6:
                    case 7:
                        movesNeed = 2;
                        break;
                    case 4:
                        General general = GeneralListCache.GetGeneral(genId);
                        if (general == null)
                            return 10000;
                        switch (general.army[0])
                        {
                            case 0:
                            case 1:
                                movesNeed = 3;
                                break;
                            case 2:
                            case 3:
                                movesNeed = 2;
                                break;
                        }
                        break;
                    case 12:
                        general = GeneralListCache.GetGeneral(genId);
                        if (general == null)
                            return 10000;
                        switch (general.army[1])
                        {
                            case 0:
                                movesNeed = 6;
                                break;
                            case 1:
                                movesNeed = 5;
                                break;
                            case 2:
                                movesNeed = 4;
                                break;
                            case 3:
                                movesNeed = 3;
                                break;
                        }
                        if (getSkill_3(genId, 5))
                            movesNeed = (byte)(movesNeed - 1);
                        break;
                    case 10:
                        movesNeed = 5;
                        if (getSkill_3(genId, 5))
                            movesNeed = (byte)(movesNeed - 1);
                        break;
                    case 11:
                        movesNeed = 6;
                        if (getSkill_3(genId, 5))
                            movesNeed = (byte)(movesNeed - 1);
                        break;
                    case 9:
                        general = GeneralListCache.GetGeneral(genId);
                        if (general == null)
                            return 10000;
                        switch (general.army[2])
                        {
                            case 0:
                                movesNeed = 6;
                                break;
                            case 1:
                                movesNeed = 5;
                                break;
                            case 2:
                                movesNeed = 4;
                                break;
                            case 3:
                                movesNeed = 3;
                                break;
                        }
                        break;
                    case 8:
                        movesNeed = 6;
                        break;
                    case 13:
                        movesNeed = 120;
                        break;
                    default:
                        movesNeed = 120;
                        break;
                }

                return movesNeed;
            }

            // ���������Ч���򷵻�һ����ֵ
            return 10000;
        }

        public byte getUsePlan(byte aiIndex, byte humanIndex)
        {
            // ��ȡ AI ������Ϣ
            General aiGeneral = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[aiIndex]);
            // ��ȡ AI ������õļƲ�����
            byte planNum = aiGeneral.getGeneralPlanNum();
            // ��ȡ��ҽ�����Ϣ
            General userGeneral = GeneralListCache.GetGeneral(this.humanGeneralId_inWar[humanIndex]);
            // ��ʼ���Ʋ�����
            byte[] abyte0 = new byte[16];
            byte byte1 = 0;

            // �������п��õļƲ�
            for (byte planIndex = 0; planIndex < planNum; planIndex++)
            {
                // �жϵ�ǰ�Ʋ��Ƿ����
                if (planNeedMoves(planIndex, this.aiGeneralId_inWar[aiIndex]) <= this.aiGeneralMoveBonus[aiIndex] &&
                    curCellCanPlan(this.aiGeneralId_inWar[aiIndex], aiIndex, humanIndex, planIndex, false))
                {
                    // ���ݲ�ͬ�ļƲ�����ѡ����ʵļƲ�
                    switch (planIndex)
                    {
                        case 0:
                        case 3:
                        case 4:
                        case 6:
                        case 7:
                        case 9:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            if (userGeneral.generalSoldier > 30)
                            {
                                abyte0[byte1] = planIndex;
                                byte1++;
                            }
                            break;
                        case 1:
                            if (userGeneral.getCurPhysical() > 1)
                            {
                                abyte0[byte1] = planIndex;
                                byte1++;
                            }
                            break;
                        case 2:
                            if (userGeneral.generalSoldier > 30 && this.humanUnitTrapped[humanIndex] == 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1++;
                            }
                            break;
                        case 5:
                        case 8:
                            if (this.humanGrain_inWar > 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1++;
                            }
                            break;
                        case 10:
                            if (this.humanUnitTrapped[humanIndex] < 6)
                            {
                                abyte0[byte1] = planIndex;
                                byte1++;
                            }
                            break;
                    }
                }
            }

            // ����ҵ�������һ�����õļƲ�
            if (byte1 > 0)
            {
                byte minsu = 35;
                byte num = 0;
                byte[] wellplan = new byte[byte1];

                // ��ʼ����ѼƲ�����
                for (int i = 0; i < wellplan.Length; i++)
                    wellplan[i] = 0;

                // �������п��еļƲߣ��ҵ��ɹ��ʸ�����ֵ�ļƲ�
                for (int i = 0; i < byte1; i++)
                {
                    byte tsc = planSuccessRate(this.aiGeneralId_inWar[aiIndex], this.humanGeneralId_inWar[humanIndex], abyte0[i]);
                    if (tsc > minsu)
                    {
                        wellplan[num] = abyte0[i];
                        num++;
                    }
                }

                // ��ʼ����ѼƲ�����
                byte index = 0;
                byte tsh = 0;

                // �������гɹ��ʽϸߵļƲߣ�ѡ����ѼƲ�
                for (int j = 0; j < wellplan.Length; j++)
                {
                    byte sh = 0;
                    switch (wellplan[j])
                    {
                        case 0:
                        case 3:
                        case 4:
                            sh = 3;
                            break;
                        case 1:
                            sh = 1;
                            break;
                        case 2:
                            if (userGeneral.generalSoldier > 1400)
                            {
                                sh = 4;
                            }
                            else
                            {
                                sh = 2;
                            }
                            break;
                        case 6:
                        case 7:
                        case 9:
                            sh = 6;
                            break;
                        case 5:
                        case 8:
                            sh = 10;
                            break;
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            sh = 8;
                            break;
                    }
                    if (sh > tsh)
                    {
                        tsh = sh;
                        index = wellplan[j];
                    }
                }

                // ������ѼƲ�����
                return index;
            }

            // ���û���ҵ��κο��õļƲߣ��򷵻� 0
            return 0;
        }

        // ����: byte_s1b1b_a
        public byte byte_s1b1b_a(short[] aword0, byte[] abyte0, byte byte0)
        {
            int i1 = 0;
            for (int j1 = 1; j1 < 64; j1++)
            {
                if ((aword0[j1] & 0x100) == 0 && aword0[j1] < aword0[i1])
                    i1 = j1;
            }
            return (byte)i1;
        }

        // ����: boolean_b_b
        public bool boolean_b_b(byte byte0)
        {
            if ((this.bigWar_coordinate[this.aiUnitCellY[byte0],this.aiUnitCellX[byte0]] & 0xF) == 8)
            {
                this.bxct = true;
                //this.gamecanvas.r_byte_fld = 21;
                void_B();
                return true;
            }
            return false;
        }

        // ����: getSequence
        public static int[] getSequence(int no)
        {
            int[] sequence = new int[no];
            for (int i = 0; i < no; i++)
                sequence[i] = i;
            System.Random random = new System.Random();
            for (int j = 0; j < no; j++)
            {
                int p = random.Next(no);
                int tmp = sequence[j];
                sequence[j] = sequence[p];
                sequence[p] = tmp;
            }
            random = null;
            return sequence;
        }

        // ����: setAIMoveBonus
        public void setAIMoveBonus()
        {
            this.aiGeneralFinshMove = new byte[this.aiGeneralNum_inWar];
            this.aiGeneralMoveBonus = new byte[this.aiGeneralNum_inWar];
            this.aiGeneralHaveMove = new byte[this.aiGeneralNum_inWar];
            for (int i = 0; i < this.aiGeneralNum_inWar; i++)
            {
                this.aiGeneralFinshMove[i] = 0;
                this.aiGeneralHaveMove[i] = 0;
                General general = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[i]);
                if (general != null)
                {
                    int bl = general.generalSoldier / 300;
                    switch (bl)
                    {
                        case 9:
                        case 10:
                            this.aiGeneralMoveBonus[i] = 20;
                            break;
                        case 7:
                        case 8:
                            this.aiGeneralMoveBonus[i] = 18;
                            break;
                        case 6:
                            this.aiGeneralMoveBonus[i] = 16;
                            break;
                        case 5:
                            this.aiGeneralMoveBonus[i] = 15;
                            break;
                        case 3:
                        case 4:
                            this.aiGeneralMoveBonus[i] = 14;
                            break;
                        case 2:
                            this.aiGeneralMoveBonus[i] = 12;
                            break;
                        case 0:
                        case 1:
                            this.aiGeneralMoveBonus[i] = 10;
                            break;
                    }
                }
            }
        }

        // ����: setHunmanMoveBonus
        public void setHunmanMoveBonus()
        {
            this.humanGeneralFinshMove = new byte[this.humanGeneralNum_inWar];
            this.humanGeneralMoveBonus = new byte[this.humanGeneralNum_inWar];
            for (int i = 0; i < this.humanGeneralNum_inWar; i++)
            {
                this.humanGeneralFinshMove[i] = 0;
                General general = GeneralListCache.GetGeneral(this.humanGeneralId_inWar[i]);
                if (general != null)
                {
                    int bl = general.generalSoldier / 300;
                    switch (bl)
                    {
                        case 9:
                        case 10:
                            this.humanGeneralMoveBonus[i] = 20;
                            break;
                        case 7:
                        case 8:
                            this.humanGeneralMoveBonus[i] = 18;
                            break;
                        case 6:
                            this.humanGeneralMoveBonus[i] = 16;
                            break;
                        case 5:
                            this.humanGeneralMoveBonus[i] = 15;
                            break;
                        case 4:
                            this.humanGeneralMoveBonus[i] = 14;
                            break;
                        case 3:
                            this.humanGeneralMoveBonus[i] = 12;
                            break;
                        case 2:
                            this.humanGeneralMoveBonus[i] = 10;
                            break;
                        case 1:
                            this.humanGeneralMoveBonus[i] = 8;
                            break;
                        case 0:
                            this.humanGeneralMoveBonus[i] = 7;
                            break;
                    }
                }
            }
        }

        // ����: execThreaten
        private void execThreaten(short[] generalIdArray, byte generalNum, byte[] unitTrapped, short[] otherGeneralIdArray, byte otherGeneralNum, byte[] otherUnitTrapped)
        {
            for (int i = 0; i < generalNum; i++)
            {
                if (unitTrapped[i] <= 0 || unitTrapped[i] >= 4)
                {
                    short generalId = generalIdArray[i];
                    if (getSkill_5(generalId, 2))
                    {
                        General general = GeneralListCache.GetGeneral(generalId);
                        if (general != null && general.generalSoldier >= 300)
                            for (int j = 1; j < otherGeneralNum; j++)
                            {
                                int hurt = general.generalSoldier / 30;
                                if (otherUnitTrapped[j] <= 0 || otherUnitTrapped[j] >= 4)
                                {
                                    short otherGeneralId = otherGeneralIdArray[j];
                                    General otherGeneral = GeneralListCache.GetGeneral(otherGeneralId);
                                    if (otherGeneral != null && otherGeneral.generalSoldier >= 600 && general.force >= otherGeneral.force && MathUtils.getRandomInt(100) <= 50)
                                    {
                                        hurt += MathUtils.getRandomInt(general.force);
                                        otherGeneral.generalSoldier = (short)(otherGeneral.generalSoldier - hurt);
                                        System.Console.WriteLine(String.Format("{0}��{1}�������ţ�����ʿ��{2}", general.generalName, otherGeneral.generalName, hurt));
                                        general.addexperience((int)(hurt * 1.2D));
                                    }
                                }
                            }
                    }
                }
            }
        }

        // ����: void_I
        void void_I()
        {
            while (true)
            {
                if (this.j_byte_fld == 0)
                {
                    this.i_boolean_fld = true;
                    this.day = (byte)(this.day + 1);
                    this.g_boolean_fld = true;
                    execThreaten(this.aiGeneralId_inWar, this.aiGeneralNum_inWar, this.aiUnitTrapped, this.humanGeneralId_inWar, this.humanGeneralNum_inWar, this.humanUnitTrapped);
                    execThreaten(this.humanGeneralId_inWar, this.humanGeneralNum_inWar, this.humanUnitTrapped, this.aiGeneralId_inWar, this.aiGeneralNum_inWar, this.aiUnitTrapped);
                    if (this.day > 1)
                        setHunmanMoveBonus();
                    void_B();
                }
                else if (this.j_byte_fld == 2 || this.j_byte_fld == 5 || this.j_byte_fld == 6)
                {
                    this.j_byte_fld = 0;
                    void_B();
                }
                if (this.j_byte_fld == 1)
                {
                    this.j_byte_fld = 0;
                    void_s1bb1_a(this.humanGeneralId_inWar, this.humanGeneralNum_inWar, this.humanUnitTrapped);
                    setAIMoveBonus();
                    this.g_boolean_fld = false;
                    this.i_boolean_fld = false;
                    this.O_byte_fld = 0;
                }
                else
                {
                    if (this.j_byte_fld == 2 || this.j_byte_fld == 4 || this.j_byte_fld == 5 || this.j_byte_fld == 6)
                        break;
                    if (this.j_byte_fld == 3)
                        this.j_byte_fld = 0;
                }
                humanAttackAI_test3();
                if (this.j_byte_fld == 3)
                    break;
                void_s1bb1_a(this.aiGeneralId_inWar, this.aiGeneralNum_inWar, this.aiUnitTrapped);
                this.humanGrain_inWar = (short)(this.humanGrain_inWar - (getAllSoldierCountInWar(this.humanGeneralId_inWar, this.humanGeneralNum_inWar, this.humanUnitTrapped) - 1) / 250 + 1);
                if (this.humanGrain_inWar <= 0)
                {
                    this.bxct = true;
                    this.humanGrain_inWar = 0;
                    //this.gamecanvas.r_byte_fld = 7;
                    void_B();
                    break;
                }
                this.aiGrain_inWar = (short)(this.aiGrain_inWar - (getAllSoldierCountInWar(this.aiGeneralId_inWar, this.aiGeneralNum_inWar, this.aiUnitTrapped) - 1) / 250 + 1);
                if (this.aiGrain_inWar <= 0)
                {
                    this.aiGrain_inWar = 0;
                    //this.gamecanvas.r_byte_fld = 6;
                }
                if (this.day == 30)
                {
                    if (!this.AIAttackHM)
                    {
                        //this.gamecanvas.r_byte_fld = 20;
                        this.bxct = true;
                        void_B();
                        break;
                    }
                    //this.gamecanvas.r_byte_fld = 22;
                    //this.gamecanvas.r_byte_fld = 5;
                    void_B();
                }
            }
        }

        // ����: void_J
        void void_J()
        {
            this.DJ = false;
            this.AIJH = false;
            this.HMJH = false;
            this.moniSd1 = (GeneralListCache.GetGeneral(this.HMGeneralId)).generalSoldier;
            this.moniSd2 = (GeneralListCache.GetGeneral(this.AIGeneralId)).generalSoldier;
            if (this.moniSd1 == 0)
                this.DJ = true;

            // ��� AI �����Ƿ��н�������
            for (int i = 0; i < this.aiGeneralNum_inWar; i++)
            {
                if (getSkill_3(this.aiGeneralId_inWar[i], 8))
                    if (this.AIGeneralId != this.aiGeneralId_inWar[i] && this.aiUnitTrapped[i] == 0)
                    {
                        int dx = Math.Abs(this.aiUnitCellX[i] - this.aiUnitCellX[this.aibettleIndex]);
                        int dy = Math.Abs(this.aiUnitCellY[i] - this.aiUnitCellY[this.aibettleIndex]);
                        if (dx <= 3 && dy <= 3)
                        {
                            this.AIJH = true;
                            break;
                        }
                    }
            }

            // ���������ҽ����Ƿ��н�������
            for (int i = 0; i < this.humanGeneralNum_inWar; i++)
            {
                if (getSkill_3(this.humanGeneralId_inWar[i], 8) && this.HMGeneralId != this.humanGeneralId_inWar[i] && this.humanUnitTrapped[i] == 0)
                {
                    int dx = Math.Abs(this.humanUnitCellX[i] - this.humanUnitCellX[this.hmbattleIndex]);
                    int dy = Math.Abs(this.humanUnitCellY[i] - this.humanUnitCellY[this.hmbattleIndex]);
                    if (dx <= 3 && dy <= 3)
                    {
                        this.HMJH = true;
                        break;
                    }
                }
            }

            this.j_boolean_fld = false;
            if ((GeneralListCache.GetGeneral(this.HMGeneralId)).generalSoldier == 0)
            {
                this.humanSmallSoldierNum = 1;
            }
            else
            {
                this.humanSmallSoldierNum = (byte)(((GeneralListCache.GetGeneral(this.HMGeneralId)).generalSoldier - 1) / 300 + 2);
            }

            if ((GeneralListCache.GetGeneral(this.AIGeneralId)).generalSoldier == 0)
            {
                this.aiSmallSoldierNum = 1;
            }
            else
            {
                this.aiSmallSoldierNum = (byte)(((GeneralListCache.GetGeneral(this.AIGeneralId)).generalSoldier - 1) / 300 + 2);
            }

            // ��ʼ��С��ͼ��������
            for (byte byte0 = 0; byte0 < this.T_byte_fld; byte0 = (byte)(byte0 + 1))
            {
                for (byte byte6 = 0; byte6 < this.U; byte6 = (byte)(byte6 + 1))
                    this.smallWarCoordinate[byte6][byte0] = 0;
            }

            // ��ʼ�� P_byte_array1d_fld ����
            for (byte byte1 = 0; byte1 < 4; byte1 = (byte)(byte1 + 1))
                this.P_byte_array1d_fld[byte1] = 0;

            // ���ݵ������óǱ�����
            if (this.warTerrain == 8)
            {
                if (this.i_boolean_fld)
                {
                    byte[,] aiCastle = new byte[7, 16];
                    string name = "/formation/ac.exp";
                    byte[] formationDat = formationArray(name);
                    aiCastle = getFormationArray(formationDat,aiCastle);
                    for (int celly = 0; celly < 7; celly++)
                    {
                        for (int cellx = 0; cellx < 16; cellx++)
                        {
                            if (aiCastle[celly,cellx] > 1)
                                switch (aiCastle[celly, cellx])
                                {
                                    case 2:
                                        this.smallWarCoordinate[celly][cellx] = 32;
                                        break;
                                    case 3:
                                        this.smallWarCoordinate[celly][cellx] = 16;
                                        break;
                                    case 4:
                                        this.smallWarCoordinate[celly][cellx] = 2;
                                        break;
                                }
                        }
                    }
                }
                else
                {
                    byte[,] hmCastle = new byte[7, 16];
                    string name = "/formation/hc.exp";
                    byte[] formationDat = formationArray(name);
                    hmCastle = getFormationArray(formationDat,hmCastle);
                    for (int celly = 0; celly < 7; celly++)
                    {
                        for (int cellx = 0; cellx < 16; cellx++)
                        {
                            if (hmCastle[celly,cellx] > 1)
                                switch (hmCastle[celly,cellx])
                                {
                                    case 2:
                                        this.smallWarCoordinate[celly][cellx] = 32;
                                        break;
                                    case 3:
                                        this.smallWarCoordinate[celly][cellx] = 16;
                                        break;
                                    case 4:
                                        this.smallWarCoordinate[celly][cellx] = 2;
                                        break;
                                }
                        }
                    }
                    for (byte byte4 = 0; byte4 < 4; byte4 = (byte)(byte4 + 1))
                        this.P_byte_array1d_fld[byte4] = 1;
                }
                this.j_boolean_fld = true;
            }

            void_m();
            this.Z = 0;
            this.aa = 0;
            this.ab = 0;
            this.ac = 0;
            this.ad = 0;
            this.ae = 0;
            this.ag = 0;
            this.ah = 0;
            this.jsbl = 0;
            this.k_boolean_fld = false;

            // ��ʼ�� x_short_array1d_fld �� y_short_array1d_fld
            for (byte byte5 = 0; byte5 < 4; byte5 = (byte)(byte5 + 1))
            {
                this.x_short_array1d_fld[byte5] = 0;
                this.y_short_array1d_fld[byte5] = 0;
            }

            //this.gamecanvas.s_void_b_a((byte)21);
            //this.gamecanvas.battlefieldSatge = 1;
            //this.gamecanvas.t_boolean_fld = false;
            SetAtk_Def1();
        }

        // ����: void_K
        void void_K()
        {/*
            if ((GeneralListCache.GetGeneral(this.HMGeneralId)).generalSoldier >= 500)
            {
                //this.gamecanvas.canMoni = true;
                //this.gamecanvas.moniBattle = false;
            }
            else
            {
                //this.gamecanvas.canMoni = false;
                //this.gamecanvas.moniBattle = false;
            }
            //this.gamecanvas.isDrawMoning = false;
            //this.gamecanvas.finishMoni = false;
            //this.gamecanvas.moniBattlePage = false;
            //this.gamecanvas.moniPersent = 0;
            long l1 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while (true)
            {
                if (//this.gamecanvas.getKeyValue() != 0)
                {
                    //this.gamecanvas.void_g();
                    //this.gamecanvas.setKeyValue((byte)0);
                }
                if (this.j_byte_fld <= 0)
                {
                    long l2 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - l1;
                    long tx = 100L;
                    if (//this.gamecanvas.isDrawMoning)
                        tx = 10L;
                    if (l2 < tx)
                    {
                        try
                        {
                            lock (this)
                            {
                                System.Threading.Thread.Sleep((int)(tx - l2));
                            }
                        }
                        catch (System.Exception exception) { }
                    }
                    //this.gamecanvas.repaint();
                    l1 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    continue;
                }
                break;
            }*/
        }

        // ����: boolean_f
        bool boolean_f()
        {
            short word1 = 0;
            if (this.smallSoldierOrder[1][0] == 2)
                return true;
            for (int i1 = 1; i1 < this.humanSmallSoldierNum; i1++)
            {
                if (this.smallSoldier_isSurvive[0][i1])
                    for (int j1 = 1; j1 < this.aiSmallSoldierNum; j1++)
                    {
                        if (this.smallSoldier_isSurvive[1][j1])
                            word1 = (short)(word1 + this.smallSoldierBlood[1][j1]);
                    }
            }
            return (word1 < 100 && (((GeneralListCache.GetGeneral(this.AIGeneralId)).force - (GeneralListCache.GetGeneral(this.HMGeneralId)).force) * 3 / 2 + GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() - GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical() < 0 || GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() < 45 || (this.V >= 12 && word1 < 100)));
        }

        // ����: void_i_a
        void void_i_a(int i1)
        {
            if (boolean_f() && i1 >= 4)
            {
                for (int j1 = 0; j1 < this.aiSmallSoldierNum; j1++)
                    this.smallSoldierOrder[1][j1] = 2;
                return;
            }
            for (int k1 = 0; k1 < this.aiSmallSoldierNum; k1++)
                this.smallSoldierOrder[1][k1] = 1;
        }

        // ����: void_i_b
        void void_i_b(int i1)
        {
            aiDefSiege(i1);
        }

        // ����: void_i_c
        void void_i_c(int i1)
        {
            if (boolean_f() && i1 >= 4)
            {
                for (int j1 = 0; j1 < this.aiSmallSoldierNum; j1++)
                    this.smallSoldierOrder[1][j1] = 2;
                return;
            }
            if (i1 >= 7)
            {
                this.smallSoldierOrder[1][0] = 0;
            }
            else
            {
                this.smallSoldierOrder[1][0] = 1;
            }
            for (int k1 = 1; k1 < this.aiSmallSoldierNum; k1++)
                this.smallSoldierOrder[1][k1] = 0;
        }

        // ����: void_i_d
        void void_i_d(int i1)
        {
            aiSiege(i1);
        }

        // ����: void_i_e
        void void_i_e(int i1)
        {
            aifield(i1);
        }

        // ����: void_i_f
        void void_i_f(int i1)
        {
            if (this.j_boolean_fld)
            {
                if (this.i_boolean_fld)
                {
                    void_i_b(i1);
                }
                else
                {
                    void_i_d(i1);
                }
            }
            else
            {
                void_i_e(i1);
            }
        }

        public byte hmSoldierMove(byte index)
        {
            // ȡ���Ѿ�ʿ������
            byte aix = this.smallSoldierCellX[1][0];  // �Ѿ�ʿ��X����
            byte aiy = this.smallSoldierCellY[1][0];  // �Ѿ�ʿ��Y����

            // ȡ�õо�ʿ������
            byte hmx = this.smallSoldierCellX[0][index];  // �о�ʿ��X����
            byte hmy = this.smallSoldierCellY[0][index];  // �о�ʿ��Y����

            byte de = 0; // Ĭ�Ϸ���ֵΪ0��C#��byte��ΧΪ0-0�������������

            if (aix < 15)
            {
                if (hmx < aix)
                {
                    if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                        return 3; // �����ƶ�
                    if (hmy == 0)
                    {
                        if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                            return 1; // �����ƶ�
                    }
                    else if (hmy == 6)
                    {
                        if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                            return 0; // �����ƶ�
                    }
                    else if (hmy > 0 && hmy < 6)
                    {
                        // ����y����ѡ�����ϻ�������
                        if (hmx < aix - 3 && hmy < 3)
                        {
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // ����
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // ����
                        }
                        else if (hmx < aix - 3 && hmy > 3)
                        {
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // ����
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // ����
                        }
                        else
                        {
                            // ���ѡ�����ϻ������ƶ�
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32 && this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return (byte)MathUtils.getRandomInt(2); // ��������ƶ�
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // ����
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // ����
                        }
                    }
                }
                else if (hmx > aix)
                {
                    if (Math.Abs(hmx - aix) == 1)
                    {
                        if (hmy == 0)
                        {
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // ����
                        }
                        else if (hmy == 6)
                        {
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // ����
                        }
                        else
                        {
                            if (aiy > hmy && this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // ����
                            if (aiy < hmy && this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // ����
                        }
                    }
                    else
                    {
                        if (this.smallWarCoordinate[hmy][hmx - 1] < 32)
                            return 2; // ����
                        if (hmy == 0)
                        {
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // ����
                        }
                        else if (hmy == 6)
                        {
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // ����
                        }
                        else
                        {
                            // ���ѡ�����ϻ������ƶ�
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32 && this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return (byte)MathUtils.getRandomInt(2); // ��������ƶ�
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // ����
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // ����
                        }
                    }
                }
                else if (hmx == aix)
                {
                    // �����Ѿ�ʿ��Y�����ƶ�
                    if (aiy == 0)
                    {
                        if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                            return 0; // ����
                        if (hmx < 15)
                        {
                            if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                                return 3; // ����
                        }
                        else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                        {
                            return 2; // ����
                        }
                    }
                    else if (aiy == 6)
                    {
                        if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                            return 1; // ����
                        if (hmx < 15)
                        {
                            if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                                return 3; // ����
                        }
                        else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                        {
                            return 2; // ����
                        }
                    }
                    else if (aiy > hmy)
                    {
                        if (Math.Abs(aiy - hmy) == 1 && this.smallWarCoordinate[hmy][hmx + 1] < 32 && MathUtils.getRandomInt(2) > 0)
                            return 3; // ����
                        if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                            return 1; // ����
                        if (hmx < 15)
                        {
                            if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                                return 3; // ����
                        }
                        else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                        {
                            return 2; // ����
                        }
                    }
                    else
                    {
                        if (Math.Abs(aiy - hmy) == 1 && this.smallWarCoordinate[hmy][hmx + 1] < 32 && MathUtils.getRandomInt(2) > 0)
                            return 3; // ����
                        if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                            return 0; // ����
                        if (hmx < 15)
                        {
                            if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                                return 3; // ����
                        }
                        else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                        {
                            return 2; // ����
                        }
                    }
                }
            }
            else if (hmx < aix)
            {
                // �о�ʿ�������ƶ�
                if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                    return 3; // ����
                if (hmy == 0)
                {
                    if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                        return 1; // ����
                }
                else if (hmy == 6)
                {
                    if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                        return 0; // ����
                }
                else if (hmy > 0 && hmy < 6)
                {
                    if (this.smallWarCoordinate[hmy - 1][hmx] < 32 && this.smallWarCoordinate[hmy + 1][hmx] < 32)
                        return (byte)MathUtils.getRandomInt(2); // ��������ƶ�
                    if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                        return 0; // ����
                    if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                        return 1; // ����
                }
            }
            else if (aiy == 0)
            {
                if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                    return 0; // ����
                if (hmx < 15)
                {
                    if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                        return 3; // ����
                }
                else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                {
                    return 2; // ����
                }
            }
            else if (aiy == 6)
            {
                if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                    return 1; // ����
                if (hmx < 15)
                {
                    if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                        return 3; // ����
                }
                else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                {
                    return 2; // ����
                }
            }
            else if (aiy > hmy)
            {
                if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                    return 1; // ����
                if (hmx < 15)
                {
                    if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                        return 3; // ����
                }
                else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                {
                    return 2; // ����
                }
            }

            // Ĭ�Ϸ���deֵ
            return de;
        }


        //����: void_bbb_a
        void void_bbb_a(byte byte0, byte byte1, byte byte2)
        {
            switch (byte2)
            {
                case 0:
                    UpMoveSoldier(byte0, byte1);
                    break;
                case 1:
                    DownMoveSoldier(byte0, byte1);
                    break;
                case 2:
                    LeftMoveSoldier(byte0, byte1);
                    break;
                case 3:
                    RightMoveSoldier(byte0, byte1);
                    break;
            }
        }

        // ����: byte_bb_b
        byte byte_bb_b(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[5];
            int i1 = 0;
            if (this.smallSoldierCellY[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] - 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
            {
                if (byte1 == 0 || (this.smallSoldierKind[0][byte0] == 0 && this.smallSoldierCellX[1][0] == this.smallSoldierCellX[0][byte0] && this.smallSoldierCellY[1][0] == this.smallSoldierCellY[0][byte0] - 1))
                    return 0;
                abyte0[i1++] = 0;
            }
            if (this.smallSoldierCellY[0][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] + 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
            {
                if (byte1 == 1 || (this.smallSoldierKind[0][byte0] == 0 && this.smallSoldierCellX[1][0] == this.smallSoldierCellX[0][byte0] && this.smallSoldierCellY[1][0] == this.smallSoldierCellY[0][byte0] + 1))
                    return 1;
                abyte0[i1++] = 1;
            }
            if (this.smallSoldierCellX[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] - 1] & 0x80) != 0)
            {
                if (byte1 == 2 || (this.smallSoldierKind[0][byte0] == 0 && this.smallSoldierCellX[1][0] == this.smallSoldierCellX[0][byte0] - 1 && this.smallSoldierCellY[1][0] == this.smallSoldierCellY[0][byte0]))
                    return 2;
                abyte0[i1++] = 2;
            }
            if (this.smallSoldierCellX[0][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] + 1] & 0x80) != 0)
            {
                if (byte1 == 3 || (this.smallSoldierKind[0][byte0] == 0 && this.smallSoldierCellX[1][0] == this.smallSoldierCellX[0][byte0] + 1 && this.smallSoldierCellY[1][0] == this.smallSoldierCellY[0][byte0]))
                    return 3;
                abyte0[i1++] = 3;
            }
            if (i1 > 0 && (byte1 == 0 || CommonUtils.getRandomInt() % 10 >= 0))
            {
                byte byte2 = (byte)(CommonUtils.getRandomInt() % i1);
                return abyte0[byte2];
            }
            return 0;
        }

        // ����: void_bbbbB_a
        void void_bbbbB_a(byte byte0, byte byte1, byte byte2, byte byte3, bool flag)
        {
            this.aj = byte0;
            this.ak = byte1;
            this.al = byte2;
            this.am = byte3;
            this.k_boolean_fld = flag;
            this.ai = 6;
        }

        // ͬ������: s_void_bbB_b
        void s_void_bbB_b(byte byte0, byte byte1, bool flag)
        {
            byte byte2;
            byte byte3;

            if (flag)
            {
                byte2 = this.smallSoldierCellX[1][byte0];
                byte3 = this.smallSoldierCellY[1][byte0];
            }
            else
            {
                byte2 = this.smallSoldierCellX[0][byte0];
                byte3 = this.smallSoldierCellY[0][byte0];
            }

            switch (byte1)
            {
                case 0:
                    byte3 = (byte)(byte3 - 1);
                    break;
                case 1:
                    byte3 = (byte)(byte3 + 1);
                    break;
                case 2:
                    byte2 = (byte)(byte2 - 1);
                    break;
                case 3:
                    byte2 = (byte)(byte2 + 1);
                    break;
            }

            if (flag)
            {
                for (byte byte4 = 0; byte4 < this.humanSmallSoldierNum; byte4 = (byte)(byte4 + 1))
                {
                    if (this.smallSoldierCellX[0][byte4] == byte2 && this.smallSoldierCellY[0][byte4] == byte3)
                        void_bbbbB_a((byte)1, byte0, (byte)0, byte4, flag);
                }
            }
            else
            {
                for (byte byte5 = 0; byte5 < this.aiSmallSoldierNum; byte5 = (byte)(byte5 + 1))
                {
                    if (this.smallSoldierCellX[1][byte5] == byte2 && this.smallSoldierCellY[1][byte5] == byte3)
                        void_bbbbB_a((byte)0, byte0, (byte)1, byte5, flag);
                }
            }
        }

        // ����: boolean_bb_b
        bool boolean_bb_b(byte byte0, byte byte1)
        {
            byte byte2 = byte_bb_b(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_b(byte0, byte2, false);
            }
            else if (byte1 >= 0)
            {
                void_bbb_a((byte)0, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }

        // ����: byte_bb_c
        byte byte_bb_c(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            byte byte2 = 5;
            if (getSkill_2(this.HMGeneralId, 6))
                byte2 = (byte)(byte2 + 1);
            if (this.smallSoldierCellY[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] - 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0 && byte1 == 0)
                return 0;
            if (this.smallSoldierCellY[0][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] + 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0 && byte1 == 1)
                return 1;
            if (this.smallSoldierCellX[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] - 1] & 0x80) != 0 && byte1 == 2)
                return 2;
            if (this.smallSoldierCellX[0][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] + 1] & 0x80) != 0 && byte1 == 3)
                return 3;
            if ((this.aa & 0xF0) == 48)
                byte2 = (byte)(byte2 + 2);
            int j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellY[0][byte0] + j1 <= 6)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] + j1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                {
                    abyte0[i1++] = 1;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellY[0][byte0] >= j1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] - j1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                {
                    abyte0[i1++] = 0;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellX[0][byte0] >= j1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] - j1] & 0x80) != 0)
                {
                    abyte0[i1++] = 2;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellX[0][byte0] + j1 <= 15)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] + j1] & 0x80) != 0)
                {
                    abyte0[i1++] = 3;
                    break;
                }
                j1++;
            }
            if (i1 > 0 && (byte1 == 0 || CommonUtils.getRandomInt() % 10 >= 0))
                return abyte0[CommonUtils.getRandomInt() % i1];
            return 0;
        }

        // ͬ������: s_void_bbB_c
        void s_void_bbB_c(byte byte0, byte byte1, bool flag)
        {
            byte byte2, byte3, byte10, byte4, byte5, byte6, byte7, byte11 = 5;

            if (flag)
            {
                byte2 = this.smallSoldierCellX[1][byte0];
                byte3 = this.smallSoldierCellY[1][byte0];
                byte10 = 64;
                if (getSkill_2(this.AIGeneralId, 6))
                    byte11 = (byte)(byte11 + 1);
                if ((this.ab & 0xF0) == 48)
                    byte11 = (byte)(byte11 + 2);
            }
            else
            {
                byte2 = this.smallSoldierCellX[0][byte0];
                byte3 = this.smallSoldierCellY[0][byte0];
                byte10 = Byte.MinValue;
                if (getSkill_2(this.HMGeneralId, 6))
                    byte11 = (byte)(byte11 + 1);
                if ((this.aa & 0xF0) == 48)
                    byte11 = (byte)(byte11 + 2);
            }

            switch (byte1)
            {
                case 0:
                    byte4 = 1;
                    while (byte4 < byte11)
                    {
                        if (byte3 - byte4 >= 0 && (this.smallWarCoordinate[byte3 - byte4][byte2] & byte10) != 0)
                        {
                            byte3 = (byte)(byte3 - byte4);
                            break;
                        }
                        byte4 = (byte)(byte4 + 1);
                    }
                    break;
                case 1:
                    byte5 = 1;
                    while (byte5 < byte11)
                    {
                        if (byte3 + byte5 <= 6 && (this.smallWarCoordinate[byte3 + byte5][byte2] & byte10) != 0)
                        {
                            byte3 = (byte)(byte3 + byte5);
                            break;
                        }
                        byte5 = (byte)(byte5 + 1);
                    }
                    break;
                case 2:
                    byte6 = 1;
                    while (byte6 < byte11)
                    {
                        if (byte2 - byte6 >= 0 && (this.smallWarCoordinate[byte3][byte2 - byte6] & byte10) != 0)
                        {
                            byte2 = (byte)(byte2 - byte6);
                            break;
                        }
                        byte6 = (byte)(byte6 + 1);
                    }
                    break;
                case 3:
                    byte7 = 1;
                    while (byte7 < byte11)
                    {
                        if (byte2 + byte7 <= 15 && (this.smallWarCoordinate[byte3][byte2 + byte7] & byte10) != 0)
                        {
                            byte2 = (byte)(byte2 + byte7);
                            break;
                        }
                        byte7 = (byte)(byte7 + 1);
                    }
                    break;
            }

            if (flag)
            {
                //this.gamecanvas.void_bbbbB_a(this.smallSoldierCellX[1][byte0], this.smallSoldierCellY[1][byte0], byte2, byte3, !flag);
                for (byte byte8 = 0; byte8 < this.humanSmallSoldierNum; byte8 = (byte)(byte8 + 1))
                {
                    if (this.smallSoldierCellX[0][byte8] == byte2 && this.smallSoldierCellY[0][byte8] == byte3)
                        void_bbbbB_a((byte)1, byte0, (byte)0, byte8, flag);
                }
            }
            else
            {
                //this.gamecanvas.void_bbbbB_a(this.smallSoldierCellX[0][byte0], this.smallSoldierCellY[0][byte0], byte2, byte3, !flag);
                for (byte byte9 = 0; byte9 < this.aiSmallSoldierNum; byte9 = (byte)(byte9 + 1))
                {
                    if (this.smallSoldierCellX[1][byte9] == byte2 && this.smallSoldierCellY[1][byte9] == byte3)
                        void_bbbbB_a((byte)0, byte0, (byte)1, byte9, flag);
                }
            }
        }

        // ����: boolean_bb_c
        bool boolean_bb_c(byte byte0, byte byte1)
        {
            byte byte2 = byte_bb_c(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_c(byte0, byte2, false);
            }
            else if (byte1 >= 0)
            {
                void_bbb_a((byte)0, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }
        // ������boolean_b_c
        // ������byte0������byte
        // ���ܣ�����byte0�Ĳ�ͬ���ͣ����ò�ͬ�Ĵ�����

        bool boolean_b_c(byte byte0)
        {
            // ��ȡhmSoldierMove���ص�ֵ
            byte byte1 = hmSoldierMove(byte0);

            // �������ֵ���ڵ���0�����丳ֵ��smallSoldier_action[0][byte0]
            if (byte1 >= 0)
            {
                this.smallSoldierAction[0][byte0] = byte1;
            }

            // ����smallSoldierKind[0][byte0]��ִֵ�в�ͬ����
            switch (this.smallSoldierKind[0][byte0])
            {
                case 0:
                case 1:
                case 3:
                    // �������0��1��3������boolean_bb_b
                    return boolean_bb_b(byte0, byte1);
                case 2:
                    // �������2������boolean_bb_c
                    return boolean_bb_c(byte0, byte1);
            }

            // ���û��ƥ������������false
            return false;
        }




        // ����: boolean_b_d
        bool boolean_b_d(byte byte0)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            if (this.smallSoldierCellY[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] - 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                abyte0[i1++] = 0;
            if (this.smallSoldierCellY[0][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] + 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                abyte0[i1++] = 1;
            if (this.smallSoldierCellX[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] - 1] & 0x80) != 0)
                abyte0[i1++] = 2;
            if (this.smallSoldierCellX[0][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] + 1] & 0x80) != 0)
                abyte0[i1++] = 3;
            if (i1 == 0)
                return false;
            s_void_bbB_b(byte0, abyte0[CommonUtils.getRandomInt() % i1], false);
            return true;
        }

        // ����: boolean_b_e
        bool boolean_b_e(byte byte0)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            byte byte2 = 5;
            if (getSkill_2(this.HMGeneralId, 6))
                byte2 = (byte)(byte2 + 1);
            if ((this.aa & 0xF0) == 48)
                byte2 = (byte)(byte2 + 2);
            byte byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellY[0][byte0] >= byte1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] - byte1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                {
                    abyte0[i1++] = 0;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellY[0][byte0] + byte1 <= 6)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] + byte1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                {
                    abyte0[i1++] = 1;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellX[0][byte0] >= byte1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] - byte1] & 0x80) != 0)
                {
                    abyte0[i1++] = 2;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellX[0][byte0] + byte1 <= 15)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] + byte1] & 0x80) != 0)
                {
                    abyte0[i1++] = 3;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            if (i1 == 0)
                return false;
            s_void_bbB_c(byte0, abyte0[CommonUtils.getRandomInt() % i1], false);
            return true;
        }

        // ����: boolean_b_f
        bool boolean_b_f(byte byte0)
        {
            switch (this.smallSoldierKind[0][byte0])
            {
                case 0:
                case 1:
                case 3:
                    return boolean_b_d(byte0);
                case 2:
                    return boolean_b_e(byte0);
            }
            return false;
        }

        // ����: boolean_b_g
        bool boolean_b_g(byte index)
        {
            if (this.smallSoldierCellX[0][index] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][index]][this.smallSoldierCellX[0][index] - 1] & 0xE0) != 0)
            {
                int i1 = 0;
                if (this.smallSoldierCellY[0][index] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][index] - 1][this.smallSoldierCellX[0][index]] & 0xE0) == 0)
                    i1++;
                if (this.smallSoldierCellY[0][index] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[0][index] + 1][this.smallSoldierCellX[0][index]] & 0xE0) == 0)
                    i1 += 2;
                byte byte1 = 0;
                if (i1 == 1)
                {
                    UpMoveSoldier(byte1, index);
                }
                else if (i1 == 2)
                {
                    DownMoveSoldier(byte1, index);
                }
                else if (i1 == 3)
                {
                    if (CommonUtils.getRandomInt() % 2 == 0)
                    {
                        UpMoveSoldier(byte1, index);
                    }
                    else
                    {
                        DownMoveSoldier(byte1, index);
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            if (this.smallSoldierCellX[0][index] == 0)
            {
                this.smallWarCoordinate[this.smallSoldierCellY[0][index]][this.smallSoldierCellX[0][index]] = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[0][index]][this.smallSoldierCellX[0][index]] & 0x32);
                this.smallSoldierCellX[0][index] = 0;
                this.smallSoldierCellY[0][index] = 0;
                this.smallSoldier_isSurvive[0][index] = false;
                return true;
            }
            LeftMoveSoldier((byte)0, index);
            return true;
        }

        // ����: byte_bb_d
        byte byte_bb_d(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[5];
            int i1 = 0;
            byte byte2 = this.smallSoldierCellX[0][byte0];
            byte byte3 = this.smallSoldierCellY[0][byte0];
            byte byte4 = this.smallSoldierCellX[1][0];
            byte byte5 = this.smallSoldierCellY[1][0];

            // ��������ƶ������
            if (byte1 == 0 && byte5 == byte3 - 1 && byte4 == byte2)
            {
                byte1 = 0;
            }
            else if (byte3 > 0 && (this.smallWarCoordinate[byte3 - 1][byte2] & 0x80) != 0 && (byte5 != byte3 - 1 || byte4 != byte2))
            {
                if (byte1 == 0)
                    return 0;
                abyte0[i1++] = 0;
            }

            // ��������ƶ������
            if (byte1 == 1 && byte5 == byte3 + 1 && byte4 == byte2)
            {
                byte1 = 0;
            }
            else if (byte3 < 6 && (this.smallWarCoordinate[byte3 + 1][byte2] & 0x80) != 0 && (byte5 != byte3 + 1 || byte4 != byte2))
            {
                if (byte1 == 1)
                    return 1;
                abyte0[i1++] = 1;
            }

            // ��������ƶ������
            if (byte1 == 2 && byte5 == byte3 && byte4 == byte2 - 1)
            {
                byte1 = 0;
            }
            else if (byte2 > 0 && (this.smallWarCoordinate[byte3][byte2 - 1] & 0x80) != 0 && (byte5 != byte3 || byte4 != byte2 - 1))
            {
                if (byte1 == 2)
                    return 2;
                abyte0[i1++] = 2;
            }

            // ��������ƶ������
            if (byte1 == 3 && byte5 == byte3 && byte4 == byte2 + 1)
            {
                byte1 = 0;
            }
            else if (byte2 < 15 && (this.smallWarCoordinate[byte3][byte2 + 1] & 0x80) != 0 && (byte4 != byte2 + 1 || byte5 != byte3))
            {
                if (byte1 == 3)
                    return 3;
                abyte0[i1++] = 3;
            }

            // ����п�ѡ�ķ��������ѡ��һ������
            if (i1 > 0 && (byte1 < 0 || CommonUtils.getRandomInt() % 10 >= 10))
            {
                byte byte6 = (byte)(CommonUtils.getRandomInt() % i1);
                return abyte0[byte6];
            }

            // ����Ĭ��ֵ
            return (byte)((byte1 >= 0) ? 0 : -2);
        }

        // ����: boolean_bb_d
        bool boolean_bb_d(byte byte0, byte byte1)
        {
            byte byte2 = byte_bb_d(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_b(byte0, byte2, false);
            }
            else if (byte1 >= 0 && byte2 != -2)
            {
                void_bbb_a((byte)0, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }

        // ����: byte_bb_e
        byte byte_bb_e(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            byte byte2 = this.smallSoldierCellX[0][byte0];
            byte byte3 = this.smallSoldierCellY[0][byte0];
            byte byte4 = this.smallSoldierCellX[1][0];
            byte byte5 = this.smallSoldierCellY[1][0];
            byte byte6 = 5;

            // ��鼼���Ƿ񼤻�
            if (getSkill_2(this.HMGeneralId, 6))
                byte6 = (byte)(byte6 + 1);

            // ��������ƶ������
            if (byte3 > 0 && (this.smallWarCoordinate[byte3 - 1][byte2] & 0x80) != 0 && byte1 == 0)
                if (byte5 == byte3 - 1 && byte4 == byte2)
                {
                    byte1 = 0;
                }
                else
                {
                    return 0;
                }

            // ��������ƶ������
            if (byte3 < 6 && (this.smallWarCoordinate[byte3 + 1][byte2] & 0x80) != 0 && byte1 == 1)
                if (byte5 == byte3 + 1 && byte4 == byte2)
                {
                    byte1 = 0;
                }
                else
                {
                    return 1;
                }

            // ��������ƶ������
            if (byte2 > 0 && (this.smallWarCoordinate[byte3][byte2 - 1] & 0x80) != 0 && byte1 == 2)
                if (byte5 == byte3 && byte4 == byte2 - 1)
                {
                    byte1 = 0;
                }
                else
                {
                    return 2;
                }

            // ��������ƶ������
            if (byte2 < 15 && (this.smallWarCoordinate[byte3][byte2 + 1] & 0x80) != 0 && byte1 == 3)
                if (byte5 == byte3 && byte4 == byte2 + 1)
                {
                    byte1 = 0;
                }
                else
                {
                    return 3;
                }

            // �����⼼��
            if ((this.aa & 0xF0) == 48)
                byte6 = (byte)(byte6 + 2);

            // ����Ϸ����λ��
            int j1 = 1;
            while (j1 < byte6 && byte3 >= j1 && (byte5 != byte3 - j1 || byte4 != byte2))
            {
                if ((this.smallWarCoordinate[byte3 - j1][byte2] & 0x80) != 0)
                {
                    abyte0[i1++] = 0;
                    break;
                }
                j1++;
            }

            // ����·����λ��
            j1 = 1;
            while (j1 < byte6 && byte3 + j1 <= 6 && (byte5 != byte3 + j1 || byte4 != byte2))
            {
                if ((this.smallWarCoordinate[byte3 + j1][byte2] & 0x80) != 0)
                {
                    abyte0[i1++] = 1;
                    break;
                }
                j1++;
            }

            // ��������λ��
            j1 = 1;
            while (j1 < byte6 && byte2 >= j1 && (byte5 != byte3 || byte4 != byte2 - j1))
            {
                if ((this.smallWarCoordinate[byte3][byte2 - j1] & 0x80) != 0)
                {
                    abyte0[i1++] = 2;
                    break;
                }
                j1++;
            }

            // ����Ҳ���λ��
            j1 = 1;
            while (j1 < byte6 && byte2 + j1 <= 15 && (byte5 != byte3 || byte4 != byte2 + j1))
            {
                if ((this.smallWarCoordinate[byte3][byte2 + j1] & 0x80) != 0)
                {
                    abyte0[i1++] = 3;
                    break;
                }
                j1++;
            }

            // ����п�ѡ�ķ��������ѡ��һ������
            if (i1 > 0 && (byte1 == 0 || CommonUtils.getRandomInt() % 10 >= 6))
                return abyte0[CommonUtils.getRandomInt() % i1];

            // ����Ĭ��ֵ
            return (byte)((byte1 != 0) ? 0 : -2);
        }

        // ����: boolean_bb_e
        bool boolean_bb_e(byte byte0, byte byte1)
        {
            byte1 = hmSoldierMove(byte0);
            byte byte2 = byte_bb_e(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_c(byte0, byte2, false);
            }
            else if (byte1 >= 0 && byte2 != -2)
            {
                void_bbb_a((byte)0, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }

        // ����: boolean_b_h
        bool boolean_b_h(byte byte0)
        {
            byte byte1 = hmSoldierMove(byte0);
            if (byte1 >= 0)
                this.smallSoldierAction[0][byte0] = byte1;
            switch (this.smallSoldierKind[0][byte0])
            {
                case 0:
                case 1:
                case 3:
                    return boolean_bb_d(byte0, byte1);
                case 2:
                    return boolean_bb_e(byte0, byte1);
            }
            return false;
        }

        // ����: boolean_b_i
        bool boolean_b_i(byte byte0)
        {
            bool flag = false;
            if (!this.smallSoldier_isSurvive[0][byte0])
                return false;
            this.smallSoldierOrder[0][byte0] = this.P_byte_array1d_fld[this.smallSoldierKind[0][byte0]];
            switch (this.smallSoldierOrder[0][byte0])
            {
                case 0:
                    flag = boolean_b_c(byte0);
                    break;
                case 1:
                    flag = boolean_b_f(byte0);
                    break;
                case 2:
                    flag = boolean_b_g(byte0);
                    break;
                case 3:
                    flag = boolean_b_h(byte0);
                    break;
            }
            setCSK();
            return flag;
        }

        // ����: byte_b_e
        byte byte_b_e(byte byte0)
        {
            byte hG_X = this.smallSoldierCellX[0][0];
            byte hG_Y = this.smallSoldierCellY[0][0];
            byte ai_X = this.smallSoldierCellX[1][byte0];
            byte ai_Y = this.smallSoldierCellY[1][byte0];
            byte byte5 = 0;

            try
            {
                // ��������ƶ������
                if (hG_X > 0 && (this.smallWarCoordinate[hG_Y][hG_X + 1] & 0xA0) == 0 && hG_Y - ai_Y != 0)
                {
                    hG_X = (byte)(hG_X - 1);
                }
                // ��������ƶ������
                else if (hG_Y - ai_Y <= 0)
                {
                    if (hG_Y > 0 && (this.smallWarCoordinate[hG_Y - 1][hG_X] & 0xA0) == 0)
                    {
                        hG_Y = (byte)(hG_Y - 1);
                    }
                    else if (hG_Y < 6 && (this.smallWarCoordinate[hG_Y + 1][hG_X] & 0xA0) == 0)
                    {
                        hG_Y = (byte)(hG_Y + 1);
                    }
                    else if (hG_X < 15 && (this.smallWarCoordinate[hG_Y][hG_X - 1] & 0xA0) == 0)
                    {
                        hG_X = (byte)(hG_X + 1);
                    }
                }
                // ��������ƶ������
                else if (hG_Y < 6 && (this.smallWarCoordinate[hG_Y + 1][hG_X] & 0xA0) == 0)
                {
                    hG_Y = (byte)(hG_Y + 1);
                }
                // ��������ƶ������
                else if (hG_Y > 0 && (this.smallWarCoordinate[hG_Y - 1][hG_X] & 0xA0) == 0)
                {
                    hG_Y = (byte)(hG_Y - 1);
                }
                // ��������ƶ������
                else if (hG_X < 15 && (this.smallWarCoordinate[hG_Y][hG_X - 1] & 0xA0) == 0)
                {
                    hG_X = (byte)(hG_X + 1);
                }

                // ���Ŀ��λ�����Ҳ�����
                if (ai_X < 15 && hG_X - ai_X > 0 && (this.smallWarCoordinate[ai_Y][ai_X + 1] & 0xA0) == 0)
                    if (hG_X == ai_X + 1 && hG_Y == ai_Y)
                    {
                        byte5 = 3;
                    }
                    else
                    {
                        return 3;
                    }
                // ���Ŀ��λ�����������
                if (ai_X > 0 && hG_X - ai_X < 0 && (this.smallWarCoordinate[ai_Y][ai_X - 1] & 0xA0) == 0)
                    if (hG_X == ai_X - 1 && hG_Y == ai_Y)
                    {
                        byte5 = 2;
                    }
                    else
                    {
                        return 2;
                    }
                // ���Ŀ��λ�����·������
                if (ai_Y < 6 && hG_Y - ai_Y > 0 && (this.smallWarCoordinate[ai_Y + 1][ai_X] & 0xA0) == 0)
                    return 1;
                // ���Ŀ��λ�����Ϸ������
                if (ai_Y > 0 && hG_Y - ai_Y < 0 && (this.smallWarCoordinate[ai_Y - 1][ai_X] & 0xA0) == 0)
                    return 0;

                // ���ˮƽ������ͬ�����
                if (hG_X - ai_X == 0)
                {
                    if (ai_X < 15 && ai_X > 0 && (this.smallWarCoordinate[ai_Y][ai_X + 1] & 0xA0) == 0 && this.smallWarCoordinate[ai_Y][ai_X - 1] == 0)
                        return (byte)(CommonUtils.getRandomInt() % 2 + 2);
                    if (ai_X < 15 && (this.smallWarCoordinate[ai_Y][ai_X + 1] & 0xA0) == 0)
                        return 3;
                    if (ai_X > 0 && (this.smallWarCoordinate[ai_Y][ai_X - 1] & 0xA0) == 0)
                        return 2;
                }

                // ��鴹ֱ������ͬ�����
                if (hG_Y - ai_Y == 0)
                {
                    if (ai_Y > 0 && ai_Y < 6 && (this.smallWarCoordinate[ai_Y + 1][ai_X] & 0xA0) == 0 && (this.smallWarCoordinate[ai_Y - 1][ai_X] & 0xA0) == 0)
                        return (byte)(CommonUtils.getRandomInt() % 2);
                    if (ai_Y < 6 && (this.smallWarCoordinate[ai_Y + 1][ai_X] & 0xA0) == 0)
                        return 1;
                    if (ai_Y > 0 && (this.smallWarCoordinate[ai_Y - 1][ai_X] & 0xA0) == 0)
                        return 0;
                }
            }
            catch (System.Exception e)
            {
                e.ToString(); // �� C# ��ʹ�� e.ToString() ��ӡ�쳣��Ϣ
                return byte5;
            }

            return byte5;
        }

        // ��byte���Ͷ���Ϊ�޷��ŵ�byte
        public byte aiSoldierMove(byte index)
        {
            // ȡ�ü���ʿ����AIʿ��������
            byte hmx = this.smallSoldierCellX[0][0]; // ����ʿ��X����
            byte hmy = this.smallSoldierCellY[0][0]; // ����ʿ��Y����
            byte aix = this.smallSoldierCellX[1][index]; // AIʿ��X����
            byte aiy = this.smallSoldierCellY[1][index]; // AIʿ��Y����

            // �������ʿ����X�������0
            if (hmx > 0)
            {
                // ���AIʿ����X������ڼ���ʿ��
                if (aix > hmx)
                {
                    // ���X�����ֵΪ1������Y������ȣ����б߽紦��
                    if (Math.Abs(aix - hmx) == 1)
                    {
                        if (aiy == hmy)
                        {
                            if (aiy == 0)
                            {
                                // ���AIʿ���ڵ�ͼ���Ϸ�������·��Ƿ���ƶ�
                                if (this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                                    return 1; // �����ƶ�
                                return 2; // �����ƶ�
                            }
                            if (aiy == 6)
                            {
                                // ���AIʿ���ڵ�ͼ���·�������Ϸ��Ƿ���ƶ�
                                if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                                    return 0; // �����ƶ�
                                return 2; // �����ƶ�
                            }
                        }
                        else if (hmy - aiy >= 2)
                        {
                            // ���AIʿ��Y����ȼ���ʿ��С2���ϣ�����·����󷽿��ƶ�
                            if (this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                                return 1; // �����ƶ�
                            if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                                return 2; // �����ƶ�
                        }
                        else if (aiy - hmy >= 2)
                        {
                            // ���AIʿ��Y����ȼ���ʿ����2���ϣ�����Ϸ����󷽿��ƶ�
                            if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                                return 0; // �����ƶ�
                            if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                                return 2; // �����ƶ�
                        }
                        else
                        {
                            // ����������������ƶ�
                            if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                                return 2; // �����ƶ�
                            if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                                return 0; // �����ƶ�
                        }
                    }
                    // AIʿ���ڵ�ͼ���Ϸ�ʱ�ı߽紦��
                    else if (aiy == 0)
                    {
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // �����ƶ�
                        if (this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                            return 1; // �����ƶ�
                    }
                    // AIʿ���ڵ�ͼ���·�ʱ�ı߽紦��
                    else if (aiy == 6)
                    {
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // �����ƶ�
                        if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                            return 0; // �����ƶ�
                    }
                    else
                    {
                        // ����󷽡��Ϸ����·��ƶ��Ŀ�����
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // �����ƶ�
                        if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16 &&
                            this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                            return (byte)(CommonUtils.getRandomInt() % 2); // ���ѡ���ϻ����ƶ�
                        if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                            return 0; // �����ƶ�
                        if (this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                            return 1; // �����ƶ�
                    }
                }
                // AIʿ���ͼ���ʿ��X������ͬ���������
                else if (aix == hmx)
                {
                    if (aiy - hmy == 1)
                    {
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // �����ƶ�
                        if (hmx < 15 && this.smallWarCoordinate[aiy][aix + 1] >= 0 && this.smallWarCoordinate[aiy][aix + 1] <= 16)
                            return 3; // �����ƶ�
                        return 0; // �����ƶ�
                    }
                    if (hmy - aiy == 1)
                    {
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // �����ƶ�
                        if (hmx < 15 && this.smallWarCoordinate[aiy][aix + 1] >= 0 && this.smallWarCoordinate[aiy][aix + 1] <= 16)
                            return 3; // �����ƶ�
                        return 1; // �����ƶ�
                    }
                    // AIʿ��Y����ȼ���ʿ����2����ʱ�Ĵ���
                    if (aiy - hmy >= 2)
                    {
                        if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                            return 0; // �����ƶ�
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // �����ƶ�
                        if (hmx < 15 && this.smallWarCoordinate[aiy][aix + 1] >= 0 && this.smallWarCoordinate[aiy][aix + 1] <= 16)
                            return 3; // �����ƶ�
                    }
                    // AIʿ��Y����ȼ���ʿ��С2����ʱ�Ĵ���
                    else if (hmy - aiy >= 2)
                    {
                        if (this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                            return 1; // �����ƶ�
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // �����ƶ�
                        if (hmx < 15 && this.smallWarCoordinate[aiy][aix + 1] >= 0 && this.smallWarCoordinate[aiy][aix + 1] <= 16)
                            return 3; // �����ƶ�
                    }
                    // Ĭ�����������ƶ�
                    if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                        return 2; // �����ƶ�
                }
            }

            // ���ݲ�ͬ������Ĭ�Ϸ���һ���ƶ����򣬷�ֹ�쳣���
            return 0; // �����ƶ�
        }


        // ����: byte_bb_f
        byte byte_bb_f(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            if (this.smallSoldierCellY[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] - 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
            {
                if (byte1 == 0 || (this.smallSoldierKind[1][byte0] == 0 && this.smallSoldierCellX[0][0] == this.smallSoldierCellX[1][byte0] && this.smallSoldierCellY[0][0] == this.smallSoldierCellY[1][byte0] - 1))
                    return 0;
                abyte0[i1++] = 0;
            }
            if (this.smallSoldierCellY[1][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] + 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
            {
                if (byte1 == 1 || (this.smallSoldierKind[1][byte0] == 0 && this.smallSoldierCellX[0][0] == this.smallSoldierCellX[1][byte0] && this.smallSoldierCellY[0][0] == this.smallSoldierCellY[1][byte0] + 1))
                    return 1;
                abyte0[i1++] = 1;
            }
            if (this.smallSoldierCellX[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] - 1] & 0x40) != 0)
            {
                if (byte1 == 4 || byte1 == 2 || (this.smallSoldierKind[1][byte0] == 0 && this.smallSoldierCellX[0][0] == this.smallSoldierCellX[1][byte0] - 1 && this.smallSoldierCellY[0][0] == this.smallSoldierCellY[1][byte0]))
                    return 2;
                abyte0[i1++] = 2;
            }
            if (this.smallSoldierCellX[1][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] + 1] & 0x40) != 0)
            {
                if (byte1 == 3 || (this.smallSoldierKind[1][byte0] == 0 && this.smallSoldierCellX[0][0] == this.smallSoldierCellX[1][byte0] + 1 && this.smallSoldierCellY[0][0] == this.smallSoldierCellY[1][byte0]))
                    return 3;
                abyte0[i1++] = 3;
            }
            if (i1 > 0 && (byte1 == 0 || CommonUtils.getRandomInt() % 10 >= 0))
                return abyte0[CommonUtils.getRandomInt() % i1];
            return 0;
        }

        // ����: boolean_bb_f
        bool boolean_bb_f(byte byte0, byte byte1)
        {
            byte byte2 = byte_bb_f(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_b(byte0, byte2, true);
            }
            else if (byte1 >= 0)
            {
                void_bbb_a((byte)1, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }

        // ����: byte_bb_g
        byte byte_bb_g(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            byte byte2 = 5;
            if (getSkill_2(this.AIGeneralId, 6))
                byte2 = (byte)(byte2 + 1);
            if (this.smallSoldierCellY[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] - 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0 && byte1 == 0)
                return 0;
            if (this.smallSoldierCellY[1][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] + 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0 && byte1 == 1)
                return 1;
            if (this.smallSoldierCellX[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] - 1] & 0x40) != 0 && byte1 == 2)
                return 2;
            if (this.smallSoldierCellX[1][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] + 1] & 0x40) != 0 && byte1 == 3)
                return 3;
            if ((this.ab & 0xF0) == 48)
                byte2 = (byte)(byte2 + 2);
            int j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellY[1][byte0] >= j1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] - j1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                {
                    abyte0[i1++] = 0;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellY[1][byte0] + j1 <= 6)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] + j1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                {
                    abyte0[i1++] = 1;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellX[1][byte0] >= j1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] - j1] & 0x40) != 0)
                {
                    abyte0[i1++] = 2;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellX[1][byte0] + j1 <= 15)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] + j1] & 0x40) != 0)
                {
                    abyte0[i1++] = 3;
                    break;
                }
                j1++;
            }
            if (i1 > 0 && (byte1 == 0 || CommonUtils.getRandomInt() % 10 >= 0))
                return abyte0[CommonUtils.getRandomInt() % i1];
            return 0;
        }

        // ����: boolean_bb_g
        bool boolean_bb_g(byte byte0, byte byte1)
        {
            byte byte2 = byte_bb_g(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_c(byte0, byte2, true);
            }
            else if (byte1 >= 0)
            {
                void_bbb_a((byte)1, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }


        // ����: boolean_b_j
        public bool boolean_b_j(byte byte0)
        {
            if (this.smallSoldier_isSurvive[1][byte0])
            {
                byte byte1 = 0;
                try
                {
                    byte1 = aiSoldierMove(byte0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // ��Unity�п���ʹ�� UnityEngine.Debug.LogError(e) ����ӡ�쳣
                    try
                    {
                        byte1 = byte_b_e(byte0);
                    }
                    catch (Exception e2)
                    {
                        Console.WriteLine(e2); // ͬ��
                    }
                }
                if (byte1 >= 0)
                    this.smallSoldierAction[1][byte0] = byte1;
                switch (this.smallSoldierKind[1][byte0])
                {
                    case 0:
                    case 1:
                    case 3:
                        return boolean_bb_f(byte0, byte1);
                    case 2:
                        return boolean_bb_g(byte0, byte1);
                }
            }
            return false;
        }

        // ����: boolean_b_k
        public bool boolean_b_k(byte byte0)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            if (this.smallSoldierCellY[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] - 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                abyte0[i1++] = 0;
            if (this.smallSoldierCellY[1][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] + 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                abyte0[i1++] = 1;
            if (this.smallSoldierCellX[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] - 1] & 0x40) != 0)
                abyte0[i1++] = 2;
            if (this.smallSoldierCellX[1][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] + 1] & 0x40) != 0)
                abyte0[i1++] = 3;
            if (i1 == 0)
                return false;
            s_void_bbB_b(byte0, abyte0[CommonUtils.getRandomInt() % i1], true);
            return true;
        }

        // ����: boolean_b_l
        public bool boolean_b_l(byte byte0)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            byte byte2 = 5;
            if (getSkill_2(this.AIGeneralId, 3))
                byte2 = (byte)(byte2 + 1);
            if ((this.ab & 0xF0) == 48)
                byte2 = (byte)(byte2 + 2);
            byte byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellY[1][byte0] >= byte1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] - byte1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                {
                    abyte0[i1++] = 0;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellY[1][byte0] + byte1 <= 6)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] + byte1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                {
                    abyte0[i1++] = 1;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellX[1][byte0] >= byte1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] - byte1] & 0x40) != 0)
                {
                    abyte0[i1++] = 2;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellX[1][byte0] + byte1 <= 15)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] + byte1] & 0x40) != 0)
                {
                    abyte0[i1++] = 3;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            if (i1 == 0)
                return false;
            s_void_bbB_c(byte0, abyte0[CommonUtils.getRandomInt() % i1], true);
            return true;
        }

        // ����С��������״̬����Ϊ���ж��Ƿ�����ض�����
        bool boolean_b_m(byte byte0)
        {
            // ����С���Ƿ���
            if (this.smallSoldier_isSurvive[1][byte0])
            {
                // ����С�������ͣ�ִ�в�ͬ���߼�
                switch (this.smallSoldierKind[1][byte0])
                {
                    case 0:
                    case 1:
                    case 3:
                        // ����boolean_b_k���������Ӧ����
                        return boolean_b_k(byte0);
                    case 2:
                        // ����boolean_b_l������������2
                        return boolean_b_l(byte0);
                }
            }

            // Ĭ�Ϸ���false����ʾû�н����κβ���
            return false;
        }

        // ����С���������ж����ܷ��ƶ�����ʧ
        bool boolean_b_n(byte byte0)
        {
            byte x = this.smallSoldierCellX[1][byte0];  // ��ȡС����ǰ��X����
            byte y = this.smallSoldierCellY[1][byte0];  // ��ȡС����ǰ��Y����

            // ���С��λ�����Ҳ�߽�(15)
            if (x == 15)
            {
                this.smallWarCoordinate[y][x] = (byte)(this.smallWarCoordinate[y][x] & 0x32);  // ����С������״̬
                this.smallSoldierCellX[1][byte0] = 0;  // ��С����X������Ϊ��Ч
                this.smallSoldierCellY[1][byte0] = 0;  // ��С����Y������Ϊ��Ч
                this.smallSoldier_isSurvive[1][byte0] = false;  // ���С��Ϊ����
                return true;  // ����true����ʾС�����Ƴ�ս��
            }

            // ���С��δ����߽磬���������Ƿ��п��ƶ��ռ�
            if (x < 15)
            {
                byte t_Left = this.smallWarCoordinate[y][x + 1];
                if (t_Left >= 0 && t_Left <= 16)
                {
                    // ִ��С���������ƶ��߼�
                    RightMoveSoldier((byte)1, byte0);
                    return true;
                }
            }

            int i = 0;

            // ���С�����Ϸ�λ���Ƿ���ƶ�
            if (y > 0)
            {
                byte t_UP = this.smallWarCoordinate[y - 1][x];
                if (t_UP >= 0 && t_UP <= 16)
                    i++;
            }

            // ���С�����·�λ���Ƿ���ƶ�
            if (y < 6)
            {
                byte t_Down = this.smallWarCoordinate[y + 1][x];
                if (t_Down >= 0 && t_Down <= 16)
                    i += 2;
            }

            // ����i��ֵ�жϷ���
            if (i == 1)
            {
                UpMoveSoldier((byte)1, byte0);  // �����ƶ�
                return true;
            }
            if (i == 2)
            {
                DownMoveSoldier((byte)1, byte0);  // �����ƶ�
                return true;
            }
            if (i == 3)
            {
                if (CommonUtils.getRandomInt() % 2 > 0)
                {
                    UpMoveSoldier((byte)1, byte0);  // ��������ƶ�
                    return true;
                }
                DownMoveSoldier((byte)1, byte0);  // �����ƶ�
                return true;
            }

            return false;  // Ĭ�Ϸ���false
        }

        // ����С����ǰ��ָ�ִ����Ӧ�Ķ���
        bool boolean_b_o(byte byte0)
        {
            bool flag = false;

            // ���С���Ѿ�������ֱ�ӷ���false
            if (!this.smallSoldier_isSurvive[1][byte0])
                return false;

            // ����С����ָ�����ͣ�ִ�в�ͬ�Ĳ���
            switch (this.smallSoldierOrder[1][byte0])
            {
                case 0:
                    // ִ������Ϊ0��ָ��
                    flag = boolean_b_j(byte0);
                    break;
                case 1:
                    // ִ������Ϊ1��ָ��
                    flag = boolean_b_m(byte0);
                    break;
                case 2:
                    // ִ������Ϊ2��ָ����ȼ���ƶ���ʧ��ʱִ������1ָ��
                    flag = boolean_b_n(byte0);
                    if (!flag)
                        flag = boolean_b_m(byte0);
                    break;
            }

            setCSK();  // ����setCSK����������״̬
            return flag;  // ����ִ�н��
        }


        public short sht(bool aiAtk)
        {
            // ��ȡ�������������ͷ��ط�������
            int gjl = this.smallSoldierAtk[this.aj][this.ak]; // ��ǰAI����ҵĹ�����
            int fyl = this.smallSoldierDef[this.al][this.am]; // ��ǰ�������ķ�����

            // ���㵱ǰѪ����20��֮һ��Ϊ��С�˺�
            int F = this.smallSoldierBlood[this.aj][this.ak] / 20;

            // ����ϵ������
            float t1 = fyl / 150.0F;
            t1 *= d.hj[fyl - 1]; // ����һ������ϵ��

            // �������յ��˺�ֵ
            float sh = gjl * 1.0F / (1.0F + t1);

            // ��֤�˺�ֵ��������Сֵ
            if (sh < F)
                sh = F;

            // ���Ѫ������200���˺�����
            if (this.smallSoldierBlood[this.aj][this.ak] < 200)
                sh = sh * this.smallSoldierBlood[this.aj][this.ak] / 200.0F;

            // ȷ���˺���СΪ1
            if (sh < 1.0F)
                sh = 1.0F;

            // ����Ƿ񱩻�
            bool isbaoji = false;

            // AI����ʱ�ļ���
            if (aiAtk)
            {
                // ����Ƿ񴥷��ض�����Ч��
                if ((this.ab & 0xF0) == 64)
                {
                    sh = sh * 4.0F / 3.0F; // ��������Ч��
                }
                else if ((this.ab & 0xF0) == 80 && this.smallSoldierKind[this.aj][this.ak] == 2)
                {
                    sh = sh * 5.0F / 3.0F; // ��һ������Ч��
                }

                // �жϲ�ͬ�����Ƿ񴥷����ܱ���
                if (this.smallSoldierKind[this.aj][this.ak] == 0 && getSkill_3(this.AIGeneralId, 0))
                {
                    if (CommonUtils.getRandomInt() % 2 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 0 && getSkill_2(this.AIGeneralId, 9))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                // �������ֱ����Ĵ����߼�����
                if (this.smallSoldierKind[this.aj][this.ak] == 1 && getSkill_2(this.AIGeneralId, 0))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 1 && getSkill_2(this.AIGeneralId, 0) && CommonUtils.getRandomInt() % 5 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
                if (this.smallSoldierKind[this.aj][this.ak] == 2 && getSkill_2(this.AIGeneralId, 2))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 2 && getSkill_2(this.AIGeneralId, 3) && CommonUtils.getRandomInt() % 5 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
                // �жϵ����Ƿ񴥷�����Ч��
                if (getSkill_2(this.AIGeneralId, 4) && this.warTerrain == 9 && !isbaoji)
                {
                    if (CommonUtils.getRandomInt() % 7 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (getSkill_2(this.AIGeneralId, 5) && (this.warTerrain == 10 || this.warTerrain == 11) && !isbaoji && CommonUtils.getRandomInt() % 7 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
            }
            // ��ҽ���ʱ�ļ����߼���������AI
            else
            {
                if ((this.aa & 0xF0) == 64)
                {
                    sh = sh * 4.0F / 3.0F;
                }
                else if ((this.aa & 0xF0) == 80 && this.smallSoldierKind[this.aj][this.ak] == 2)
                {
                    sh = sh * 5.0F / 3.0F;
                }
                if (this.smallSoldierKind[this.aj][this.ak] == 0 && getSkill_3(this.HMGeneralId, 0))
                {
                    if (CommonUtils.getRandomInt() % 2 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 0 && getSkill_2(this.HMGeneralId, 9))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                if (this.smallSoldierKind[this.aj][this.ak] == 1 && getSkill_2(this.HMGeneralId, 0))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 1 && getSkill_2(this.HMGeneralId, 1) && CommonUtils.getRandomInt() % 5 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
                if (this.smallSoldierKind[this.aj][this.ak] == 2 && getSkill_2(this.HMGeneralId, 2))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 2 && getSkill_2(this.HMGeneralId, 2) && CommonUtils.getRandomInt() % 5 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
                if (getSkill_2(this.HMGeneralId, 4) && this.warTerrain == 9 && !isbaoji)
                {
                    if (CommonUtils.getRandomInt() % 7 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (getSkill_2(this.HMGeneralId, 5) && (this.warTerrain == 10 || this.warTerrain == 11) && !isbaoji && CommonUtils.getRandomInt() % 7 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
            }

            // �������յ��˺�ֵ
            return (short)(int)sh;
        }


        // ����ƽ�����ĺ���
        double getSqrt(double a)
        {
            return Math.Sqrt(a); // ʹ��C#�е�Math.Sqrt����
        }

        // ִ��ս���߼�
        void void_B_b(bool flag)
        {
            short sh = sht(flag); // ����sht������ȡ�˺�ֵ

            // ��鼼��3�������˺�ֵ
            if (getSkill_3(this.AIGeneralId, 9) && !flag)
            {
                sh = (short)(sh / 2);
            }
            else if (getSkill_3(this.HMGeneralId, 9) && flag)
            {
                sh = (short)(sh / 2);
            }

            // ��鼼��2������˺�ֵС��30���ܽ��˺�ֵ��Ϊ0
            if (sh < 30)
            {
                if (getSkill_2(this.AIGeneralId, 7) && CommonUtils.getRandomInt() % 3 < 1 && !flag)
                {
                    sh = 0;
                }
                else if (getSkill_2(this.HMGeneralId, 7) && CommonUtils.getRandomInt() % 3 < 1 && flag)
                {
                    sh = 0;
                }
            }

            // ���Ѫ�������ʿ����Ѫ��С��50���Ҳ��ǲ���
            if (this.smallSoldierBlood[this.al][this.am] < 50 && this.smallSoldierKind[this.al][this.am] != 0)
            {
                if (getSkill_2(this.AIGeneralId, 8) && CommonUtils.getRandomInt() % 3 < 1 && !flag)
                {
                    sh = 0;
                }
                else if (getSkill_2(this.HMGeneralId, 8) && CommonUtils.getRandomInt() % 3 < 1 && flag)
                {
                    sh = 0;
                }
            }

            // ������ս�߼�
            if (this.smallSoldierKind[this.al][this.am] == 0)
            {
                if (this.smallSoldierKind[this.aj][this.ak] == 0)
                {
                    this.singleFigth = true; // ���õ���ģʽ
                    return;
                }

                General userGeneral = GeneralListCache.GetGeneral(this.HMGeneralId);
                General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId);

                if (flag)
                {
                    userGeneral.decreaseCurPhysical((byte)(sh / 6));
                    if (userGeneral.getCurPhysical() <= 0)
                    {
                        this.smallSoldier_isSurvive[this.al][this.am] = false;
                    }
                }
                else
                {
                    aiGeneral.decreaseCurPhysical((byte)(sh / 6));
                    if (aiGeneral.getCurPhysical() <= 0)
                    {
                        this.smallSoldier_isSurvive[this.al][this.am] = false;
                    }
                }
            }
            else
            {
                short first = this.smallSoldierBlood[this.al][this.am];
                this.smallSoldierBlood[this.al][this.am] = (short)(this.smallSoldierBlood[this.al][this.am] - sh);

                if (this.smallSoldierBlood[this.al][this.am] <= 0)
                {
                    this.smallSoldier_isSurvive[this.al][this.am] = false;
                    this.smallSoldierBlood[this.al][this.am] = 0;
                    this.smallWarCoordinate[this.smallSoldierCellY[this.al][this.am]][this.smallSoldierCellX[this.al][this.am]] = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[this.al][this.am]][this.smallSoldierCellX[this.al][this.am]] & 0x32);
                    this.smallSoldierCellY[this.al][this.am] = 0;
                    this.smallSoldierCellX[this.al][this.am] = 0;
                }

                short end = this.smallSoldierBlood[this.al][this.am];

                if (this.smallSoldierKind[this.aj][this.ak] == 0)
                {
                    if (flag)
                    {
                        this.AITotalGeneralHurt = (short)(this.AITotalGeneralHurt + first - end);
                    }
                    else
                    {
                        this.HMTotalGeneralHurt = (short)(this.HMTotalGeneralHurt + first - end);
                    }
                }
                else if (flag)
                {
                    this.AITotalSoldierHurt = (short)(this.AITotalSoldierHurt + first - end);
                }
                else
                {
                    this.HMTotalSoldierHurt = (short)(this.HMTotalSoldierHurt + first - end);
                }
            }
        }

        // ��鲢ִ�и��������ʿ��ս���߼�
        void void_L()
        {
            byte byte0 = this.smallSoldierCellX[0][0];
            byte byte1 = this.smallSoldierCellY[0][0];

            for (int i1 = byte0 + 1; i1 < byte0 + 4 && i1 <= 15; i1++)
            {
                for (int j1 = byte1 - 1; j1 < byte1 + 2; j1++)
                {
                    if (j1 >= 0)
                    {
                        if (j1 > 6)
                            break;

                        for (int k1 = 0; k1 < this.aiSmallSoldierNum; k1++)
                        {
                            if (this.smallSoldierCellX[1][k1] == i1 && this.smallSoldierCellY[1][k1] == j1)
                            {
                                if (k1 == 0)
                                {
                                    General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId);
                                    aiGeneral.decreaseCurPhysical((byte)(CommonUtils.getRandomInt() % 1));
                                    if (aiGeneral.getCurPhysical() <= 0)
                                    {
                                        this.smallSoldier_isSurvive[1][0] = false;
                                    }
                                }
                                else if (this.smallSoldier_isSurvive[1][k1])
                                {
                                    this.smallSoldierBlood[1][k1] = (short)(this.smallSoldierBlood[1][k1] - CommonUtils.getRandomInt() % 60 + 50);
                                    if (this.smallSoldierBlood[1][k1] <= 0)
                                    {
                                        this.smallWarCoordinate[this.smallSoldierCellY[1][k1]][this.smallSoldierCellX[1][k1]] = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[1][k1]][this.smallSoldierCellX[1][k1]] & 0x3F);
                                        this.smallSoldierBlood[1][k1] = 0;
                                        this.smallSoldier_isSurvive[1][k1] = false;
                                        this.smallSoldierCellX[1][k1] = 0;
                                        this.smallSoldierCellY[1][k1] = 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        // void_M ������ִ��ʿ��ս���߼�
        void void_m()
        {
            byte byte0 = this.smallSoldierCellX[1][0]; // ��ȡ��1���о�ʿ����X����
            byte byte1 = this.smallSoldierCellY[1][0]; // ��ȡ��1���о�ʿ����Y����

            // �ڵо�ʿ�����������귶Χ������
            for (int i1 = byte0 - 1; i1 > byte0 - 4 && i1 >= 0; i1--)
            {
                for (int j1 = byte1 - 1; j1 < byte1 + 2; j1++)
                {
                    if (j1 >= 0)
                    {
                        if (j1 > 6)
                            break;

                        // ��������ҷ�ʿ����λ��
                        for (int k1 = 0; k1 < this.humanSmallSoldierNum; k1++)
                        {
                            if (this.smallSoldierCellX[0][k1] == i1 && this.smallSoldierCellY[0][k1] == j1)
                            {
                                // �����1���ҷ�ʿ��
                                if (k1 == 0)
                                {
                                    General userGeneral = GeneralListCache.GetGeneral(this.HMGeneralId); // ��ȡ��ҽ���
                                    userGeneral.decreaseCurPhysical((byte)(CommonUtils.getRandomInt() % 21 + 30)); // ��������
                                    if (userGeneral.getCurPhysical() <= 0)
                                        this.smallSoldier_isSurvive[0][0] = false; // ��������ľ������ʿ������
                                }
                                else if (this.smallSoldier_isSurvive[0][k1])
                                {
                                    // ������ʿ������˺�
                                    this.smallSoldierBlood[0][k1] = (short)(this.smallSoldierBlood[0][k1] - (CommonUtils.getRandomInt() % 60 + 50));
                                    if (this.smallSoldierBlood[0][k1] <= 0)
                                    {
                                        // ���ʿ������������ս����ͼ���������
                                        this.smallWarCoordinate[this.smallSoldierCellY[0][k1]][this.smallSoldierCellX[0][k1]] = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[0][k1]][this.smallSoldierCellX[0][k1]] & 0x3F);
                                        this.smallSoldierBlood[0][k1] = 0;
                                        this.smallSoldier_isSurvive[0][k1] = false;
                                        this.smallSoldierCellX[0][k1] = 0;
                                        this.smallSoldierCellY[0][k1] = 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // boolean_g �������ж�AI�Ƿ���
        bool boolean_g()
        {
            byte CITY_NUM = getCanRetreatCityId(this.aiKingId); // ��ȡAI�����Ƿ��п��Գ��˵ĳ���
            byte byte0 = 0;
            General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId); // ��ȡAI����

            // �����������������ҳ϶ȳ���һ��ֵ��AI�����᳷��
            if (aiGeneral.getCurPhysical() > (int)(25.0 - aiGeneral.force * 1.7 / 10.0) || aiGeneral.getLoyalty() > 99)
                return false;

            // �����Χ�ĵз���λ�������㳷�˵Ŀ�����
            if (this.smallSoldierCellY[1][0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][0] - 1][this.smallSoldierCellX[1][0]] & 0x40) != 0)
                byte0 = (byte)(byte0 + 1);
            if (this.smallSoldierCellY[1][0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[1][0] + 1][this.smallSoldierCellX[1][0]] & 0x40) != 0)
                byte0 = (byte)(byte0 + 1);
            if (this.smallSoldierCellX[1][0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][0]][this.smallSoldierCellX[1][0] - 1] & 0x40) != 0)
                byte0 = (byte)(byte0 + 1);
            if (this.smallSoldierCellX[1][0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[1][0]][this.smallSoldierCellX[1][0] + 1] & 0x40) != 0)
                byte0 = (byte)(byte0 + 1);

            // ���ݰ�Χ������ó��˸���
            if (byte0 == 4)
            {
                byte0 = 100;
            }
            else if (byte0 == 3)
            {
                byte0 = 80;
            }
            else if (byte0 == 2)
            {
                byte0 = 60;
            }
            else if (byte0 == 1)
            {
                byte0 = 20;
            }
            else
            {
                return false;
            }

            // ���AI���������ҳ϶Ƚϸߣ����ͳ��˵ĸ���
            if ((aiGeneral.force > 95 || aiGeneral.getLoyalty() > 95) && CITY_NUM > 0)
            {
                byte0 = (byte)(byte0 - 50);
            }
            else if ((aiGeneral.force > 85 || aiGeneral.getLoyalty() > 85) && CITY_NUM > 0)
            {
                byte0 = (byte)(byte0 - 30);
            }
            else if ((aiGeneral.force > 75 || aiGeneral.getLoyalty() > 75) && CITY_NUM > 0)
            {
                byte0 = (byte)(byte0 - 20);
            }

            // �����ҳ϶Ƚ�һ���������˸���
            if (byte0 > 0)
            {
                if (aiGeneral.getLoyalty() < 15)
                {
                    byte0 = (byte)(byte0 + 40);
                }
                else if (aiGeneral.getLoyalty() < 35)
                {
                    byte0 = (byte)(byte0 + 20);
                }
                else if (aiGeneral.getLoyalty() < 50)
                {
                    byte0 = (byte)(byte0 + 10);
                }
            }

            // ���ݼ���ĳ��˸��ʾ����Ƿ���
            return (CommonUtils.getRandomInt() % 100 < byte0);
        }


        // WarGeneralHpSoldierNum �������ж�ս������һ�AI�����״̬����������Ӧ����
        void WarGeneralHpSoldierNum()
        {
            // ������ʿ���Ƿ���
            if (!this.smallSoldier_isSurvive[0][0])
            {
                General userGeneral = GeneralListCache.GetGeneral(this.HMGeneralId); // ��ȡ��ҽ���
                this.wjct = true; // ���Ϊ���ս��

                // �����ҽ��������ľ�
                if (userGeneral.getCurPhysical() <= 0)
                {
                    this.Z = 2; // ���ʧ�ܱ��
                }
                else
                {
                    this.Z = 6; // ���״̬����
                                // �����Ҿ߱��ض����� ���� ��DJΪ��
                    if (getSkill_3(this.HMGeneralId, 0) && this.DJ)
                    {
                        // ������ж��Ƿ񷢶��ؼ�
                        if (CommonUtils.getRandomInt() % 10 > 4)
                        {
                            this.ctsb = true; // ����ؼ���Ч
                            this.ac = (byte)(CommonUtils.getRandomInt() % 5 + 1); // ������������
                            if (this.ac >= userGeneral.getCurPhysical())
                            {
                                this.ac = userGeneral.getCurPhysical();
                                this.Z = 2; // ���ʧ�ܱ��
                            }
                            userGeneral.decreaseCurPhysical(this.ac); // ������ҽ��������
                        }
                    }
                    // ��������£���ͨ����ж�
                    else if (CommonUtils.getRandomInt() % 10 > 1)
                    {
                        this.ctsb = true;
                        this.ac = (byte)(CommonUtils.getRandomInt() % 12 + 2); // ������������
                        if (this.ac >= userGeneral.getCurPhysical())
                        {
                            this.ac = userGeneral.getCurPhysical();
                            this.Z = 2;
                        }
                        userGeneral.decreaseCurPhysical(this.ac);
                    }
                }
                return;
            }

            // ���AIʿ���Ƿ���
            if (!this.smallSoldier_isSurvive[1][0])
            {
                General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId); // ��ȡAI����

                // ���AI���������ľ�
                if (aiGeneral.getCurPhysical() <= 0)
                {
                    this.Z = 1; // AIʧ�ܱ��
                }
                else
                {
                    this.Z = 5; // AI״̬����
                    if (getSkill_5(this.AIGeneralId, 7)) return; // ���AI�߱��ض����ܣ���ǰ����

                    byte bytek = getCanRetreatCityId(this.aiKingId); // ��ȡAI�Ƿ��п��Գ��˵ĳ���
                    if (bytek > 0)
                    {
                        // ���AI�����ϵ�
                        if (aiGeneral.getCurPhysical() <= 10)
                        {
                            this.ac = 0;
                        }
                        // �����������ļ���
                        else if (CommonUtils.getRandomInt() % 10 > 4)
                        {
                            this.ac = (byte)(CommonUtils.getRandomInt() % 4 + 1);
                            if (this.ac >= aiGeneral.getCurPhysical())
                            {
                                this.ac = aiGeneral.getCurPhysical();
                                this.Z = 1; // AIʧ�ܱ��
                            }
                            aiGeneral.decreaseCurPhysical(this.ac); // ����AI���������
                        }
                    }
                    // ���������������
                    else if (CommonUtils.getRandomInt() % 10 > 1)
                    {
                        this.ac = (byte)(CommonUtils.getRandomInt() % 12 + 2);
                        if (this.ac >= aiGeneral.getCurPhysical())
                        {
                            this.ac = aiGeneral.getCurPhysical();
                            this.Z = 1;
                        }
                        aiGeneral.decreaseCurPhysical(this.ac);
                    }
                }
            }
        }

        // AfterWarSettlement ����������ս����������о���ֵ����
        void AfterWarSettlement()
        {
            short word0 = this.sd1;
            short word1 = this.sd2;

            General userGeneral = GeneralListCache.GetGeneral(this.HMGeneralId); // ��ȡ��ҽ���
            userGeneral.generalSoldier = 0; // ��ʼ����ҽ���ʿ������

            // ͳ�����ʿ��ʣ������
            for (byte byte0 = 1; byte0 < this.humanSmallSoldierNum; byte0 = (byte)(byte0 + 1))
            {
                userGeneral.generalSoldier = (short)(userGeneral.generalSoldier + this.smallSoldierBlood[0][byte0]);
                if (userGeneral.generalSoldier > userGeneral.getMaxGeneralSoldier())
                    userGeneral.generalSoldier = userGeneral.getMaxGeneralSoldier(); // ȷ�����������ʿ����
            }

            General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId); // ��ȡAI����
            aiGeneral.generalSoldier = 0; // ��ʼ��AI����ʿ������

            // ͳ��AIʿ��ʣ������
            for (byte byte1 = 1; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
            {
                aiGeneral.generalSoldier = (short)(aiGeneral.generalSoldier + this.smallSoldierBlood[1][byte1]);
                if (aiGeneral.generalSoldier > aiGeneral.getMaxGeneralSoldier())
                    aiGeneral.generalSoldier = aiGeneral.getMaxGeneralSoldier(); // ȷ�����������ʿ����
            }

            // ���㾭��ֵ����
            int expHM = word1 - aiGeneral.generalSoldier;
            int expAI = word0 - userGeneral.generalSoldier;

            // ���侭��ֵ
            addExp_P(this.HMGeneralId, this.AIGeneralId, expHM);
            addExp_P(this.AIGeneralId, this.HMGeneralId, expAI);

            // �����쵼����������
            GeneralListCache.addLeadExp(this.HMGeneralId, (byte)(this.HMTotalSoldierHurt / 300));
            GeneralListCache.addLeadExp(this.AIGeneralId, (byte)(this.AITotalSoldierHurt / 300));
            GeneralListCache.addforceExp(this.HMGeneralId, (byte)(this.HMTotalGeneralHurt / 50));
            GeneralListCache.addforceExp(this.AIGeneralId, (byte)(this.AITotalGeneralHurt / 50));

            // �������˺�ͳ��
            this.HMTotalSoldierHurt = 0;
            this.AITotalSoldierHurt = 0;
            this.HMTotalGeneralHurt = 0;
            this.AITotalGeneralHurt = 0;

            // �ض�����Ч�� ���� ����
            if (getSkill_3(this.AIGeneralId, 6) && aiGeneral.generalSoldier > 0)
            {
                if (CommonUtils.getRandomInt() % 10 < 2)
                    aiGeneral.generalSoldier = (short)(aiGeneral.generalSoldier + expAI / 3);
                if (aiGeneral.generalSoldier > aiGeneral.getMaxGeneralSoldier())
                    aiGeneral.generalSoldier = aiGeneral.getMaxGeneralSoldier();
            }

            // �������״̬�µ�ʿ����������
            if (this.wjct && this.ctsb)
            {
                if (userGeneral.generalSoldier > 0)
                {
                    int i = CommonUtils.getRandomInt() % 15 + 3;
                    this.jsbl = (short)(i * 15); // ���㽻����ʿ������

                    if (this.i_boolean_fld)
                        this.jsbl = (short)(this.jsbl + 250); // ������������ӽ�������

                    if (getSkill_5(this.AIGeneralId, 7))
                        this.jsbl = (short)(this.jsbl / 2); // ���AI�����⼼�ܣ����ٽ�����

                    if (userGeneral.generalSoldier < this.jsbl)
                        this.jsbl = userGeneral.generalSoldier;

                    userGeneral.generalSoldier = (short)(userGeneral.generalSoldier - this.jsbl); // �������ʿ��
                    if (userGeneral.generalSoldier < 0)
                        userGeneral.generalSoldier = 0;

                    aiGeneral.generalSoldier = (short)(aiGeneral.generalSoldier + this.jsbl); // ����AIʿ��
                    if (aiGeneral.generalSoldier > aiGeneral.getMaxGeneralSoldier())
                        aiGeneral.generalSoldier = aiGeneral.getMaxGeneralSoldier();
                }
                return;
            }

            // �����Ҿ����ض�����
            if (getSkill_3(this.HMGeneralId, 6) && userGeneral.generalSoldier > 0)
            {
                if (CommonUtils.getRandomInt() % 10 < 2)
                    userGeneral.generalSoldier = (short)(userGeneral.generalSoldier + expHM / 3);
                if (userGeneral.generalSoldier > userGeneral.getMaxGeneralSoldier())
                    userGeneral.generalSoldier = userGeneral.getMaxGeneralSoldier();
            }
        }



        // ����: void_P
        public void void_P()
        {
            AfterWarSettlement(); // ���� AfterWarSettlement ����
            if (this.i_boolean_fld) // �ж� i_boolean_fld �Ƿ�Ϊ true
            {
                this.j_byte_fld = 2; // ���Ϊ true���� j_byte_fld ����Ϊ 2
            }
            else
            {
                this.j_byte_fld = 3; // ��������Ϊ 3
            }
        }

        // ����: newArray
        public byte[] newArray(byte Length)
        {
            byte[] array = new byte[Length]; // ����һ������Ϊ Length �� byte ����
            for (byte i = 0; i < Length; i = (byte)(i + 1)) // �������鲢���
                array[i] = i;
            return array; // �������������
        }

        // ����: PrepareWarStancejgjbh
        public void PrepareWarStancejgjbh()
        {
            this.smallSoldierBlood[0][0] = (short)(300 * GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical() / (GeneralListCache.GetGeneral(this.HMGeneralId)).maxPhysical); // ���� smallSoldierBlood ��ֵ
            if (GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical() * 2 < (GeneralListCache.GetGeneral(this.HMGeneralId)).maxPhysical) // �жϵ�ǰ�����Ƿ�С�����������һ��
                this.smallSoldierBlood[0][0] = 200; // ���С�ڣ������� smallSoldierBlood ��ֵΪ 200
        }


        // ������void_Q
        void void_Q()
        {
            // ���õ�����־Ϊ false
            this.singleFigth = false;

            // ����˫��ʿ����������
            byte[] hmIndex = new byte[this.humanSmallSoldierNum];
            byte[] aiIndex = new byte[this.aiSmallSoldierNum];

            // ��ʼ���ʹ�������
            hmIndex = newArray((byte)hmIndex.Length);
            aiIndex = newArray((byte)aiIndex.Length);
            hmIndex = randomArray(hmIndex);
            aiIndex = randomArray(aiIndex);

            // ��� j_byte_fld Ϊ 0����ʼ��ս��״̬
            if (this.j_byte_fld == 0)
            {
                //this.gamecanvas.s_byte_fld = 0;
                this.aq = 0;
                this.d_int_fld = 0;

                // �ж� AI �Ƿ񹥻����
                if (this.aiAtkHm)
                {
                    this.ar = 1;
                }
                else
                {
                    this.ar = 0;
                }

                this.e_int_fld = 0;
                this.a_s = 0;
                this.ao = 0;
                this.ap = 0;
                this.at = 0;
            }
            else
            {
                // ���� j_byte_fld
                this.j_byte_fld = 0;
            }

            // ��ȡ��ǰϵͳʱ�䣬���ڿ���֡��
            long l1 = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;

            // ������ѭ����ֱ�� j_byte_fld ���� 0 Ϊֹ
            bool outerLoop = true;
            while (this.j_byte_fld <= 0)
            {
                // �����⵽������룬��������
                if (Input.touchCount > 0)
                {
                    //this.gamecanvas.void_g();
                    //this.gamecanvas.setKeyValue((byte)0);

                    // ����ǵ���ģʽ��ִ����ز���
                    if (this.singleFigth)
                    {
                        void_S();
                        void_T();
                        //this.gamecanvas.s_void_b_a((byte)21);
                        //this.gamecanvas.battlefieldSatge = 2;
                    }
                }

                // �������ϴ�ѭ����ʱ���
                long l2 = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond - l1;

                // ����֡�ʣ�ÿ��ѭ�����ټ�� 15 ����
                if (l2 < 15L)
                {
                    try
                    {
                        lock (this)
                        {
                            Thread.Sleep((int)(15L - l2));
                        }
                    }
                    catch (Exception exception) { }
                }

                // ���»�����Ϸ����
                //this.gamecanvas.repaint();

                // ���µ�ǰʱ��
                l1 = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;

                // ���ս��״̬
                if (this.ad != 2 && this.Z <= 0)
                {
                    if (this.aa != 0)
                    {
                        if (this.e_int_fld == 0)
                        {
                            this.e_int_fld = this.d_int_fld;
                            this.a_s = this.humanSmallSoldierNum;
                        }
                        else if (this.d_int_fld > this.e_int_fld && this.humanSmallSoldierNum >= this.a_s)
                        {
                            this.e_int_fld = this.d_int_fld;
                            this.aa = (byte)(this.aa - 1);

                            // ����غϽ����߼�
                            if ((this.aa & 0xF) == 0)
                            {
                                this.aa = 0;
                                this.e_int_fld = 0;
                            }
                        }
                    }

                    // ���»غϼ���
                    this.at = (byte)(this.at + 1);

                    // ����Ƿ���Խ�����һ�׶�
                    if (!(Input.touchCount > 0))
                    {
                        if (this.ai > 0)
                        {
                            this.a_boolean_array2d_fld[this.al][this.am] = true;
                            this.ai = (byte)(this.ai - 1);

                            // AI ִ�в���
                            if (this.ai == 0)
                            {
                                void_B_b(this.k_boolean_fld);
                                this.at = 0;
                                WarGeneralHpSoldierNum();

                                if (this.singleFigth)
                                {
                                    void_S();
                                    void_T();
                                    //this.gamecanvas.s_void_b_a((byte)21);
                                    //this.gamecanvas.battlefieldSatge = 2;
                                    this.singleFigth = false;
                                }
                            }
                            continue;
                        }

                        // ����Ƿ���ս���׶�
                        if (!(Input.touchCount > 0))
                        {
                            if (this.at >= 10)
                            {
                                WarGeneralHpSoldierNum();
                                if (this.Z <= 0)
                                {
                                    this.at = 0;

                                    // ��鵱ǰ�غ�״̬
                                    if (this.ar > 1)
                                    {
                                        this.d_int_fld++;
                                        hmIndex = randomArray(hmIndex);
                                        this.ao = 0;
                                        aiIndex = randomArray(aiIndex);
                                        this.ap = 0;
                                        this.ar = 0;
                                    }

                                    // ���ִ�в���
                                    if (this.ar != 0)
                                    {
                                        if (this.ar == 1)
                                        {
                                            this.n_boolean_fld = false;
                                            void_i_f(this.d_int_fld);

                                            while (true)
                                            {
                                                if (aiIndex[this.ap] == 0 && (this.aa & 0xF0) == 16)
                                                {
                                                    this.n_boolean_fld = boolean_b_m((byte)0);
                                                }
                                                else
                                                {
                                                    this.n_boolean_fld = boolean_b_o(aiIndex[this.ap]);
                                                }

                                                // ��� AI ʿ���Ƿ�����»غ�״̬
                                                if (!this.smallSoldier_isSurvive[1][aiIndex[this.ap]] || this.smallSoldierKind[1][aiIndex[this.ap]] >= 2 || this.aq >= 1)
                                                {
                                                    this.ap = (byte)(this.ap + 1);
                                                    this.aq = 0;
                                                }
                                                else
                                                {
                                                    this.aq = (byte)(this.aq + 1);
                                                }

                                                // ��� AI ʿ�������Ƿ�������
                                                if (this.ap == this.aiSmallSoldierNum)
                                                {
                                                    this.aq = 0;
                                                    this.ar = 2;
                                                    outerLoop = false;  // �˳������ѭ��
                                                }

                                                // ����ҵ�����������AIʿ����������ǰ�غ�
                                                if (this.n_boolean_fld)
                                                    outerLoop = false;  // �˳������ѭ��
                                            }
                                        }
                                        continue;
                                    }

                                    // ��Ҳ���
                                    this.n_boolean_fld = false;
                                    while (true)
                                    {
                                        this.n_boolean_fld = boolean_b_i(hmIndex[this.ao]);

                                        // ������ʿ���Ƿ���
                                        if (!this.smallSoldier_isSurvive[0][hmIndex[this.ao]] || this.smallSoldierKind[0][hmIndex[this.ao]] >= 2 || this.aq >= 1)
                                        {
                                            this.ao = (byte)(this.ao + 1);
                                            this.aq = 0;
                                        }
                                        else
                                        {
                                            this.aq = (byte)(this.aq + 1);
                                        }

                                        // ������ʿ�������Ƿ�������
                                        if (this.ao == this.humanSmallSoldierNum)
                                        {
                                            this.aq = 0;
                                            this.ar = 1;

                                            // ����Ƿ���Ҫ������һ�غ�
                                            if (boolean_g())
                                            {
                                                this.Z = 3;
                                                outerLoop = false;  // �˳������ѭ��
                                            }

                                            // ���»غ�״̬
                                            if (this.ab == 0)
                                                outerLoop = false;  // �˳������ѭ��

                                            if ((this.ab & 0xF) == 0)
                                            {
                                                this.ab = 0;
                                                outerLoop = false;  // �˳������ѭ��
                                            }

                                            this.ab = (byte)(this.ab - 1);
                                            outerLoop = false;  // �˳������ѭ��
                                        }

                                        // ����ҵ��������������ʿ����������ǰ�غ�
                                        if (this.n_boolean_fld)
                                            outerLoop = false;  // �˳������ѭ��
                                    }
                                }
                            }
                            continue;
                        }

                        // ������Ϸ����״̬
                        if (this.ag > 0 && (this.ag = (byte)(this.ag - 1)) == 0)
                        {
                            void_L();
                            //this.gamecanvas.v_boolean_fld = false;
                            this.at = 0;
                        }

                        if (this.ah > 0 && (this.ah = (byte)(this.ah - 1)) == 0)
                        {
                            void_m();
                            //this.gamecanvas.w_boolean_fld = false;
                        }
                    }
                }
            }

            // ����AI�������״̬
            this.aiAtkHm = false;
        }

        // �ж������AI����Ķ�ս���
        bool boolean_ss_b(short userGeneralId, short aiGeneralId)
        {
            // �������dttbΪtrue��ֱ�ӷ���false����ִ�к����߼�
            if (this.dttb)
                return false;

            // ��ȡ�����AI�����������ֵ������20���ڼ������
            int i1 = (GeneralListCache.GetGeneral(userGeneralId).force - GeneralListCache.GetGeneral(aiGeneralId).force) / 20;

            // ʹ����������������ж��Ƿ�����ָ����������
            // this.random��Java�е�Random�࣬��C#��ʹ��System.Random
            return (this.random.Next() % 10 < 4 + i1);
        }


        bool boolean_ss_gj_b(short word0, short word1)
        {
            // ��ȡ˫����������������15��ΪӰ������
            int i1 = ((GeneralListCache.GetGeneral(word0)).force - (GeneralListCache.GetGeneral(word1)).force) / 15;

            // ͨ����������жϽ��
            return (this.random.Next() % 10 < 10 + i1);
        }

        byte byte_ss_a(short word0, short word1)
        {
            // ��ǰ��������20�������Ϊż��������4
            if (GeneralListCache.GetGeneral(word0).getCurPhysical() < 20 && CommonUtils.getRandomInt() % 2 == 0)
                return 4;

            // ��ǰ�����������������һ���ҶԷ������������10�������С��3ʱ����2
            if (GeneralListCache.GetGeneral(word0).getCurPhysical() < GeneralListCache.GetGeneral(word0).maxPhysical / 2 &&
                GeneralListCache.GetGeneral(word1).getCurPhysical() - GeneralListCache.GetGeneral(word0).getCurPhysical() > 10 &&
                CommonUtils.getRandomInt() % 10 < 3)
                return 2;

            // ��ǰ�������ڶԷ�����ʱ���������������0��1
            if (GeneralListCache.GetGeneral(word0).getCurPhysical() < GeneralListCache.GetGeneral(word1).getCurPhysical())
                return (byte)((CommonUtils.getRandomInt() % 10 >= 6) ? 0 : 1);

            // ����������������1��0
            return (byte)((CommonUtils.getRandomInt() % 10 >= 6) ? 1 : 0);
        }

        byte byte_ss_b(short word0, short word1)
        {
            // ����AISingleOrder���������ؽ��
            return AISingleOrder(word0, word1);
        }

        byte weaponEffect(short atkGeneralId, short defGeneralId, byte sc, bool sm)
        {
            // ��ȡ���������������ͺͷ��ط��ķ�������
            byte a = (GeneralListCache.GetGeneral(atkGeneralId)).weapon;
            byte b = (GeneralListCache.GetGeneral(defGeneralId)).armor;

            // ���������ͷ��ߵ����͵���sc��ֵ
            if (a == 5 && sm)
                sc = (byte)(sc + 20);
            if ((a == 6 || a == 7 || a == 14) && !sm)
                sc = (byte)(sc + 15);
            if (b == 30 && !sm)
                sc = (byte)(sc - 15);
            if (b == 31 && !sm)
                sc = (byte)(sc - 20);
            else if (b == 31 && sm)
                sc = 0;

            // ���ص������sc
            return sc;
        }

        byte getPercentage(short atkId, short defId, bool sm, bool HMatk)
        {
            byte sc = 0;
            byte weaponType1 = (byte)((GeneralListCache.GetGeneral(atkId)).weapon / 8);
            byte b = (byte)((GeneralListCache.GetGeneral(defId)).weapon / 8);

            // ����˫���������������û���������
            if (weaponType1 == 0 && b == 0)
                sc = 70;
            else if (weaponType1 == 0 && b == 1)
                sc = 75;
            else if (weaponType1 == 0 && b == 2)
                sc = 60;
            else if (weaponType1 == 1 && b == 0)
                sc = 55;
            else if (weaponType1 == 1 && b == 1)
                sc = 60;
            else if (weaponType1 == 1 && b == 2)
                sc = 70;
            else if (weaponType1 == 2 && b == 0)
                sc = 80;
            else if (weaponType1 == 2 && b == 1)
                sc = 50;
            else if (weaponType1 == 2 && b == 2)
                sc = 60;

            // ���ݹ�����ʽ����������
            if (HMatk)
                sc = (byte)(sc - 20);
            if (sm && HMatk)
                sc = (byte)(sc / 3);
            else if (sm && !HMatk)
                sc = (byte)(sc / 2);

            // ʹ��weaponEffect������һ������������
            sc = weaponEffect(atkId, defId, sc, sm);

            // �������յ�������
            return sc;
        }

        void void_S()
        {
            this.m_boolean_fld = false;

            // ���AI�����Ƿ�����ض�ID��������ر�־
            if (this.AIGeneralId == 1 || this.AIGeneralId == 4 || this.AIGeneralId == 24 || this.AIGeneralId == 30 || this.AIGeneralId == 40 || this.AIGeneralId == 61 || this.AIGeneralId == 69)
            {
                Country country = CountryListCache.GetCountryByKingId(this.AIGeneralId);
                if ((CityListCache.GetCityByCityId(curWarCityId)).cityBelongKing == country.countryKingId && country.GetHaveCityNum() <= 1)
                    this.m_boolean_fld = true;
            }

            // ��¼˫���ĳ�ʼ����
            this.HMfirstPhy = GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical();
            this.AIfirstPhy = GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical();
        }

        void void_B_c(bool flag)
        {
            // ����flag��ֵ���ò�ͬ��Ӫ��ʿ��ָ��
            if (flag)
            {
                for (byte byte0 = 0; byte0 < this.aiSmallSoldierNum; byte0 = (byte)(byte0 + 1))
                    this.smallSoldierOrder[1][byte0] = 2;
            }
            else
            {
                this.smallSoldierOrder[0][0] = 2;
                for (byte byte1 = 0; byte1 < 4; byte1 = (byte)(byte1 + 1))
                    this.P_byte_array1d_fld[byte1] = 2;
            }
        }

        int obtainWeaponOrArmor()
        {
            // ���m_boolean_fldΪtrue������AI����ID�������������
            if (this.m_boolean_fld)
            {
                if (this.AIGeneralId == 61)
                {
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).weapon = 6;
                    return 0;
                }
                if (this.AIGeneralId == 4)
                {
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).armor = 31;
                    return 1;
                }
                if (this.AIGeneralId == 1)
                {
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).weapon = 7;
                    return 2;
                }
                if (this.AIGeneralId == 24)
                {
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).weapon = 5;
                    return 3;
                }
                if (this.AIGeneralId == 69 || this.AIGeneralId == 30 || this.AIGeneralId == 40)
                {
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).weapon = 14;
                    return 4;
                }
            }
            return 0;
        }


        // ���巽�� void_T����Unity������
        void void_T()
        {
            //this.gamecanvas.s_void_b_a((byte)22); // ���� gamecanvas �ķ���
            while (true)
            {
                // ��ȡ��ǰʱ���
                long l1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                // ��鰴������
                if (Input.touchCount > 0)
                {
                    //this.gamecanvas.void_f(); // ���������ֵ�ķ���
                    //this.gamecanvas.setKeyValue((byte)0); // ���ü�ֵΪ0
                }

                // �������ĵ�ʱ��
                long l2 = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - l1;
                if (l2 < 500L)
                {
                    try
                    {
                        // �߳����ߣ���֤���
                        Thread.Sleep((int)(50L - l2));
                    }
                    catch (Exception exception) { }
                }

                // �ػ����
                //this.gamecanvas.repaint();

                // ����Ƿ��ڵ���ս��״̬
                if (!this.singleFigth)
                {
                    SingleFightaddforceExp(); // ����ս������
                    return;
                }
            }
        }

        // ����ս��������ս������ķ���
        void SingleFightaddforceExp()
        {
            General userGeneral = GeneralListCache.GetGeneral(this.HMGeneralId); // ��ȡ��ҵĽ���
            int userCurPhysical = 0;
            if (userGeneral != null)
                userCurPhysical = userGeneral.getCurPhysical(); // ��ȡ��ҵ�ǰ����

            int aiCurPhysical = 0;
            General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId); // ��ȡAI����
            if (aiGeneral != null)
                aiCurPhysical = aiGeneral.getCurPhysical(); // ��ȡAI��ǰ����

            // ���㾭��ֵ
            int aiExp = (int)((this.HMfirstPhy - userCurPhysical) * 1.2D);
            int hmExp = this.AIfirstPhy - aiCurPhysical;
            aiExp /= 3;
            hmExp /= 3;

            // ���þ���ֵ�����޺�����
            if (aiExp <= 0)
                aiExp = 2;
            if (hmExp < 0)
                hmExp = 0;
            if (aiExp >= 20)
                aiExp = 20;
            if (hmExp >= 20)
                hmExp = 20;

            // ��ӽ��쾭��
            GeneralListCache.addforceExp(this.AIGeneralId, (byte)aiExp);
            GeneralListCache.addforceExp(this.HMGeneralId, (byte)hmExp);

            // ���ó�ʼ����
            this.HMfirstPhy = 0;
            this.AIfirstPhy = 0;
        }

        // ģ��������AI��ս������
        void hm_AI_Moni()
        {
            int hmpower = 0;  // ���ս��
            int aipower = 0;  // AIս��
            int hmpf = 0;     // ���ս��ϵ��
            int aipf = 0;     // AIս��ϵ��
            int i;

            // ���С��ս��������
            for (i = 1; i < this.humanSmallSoldierNum; i++)
            {
                int theAtk = this.smallSoldierAtk[0][i];  // С��������
                int theDef = this.smallSoldierDef[0][i];  // С��������

                // ��鼼�ܴ���������������
                if (getSkill_2(this.HMGeneralId, 7) && CommonUtils.getRandomInt() % 10 > 6)
                    theDef += theDef / 2;
                if (getSkill_2(this.HMGeneralId, 8) && CommonUtils.getRandomInt() % 10 > 6)
                    theDef += theDef / 2;

                // �����������ܣ����ӹ����ͷ�����
                if (getSkill_3(this.HMGeneralId, 9))
                {
                    theAtk += theAtk / 2;
                    theDef += theDef / 2;
                }

                // ���ݱ��ֵ���ս����
                if (this.smallSoldierKind[0][i] == 1)  // ����1�Ĵ���
                {
                    // ��鼼�ܲ����ӹ�����
                    if (getSkill_2(this.HMGeneralId, 0) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 2;
                    else if (getSkill_2(this.HMGeneralId, 1) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 3;

                    // �ض����μӳ�
                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.HMGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 1) + theAtk * this.V / 8;
                    hmpower += p * p;
                }
                else if (this.smallSoldierKind[0][i] == 2)  // ����2�Ĵ���
                {
                    // �ض����ܺ͵��μӳ�
                    if (getSkill_2(this.HMGeneralId, 6) && CommonUtils.getRandomInt() % 10 > 3)
                        theAtk += theAtk / 2;
                    if (getSkill_2(this.HMGeneralId, 2) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 2;
                    else if (getSkill_2(this.HMGeneralId, 3) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 3;

                    // �������������ܼӳ�
                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.HMGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;
                    if (this.warTerrain == 9 && getSkill_2(this.HMGeneralId, 4) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    // ���ݵ�ǰ����Ϸ״̬���д���
                    if (!this.i_boolean_fld && this.j_boolean_fld)
                    {
                        if (this.V >= 14)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 3 + 3);
                            hmpower += p * p;
                        }
                        else if (this.V >= 10)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 3);
                            hmpower += p * p;
                        }
                        else if (this.V >= 8)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 3 + 2);
                            hmpower += p * p;
                        }
                        else if (this.V >= 7)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 2);
                            hmpower += p * p;
                        }
                        else
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 1);
                            hmpower += p * p;
                        }
                    }
                    else
                    {
                        int p = (theAtk + theDef) * 2 + theAtk * CommonUtils.getRandomInt() % 2 + theAtk * this.V / 7;
                        hmpower += p * p;
                    }
                }
                else  // �������ִ���
                {
                    // �ض����μӳ�
                    if (this.warTerrain == 9 && getSkill_2(this.HMGeneralId, 4) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;
                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.HMGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    int p = (theAtk + theDef) * 2 / 3;
                    hmpower += p * p;
                }
            }

            // AIС��ս�������㣬�߼�ͬ��
            for (i = 1; i < this.aiSmallSoldierNum; i++)
            {
                int theAtk = this.smallSoldierAtk[1][i];
                int theDef = this.smallSoldierDef[1][i];

                if (getSkill_2(this.AIGeneralId, 7) && CommonUtils.getRandomInt() % 10 > 6)
                    theDef += theDef / 2;
                if (getSkill_2(this.AIGeneralId, 8) && CommonUtils.getRandomInt() % 10 > 6)
                    theDef += theDef / 2;

                if (getSkill_3(this.AIGeneralId, 9))
                {
                    theAtk += theAtk / 2;
                    theDef += theDef / 2;
                }

                if (this.smallSoldierKind[1][i] == 1)
                {
                    if (getSkill_2(this.AIGeneralId, 0) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 2;
                    else if (getSkill_2(this.AIGeneralId, 1) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 3;

                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.AIGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 1) + theAtk * this.W / 8;
                    aipower += p * p;
                }
                else if (this.smallSoldierKind[1][i] == 2)
                {
                    if (getSkill_2(this.AIGeneralId, 6) && CommonUtils.getRandomInt() % 10 > 3)
                        theAtk += theAtk / 2;
                    if (getSkill_2(this.AIGeneralId, 2) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 2;
                    else if (getSkill_2(this.AIGeneralId, 3) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 3;

                    if (this.warTerrain == 9 && getSkill_2(this.AIGeneralId, 4) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;
                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.AIGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    if (this.i_boolean_fld && this.j_boolean_fld)
                    {
                        if (this.W >= 14)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 3 + 3);
                            aipower += p * p;
                        }
                        else if (this.W >= 10)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 3);
                            aipower += p * p;
                        }
                        else if (this.W >= 8)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 3 + 2);
                            aipower += p * p;
                        }
                        else if (this.W >= 7)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 2);
                            aipower += p * p;
                        }
                        else
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 1);
                            aipower += p * p;
                        }
                    }
                    else
                    {
                        int p = (theAtk + theDef) * 2 + theAtk * CommonUtils.getRandomInt() % 2 + theAtk * this.W / 7;
                        aipower += p * p;
                    }
                }
                else
                {
                    if (this.warTerrain == 9 && getSkill_2(this.AIGeneralId, 4) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;
                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.AIGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    int p = (theAtk + theDef) * 2 / 3;
                    aipower += p * p;
                }
            }

            // �ж�ս�����
            if (hmpower > aipower)
            {
                // ���ʤ��
            }
            else if (hmpower < aipower)
            {
                // AIʤ��
            }
            else
            {
                // ƽ��
            }
        }



        // ģ��ս��������������
        void void_U()
        {
            this.j_byte_fld = 0;  // ��ʼ��״̬��־
            //this.gamecanvas.finishMoni = false;  // ����ģ��ս��������־Ϊfalse
            void_J();  // ���÷���J����ʼ�����״̬
            void_K();  // ���÷���K����ʼ�����״̬
            this.sd1 = GeneralListCache.GetGeneral(this.HMGeneralId).generalSoldier;  // ��ȡ��ҽ�����ʿ����Ϣ
            this.sd2 = GeneralListCache.GetGeneral(this.AIGeneralId).generalSoldier;  // ��ȡAI������ʿ����Ϣ

            // ���ģ��ս���ѽ���
            if (Input.touchCount > 0)
            {
                if (this.i_boolean_fld)  // ���ʤ��
                {
                    this.j_byte_fld = 2;
                }
                else  // AIʤ��
                {
                    this.j_byte_fld = 3;
                }
                return;
            }

            this.j_byte_fld = 0;  // ���³�ʼ��״̬��־

            while (true)
            {
                this.l_boolean_fld = false;  // ��λ��־
                void_Q();  // ���÷���Q������ǰѭ���߼�

                // �ж�ս��״̬
                if (this.j_byte_fld != 1)
                {
                    if (this.j_byte_fld == 2)
                    {
                        void_P();  // ���ս�����������÷���P��������߼�
                        return;
                    }
                }
            }
        }

        // �жϽ����Ƿ���������������Ӧ����
        bool GeneralDie(short generalId, bool isUser)
        {
            if (isUser)  // �������ҵĽ�������
            {
                if (generalId == this.humanGeneralId_inWar[0])  // �ж���ҵ���Ҫ�����Ƿ�����
                {
                    this.bxct = true;  // ����ս��������־
                    this.j_byte_fld = 2;  // ����ս��״̬Ϊ����
                    this.h_boolean_fld = true;  // �������ʤ����־
                    this.humanUnitTrapped[0] = 3;  // ����ҵ���Ҫ�������Ϊ������
                    this.bigWar_coordinate[this.humanUnitCellY[0],this.humanUnitCellX[0]] = (byte)(this.bigWar_coordinate[this.humanUnitCellY[0],this.humanUnitCellX[0]] & 0x3F);  // ����ս������

                    if (this.humanGeneralId_inWar[0] == this.userKingId)  // �������������ҵĹ���
                        GeneralListCache.GeneralDie(generalId);  // ���û��棬�����������߼�

                    for (byte b1 = 0; b1 < this.aiGeneralNum_inWar; b1++)  // ���AI�����Ľ���
                    {
                        if (this.aiUnitTrapped[b1] == 2)
                            this.aiUnitTrapped[b1] = 0;
                    }

                    this.N_byte_fld = 1;
                    byte byte1;

                    // ѭ��������Ȼ������ҽ���
                    for (byte1 = 1; byte1 < this.humanGeneralNum_inWar && this.humanUnitTrapped[byte1] != 0 && this.humanUnitTrapped[byte1] <= 3;)
                        byte1++;

                    if (byte1 < this.humanGeneralNum_inWar)  // ������д��Ľ���
                    {
                        FindRetreatCity(curWarCityId);  // ����ǰ��������߼�
                        this.N_byte_fld = byte1;  // ���´������
                        this.HMGeneralId = this.humanGeneralId_inWar[this.N_byte_fld];  // �����µ���ҽ���
                        //this.gamecanvas.void_c();  // ����UI��ʾ
                        //this.gamecanvas.void_B_a(true);  // ����ս��״̬
                        //this.gamecanvas.k_boolean_fld = false;  // ���ñ�־
                        //this.gamecanvas.l_boolean_fld = true;  // ���±�־
                    }
                    else  // �����ҽ���ȫ������
                    {
                        if (this.AIAttackHM)  // ���AI�ڹ������
                            void_z();  // ����AI���������߼�
                        void_A();  // ����ս�������߼�
                        return false;
                    }
                }

                // ���������ҽ����Ƿ�����
                for (byte index = 1; index < this.humanGeneralNum_inWar; index++)
                {
                    if (this.humanGeneralId_inWar[index] == generalId)
                    {
                        this.humanUnitTrapped[index] = 3;  // �������Ľ������Ϊ����
                        this.bigWar_coordinate[this.humanUnitCellY[index],this.humanUnitCellX[index]] = (byte)(this.bigWar_coordinate[this.humanUnitCellY[index],this.humanUnitCellX[index]] & 0x3F);  // ����ս������
                        return true;
                    }
                }
            }
            else  // �����AI��������
            {
                if (generalId == this.aiGeneralId_inWar[0])  // �ж�AI��Ҫ�����Ƿ�����
                {
                    this.j_byte_fld = 2;  // ����ս��״̬Ϊ����
                    this.aiUnitTrapped[0] = 3;  // ��AI��Ҫ�������Ϊ������
                    this.bigWar_coordinate[this.aiUnitCellY[0],this.aiUnitCellX[0]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[0],this.aiUnitCellX[0]] & 0x3F);  // ����ս������

                    // �����ұ����Ľ���
                    for (byte b = 1; b < this.humanGeneralNum_inWar; b++)
                    {
                        if (this.humanUnitTrapped[b] == 2)
                            this.humanUnitTrapped[b] = 0;
                    }

                    //this.gamecanvas.r_byte_fld = 5;  // ������ϷUI��־
                    return true;
                }

                // �������AI�����Ƿ�����
                for (byte index = 1; index < this.aiGeneralNum_inWar; index++)
                {
                    if (this.aiGeneralId_inWar[index] == generalId)
                    {
                        this.aiUnitTrapped[index] = 3;  // ��AI�������Ϊ����
                        this.bigWar_coordinate[this.aiUnitCellY[index],this.aiUnitCellX[index]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[index],this.aiUnitCellX[index]] & 0x3F);  // ����ս������
                        return true;
                    }
                }
            }

            return true;  // Ĭ�Ϸ���true��ʾ�������
        }


        // �������Ƿ������������߼�
        bool boolean_sB_b(short generalId, bool isUser)
        {
            if (isUser)  // ��������
            {
                if (generalId == this.humanGeneralId_inWar[0])  // �������ҵ���Ҫ����
                {
                    this.bxct = true;  // ����ս��������־
                    this.j_byte_fld = 2;  // ����ս��״̬
                    this.h_boolean_fld = true;  // �������ʤ����־
                    this.humanUnitTrapped[0] = 2;  // �����ҽ����ѱ���
                    this.bigWar_coordinate[this.humanUnitCellY[0],this.humanUnitCellX[0]] = (byte)(this.bigWar_coordinate[this.humanUnitCellY[0],this.humanUnitCellX[0]] & 0x3F);  // ����ս������

                    // ���AI��������
                    for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0++)
                    {
                        if (this.aiUnitTrapped[byte0] == 2)
                            this.aiUnitTrapped[byte0] = 0;
                    }

                    this.N_byte_fld = 1;
                    byte byte1;
                    // ������һ��δ�����Ľ���
                    for (byte1 = 1; byte1 < this.humanGeneralNum_inWar && this.humanUnitTrapped[byte1] != 0 && this.humanUnitTrapped[byte1] <= 3;)
                        byte1++;

                    if (byte1 < this.humanGeneralNum_inWar)  // �������δ�����Ľ���
                    {
                        FindRetreatCity(curWarCityId);  // ����ǰ���е��߼�
                        this.N_byte_fld = byte1;  // ������ҽ������
                        this.HMGeneralId = this.humanGeneralId_inWar[this.N_byte_fld];  // �����µ���ҽ���
                        //this.gamecanvas.void_c();  // ����UI
                        //this.gamecanvas.void_B_a(true);  // ����ս��״̬
                        //this.gamecanvas.k_boolean_fld = false;  // ���ñ�־
                        //this.gamecanvas.l_boolean_fld = true;  // ���±�־
                    }
                    else  // ��ҽ���ȫ������
                    {
                        if (this.AIAttackHM)
                            void_z();  // AI���������߼�
                        void_A();  // ս�������߼�
                        return false;
                    }
                }

                // ���������ҽ����Ƿ���
                for (byte byte2 = 1; byte2 < this.humanGeneralNum_inWar; byte2++)
                {
                    if (this.humanGeneralId_inWar[byte2] == generalId)
                    {
                        this.humanUnitTrapped[byte2] = 2;  // ��������
                        this.bigWar_coordinate[this.humanUnitCellY[byte2],this.humanUnitCellX[byte2]] = (byte)(this.bigWar_coordinate[this.humanUnitCellY[byte2],this.humanUnitCellX[byte2]] & 0x3F);  // ����ս������
                        return true;
                    }
                }
            }
            else  // �����AI����
            {
                if (generalId == this.aiGeneralId_inWar[0])  // ���AI��Ҫ�����Ƿ���
                {
                    this.j_byte_fld = 2;  // ս��״̬����
                    this.aiUnitTrapped[0] = 2;  // AI��������
                    this.bigWar_coordinate[this.aiUnitCellY[0],this.aiUnitCellX[0]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[0],this.aiUnitCellX[0]] & 0x3F);  // ����ս������

                    // �����ұ����Ľ���
                    for (byte byte3 = 1; byte3 < this.humanGeneralNum_inWar; byte3++)
                    {
                        if (this.humanUnitTrapped[byte3] == 2)
                            this.humanUnitTrapped[byte3] = 0;
                    }

                    //this.gamecanvas.r_byte_fld = 5;  // ������Ϸ״̬
                    return true;
                }

                // �������AI�����Ƿ���
                for (byte index = 1; index < this.aiGeneralNum_inWar; index++)
                {
                    if (this.aiGeneralId_inWar[index] == generalId)
                    {
                        this.aiUnitTrapped[index] = 2;  // AI��������
                        this.bigWar_coordinate[this.aiUnitCellY[index],this.aiUnitCellX[index]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[index],this.aiUnitCellX[index]] & 0x3F);  // ����ս������
                        return true;
                    }
                }
            }
            return true;  // Ĭ�Ϸ���true����ʾ�������
        }

        // ����ͬ����Ľ��������߼�
        bool boolean_h()
        {
            Country country;
            bool isCountry;
            byte countryId;
            bool result = false;

            switch (this.Z)
            {
                case 1:  // ����AI���������߼�
                    country = CountryListCache.GetCountryByKingId(this.AIGeneralId);  // ��ȡAI������������
                    isCountry = false;
                    countryId = 0;

                    if (country != null)  // ����ҵ�������Ϣ
                    {
                        countryId = country.countryId;
                        isCountry = true;
                    }

                    result = GeneralDie(this.AIGeneralId, false);  // AI������������
                    GameInfo.chooseGeneralName = GeneralListCache.GetGeneral(this.AIGeneralId).generalName;  // ��¼��������
                    GeneralListCache.GeneralDie(this.AIGeneralId);  // ���������������

                    if (isCountry)  // ���AI����Ϊ����
                    {
                        short newKingGeneralId = CountryListCache.GetCountryByCountryId(countryId).countryKingId;  // ��ȡ�µĹ���
                        if (this.AIAttackHM)
                        {
                            this.e_short_fld = newKingGeneralId;
                        }
                        else
                        {
                            this.f_short_fld = newKingGeneralId;
                        }
                        this.aiKingId = newKingGeneralId;  // ����AI����ID
                    }
                    return result;

                case 2:  // ������ҽ��������߼�
                    result = GeneralDie(this.HMGeneralId, true);
                    GameInfo.chooseGeneralName = GeneralListCache.GetGeneral(this.HMGeneralId).generalName;
                    GeneralListCache.GeneralDie(this.HMGeneralId);
                    return result;

                case 3:  // ����AI���������߼�
                    return boolean_sB_b(this.AIGeneralId, false);

                case 4:  // ������ҽ��������߼�
                    return boolean_sB_b(this.HMGeneralId, true);
            }

            return true;  // Ĭ�Ϸ���true
        }

        // ս�������Ľ�������
        void void_V()
        {
            //this.gamecanvas.B_boolean_fld = true;  // ����ս��״̬
            //this.gamecanvas.s_void_b_a((byte)17);  // ���ó����л��߼�
            this.j_byte_fld = 0;  // ����ս��״̬
            GameTurn();  // ���ý����߼�
        }

        // ս��ʤ���Ĵ���
        void void_W()
        {
            //this.gamecanvas.B_boolean_fld = true;  // ����ս��״̬
            //this.gamecanvas.s_void_b_a((byte)16);  // ����ʤ�������л��߼�
            this.j_byte_fld = 0;  // ����ս��״̬
            GameTurn();  // ���ý����߼�
        }

        // ����ս���еı�־λ
        void void_b_f(byte byte0)
        {
            //this.gamecanvas.s_void_b_a((byte)20);  // ����ս��״̬
            //this.gamecanvas.r_byte_fld = byte0;  // ���ó���״̬
            this.j_byte_fld = 0;  // ����ս��״̬
            void_B();  // ���ø����߼�
        }


        // ����ս��ѭ�����߼�
        void void_X()
        {
            this.HMGeneralId = 0;  // ������ҽ���ID
            void_x();  // ����ս����ص��߼�
            void_B();  // ������Ϸ״̬
            this.j_byte_fld = 0;  // ����ս��״̬
            this.bxct = false;  // ����ս��������־

            // ����ѭ������ս��״̬
            while (true)
            {
                void_I();  // ִ��ս���е�ĳ������

                // ���ս��״̬Ϊ2��3����������߼�
                if (this.j_byte_fld == 2 || this.j_byte_fld == 3)
                {
                    byte byte0 = this.j_byte_fld;
                    void_U();  // ����ĳ��ս������
                    //this.gamecanvas.s_void_b_a((byte)20);  // �л�ս������
                    //this.gamecanvas.void_c();  // ����UI
                    this.j_byte_fld = byte0;

                    // ��齫���Ƿ�����
                    if (!boolean_h())
                        this.j_byte_fld = 4;  // ����ս��״̬
                    //this.gamecanvas.repaint();  // ˢ�»���
                    continue;
                }

                // ����ս��״̬Ϊ5�����
                if (this.j_byte_fld == 5)
                {
                    this.j_byte_fld = 0;
                    void_V();  // ִ��ս��������Ĵ���

                    // ���ݲ�ͬ״̬������Ӧ�ı�־λ
                    switch (this.j_byte_fld)
                    {
                        case 1:
                            void_b_f((byte)11);  // ����״̬11
                            break;
                        case 2:
                            void_b_f((byte)10);  // ����״̬10
                            break;
                        case 3:
                            void_b_f((byte)12);  // ����״̬12
                            break;
                        case 4:
                            void_b_f((byte)13);  // ����״̬13
                            break;
                    }
                    this.j_byte_fld = 5;  // ����ս��״̬
                    //this.gamecanvas.void_c();  // ����UI
                    continue;
                }

                // ����ս��״̬��Ϊ6�����
                if (this.j_byte_fld != 6)
                {
                    if (this.j_byte_fld > 0)
                        break;  // ���״̬����0���˳�ѭ��
                    continue;  // �������ѭ��
                }

                void_W();  // ִ��ս��ʤ���Ĵ���

                // ���ݲ�ͬ״̬������Ӧ�ı�־λ
                switch (this.j_byte_fld)
                {
                    case 1:
                        void_b_f((byte)14);  // ����״̬14
                        break;
                    case 2:
                        void_b_f((byte)10);  // ����״̬10
                        break;
                }
                this.j_byte_fld = 6;  // ����ս��״̬
                //this.gamecanvas.void_c();  // ����UI
            }
        }

        // AI������ҵ��߼�
        void AIattackUser()
        {
            void_Y();  // ִ��AI����ǰ�ĳ�ʼ��
            this.HMGeneralId = 0;  // ������ҽ���ID
            void_B();  // ������Ϸ״̬
            this.j_byte_fld = 0;  // ����ս��״̬
            this.curAIindex = 0;  // ����AI����
            this.bxct = false;  // ����ս��������־

            // ����ѭ������ս��״̬
            while (true)
            {
                void_I();  // ִ��ս���е�ĳ������

                // ���ս��״̬Ϊ2��3����������߼�
                if (this.j_byte_fld == 2 || this.j_byte_fld == 3)
                {
                    byte byte0 = this.j_byte_fld;
                    void_U();  // ����ĳ��ս������
                    //this.gamecanvas.s_void_b_a((byte)20);  // �л�ս������
                    //this.gamecanvas.void_c();  // ����UI
                    this.j_byte_fld = byte0;

                    // ��齫���Ƿ�����
                    if (!boolean_h())
                        this.j_byte_fld = 4;  // ����ս��״̬
                    continue;
                }

                // ����ս��״̬Ϊ5�����
                if (this.j_byte_fld == 5)
                {
                    this.j_byte_fld = 0;
                    void_V();  // ִ��ս��������Ĵ���

                    // ���ݲ�ͬ״̬������Ӧ�ı�־λ
                    switch (this.j_byte_fld)
                    {
                        case 1:
                            void_b_f((byte)11);  // ����״̬11
                            break;
                        case 2:
                            void_b_f((byte)10);  // ����״̬10
                            break;
                        case 3:
                            void_b_f((byte)12);  // ����״̬12
                            break;
                        case 4:
                            void_b_f((byte)13);  // ����״̬13
                            break;
                    }
                    this.j_byte_fld = 5;  // ����ս��״̬
                    //this.gamecanvas.void_c();  // ����UI
                    continue;
                }

                // ����ս��״̬��Ϊ6�����
                if (this.j_byte_fld != 6)
                {
                    if (this.j_byte_fld > 0)
                        break;  // ���״̬����0���˳�ѭ��
                    continue;  // �������ѭ��
                }

                void_W();  // ִ��ս��ʤ���Ĵ���

                // ���ݲ�ͬ״̬������Ӧ�ı�־λ
                switch (this.j_byte_fld)
                {
                    case 1:
                        void_b_f((byte)14);  // ����״̬14
                        break;
                    case 2:
                        void_b_f((byte)10);  // ����״̬10
                        break;
                }
                this.j_byte_fld = 6;  // ����ս��״̬
                //this.gamecanvas.void_c();  // ����UI
            }
        }

        // �����߼�
        void void_Y()
        {
            this.j_byte_fld = 0;  // ����ս��״̬
            this.B_byte_fld = this.tarCity;  // ����Ŀ�����
            curWarCityId = this.curCity;  // ��ǰս������ID
            WarInfo.curWarCityId = curWarCityId;  // ����ȫ��ս������ID
            City curWarCity = CityListCache.GetCityByCityId(this.curCity);  // ��ȡ��ǰ���ж���
            this.f_short_fld = curWarCity.cityBelongKing;  // ��ȡ���������Ĺ���
            this.userKingId = this.f_short_fld;  // ������ҹ���ID
            this.e_short_fld = (CountryListCache.GetCountryByCountryId(this.curTurnsCountryId)).countryKingId;  // ��ȡAI����ID
            this.aiKingId = this.e_short_fld;  // ����AI����ID

            // ���ѡ��Ľ�����������10��ѡ��AI���еĽ���
            if (this.chooseGeneralNum < 10)
            {
                City aiCity = CityListCache.GetCityByCityId(this.tarCity);  // ��ȡĿ����ж���
                short[] connectCityId = aiCity.connectCityId;  // ��ȡ��Ŀ����������ĳ���ID
                for (int i = 0; i < connectCityId.Length || this.chooseGeneralNum >= 10; i++)  // �������ӳ���
                {
                    byte cityId = (byte)connectCityId[i];  // ��ȡ����ID
                    City city = CityListCache.GetCityByCityId(cityId);  // ��ȡ���ж���

                    // �����������AI����
                    if (city.cityBelongKing == this.aiKingId)
                    {
                        // ��������еĽ�����������2����ѡ��Ľ�������С��10������ѡ�񽫾�
                        while ((city.getCityOfficeGeneralIdArray()).Length < 2 && this.chooseGeneralNum < 10)
                        {
                            short generalId = city.getMaxBattlePowerGeneralId();  // ��ȡս������ߵĽ���

                            // ���������AI����
                            if (generalId == this.aiKingId)
                            {
                                short otherGeneralId = this.chooseGeneralIdArray[0];  // �滻��һλ����
                                this.chooseGeneralIdArray[this.chooseGeneralNum] = otherGeneralId;
                                this.chooseGeneralIdArray[0] = generalId;
                            }
                            else
                            {
                                this.chooseGeneralIdArray[this.chooseGeneralNum] = generalId;  // ѡ�񽫾�
                            }

                            this.chooseGeneralNum = (byte)(this.chooseGeneralNum + 1);  // ����ѡ��Ľ�������
                            city.removeOfficeGeneralId(generalId);  // �Ƴ�����
                        }
                        city.AppointmentPrefect();  // �����ط�����
                    }
                }
            }

            // ����ս����Ϣ
            this.humanGeneralNum_inWar = curWarCity.getCityGeneralNum();  // ��ȡ��ҳ����еĽ�������
            this.aiGeneralNum_inWar = this.chooseGeneralNum;  // AIѡ��Ľ�������

            // ����AI��ս����ID
            for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
                this.aiGeneralId_inWar[byte0] = this.chooseGeneralIdArray[byte0];

            // ������Ҳ�ս����ID
            short[] officeGeneralIdArray = curWarCity.getCityOfficeGeneralIdArray();
            for (byte byte1 = 0; byte1 < this.humanGeneralNum_inWar; byte1 = (byte)(byte1 + 1))
                this.humanGeneralId_inWar[byte1] = officeGeneralIdArray[byte1];

            // ������ҵ�ս����Դ
            this.humanMoney_inWar = curWarCity.GetMoney();  // ����ʽ�
            this.humanGrain_inWar = curWarCity.GetFood();  // �����ʳ
            this.AIAttackHM = true;  // AI�Ƿ񹥻����

            // ��ʼ��ս��״̬
            for (byte byte2 = 0; byte2 < this.humanGeneralNum_inWar; byte2 = (byte)(byte2 + 1))
                this.humanUnitTrapped[byte2] = 0;  // ��ҵ�λδ����

            for (byte byte3 = 0; byte3 < this.aiGeneralNum_inWar; byte3 = (byte)(byte3 + 1))
                this.aiUnitTrapped[byte3] = 0;  // AI��λδ����

            // ��ʼ��ս���ִε���Ϣ
            this.I_byte_fld = 1;
            this.J_byte_fld = 1;
            this.K_byte_fld = 1;
            this.L_byte_fld = 1;
            this.day = 0;
            this.F_byte_fld = 0;
            this.g_boolean_fld = true;
            this.N_byte_fld = 0;

            // ��������ƶ��ӳ�
            setHunmanMoveBonus();

            // ִ��ս����ʼ��
            PrepareWarStance();
            //this.gamecanvas.void_b();  // ������Ϸ����
            //this.gamecanvas.void_a();  // ˢ�½���
            //this.gamecanvas.void_i();  // ��ʼ��ս��UI
        }

        // ��Ϸѭ���߼�����Ҫ���ڴ�����Ϸ�ڵ��û����������ˢ��
        IEnumerator GameTurn()
        {
            float l1 = Time.time * 1000;  // ��ȡ��ǰϵͳʱ�䣨�Ժ���Ϊ��λ��

            while (true)
            {
                // ����������İ���
                if (Input.touchCount > 0)
                {
                    //this.gamecanvas.void_e();  // ִ�а�������

                    // �����Ϸ״̬δ�ı�
                    if (Input.touchCount > 0) { }
                        //this.gamecanvas.setKeyValue((byte)0);  // ���ð���ֵ
                }

                // ���ս��״̬
                if (this.j_byte_fld <= 0)
                {
                    // �����ϴ�ѭ���ĺ�ʱ��ʹ�� Unity ��ʱ��ϵͳ
                    float l2 = (Time.time * 1000) - l1;

                    if (l2 < 100f)  // �����ʱС��100����
                    {
                        // ȷ��ѭ�����������100����
                        yield return new WaitForSeconds((100f - l2) / 1000f);
                    }

                    //this.gamecanvas.repaint();  // ˢ����Ϸ����

                    l1 = Time.time * 1000;  // ����ѭ����ʼʱ��
                    continue;  // ������һ��ѭ��
                }

                // ���ս��״̬����0���˳�ѭ��
                break;
            }
        }



        // ����Ŀ�����
        void SelectTarCity()
        {
            this.p_byte_fld = this.tarCity;  // ��Ŀ�����ID�洢��p_byte_fld
        }

        // �л���ĳ������״̬��������GameTurn����ˢ��
        void void_ad()
        {
            //this.gamecanvas.s_void_b_a((byte)7);  // �л�������״̬7
            GameTurn();  // ����ˢ�·���
        }

        // �̳��߼�����ѭ����⵱ǰ����״̬
        void InheritCanvas()
        {
            this.X = 22;  // ����XΪ22
            Country humanCountry = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);  // ��ȡ��ҹ���
            this.tarCity = humanCountry.getCity(0);  // ��ȡ��ҹ��ҵĵ�һ��������ΪĿ�����
            this.d_boolean_fld = true;  // ���Ϊ�棬��ʾĳ��״̬����
            while (true)
            {
                SelectTarCity();  // ����Ŀ�����
                this.j_byte_fld = 0;  // ����j_byte_fld
                void_ad();  // �л�������ˢ��
                if (this.j_byte_fld <= 1)
                {
                    this.j_byte_fld = 0;  // ����״̬
                    continue;  // ����ѭ��
                }
                break;  // �˳�ѭ��
            }
            City city = CityListCache.GetCityByCityId(this.tarCity);  // ���ݳ���ID��ȡ���ж���
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();  // ��ȡ�����еĽ���ID����
            for (int i = 0; i < officeGeneralIdArray.Length; i++)  // ��������ID
            {
                if (this.HMGeneralId == officeGeneralIdArray[i])  // �������ָ���Ľ���
                {
                    humanCountry.Inherit(this.HMGeneralId);  // ��ҹ��Ҽ̳иý���
                    this.j_byte_fld = 0;  // ����״̬
                    //this.gamecanvas.s_void_b_a((byte)4);  // �л���״̬4
                    return;
                }
            }
            humanCountry.Inherit();  // ���û��ָ���Ľ�����ֱ�Ӽ̳�
            this.j_byte_fld = 0;  // ����״̬
            //this.gamecanvas.s_void_b_a((byte)4);  // �л���״̬4
        }

        // ���ҽ��洦��
        void NewCountryTurnCanvas(byte byte0, short newcountryKingId)
        {
            //this.gamecanvas.NewCountryTurnCanvas(byte0, newcountryKingId);  // ���»���״̬
            GameTurn();  // ˢ��
            this.j_byte_fld = 0;  // ����״̬
        }

        // ������������߼�
        void CountryDieCanvas()
        {
            //this.gamecanvas.s_void_b_a((byte)4);  // �л���״̬4
            this.j_byte_fld = 0;  // ����״̬
            if (GameInfo.countryDieTips == 1)
            {
                NewCountryTurnCanvas((byte)6, (short)0);  // �л�״̬������
            }
            else if (GameInfo.countryDieTips == 2)
            {
                NewCountryTurnCanvas((byte)6, (short)0);
                InheritCanvas();  // ���ü̳��߼�
                GameInfo.ShowInfo = GameInfo.ShowInfo + "�¾���" + (GeneralListCache.GetGeneral((CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)).generalName + " ��λ!";  // ������Ϣ
                NewCountryTurnCanvas((byte)6, (short)0);  // �л�״̬������
            }
            else if (GameInfo.countryDieTips == 3)
            {
                this.userOrderNum = 1;  // �����û�ָ��
                NewCountryTurnCanvas((byte)5, (short)0);  // �л�״̬
                this.j_byte_fld = 99;  // ����״̬Ϊ99
                return;
            }
            else if (GameInfo.countryDieTips == 4)
            {
                NewCountryTurnCanvas((byte)6, (short)0);  // �л�״̬
            }
            GameInfo.countryDieTips = 0;  // ���ù���������ʾ
            this.j_byte_fld = 4;  // ����״̬Ϊ4
        }

        // ������ʳ���ʽ�
        void foodMoneyDea1()
        {
            if (this.curTurnsCountryId == GameInfo.humanCountryId)  // �������ҹ��ҵĻغ�
            {
                this.fmoney = CityListCache.GetCityByCityId(this.tarCity).GetMoney();  // ��ȡ�ʽ�
                this.ffood = CityListCache.GetCityByCityId(this.tarCity).GetFood();  // ��ȡ��ʳ
            }
        }

        // �����ʳ���ʽ�仯
        void foodMoneyDea2()
        {
            if (this.ffood > CityListCache.GetCityByCityId(this.tarCity).GetFood() || this.fmoney > CityListCache.GetCityByCityId(this.tarCity).GetMoney())  // �����ʳ���ʽ����
            {
                CityListCache.GetCityByCityId((byte)37).SetFood((short)0);  // ����ĳ�����е���ʳΪ0
                return;
            }
        }

        // ������Ҳ���
        IEnumerator userDoSomething()
        {
            if (GameInfo.isWatch)  // ����ǹ۲�״̬��ֱ�ӷ���
                yield break;

            if (this.j_byte_fld == 0)  // ��ʼ״̬
            {
                this.userOrderNum = GameInfo.GetUserOrderNum();  // ��ȡ�û�ָ����
                this.X = 0;
                this.Y = 0;
                FindTarCity();  // ִ��ĳ������
                //this.gamecanvas.calculationUserKingIndex();  // ������ҹ�������
                //this.gamecanvas.repaint();  // ˢ�»���
                //this.gamecanvas.void_e();  // �������¼�
            }
            else if (this.j_byte_fld == 2)
            {
                InitiateCanvasMark();  // ִ��ĳ������
                this.j_byte_fld = 0;  // ����״̬
            }
            else if (this.j_byte_fld == 4)
            {
                this.j_byte_fld = 0;  // ����״̬
                EndDecreaseOrder();  // ִ��ĳ������
            }

            float l1 = Time.time * 1000;  // ��ȡ��ǰʱ�䣨���룩

            while (true)
            {
                // ��鰴������
                if (Input.touchCount > 0)
                {
                    //this.gamecanvas.void_e();  // �������¼�

                    // �����Ϸ״̬δ�ı�
                    if (Input.touchCount > 0) { }
                        //this.gamecanvas.setKeyValue((byte)0);  // ���ð���ֵ
                }

                if (this.j_byte_fld <= 0)
                {
                    // ����ʱ���
                    float l2 = (Time.time * 1000) - l1;

                    if (l2 < 20f)  // ȷ��ÿ֡����С���Ϊ20����
                    {
                        // ʹ��Э�̿��Ƶȴ�
                        yield return new WaitForSeconds((20f - l2) / 1000f);
                    }

                    //this.gamecanvas.repaint();  // ˢ�»���
                    l1 = Time.time * 1000;  // ����ʱ��
                    continue;
                }

                // ������������ϣ��˳�ѭ��
                break;
            }
        }


        // ð�������㷨
        public byte[] bubbleSort(byte[] args)
        {
            for (int i = 0; i < args.Length - 1; i++)
            {
                for (int j = i + 1; j < args.Length; j++)
                {
                    if (args[i] < args[j])  // �Ƚϴ�С������
                    {
                        byte temp = args[i];
                        args[i] = args[j];
                        args[j] = temp;
                    }
                }
            }
            return args;  // ��������������
        }

        // ����غ�˳���Ƿ�ˢ�¹���״̬
        void turnsort(bool isFlush)
        {
            byte[] havecitys = CountryListCache.getCountryIdArrayBySort();  // ��ȡ�����Ĺ���ID����
            this.countryOrder = new byte[CountryListCache.getCountrySize()];  // ��ʼ������˳������
            for (int i = 0; i < havecitys.Length; i++)
            {
                Country country = CountryListCache.GetCountryByCountryId(havecitys[i]);
                if (country.GetHaveCityNum() <= 0)  // �������û�г���
                {
                    this.countryOrder[i] = 0;  // ����˳��Ϊ0
                    country.isTurns = 0;  // ���Ϊ������غ�
                }
                else if (isFlush)
                {
                    this.countryOrder[i] = havecitys[i];  // ����˳��Ϊ����ID
                    country.isTurns = 1;  // ���Ϊ����غ�
                }
                else if (country.isTurns == 0)
                {
                    this.countryOrder[i] = 0;  // ������غ�
                }
                else
                {
                    this.countryOrder[i] = havecitys[i];  // ����غ�
                }
            }
        }


        // ��ȡ��ǰִ�еĹ���ID
        private byte getCurrentExecutionCountryId()
        {
            for (int i = 0; i < this.countryOrder.Length; i++)  // ��������˳������
            {
                Country country = CountryListCache.GetCountryByCountryId(this.countryOrder[i]);  // ���ݹ���ID��ȡ���Ҷ���
                if (country != null && country.isTurns == 1)  // ������Ҵ��ڲ����ֵ���غ�
                {
                    this.curTurnsCountryId = this.countryOrder[i];  // ���µ�ǰ�ֵ��Ĺ���ID
                    country.isTurns = 0;  // ��Ǹù��ҵĻغ���ִ��
                    return this.countryOrder[i];  // ���ع���ID
                }
            }
            return (byte)0;  // ���û�й��ҿ�ִ�У�����0
        }

        // ���غϴ����߼�
        void TurnTestCanvas()
        {
            if (this.j_byte_fld != 2)  // ���״̬����2
                turnsort(true);  // ִ�й���˳������
            this.au = 0;  // ��ʼ������
            while (true)
            {
                if (this.j_byte_fld == 0)  // ���״̬Ϊ0
                {
                    int i = getCurrentExecutionCountryId();  // ��ȡ��ǰִ�еĹ���ID
                    if (i == 0)  // ���û�й��ҿ�ִ��
                        break;  // �˳�ѭ��
                    this.gdcs = 0;  // ���ü�����
                    this.bngd = false;  // ���ñ�־λ
                    if (this.au == this.curTurnsCountryId && this.curTurnsCountryId != 0)  // �����ǰ�����Ѿ�ִ�й���ID��Ϊ0
                        continue;  // ����ѭ��
                }
                if (this.curTurnsCountryId <= 0)  // �����ǰ�ֵ��Ĺ���ID���Ϸ�
                {
                    this.curTurnsCountryId = this.au;  // �ָ�Ϊǰһ������ID
                    continue;  // ����ѭ��
                }
                this.au = this.curTurnsCountryId;  // ���浱ǰ����ID
                if (this.curTurnsCountryId == GameInfo.humanCountryId)  // �������ҹ���
                {
                    userDoSomething();  // ִ����ҵĲ���
                    if (this.o_boolean_fld)
                        this.o_boolean_fld = false;
                    if (this.j_byte_fld == 3)
                        this.j_byte_fld = 0;
                    if (this.j_byte_fld != 4)
                        continue;
                    void_X();  // ִ���ض��߼�
                    CountryDieCanvas();  // ����ս����Ľ���
                    this.gdcs = (byte)(this.gdcs + 1);  // ���Ӽ�����
                    if (this.gdcs >= 2)  // ����������λغ�
                        this.bngd = true;  // ���Ϊ����״̬
                    if (this.j_byte_fld == 99)  // ���״̬Ϊ99
                    {
                        this.j_byte_fld = 0;
                        return;  // ��������
                    }
                    continue;
                }
                //this.gamecanvas.repaint();  // ˢ�»���
                System.Console.WriteLine(GeneralListCache.GetGeneral(CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).countryKingId).generalName + "��ʼִ������");  // �����־
                //this.gamecanvas.serviceRepaints();  // �����ػ����
                long l1 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;  // ��ȡ��ǰʱ��
                this.j_byte_fld = 0;
                AITurns(this.curTurnsCountryId);  // AIִ�лغ�
                this.j_byte_fld = 0;
                long l2 = (System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - l1;  // ����ʱ���
                if (l2 >= 2000L)
                    continue;
                try
                {
                    lock (this)  // ʹ��ͬ����ȷ���̰߳�ȫ
                    {
                        System.Threading.Thread.Sleep((int)2000L - (int)l2);  // ��֤AI�غ�ʱ������Ϊ2000����
                    }
                }
                catch (System.Exception) { }
            }
        }

        // AIִ�лغϵ��߼�
        void AITurns(byte curTurnsCountryId)
        {
            byte orderNum = CountryListCache.getAIOredrNum(curTurnsCountryId);  // ��ȡAIָ����
            this.warNum = 2;  // ��ʼ��ս������
            while (this.AIUseOrderNum < orderNum)  // ��AIδִ��������ָ��ʱ
            {
                this.AIUseOrderNum = (byte)(this.AIUseOrderNum + 1);  // ������ִ��ָ����
                this.X = 0;  // ��ʼ��AI״̬
                this.tarCity = 0;  // ��ʼ��Ŀ�����
                this.curCity = 0;  // ��ʼ����ǰ����
                System.GC.Collect();  // ǿ�ƽ�����������
                alliance(curTurnsCountryId);  // ִ�н���
                AiStartInterior(curTurnsCountryId);  // ��ʼ��������
                aiDoSearchGen(curTurnsCountryId);  // AI��������
                Country country1 = CountryListCache.GetCountryByCountryId(curTurnsCountryId);  // ��ȡ��ǰ����
                country1.mustShangRen();  // ǿ�����˽���
                AIConscription();  // AI��������
                country1.Boolean_R();  // ִ��ĳ����������
                country1.transportMoney();  // AI�����ʽ�����

                if (AiFindLowLoyaltyGeneral())  // �������ĳ������
                    AiRewardGeneral();  // ִ����Ӧ����

                if (this.AIUseOrderNum < orderNum && this.warNum > 0)  // ���AI����ָ��δִ���һ���ս������
                {
                    byte num = (orderNum - this.AIUseOrderNum > this.warNum) ? this.warNum : (byte)(orderNum - this.AIUseOrderNum);  // ���㵱ǰս������
                    if (AIThinkWar(curTurnsCountryId, num) && warRand(num))  // ���AI����ս���ҷ����������
                    {
                        this.warNum = (byte)(this.warNum - 1);  // ����ս������
                        startWar();  // ��ʼս��
                        if (this.j_byte_fld == 3)
                        {
                            AIattackUser();  // AI�������
                            CountryDieCanvas();  // ִ��ս����Ľ���
                            if (this.j_byte_fld == 99)
                            {
                                this.j_byte_fld = 0;
                                return;  // ���״̬Ϊ99����������
                            }
                        }
                        continue;  // ����ִ����һ���غ�
                    }
                }
                AIConscription();  // AI���ж��������
                if (canTreatment())  // ������Խ�������
                {
                    AiTreat();  // ִ�����Ʋ���
                    continue;  // ����ִ����һ���غ�
                }
                AiFindLowLoyaltyGeneral();  // ִ��ĳ������
                if (this.X == 8)  // ���AI״̬Ϊ8
                {
                    AiRewardGeneral();  // ִ���ض�����
                    continue;  // ����ִ����һ���غ�
                }
                AiStartInterior(curTurnsCountryId);  // ����������������
            }
            Country country = CountryListCache.GetCountryByCountryId(curTurnsCountryId);  // ��ȡ��ǰ����
            byte CITY_NUM = country.GetHaveCityNum();  // ��ȡ����ӵ�еĳ�����
            for (int i = 0; i < CITY_NUM; i++)  // �������г���
            {
                byte cityId = country.getCity(i);  // ��ȡ����ID
                City city = CityListCache.GetCityByCityId(cityId);  // ��ȡ���ж���
                if (city.GetMoney() <= 100)  // ��������ʽ����ڵ���100
                    city.AddMoney((short)MathUtils.getRandomInt(20));  // ���ӳ����ʽ�
                if (city.GetFood() <= 300)  // ���������ʳ���ڵ���300
                    city.AddFood((short)MathUtils.getRandomInt(100));  // ���ӳ�����ʳ
                if (isUprising(cityId))  // ������з�������
                {
                    short prefectId = city.prefectId;  // ��ȡ����̫��ID
                    General general = GeneralListCache.GetGeneral(prefectId);  // ��ȡ�������
                    Country oldCountry = CountryListCache.GetCountryByKingId(city.cityBelongKing);  // ��ȡ�ɹ���
                    oldCountry.RemoveCity(cityId);  // �Ӿɹ����Ƴ��ó���
                    CITY_NUM = (byte)(CITY_NUM - 1);  // ���³�������
                    i--;  // ���������Դ�����������仯
                    Country newCountry = new Country();  // �����¹���
                    newCountry.countryId = (byte)(CountryListCache.getCountrySize() + 1);  // �����¹���ID
                    newCountry.countryKingId = general.generalId;  // �����¹��ҵĹ���ID
                    city.prefectId = general.generalId;  // ���ó��е�̫��Ϊ�ý���
                    newCountry.AddCity(cityId);  // �¹�����ӳ���
                    this.AIGeneralId = general.generalId;  // ����AI����ID
                    this.eventId = 20;  // �����¼�ID
                    RefreshFeedBack((byte)19);  // ִ���ض�����
                    FloodDisasterCanvans();  // �����¼�
                    CountryListCache.AddCountry(newCountry);  // ���¹�����ӵ����һ���
                    byte[] tempCountryOrder = new byte[this.countryOrder.Length + 1];  // ������ʱ�����԰����¹���
                    for (int j = 0; j < this.countryOrder.Length; j++)
                        tempCountryOrder[j] = this.countryOrder[j];  // ���ƾɹ���˳��
                    tempCountryOrder[tempCountryOrder.Length - 1] = newCountry.countryId;  // ����¹���
                    this.countryOrder = tempCountryOrder;  // ���¹���˳��
                    System.Console.WriteLine(general.generalName + "��" + city.cityName + "���壡");  // ���������־
                }
            }
            if (this.j_byte_fld != 3)  // ���״̬����3
                this.AIUseOrderNum = 0;  // ����AI����ָ����
        }


        // ִ�н��˲���
        private void alliance(byte countryId)
        {
            // ��ȡָ��ID�Ĺ���
            Country country = CountryListCache.GetCountryByCountryId(countryId);
            // ��ȡ�ù���ӵ�еĳ�������
            byte CityNum = country.GetHaveCityNum();
            // ���������������3�����������
            if (CityNum > 3)
                return;

            // ��ȡ�ù���ӵ�е����г���ID
            byte[] cityIds = country.GetCities();
            int qz = 0;  // ��¼�Ƿ��г������������ҽ���

            // �������г���
            for (int i = 0; i < cityIds.Length; i++)
            {
                byte cityId = cityIds[i];
                // ��ȡ���ж���
                City city = CityListCache.GetCityByCityId(cityId);
                // ��ȡ�ó������ӵĳ���ID
                short[] connectCityId = city.connectCityId;

                // �������ӵĳ���
                for (int m = 0; m < connectCityId.Length; m++)
                {
                    // ��ȡ���ӳ��е���������ID
                    short kingId = (CityListCache.GetCityByCityId((byte)connectCityId[m])).cityBelongKing;
                    // ��ȡ�ù��������Ĺ���
                    Country otherCountry = CountryListCache.GetCountryByKingId(kingId);

                    // ����������Ҵ�������IDΪ�������ID
                    if (otherCountry != null && otherCountry.countryId == GameInfo.humanCountryId)
                    {
                        qz++;  // ���ӽ��˼���
                        break;  // ����ѭ��
                    }
                }
            }

            // ���û���ҵ��ɽ��˵Ĺ��������ֵ����10�����������
            if (qz == 0 && MathUtils.getRandomInt(100) > 10)
                return;

            // ���������ֵ
            byte gl = (byte)(8 - MathUtils.pow(2, CityNum - 1) + CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).GetHaveCityNum());
            int k = MathUtils.getRandomInt(100);
            gl = (byte)(gl + qz);

            // ���������ֵС�����ֵ�����������
            if (gl < k)
                return;

            // ��ȡû�н��˵Ĺ���ID����
            byte[] noAllianceCountryId = country.GetNoCountryIdAllianceCountryIdArray();
            // ���û��û�н��˵Ĺ��ң��򷵻�
            if (noAllianceCountryId.Length < 1)
                return;

            Country allianceCountry = null;  // ��¼Ҫ���˵Ĺ���
            int dPhase = 0;  // ��¼��С����λ��
                                // ��ȡ��ǰ���ҹ���
            General countryKing = GeneralListCache.GetGeneral(country.countryKingId);

            // ����û�н��˵Ĺ���
            for (int j = 0; j < noAllianceCountryId.Length; j++)
            {
                byte otherCountryId = noAllianceCountryId[j];
                // ��ȡ��������
                Country otherCountry = CountryListCache.GetCountryByCountryId(otherCountryId);
                if (otherCountry != null && otherCountryId != GameInfo.humanCountryId)
                {
                    // ��ȡ�������ҹ���
                    General otherCountryKing = GeneralListCache.GetGeneral(otherCountry.countryKingId);
                    if (otherCountryKing != null)
                    {
                        // ���㵱ǰ���ҹ������������ҹ�������λ��
                        int d1 = GetdPhase(countryKing.phase, otherCountryKing.phase);
                        if (dPhase == 0 || dPhase > d1)
                        {
                            dPhase = d1;  // ������С����λ��
                            allianceCountry = otherCountry;  // ��¼��ǰ���ʺϽ��˵Ĺ���
                        }
                    }
                }
            }

            // ���û���ҵ��ʺϽ��˵Ĺ��ң��򷵻�
            if (allianceCountry == null)
                return;

            // �����λ����ϱ����˹��ҵĳ�����С�����ֵ
            if (dPhase + allianceCountry.GetHaveCityNum() <= MathUtils.getRandomInt(75))
            {
                // ִ�н��˲���
                country.AddAlliance(allianceCountry.countryId);
                // ������˳ɹ�����־
                System.Console.WriteLine(countryKing.generalName + "������" + (GeneralListCache.GetGeneral(allianceCountry.countryKingId)).generalName + "����ͬ�˳ɹ���");
                // ������Ϸ��Ϣ��ʾ
                GameInfo.ShowInfo = countryKing.generalName + "������" + (GeneralListCache.GetGeneral(allianceCountry.countryKingId)).generalName + "���ͬ�ˣ�";
                this.eventId = 21;  // �����¼�ID
                RefreshFeedBack((byte)19);  // ִ���ض�����
                FloodDisasterCanvans();  // �����¼�
            }
        }


        // �жϳ����Ƿ�������
        private bool isUprising(byte cityId)
        {
            // ��ȡָ��ID�ĳ���
            City city = CityListCache.GetCityByCityId(cityId);
            // ��ȡ���еĶ���ID
            short prefectId = city.prefectId;
            // ��ȡ����Ľ���
            General general = GeneralListCache.GetGeneral(prefectId);
            // ��ȡ���������Ĺ���
            Country oldCountry = CountryListCache.GetCountryByKingId(city.cityBelongKing);

            // ����������ҳ϶ȴ���90���߳��е���������ID���ڶ���ID��������
            if (general.getLoyalty() > 90 || city.cityBelongKing == city.prefectId)
                return false;

            // �����ҳ϶�
            int loyalty = 100 - general.getLoyalty();
            // ��ȡ�������������Ľ���
            General kingGeneral = GeneralListCache.GetGeneral(city.cityBelongKing);
            // ���㽫���Ľ׶β�
            int phase = GetdPhase(general.phase, kingGeneral.phase);

            // ����ҳ϶�С��10��׶β�С��5��������
            if (loyalty < 10 || phase < 5)
                return false;

            // �������ҵ��ٽ�ֵ
            int x = loyalty - 5 + phase / 2 - oldCountry.GetHaveCityNum() - getMoral(kingGeneral) - CountryListCache.getCountrySize() / 2;
            x /= 2;

            // ����������ֵС�ڵ���0��������
            if (x <= 0)
                return false;

            // ���ֵ�����ٽ�ֵ
            int m = MathUtils.getRandomInt(100) / x;
            // ������ֵ����0��������
            if (m > 0)
                return false;

            // ��ȡ�������ӵ����г���ID
            short[] cityIdArray = city.connectCityId;
            int maxAtkPower = 0;

            // �������ӳ��У��ҳ���󹥻���
            for (int i = 0; i < cityIdArray.Length; i++)
            {
                short tempCityId = cityIdArray[i];
                City tempCity = CityListCache.GetCityByCityId((byte)tempCityId);
                int atkPower = tempCity.getMaxAtkPower();
                if (atkPower > maxAtkPower)
                    maxAtkPower = atkPower;
            }

            // ������еķ�������С����󹥻�����70%��������
            if (city.GetDefenseAbility() < maxAtkPower * 0.7f)
                return false;

            return true;
        }

        // ��ȡ�����ĵ���ֵ
        public int getMoral(General general)
        {
            int moral = general.moral - 80;
            int result = moral / 9;
            return result;
        }

        // �ж��Ƿ�Ϊ�ض��¼�
        bool DisasterRate_i()
        {
            // �жϵ�ǰ�·��Ƿ���3�µ�11��֮��
            if (GameInfo.month < 11 && GameInfo.month > 2)
            {
                // �������һ��0��499֮������������ж��Ƿ�С��4
                int i1 = CommonUtils.getRandomInt() % 500;
                return (i1 < 4);
            }
            return false;
        }

        // �ж��Ƿ�Ϊ�ض��¼�
        bool DisasterRate_j()
        {
            // �������һ��0��499֮������������ж��Ƿ�С�ڵ���1
            return (CommonUtils.getRandomInt() % 500 <= 1);
        }

        // ����ĳֵ
        int FloodDisasterLoss(int i1, byte byte0, int j1)
        {
            i1 /= 2;
            return byte0 * i1 / j1;
        }


        // ������еĺ�ˮ����
        private void FloodDisaster(byte byte0)
        {
            // ��ȡָ��ID�ĳ���
            City city = CityListCache.GetCityByCityId(byte0);

            // ������еĺ�ˮ����С��90
            if (city.floodControl < 90)
            {
                // ���ٳ��еĽ�Ǯ��ʳ���ͳ����
                city.DecreaseMoney((short)FloodDisasterLoss(city.GetMoney(), city.floodControl, 90));
                city.DecreaseFood((short)FloodDisasterLoss(city.GetFood(), city.floodControl, 90));
                city.rule = (byte)(city.rule - FloodDisasterLoss(city.rule, city.floodControl, 90));
            }

            // ������еĺ�ˮ����С��99
            if (city.floodControl < 99)
            {
                // ���ٳ��е�ó�׺�ũҵ
                city.trade = (short)(city.trade - FloodDisasterLoss(city.trade, city.floodControl, 99));
                city.agro = (short)(city.agro - FloodDisasterLoss(city.agro, city.floodControl, 99));
            }

            // ������еĺ�ˮ���ƴ���0
            if (city.floodControl > 0)
                // ���ٺ�ˮ����ֵ��ÿ�μ���1/10��1
                city.floodControl = (byte)(city.floodControl - city.floodControl / 10 + 1);
        }

        // ִ�����������������¼�ID
        private void FloodDisasterCanvans()
        {
            void_bb();
            RefreshFeedBack((byte)4);
        }

        /// <summary>
        /// ������еĺ�ˮ�ֺ�
        /// </summary>
        /// <param name="byte0"></param>
        private void DisasterHurt(byte byte0)
        {
            // ��ȡָ��ID�ĳ���
            City city = CityListCache.GetCityByCityId(byte0);
            // ��ȡ�����еĽ���ID����
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // ������еĺ�ˮ����С��90
            if (city.floodControl < 90)
            {
                // ���������еĽ��������ٽ�����ʿ������
                for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
                {
                    General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]);
                    general.generalSoldier = (short)(general.generalSoldier - FloodDisasterLoss(general.generalSoldier, city.floodControl, 90));
                }
                // ���ٳ��д���ʿ��������ͳ����
                city.cityReserveSoldier -= FloodDisasterLoss(city.cityReserveSoldier, city.floodControl, 90);
                city.rule = (byte)(city.rule - FloodDisasterLoss(city.rule, city.floodControl, 90));
            }

            // ������еĺ�ˮ����С��99
            if (city.floodControl < 99)
                // ���ٳ����˿�
                city.population -= FloodDisasterLoss(city.population, city.floodControl, 99);

            // ������еĺ�ˮ���ƴ���0
            if (city.floodControl > 0)
                // ���ٺ�ˮ����ֵ��ÿ�μ���1/10��1
                city.floodControl = (byte)(city.floodControl - city.floodControl / 10 + 1);
        }

        // �жϳ����Ƿ�ᷢ������
        private bool IsRebelDisaster(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            if (city.rule < 15)
            {
                // �������ҷ����ĸ���
                int i1 = city.rule * 10 / 15 + 80;
                if (CommonUtils.getRandomInt() % 100 >= i1)
                    return true;
            }
            else if (city.rule < 30)
            {
                int j1 = (city.rule - 15) / 3 + 90;
                if (CommonUtils.getRandomInt() % 100 >= j1)
                    return true;
            }
            else if (city.rule < 40)
            {
                int k1 = (city.rule - 30) / 5 + 98;
                if (CommonUtils.getRandomInt() % 100 >= k1)
                    return true;
            }
            else if (city.rule < 60)
            {
                int l1 = (city.rule - 40) / 5 + 998;
                if (CommonUtils.getRandomInt() % 1000 >= l1)
                    return true;
            }
            return false;
        }

        // ������ٳ��е�ͳ����
        private void DecreaseCityRule(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            city.rule = (byte)((city.rule - CommonUtils.getRandomInt() % 15));
            if (city.rule < 0)
                city.rule = 0;
        }

        // ����һ������ֵ
        private int RebelDisasterLoss(int word0, int i1, int j1)
        {
            int k1 = word0 * i1 / j1;
            if (k1 > 0)
                return (short)(word0 - CommonUtils.getRandomInt() % k1);
            return word0;
        }

        // ����һ��������ֵ
        private short RebelDisasterLoss(short word0, int i1, int j1)
        {
            int k1 = word0 * i1 / j1;
            if (k1 > 0)
                return (short)(word0 - CommonUtils.getRandomInt() % k1);
            return word0;
        }

        /// <summary>
        /// ������е�ͳ�ζȿ���Ǯ��
        /// </summary>
        /// <param name="cityId"></param>
        private void RebelDisasterLowRule(byte cityId)
        {
            int i1 = 0;
            // ��ȡָ��ID�ĳ���
            City city = CityListCache.GetCityByCityId(cityId);
            // ��ȡ�����еĽ���ID����
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // ���ݳ��е�ͳ�ζ�������ͬ�����
            if (city.rule < 15)
            {
                // ͳ�ζ�С��15�����еĸ�����Դ����
                city.population /= 3;
                city.agro = (short)(city.agro / 3);
                city.trade = (short)(city.trade / 3);
                city.SetMoney((short)(city.GetMoney() / 2));
                city.SetFood((short)(city.GetFood() / 2));
                DecreaseCityRule(cityId);
                city.cityReserveSoldier = RebelDisasterLoss(city.cityReserveSoldier, 2, 3);
                for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
                {
                    General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]);
                    general.generalSoldier = RebelDisasterLoss(general.generalSoldier, 2, 3);
                    i1 += general.generalSoldier;
                }
            }
            else if (city.rule < 30)
            {
                // ͳ�ζ���15��30֮�䣬���еĸ�����Դ����
                city.population /= 2;
                city.agro = (short)(city.agro / 2);
                city.trade = (short)(city.trade / 2);
                city.SetMoney((short)(city.GetMoney() * 3 / 7));
                city.SetFood((short)(city.GetFood() * 3 / 7));
                DecreaseCityRule(cityId);
                city.cityReserveSoldier = RebelDisasterLoss(city.cityReserveSoldier, 1, 2);
                for (byte byte2 = 0; byte2 < city.getCityGeneralNum(); byte2 = (byte)(byte2 + 1))
                {
                    General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]);
                    general.generalSoldier = RebelDisasterLoss(general.generalSoldier, 1, 2);
                    i1 += general.generalSoldier;
                }
            }
            else
            {
                // ͳ�ζ���30���ϣ����еĸ�����Դ����
                city.population = city.population * 2 / 3;
                city.agro = (short)(city.agro * 2 / 3);
                city.trade = (short)(city.trade * 2 / 3);
                city.SetMoney((short)(city.GetMoney() * 1 / 7));
                city.SetFood((short)(city.GetFood() * 1 / 7));
                DecreaseCityRule(cityId);
                city.cityReserveSoldier = RebelDisasterLoss(city.cityReserveSoldier, 1, 5);
                for (byte byte3 = 0; byte3 < city.getCityGeneralNum(); byte3 = (byte)(byte3 + 1))
                {
                    General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte3]);
                    general.generalSoldier = RebelDisasterLoss(general.generalSoldier, 1, 5);
                    i1 += general.generalSoldier;
                }
            }
        }

        /// <summary>
        /// ����ĳ����Դ��Ӱ��ֵ
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="j1"></param>
        /// <param name="k1"></param>
        /// <returns></returns>
        private int FoodIncome(int i1, int j1, int k1)
        {
            int l1 = k1 / 100;
            int i2 = l1 * i1 * 4 / 5 / 125;
            l1 += i2;
            i2 = 0;
            if (j1 > 90)
            {
                i2 += l1 * 4 / 5;
            }
            else if (j1 > 80)
            {
                i2 += l1 * 3 / 5;
            }
            else if (j1 > 70)
            {
                i2 += l1 * 2 / 5;
            }
            else if (j1 > 50)
            {
                i2 += l1 / 5;
            }
            l1 += i2;
            return l1;
        }

        /// <summary>
        /// �����Ǯ����
        /// </summary>
        /// <param name="trade"></param>
        /// <param name="rule"></param>
        /// <param name="population"></param>
        /// <returns></returns>
        private int MoneyIncome(int trade, int rule, int population)
        {
            int l1 = population / 400;
            l1++;
            int i2 = l1 * trade * 3 / 5 / 125;
            l1 += i2;
            i2 = 0;
            if (rule > 90)
            {
                i2 += l1 * 4 / 5;
            }
            else if (rule > 80)
            {
                i2 += l1 * 3 / 5;
            }
            else if (rule > 70)
            {
                i2 += l1 * 2 / 5;
            }
            else if (rule > 50)
            {
                i2 += l1 / 5;
            }
            l1 += i2;
            return l1;
        }

        /// <summary>
        /// �����ջ��Ǯ
        /// </summary>
        /// <param name="byte0"></param>
        private void RegularGiveOutMoney(byte byte0)
        {
            // ��ȡָ��ID�ĳ���
            City city = CityListCache.GetCityByCityId(byte0);
            // ��ȡ�����еĽ���ID����
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            // �����Ǯ����
            int i1 = MoneyIncome(city.trade, city.rule, city.population);

            // ����н���ӵ���ض����ܣ����Ǯ��������50%
            for (int i = 0; i < city.getCityGeneralNum(); i++)
            {
                short id = officeGeneralIdArray[i];
                if (GetSkill_4(id, 5))
                {
                    i1 += i1 / 2;
                    break;
                }
            }

            // ������в�������ҹ��ң����Ǯ��������20%
            if (city.cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                i1 = (int)(i1 * 1.2D);

            // ��ӽ�Ǯ������
            city.AddMoney((short)i1);
        }

        /// <summary>
        /// �����ջ�ʳ��
        /// </summary>
        /// <param name="byte0"></param>
        private void RegularGiveOutFood(byte byte0)
        {
            // ��ȡָ��ID�ĳ���
            City city = CityListCache.GetCityByCityId(byte0);
            // ����ʳ�����
            int getnum = FoodIncome(city.agro, city.rule, city.population);
            // ��ȡ�����еĽ���ID����
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // ����н���ӵ���ض����ܣ���ʳ���������50%
            for (int i = 0; i < city.getCityGeneralNum(); i++)
            {
                short id = officeGeneralIdArray[i];
                if (GetSkill_4(id, 5))
                {
                    getnum += getnum / 2;
                    break;
                }
            }

            // ������в�������ҹ��ң���ʳ���������20%
            if (city.cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                getnum = (int)(getnum * 1.2D);

            // ���ʳ�ﵽ����
            city.AddFood((short)getnum);
        }


        /// <summary>
        /// ������г����Ƿ�������ҹ��ҵĹ���
        /// </summary>
        /// <returns></returns>
        private bool UserhaveAllCity()
        {
            for (byte cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                // ��ȡ���е���������ID��������ҹ��ҵĹ���ID���бȽ�
                if ((CityListCache.GetCityByCityId(cityId)).cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                    return false; // ������κ�һ�����еĹ���ID��ƥ�䣬�򷵻�false
            }
            return true; // ���г��ж�������ҹ��ҵĹ���������true
        }

        /// <summary>
        /// �����ҹ����Ƿ�û�г���
        /// </summary>
        /// <returns></returns>
        private bool UserhaveNoneCity()
        {
            Country userCountry = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);
            // �����ҹ��Ҵ�����ӵ�еĳ���������Ϊ0���򷵻�false�����򷵻�true
            return !(userCountry != null && userCountry.GetHaveCityNum() != 0);
        }

        /// <summary>
        /// ����ı���е�״̬
        /// </summary>
        /// <param name="byte0"></param>
        private void RandomChangeCity(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);

            // ������ݾ�����ͬ���������
            if (GameInfo.years <= 194)
            {
                int i1 = CommonUtils.getRandomInt() % 4;
                int j1 = CommonUtils.getRandomInt() % 5 + 1;
                switch (i1)
                {
                    case 0:
                        city.agro = (short)(city.agro + j1);
                        if (city.agro > 999)
                            city.agro = 999; // ȷ��agroֵ���ᳬ��999
                        break;
                    case 1:
                        city.trade = (short)(city.trade + j1);
                        if (city.trade > 999)
                            city.trade = 999; // ȷ��tradeֵ���ᳬ��999
                        break;
                    case 2:
                        city.population += j1 * 1000;
                        if (city.population > 990000)
                            city.population = 990000; // ȷ��populationֵ���ᳬ��990000
                        break;
                    case 3:
                        city.floodControl = (byte)(city.floodControl + j1 / 2 + 8);
                        if (city.floodControl > 99)
                            city.floodControl = 99; // ȷ��floodControlֵ���ᳬ��99
                        break;
                }
                j1 = CommonUtils.getRandomInt() % 3 + 1;
                if (city.rule < 30)
                {
                    city.rule = (byte)(city.rule + j1 + 8);
                }
                else if (city.rule < 40)
                {
                    city.rule = (byte)(city.rule + j1 + 2);
                }
                else if (city.rule < 80)
                {
                    city.rule = (byte)(city.rule + j1);
                }
            }
            else
            {
                int i1 = CommonUtils.getRandomInt() % 2;
                int j1 = CommonUtils.getRandomInt() % 5 + 1;
                switch (i1)
                {
                    case 0:
                        city.floodControl = (byte)(city.floodControl + j1 / 2 + 8);
                        if (city.floodControl > 99)
                            city.floodControl = 99; // ȷ��floodControlֵ���ᳬ��99
                        break;
                    case 1:
                        city.population += j1 * 500;
                        if (city.population > 990000)
                            city.population = 990000; // ȷ��populationֵ���ᳬ��990000
                        break;
                }
                j1 = CommonUtils.getRandomInt() % 3 + 1;
                if (city.rule < 30)
                {
                    city.rule = (byte)(city.rule + j1 + 6);
                }
                else if (city.rule < 40)
                {
                    city.rule = (byte)(city.rule + j1 + 2);
                }
                else if (city.rule < 80)
                {
                    city.rule = (byte)(city.rule + j1);
                }
            }
            // ȷ��ruleֵ���ᳬ��99
            if (city.rule > 99)
                city.rule = 99;
        }

        /// <summary>
        /// �����й��ҵĳ��н���ĳЩ����
        /// </summary>
        private void RandomChangeAllCity()
        {
            for (byte i1 = 1; i1 < 8; i1 = (byte)(i1 + 1))
            {
                Country country = CountryListCache.GetCountryByCountryId(i1);
                if (country.countryId > 0 && country.countryId != GameInfo.humanCountryId)
                    for (int j1 = 0; j1 < country.GetHaveCityNum(); j1++)
                        RandomChangeCity(country.getCity(j1)); // ��ÿ�����е���RandomChangeCity
            }
        }

        /// <summary>
        /// ����ҹ��ҽ����Զ�����
        /// </summary>
        private void AutoInterior()
        {
            Country country = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);
            // �����ҹ��Ҳ����ڻ�ӵ�еĳ�������10�����򷵻�
            if (country == null || country.GetHaveCityNum() < 10)
                return;

            for (int index = 0; index < country.GetHaveCityNum(); index++)
            {
                City city = CityListCache.GetCityByCityId(country.getCity(index));
                if (city.GetMoney() >= 40)
                    if (CommonUtils.getRandomInt() % 100 > 30)
                        AutoInteriorLogic(city.cityId); // �����������������AutoInteriorLogic
            }
        }

        /// <summary>
        /// �Զ���AI���г��н�����������
        /// </summary>
        private void AutoInteriorAllCity()
        {
            for (byte cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                City city = CityListCache.GetCityByCityId(cityId);
                if (city.cityBelongKing > 0 && city.cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                {
                    byte CITY_NUM = CountryListCache.GetCountryByKingId(city.cityBelongKing).GetHaveCityNum();
                    if (CITY_NUM > 0 && CITY_NUM <= 6)
                    {
                        if (city.GetMoney() < 600)
                            city.AddMoney((short)(30 + CommonUtils.getRandomInt() % 600 / CITY_NUM));
                        if (city.GetFood() < city.GetCityAllSoldierNum() / 1000 * 6 * 30)
                            city.AddFood((short)(150 + CommonUtils.getRandomInt() % 600 / CITY_NUM));
                    }
                    else if (city.GetMoney() < 30)
                    {
                        city.AddMoney((short)(20 + CommonUtils.getRandomInt() % 10));
                    }

                    short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                    byte minLoyalty = 100;
                    short word0 = 0;
                    for (byte byte3 = 0; byte3 < city.getCityGeneralNum(); byte3 = (byte)(byte3 + 1))
                    {
                        short generalId = officeGeneralIdArray[byte3];
                        General general = GeneralListCache.GetGeneral(generalId);
                        if (general.getLoyalty() < 50)
                        {
                            general.AddLoyalty(false);
                        }
                        else if (minLoyalty > general.getLoyalty())
                        {
                            word0 = generalId;
                            minLoyalty = general.getLoyalty();
                        }
                    }
                    if (minLoyalty < 90)
                    {
                        General general = GeneralListCache.GetGeneral(word0);
                        general.AddLoyalty(false);
                    }

                    if ((this.k_byte_array1d_fld[cityId] & 0x2) == 2)
                        AIDoLearn(cityId);

                    if ((this.k_byte_array1d_fld[cityId] & 0x4) == 4)
                        for (byte id = 0; id < city.getCityGeneralNum(); id = (byte)(id + 1))
                        {
                            short generalId = officeGeneralIdArray[id];
                            General general2 = GeneralListCache.GetGeneral(generalId);
                            if (general2.getCurPhysical() < general2.maxPhysical)
                            {
                                byte addPhysical = (byte)AiTreatValue();
                                general2.addCurPhysical(addPhysical);
                            }
                        }

                    if (city.GetMoney() >= 30)
                    {
                        DoFlood(cityId);
                        if (city.GetMoney() >= 30)
                            if (CITY_NUM > 6)
                            {
                                if (city.getCityGeneralNum() > 1)
                                {
                                    if (CommonUtils.getRandomInt() % city.getCityGeneralNum() > 0)
                                        AutoInteriorLogic(cityId);
                                }
                                else if (CommonUtils.getRandomInt() % 40 > CITY_NUM * 2)
                                {
                                    AutoInteriorLogic(cityId);
                                }
                            }
                            else if (city.getCityGeneralNum() > 1)
                            {
                                if (CommonUtils.getRandomInt() % city.getCityGeneralNum() > 0)
                                    AutoInteriorLogic(cityId);
                            }
                            else if (CommonUtils.getRandomInt() % 3 > 1)
                            {
                                AutoInteriorLogic(cityId);
                            }
                    }
                }
            }
        }


        /// <summary>
        /// �Զ�����AI���г��е�����
        /// </summary>
        private void AutoInteriorAllCity2()
        {
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte0);

                // ������еĹ���ID����0�Ҳ�������ҹ��ҵĹ���
                if (city.cityBelongKing > 0 && city.cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                {
                    byte curCountryCitys = CountryListCache.GetCountryByKingId(city.cityBelongKing).GetHaveCityNum();

                    // �����ǰ���ҵĳ�������С�ڵ���10
                    if (curCountryCitys <= 10)
                    {
                        // ������е��ʽ�����600��������һ�����ʽ�
                        if (city.GetMoney() < 600)
                            city.AddMoney((short)(30 + CommonUtils.getRandomInt() % 6000 / curCountryCitys));

                        // ������е�ʳ�����ڳ�������ʿ�������� 6 * 60 ��
                        if (city.GetFood() < city.GetCityAllSoldierNum() / 1000 * 6 * 60)
                            city.SetFood((short)(150 + CommonUtils.getRandomInt() % 6000 / curCountryCitys));
                    }
                    else if (city.GetMoney() < 30)
                    {
                        // ������е��ʽ�����30��������һ�����ʽ�
                        city.AddMoney((short)(20 + CommonUtils.getRandomInt() % 10));
                    }

                    byte byte1 = 100; // ��ʼ��С�ҳ϶�
                    short word0 = 0;  // ��ʼ�ҳ϶���͵Ľ���ID
                    short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

                    // �������������н���
                    for (byte byte3 = 0; byte3 < city.getCityGeneralNum(); byte3 = (byte)(byte3 + 1))
                    {
                        short generalId = officeGeneralIdArray[byte3];
                        General general = GeneralListCache.GetGeneral(generalId);

                        // ����������ҳ϶ȵ���50���������ҳ϶�
                        if (general.getLoyalty() < 50)
                        {
                            general.AddLoyalty(true);
                        }
                        // �����ǰ�������ҳ϶ȵ�����С�ҳ϶ȣ��������С�ҳ϶�
                        else if (byte1 > general.getLoyalty())
                        {
                            word0 = generalId;
                            byte1 = general.getLoyalty();
                        }
                    }
                    // �����С�ҳ϶ȵ���90����������Ӧ�������ҳ϶�
                    if (byte1 < 90)
                        GeneralListCache.GetGeneral(word0).AddLoyalty(true);

                    // ������еı�־λ����0x2�������AIDoLearn����
                    if ((this.k_byte_array1d_fld[byte0] & 0x2) == 2)
                        AIDoLearn(byte0);

                    // ������еı�־λ����0x4�����ÿ���������������ָ�
                    if ((this.k_byte_array1d_fld[byte0] & 0x4) == 4)
                        for (byte byte5 = 0; byte5 < city.getCityGeneralNum(); byte5 = (byte)(byte5 + 1))
                        {
                            short word4 = officeGeneralIdArray[byte5];
                            General general = GeneralListCache.GetGeneral(word4);
                            if (general.getCurPhysical() < general.maxPhysical)
                            {
                                byte addPhysical = (byte)AiTreatValue();
                                general.addCurPhysical(addPhysical);
                            }
                        }

                    // ������е��ʽ���ڵ���30
                    if (CityListCache.GetCityByCityId(byte0).GetMoney() >= 30)
                    {
                        DoFlood(byte0); // ����DoFlood����

                        // ������е��ʽ���Ȼ���ڵ���30
                        if (CityListCache.GetCityByCityId(byte0).GetMoney() >= 30)
                        {
                            if (curCountryCitys > 10)
                            {
                                if (city.getCityGeneralNum() > 1)
                                {
                                    if (CommonUtils.getRandomInt() % city.getCityGeneralNum() > 0)
                                        AutoInteriorLogic(byte0); // ����AutoInteriorLogic����
                                }
                                else if (CommonUtils.getRandomInt() % 60 > curCountryCitys * 2)
                                {
                                    AutoInteriorLogic(byte0); // ����AutoInteriorLogic����
                                }
                            }
                            else if (city.getCityGeneralNum() > 1)
                            {
                                if (CommonUtils.getRandomInt() % city.getCityGeneralNum() > 0)
                                    AutoInteriorLogic(byte0); // ����AutoInteriorLogic����
                            }
                            else if (CommonUtils.getRandomInt() % 3 > 0)
                            {
                                AutoInteriorLogic(byte0); // ����AutoInteriorLogic����
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ִ��ˮ�ִ���
        /// </summary>
        /// <param name="city"></param>
        private void DoFlood(byte city)
        {
            short generalId = AiFindMostIQPoliticalGeneralInCity(city); // ��ȡ����ID
                                                // ������еķ������С��99�������AiTameOrder����
            if ((CityListCache.GetCityByCityId(city)).floodControl < 99)
                AiTameOrder(city, generalId);
        }


        /// <summary>
        /// ������Ϸ�еĸ����¼�
        /// </summary>
        private void DoThingsInTurn()
        {
            this.disasterThings = 0; // ��ʼ�� disasterThings Ϊ 0

            // ��� UserhaveNoneCity() ���� true
            if (UserhaveNoneCity())
            {
                this.eventId = 1; // �����¼� ID Ϊ 1
                RefreshFeedBack((byte)23); // ���� RefreshFeedBack ����������Ϊ 23
                GameTurn(); // ���� GameTurn ����
                this.j_byte_fld = 1; // ���� j_byte_fld Ϊ 1
                return; // ��������
            }

            // ��� UserhaveAllCity() ���� true
            if (UserhaveAllCity())
            {
                this.eventId = 0; // �����¼� ID Ϊ 0
                RefreshFeedBack((byte)23); // ���� RefreshFeedBack ����������Ϊ 23
                GameTurn(); // ���� GameTurn ����
                this.j_byte_fld = 1; // ���� j_byte_fld Ϊ 1
                return; // ��������
            }

            // ������Ϸ���·�
            GameInfo.month = (byte)(GameInfo.month + 1);

            // �������г��� ID
            for (short word0 = 1; word0 < CityListCache.CITY_NUM; word0 = (short)(word0 + 1))
            {
                // ��� DisasterRate_i() ���� true
                if (DisasterRate_i())
                {
                    this.disasterThings = (byte)(this.disasterThings + 1);
                    this.G_byte_array1d_fld[this.disasterThings] = (byte)word0;
                }
            }

            // ��� disasterThings С�� 1
            if (this.disasterThings < 1)
            {
                // �������г��� ID
                for (short word1 = 1; word1 < CityListCache.CITY_NUM; word1 = (short)(word1 + 1))
                {
                    // ��� DisasterRate_j() ���� true
                    if (DisasterRate_j())
                    {
                        this.disasterThings = (byte)(this.disasterThings + 1);
                        this.G_byte_array1d_fld[this.disasterThings] = (byte)word1;
                    }
                }
            }
            else
            {
                // �� disasterThings �д洢�ĳ��� ID ִ�� FloodDisaster ����
                for (short word2 = 0; word2 < this.disasterThings; word2 = (short)(word2 + 1))
                    FloodDisaster(this.G_byte_array1d_fld[word2]);

                this.eventId = CommonUtils.getRandomInt() % 3 + 6; // �����¼� ID Ϊ���ֵ 6 �� 8 ֮��
                RefreshFeedBack((byte)19); // ���� RefreshFeedBack ����������Ϊ 19
                FloodDisasterCanvans(); // ���� FloodDisasterCanvans ����
                this.disasterThings = 0; // ���� disasterThings
            }

            // ��� disasterThings ���� 0
            if (this.disasterThings > 0)
            {
                // �� disasterThings �д洢�ĳ��� ID ִ�� DisasterHurt ����
                for (short word3 = 0; word3 < this.disasterThings; word3 = (short)(word3 + 1))
                    DisasterHurt(this.G_byte_array1d_fld[word3]);

                this.eventId = 9; // �����¼� ID Ϊ 9
                RefreshFeedBack((byte)19); // ���� RefreshFeedBack ����������Ϊ 19
                FloodDisasterCanvans(); // ���� FloodDisasterCanvans ����
                this.disasterThings = 0; // ���� disasterThings
            }

            // �������г��� ID
            for (byte word4 = 1; word4 < CityListCache.CITY_NUM; word4 = (byte)(word4 + 1))
            {
                City city = CityListCache.GetCityByCityId(word4);

                // ������еĹ��� ID ���� 0 �� IsRebelDisaster(word4) ���� true
                if ((city.cityBelongKing > 0) && IsRebelDisaster(word4))
                {
                    this.disasterThings = (byte)(this.disasterThings + 1);
                    this.G_byte_array1d_fld[this.disasterThings] = word4;
                }
            }

            // ��� disasterThings ���� 0
            if (this.disasterThings > 0)
            {
                // �� disasterThings �д洢�ĳ��� ID ִ�� RebelDisasterLowRule ����
                for (short word5 = 0; word5 < this.disasterThings; word5 = (short)(word5 + 1))
                    RebelDisasterLowRule(this.G_byte_array1d_fld[word5]);

                this.eventId = 13; // �����¼� ID Ϊ 13
                RefreshFeedBack((byte)19); // ���� RefreshFeedBack ����������Ϊ 19
                FloodDisasterCanvans(); // ���� FloodDisasterCanvans ����
                this.disasterThings = 0; // ���� disasterThings
                AutoInteriorAllCity2(); // ���� AutoInteriorAllCity2 ����
            }

            AutoInteriorAllCity(); // ���� AutoInteriorAllCity ����

            short userKingId = (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId; // ��ȡ��ҹ��ҵĹ��� ID
            byte cityId;

            // �������г��� ID
            for (cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                City city = CityListCache.GetCityByCityId(cityId);

                // ������еĹ��� ID ���� 0
                if (city.cityBelongKing > 0)
                {
                    // ������еĹ��� ID ��������ҹ��ҵĹ��� ID
                    if (city.cityBelongKing != userKingId)
                    {
                        city.AppointmentPrefect(); // �������г�

                        // ��������С�� 1
                        if (CommonUtils.getRandomInt() % 5 < 1)
                        {
                            byte notFoundGeneralNum = city.getCityNotFoundGeneralNum();

                            // �����������δ�ҵ��Ľ���
                            if (notFoundGeneralNum > 0)
                            {
                                int index = MathUtils.getRandomInt(notFoundGeneralNum);
                                short generalId = city.getNotFoundGeneralId((byte)index);
                                city.removeNotFoundGeneralId(generalId);

                                if (generalId <= 0)
                                    continue;

                                city.AddOppositionGeneralId(generalId); // ��ӵжԽ���
                            }
                        }
                    }

                    city.soldierEatFood(); // ���е�ʿ������ʳ
                    city.paySalaries(); // ֧�����еĹ���

                    short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                    bool haveSY = false;
                    int j;

                    // ���������еĽ���
                    for (j = 0; j < city.getCityGeneralNum(); j++)
                    {
                        short id = officeGeneralIdArray[j];

                        // ����������м��� 4
                        if (GetSkill_4(id, 7))
                        {
                            haveSY = true;
                            break;
                        }
                    }

                    // ���������еĽ���
                    for (j = 0; j < city.getCityGeneralNum(); j++)
                    {
                        short id = officeGeneralIdArray[j];
                        General general = GeneralListCache.GetGeneral(id);

                        // �������������С���������
                        if (general.getCurPhysical() < general.maxPhysical)
                        {
                            // ����м��� 4�������� 10 �� 14 ������
                            if (haveSY)
                            {
                                byte addPhysical = (byte)(10 + CommonUtils.getRandomInt() % 5);
                                general.addCurPhysical(addPhysical);
                            }
                            // �������� 1 �� 3 ������
                            else
                            {
                                byte addPhysical = (byte)(1 + CommonUtils.getRandomInt() % 3);
                                general.addCurPhysical(addPhysical);
                            }
                        }
                    }

                    // ������е�Ԥ������С�ڵ��� 10000
                    if (city.cityReserveSoldier <= 10000)
                    {
                        for (j = 0; j < city.getCityGeneralNum(); j++)
                        {
                            short id = officeGeneralIdArray[j];

                            // ����������м��� 6 �ҳ����˿ڴ��ڵ��� 20000
                            if (GetSkill_4(id, 6) && city.population >= 20000)
                            {
                                int addReserveSoldier = (GeneralListCache.GetGeneral(id)).moral + city.population / 1000 + MathUtils.getRandomInt(200) - 100;

                                if (addReserveSoldier >= 0)
                                {
                                    city.cityReserveSoldier += addReserveSoldier;
                                    city.population -= addReserveSoldier;
                                    break;
                                }
                            }
                        }

                        bool haveRY = false;
                        int k;

                        // ���������еĽ���������Ƿ���м��� 8����
                        for (k = 0; k < city.getCityGeneralNum(); k++)
                        {
                            short id = officeGeneralIdArray[k];

                            if (GetSkill_4(id, 8))
                            {
                                haveRY = true;
                                break;
                            }
                        }

                        // ���������еĽ���
                        for (k = 0; k < city.getCityGeneralNum(); k++)
                        {
                            short id = officeGeneralIdArray[k];
                            General general = GeneralListCache.GetGeneral(id);

                            // ����������ҳ϶�С�� 95
                            if (general.getLoyalty() < 95)
                            {
                                // ����м��� 8 �����ҽ������ҳ϶�С�� 90
                                if (haveRY && general.getLoyalty() < 90)
                                {
                                    byte x = (byte)(5 + CommonUtils.getRandomInt() % 6);

                                    if (general.getLoyalty() + x >= 90)
                                        x = (byte)(90 - general.getLoyalty());

                                    general.AddLoyalty(x);
                                }
                            }
                        }
                    }
                }
                continue;
            }

            // �����Ϸ�·��� 4��8 �� 12
            if (GameInfo.month == 4 || GameInfo.month == 8 || GameInfo.month == 12)
            {
                // �������г��� ID
                for (cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
                {
                    // ������еĹ��� ID ���� 0
                    if ((CityListCache.GetCityByCityId(cityId)).cityBelongKing > 0)
                        RegularGiveOutMoney(cityId); // ���� RegularGiveOutMoney ����
                }

                this.eventId = 10; // �����¼� ID Ϊ 10
                RefreshFeedBack((byte)19); // ���� RefreshFeedBack ����������Ϊ 19
                FloodDisasterCanvans(); // ���� FloodDisasterCanvans ����
            }
            // �����Ϸ�·��� 5 �� 10
            else if (GameInfo.month == 5 || GameInfo.month == 10)
            {
                // �������г��� ID
                for (cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
                {
                    // ������еĹ��� ID ���� 0
                    if ((CityListCache.GetCityByCityId(cityId)).cityBelongKing > 0)
                        RegularGiveOutFood(cityId); // ���� RegularGiveOutFood ����
                }

                this.eventId = 11; // �����¼� ID Ϊ 11
                RefreshFeedBack((byte)19); // ���� RefreshFeedBack ����������Ϊ 19
                FloodDisasterCanvans(); // ���� FloodDisasterCanvans ����
            }

            // �����Ϸ�·��� 3��6��9 �� 12
            if (GameInfo.month == 3 || GameInfo.month == 6 || GameInfo.month == 9 || GameInfo.month == 12)
                for (byte b = 1; b < CityListCache.CITY_NUM; b = (byte)(b + 1))
                {
                    City city = CityListCache.GetCityByCityId(b);
                    short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

                    // ���������еĽ���
                    for (int j = 0; j < city.getCityGeneralNum(); j++)
                    {
                        short generalId = officeGeneralIdArray[j];
                        short kingId = city.cityBelongKing;
                        General general = GeneralListCache.GetGeneral(generalId);

                        // ���㽫������й����Ľ׶β�
                        int d = GetdPhase(general.phase, (GeneralListCache.GetGeneral(kingId)).phase);

                        // ����׶β���� 10 �ҽ������ҳ϶Ȳ����� 100
                        if (d > 10 && general.getLoyalty() != 100)
                        {
                            // ��������С�ڽ׶β�� 80%
                            if (CommonUtils.getRandomInt() % 80 < d)
                            {
                                int val = d / 10;
                                val = Mathf.Max(0, general.getLoyalty() - val);
                                general.decreaseLoyalty((byte)val); // ���ٽ������ҳ϶�
                            }
                        }
                    }
                }

            byte i;

            // �������г��� ID
            for (i = 1; i < CityListCache.CITY_NUM; i = (byte)(i + 1))
            {
                City city = CityListCache.GetCityByCityId(i);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

                // ���������еĽ���
                for (int j = 0; j < city.getCityGeneralNum(); j++)
                {
                    short id = officeGeneralIdArray[j];

                    // ����������м��� 5�Ӷ�
                    if (getSkill_5(id, 1))
                    {
                        General general = GeneralListCache.GetGeneral(id);

                        // ������������̴��ڵ������ֵ 120
                        if (general.IQ >= MathUtils.getRandomInt(120))
                        {
                            byte[] enemyCityId = CountryListCache.getEnemyCityIdArray_new(city.cityId);

                            // �����з�����
                            for (int k = 0; k < enemyCityId.Length; k++)
                            {
                                byte b1 = enemyCityId[k];
                                City beCity = CityListCache.GetCityByCityId(b1);
                                General prefectGeneral = GeneralListCache.GetGeneral(beCity.prefectId);
                                byte b = (byte)(general.force - prefectGeneral.force);

                                // �����������ڵ������ֵ 70
                                if (GetLueDuoByForceD(b) >= MathUtils.getRandomInt(70))
                                {
                                    short food = (short)(int)(beCity.GetFood() * 0.04D - city.GetFood() * 0.01D);
                                    if (food < 0)
                                        food = 0;

                                    short money = (short)(int)(beCity.GetMoney() * 0.04D - city.GetMoney() * 0.01D);
                                    if (money < 0)
                                        money = 0;

                                    short population = (short)(int)(beCity.population * 0.04D - city.population * 0.01D);
                                    if (population < 0)
                                        population = 0;

                                    // ���ٵз�������Դ
                                    beCity.DecreaseFood(food);
                                    beCity.DecreaseMoney(money);
                                    beCity.population -= population;
                                    if (beCity.population < 0)
                                        beCity.population = 0;

                                    // ��ӡ�Ӷ���Ϣ
                                    Debug.Log($"{city.cityName}�Ӷ�{beCity.cityName}��ʳ��{food} ��{money} �˿ڣ�{population}");

                                    // ���ӱ�������Դ
                                    city.AddFood(food);
                                    city.AddMoney(money);
                                    city.population += population;

                                    if (city.population < 0 || city.population > 990000)
                                        city.population = 990000;
                                }
                            }
                            break;
                        }
                    }
                }
            }

            // �������г��� ID
            for (i = 1; i < CityListCache.CITY_NUM; i = (byte)(i + 1))
            {
                City city = CityListCache.GetCityByCityId(i);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

                // ���������еĽ���
                for (int j = 0; j < city.getCityGeneralNum(); j++)
                {
                    short id = officeGeneralIdArray[j];
                    General general = GeneralListCache.GetGeneral(id);

                    // ����������м��� 5����
                    if (getSkill_5(id, 5))
                    {
                        // �������������ֵ���ڵ������ֵ 100
                        if (general.political < MathUtils.getRandomInt(100))
                            continue;

                        int random = MathUtils.getRandomInt(4);

                        // �������ֵ���³�������
                        switch (random)
                        {
                            case 0:
                                city.agro = (short)(city.agro + general.political / 10);
                                if (city.agro > 999)
                                    city.agro = 999;
                                break;
                            case 1:
                                city.trade = (short)(city.trade + general.political / 10);
                                if (city.trade > 999)
                                    city.trade = 999;
                                break;
                            case 2:
                                city.population += general.political * 10;
                                if (city.population > 990000)
                                    city.population = 990000;
                                break;
                            case 3:
                                city.floodControl = (byte)(city.floodControl + MathUtils.getRandomInt(4));
                                if (city.floodControl > 99)
                                    city.floodControl = 99;
                                break;
                        }
                    }

                    // ����������м��� 6����
                    if (getSkill_5(id, 6))
                        for (int k = 0; k < officeGeneralIdArray.Length; k++)
                        {
                            short otherGeneralId = officeGeneralIdArray[k];
                            General otherGeneral = GeneralListCache.GetGeneral(otherGeneralId);
                            otherGeneral.addexperience(MathUtils.getRandomInt(general.force));
                        }

                    // ����������м��� 7�Խ�
                    if (getSkill_5(id, 7))
                        for (int k = 0; k < officeGeneralIdArray.Length; k++)
                        {
                            short otherGeneralId = officeGeneralIdArray[k];
                            General otherGeneral = GeneralListCache.GetGeneral(otherGeneralId);
                            otherGeneral.addIQExp((byte)(1 + MathUtils.getRandomInt(general.IQ / 10)));
                        }
                }
            }

            // �������й���
            for (i = 0; i < CountryListCache.getCountrySize(); i = (byte)(i + 1))
            {
                Country country = CountryListCache.getCountryByIndexId(i);
                List<Alliance> allianceList = country.allianceList;

                // ���������б�
                for (int k = 0; k < allianceList.Count; k++)
                {
                    Alliance alliance = allianceList [k];
                    alliance.Months = (byte)(alliance.Months - 1);

                    // ������˳���ʱ��С�ڵ��� 0
                    if (alliance.Months <= 0)
                    {
                        bool isRemoveAlliance = country.removeAlliance(alliance.countryId);

                        // ������˱��Ƴ�
                        if (isRemoveAlliance)
                        {
                            this.eventId = 14; // �����¼� ID Ϊ 14
                            this.m_byte_fld = alliance.countryId;
                            RefreshFeedBack((byte)19); // ���� RefreshFeedBack ����������Ϊ 19
                            FloodDisasterCanvans(); // ���� FloodDisasterCanvans ����
                        }
                    }
                }
            }

            oppGenMove(); // ���� oppGenMove ����
        }


        private int GetLueDuoByForceD(byte a)
        {
            int result = 30;
            if (a >= 50)
            {
                result = 60;
            }
            else if (a >= 40)
            {
                result = 55;
            }
            else if (a >= 30)
            {
                result = 50;
            }
            else if (a >= 20)
            {
                result = 45;
            }
            else if (a >= 10)
            {
                result = 40;
            }
            else if (a >= 0)
            {
                result = 35;
            }
            return result;
        }

        /// <summary>
        /// ������Ұ������ƶ��߼�
        /// </summary>
        void oppGenMove()
        {
            List<short> vector = new List<short>(); // ����һ���б����洢����ID

            for (byte cityIndex = 0; cityIndex < CityListCache.getCityNum(); cityIndex++)
            {
                City city = CityListCache.getCityByIndex(cityIndex);
                for (byte index = 0; index < city.GetOppositionGeneralNum(); index++)
                {
                    short generalId = city.GetOppositionGeneralId(index);
                    if (generalId > 0)
                    {
                        if (vector.Contains(generalId))
                        {
                            // ����б����Ѱ����ý���ID����������ǰѭ��
                            continue;
                        }
                        vector.Add(generalId); // ��ӽ���ID���б�

                        bool ev = false;
                        byte evKing = 0;

                        // ���ҷ��������Ĺ���
                        for (byte indexId = 1; indexId < CountryListCache.getCountrySize(); indexId++)
                        {
                            if ((GeneralListCache.GetGeneral(CountryListCache.getCountryByIndexId(indexId).countryKingId)).phase == GeneralListCache.GetGeneral(generalId).phase &&
                                CountryListCache.getCountryByIndexId(indexId).countryId > 0)
                            {
                                ev = true;
                                evKing = indexId;
                            }
                        }

                        if (city.cityBelongKing > 0)
                        {
                            short kingPhase = GeneralListCache.GetGeneral(city.cityBelongKing).phase;

                            if (ev)
                            {
                                // ����ҵ����������Ĺ���
                                Country evCountry = CountryListCache.GetCountryByCountryId(evKing);
                                if (evCountry != null && evCountry.countryKingId != city.cityBelongKing)
                                {
                                    // �������������ĳ��У������ж��ֽ����ƶ�
                                    for (int i = 0; i < evCountry.GetHaveCityNum(); i++)
                                    {
                                        byte city1 = evCountry.getCity(i);
                                        if (CityListCache.GetCityByCityId(city1).getCityOfficeGeneralIdArray()[0] == evCountry.countryKingId)
                                        {
                                            OppGenMove(generalId, city.cityId, city1);
                                        }
                                    }
                                }
                            }
                            else if (GetdPhase(kingPhase, GeneralListCache.GetGeneral(generalId).phase) > 5 || city.getCityGeneralNum() >= 10)
                            {
                                // �������Ľ׶β�����5�����߳��н����������ڵ���10
                                byte moveCityId = getOppmovetarCity(city.cityId);
                                if (moveCityId > 0)
                                {
                                    OppGenMove(generalId, city.cityId, moveCityId);
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// ��ȡ��Ұ��������ƶ�����Ŀ�����
        /// </summary>
        /// <param name="curcity"></param>
        /// <returns></returns>
        byte getOppmovetarCity(byte curcity)
        {
            byte tarCityId = curcity;
            short[] connectionCityIds = CityListCache.GetCityByCityId(curcity).connectCityId;
            byte[] canMoveCityIds = new byte[connectionCityIds.Length];
            byte canMoveIndex = 0;

            for (byte index = 0; index < connectionCityIds.Length; index++)
            {
                City city = CityListCache.GetCityByCityId((byte)connectionCityIds[index]);
                if (city.cityId != tarCityId && city.GetOppositionGeneralNum() < 10)
                {
                    canMoveCityIds[canMoveIndex] = city.cityId;
                    canMoveIndex++;
                }
            }

            if (canMoveIndex == 0)
                return 0;

            int moveIndex = MathUtils.getRandomInt(canMoveIndex);
            if (canMoveCityIds[moveIndex] > 0)
                tarCityId = canMoveCityIds[moveIndex];

            return tarCityId;
        }

        /// <summary>
        /// ִ����Ұ������ƶ�
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="curCity"></param>
        /// <param name="tarCity"></param>
        void OppGenMove(short generalId, byte curCity, byte tarCity)
        {
            if (curCity == tarCity)
                return;

            City tCity = CityListCache.GetCityByCityId(tarCity);
            tCity.AddOppositionGeneralId(generalId);

            City cCity = CityListCache.GetCityByCityId(curCity);
            cCity.RemoveOppositionGeneralId(generalId);
        }

        /// <summary>
        /// ִ���¶Ȳ���
        /// </summary>
        void MonthDoThings()
        {
            while (GameInfo.month <= 12)
            {
                TurnTestCanvas();
                if (this.j_byte_fld != 0)
                    return;

                this.s_byte_fld = 0;
                DoThingsInTurn();

                if (GameInfo.isWatch)
                    testGeneral();

                if (this.j_byte_fld != 0)
                    return;
            }
        }

        /// <summary>
        /// ���Խ���
        /// </summary>
        public void testGeneral()
        {
            short generalNum = GeneralListCache.GetTotalGeneralNum();

            for (short k = 0; k < generalNum; k++)
            {
                General general = GeneralListCache.GetGeneralByIndex(k);

                if (general == null)
                {
                    Debug.LogError("ϵͳ�쳣��������" + k + "���佫������.");
                }
                else
                {
                    string cityInfoString = "";
                    int n = 0;

                    for (byte i = 0; i < CityListCache.getCityNum(); i++)
                    {
                        City city = CityListCache.getCityByIndex(i);
                        byte index;

                        // �������еĽ���
                        for (index = 0; index < city.getCityGeneralNum(); index++)
                        {
                            if (city.getCityOfficeGeneralIdArray()[index] == general.generalId)
                            {
                                cityInfoString += city.cityName;
                                n++;
                            }
                        }

                        // �������еĶ��ֽ���
                        for (index = 0; index < city.GetOppositionGeneralNum(); index++)
                        {
                            if (city.GetOppositionGeneralId(index) == general.generalId)
                            {
                                cityInfoString += "[-" + city.cityName + "-]";
                                n++;
                            }
                        }

                        // ���δ�ҵ��Ľ���
                        for (index = 0; index < city.getCityNotFoundGeneralNum(); index++)
                        {
                            if (city.getCityNotFoundGeneralIdArray()[index] == general.generalId)
                            {
                                cityInfoString += "[" + city.cityName + "]";
                                n++;
                            }
                        }
                    }

                    if (n > 1)
                        Debug.LogError("ϵͳ�쳣������" + general.generalName + "�ڳǳأ�" + cityInfoString + " ��ְ��");
                }
            }
        }

        /// <summary>
        /// ������Ϸ��Ϣ��׼���µ�һ��
        /// </summary>
        void NewYearDebt()
        {
            GameInfo.month = 1;
            GameInfo.years = (short)(GameInfo.years + 1);
            GeneralListCache.DebutByYears(GameInfo.years);
        }

        /// <summary>
        /// ��Ҫ����Ϸѭ��
        /// </summary>
        void GameLoop()
        {
            while (true)
            {
                MonthDoThings();
                if (this.j_byte_fld != 0)
                    return;
                NewYearDebt();
            }
        }

        // �����к���
        public void run()
        {
            try
            {
                GameInfo.month = 1;
                GameInfo.years = 189;
                CommonUtils.CleanAllInfo();
                AfterWarSettlement();
                WarGeneralHpSoldierNum();
                if (this.j_byte_fld == 1)
                    this.j_byte_fld = 0;
                GameLoop();
            }
            catch (Exception exception)
            {
                Debug.LogError(exception.ToString());
            }
        }

        // ����������Ϣ
        void void_aq()
        {
            //void_bK();
            //readHighSort(7);

            for (int i = 0; i < 7 && Mathf.Abs(this.higSort[i] - d.disaster_warning_information[i].Length - 1) <= 2; i++) ;
        }

        // ������ID������չ����������
        short[] ExpandGeneralIdArray(short[] aword0, byte num, short generalId)
        {
            short[] aword1 = new short[num + 1];
            for (byte byte1 = 0; byte1 < num; byte1++)
                aword1[byte1] = aword0[byte1];

            aword1[num] = generalId;
            return aword1;
        }

        /// <summary>
        /// ���ù���ID
        /// </summary>
        /// <param name="countryId"></param>
        void void_b_p(byte countryId)
        {
            GameInfo.humanCountryId = countryId;
            this.j_byte_fld = 1;
            //this.gamecanvas.s_void_b_a((byte)4);
        }

        // ���㽫�����
        short CalculateTotalGeneralSoldierNum(short[] generalIdArray, byte generalNum)
        {
            short word0 = 0;

            for (byte byte1 = 0; byte1 < generalNum; byte1++)
                word0 += GeneralListCache.GetGeneral(generalIdArray[byte1]).generalSoldier;

            return word0;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="soldierNum"></param>
        /// <param name="cityId"></param>
        void conscriptionOfUser(short soldierNum, byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            city.cityReserveSoldier += soldierNum; // ���ӳ��д�����Ա
            city.DecreaseMoney((short)((soldierNum + 4) / 5)); // �۳���Ӧ��Ǯ��
            city.population -= soldierNum * 3 / 2; // ���ٳ����˿�
            city.rule = (byte)(city.rule - soldierNum / 500); // �������
            if (city.rule < 0)
                city.rule = 0; // ȷ�����򲻻�С��0
            if (city.population < 0)
                city.population = 0; // ȷ���˿ڲ���С��0
        }

        // ������Ϸ�����ͱ�ǲ���ֵ
        void RefreshFeedBack(byte byte0)
        {
            //this.gamecanvas.s_void_b_a(byte0);
            //this.gamecanvas.repaint();
            this.e_boolean_fld = true;
        }

        // ��ʼ��״̬
        void InitiateCanvasMarkValue()
        {
            this.Y = 0;
            this.X = 0;
            this.d_boolean_fld = true;
            this.a_boolean_fld = true;
            this.c_boolean_fld = true;
            this.p_byte_fld = this.tarCity;
        }

        // ִ�в���6
        void InitiateCanvasMark()
        {
            InitiateCanvasMarkValue();
            RefreshFeedBack((byte)6);
        }

        // ִ�в���6���������û���������
        void EndDecreaseOrder()
        {
            InitiateCanvasMarkValue();
            this.userOrderNum = (byte)(this.userOrderNum - 1);
            if (this.userOrderNum <= 0)
            {
                this.X = 0;
                this.j_byte_fld = 3;
                RefreshFeedBack((byte)4);
            }
            else
            {
                if ((CityListCache.GetCityByCityId(this.tarCity)).cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                    FindTarCity();
                RefreshFeedBack((byte)6);
            }
        }

        /// <summary>
        /// �����û�����ID
        /// </summary>
        void CanvascalculationUserKingIndex()
        {
            //this.gamecanvas.calculationUserKingIndex();
            RefreshFeedBack((byte)4);
        }

        /// <summary>
        /// ����Ŀ����в�����״̬
        /// </summary>
        void CanvasSetTarCity()
        {
            this.tarCity = this.curCity;
            this.Y = (byte)(this.Y + 1);
            DoMenuSwitch();
        }

        /// <summary>
        /// ����AI����ID������״̬
        /// </summary>
        void CanvasSetAiGeneralId()
        {
            this.AIGeneralId = this.HMGeneralId;
            RefreshFeedBack((byte)7);
        }

        /// <summary>
        /// ִ�в�����������״̬
        /// </summary>
        void AppointTheHMGenToTarCity()
        {
            AppointPrefectInCity(this.HMGeneralId, this.tarCity);
            this.Y = (byte)(this.Y + 1);
            DoMenuSwitch();
        }

        /// <summary>
        /// ������ʾ��Ϣ
        /// </summary>
        void AppointTheHMGenToTarCityTips()
        {
            AppointPrefectInCity(this.HMGeneralId, this.tarCity);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[2][3]);
            this.HMGeneralId = this.chooseGeneralIdArray[0];
            this.Y = 6;
        }

        /// <summary>
        /// �������첢����״̬
        /// </summary>
        void CanvasSearchGeneral()
        {
            SearchOrder(this.tarCity, this.HMGeneralId);
            RefreshFeedBack((byte)11);
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// ������ʾ��Ϣ�ķ���
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="info"></param>
        void SetTipsInfo(short generalId, string info)
        {
            this.tipsGeneralId = generalId;
            this.a_java_lang_String_fld = info;
            RefreshFeedBack((byte)10);
        }

        /// <summary>
        /// ��齫���Ƿ񱻹�Ӷ����������ʾ��Ϣ
        /// </summary>
        void EmployResult()
        {
            if (isEmploy(this.tarCity, this.HMGeneralId, this.AIGeneralId))
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[2][0]);
            }
            else
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[2][1]);
            }
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// ִ�н��������������ʾ��Ϣ
        /// </summary>
        void AppointNextPrefect()
        {
            CanvasAppointPrefectInCity(this.HMGeneralId, this.tarCity);
            this.Y = (byte)(this.Y + 1);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[2][3]);
        }

        /// <summary>
        /// ������ID��������
        /// </summary>
        void AppointMainGeneral()
        {
            for (int i1 = 0; i1 < this.chooseGeneralNum; i1++)
            {
                if (this.chooseGeneralIdArray[i1] == this.HMGeneralId)
                {
                    this.chooseGeneralIdArray[i1] = this.chooseGeneralIdArray[0];
                    this.chooseGeneralIdArray[0] = this.HMGeneralId;
                }
            }
            this.Y = (byte)(this.Y + 1);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[0][2]);
        }

        /// <summary>
        /// ���������Ǯ��
        /// </summary>
        /// <param name="needMoney"></param>
        void IsEnoughMoney(int needMoney)
        {
            if (needMoney > CityListCache.GetCityByCityId(this.tarCity).GetMoney())
                this.eventId = CityListCache.GetCityByCityId(this.tarCity).GetMoney();
            RefreshFeedBack((byte)13);
        }

        /// <summary>
        /// �����ڲ������Ǯ��
        /// </summary>
        void NeedMoneyOfInteriorF()
        {
            int needMoney = GetNeedMoneyOfInterior(this.HMGeneralId, (byte)1);
            this.eventId = needMoney;
            IsEnoughMoney(needMoney);
        }

        /// <summary>
        /// ���������Ǯ��
        /// </summary>
        void NeedMoneyOfInteriorL()
        {
            this.eventId = GetNeedMoneyOfInterior(this.HMGeneralId, (byte)3);
            IsEnoughMoney(this.eventId);
        }

        /// <summary>
        /// ���ѳ���
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="generalId"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int Reclaim1(byte cityId, short generalId, int useMoney)
        {
            int j1 = ReclaimValue(generalId, useMoney);
            City city = CityListCache.GetCityByCityId(cityId);
            city.DecreaseMoney((short)useMoney); // �۳�Ǯ��
            if (city.agro + j1 > 999)
                j1 = 999 - city.agro; // ȷ��ũҵ���ᳬ��999
            city.agro = (short)(city.agro + j1); // ����ũҵֵ
            return j1;
        }

        /// <summary>
        /// ִ�п��Ѳ���
        /// </summary>
        void Reclaim2Tip()
        {
            int num = Reclaim1(this.tarCity, this.HMGeneralId, this.eventId);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[3][0] + num + "��");
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// ִ��ó�ײ���
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int Mercantile1(byte byte0, short word0, int useMoney)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            int j1 = MercantileValue(word0, useMoney);
            city.DecreaseMoney((short)useMoney); // �۳�Ǯ��
            if (city.trade + j1 > 999)
                j1 = 999 - city.trade; // ȷ��ó�ײ��ᳬ��999
            city.trade = (short)(city.trade + j1); // ����ó��ֵ
            return j1;
        }

        /// <summary>
        /// ִ��ó�ײ���
        /// </summary>
        void Mercantile2Tip()
        {
            int num = Mercantile1(this.tarCity, this.HMGeneralId, this.eventId);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[3][1] + num + "��");
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// ִ�з������
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        int Tame1(byte byte0, short word0, int i1)
        {
            int j1 = TameValue(word0, i1);
            City city = CityListCache.GetCityByCityId(byte0);
            city.DecreaseMoney((short)i1); // �۳�Ǯ��
            if (city.floodControl + j1 > 99)
                j1 = 99 - city.floodControl; // ȷ������ֵ���ᳬ��99
            city.floodControl = (byte)(city.floodControl + j1); // ���ӷ���ֵ
            return j1;
        }


        /// <summary>
        /// ִ�з�����ʾ����
        /// </summary>
        void Tame2Tip()
        {
            int num = Tame1(this.tarCity, this.HMGeneralId, this.eventId);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[3][3] + num + "��");
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// ����Ѳ�����
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        int Patrol1(byte byte0, short word0, int i1)
        {
            int j1 = PatrolValue(word0, i1);
            City city = CityListCache.GetCityByCityId(byte0);
            city.DecreaseMoney((short)i1); // �۳�Ǯ��
            if (city.population > 990000)
                j1 = 990000 - city.population; // ȷ���˿ڲ�����990000
            if (city.rule < 99)
            {
                if (j1 < 1500)
                {
                    city.rule = (byte)(city.rule + 1);
                }
                else if (j1 < 2500)
                {
                    city.rule = (byte)(city.rule + 2);
                }
                else
                {
                    city.rule = (byte)(city.rule + 3);
                }
            }
            if (city.rule > 99)
                city.rule = 99; // ȷ�����򲻳���99
            city.population += j1; // �����˿�
            return j1;
        }

        /// <summary>
        /// ִ��Ѳ����ʾ����
        /// </summary>
        void Patrol2Tip()
        {
            int num = Patrol1(this.tarCity, this.HMGeneralId, this.eventId);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[3][4] + num + "��");
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// ���㽫�����ɹ��ĸ���
        /// </summary>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        /// <returns></returns>
        int AlienateRate(short gohireId, short behireId)
        {
            General beGeneral = GeneralListCache.GetGeneral(behireId);
            if (beGeneral.getLoyalty() > 95)
                return 0;
            if (beGeneral.getLoyalty() > 87)
            {
                if (MathUtils.getRandomInt(100) > (95 - beGeneral.getLoyalty()) * 2)
                    return 0;
            }
            else
            {
                int i = (95 - beGeneral.getLoyalty()) * (95 - beGeneral.getLoyalty()) / 4;
                if (i > 90)
                    i = 90;
                if (MathUtils.getRandomInt(100) > i)
                    return 0;
            }
            short bepk = (GeneralListCache.GetGeneral(GetOfficeGenBelongKing(behireId))).phase;
            short pk = (GeneralListCache.GetGeneral(GetOfficeGenBelongKing(gohireId))).phase;
            int d1 = GetdPhase(bepk, beGeneral.phase);
            int d2 = GetdPhase(pk, beGeneral.phase);
            int d3 = GetdPhase((GeneralListCache.GetGeneral(gohireId)).phase, beGeneral.phase);
            if (d1 == 0)
                return 0;
            if (d2 == 0)
                return 10 + CommonUtils.getRandomInt() % 15;
            if (d3 > d1 + 10)
                return 0;
            int val = d1 - d2 * 4 / 3 - d3 * 2 + 110 - beGeneral.getLoyalty();
            if (val > 0)
            {
                if (CommonUtils.getRandomInt() % val > 5)
                    return 5 + CommonUtils.getRandomInt() % 10;
                if (CommonUtils.getRandomInt() % 40 < 100 - beGeneral.getLoyalty())
                    return 2 + CommonUtils.getRandomInt() % 5;
                return 1 + CommonUtils.getRandomInt() % 3;
            }
            if (CommonUtils.getRandomInt() % 120 < (GeneralListCache.GetGeneral(gohireId)).IQ - beGeneral.IQ)
                return 1 + CommonUtils.getRandomInt() % 3;
            return 0;
        }

        /// <summary>
        /// �������Ƿ�ɹ�
        /// </summary>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        /// <returns></returns>
        bool IsSuccessOfAlienate(short gohireId, short behireId)
        {
            int i1 = AlienateRate(gohireId, behireId);
            if (i1 > 0)
            {
                General beGeneral = GeneralListCache.GetGeneral(behireId);
                Debug.Log((GeneralListCache.GetGeneral(gohireId)).generalName + "���" + beGeneral.generalName + "�ҳ϶Ƚ��ͣ�" + i1);
                beGeneral.decreaseLoyalty((byte)i1); // �����ҳ϶�
                return true;
            }
            return false;
        }

        /// <summary>
        /// ִ�������Ϣ����
        /// </summary>
        void Alienate2Tip()
        {
            if (IsSuccessOfAlienate(this.HMGeneralId, this.AIGeneralId))
            {
                GeneralListCache.addIQExp(this.HMGeneralId, (byte)1);
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[5][1]);
            }
            else
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[5][0]);
            }
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// ��ȡ���˸���
        /// </summary>
        /// <param name="userKingId"></param>
        /// <param name="otherKingId"></param>
        /// <returns></returns>
        int getAllianceProbability(short userKingId, short otherKingId)
        {
            int dPhase = GetdPhase((GeneralListCache.GetGeneral(userKingId)).phase, (GeneralListCache.GetGeneral(otherKingId)).phase);
            dPhase += CountryListCache.GetCountryByKingId(otherKingId).GetHaveCityNum() - CountryListCache.GetCountryByKingId(userKingId).GetHaveCityNum();
            if (dPhase < MathUtils.getRandomInt(75))
                return 0;
            return 0;
        }

        /// <summary>
        /// ִ�����˲���
        /// </summary>
        void Negotiate()
        {
            short otherKingId = (CountryListCache.GetCountryByCountryId(this.m_byte_fld)).countryKingId;
            Country country = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);
            int probability = getAllianceProbability(country.countryKingId, otherKingId);
            if (probability == 0)
            {
                Alliance alliance = new Alliance(this.m_byte_fld, (byte)12);
                country.AddAlliance(alliance);
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[1][0]);
            }
            else
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[1][1]);
            }
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// ������ý����ҳ϶�
        /// </summary>
        /// <param name="generalId"></param>
        void RandomSetGeneralLoyalty(short generalId)
        {
            GeneralListCache.GetGeneral(generalId).SetLoyalty((byte)(60 + CommonUtils.getRandomInt() % 15));
        }

        /// <summary>
        /// ��齫���Ƿ���Ա����
        /// </summary>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        /// <returns></returns>
        bool BribeRate(short gohireId, short behireId)
        {
            General beGeneral = GeneralListCache.GetGeneral(behireId);
            if (beGeneral.getLoyalty() >= 90)
                return false;
            short pk1 = (GeneralListCache.GetGeneral(GetOfficeGenBelongKing(gohireId))).phase;
            short pk2 = (GeneralListCache.GetGeneral(GetOfficeGenBelongKing(behireId))).phase;
            int d1 = GetdPhase(pk1, beGeneral.phase);
            int d2 = GetdPhase(pk2, beGeneral.phase);
            int d3 = GetdPhase((GeneralListCache.GetGeneral(gohireId)).phase, beGeneral.phase);
            if (d2 == 0)
                return false;
            if (d2 < 5)
            {
                int val = d2 - d1 * 2 - d3 * 2 + (100 - beGeneral.getLoyalty()) / 2;
                if (val > 0)
                    return true;
            }
            else if (d2 <= 10)
            {
                int val = d2 - d1 * 3 / 2 - d3 * 2 + (100 - beGeneral.getLoyalty()) / 2;
                if (val > 0)
                    return true;
            }
            else if (d2 <= 20)
            {
                int val = d2 - d1 - d3 * 2 + (100 - beGeneral.getLoyalty()) / 2;
                if (val > 0)
                    return true;
            }
            else
            {
                int val = d2 - d1 - d3 * 2 + (100 - beGeneral.getLoyalty()) / 3;
                if (val > 0)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// �������罫���һ������ת�Ƶ���һ������
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="cityId"></param>
        /// <param name="word0"></param>
        /// <param name="word1"></param>
        /// <returns></returns>
        bool BribeMovePossibility(byte byte0, byte cityId, short word0, short word1)
        {
            if (BribeRate(word0, word1))
            {
                RandomSetGeneralLoyalty(word1); // ������ý����ҳ϶�
                GeneralListCache.addMoralExp(word0, (byte)5); // ���ӽ���ĵ��¾���
                GeneralListCache.addIQExp(word0, (byte)2); // ���ӽ������������
                City city = CityListCache.GetCityByCityId(cityId);
                city.removeOfficeGeneralId(word1); // �ӳ������Ƴ�����
                City city2 = CityListCache.GetCityByCityId(byte0);
                city2.AddOfficeGeneralId(word1); // ��������ӵ���һ������
                Debug.Log(city2.cityName + "��" + GeneralListCache.GetGeneral(word0).generalName + "����" + city.cityName + "��" + GeneralListCache.GetGeneral(word1).generalName);
                return true;
            }
            return false;
        }

        /// <summary>
        /// ִ�����罫��ת�Ʋ���
        /// </summary>
        void BribeResultTip()
        {
            if (BribeMovePossibility(this.tarCity, this.curCity, this.HMGeneralId, this.AIGeneralId))
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[5][3]);
            }
            else
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[5][2]);
            }
            this.Y = (byte)(this.Y + 1);
        }

        // ���ٽ��쾭�飬������1
        int SchoolIncreaseIQValue(short word0)
        {
            GeneralListCache.GetGeneral(word0).experience = (short)(GeneralListCache.GetGeneral(word0).experience - getLearnNeedExp(word0));
            return 1;
        }

        /// <summary>
        /// ѧԺ���ӽ��������ֵTip
        /// </summary>
        void SchoolTip1()
        {
            GeneralListCache.GetGeneral(this.HMGeneralId).IQ = (byte)(GeneralListCache.GetGeneral(this.HMGeneralId).IQ + SchoolIncreaseIQValue(this.HMGeneralId));
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[4][3]);
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// ҽ�����ӽ�������ֵTip
        /// </summary>
        void HospitalTip1()
        {
            AiTreat(); // ִ����ز���
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[4][4]);
            this.Y = (byte)(this.Y + 1);
        }

    

    
    

        // ִ�� DoMenuSwitch ����
        void DoMenuSwitch()
        {
            // ��ȡ��ǰ������ֽ�ֵ
            byte byte0 = this.i_byte_array2d_fld[this.X][this.Y];
            System.GC.Collect(); // ǿ�ƽ�����������

            // ���� byte0 ��ִֵ�в�ͬ�ķ���
            switch (byte0)
            {
                case 0:
                    InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
                    break;
                case 1:
                    EndDecreaseOrder(); // ִ�� EndDecreaseOrder ����
                    break;
                case 2:
                    CanvascalculationUserKingIndex(); // ִ�� CanvascalculationUserKingIndex ����
                    break;
                case 3:
                    CanvasSetAiGeneralId(); // ִ�� CanvasSetAiGeneralId ����
                    break;
                case 4:
                    this.Y = (byte)(this.Y + 1); // ���� Y ����
                    RefreshFeedBack((byte)10); // ִ�� RefreshFeedBack ����
                    break;
                case 5:
                    RefreshFeedBack((byte)8); // ִ�� RefreshFeedBack ����
                    break;
                case 6:
                    RefreshFeedBack((byte)14); // ִ�� RefreshFeedBack ����
                    break;
                case 8:
                    RefreshFeedBack((byte)5); // ִ�� RefreshFeedBack ����
                    break;
                case 9:
                    RefreshFeedBack((byte)15); // ִ�� RefreshFeedBack ����
                    break;
                case 10:
                    CanvasSearchGeneral(); // ִ�� CanvasSearchGeneral ����
                    break;
                case 11:
                    RefreshFeedBack((byte)12); // ִ�� RefreshFeedBack ����
                    break;
                case 12:
                    NeedMoneyOfInteriorF(); // ִ�� NeedMoneyOfInteriorF ����
                    break;
                case 13:
                    NeedMoneyOfInteriorL(); // ִ�� NeedMoneyOfInteriorL ����
                    break;
                case 14:
                    RefreshFeedBack((byte)16); // ִ�� RefreshFeedBack ����
                    break;
                case 15:
                    RefreshFeedBack((byte)17); // ִ�� RefreshFeedBack ����
                    break;
                case 16:
                    RefreshFeedBack((byte)9); // ִ�� RefreshFeedBack ����
                    break;
                case 17:
                    RefreshFeedBack((byte)18); // ִ�� RefreshFeedBack ����
                    break;
                case 83:
                    AppointTheHMGenToTarCityTips(); // ִ�� AppointTheHMGenToTarCityTips ����
                    break;
                case 84:
                    AppointMainGeneral(); // ִ�� AppointMainGeneral ����
                    break;
                case 85:
                    //void_aS(); // ִ�� void_aS ����
                    break;
                case 86:
                    //void_aR(); // ִ�� void_aR ����
                    break;
                case 87:
                    //saveGame(); // ������Ϸ
                    break;
                case 88:
                    HospitalTip1(); // ִ�� HospitalTip1 ����
                    break;
                case 89:
                    SchoolTip1(); // ִ�� SchoolTip1 ����
                    break;
                case 90:
                    BribeResultTip(); // ִ�� BribeResultTip ����
                    break;
                case 91:
                    Negotiate(); // ִ�� Negotiate ����
                    break;
                case 92:
                    Alienate2Tip(); // ִ�� Alienate2Tip ����
                    break;
                case 93:
                    Patrol2Tip(); // ִ�� Patrol2Tip ����
                    break;
                case 94:
                    Tame2Tip(); // ִ�� Tame2Tip ����
                    break;
                case 95:
                    Mercantile2Tip(); // ִ�� Mercantile2Tip ����
                    break;
                case 96:
                    Reclaim2Tip(); // ִ�� Reclaim2Tip ����
                    break;
                case 97:
                    AppointNextPrefect(); // ִ�� AppointNextPrefect ����
                    break;
                case 98:
                    EmployResult(); // ִ�� EmployResult ����
                    break;
                case 99:
                    AppointTheHMGenToTarCity(); // ִ�� AppointTheHMGenToTarCity ����
                    break;
                case 100:
                    CanvasSetTarCity(); // ִ�� CanvasSetTarCity ����
                    break;
            }
        }


        // ��� e_boolean_fld �ֶβ����ز���ֵ
        bool CanvasMark1()
        {
            if (this.e_boolean_fld)
            {
                this.e_boolean_fld = false; // ���� e_boolean_fld Ϊ false
                return true; // ���� true
            }
            return false; // ���� false
        }

        // ִ�� CanvasMark1Refresh ����
        void CanvasMark1Refresh(byte cityId, int i1)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            if (i1 == 1)
            {
                InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
                return;
            }

            if (this.X == 1 || this.X == 3)
            {
                this.p_byte_fld = this.tarCity; // ���� p_byte_fld ΪĿ����� ID
            }
            else
            {
                this.p_byte_fld = cityId; // ���� p_byte_fld Ϊ����ĳ��� ID
            }
            this.curCity = cityId; // ���µ�ǰ���� ID
            this.Y = (byte)(this.Y + 1); // ���� Y ����
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�и������
        void RebornModel(int i1)
        {
            short[] cityOfficeGeneralIdArray;
            byte generalNum;

            if (this.X != 22 && !CanvasMark1()) // ��� X ���� 22 ���� CanvasMark1() ���� false���˳�����
                return;

            if (this.d_boolean_fld)
            {
                cityOfficeGeneralIdArray = CityListCache.GetCityByCityId(this.p_byte_fld).getCityOfficeGeneralIdArray(); // ��ȡ���еĽ��� ID ����
                generalNum = (byte)cityOfficeGeneralIdArray.Length; // ��ȡ��������
            }
            else
            {
                cityOfficeGeneralIdArray = this.canToDoGeneral_Array; // ��ȡ���Բ����Ľ�������
                generalNum = this.canToDoGeneralNum; // ��ȡ���Բ����Ľ�������
                this.d_boolean_fld = true; // ���� d_boolean_fld Ϊ true
            }

            if (i1 == 1)
            {
                RebornGeneralMark(cityOfficeGeneralIdArray, generalNum); // ִ�� RebornGeneralMark ����
                if (this.X == 22)
                {
                    this.j_byte_fld = 1; // ���� j_byte_fld Ϊ 1
                    return;
                }
                InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
                return;
            }

            byte byte1 = 0;
            while (byte1 < generalNum)
            {
                if ((GeneralListCache.GetGeneral(cityOfficeGeneralIdArray[byte1])).IsDie) // �����������
                {
                    this.HMGeneralId = cityOfficeGeneralIdArray[byte1]; // ���� HMGeneralId Ϊ���� ID
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).IsDie = false; // ���������Ϊδ����
                    break;
                }
                byte1 = (byte)(byte1 + 1); // ��������
            }

            if (this.X == 22)
            {
                this.j_byte_fld = 2; // ���� j_byte_fld Ϊ 2
                return;
            }

            if (this.X == 9)
                this.e_boolean_fld = true; // ��� X Ϊ 9������ e_boolean_fld Ϊ true

            this.Y = (byte)(this.Y + 1); // ���� Y ����
            this.p_byte_fld = this.tarCity; // ���� p_byte_fld ΪĿ����� ID
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� AppointPrefectInCity ����
        void AppointPrefectInCity(short generalId, byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId); // ��ȡ���ж���
            city.AppointmentPrefect(generalId); // ��������Ϊ���й�Ա
        }

        // ִ�� CanvasAppointPrefectInCity ����
        void CanvasAppointPrefectInCity(short word0, byte byte0)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            AppointPrefectInCity(word0, byte0); // ִ�� AppointPrefectInCity ����
        }

        // ִ�� MoveKingAppointPrefectInCity ����
        void MoveKingAppointPrefectInCity()
        {
            City city = CityListCache.GetCityByCityId(this.curCity); // ��ȡ��ǰ���ж���
            for (byte byte0 = 0; byte0 < this.chooseGeneralNum; byte0 = (byte)(byte0 + 1))
                city.AddOfficeGeneralId(this.chooseGeneralIdArray[byte0]); // ������ ID ��ӵ�����

            if (city.cityBelongKing == this.chooseGeneralIdArray[0]) // ������еĹ��� ID ƥ���һ��ѡ��Ľ��� ID
            {
                this.e_boolean_fld = true; // ���� e_boolean_fld Ϊ true
                CanvasAppointPrefectInCity(this.chooseGeneralIdArray[0], this.curCity); // ִ�� CanvasAppointPrefectInCity ����
            }
        }

        // ִ�� MoveOffGeneral ����
        void MoveOffGeneral()
        {
            City city = CityListCache.GetCityByCityId(this.tarCity); // ��ȡĿ����ж���
            for (int i = 0; i < this.chooseGeneralNum; i++)
            {
                short generalId = this.chooseGeneralIdArray[i]; // ��ȡ���� ID
                city.removeOfficeGeneralId(generalId); // �ӳ������Ƴ����� ID
            }
        }


        // ִ�� MoveKingAppointPrefectInCity �� MoveOffGeneral ����
        void MoveKingReplaceGeneral()
        {
            MoveKingAppointPrefectInCity(); // ִ�� MoveKingAppointPrefectInCity ����
            MoveOffGeneral(); // ִ�� MoveOffGeneral ����
        }

        // ִ�� RemoveGeneralIdInArray ����
        void RemoveGeneralIdInArray()
        {
            City city = CityListCache.GetCityByCityId(this.tarCity); // ��ȡĿ����ж���
            short[] officeGeneralId = city.getCityOfficeGeneralIdArray(); // ��ȡ���еĽ��� ID ����

            // �������н��� ID ������ӳ������Ƴ�
            for (int i = 0; i < officeGeneralId.Length; i++)
            {
                short generalId = officeGeneralId[i];
                city.removeOfficeGeneralId(generalId); // �ӳ������Ƴ�����
            }
        }

        // ִ�� CanvasMoveKingRefresh ����
        void CanvasMoveKingRefresh(int i1)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            if (i1 == 1)
            {
                InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
                return;
            }

            if (this.X == 1)
            {
                MoveKingAppointPrefectInCity(); // ִ�� MoveKingAppointPrefectInCity ����
                RemoveGeneralIdInArray(); // ִ�� RemoveGeneralIdInArray ����
                this.tarCity = this.curCity; // ����Ŀ�����Ϊ��ǰ����
                this.Y = 4; // ���� Y ����Ϊ 4
            }
            else
            {
                this.HMGeneralId = this.chooseGeneralIdArray[0]; // ���� HMGeneralId Ϊѡ��Ľ��� ID
                this.Y = 2; // ���� Y ����Ϊ 2
            }
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� RebornGeneralMark ����
        void RebornGeneralMark(short[] aword0, byte byte0)
        {
            for (byte byte1 = 0; byte1 < byte0; byte1 = (byte)(byte1 + 1))
                (GeneralListCache.GetGeneral(aword0[byte1])).IsDie = false; // ���������Ϊδ����
        }

        // ִ�� MoveTooMuchRebornGeneral ����
        void MoveTooMuchRebornGeneral(int i1)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            City city = CityListCache.GetCityByCityId(this.tarCity); // ��ȡĿ����ж���
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ���еĽ��� ID ����

            if (i1 == 1)
            {
                RebornGeneralMark(officeGeneralIdArray, city.getCityGeneralNum()); // ִ�� RebornGeneralMark ����
                InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
                return;
            }

            bool flag = false;
            this.a_boolean_fld = true; // ���� a_boolean_fld Ϊ true
            this.chooseGeneralNum = 0; // ����ѡ��Ľ�������

            // �������� ID ���飬���������Ľ���
            for (byte byte0 = 0; byte0 < city.getCityGeneralNum(); byte0 = (byte)(byte0 + 1))
            {
                if ((GeneralListCache.GetGeneral(officeGeneralIdArray[byte0])).IsDie) // �����������
                {
                    if (byte0 == 0)
                        flag = true; // ����ǵ�һ������������ flag Ϊ true
                    this.chooseGeneralNum = (byte)(this.chooseGeneralNum + 1); // ����ѡ��Ľ�������
                    this.chooseGeneralIdArray[this.chooseGeneralNum] = officeGeneralIdArray[byte0]; // ��ӽ��� ID ��ѡ������
                    (GeneralListCache.GetGeneral(officeGeneralIdArray[byte0])).IsDie = false; // ���������Ϊδ����
                }
            }

            this.tipsGeneralId = this.chooseGeneralIdArray[0]; // ������ʾ���� ID

            if (this.X == 1)
            {
                if (this.chooseGeneralNum + CityListCache.GetCityByCityId(this.curCity).getCityGeneralNum() > 10)
                {
                    SetTipsInfo(this.chooseGeneralIdArray[0], "�ƶ��佫������!"); // ������ʾ��Ϣ
                    this.Y = 6; // ���� Y ����Ϊ 6
                    return;
                }
                this.a_java_lang_String_fld = d.DoThingsResultInfo[0][0]; // �����ַ����ֶ�
            }

            if (this.chooseGeneralNum == city.getCityGeneralNum())
            {
                //this.gamecanvas.Void_m(); // ִ�� gamecanvas �� Void_m ����
                this.e_boolean_fld = true; // ���� e_boolean_fld Ϊ true
                //this.gamecanvas.Repaint(); // ���»��� gamecanvas
                return;
            }

            if (this.X == 1)
            {
                if (flag)
                {
                    this.p_byte_fld = this.tarCity; // ���� p_byte_fld ΪĿ�����
                    this.c_boolean_fld = false; // ���� c_boolean_fld Ϊ false
                    this.Y = 2; // ���� Y ����Ϊ 2
                }
                else
                {
                    this.Y = 4; // ���� Y ����Ϊ 4
                }
                MoveKingReplaceGeneral(); // ִ�� MoveKingReplaceGeneral ����
            }
            else
            {
                this.Y = (byte)(this.Y + 1); // ���� Y ����
            }
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� CanvasMarkReInitTOMenu ����
        void CanvasMarkReInitTOMenu(int i1)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            if (i1 == 1)
            {
                InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
                return;
            }

            this.Y = (byte)(this.Y + 1); // ���� Y ����
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� DoCanvasMarkReInitTOMenu ����
        void DoCanvasMarkReInitTOMenu(int i1)
        {
            CanvasMarkReInitTOMenu(i1); // ִ�� CanvasMarkReInitTOMenu ����
        }

        // ִ�� CheckCanvasMarkReInitTOMenu ����
        void CheckCanvasMarkReInitTOMenu()
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�����͵����ǳط���
        void TransportationAdjustCity(short[] aword0)
        {
            CityListCache.GetCityByCityId(this.tarCity).DecreaseMoney(aword0[0]); // ��Ŀ����м��ٽ�Ǯ
            CityListCache.GetCityByCityId(this.tarCity).DecreaseFood(aword0[1]); // ��Ŀ����м�����ʳ
            (CityListCache.GetCityByCityId(this.tarCity)).treasureNum = (byte)((CityListCache.GetCityByCityId(this.tarCity)).treasureNum - aword0[2]); // ����Ŀ����еı�������
            CityListCache.GetCityByCityId(this.curCity).AddMoney(aword0[0]); // ��ǰ������ӽ�Ǯ
            CityListCache.GetCityByCityId(this.curCity).AddFood(aword0[1]); // ��ǰ���������ʳ
            (CityListCache.GetCityByCityId(this.curCity)).treasureNum = (byte)((CityListCache.GetCityByCityId(this.curCity)).treasureNum + aword0[2]); // ���µ�ǰ���еı�������
        }

        // ִ������ָ���
        void TransportationOrder(int i1, short[] aword0)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            if (i1 == 1)
            {
                InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
            }
            else
            {
                TransportationAdjustCity(aword0); // ִ�� TransportationAdjustCity ����
                bool needZhiLing = true; // ����Ƿ���Ҫָ��
                City city = CityListCache.GetCityByCityId(this.tarCity); // ��ȡĿ����ж���
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ���еĽ��� ID ����

                // ���������Ƿ��н���ӵ�м��� 4
                for (int i = 0; i < city.getCityGeneralNum(); i++)
                {
                    short id = officeGeneralIdArray[i];
                    if (GetSkill_4(id, 9))
                    {
                        needZhiLing = false; // ����н���ӵ�иü��ܣ����Ϊ����Ҫָ��
                        break;
                    }
                }

                if (needZhiLing)
                {
                    this.Y = (byte)(this.Y + 1); // �����Ҫָ����� Y ����
                }
                else
                {
                    this.Y = (byte)(this.Y + 2); // �������Ҫָ����� Y ����
                }
                SetTipsInfo(city.prefectId, d.DoThingsResultInfo[0][0]); // ������ʾ��Ϣ
            }
        }


        // ִ�� PrepareStartWar ����
        void PrepareStartWar(short word0, short word1, int i1)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            if (i1 == 1)
            {
                InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
                return;
            }

            // ����ս���е���Դ
            this.humanMoney_inWar = word0; // ����ս���еĽ�Ǯ
            this.humanGrain_inWar = word1; // ����ս���е���ʳ
            this.Y = 6; // ���� Y ����Ϊ 6
            this.a_java_lang_String_fld = d.DoThingsResultInfo[0][2]; // �����ַ����ֶ�

            // ����ѡ��Ľ��������ͳ��еĽ����������д���
            if (this.chooseGeneralNum != CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum())
            {
                if (this.chooseGeneralIdArray[0] == CityListCache.GetCityByCityId(this.tarCity).prefectId)
                {
                    this.c_boolean_fld = false; // ���� c_boolean_fld Ϊ false
                    this.p_byte_fld = this.tarCity; // ���� p_byte_fld ΪĿ�����
                    this.Y = 3; // ���� Y ����Ϊ 3
                }
                else
                {
                    this.c_boolean_fld = false; // ���� c_boolean_fld Ϊ false
                    this.d_boolean_fld = false; // ���� d_boolean_fld Ϊ false

                    // ����ѡ��Ľ�������ִ�н�������
                    for (int j1 = 0; j1 < this.chooseGeneralNum; j1++)
                        this.canToDoGeneral_Array[j1] = this.chooseGeneralIdArray[j1];
                    this.canToDoGeneralNum = this.chooseGeneralNum; // ���¿�ִ�н�������
                    this.Y = 5; // ���� Y ����Ϊ 5
                }
            }

            MoveOffGeneral(); // ִ�� MoveOffGeneral ����
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ��������
        void rewardGeneral(short money)
        {
            General general = GeneralListCache.GetGeneral(this.HMGeneralId); // ��ȡ��������
            City city = CityListCache.GetCityByCityId(this.tarCity); // ��ȡĿ����ж���

            if (money == 200)
            {
                city.treasureNum = (byte)(city.treasureNum - 1); // �ӳ����м��ٱ�������
                general.AddLoyalty(false); // ���ӽ������ҳ϶�
            }
            else
            {
                city.DecreaseMoney(money); // �ӳ����м��ٽ�Ǯ
                general.AddLoyalty(true); // ���ӽ������ҳ϶�
            }
        }

        // ִ�� RewardGeneralTips ����
        void RewardGeneralTips(short money, int i1)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            if (i1 == 1)
            {
                InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
            }
            else
            {
                rewardGeneral(money); // ��������
                this.Y = (byte)(this.Y + 1); // ���� Y ����
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[2][2]); // ������ʾ��Ϣ
            }
        }

        // ִ�� void_i_l ����
        void void_i_l(int i1)
        {
            CanvasMarkReInitTOMenu(i1); // ִ�� CanvasMarkReInitTOMenu ����
        }

        // ִ�� void_bi_c ����
        void void_bi_c(byte byte0, int i1)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            if (i1 == 1)
            {
                InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
                return;
            }

            this.m_byte_fld = byte0; // ���� m_byte_fld Ϊ byte0
            this.Y = (byte)(this.Y + 1); // ���� Y ����
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� void_aZ ����
        void void_aZ()
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            this.Y = 0; // ���� Y ����Ϊ 0
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� void_i_m ����
        void void_i_m(int i1)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            if (i1 == 1)
            {
                InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
            }
            else
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, d.DoThingsResultInfo[4][0]); // ������ʾ��Ϣ
                this.Y = (byte)(this.Y + 1); // ���� Y ����
            }
        }

        // ִ�� BuyWeaponTips ����
        void BuyWeaponTips(int i1)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            switch (i1)
            {
                case 0:
                    SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[4][1]); // ������ʾ��Ϣ
                    this.Y = (byte)(this.Y + 1); // ���� Y ����
                    break;
                case 1:
                    InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
                    break;
                case 2:
                    SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "�ʲƲ���"); // ������ʾ��Ϣ
                    this.Y = 3; // ���� Y ����Ϊ 3
                    break;
                case 3:
                    SetTipsInfo(this.HMGeneralId, "��������,�����޷�ʹ�ô�����"); // ������ʾ��Ϣ
                    this.Y = 3; // ���� Y ����Ϊ 3
                    break;
            }
        }

        // ִ�� void_i_o ����
        void void_i_o(int i1)
        {
            if (!CanvasMark1()) // ��� CanvasMark1() �Ľ��
                return; // ������� false���˳�����

            if (i1 == 5)
            {
                InitiateCanvasMark(); // ִ�� InitiateCanvasMark ����
                return;
            }

            this.eventId = i1; // ���� eventId Ϊ i1
            this.Y = (byte)(this.Y + 1); // ���� Y ����
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� void_b_s ����
        void void_b_s(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }


        // ִ�� MoveOrderTips ����
        void MoveOrderTips(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            // �������г��У�����Ƿ��п����ƶ��ĳ���
            for (byte byte1 = 1; byte1 < CityListCache.CITY_NUM; byte1 = (byte)(byte1 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte1); // ��ȡ���ж���
                if (city.cityBelongKing == CityListCache.GetCityByCityId(this.tarCity).cityBelongKing && byte1 != this.tarCity)
                {
                    this.a_boolean_fld = false; // ���� a_boolean_fld Ϊ false
                    DoMenuSwitch(); // ִ�� DoMenuSwitch ����
                    return;
                }
            }
            // ���û�з��������ĳ��У�������ʾ��Ϣ�� Y ����
            this.Y = 6;
            SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "��ǰ�޿��ƶ��ĳ�!");
        }

        // ִ�� TransportationOrderTips ����
        void TransportationOrderTips(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            // �������г��У�����Ƿ��п������͵ĳ���
            for (byte byte1 = 1; byte1 < CityListCache.CITY_NUM; byte1 = (byte)(byte1 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte1); // ��ȡ���ж���
                if (city.cityBelongKing == CityListCache.GetCityByCityId(this.tarCity).cityBelongKing && byte1 != this.tarCity)
                {
                    DoMenuSwitch(); // ִ�� DoMenuSwitch ����
                    return;
                }
            }
            // ���û�з��������ĳ��У�������ʾ��Ϣ�� Y ����
            this.Y = 3;
            SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "��ǰ�޿����͵ĳ�!");
        }

        // ִ�� RewardOrder ����
        void RewardOrder(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0
            this.canToDoGeneralNum = 0; // ��ʼ����ִ�н�������

            City city = CityListCache.GetCityByCityId(this.tarCity); // ��ȡĿ����ж���
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ�����еĽ��� ID ����

            // ���������еĽ���������ҳ϶�
            for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]); // ��ȡ��������
                if (general.getLoyalty() < 99) // ��������ҳ϶�С�� 99
                {
                    this.canToDoGeneralNum = (byte)(this.canToDoGeneralNum + 1); // ���ӿ�ִ�н�������
                    this.canToDoGeneral_Array[this.canToDoGeneralNum] = officeGeneralIdArray[byte1]; // ��ӽ��� ID ��������
                }
            }

            if (this.canToDoGeneralNum > 0)
            {
                this.d_boolean_fld = false; // ���� d_boolean_fld Ϊ false
                DoMenuSwitch(); // ִ�� DoMenuSwitch ����
            }
            else
            {
                this.Y = 3; // ���� Y ����Ϊ 3
                SetTipsInfo(city.prefectId, "��ʿ�����Ĳ���!"); // ������ʾ��Ϣ
            }
        }

        // ִ�� SearchOrder ����
        void SearchOrder(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            City city = CityListCache.GetCityByCityId(this.tarCity); // ��ȡĿ����ж���

            if (city.getCityGeneralNum() == 10) // ��������еĽ�������Ϊ 10
            {
                SetTipsInfo(city.prefectId, "������������!"); // ������ʾ��Ϣ
                this.Y = 4; // ���� Y ����Ϊ 4
                return;
            }

            if (city.GetOppositionGeneralNum() == 0) // �����Ұ��������Ϊ 0
            {
                SetTipsInfo(city.prefectId, "Ұ������!"); // ������ʾ��Ϣ
                this.Y = 4; // ���� Y ����Ϊ 4
                return;
            }

            this.d_boolean_fld = false; // ���� d_boolean_fld Ϊ false
            this.canToDoGeneralNum = city.GetOppositionGeneralNum(); // ���ÿ�ִ�н�������

            if (this.canToDoGeneralNum > 10)
                this.canToDoGeneralNum = 10; // �����ִ�н����������� 10������Ϊ 10

            // ����Ұ���� ID ��ӵ�������
            for (byte byte1 = 0; byte1 < this.canToDoGeneralNum; byte1 = (byte)(byte1 + 1))
                this.canToDoGeneral_Array[byte1] = city.GetOppositionGeneralId(byte1);

            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� AppointVeto ����
        void AppointVeto(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            City city = CityListCache.GetCityByCityId(this.tarCity); // ��ȡĿ����ж���

            if (city.cityBelongKing == city.prefectId) // ������еĹ��� ID ����е������� ID ��ͬ
            {
                SetTipsInfo(city.cityBelongKing, d.DoThingsResultInfo[2][4]); // ������ʾ��Ϣ
                this.Y = 2; // ���� Y ����Ϊ 2
                return;
            }

            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ����Ƿ����㹻�Ľ�Ǯ
        bool haveEnoughMoney()
        {
            if (CityListCache.GetCityByCityId(this.tarCity).GetMoney() == 0) // ���Ŀ����еĽ�ǮΪ 0
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "�ʲƲ���"); // ������ʾ��Ϣ
                this.Y = 4; // ���� Y ����Ϊ 4
                return true; // ���� true
            }
            return false; // ���� false
        }

        // ִ�п��Ѳ���
        void Reclaim(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            if (haveEnoughMoney()) // ����Ƿ����㹻�Ľ�Ǯ
                return;

            if (CityListCache.GetCityByCityId(this.tarCity).agro == 999) // ������е�ũҵֵΪ 999
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, d.DoThingsResultInfo[3][2]); // ������ʾ��Ϣ
                this.Y = 4; // ���� Y ����Ϊ 4
                return;
            }

            this.b_int_fld = 0; // ���� b_int_fld Ϊ 0
            this.Y = 0; // ���� Y ����Ϊ 0
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ��Ȱ�̲���
        void Mercantile(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            if (haveEnoughMoney()) // ����Ƿ����㹻�Ľ�Ǯ
                return;

            if (CityListCache.GetCityByCityId(this.tarCity).trade == 999) // ������е�ó��ֵΪ 999
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, d.DoThingsResultInfo[3][5]); // ������ʾ��Ϣ
                this.Y = 4; // ���� Y ����Ϊ 4
                return;
            }

            this.b_int_fld = 1; // ���� b_int_fld Ϊ 1
            this.Y = 0; // ���� Y ����Ϊ 0
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }


        // ִ�� TameFlood ����
        void TameFlood(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            if (haveEnoughMoney()) // ����Ƿ����㹻�Ľ�Ǯ
                return;

            // �����еĺ�ˮ����ֵ
            if (CityListCache.GetCityByCityId(this.tarCity).floodControl == 99)
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, d.DoThingsResultInfo[3][6]); // ������ʾ��Ϣ
                this.Y = 4; // ���� Y ����Ϊ 4
                return;
            }

            this.b_int_fld = 2; // ���� b_int_fld Ϊ 2
            this.Y = 0; // ���� Y ����Ϊ 0
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� Patrol ����
        void Patrol(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            if (haveEnoughMoney()) // ����Ƿ����㹻�Ľ�Ǯ
                return;

            // �����е��˿�����
            if (CityListCache.GetCityByCityId(this.tarCity).population == 990000)
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, d.DoThingsResultInfo[3][7]); // ������ʾ��Ϣ
                this.Y = 4; // ���� Y ����Ϊ 4
                return;
            }

            this.b_int_fld = 3; // ���� b_int_fld Ϊ 3
            this.Y = 0; // ���� Y ����Ϊ 0
            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� Employ ����
        void Employ(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            // �������еĽ�������
            if (CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum() == 10)
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "������������!"); // ������ʾ��Ϣ
                this.Y = 5; // ���� Y ����Ϊ 5
                return;
            }

            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� Shopping ����
        void Shopping(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            // �������Ƿ�������
            if ((this.k_byte_array1d_fld[this.tarCity] & 0x8) != 8)
            {
                this.Y = 2; // ���� Y ����Ϊ 2
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "����������,�޷���������"); // ������ʾ��Ϣ
                return;
            }

            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ִ�� Smithy ����
        void Smithy(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            // �������Ƿ���������
            if ((this.k_byte_array1d_fld[this.tarCity] & 0x1) != 1)
            {
                this.Y = 3; // ���� Y ����Ϊ 3
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "������������,�޷���������"); // ������ʾ��Ϣ
                return;
            }

            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // ���㽫����ѧϰ���
        short AIDoLearn(byte cityId)
        {
            short learnNum = 0; // ��ʼ��ѧϰ����
            City city = CityListCache.GetCityByCityId(cityId); // ��ȡ���ж���
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ�����еĽ��� ID ����

            // ���������еĽ���
            for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
            {
                short generalId = officeGeneralIdArray[byte1]; // ��ȡ���� ID
                General general = GeneralListCache.GetGeneral(generalId); // ��ȡ��������

                // ���ݽ����� IQ ֵ�������Ƿ����ѧϰ
                if (general.IQ < 120)
                {
                    switch (general.IQ / 10)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            if (general.experience >= getLearnNeedExp(generalId)) // ����Ƿ����㹻�ľ���
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // ���� IQ ֵ
                            learnNum = (short)(learnNum + 1); // ����ѧϰ����
                            break;
                        case 5:
                            if (general.experience >= getLearnNeedExp(generalId) && general.level >= 2)
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // ���� IQ ֵ
                            learnNum = (short)(learnNum + 1); // ����ѧϰ����
                            break;
                        case 6:
                            if (general.experience >= getLearnNeedExp(generalId) && general.level >= 3)
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // ���� IQ ֵ
                            learnNum = (short)(learnNum + 1); // ����ѧϰ����
                            break;
                        case 7:
                            if (general.experience >= getLearnNeedExp(generalId) && general.level >= 4)
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // ���� IQ ֵ
                            learnNum = (short)(learnNum + 1); // ����ѧϰ����
                            break;
                        case 8:
                            if (general.experience >= getLearnNeedExp(generalId) && general.level >= 7)
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // ���� IQ ֵ
                            break;
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                            if (general.experience >= getLearnNeedExp(generalId) && general.level == 8)
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // ���� IQ ֵ
                            learnNum = (short)(learnNum + 1); // ����ѧϰ����
                            break;
                    }
                }
            }
            return learnNum; // ����ѧϰ����
        }

        // ����Ƿ����ѧϰ
        bool canLearn(byte cityId)
        {
            bool flag = false; // ��ʼ����־Ϊ false
            this.canToDoGeneralNum = 0; // ��ʼ����ִ�н�������
            City city = CityListCache.GetCityByCityId(cityId); // ��ȡ���ж���
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ�����еĽ��� ID ����

            // ���������еĽ���
            for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]); // ��ȡ��������
                if (general.IQ < 120 && general.experience >= getLearnNeedExp(officeGeneralIdArray[byte1])) // ��齫���� IQ �;���
                {
                    this.canToDoGeneralNum = (byte)(this.canToDoGeneralNum + 1); // ���ӿ�ִ�н�������
                    this.canToDoGeneral_Array[this.canToDoGeneralNum] = officeGeneralIdArray[byte1]; // ��ӽ��� ID ��������
                }
            }
            return flag; // ���ر�־
        }

        // ִ�� School ����
        void School(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0

            // �������Ƿ���ѧ��
            if ((this.k_byte_array1d_fld[this.tarCity] & 0x2) == 2)
            {
                canLearn(this.tarCity); // ����Ƿ����ѧϰ
                if (this.canToDoGeneralNum > 0)
                {
                    this.d_boolean_fld = false; // ���� d_boolean_fld Ϊ false
                    DoMenuSwitch(); // ִ�� DoMenuSwitch ����
                }
                else
                {
                    SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "����û�п���ѧϰ���佫"); // ������ʾ��Ϣ
                    this.Y = 2; // ���� Y ����Ϊ 2
                }
            }
            else
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "������ѧ��,�޷���ϰ����"); // ������ʾ��Ϣ
                this.Y = 2; // ���� Y ����Ϊ 2
            }
        }

        // ��ȡѧϰ���辭��
        short getLearnNeedExp(short generalId)
        {
            short needExp = 0; // ��ʼ�����辭��
            needExp = (short)(200 + (GeneralListCache.GetGeneral(generalId).IQ * 50)); // �������辭��
            return needExp; // �������辭��
        }


        // ִ�� Hospital ����
        void Hospital(byte byte0)
        {
            bool flag = false; // ��ʼ����־Ϊ false
            this.X = byte0; // ���� X Ϊ byte0
            City city = CityListCache.GetCityByCityId(this.tarCity); // ��ȡ���ж���
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ�����еĽ��� ID ����

            // �������Ƿ���ҽԺ
            if ((this.k_byte_array1d_fld[this.tarCity] & 0x4) != 4)
            {
                SetTipsInfo(city.prefectId, "������ҽԺ,�޷������佫"); // ������ʾ��Ϣ
                this.Y = 3; // ���� Y ����Ϊ 3
                return;
            }

            this.canToDoGeneralNum = 0; // ��ʼ�����Դ���Ľ�������
            for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]); // ��ȡ��������
                if (general.getCurPhysical() < general.maxPhysical) // ��齫���ĵ�ǰ�����Ƿ�С���������
                {
                    this.canToDoGeneralNum = (byte)(this.canToDoGeneralNum + 1); // ���ӿ��Դ���Ľ�������
                    this.canToDoGeneral_Array[this.canToDoGeneralNum] = officeGeneralIdArray[byte1]; // ������ ID ��ӵ�������
                }
            }

            // ���ݳ��е��ʽ����������һ������
            if (this.canToDoGeneralNum > 0)
            {
                if (city.GetMoney() >= 50) // �������Ƿ����㹻���ʽ�
                {
                    this.d_boolean_fld = false; // ���� d_boolean_fld Ϊ false
                    DoMenuSwitch(); // ִ�� DoMenuSwitch ����
                }
                else
                {
                    SetTipsInfo(city.prefectId, "�ʲƲ���"); // ������ʾ��Ϣ
                    this.Y = 3; // ���� Y ����Ϊ 3
                }
            }
            else
            {
                SetTipsInfo(city.prefectId, "��ʿ����������!"); // ������ʾ��Ϣ
                this.Y = 3; // ���� Y ����Ϊ 3
            }
        }

        // ִ�� Alienate ����
        void Alienate(byte byte0)
        {
            this.X = byte0; // ���� X Ϊ byte0
            Country userCountry = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId); // ��ȡ�û����Ҷ���
            this.noAllianceCountryIdArray = userCountry.GetNoCountryIdAllianceCountryIdArray(); // ��ȡ�����˹��ҵ� ID ����
            this.x_byte_fld = (byte)this.noAllianceCountryIdArray.Length; // ���� x_byte_fld Ϊ�����˹�������

            // ����û������Ƿ�������������ͬ��
            if (userCountry.GetAllianceSize() == CountryListCache.getCountrySize() - 1)
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "������������ͬ��"); // ������ʾ��Ϣ
                this.Y = 4; // ���� Y ����Ϊ 4
                return;
            }

            DoMenuSwitch(); // ִ�� DoMenuSwitch ����
        }

        // �������Ƿ���������
        bool theCityIsAlliance(byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId); // ��ȡ���ж���
            if (city.cityBelongKing == 0)
                return false; // ����û�й��������� false

            Country otherCountry = CountryListCache.GetCountryByKingId(city.cityBelongKing); // ��ȡ���ڸó��еĹ��Ҷ���
            if (otherCountry == null)
                return false; // ���Ҷ���Ϊ�գ����� false

            Alliance alliance = otherCountry.getAllianceById(GameInfo.humanCountryId); // ��ȡ���˶���
            return (alliance != null); // ������˶���Ϊ�գ����� true�����򷵻� false
        }

        // ִ�� AttackOrder ����
        void AttackOrder(byte byte0)
        {
            if (this.bngd) // ����Ƿ��Ѿ�������
            {
                this.X = byte0; // ���� X Ϊ byte0
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "��������Ѿ�����2���ˣ������ٹ�����!"); // ������ʾ��Ϣ
                this.Y = 8; // ���� Y ����Ϊ 8
            }
            else
            {
                this.X = byte0; // ���� X Ϊ byte0
                bool can = false; // ��ʼ���ɹ�����־Ϊ false

                // �������ӵĳ��� ID
                for (byte byte2 = 0; byte2 < (CityListCache.GetCityByCityId(this.tarCity)).connectCityId.Length; byte2 = (byte)(byte2 + 1))
                {
                    byte otherCityId = (byte)(CityListCache.GetCityByCityId(this.tarCity)).connectCityId[byte2]; // ��ȡ���ӳ��� ID
                    if ((CityListCache.GetCityByCityId(otherCityId)).cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                        if (!theCityIsAlliance(otherCityId)) // ������в������˳���
                        {
                            can = true; // ���ÿ��Թ�����־Ϊ true
                            break; // �˳�ѭ��
                        }
                }

                if (can)
                {
                    this.a_boolean_fld = false; // ���� a_boolean_fld Ϊ false
                    DoMenuSwitch(); // ִ�� DoMenuSwitch ����
                }
                else
                {
                    SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "��ǰ�޿�ս������!"); // ������ʾ��Ϣ
                    this.Y = 8; // ���� Y ����Ϊ 8
                }
            }
        }

        // ������������� i1 ���㷵��ֵ
        int int_i_a(int i1)
        {
            byte byte0; // ���� byte0

            // ���� i1 ��ֵȷ�� byte0 ��ֵ
            if (i1 < 0)
            {
                i1 = -1;
            }
            else
            {
                i1 /= 1000;
            }

            switch (i1)
            {
                case -1:
                    byte0 = 5;
                    break;
                case 0:
                    byte0 = 10;
                    break;
                case 1:
                    byte0 = 20;
                    break;
                case 2:
                    byte0 = 50;
                    break;
                case 3:
                    byte0 = 70;
                    break;
                default:
                    byte0 = 80;
                    break;
            }

            // ��������������Ƿ��޸� X ��ֵ
            if (CommonUtils.getRandomInt() % 250 > byte0)
                this.X = 0;

            return i1; // ���� i1
        }

        // ִ�� void_bs1b_a ����
        void void_bs1b_a(byte byte0, short[] aword0, byte byte1)
        {
            CityListCache.GetCityByCityId(byte0).prefectId = aword0[0]; // ���ó��е� prefectId
        }

        // ִ�� void_bs1b_b ����
        void void_bs1b_b(byte byte0, short[] aword0, byte byte1)
        {
            AiAppointmentPrefect(byte0, aword0, byte1); // ִ�� AppointmentPrefect ����
        }

        // ִ�� void_s1b_c ����
        void void_s1b_c(short[] aword0, byte byte0)
        {
            for (int i1 = 0; i1 < byte0; i1++)
            {
                if (aword0[i1] == CityListCache.GetCityByCityId(this.tarCity).cityBelongKing) // ����Ƿ�����еĹ�����ͬ
                {
                    short word0 = aword0[0];
                    aword0[0] = aword0[i1];
                    aword0[i1] = word0; // ��������Ԫ��
                    return; // �˳�����
                }
            }
        }


        /// <summary>
        /// ��������ʳ�������
        /// </summary>
        /// <param name="city"></param>
        /// <param name="chooseGeneralIdArray"></param>
        /// <param name="chooseGeneralNum"></param>
        /// <returns></returns>
        int NeedFoodValue(City city, short[] chooseGeneralIdArray, int chooseGeneralNum)
        {
            int allGeneralSoldier = 0; // ��ʼ�����н�����ʿ������
            allGeneralSoldier = CalculateTotalGeneralSoldierNum(chooseGeneralIdArray, (byte)chooseGeneralNum); // �������н�����ʿ������
            allGeneralSoldier = allGeneralSoldier * 4 / 1000 + 1; // �����������ʿ������

            // ��������ʳ������
            int needFood = CommonUtils.getRandomInt() % allGeneralSoldier * 30 + allGeneralSoldier * 30;
            if (needFood < city.GetFood() / 2)
            {
                needFood = city.GetFood() / 2; // �������ʳ�����ڳ��е�һ��ʳ���ȡ����ʳ���һ��
            }
            else if (needFood >= city.GetFood())
            {
                needFood = city.GetFood() * 2 / 3; // �������ʳ����ڵ��ڳ���ʳ���ȡ����ʳ�������֮��
            }
            return needFood; // ��������ʳ������
        }

        /// <summary>
        /// ִ��ռ����з���
        /// </summary>
        /// <param name="generalIdArray"></param>
        /// <param name="generalNum"></param>
        /// <param name="food"></param>
        /// <param name="money"></param>
        void OccupyCity(short[] generalIdArray, byte generalNum, int food, int money)
        {
            CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).AddCity(this.curCity); // ����ǰ������ӵ�����
            City city = CityListCache.GetCityByCityId(this.curCity); // ��ȡ���ж���
            for (int k1 = 0; k1 < generalNum; k1++)
                city.AddOfficeGeneralId(generalIdArray[k1]); // ������ ID ��ӵ�������
            city.cityBelongKing = CityListCache.GetCityByCityId(this.tarCity).cityBelongKing; // ���ó��еĹ���
            city.prefectId = generalIdArray[0]; // ���ó��е� prefectId
            city.AddFood((short)food); // ���ʳ��
            city.AddMoney((short)money); // ����ʽ�
        }

        /// <summary>
        /// ִ�� DefenseTurnToAttack ����
        /// </summary>
        void DefenseTurnToAttack()
        {
            Country attackCountry = CountryListCache.GetCountryByKingId(CityListCache.GetCityByCityId(this.tarCity).cityBelongKing); // ��ȡ������
            Country defenseCountry = CountryListCache.GetCountryByKingId(CityListCache.GetCityByCityId(this.curCity).cityBelongKing); // ��ȡ������
            attackCountry.AddCity(this.curCity); // ��������ӵ�������
            defenseCountry.RemoveCity(this.curCity); // �ӷ��������Ƴ�����
        }

        // ִ�з����佫�����ý��淽��
        void void_s_j(short generalId)
        {
            CityListCache.GetCityByCityId(this.curCity).AddNotFoundGeneralId(generalId); // ������ ID ��ӵ�δ�ҵ��Ľ����б�
        }

        /// <summary>
        /// ִ�з����췽��
        /// </summary>
        /// <param name="word0"></param>
        void CaptureGeneral(short word0)
        {
            General general = GeneralListCache.GetGeneral(word0); // ��ȡ��������
            byte AddLoyalty = (byte)(100 - general.getLoyalty()); // �������ӵ��ҳ϶�
            byte baseLoyalty = (byte)(60 + AddLoyalty); // ��������ҳ϶�
            if (baseLoyalty >= 99 || baseLoyalty < 0)
            {
                general.SetLoyalty((byte)99); // ��������ҳ϶Ȳ�����Ч��Χ�ڣ�������Ϊ 99
            }
            else
            {
                general.SetLoyalty((byte)(baseLoyalty + CommonUtils.getRandomInt() % (99 - baseLoyalty))); // ���ý������ҳ϶�
            }
            CityListCache.GetCityByCityId(this.curCity).AddOfficeGeneralId(word0); // ������ ID ��ӵ�������
        }

        // ִ��ռ��ճǷ���
        byte MoveGeneralToEmptyCity(short generalId, byte[] abyte0, byte byte0, byte cityId, short kingId)
        {
            City city = CityListCache.GetCityByCityId(cityId); // ��ȡ���ж���
            if (city.cityBelongKing == 0) // �������û�й���
            {
                Country country = CountryListCache.GetCountryByKingId(kingId); // ��ȡ���Ҷ���
                country.AddCity(cityId); // ��������ӵ�����
                city.cityBelongKing = country.countryKingId; // ���ó��еĹ���
                city.AddOfficeGeneralId(generalId); // ������ ID ��ӵ�������
                return byte0; // ���� byte0
            }
            city.AddOfficeGeneralId(generalId); // ������ ID ��ӵ�������
            if (city.getCityGeneralNum() == 10) // ��������н��������ﵽ 10
            {
                byte0 = (byte)(byte0 - 1); // ���� byte0 ��ֵ
                if (byte0 != 0)
                {
                    byte byte4 = 0;
                    while (byte4 < byte0)
                    {
                        if (abyte0[byte4] == cityId) // ��������� ID ��ͬ��Ԫ��
                        {
                            abyte0[byte4] = abyte0[byte0]; // ����Ԫ��
                            break; // �˳�ѭ��
                        }
                        byte4 = (byte)(byte4 + 1); // ��������
                    }
                }
            }
            return byte0; // ���� byte0
        }

        // ִ�� MoveAddCityMoneyFood ����
        void MoveAddCityMoneyFood(byte byte0, int i1, int j1)
        {
            City city = CityListCache.GetCityByCityId(byte0); // ��ȡ���ж���
            if (i1 < 0)
                i1 = 0; // ȷ��ʳ��ֵΪ�Ǹ�
            if (j1 < 0)
                j1 = 0; // ȷ���ʽ�ֵΪ�Ǹ�
            city.AddMoney((short)j1); // ����ʽ�
            city.AddFood((short)i1); // ���ʳ��
        }

       

        /// <summary>
        /// �����������߼����ж��Ƿ�ɹ�����
        /// </summary>
        /// <param name="generalIdArray"></param>
        /// <param name="generalNum"></param>
        /// <param name="kingId"></param>
        /// <param name="food"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        bool IsRetreat(short[] generalIdArray, byte generalNum, short kingId, int food, int money)
        {
            Country country = CountryListCache.GetCountryByKingId(kingId); // ���ݹ���ID��ȡ����
            City city = CityListCache.GetCityByCityId(this.curCity); // ��ȡ��ǰ����
            short[] tempGeneralIdArray = new short[generalNum]; // ��ʱ����ID����
            byte tempGeneralNum = 0; // ��ʱ��������
            bool chiefGeneralCaptured = false; // ��������Ƿ񱻷���

            // �������н���ID
            for (int i = 0; i < generalNum; i++)
            {
                short generalId = generalIdArray[i];
                if (generalId == country.countryKingId) // �жϽ����Ƿ�Ϊ����
                {
                    tempGeneralIdArray[tempGeneralNum] = generalId;
                    tempGeneralNum = (byte)(tempGeneralNum + 1);
                    continue; // ������������
                }

                if (city.getCityGeneralNum() > 9) // ��������еĽ�����������9
                {
                    tempGeneralIdArray[tempGeneralNum] = generalId;
                    tempGeneralNum = (byte)(tempGeneralNum + 1);
                    continue; // ������������
                }

                byte[] citys = country.GetCities(); // ��ȡ���ҵ����г���
                General general = GeneralListCache.GetGeneral(generalIdArray[i]); // ��ȡ��������

                // �жϹ����Ƿ�ֻʣ�µ�ǰ����
                if (citys.Length < 1 || (citys.Length == 1 && citys[0] == this.curCity))
                {
                    // ���ݽ����͹����� phase ֵ�����Ƿ����
                    if (GetdPhase(GeneralListCache.GetGeneral(kingId).phase, general.phase) > 20)
                    {
                        CaptureGeneral(generalId); // ����������
                        if (i == 0)
                        {
                            chiefGeneralCaptured = true; // �������������
                            Console.WriteLine("������" + general.generalName + "�����񣡣�����");
                        }
                        else
                        {
                            Console.WriteLine("�佫��" + general.generalName + "�����񣡣�����");
                        }
                        continue;
                    }
                }
                else if (general.getCurPhysical() <= 40 && general.generalSoldier <= 0 && GetdPhase(GeneralListCache.GetGeneral(kingId).phase, general.phase) > 15)
                {
                    byte capturedProbability;

                    // ���ݽ����� IQ��force �� lead ֵ���㱻������
                    if (general.IQ >= 95 || general.force >= 95 || general.lead >= 95)
                    {
                        capturedProbability = 5;
                    }
                    else if (general.IQ >= 90 || general.force >= 90 || general.lead >= 95)
                    {
                        capturedProbability = 15;
                    }
                    else if (general.IQ >= 80 || general.force >= 80 || general.lead >= 95)
                    {
                        capturedProbability = 25;
                    }
                    else
                    {
                        capturedProbability = 40;
                    }

                    // ����ж��Ƿ���񽫾�
                    if (CommonUtils.getRandomInt() % 100 <= capturedProbability)
                    {
                        CaptureGeneral(generalId); // ����������
                        if (i == 0)
                        {
                            chiefGeneralCaptured = true; // �������������
                            Console.WriteLine("������" + general.generalName + "�����񣡣�����");
                        }
                        else
                        {
                            Console.WriteLine("�佫��" + general.generalName + "�����񣡣�����");
                        }
                        continue;
                    }
                }
                tempGeneralIdArray[tempGeneralNum] = generalId; // ������ID��ӵ���ʱ����
                tempGeneralNum = (byte)(tempGeneralNum + 1);
                continue;
            }

            bool masterRetreat = false; // ��������Ƿ��˳ɹ�
            if (tempGeneralNum > 0)
            {
                if (generalIdArray.Length > tempGeneralNum)
                {
                    short[] tempOfficeGeneralId = new short[tempGeneralNum];
                    Array.Copy(tempGeneralIdArray, 0, tempOfficeGeneralId, 0, tempGeneralNum); // ������ʱ��������
                    generalIdArray = tempOfficeGeneralId; // ���½�������
                }
                masterRetreat = country.RetreatGeneralToCity(generalIdArray, this.curCity, food, money, chiefGeneralCaptured); // ���������˵�����
            }

            if (!masterRetreat) // �������û�гɹ�����
            {
                city.AddFood((short)food); // ���������ʳ��
                city.AddMoney((short)money); // ��������ӽ�Ǯ
                if (kingId == generalIdArray[0])
                    return true; // ��������ǵ�һ�����˵Ľ���������true
            }

            return false; // ����false
        }

        /// <summary>
        /// �������������߼�
        /// </summary>
        /// <param name="attackGeneralArray"></param>
        /// <param name="attackGeneralNum"></param>
        /// <param name="carryFood"></param>
        /// <param name="money"></param>
        void IsDestroyed(short[] attackGeneralArray, byte attackGeneralNum, int carryFood, int money)
        {
            City city = CityListCache.GetCityByCityId(this.curCity); // ��ȡ��ǰ����
            byte defenseGeneralNum = city.getCityGeneralNum(); // ��ȡ������������
            short kingId = city.cityBelongKing; // ��ȡ������������
            Country country = CountryListCache.GetCountryByKingId(kingId); // ��ȡ���Ҷ���
            short[] defenseGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ�����еķ�������ID����

            city.ClearAllOfficeGeneral(); // ��ճ����е����н���
            DefenseTurnToAttack(); // ��������������ı��

            for (int l1 = 0; l1 < attackGeneralNum; l1++)
                city.AddOfficeGeneralId(attackGeneralArray[l1]); // ���������Ľ���ID��ӵ�������

            city.prefectId = attackGeneralArray[0]; // ���ó��е� prefectId
            city.cityBelongKing = CityListCache.GetCityByCityId(this.tarCity).cityBelongKing; // ���³��еĹ���

            short takeThing = city.GetMoney(); // ��ȡ���е�ǰ��Ǯ
            city.SetMoney((short)money); // ���³��н�Ǯ
            money = takeThing; // ����ԭ�н�Ǯ

            takeThing = city.GetFood(); // ��ȡ���е�ǰʳ��
            city.SetFood((short)carryFood); // ���³���ʳ��
            carryFood = takeThing; // ����ԭ��ʳ��

            // �жϷ��������Ƿ��˳ɹ�
            bool flag = IsRetreat(defenseGeneralIdArray, defenseGeneralNum, kingId, carryFood, money);
            if (flag) // ������˳ɹ�
            {
                if (country.GetHaveCityNum() > 0)
                {
                    GameInfo.countryDieTips = 1;
                    short newKingGeneralId = country.Inherit(); // �̳��¹���
                    GameInfo.ShowInfo = GeneralListCache.GetGeneral(defenseGeneralIdArray[0]).generalName + "����,�¾��� " + GeneralListCache.GetGeneral(newKingGeneralId).generalName + " ��λ!";
                    this.f_short_fld = newKingGeneralId; // ���¼�λ�Ľ���ID
                }
                else
                {
                    // ���������������߼�
                    byte[] tempCountryOrder = new byte[this.countryOrder.Length - 1];
                    int index = 0;
                    for (int i = 0; i < this.countryOrder.Length; i++)
                    {
                        if (this.countryOrder[i] != country.countryId)
                        {
                            if (index == this.countryOrder.Length - 1)
                            {
                                Console.Error.WriteLine("ϵͳ����!�޷��ҵ���countryId:" + country.countryId + "��ͬ���������");
                            }
                            else
                            {
                                tempCountryOrder[index] = this.countryOrder[i];
                                index++;
                            }
                        }
                    }
                    GameInfo.chooseGeneralName = GeneralListCache.GetGeneral(country.countryKingId).generalName; // �����������ҵĹ�������
                    this.countryOrder = tempCountryOrder; // ���¹���˳��
                    CountryListCache.removeCountry(country.countryId); // �Ƴ�����
                }
            }
        }


        // ������������˫�����佫ս�����
        void ffzs(short[] aword0, byte byte0, short[] aword1, byte byte1)
        {
            int gfhszl = 0; // ��������ս����
            int gfxhzl = 0; // ������ʣ��ս����
            int pjxhzl = 0; // ƽ��ս����
            int ffxhzl = 0; // ���ط�ʣ��ս����
            byte[] gfjq = new byte[byte0]; // �������佫ս����Ȩ
            byte[] ffjq = new byte[byte1]; // ���ط��佫ս����Ȩ
            int[] xhbl = new int[byte1]; // �������

            // ���������ÿ���佫��ս����Ȩ
            for (byte byte5 = 0; byte5 < byte0; byte5 = (byte)(byte5 + 1))
            {
                int k = 1; // �佫ս��������
                byte zl = (GeneralListCache.GetGeneral(aword0[byte5])).IQ; // ����
                byte wl = (GeneralListCache.GetGeneral(aword0[byte5])).lead; // ͳ��

                // ������������ս����
                if (zl >= 100) k += 6;
                else if (zl >= 95) k += 5;
                else if (zl >= 88) k += 4;
                else if (zl >= 82) k += 3;
                else if (zl >= 75) k += 2;
                else if (zl >= 68) k++;

                // ����ͳ�ʵ���ս����
                if (wl >= 100) k += 6;
                else if (wl >= 95) k += 5;
                else if (wl >= 88) k += 4;
                else if (wl >= 82) k += 3;
                else if (wl >= 75) k += 2;
                else if (wl >= 68) k++;

                // ����������ֵ����ս����
                if (zl <= 55) k--;
                else if (zl <= 40) k -= 2;
                else if (zl <= 25) k -= 3;

                if (k < 1) k = 1; // ȷ��ս����������1
                gfjq[byte5] = (byte)k;
            }

            // �����������ս����
            for (int i = 0; i < byte0; i++)
            {
                gfhszl += gfjq[i] * (GeneralListCache.GetGeneral(aword0[i]).IQ + 3 * GeneralListCache.GetGeneral(aword0[i]).lead / 2) *
                            (GeneralListCache.GetGeneral(aword0[i]).generalSoldier + 200) / 100;
            }
            gfxhzl = this.gfZZL - gfhszl; // ���������ʣ��ս����
            ffxhzl = gfxhzl; // ��ʼ�����ط�ʣ��ս����
            pjxhzl = ffxhzl / byte1; // ������ط���ƽ��ս����

            // ������ط�ÿ���佫��ս����Ȩ
            for (byte byte6 = 0; byte6 < byte1; byte6 = (byte)(byte6 + 1))
            {
                int k = 1; // �佫ս��������
                byte zl = (GeneralListCache.GetGeneral(aword1[byte6])).IQ; // ����
                byte wl = (GeneralListCache.GetGeneral(aword1[byte6])).lead; // ͳ��

                // ������������ս����
                if (zl >= 100) k += 6;
                else if (zl >= 95) k += 5;
                else if (zl >= 88) k += 4;
                else if (zl >= 82) k += 3;
                else if (zl >= 75) k += 2;
                else if (zl >= 68) k++;

                // ����ͳ�ʵ���ս����
                if (wl >= 100) k += 6;
                else if (wl >= 95) k += 5;
                else if (wl >= 88) k += 4;
                else if (wl >= 82) k += 3;
                else if (wl >= 75) k += 2;
                else if (wl >= 68) k++;

                // ����������ֵ����ս����
                if (zl <= 55) k--;
                else if (zl <= 40) k -= 2;
                else if (zl <= 25) k -= 3;

                if (byte6 == 0) k += 2; // ��������ӳ�
                if (k < 1) k = 1; // ȷ��ս����������1
                ffjq[byte6] = (byte)k;
            }

            // ������ط�ÿ���佫���������
            for (int j = 0; j < byte1; j++)
            {
                xhbl[j] = pjxhzl * 100 / ffjq[j] * (GeneralListCache.GetGeneral(aword1[j]).IQ + 3 * GeneralListCache.GetGeneral(aword1[j]).lead / 2) - 200;
                if (xhbl[j] < 0) xhbl[j] = 0; // ȷ�����������Ϊ��
            }

            // ģ��ս������
            while (true)
            {
                int wb = 0; // ��¼ս���ѽ������佫��

                // ����ս����ʧ
                for (int k = 0; k < byte1; k++)
                {
                    if (GeneralListCache.GetGeneral(aword1[k]).generalSoldier == 0) wb++;
                    if (GeneralListCache.GetGeneral(aword1[k]).generalSoldier > 0)
                    {
                        if (GeneralListCache.GetGeneral(aword1[k]).generalSoldier > xhbl[k])
                        {
                            GeneralListCache.GetGeneral(aword1[k]).generalSoldier -= (short)xhbl[k];
                            ffxhzl -= ffjq[k] * (GeneralListCache.GetGeneral(aword1[k]).IQ + 3 * GeneralListCache.GetGeneral(aword1[k]).lead / 2) * xhbl[k] / 100;
                        }
                        else
                        {
                            ffxhzl -= ffjq[k] * (GeneralListCache.GetGeneral(aword1[k]).IQ + 3 * GeneralListCache.GetGeneral(aword1[k]).lead / 2) *
                                        (GeneralListCache.GetGeneral(aword1[k]).generalSoldier + 200) / 100;
                            GeneralListCache.GetGeneral(aword1[k]).generalSoldier = 0;
                            wb++;
                        }
                    }
                }

                // ���¼���ʣ��ս����
                if (wb < byte1 - 1)
                {
                    pjxhzl = ffxhzl / (byte1 - wb); // ���·���ʣ��ս����
                    for (int m = 0; m < byte1; m++)
                    {
                        if (GeneralListCache.GetGeneral(aword1[m]).generalSoldier > 0)
                        {
                            xhbl[m] = pjxhzl * 100 / ffjq[m] * (GeneralListCache.GetGeneral(aword1[m]).IQ + 3 * GeneralListCache.GetGeneral(aword1[m]).lead / 2);
                            if (xhbl[m] < 0) xhbl[m] = 0; // ȷ�����������Ϊ��
                        }
                    }
                    if (ffxhzl <= 100) break; // ���ʣ��ս��������һ��ֵ��ս������
                }
                else break;
            }
        }


        /// <summary>
        /// ���ؽ�����ֵ��λ������
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        int DiffSoldierGen(byte byte0, int i1)
        {
            return i1;
        }

        /// <summary>
        /// ���㵥���佫����ս����
        /// </summary>
        /// <param name="generalId"></param>
        /// <returns></returns>
        int SingleGeneralFightValue(short generalId)
        {
            General general = GeneralListCache.GetGeneral(generalId); // �����佫ID��ȡ�佫
            if (general == null)
                return 0;

            // ����ս���� (������������ͳ˧������Ӱ��)
            int i1 = (general.force + general.IQ + general.lead * 2) / 2 * (general.generalSoldier + 150);
            return i1;
        }

        /// <summary>
        /// ���������佫���ŵ���ս����
        /// </summary>
        /// <param name="aword0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        int WholeGeneralFightValue(short[] aword0, int i1)
        {
            int j1 = 0;
            for (int l1 = 0; l1 < i1; l1++)
            {
                int k1 = SingleGeneralFightValue(aword0[l1]); // ����ÿ���佫��ս����
                j1 += k1; // �ۼ���ս����
            }
            return j1;
        }

        // �����佫������㼺�����е�ս����
        void gffpjy(short[] generalIdArray, byte generalNum)
        {
            this.gfZL = new int[generalNum]; // ������ս����
            this.gfzdl = new int[generalNum]; // ���������佫ս����
            this.gfZZL = 1; // ������ս������ʼֵ

            for (byte i = 0; i < generalNum; i = (byte)(i + 1))
            {
                General general = GeneralListCache.GetGeneral(generalIdArray[i]); // ��ȡ�佫
                byte zl = general.IQ; // ����
                byte ts = general.lead; // ͳ˧
                byte dj = general.level; // �ȼ�
                byte wl = general.force; // ����

                // �����佫ս���� (�����Լӳɹ�ʽ)
                int gjl = (int)(ts * 1.42D + zl * 0.25D + wl * 0.33D + ((ts * 2 + wl + zl) * (dj - 1)) * 0.04D);

                // ��������ֵ�Ĳ�ͬ����ս����
                if (zl >= 100)
                    gjl += 15;
                else if (zl >= 95)
                    gjl += 12;
                else if (zl >= 88)
                    gjl += 8;
                else if (zl >= 80)
                    gjl += 5;
                else if (zl >= 70)
                    gjl += 3;
                else if (zl >= 55)
                    gjl -= 5;
                else if (zl >= 40)
                    gjl -= 10;
                else
                    gjl -= 20;

                // ����ս�������� (����ƽ��ֵ�������Ӱ��)
                long gjl2 = (gjl * gjl * gjl / 100000 + 1);
                this.gfzdl[i] = (int)gjl2;

                // ����ս��������������
                if (general.generalSoldier < 500)
                    this.gfzdl[i] = Math.Min(100, this.gfzdl[i]);

                if (this.gfzdl[i] < 20)
                    this.gfzdl[i] = Math.Max(general.generalSoldier / 150, this.gfzdl[i]);

                // ��ս��������
                this.gfZL[i] = this.gfzdl[i];
                this.gfZL[i] = this.gfZL[i] * (general.generalSoldier + 1);
                this.gfZZL += this.gfZL[i];
            }
        }

        // �����佫�������з����е�ս����
        void fffpjy(short[] generalIdArray)
        {
            this.ffZL = new int[generalIdArray.Length]; // �з���ս����
            this.ffzdl = new int[generalIdArray.Length]; // �з������佫ս����
            this.ffZZL = 1; // �з���ս������ʼֵ

            for (byte i = 0; i < generalIdArray.Length; i = (byte)(i + 1))
            {
                General general = GeneralListCache.GetGeneral(generalIdArray[i]); // ��ȡ�佫
                byte zl = general.IQ; // ����
                byte ts = general.lead; // ͳ˧
                byte dj = general.level; // �ȼ�
                byte wl = general.force; // ����

                // �����佫ս���� (�����Լӳɹ�ʽ)
                int gjl = (int)(ts * 1.42D + zl * 0.25D + wl * 0.33D + ((ts * 2 + wl + zl) * (dj - 1)) * 0.04D);

                if (i == 0)
                    gjl = (int)(gjl * 1.3D); // �ӳ�����ӳ�

                // ��������ֵ�Ĳ�ͬ����ս����
                if (zl >= 100)
                    gjl += 15;
                else if (zl >= 95)
                    gjl += 12;
                else if (zl >= 88)
                    gjl += 8;
                else if (zl >= 80)
                    gjl += 5;
                else if (zl >= 70)
                    gjl += 3;
                else if (zl >= 55)
                    gjl -= 5;
                else if (zl >= 40)
                    gjl -= 10;
                else
                    gjl -= 20;

                // ����ս��������
                long gjl2 = (gjl * gjl * gjl / 100000 + 1);
                this.ffzdl[i] = (int)gjl2;

                // ����ս��������������
                if (general.generalSoldier < 500)
                    this.ffzdl[i] = Math.Min(150, this.ffzdl[i]);

                if (this.ffzdl[i] < 20)
                    this.ffzdl[i] = Math.Max(general.generalSoldier / 150, this.ffzdl[i]);

                // ��ս��������
                if (i == 0)
                    this.ffZL[i] = this.ffZL[i] * (general.generalSoldier + 1);
                else
                    this.ffZL[i] = this.ffZL[i] * (general.generalSoldier + 1);

                this.ffZZL += this.ffZL[i];
            }
        }


        // �ж��Ƿ�ռ�����
        bool isCapture(short[] generalIdArray, byte generalNum, int food, int j1)
        {
            gffpjy(generalIdArray, generalNum); // ���㼺���佫��ս����
            City city = CityListCache.GetCityByCityId(this.curCity); // ��ȡ��ǰ����
            fffpjy(city.getCityOfficeGeneralIdArray()); // ����з��佫��ս����

            // ��AI����ս��
            if (AIWar2(generalIdArray, generalNum, food))
            {
                IsDestroyed(generalIdArray, generalNum, food, j1); // ����ս������
                return true; // ռ��ɹ�
            }

            // ս��ʧ�ܣ�������Ӧ����
            IsRetreat(generalIdArray, generalNum, (CityListCache.GetCityByCityId(this.tarCity)).cityBelongKing, food, j1);
            return false;
        }

        // �������������������
        short atkEatFood(short[] genId, byte genNum)
        {
            short eatNum = 3; // ��ʼ����Ϊ3
            short atkTotleSoldier = CalculateTotalGeneralSoldierNum(genId, genNum); // ������������ܱ���
            eatNum = (short)(eatNum + atkTotleSoldier * 4 / 1000); // ������������������
            return eatNum;
        }

        // ������ط�����������
        short defEatFood(short[] genId)
        {
            short eatNum = 1; // ��ʼ����Ϊ1
            short defTotleSoldier = CalculateTotalGeneralSoldierNum(genId, (byte)genId.Length); // ������ط����ܱ���
            eatNum = (short)(eatNum + defTotleSoldier * 4 / 1000); // ������������������
            return eatNum;
        }

        // AI����ս��ģ��
        bool AIWar2(short[] genId, byte genNum, int atkfood)
        {
            bool occupy = false; // �Ƿ�ռ��
            bool atknot = false; // �������Ƿ��޷�����
            bool defnot = false; // ���ط��Ƿ��޷�����
            byte day = 0; // ս����������
            City city = CityListCache.GetCityByCityId(this.curCity); // ��ȡ��ǰ����

            // ս��ģ��ѭ��
            while (true)
            {
                day = (byte)(day + 1); // ��������
                atkfood -= atkEatFood(genId, genNum); // ��������������

                if (atkfood <= 0)
                {
                    atkfood = 0; // ���ݺľ�
                    break;
                }

                // ���ط���������
                city.DecreaseFood(defEatFood(city.getCityOfficeGeneralIdArray()));

                // �����ط����ݺľ�
                if (city.GetFood() <= 0)
                {
                    city.SetFood((short)0); // ���÷��ط�����Ϊ0
                    occupy = true; // ���б�ռ��
                    break;
                }

                if (day < 3) // ս������ʱ��С��3�����
                    continue;

                if (day > 30) // ս������ʱ�䳬��30�����
                    break;

                // Ѱ�ҽ������Ĺ����佫
                short attackGeneralId = -1;
                byte[] sequence1 = new byte[genNum];
                for (byte i = 0; i < genNum; i = (byte)(i + 1))
                    sequence1[i] = i;
                sequence1 = randomArray(sequence1); // ������ҽ������佫˳��

                // �����ܹ��������佫
                for (byte i = 0; i < sequence1.Length; i = (byte)(i + 1))
                {
                    byte index1 = sequence1[i];
                    int soldier = GeneralListCache.GetGeneral(genId[index1]).generalSoldier;
                    byte phy = GeneralListCache.GetGeneral(genId[index1]).getCurPhysical();
                    if (soldier > 0 || phy > 50)
                    {
                        attackGeneralId = genId[index1]; // �ҵ������佫
                        atknot = false;
                        break;
                    }
                    atknot = true; // �޷��ҵ������佫
                }

                // �����������ս��
                if (CommonUtils.getRandomInt() % 100 < 15)
                    continue;

                if (atknot)
                    break; // �޷���������

                // Ѱ�ҷ��ط��ķ����佫
                short preventGeneralId = -1;
                byte[] sequence2 = new byte[city.getCityGeneralNum()];
                for (byte b1 = 0; b1 < city.getCityGeneralNum(); b1 = (byte)(b1 + 1))
                    sequence2[b1] = b1;
                sequence2 = randomArray(sequence2); // ������ҷ��ط��佫˳��
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

                // �����ܹ����ص��佫
                for (byte j = 0; j < sequence2.Length; j = (byte)(j + 1))
                {
                    byte index2 = sequence2[j];
                    short generalId = officeGeneralIdArray[index2];
                    int soldier = GeneralListCache.GetGeneral(generalId).generalSoldier;
                    byte phy = GeneralListCache.GetGeneral(generalId).getCurPhysical();
                    if (soldier > 0 || phy > 50)
                    {
                        preventGeneralId = generalId; // �ҵ������佫
                        defnot = false;
                        break;
                    }
                    defnot = true; // �޷��ҵ������佫
                }

                if (defnot)
                {
                    occupy = true; // ����ʧ�ܣ�ռ�����
                    break;
                }

                if (attackGeneralId > 0 && preventGeneralId > 0)
                    moniAtk2(attackGeneralId, preventGeneralId); // ģ�⹥��ս
            }

            return occupy; // �����Ƿ�ռ��ɹ�
        }

        // �����佫�ľ���
        void addExp_P(short atkGen, short defGen, int totalExp)
        {
            // ���㾭�����
            float pesent = satrapVal(defGen) / satrapVal(atkGen);
            if (pesent > 1.5F)
                pesent = 1.5F;
            else if (pesent < 0.1F)
                pesent = 0.1F;

            // ����ɻ�ȡ�ľ���ֵ
            short canhaveExp = (short)(int)(totalExp * pesent);
            General general = GeneralListCache.GetGeneral(atkGen); // ��ȡ�����佫
            general.addexperience(canhaveExp / 3); // ���Ӿ���
        }

        // AIս�����Ӿ���
        void AIWarAddEXP(short atkGen, short defGen, int totalExp)
        {
            float pesent = satrapVal(defGen) / satrapVal(atkGen);
            if (pesent > 1.5F)
                pesent = 1.5F;
            else if (pesent < 0.5F)
                pesent = 0.5F;

            // ����ɻ�ȡ���ܾ���
            short canhaveExp = (short)(int)(totalExp * pesent + 1.0F);
            short IQExp = 0, leadExp = 0, forceExp = 0;

            // ��ȡ�����ͷ��ص��佫
            General atkGeneral = GeneralListCache.GetGeneral(atkGen);
            General defGeneral = GeneralListCache.GetGeneral(defGen);

            // ���������ϴ�������������
            if (atkGeneral.IQ > defGeneral.IQ + 20)
                IQExp = (short)(int)(canhaveExp * 0.3F);

            // ���������ϴ������������鲢��������
            if (atkGeneral.force > defGeneral.force + 20 && atkGeneral.getCurPhysical() * 2 > atkGeneral.maxPhysical)
            {
                byte physical = (byte)(CommonUtils.getRandomInt() % (atkGeneral.getCurPhysical() - atkGeneral.maxPhysical / 2 + 1));
                float forcepecent = (physical * 2) / atkGeneral.getCurPhysical();
                if (forcepecent < 0.3F)
                    forcepecent = 0.3F;

                forceExp = (short)(int)(forcepecent * canhaveExp * 0.2F);
                atkGeneral.decreaseCurPhysical(physical); // ��������
            }

            // ����ͳ˧����
            leadExp = (short)(canhaveExp - IQExp - forceExp);

            // ���Ӹ����Ծ���
            GeneralListCache.addforceExp(atkGen, (byte)(forceExp / 50));
            GeneralListCache.addIQExp(atkGen, (byte)(IQExp / 100));
            GeneralListCache.addLeadExp(atkGen, (byte)(leadExp / 300));
        }


        void AIWarAddEXP2(short atkGen, short defGen, int totalExp)
        {
            // ���㾭��ٷֱȣ�ȡֵ��Χ��0.5��1.5֮��
            float pesent = satrapVal(defGen) / satrapVal(atkGen);
            if (pesent > 1.5F)
            {
                pesent = 1.5F;
            }
            else if (pesent < 0.5F)
            {
                pesent = 0.5F;
            }

            // ����ɻ�õ��ܾ���
            short canhaveExp = (short)(int)(totalExp * pesent + 1.0F);
            short IQExp = 0;
            short leadExp = 0;

            // �����������������ȷ��ؽ���߳�20����������ӳ�
            if (GeneralListCache.GetGeneral(atkGen).IQ > GeneralListCache.GetGeneral(defGen).IQ + 20)
                IQExp = (short)(int)(canhaveExp * 0.3F);

            // ʣ�ྭ�������쵼��
            leadExp = (short)(canhaveExp - IQExp);

            // ���ӽ�����������쵼������
            GeneralListCache.addIQExp(atkGen, (byte)(IQExp / 100));
            GeneralListCache.addLeadExp(atkGen, (byte)(leadExp / 300));
        }

        int getSword(int power, byte t, short genId)
        {
            // ���ݾ�������t����powerֵ
            switch (t)
            {
                case 0:
                    if (GeneralListCache.GetGeneral(genId).army[0] == 0)
                        power = (int)(power * 0.8F);
                    else if (GeneralListCache.GetGeneral(genId).army[0] == 1)
                        power = (int)(power * 0.9F);
                    else if (GeneralListCache.GetGeneral(genId).army[0] == 2)
                        power = (int)(power * 1.0F);
                    else if (GeneralListCache.GetGeneral(genId).army[0] == 3)
                        power = (int)(power * 1.1F);
                    break;
                case 1:
                    if (GeneralListCache.GetGeneral(genId).army[1] == 0)
                        power = (int)(power * 0.8F);
                    else if (GeneralListCache.GetGeneral(genId).army[1] == 1)
                        power = (int)(power * 0.9F);
                    else if (GeneralListCache.GetGeneral(genId).army[1] == 2)
                        power = (int)(power * 1.0F);
                    else if (GeneralListCache.GetGeneral(genId).army[1] == 3)
                        power = (int)(power * 1.1F);
                    break;
                case 2:
                    if (GeneralListCache.GetGeneral(genId).army[2] == 0)
                        power = (int)(power * 0.8F);
                    else if (GeneralListCache.GetGeneral(genId).army[2] == 1)
                        power = (int)(power * 0.9F);
                    else if (GeneralListCache.GetGeneral(genId).army[2] == 2)
                        power = (int)(power * 1.0F);
                    else if (GeneralListCache.GetGeneral(genId).army[2] == 3)
                        power = (int)(power * 1.1F);
                    break;
            }

            // ���powerС�ڵ���0����������Ϊ1
            if (power <= 0)
                power = 1;

            return power;
        }

        byte getWarTTT(byte city)
        {
            // ����������ж�ս��״̬
            byte index = (byte)(CommonUtils.getRandomInt() % 10);
            if (index >= this.moniwarT[city][1])
            {
                index = 2;
            }
            else if (index >= this.moniwarT[city][0])
            {
                index = 1;
            }
            else
            {
                index = 0;
            }

            return index;
        }

        int moniAtkgetGenPower(int power, bool ists, short genId)
        {
            // ���ݽ����ʿ����������������
            long gjl_jq = (1 + power * power * power / 100000);
            if (ists && GeneralListCache.GetGeneral(genId).generalSoldier <= 500)
                gjl_jq = Math.Min(100L, gjl_jq);

            return (int)gjl_jq;
        }

        int getGenSinglePower(short id)
        {
            // ���㽫��ĵ���ս����
            int power = GeneralListCache.GetGeneral(id).force * 2 +
                        GeneralListCache.GetGeneral(id).force * WeaponListCache.getWeapon(GeneralListCache.GetGeneral(id).weapon).weaponProperties / 100 +
                        GeneralListCache.GetGeneral(id).force * WeaponListCache.getWeapon(GeneralListCache.GetGeneral(id).armor).weaponProperties / 100;
            long p = (1 + power * power * power / 100000);

            return (int)p;
        }

        byte cangetphy(short id)
        {
            // ��ȡ����ĵ�ǰ����
            byte phy;
            if (GeneralListCache.GetGeneral(id).getCurPhysical() > 35)
            {
                int ph = CommonUtils.getRandomInt() % GeneralListCache.GetGeneral(id).getCurPhysical() + 30;
                if (ph >= GeneralListCache.GetGeneral(id).getCurPhysical())
                    ph = GeneralListCache.GetGeneral(id).getCurPhysical() - 35;

                phy = (byte)ph;
            }
            else
            {
                phy = 1;
            }

            return phy;
        }


        void moniAtk2(short attackGeneralId, short preventGeneralId)
        {
            City city = CityListCache.GetCityByCityId(this.curCity);
            bool isprefectId = (city.prefectId == preventGeneralId);
            short soldier1 = (GeneralListCache.GetGeneral(attackGeneralId)).generalSoldier;
            short soldier2 = (GeneralListCache.GetGeneral(preventGeneralId)).generalSoldier;
            if (soldier1 > 0 && soldier2 > 0)
            {
                if (isprefectId)
                {
                    int power1 = satrapVal(attackGeneralId);
                    int power2 = satrapVal(preventGeneralId);
                    power2 = (int)(power2 * 1.33D);
                    power1 = moniAtkgetGenPower(power1, false, attackGeneralId);
                    power2 = moniAtkgetGenPower(power2, true, preventGeneralId);
                    int sword1 = power1 * soldier1;
                    int sword2 = power2 * soldier2;
                    if (sword1 > sword2)
                    {
                        int dea1 = sword2 / power1;
                        int dea2 = sword2 / power2;
                        changeSoldier(attackGeneralId, (short)dea1);
                        changeSoldier(preventGeneralId, (short)dea2);
                        addExp_P(attackGeneralId, preventGeneralId, dea2);
                        AIWarAddEXP2(attackGeneralId, preventGeneralId, (short)dea2);
                        addExp_P(preventGeneralId, attackGeneralId, dea1);
                        AIWarAddEXP2(preventGeneralId, attackGeneralId, (short)dea1);
                    }
                    else
                    {
                        int dea1 = sword1 / power1;
                        int dea2 = sword1 / power2;
                        changeSoldier(attackGeneralId, (short)dea1);
                        changeSoldier(preventGeneralId, (short)dea2);
                        addExp_P(attackGeneralId, preventGeneralId, dea2);
                        AIWarAddEXP2(attackGeneralId, preventGeneralId, (short)dea2);
                        addExp_P(preventGeneralId, attackGeneralId, dea1);
                        AIWarAddEXP2(preventGeneralId, attackGeneralId, (short)dea1);
                    }
                }
                else
                {
                    byte t = getWarTTT(this.tarCity);
                    int power1 = satrapVal(attackGeneralId);
                    int power2 = satrapVal(preventGeneralId);
                    power1 = getSword(power1, t, attackGeneralId);
                    power2 = getSword(power2, t, preventGeneralId);
                    power1 = moniAtkgetGenPower(power1, false, attackGeneralId);
                    power2 = moniAtkgetGenPower(power2, false, preventGeneralId);
                    int sword1 = power1 * soldier1;
                    int sword2 = power2 * soldier2;
                    if (sword1 > sword2)
                    {
                        int dea1 = sword2 / power1;
                        int dea2 = sword2 / power2;
                        changeSoldier(attackGeneralId, (short)dea1);
                        changeSoldier(preventGeneralId, (short)dea2);
                        addExp_P(attackGeneralId, preventGeneralId, dea2);
                        AIWarAddEXP2(attackGeneralId, preventGeneralId, (short)dea2);
                        addExp_P(preventGeneralId, attackGeneralId, dea1);
                        AIWarAddEXP2(preventGeneralId, attackGeneralId, (short)dea1);
                    }
                    else
                    {
                        int dea1 = sword1 / power1;
                        int dea2 = sword1 / power2;
                        changeSoldier(attackGeneralId, (short)dea1);
                        changeSoldier(preventGeneralId, (short)dea2);
                        addExp_P(attackGeneralId, preventGeneralId, dea2);
                        AIWarAddEXP2(attackGeneralId, preventGeneralId, (short)dea2);
                        addExp_P(preventGeneralId, attackGeneralId, dea1);
                        AIWarAddEXP2(preventGeneralId, attackGeneralId, (short)dea1);
                    }
                }
            }
            else if (soldier1 > 0 && soldier2 <= 0)
            {
                if (isprefectId)
                {
                    int power1 = satrapVal(attackGeneralId);
                    int power2 = getGenSinglePower(preventGeneralId);
                    power1 = moniAtkgetGenPower(power1, false, attackGeneralId);
                    int sword1 = power1 * soldier1;
                    byte phy = cangetphy(preventGeneralId);
                    int sword2 = power2 * phy * 3;
                    if (sword1 > sword2)
                    {
                        int dea1 = sword2 / power1;
                        changeSoldier(attackGeneralId, (short)dea1);
                        GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)(35 + CommonUtils.getRandomInt() % 5));
                        GeneralListCache.addforceExp(preventGeneralId, (byte)(dea1 / 50));
                    }
                    else
                    {
                        (GeneralListCache.GetGeneral(attackGeneralId)).generalSoldier = 0;
                        byte physical = (byte)(sword1 / power2 * 3);
                        GeneralListCache.GetGeneral(preventGeneralId).decreaseCurPhysical(physical);
                        if (GeneralListCache.GetGeneral(preventGeneralId).getCurPhysical() < 1)
                            GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)1);
                        GeneralListCache.addforceExp(preventGeneralId, (byte)(soldier1 / 50));
                    }
                }
                else
                {
                    byte t = getWarTTT(this.tarCity);
                    int power1 = satrapVal(attackGeneralId);
                    int power2 = getGenSinglePower(preventGeneralId);
                    power1 = getSword(power1, t, attackGeneralId);
                    power1 = moniAtkgetGenPower(power1, false, attackGeneralId);
                    int sword1 = power1 * soldier1;
                    byte phy = cangetphy(preventGeneralId);
                    int sword2 = power2 * phy * 2;
                    if (sword1 > sword2)
                    {
                        int dea1 = sword2 / power1;
                        changeSoldier(attackGeneralId, (short)dea1);
                        GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)(35 + CommonUtils.getRandomInt() % 5));
                        GeneralListCache.addforceExp(preventGeneralId, (byte)(dea1 / 50));
                    }
                    else
                    {
                        (GeneralListCache.GetGeneral(attackGeneralId)).generalSoldier = 0;
                        byte physical = (byte)(sword1 / power2 * 2);
                        GeneralListCache.GetGeneral(preventGeneralId).decreaseCurPhysical(physical);
                        if (GeneralListCache.GetGeneral(preventGeneralId).getCurPhysical() < 1)
                            GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)1);
                        GeneralListCache.addforceExp(preventGeneralId, (byte)(soldier1 / 50));
                    }
                }
            }
            else if (soldier1 <= 0 && soldier2 > 0)
            {
                if (isprefectId)
                {
                    int power1 = getGenSinglePower(attackGeneralId);
                    int power2 = satrapVal(preventGeneralId);
                    power2 = (int)(power2 * 1.33D);
                    power2 = moniAtkgetGenPower(power2, true, preventGeneralId);
                    byte phy = cangetphy(attackGeneralId);
                    int sword1 = power1 * phy;
                    int sword2 = power2 * soldier2;
                    if (sword1 > sword2)
                    {
                        (GeneralListCache.GetGeneral(preventGeneralId)).generalSoldier = 0;
                        byte physical = (byte)(sword2 / power1);
                        GeneralListCache.GetGeneral(attackGeneralId).decreaseCurPhysical(physical);
                        if (GeneralListCache.GetGeneral(attackGeneralId).getCurPhysical() < 1)
                            GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)1);
                        GeneralListCache.addforceExp(attackGeneralId, (byte)(soldier2 / 50));
                    }
                    else
                    {
                        int dea1 = sword1 / power2;
                        changeSoldier(preventGeneralId, (short)dea1);
                        GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)(35 + CommonUtils.getRandomInt() % 5));
                        GeneralListCache.addforceExp(attackGeneralId, (byte)(dea1 / 50));
                    }
                }
                else
                {
                    byte t = getWarTTT(this.tarCity);
                    int power1 = getGenSinglePower(attackGeneralId);
                    int power2 = satrapVal(preventGeneralId);
                    power2 = getSword(power2, t, preventGeneralId);
                    power2 = moniAtkgetGenPower(power2, false, preventGeneralId);
                    byte phy = cangetphy(attackGeneralId);
                    int sword1 = power1 * phy * 2;
                    int sword2 = power2 * soldier2;
                    if (sword1 > sword2)
                    {
                        (GeneralListCache.GetGeneral(preventGeneralId)).generalSoldier = 0;
                        byte physical = (byte)(sword2 / power1 * 2);
                        GeneralListCache.GetGeneral(attackGeneralId).decreaseCurPhysical(physical);
                        if (GeneralListCache.GetGeneral(attackGeneralId).getCurPhysical() < 1)
                            GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)1);
                        GeneralListCache.addforceExp(attackGeneralId, (byte)(soldier2 / 50));
                    }
                    else
                    {
                        int dea1 = sword1 / power2;
                        changeSoldier(preventGeneralId, (short)dea1);
                        GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)(35 + CommonUtils.getRandomInt() % 5));
                        GeneralListCache.addforceExp(attackGeneralId, (byte)(dea1 / 50));
                    }
                }
            }
            else if (soldier1 <= 0 && soldier2 <= 0)
            {
                int power1 = (GeneralListCache.GetGeneral(attackGeneralId)).force + (GeneralListCache.GetGeneral(attackGeneralId)).force * ((WeaponListCache.getWeapon((GeneralListCache.GetGeneral(attackGeneralId)).weapon)).weaponProperties + (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(attackGeneralId)).armor)).weaponProperties) / 100;
                int power2 = (GeneralListCache.GetGeneral(preventGeneralId)).force + (GeneralListCache.GetGeneral(preventGeneralId)).force * ((WeaponListCache.getWeapon((GeneralListCache.GetGeneral(preventGeneralId)).weapon)).weaponProperties + (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(preventGeneralId)).armor)).weaponProperties) / 100;
                power1 = 1 + power1 * power1 / 2;
                power2 = 1 + power2 * power2 / 2;
                byte phy1 = GeneralListCache.GetGeneral(attackGeneralId).getCurPhysical();
                byte phy2 = GeneralListCache.GetGeneral(preventGeneralId).getCurPhysical();
                if (power1 * phy1 > power2 * phy2)
                {
                    GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)10);
                    byte x = (byte)((power1 * phy1 - power2 * phy2) / power1);
                    GeneralListCache.GetGeneral(attackGeneralId).decreaseCurPhysical(x);
                    if (GeneralListCache.GetGeneral(attackGeneralId).getCurPhysical() < 10)
                        GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)10);
                    GeneralListCache.addforceExp(attackGeneralId, (byte)10);
                    GeneralListCache.addforceExp(preventGeneralId, (byte)2);
                }
                else if (power1 * phy1 == power2 * phy2)
                {
                    GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)(10 + CommonUtils.getRandomInt() % 5));
                    GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)(10 + CommonUtils.getRandomInt() % 5));
                    GeneralListCache.addforceExp(attackGeneralId, (byte)5);
                    GeneralListCache.addforceExp(preventGeneralId, (byte)5);
                }
                else
                {
                    GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)10);
                    byte x = (byte)((power2 * phy2 - power1 * phy1) / power2);
                    GeneralListCache.GetGeneral(preventGeneralId).decreaseCurPhysical(x);
                    if (GeneralListCache.GetGeneral(preventGeneralId).getCurPhysical() < 10)
                        GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)10);
                    GeneralListCache.addforceExp(attackGeneralId, (byte)2);
                    GeneralListCache.addforceExp(preventGeneralId, (byte)10);
                }
            }
        }

        void moniAtk(short[] genId1, short[] genId2, byte index1, byte index2)
        {
            // �жϹ�������ս���Ƿ���ڷ��ط�
            if (this.gfZL[index1] > this.ffZL[index2])
            {
                // ������ط���ʧ��ʿ��������dea1 Ϊ��������dea2 Ϊ���ط�
                int dea1 = this.ffZL[index2] / this.gfzdl[index1];
                int dea2;
                // �жϷ��ط��Ƿ�Ϊ��һ�����ؽ���
                if (index2 == 0)
                {
                    dea2 = this.ffZL[index2] / this.ffzdl[index2];
                }
                else
                {
                    dea2 = this.ffZL[index2] / this.ffzdl[index2];
                }
                // �����������ͷ��ط���ʿ������
                changeSoldier(genId1[index1], (short)dea1);
                changeSoldier(genId2[index2], (short)dea2);
                // ����ս��
                this.gfZL[index1] = this.gfZL[index1] - this.ffZL[index2];
                this.ffZL[index2] = 0;
                // ���Ӿ���ֵ
                addExp_P(genId1[index1], genId2[index2], dea2);
                AIWarAddEXP(genId1[index1], genId2[index2], (short)dea2);
                addExp_P(genId2[index2], genId1[index1], dea1);
                AIWarAddEXP(genId2[index2], genId1[index1], (short)dea1);
            }
            else
            {
                // ���㹥������ʧ��ʿ������
                int dea1 = this.gfZL[index1] / this.gfzdl[index1];
                int dea2;
                // �жϷ��ط��Ƿ�Ϊ��һ�����ؽ���
                if (index2 == 0)
                {
                    dea2 = this.gfZL[index1] / this.ffzdl[index2];
                }
                else
                {
                    dea2 = this.gfZL[index1] / this.ffzdl[index2];
                }
                // ���·��ط���ս��
                this.ffZL[index2] = this.ffZL[index2] - this.gfZL[index1];
                this.gfZL[index1] = 0;
                // ����ʿ������
                changeSoldier(genId1[index1], (short)dea1);
                changeSoldier(genId2[index2], (short)dea2);
                // ���Ӿ���ֵ
                addExp_P(genId1[index1], genId2[index2], dea2);
                AIWarAddEXP(genId1[index1], genId2[index2], (short)dea2);
                addExp_P(genId2[index2], genId1[index1], dea1);
                AIWarAddEXP(genId2[index2], genId1[index1], (short)dea1);
            }
        }


        void changeSoldier(short genId, short num)
        {
            // ���ٽ����ʿ������
            GeneralListCache.GetGeneral(genId).generalSoldier -= num;
            // ȷ��ʿ����������Ϊ����
            if (GeneralListCache.GetGeneral(genId).generalSoldier < 0)
                GeneralListCache.GetGeneral(genId).generalSoldier = 0;
        }

        //�۲�ģʽ
        void void_bb()
        {
            // �����ǰ�ǹ۲�ģʽ
            if (GameInfo.isWatch)
            {
                try
                {
                    // �߳�ͬ������ͣ 1500 ����
                    lock (this)
                    {
                        System.Threading.Thread.Sleep(1500);
                    }
                }
                catch (Exception exception) { }
                // �ػ���Ϸ����
                //this.gamecanvas.repaint();
            }
            else
            {/*
                // ��ȡ��ǰϵͳʱ��
                for (long l1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    //this.gamecanvas.getKeyValue() == 0; l1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond)
                {
                    // ���㾭����ʱ��
                    long l2 = ((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - l1);
                    if (l2 < 100)
                    {
                        try
                        {
                            // �߳�ͬ������ͣ�㹻��ʱ����ά�� 100 ����ļ��
                            lock (this)
                            {
                                System.Threading.Thread.Sleep((int)(100 - l2));
                            }
                        }
                        catch (Exception exception) { }
                    }
                    // �ػ���Ϸ����
                    //this.gamecanvas.repaint();
                }
          */  }
        }



        // ����ս��
        void startWar()
        {
            int needFood = 0;
            int needMoney = 0;

            // ��ȡĿ����е�ʵ��
            City tCity = CityListCache.GetCityByCityId(this.tarCity);

            // ����з��ٽ����е���󹥻���
            int enemyAdjacentAtkPower = CountryListCache.getOtherCityMaxAtkPower(this.tarCity, this.curCity);
            enemyAdjacentAtkPower = (int)(enemyAdjacentAtkPower * 0.3D); // ȡ30%��ֵ

            // ��ȡս�°칫���еĽ��� ID ����
            short[] warOfficeGeneralIdArray = tCity.GetWarOfficeGeneralIdArray(enemyAdjacentAtkPower);

            // ѡ��Ľ�������
            this.chooseGeneralNum = (byte)warOfficeGeneralIdArray.Length;

            // ���û�н�����Բ���ս����ֱ�ӷ���
            if (this.chooseGeneralNum == 0)
                return;

            // �Ƴ�ս�°칫�ҵĽ���
            for (int i = 0; i < warOfficeGeneralIdArray.Length; i++)
                tCity.removeOfficeGeneralId(warOfficeGeneralIdArray[i]);

            // ��������̫��
            tCity.AppointmentPrefect();

            // ��ʼ��ѡ��Ľ��� ID ����
            this.chooseGeneralIdArray = new short[10];

            // ��ս�°칫�ҵĽ��� ID ��䵽ѡ��Ľ���������
            for (int i = 0; i < warOfficeGeneralIdArray.Length; i++)
                this.chooseGeneralIdArray[i] = warOfficeGeneralIdArray[i];

            // ����������ʳ
            needFood = NeedFoodValue(tCity, this.chooseGeneralIdArray, this.chooseGeneralNum);

            // ��ȡ��ǰ����ʵ��
            City cCity = CityListCache.GetCityByCityId(this.curCity);

            // ��ȡ��ǰ�������������� ID
            short kingId = cCity.cityBelongKing;

            // ���������Ǯ������Ǯ����50����Ϊ0������ȡһ��
            if (tCity.GetMoney() < 50)
            {
                needMoney = 0;
            }
            else
            {
                needMoney = tCity.GetMoney() / 2;
            }

            // �����ǰ����û�й���������������ʳ�ͽ�Ǯ
            if (kingId == 0)
            {
                needFood /= 5;
                needMoney /= 5;
            }

            // ����Ŀ����еĽ�Ǯ����ʳ
            tCity.DecreaseMoney((short)needMoney);
            tCity.DecreaseFood((short)needFood);

            // ��������
            System.GC.Collect();

            // �жϽ������Ƿ�����ҿ��ƵĹ���
            if (kingId == (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
            {
                // ������ʾ��Ϣ
                GameInfo.ShowInfo = $"{GeneralListCache.GetGeneral((CountryListCache.GetCountryByCountryId(this.curTurnsCountryId)).countryKingId).generalName}������ {cCity.cityName}...";

                // �����¼� ID
                this.eventId = 1;

                // ִ����Ӧ����Ϸ�¼�
                RefreshFeedBack((byte)19);
                void_bb();

                // ��¼ս���еĽ�Ǯ����ʳ
                this.aiMoney_inWar = (short)needMoney;
                this.aiGrain_inWar = (short)needFood;
                this.j_byte_fld = 3;
                return;
            }

            // ����ǰ�����޹���
            if (kingId == 0)
            {
                this.eventId = 2;
                RefreshFeedBack((byte)19);
                FloodDisasterCanvans();
                OccupyCity(this.chooseGeneralIdArray, this.chooseGeneralNum, needFood, needMoney);
            }
            else
            {
                // ��ȡ�з����� ID
                byte countryId = (CountryListCache.GetCountryByKingId(kingId)).countryId;

                // ������ʾ��Ϣ���ַ���
                string str = "[";
                for (int j = 0; j < this.chooseGeneralNum && j < 3; j++)
                    str += $"{GeneralListCache.GetGeneral(this.chooseGeneralIdArray[j]).generalName}��";

                // �Ƴ����һ�� "��"
                str = str.Substring(0, str.Length - 1);
                str += "]";

                if (this.chooseGeneralNum > 3)
                    str += $"��{this.chooseGeneralNum}Ա��";

                str = $"{GeneralListCache.GetGeneral((CountryListCache.GetCountryByCountryId(this.curTurnsCountryId)).countryKingId).generalName}�� ��{tCity.cityName}�ɳ�{str}��{GeneralListCache.GetGeneral(kingId).generalName}��{cCity.cityName}����ս����";

                // �����Ϣ������̨
                Console.WriteLine(str);

                // ������Ϸ��ʾ��Ϣ
                GameInfo.ShowInfo = str;

                // �����¼� ID
                this.eventId = 1;

                // ����ս���¼�
                RefreshFeedBack((byte)19);
                FloodDisasterCanvans();

                // �ж��Ƿ��ܹ�ռ�����
                if (isCapture(this.chooseGeneralIdArray, this.chooseGeneralNum, needFood, needMoney))
                {
                    this.eventId = 4;
                }
                else
                {
                    this.eventId = 5;
                }

                // ��������ս���¼�
                RefreshFeedBack((byte)19);
                FloodDisasterCanvans();

                // ���з������Ƿ��Ѿ�����
                if (CountryListCache.GetCountryByCountryId(countryId) == null)
                {
                    this.AIGeneralId = kingId;
                    this.m_byte_fld = countryId;
                    this.eventId = 18;
                    RefreshFeedBack((byte)19);
                    FloodDisasterCanvans();
                }
                else if ((CountryListCache.GetCountryByCountryId(countryId)).countryKingId != kingId)
                {
                    this.AIGeneralId = kingId;
                    this.m_byte_fld = countryId;
                    this.eventId = 19;
                    RefreshFeedBack((byte)19);
                    FloodDisasterCanvans();
                }
            }

            // ��ͣ500������ģ���¼��ӳ�
            try
            {
                System.Threading.Thread.Sleep(500);
            }
            catch (Exception exception) { }

            // ��������
            System.GC.Collect();
        }


        // �����������н���������Ƿ񶼴��� 40
        bool IsAllGeneralHpTooLow(byte byte0)
        {
            // ��ȡ����ʵ��
            City city = CityListCache.GetCityByCityId(byte0);

            // ��ȡ��������ְ�Ľ��� ID ����
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // ���������еĽ���
            for (int i1 = 0; i1 < city.getCityGeneralNum(); i1++)
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[i1]);

                // ������������С��������������������� 40���򷵻� false
                if (general.getCurPhysical() < general.maxPhysical && general.getCurPhysical() <= 40)
                    return false;
            }

            // ���н�������������Ҫ�󣬷��� true
            return true;
        }

        // ���������������м���
        int TrappedUnitNumb_e(byte byte0, byte byte1)
        {
            return DiffSoldierGenByFightBetweenCity(byte0, byte1);
        }

        // �жϵ�ǰ�����Ƿ�����ҽ���
        bool isAllianceWithUser()
        {
            // ��ȡ������ڵĹ���
            Country country = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);

            // ��ȡ���˹��ҵ��б�
            List<Alliance> allianceCountry = country.allianceList;

            // ���û�н��˹��ң����� false
            if (allianceCountry.Count == 0)
                return false;

            // ���������б��ж��Ƿ��뵱ǰ�غϹ��ҽ���
            for (int i = 0; i < allianceCountry.Count; i++)
            {
                Alliance alliance = allianceCountry [i];
                if (alliance.countryId == this.curTurnsCountryId)
                    return true;
            }

            return false;
        }

        // ������ѽ�������
        int FindAttackedCity()
        {
            int j1 = -1001;  // ��ʼ������
            bool flag = isAllianceWithUser();  // �ж��Ƿ�����ҽ���

            // ������ǰ���ҵ����г���
            for (int byte2 = 0; byte2 < CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).GetHaveCityNum(); byte2++)
            {
                byte cityId = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).getCity(byte2);

                // ������еĽ��������� 2��������ж�
                if (CityListCache.GetCityByCityId(cityId).getCityGeneralNum() > 2)
                {
                    // �������ӳ���
                    for (byte byte3 = 0; byte3 < (CityListCache.GetCityByCityId(cityId)).connectCityId.Length; byte3 = (byte)(byte3 + 1))
                    {
                        byte byte1 = (byte)(CityListCache.GetCityByCityId(cityId)).connectCityId[byte3];

                        // �жϵ�ǰ���������ӳ����Ƿ����ڲ�ͬ�Ĺ���
                        if ((CityListCache.GetCityByCityId(cityId)).cityBelongKing != (CityListCache.GetCityByCityId(byte1)).cityBelongKing &&
                            (!flag || (CityListCache.GetCityByCityId(byte1)).cityBelongKing != (CityListCache.GetCityByCityId(GameInfo.humanCountryId)).cityBelongKing))
                        {
                            // ������н�����ֵ
                            int i1 = TrappedUnitNumb_e(cityId, byte1);

                            // ��¼���ֵ
                            if (i1 > j1)
                            {
                                j1 = i1;
                                this.tarCity = cityId;  // Ŀ�����
                                this.curCity = byte1;   // ��ǰ����
                            }
                        }
                    }
                }
            }

            // ������ֳ�����ֵ�����ý���ģʽ
            if (j1 >= -1000)
                this.X = 3;

            return j1;
        }

        // �жϵ�ǰ�غϹ����Ƿ���Ҫ����
        bool needConscription(byte curTurnsCountryId)
        {
            return AiJudDraft(curTurnsCountryId);
        }

        // ������ǰ�������н����ʿ��
        void GeneralSoldierToReserve()
        {
            City city = CityListCache.GetCityByCityId(this.tarCity);

            // ���������еĽ���
            for (byte byte0 = 0; byte0 < city.getCityGeneralNum(); byte0 = (byte)(byte0 + 1))
            {
                // �������ʿ��������е�Ԥ��ʿ���У����������ʿ����������
                city.cityReserveSoldier += GeneralListCache.GetGeneral(city.getCityOfficeGeneralIdArray()[byte0]).generalSoldier;
                GeneralListCache.GetGeneral(city.getCityOfficeGeneralIdArray()[byte0]).generalSoldier = 0;
            }
        }

        // �Խ���������򣬰�ͳ������ֵ����
        void SortGeneralFightValue()
        {
            City city = CityListCache.GetCityByCityId(this.tarCity);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // ���������б��������
            for (byte byte0 = 1; byte0 < city.getCityGeneralNum(); byte0 = (byte)(byte0 + 1))
            {
                short generalId1 = officeGeneralIdArray[byte0];
                int i = satrapVal(generalId1);  // ��ȡ����1��ͳ������

                // ��ʣ��Ľ�����бȽϣ��ҵ�ͳ���������ߵĽ���
                for (byte byte1 = byte0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
                {
                    short generalId2 = officeGeneralIdArray[byte1];
                    int j = satrapVal(generalId2);  // ��ȡ����2��ͳ������

                    // �������2������ֵ���ߣ��򽻻�
                    if (j > i)
                    {
                        short max = generalId2;
                        generalId2 = generalId1;
                        generalId1 = max;
                    }
                }
            }
        }

        // AI ����ʿ������
        void AIDistributionSoldier()
        {
            SortGeneralFightValue();  // �Խ����������
            GeneralSoldierToReserve();  // �����н����ʿ���ռ������е�Ԥ��ʿ����

            short totalSoldier = CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum();  // ��ʿ����
            byte generalNum = CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum();    // ��������

            // �������첢����ʿ��
            for (int i = 0; i < generalNum && totalSoldier > 0; i++)
            {
                General general = GeneralListCache.GetGeneral(CityListCache.GetCityByCityId(this.tarCity).getCityOfficeGeneralIdArray()[i]);
                short needSoldier = (short)(general.getMaxGeneralSoldier() - general.generalSoldier);  // ��Ҫ��ʿ����

                // ���������Ҫʿ���������
                if (needSoldier > 0)
                {
                    if (needSoldier >= totalSoldier)
                    {
                        general.generalSoldier += totalSoldier;  // ��������ʣ��ʿ��
                        totalSoldier = 0;
                    }
                    else
                    {
                        general.generalSoldier += needSoldier;  // ��������ʿ��
                        totalSoldier -= needSoldier;
                    }
                }
            }
        }


        // AI �Զ�����
        void AIConscription()
        {
            byte thecity = 0;  // ��¼�˿����ĳ��� ID
            int maxpopulation = 0;  // ��¼����˿�
            Country curCountry = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId);  // ��ȡ��ǰ�غϹ���

            if (curCountry == null)  // �������Ϊ�գ��򷵻�
                return;

            byte CITY_NUM = curCountry.GetHaveCityNum();  // ��ȡ��ǰ���ҵĳ�������

            if (CITY_NUM < 1)  // ���û�г��У��򷵻�
                return;

            // �������г��У��ҵ��˿����ĳ���
            for (int i = 0; i < CITY_NUM; i++)
            {
                byte cityId = curCountry.getCity(i);  // ��ȡ���� ID
                City city = CityListCache.GetCityByCityId(cityId);  // ���� ID ��ȡ����ʵ��

                // ��������˿ڳ��� 1000 �Ҵ��ڵ�ǰ��¼������˿ڣ���������˿ں�Ŀ����� ID
                if (city.population > 1000 && city.population > maxpopulation)
                {
                    maxpopulation = city.population;
                    thecity = cityId;
                }
            }

            // ���û�з��������ĳ��л�������˿����� 1000������
            if (thecity == 0 || maxpopulation < 1000)
                return;

            // �������г��н�����������
            for (int i = 0; i < CITY_NUM; i++)
            {
                byte cityId = curCountry.getCity(i);  // ��ȡ��ǰ���� ID
                City city = CityListCache.GetCityByCityId(cityId);  // ��ȡ��ǰ����ʵ��

                int i1 = city.getAllSoldierNum();  // ��ȡ���е���ʿ����
                int j1 = i1 - city.GetCityAllSoldierNum();  // ��ȡ���з�פ��ʿ����
                int needSoldierNum = j1 - city.cityReserveSoldier;  // ������Ҫ�����ʿ����

                // �����Ҫ����ʿ��
                if (needSoldierNum > 0)
                {
                    int needMoney = ((needSoldierNum - 1) / 100 + 1) * 20;  // ������������Ľ�Ǯ
                    City thisCity = CityListCache.GetCityByCityId(thecity);  // ��ȡ�˿����ĳ���ʵ��

                    // �����ǰ�������㹻�Ľ�Ǯ��������
                    if (city.GetMoney() >= needMoney)
                    {
                        city.DecreaseMoney((short)needMoney);  // ���ٳ��н�Ǯ
                        city.cityReserveSoldier += needMoney * 5;  // ���ӳ��е�Ԥ��ʿ��
                        thisCity.population -= needSoldierNum;  // �����˿������е��˿�

                        // ����˿ڼ��ٵ���������Ϊ 0
                        if (thisCity.population < 0)
                            thisCity.population = 0;
                    }
                    else  // �����Ǯ����
                    {
                        int i2 = city.GetMoney() / 20 * 20;  // ���ݽ�Ǯ���������������
                        city.DecreaseMoney((short)i2);  // ���ٳ��н�Ǯ
                        city.cityReserveSoldier += i2 * 5;  // ���ӳ��е�Ԥ��ʿ��
                        thisCity.population -= i2 * 5;  // �����˿������е��˿�

                        // ����˿ڼ��ٵ���������Ϊ 0
                        if (thisCity.population < 0)
                            thisCity.population = 0;
                    }
                }

                // ����ʿ��������
                city.distributionSoldier();
            }
        }

        // �жϳ����Ƿ�Ϊ�жԳ���
        bool cityIsEnemy(byte cityId)
        {
            short[] cityIdArray = CityListCache.GetCityByCityId(cityId).connectCityId;  // ��ȡ��ǰ���е����ӳ��� ID ����

            // �������ӵĳ��У��ж��Ƿ����ڲ�ͬ����
            for (byte byte1 = 0; byte1 < cityIdArray.Length; byte1 = (byte)(byte1 + 1))
            {
                // ������ӳ��еĹ����뵱ǰ���в�ͬ������ true
                if (CityListCache.GetCityByCityId((byte)cityIdArray[byte1]).cityBelongKing != CityListCache.GetCityByCityId(cityId).cityBelongKing)
                    return true;
            }

            // ����������ӵĳ��ж�����ͬһ���������� false
            return false;
        }

        

        // �ƶ����쵽Ŀ�����
        void AiMoveGenToCity(int i1)
        {
            // �ƶ�ָ�������Ľ���
            for (int j1 = 0; j1 < i1; j1++)
            {
                City city = CityListCache.GetCityByCityId(this.curCity);  // ��ȡ��ǰ����ʵ��
                short generalId = city.getCityOfficeGeneralIdArray()[city.getCityGeneralNum() - 1];  // ��ȡ��ǰ�������һ������ ID

                city.removeOfficeGeneralId(generalId);  // �Ƴ��ý���
                CityListCache.GetCityByCityId(this.tarCity).AddOfficeGeneralId(generalId);  // ���ý�����ӵ�Ŀ�����

                // ���Ŀ����еĽ������ﵽ 10��ֹͣ����
                if (CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum() >= 10)
                    return;
            }
        }

        /// <summary>
        /// AIѰ�ҿ����ƽ���
        /// </summary>
        void AiFindTreatGeneral()
        {
            // ��������Ƿ����ִ�в�����1/3 ����ִ��
            if (CommonUtils.getRandomInt() % 3 > 0)
                return;

            // ������ǰ���ҵ����г���
            for (int byte1 = 0; byte1 < CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).GetHaveCityNum(); byte1++)
            {
                byte byte0 = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).getCity(byte1);  // ��ȡ���� ID

                // �жϳ����Ƿ�����������ҵжԲ����㹻��Ǯ
                if ((this.k_byte_array1d_fld[byte0] & 0x4) == 4 && CityListCache.GetCityByCityId(byte0).GetMoney() >= 100 && cityIsEnemy(byte0))
                {
                    byte byte2 = 0;
                    while (true)
                    {
                        City city = CityListCache.GetCityByCityId(byte0);  // ��ȡ��ǰ����ʵ��
                        short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();  // ��ȡ��ǰ���еĽ��� ID ����

                        // ������������н��죬����ѭ��
                        if (byte2 >= city.getCityGeneralNum())
                            break;

                        // �жϽ���������Ƿ�С�����ֵ 40 ��С�ڵ�ǰ����
                        if ((GeneralListCache.GetGeneral(officeGeneralIdArray[byte2])).maxPhysical - 40 > GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]).getCurPhysical())
                        {
                            this.X = 19;  // �����¼�����Ϊ 19
                            this.tarCity = byte0;  // ����Ŀ�����
                            this.HMGeneralId = officeGeneralIdArray[byte2];  // ���ò����Ľ���
                            return;
                        }
                        byte2 = (byte)(byte2 + 1);
                    }
                }
            }
        }

        // �ж��Ƿ��������
        bool canTreatment()
        {
            return AiFindLowHpEnemyGeneral();  // ���� AiFindLowHpEnemyGeneral �����ж�
        }

        /// <summary>
        /// �������һ������Ч��ֵ
        /// </summary>
        /// <returns></returns>
        int AiTreatValue()
        {
            return 35 + CommonUtils.getRandomInt() % 17;  // ���� 35 �� 51 �����ֵ
        }

        /// <summary>
        /// �������һ������Ч��ֵ
        /// </summary>
        /// <returns></returns>
        int HmTreatValue()
        {
            return 20 + CommonUtils.getRandomInt() % 15;  // ���� 20 �� 34 �����ֵ
        }

        /// <summary>
        /// AIִ�����Ʋ���
        /// </summary>
        void AiTreat()
        {
            byte physical = (byte)AiTreatValue();  // ��ȡ�������Ч��
            General general = GeneralListCache.GetGeneral(this.HMGeneralId);  // ��ȡ��ǰ�����Ľ���

            general.addCurPhysical(physical);  // ���ӽ���ĵ�ǰ����

            // ��������������ֵ��С�ڵ��� 0����������Ϊ���ֵ
            if (general.getCurPhysical() > general.maxPhysical || general.getCurPhysical() <= 0)
                general.setCurPhysical(general.maxPhysical);

            CityListCache.GetCityByCityId(this.tarCity).DecreaseMoney((short)50);  // �ӳ��еĽ�Ǯ�п۳� 50
        }

        /// <summary>
        /// AIִ��Ѱ�ҿɽ��ͽ������
        /// </summary>
        void AiFindRewardGeneral()
        {
            // 1/5 �ļ���ִ�в���
            if (CommonUtils.getRandomInt() % 5 > 0)
                return;

            // ������ǰ���ҵ����г���
            for (int byte1 = 0; byte1 < CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).GetHaveCityNum(); byte1++)
            {
                byte byte0 = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).getCity(byte1);  // ��ȡ��ǰ���� ID

                // �жϳ����Ƿ����㹻�Ľ�Ǯ�򱦲�
                if (CityListCache.GetCityByCityId(byte0).GetMoney() >= 200 || CityListCache.GetCityByCityId(byte0).treasureNum != 0)
                {
                    byte byte2 = 0;
                    while (true)
                    {
                        City city = CityListCache.GetCityByCityId(byte0);  // ��ȡ����ʵ��
                        short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();  // ��ȡ���еĽ��� ID ����

                        // ���������н���������
                        if (byte2 >= city.getCityGeneralNum())
                            break;

                        // �жϽ�����ҳ϶��Ƿ�С�� 50
                        if (GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]).getLoyalty() < 50)
                        {
                            this.X = 8;  // �����¼�����Ϊ 8
                            this.tarCity = byte0;  // ����Ŀ�����
                            this.HMGeneralId = officeGeneralIdArray[byte2];  // ���ò����Ľ���
                            return;
                        }
                        byte2 = (byte)(byte2 + 1);
                    }
                }
            }
        }


        // ִ�� AiFindLowLoyaltyGeneral ����
        void void_bl()
        {
            AiFindLowLoyaltyGeneral();
        }

        // ������ֵ�����ݴ���� i1 ���ز�ͬ�����ֵ
        int int_i_c(int i1)
        {
            // ������� 200������ 11 �� 18 ֮������ֵ
            if (i1 == 200)
                return 11 + CommonUtils.getRandomInt() % 8;

            int j1 = i1 / 8;  // j1 Ϊ i1 ���� 8 ����
            int k1 = CommonUtils.getRandomInt() % 8;  // ��ȡ 0 �� 7 �����ֵ

            // ��� k1 С�� i1 ���� 8 ��������j1 �� 1
            if (k1 < i1 % 8)
                j1++;

            // ��� j1 ���� 7�����е���
            if (j1 > 7)
                j1 += CommonUtils.getRandomInt() % 2 - 1;

            return j1;  // ���ؼ����� j1
        }

        /// <summary>
        /// Ai���ͽ����ҳ϶Ȼ����Ŀ����еı��ػ��Ǯ
        /// </summary>
        void AiRewardGeneral()
        {
            // ���û������Ŀ����У�ֱ�ӷ���
            if (this.tarCity == 0)
                return;

            General general = GeneralListCache.GetGeneral(this.HMGeneralId);  // ��ȡ��ǰ����
            City city = CityListCache.GetCityByCityId(this.tarCity);  // ��ȡĿ�����

            // ���������ҳ϶ȴ��� 90 �ҳ����б���
            if (general.getLoyalty() > 90)
            {
                if (city.treasureNum > 0)
                {
                    general.AddLoyalty(false);  // �����ҳ϶ȵ����Ϊ���Ѻ�
                    city.treasureNum = (byte)(city.treasureNum - 1);  // ���ٳ��еı�������
                    return;
                }
            }
            // ����������н�Ǯ���� 50
            else if (city.GetMoney() > 50)
            {
                general.AddLoyalty(true);  // �����ҳ϶��ұ��Ϊ�Ѻ�
                city.DecreaseMoney((short)50);  // ���ٳ��еĽ�Ǯ
            }
            // �������û���㹻�Ľ�Ǯ���б���
            else if (city.treasureNum > 0)
            {
                general.AddLoyalty(false);  // �����ҳ϶ȵ����Ϊ���Ѻ�
                city.treasureNum = (byte)(city.treasureNum - 1);  // ���ٳ��еı���
            }
        }

        /// <summary>
        /// AI������ʳ
        /// </summary>
        void AiTransportFood()
        {
            City tCity = CityListCache.GetCityByCityId(this.tarCity);  // ��ȡĿ�����
            City cCity = CityListCache.GetCityByCityId(this.curCity);  // ��ȡ��ǰ����

            // �����ǰ����û����ʳ��ֱ�ӷ���
            if (cCity.GetFood() < 1)
                return;

            short[] curval = new short[3];
            short[] tarval = new short[3];
            curval = cityNeedFood(this.curCity);  // ��ȡ��ǰ���е���ʳ����
            tarval = cityNeedFood(this.tarCity);  // ��ȡĿ����е���ʳ����

            short canNum = 0;
            short mustMum = 0;
            int s = 0;

            // ��ǰ��Ŀ����ж�ȱ��ʳ
            if (curval[2] < 0 && tarval[2] < 0)
            {
                canNum = (short)Math.Abs(curval[2]);
                mustMum = (short)Math.Abs(tarval[2]);

                if (mustMum + canNum + cCity.GetFood() + tCity.GetFood() != 0)
                {
                    s = (mustMum * cCity.GetFood() - canNum * tCity.GetFood()) / (mustMum + canNum + cCity.GetFood() + tCity.GetFood());
                    if (s > cCity.GetFood() || s < 0)
                        s = cCity.GetFood();
                }
            }
            // ��ǰ��������ʳ��Ŀ�����ȱ��
            else if (curval[2] > 0 && tarval[2] < 0)
            {
                canNum = (short)Math.Abs(curval[2]);
                mustMum = (short)Math.Abs(tarval[2]);

                if (mustMum - canNum + cCity.GetFood() + tCity.GetFood() != 0)
                {
                    s = (mustMum * cCity.GetFood() + canNum * tCity.GetFood()) / (mustMum - canNum + cCity.GetFood() + tCity.GetFood());
                    if (s > cCity.GetFood() || s < 0)
                        s = cCity.GetFood();
                }
            }
            // ��ǰ��Ŀ����ж����㹻��ʳ
            else if (curval[2] > 0 && tarval[2] > 0)
            {
                s = canNum;
            }

            // ����Ƿ񳬹�Ŀ����е������ʳ����
            if (s > 30000 - tCity.GetFood())
                s = 30000 - tCity.GetFood();

            if (s < 0)
                s = 0;

            cCity.DecreaseFood((short)s);  // ��ǰ���м�����ʳ
            tCity.AddFood((short)s);  // Ŀ�����������ʳ
            Console.WriteLine($"{cCity.cityName} ���� {s} ʳ�ﵽ {tCity.cityName}");  // ���������Ϣ
        }

        /// <summary>
        /// AI�����Ǯ
        /// </summary>
        void AiTransportMoney()
        {
            City cCity = CityListCache.GetCityByCityId(this.curCity);  // ��ȡ��ǰ����
            City tCity = CityListCache.GetCityByCityId(this.tarCity);  // ��ȡĿ�����

            // �����ǰ���н�Ǯ���� 100��ֱ�ӷ���
            if (cCity.GetMoney() < 100)
                return;

            short[] curval = new short[3];
            short[] tarval = new short[3];
            curval = cityNeedMoney(this.curCity);  // ��ȡ��ǰ���еĽ�Ǯ����
            tarval = cityNeedMoney(this.tarCity);  // ��ȡĿ����еĽ�Ǯ����

            short canNum = 0;
            short mustMum = 0;
            int s = 0;

            // ��ǰ��Ŀ����ж�ȱǮ
            if (curval[2] < 0 && tarval[2] < 0)
            {
                canNum = (short)Math.Abs(curval[2]);
                mustMum = (short)Math.Abs(tarval[2]);
                s = (mustMum * cCity.GetMoney() - canNum * tCity.GetMoney()) / (mustMum + canNum + cCity.GetMoney() + tCity.GetMoney());

                if (s > cCity.GetMoney() || s < 0)
                    s = cCity.GetMoney();
            }
            // ��ǰ������Ǯ��Ŀ�����ȱǮ
            else if (curval[2] > 0 && tarval[2] < 0)
            {
                canNum = (short)Math.Abs(curval[2]);
                mustMum = (short)Math.Abs(tarval[2]);
                int result = mustMum - canNum + cCity.GetMoney() + tCity.GetMoney();
                result = (result == 0) ? 1 : result;
                s = (mustMum * cCity.GetMoney() + canNum * tCity.GetMoney()) / result;

                if (s > cCity.GetMoney() || s < 0)
                    s = cCity.GetMoney();
            }
            // ��ǰ��Ŀ����ж����㹻��Ǯ
            else if (curval[2] > 0 && tarval[2] > 0)
            {
                s = canNum;
            }

            // ����Ƿ񳬹�Ŀ����е�����Ǯ����
            if (s > 30000 - tCity.GetMoney())
                s = 30000 - tCity.GetMoney();

            if (s < 0)
                s = 0;

            cCity.DecreaseMoney((short)s);  // ��ǰ���м��ٽ�Ǯ
            tCity.AddMoney((short)s);  // Ŀ��������ӽ�Ǯ
            Console.WriteLine($"{cCity.cityName} ���� {s} ��Ǯ�� {tCity.cityName}");  // ���������Ϣ
        }


        /// <summary>
        /// AI���ĳ�������Ƿ������꣬����������߼�
        /// </summary>
        /// <param name="byte0"></param>
        /// <returns></returns>
        bool DoAiHasGrainShop(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);  // ��ȡ���ж���
            int i1 = 0;

            // ���ó��еı�־λ�������־λΪ8������ʳ�����Ǯ�Ľ���
            if ((this.k_byte_array1d_fld[byte0] & 0x8) == 8)
            {
                // �����Ǯ����100��ʳ����㣬�����ʳ�����ӽ�Ǯ
                if (city.GetMoney() < 100 && city.GetFood() > 500)
                {
                    city.DecreaseFood((short)200);
                    CityListCache.GetCityByCityId(byte0).AddMoney((short)150);
                    return true;
                }

                // ���ʳ�ﲻ��200�ҽ�Ǯ���㣬����ٽ�Ǯ����ʳ��
                if (city.GetFood() < 200 && city.GetMoney() > 500)
                {
                    city.DecreaseMoney((short)200);
                    city.AddFood((short)266);
                    return true;
                }
            }

            // ���ó��еı�־λ�������־λΪ2������ѧϰ��Ϊ
            if ((this.k_byte_array1d_fld[byte0] & 0x2) == 2)
                i1 = AIDoLearn(byte0);

            // ���ѧϰ��Ϊ��Ч������true
            if (i1 > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Ai�����ҽ���
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        void AiAlienate(byte byte0, short gohireId, short behireId)
        {
            // �жϷ�������Ƿ�ɹ�
            bool flag = IsSuccessOfAlienate(gohireId, behireId);

            // ����ɹ���Ŀ�����������ҵĹ���
            if (flag)
            {
                if (CityListCache.GetCityByCityId(byte0).cityBelongKing == CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).countryKingId)
                {
                    this.eventId = 16;  // �����¼�ID
                    this.AIGeneralId = behireId;  // ����AI����ID
                    RefreshFeedBack((byte)19);  // �����¼�
                    FloodDisasterCanvans();  // �����¼�
                }
                GeneralListCache.addIQExp(gohireId, (byte)1);  // ������������
            }
        }

        /// <summary>
        /// AI������ҽ���
        /// </summary>
        /// <param name="goCity"></param>
        /// <param name="beCity"></param>
        /// <param name="word0"></param>
        /// <param name="word1"></param>
        void AiBribe(byte goCity, byte beCity, short word0, short word1)
        {
            bool flag = BribeMovePossibility(goCity, beCity, word0, word1);

            // �����Ӷ�ɹ���Ŀ�����������ҵĹ���
            if (flag && CityListCache.GetCityByCityId(beCity).cityBelongKing == CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).countryKingId)
            {
                this.eventId = 17;  // �����¼�ID
                this.tarCity = goCity;  // ����Ŀ�����
                this.AIGeneralId = word1;  // ����AI����ID
                RefreshFeedBack((byte)19);  // �����¼�
                FloodDisasterCanvans();  // �����¼�
            }
        }

        // �Ƴ�ָ����Ԫ�ز������µ�����
        short[] short1_s1bs_b(short[] aword0, byte byte0, short word0)
        {
            // ���Ԫ�ظ������㣬����null
            if (byte0 <= 1)
                return null;

            short[] aword1 = new short[byte0 - 1];  // �������������ڴ洢�Ƴ��������
            byte byte1 = 0;

            // ����ԭ���飬�Ƴ�ָ��Ԫ��
            for (byte byte2 = 0; byte2 < byte0; byte2 = (byte)(byte2 + 1))
            {
                if (aword0[byte2] != word0)
                {
                    byte1 = (byte)(byte1 + 1);
                    aword1[byte1] = aword0[byte2];
                }
            }

            return aword1;  // ����������
        }

        /// <summary>
        /// ��ȡ���������ľ���ID
        /// </summary>
        /// <param name="genId"></param>
        /// <returns></returns>
        short GetOfficeGenBelongKing(short genId)
        {
            short kingId = 0;
            General general = GeneralListCache.GetGeneral(genId); // ��ȡ�������
            City debutCity = CityListCache.GetCityByCityId(general.debutCity); // ��ȡ������εǳ��ĳ���
            short[] officeGeneralIdArray = debutCity.getCityOfficeGeneralIdArray(); // ��ȡ���е���ְ����ID����

            // �������е���ְ����ID���飬���ҽ����Ƿ��ڸó�����ְ
            for (int i = 0; i < officeGeneralIdArray.Length; i++)
            {
                if (officeGeneralIdArray[i] == general.generalId)
                {
                    return debutCity.cityBelongKing; // ���ظó��������ľ���ID
                }
            }

            int inCount = 0; // ������
            string cityInfoString = ""; // ���ڼ�¼�������ڳ�����Ϣ

            // �������г��У����ҽ����Ƿ�������������ְ
            for (byte cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                City city = CityListCache.GetCityByCityId(cityId); // ��ȡ���ж���

                // �������е���ְ����ID����
                for (byte index = 0; index < city.getCityGeneralNum(); index = (byte)(index + 1))
                {
                    if (city.getCityOfficeGeneralIdArray()[index] == genId)
                    {
                        kingId = city.cityBelongKing; // �ҵ��ó��������ľ���ID
                        inCount++; // ����
                        cityInfoString += city.cityName; // ��¼��������

                        // ���������εǳ������뵱ǰ���в�һ�£��������Ϣ
                        if (general.debutCity != cityId)
                        {
                            city.removeOfficeGeneralId(general.generalId); // �Ӿɳ����Ƴ�������ְ��Ϣ
                            general.debutCity = cityId; // ���½���ĳ��εǳ�����
                        }
                    }
                }
            }

            // �������������0������������ְ������Ϣ
            if (inCount > 0)
            {
                Debug.Log(general.generalName + "��" + cityInfoString + "��ְ��"); // ʹ��Unity��Debug.Log�����Ϣ
            }

            return kingId; // ���ؾ���ID
        }


        /// <summary>
        /// AIִ�й�Ӷ����
        /// </summary>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        /// <returns></returns>
        bool AiEmploy(short gohireId, short behireId)
        {
            General goGeneral = GeneralListCache.GetGeneral(gohireId);  // ��ȡ��Ӷ����
            City city = CityListCache.GetCityByCityId(goGeneral.debutCity);  // ��ȡ�ý������ڳ���
            General kingGeneral = GeneralListCache.GetGeneral(city.cityBelongKing);  // ��ȡ�ó��������Ĺ���
            General beGeneral = GeneralListCache.GetGeneral(behireId);  // ��ȡ����Ӷ�Ľ���

            // �������Ӷ�Ľ��첻���ڣ�����false
            if (beGeneral == null)
                return false;

            int d1 = GetdPhase(kingGeneral.phase, beGeneral.phase);  // ��������뱻��Ӷ�������λ��
            int d2 = GetdPhase(goGeneral.phase, beGeneral.phase);  // �����Ӷ�����뱻��Ӷ�������λ��
            int i = MathUtils.getRandomInt(75);  // ��ȡ��������ڹ�Ӷ�ɹ��ж�

            // �����λ�������Ӷ��������Ӷ�ɹ�
            if ((d1 + d2) / 2 < i)
            {
                Console.WriteLine($"{kingGeneral.generalName} �����ɹ���Ӷ {beGeneral.generalName}��");
                return true;
            }

            return false;  // ��Ӷʧ��
        }


        /// <summary>
        /// ��ȡ��ָ������������ӽ��Ĺ���ID
        /// </summary>
        /// <param name="GenId"></param>
        /// <returns></returns>
        byte GetNearPhaseCountryId(short GenId)
        {
            short min = 100;  // ��С���Բ�ֵ
            byte mincountryId = 0;  // ��ʼ������ID
            byte countrySize = CountryListCache.getCountrySize();  // ��ȡ�����б��С
            for (byte i = 1; i < countrySize; i = (byte)(i + 1))
            {
                Country country = CountryListCache.getCountryByIndexId(i);  // ��ȡ���Ҷ���
                if (country != null && country.countryKingId > 0 && country.countryId > 0)
                {
                    General general = GeneralListCache.GetGeneral(country.countryKingId);  // ��ȡ��������
                    if (general != null)
                    {
                        short curKingPhase = general.phase;  // ��ȡ����������
                        int curd = GetdPhase(curKingPhase, (GeneralListCache.GetGeneral(GenId)).phase);  // ���㵱ǰ������Ŀ�꽫������Բ�ֵ
                        if (mincountryId == 0 || curd < min)
                        {
                            min = (short)curd;
                            mincountryId = country.countryId;  // ������С���Թ���ID
                        }
                    }
                }
            }
            if (mincountryId == 0)
                Console.Error.WriteLine("��ȡ��С���Ծ���ʧ�ܣ�");
            return mincountryId;
        }

        /// <summary>
        /// ��齫���Ƿ�Ϊĳ�������������Խ���
        /// </summary>
        /// <param name="genId"></param>
        /// <returns></returns>
        bool GenIsExclusive(short genId)
        {
            byte countrySize = CountryListCache.getCountrySize();  // ��ȡ�����б��С
            for (byte i = 1; i < countrySize; i = (byte)(i + 1))
            {
                Country country = CountryListCache.getCountryByIndexId(i);  // ��ȡ���Ҷ���
                if (country.countryKingId > 0 && country.countryId > 0 &&
                    (GeneralListCache.GetGeneral(country.countryKingId)).phase == (GeneralListCache.GetGeneral(genId)).phase)
                {
                    return true;  // ����ý�����ĳ�����ҵĹ�������������ͬ����Ϊ�����Խ���
                }
            }
            return false;
        }

        /// <summary>
        /// ������λ��������Բ�ֵ
        /// </summary>
        /// <param name="ph1"></param>
        /// <param name="ph2"></param>
        /// <returns></returns>
        int GetdPhase(short ph1, short ph2)
        {
            int total = Math.Abs(ph1 - ph2);  // ������Բ�ֵ
            if (total >= 75)
                total = 150 - total;  // ����75��ȡ���������Բ�ֵ
            return total;
        }

        /// <summary>
        /// �ж��Ƿ�ɹ����û���������
        /// </summary>
        /// <param name="curCity"></param>
        /// <param name="employGeneralId"></param>
        /// <param name="generalId"></param>
        /// <returns></returns>
        bool isEmploy(byte curCity, short employGeneralId, short generalId)
        {
            int i = MathUtils.getRandomInt(100);  // ������ж�
            if (i > 50)
                return false;  // ���������50��ʧ��

            if (AiEmploy(employGeneralId, generalId))  // ��������
            {
                GeneralListCache.addMoralExp(employGeneralId, (byte)10);  // ���ӵ��¾���
                City city = CityListCache.GetCityByCityId(curCity);  // ��ȡ��ǰ����
                city.AddOfficeGeneralId(generalId);  // ���������Ľ��������е�ְ������
                city.RemoveOppositionGeneralId(generalId);  // ���ý���ӷ��Խ����б����Ƴ�
                return true;  // �����ɹ�
            }
            return false;  // ����ʧ��
        }

        /// <summary>
        /// �������죬�����������
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="notFoundGeneralIdNum"></param>
        /// <returns></returns>
        byte Search(short generalId, byte notFoundGeneralIdNum)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // ��ȡ������Ϣ
            byte iq = general.IQ;  // ��ȡ��������
            byte moral = general.moral;  // ��ȡ�������
            int i1 = MathUtils.getRandomInt(100);  // ������ж�
            bool isyl = false;

            // �������߱������������޸������ɹ���
            if (GetSkill_4(generalId, 4))
            {
                i1 = 120;
                isyl = true;
            }

            // ����δ�ҵ���������������ֵ���������ɹ���
            if (notFoundGeneralIdNum >= 1 && moral >= 70)
            {
                i1 = 60;
            }
            else if (notFoundGeneralIdNum >= 1 && CommonUtils.getRandomInt() % 3 > 0)
            {
                i1 = 60;
            }

            // ���������������ɹ����ж�����ʧ��
            if (i1 > iq && !isyl && notFoundGeneralIdNum == 0)
                return 0;

            int i2 = 0;

            // ���������ɹ����ж����
            if (i1 > 79)
            {
                if (GetSkill_4(generalId, 4))//���ӵ�м�������
                {
                    int trand = MathUtils.getRandomInt(10);  // ��һ������ж�
                    if (notFoundGeneralIdNum > 0)
                    {
                        i2 = 3;
                    }
                    else if (trand > 5)
                    {
                        i2 = 2;
                    }
                    else if (trand > 1)
                    {
                        i2 = 1;
                    }
                    else
                    {
                        i2 = 4;
                    }
                }
                else if (notFoundGeneralIdNum > 0)
                {
                    i2 = 3;
                }
                else
                {
                    int j1 = MathUtils.getRandomInt(100);  // ��һ������ж�
                    if (j1 < 5)
                    {
                        i2 = 4;
                    }
                    else if (j1 < 55)
                    {
                        i2 = 2;
                    }
                    else if (j1 < 95)
                    {
                        i2 = 1;
                    }
                }
            }
            else if (i1 > 59 && notFoundGeneralIdNum != 0)
            {
                i2 = 3;
            }
            else
            {
                int j1 = MathUtils.getRandomInt(100);  // ��һ������ж�
                if (j1 < 5)
                {
                    i2 = 4;
                }
                else if (j1 < 45)
                {
                    i2 = 2;
                }
                else if (j1 < 85)
                {
                    i2 = 1;
                }
            }

            return (byte)i2;  // �����������
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="curCity"></param>
        /// <param name="generalId"></param>
        void SearchOrder(byte curCity, short generalId)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // ��ȡָ������
            general.decreaseCurPhysical((byte)2);  // ���ٽ��쵱ǰ����
            City city = CityListCache.GetCityByCityId(curCity);  // ��ȡָ������
            byte kind = Search(generalId, city.getCityNotFoundGeneralNum());  // �������첢��ȡ�������
            this.b_int_fld = kind;  // �洢�������

            // ���ݽ�����������¼�ID
            if (this.b_int_fld == 1 || this.b_int_fld == 2)
            {
                this.eventId = CommonUtils.getRandomInt() % 30 + (general.IQ + general.moral * 3) / 5;
                if (GetSkill_4(generalId, 4))
                    this.eventId += this.eventId / 2;  // ����м������������¼�ID����һ��
            }
            else if (this.b_int_fld == 3)
            {
                this.eventId = CommonUtils.getRandomInt() % city.getCityNotFoundGeneralNum();  // ����¼�ID
            }
            else if (this.b_int_fld == 4)
            {
                this.eventId = 1;  // �̶��¼�ID
            }

            // ���ݽ�����ͶԳ��н��в���
            if (this.b_int_fld == 1)
            {
                city.AddFood((short)this.eventId);  // ���ӳ��е���ʳ
            }
            else if (this.b_int_fld == 2)
            {
                city.AddMoney((short)this.eventId);  // ���ӳ��е��ʽ�
            }
            else if (this.b_int_fld == 3)
            {
                short beGeneralId = city.getNotFoundGeneralId((byte)this.eventId);  // ��ȡδ�ҵ��Ľ���ID
                if (beGeneralId <= 0)
                    return;  // ���δ�ҵ�������ID��Ч�򷵻�
                city.removeNotFoundGeneralId(beGeneralId);  // �Ƴ�δ�ҵ��Ľ���ID
                city.AddOppositionGeneralId(beGeneralId);  // ��ӵ���������ID
            }
            else if (this.b_int_fld == 4)
            {
                city.treasureNum = (byte)(city.treasureNum + this.eventId);  // ���ӳ��еı�������
                if (city.treasureNum > 99)
                    city.treasureNum = 99;  // ���������������99������Ϊ99
            }
        }

        /// <summary>
        /// �����ҵ�����������ߵĽ���
        /// </summary>
        /// <param name="byte0"></param>
        /// <returns></returns>
        short GetMostPoliticalGeneral(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);  // ��ȡָ������
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();  // ��ȡ����ְ����ID����
            short[] aword0 = new short[city.getCityGeneralNum()];  // �洢���������ߵĽ���ID
            byte byte1 = 0;  // ���������ߵĽ�������
            int i1 = 0;  // �����������
            for (byte byte2 = 0; byte2 < city.getCityGeneralNum(); byte2 = (byte)(byte2 + 1))
            {
                short generalId = officeGeneralIdArray[byte2];  // ��ȡ����ID
                if (i1 < (GeneralListCache.GetGeneral(generalId)).political)
                {
                    this.HMGeneralId = generalId;  // ��������������ߵĽ���ID
                    i1 = (GeneralListCache.GetGeneral(this.HMGeneralId)).political;
                }
                    if ((GeneralListCache.GetGeneral(generalId)).political >= 70)
                    {
                        byte1 = (byte)(byte1 + 1);  // ������������70�Ľ�����������
                        aword0[byte1] = generalId;  // �洢�ý���ID
                    }
            }
                if (byte1 == 0)
                return this.HMGeneralId;  // ���û�����������ߵĽ��죬��������������ߵĽ���ID
        return aword0[CommonUtils.getRandomInt() % byte1];  // �����������ߵĽ��������ѡ��һ��
    }

        /// <summary>
        /// ����������Ҫ�Ľ�Ǯ
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        int GetNeedMoneyOfInterior(short generalId, byte type)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // ��ȡ������Ϣ
            byte byte0 = 0;  // ���ڴ洢������
            switch (type)
            {
                case 1:
                    byte0 = (byte)((general.force + general.political) / 2);  // �������������ε�ƽ��ֵ
                    break;
                case 2:
                    byte0 = (byte)((general.IQ + general.political) / 2);  // �������������ε�ƽ��ֵ
                    break;
                case 3:
                    byte0 = (byte)((general.lead + general.political) / 2);  // �����쵼�������ε�ƽ��ֵ
                    break;
                case 4:
                    byte0 = (byte)((general.moral + general.political) / 2);  // ������������ε�ƽ��ֵ
                    break;
            }
            int needMoney = 10;  // ������Ǯ����
            needMoney += byte0 / 10;  // ���ݼ��������ӽ�Ǯ����
            needMoney += 2 * (CommonUtils.getRandomInt() % 5 + 1);  // �������ֵ
            return needMoney;
        }

        /// <summary>
        /// ������������ֵ
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int ReclaimValue(short generalId, int useMoney)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // ��ȡ������Ϣ
            byte byte0 = (byte)((general.force + general.political * 2) / 3);  // ��������������������ֵ
            general.decreaseCurPhysical((byte)2);  // ���ٽ��쵱ǰ����
            general.addexperience(MathUtils.getRandomInt(50) + 1);  // ���ӽ��쾭��
            general.addPoliticalExp((byte)1);  // ���ӽ������ξ���
            int val = 0;  // ���ڴ洢������
            if (byte0 < 12)
            {
                val = 1;  // ���������С��12������ֵΪ1
            }
            else
            {
                int k1 = byte0 * useMoney / 100;  // ����ʹ�ý�Ǯ����ֵ
                int j1 = k1 / 2;
                val = j1 + MathUtils.getRandomInt(j1 + 1) / 2;  // �������ֵ
                if (GetSkill_4(generalId, 0))
                {
                    val += val / 4;  // ����м������������Ӽ���ֵ
                }
                else if (GetSkill_4(generalId, 2))
                {
                    val += val / 3;  // ����м���������Ӽ���ֵ
                }
            }
            return val;
        }

        /// <summary>
        /// ����Ȱ������ֵ
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int MercantileValue(short generalId, int useMoney)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // ��ȡ������Ϣ
            byte byte0 = (byte)((general.IQ + general.political * 2) / 3);  // ����Ȱ����������ֵ
            general.decreaseCurPhysical((byte)2);  // ���ٽ��쵱ǰ����
            general.addexperience(MathUtils.getRandomInt(50) + 1);  // ���ӽ��쾭��
            general.addPoliticalExp((byte)1);  // ���ӽ������ξ���
            int val = 0;  // ���ڴ洢������
            if (byte0 < 12)
            {
                val = 1;  // ���������С��12����ʾֵΪ1
            }
            else
            {
                int k1 = byte0 * useMoney / 100;  // ����ʹ�ý�Ǯ����ֵ
                int j1 = k1 / 2;
                val = j1 + MathUtils.getRandomInt(j1 + 1) / 2;  // �������ֵ
                if (GetSkill_4(generalId, 0))
                {
                    val += val / 4;  // ����м������������Ӽ���ֵ
                }
                else if (GetSkill_4(generalId, 3))
                {
                    val += val / 3;  // ����м����̲ţ����Ӽ���ֵ
                }
            }
            return val;
        }

        /// <summary>
        /// ������ˮ����ֵ
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int TameValue(short generalId, int useMoney)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // ��ȡ������Ϣ
            byte byte0 = (byte)((general.lead + general.political * 2) / 4);  // ����������ˮ��������ֵ
            general.decreaseCurPhysical((byte)2);  // ���ٽ��쵱ǰ����
            general.addexperience(MathUtils.getRandomInt(50) + 1);  // ���ӽ��쾭��
            general.addPoliticalExp((byte)1);  // ���ӽ������ξ���
            int val = 0;  // ���ڴ洢������
            if (byte0 < 10)
            {
                val = 1;  // ���������С��10����ʾֵΪ1
            }
            else
            {
                int k1 = byte0 * useMoney / 100;  // ����ʹ�ý�Ǯ����ֵ
                int j1 = k1 / 2;
                val = j1 + MathUtils.getRandomInt(j1 + 1) / 3;  // �������ֵ
                if (GetSkill_4(generalId, 0))
                    val += val / 4;  // ����м������������Ӽ���ֵ
            }
            return val;
        }

        /// <summary>
        /// ����Ѳ������ֵ
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int PatrolValue(short generalId, int useMoney)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // ��ȡ������Ϣ
            byte byte0 = (byte)((general.IQ + general.moral * 2 + general.political * 2) / 5);  // ��������Ѳ�������ֵ
            general.decreaseCurPhysical((byte)2);  // ���ٽ��쵱ǰ����
            general.addexperience(MathUtils.getRandomInt(50) + 1);  // ���ӽ��쾭��
            general.addPoliticalExp((byte)1);  // ���ӽ������ξ���
            general.addMoralExp((byte)1);  // ���ӽ�����¾���
            int val = 0;  // ���ڴ洢������
            if (byte0 < 50)
            {
                val = 500;  // ��׼ֵС��50ʱ������ֵ�̶�Ϊ500
            }
            else
            {
                val = byte0 * useMoney;  // ���ݻ�׼ֵ��ʹ�ý�Ǯ��������ֵ
                if (GetSkill_4(generalId, 0))
                {
                    val += val / 4;  // ����м�����������������ֵ
                }
                else if (GetSkill_4(generalId, 1))
                {
                    val += val / 3;  // ����м�����������������ֵ
                }
            }
            return val;
        }

        /// <summary>
        /// AI�������Ѳ����
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        void AiReclaimOrder(byte byte0, short word0)
        {
            int needMoney = GetNeedMoneyOfInterior(word0, (byte)1);  // ��ȡ����������Ҫ�Ľ�Ǯ
            Reclaim1(byte0, word0, needMoney);  // ִ����ز���
        }

        /// <summary>
        /// AI����Ȱ�̲���
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        void AiMercantileOrder(byte byte0, short word0)
        {
            int needMoney = GetNeedMoneyOfInterior(word0, (byte)2);  // ��ȡ����Ȱ����Ҫ�Ľ�Ǯ
            Mercantile1(byte0, word0, needMoney);  // ִ����ز���
        }

        /// <summary>
        /// Ai����Ѳ�����
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        void AiPatrolOrder(byte byte0, short word0)
        {
            int needMoney = GetNeedMoneyOfInterior(word0, (byte)4);  // ��ȡ����Ѳ����Ҫ�Ľ�Ǯ
            Patrol1(byte0, word0, needMoney);  // ִ����ز���
        }

        /// <summary>
        /// AI������ˮ����
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        void AiTameOrder(byte byte0, short word0)
        {
            int needMoney = GetNeedMoneyOfInterior(word0, (byte)3);  // ��ȡ������ˮ��Ҫ�Ľ�Ǯ
            Tame1(byte0, word0, needMoney);  // ִ����ز���
        }

        /// <summary>
        /// AI��������ѡ������
        /// </summary>
        /// <param name="byte0"></param>
        void AiInteriorChooseOrder(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);  // ��ȡָ������
            if (city.floodControl < 99)
            {
                AiTameOrder(byte0, this.HMGeneralId);  // ����������С��99��ִ��������ļ����
                return;
            }
            if (CommonUtils.getRandomInt() % 2 > 0)
            {
                if (city.agro < 999 && city.trade < 999)
                {
                    if (GameInfo.month < 4 || GameInfo.month >= 10)
                    {
                        AiReclaimOrder(byte0, this.HMGeneralId);  // ����·�С��4����ڵ���10��ִ������Ѳ�����
                    }
                    else
                    {
                        AiMercantileOrder(byte0, this.HMGeneralId);  // ����ִ��������������
                    }
                    return;
                }
                if (city.agro < 999)
                {
                    AiReclaimOrder(byte0, this.HMGeneralId);  // ���ũҵС��999��ִ������Ѳ�����
                    return;
                }
                if (city.trade < 999)
                {
                    AiMercantileOrder(byte0, this.HMGeneralId);  // ���ó��С��999��ִ��������������
                    return;
                }
            }
            if (city.population < 990000)
            {
                AiPatrolOrder(byte0, this.HMGeneralId);  // ����˿�С��990000��ִ��������Ʋ���
                return;
            }
            AiTameOrder(byte0, this.HMGeneralId);  // Ĭ��ִ��������ļ����
        }

    /// <summary>
    /// AIִ���������������ý���
    /// </summary>
    /// <param name="byte0"></param>
    void AiInteriorChooseGeneralId(byte byte0)
        {
            this.HMGeneralId = GetMostPoliticalGeneral(byte0);  // ��ȡ������ߵĽ���ID
            AiInteriorChooseOrder(byte0);  // ִ����������
        }

        // �ҷ��Ƿ��н�AI���죿
        bool IsSummonToSurrender(short word0, short word1)
        {
            if (GeneralListCache.GetGeneral(word1).getLoyalty() > 99)
                return false;  // ��������ҳ϶ȴ���99��������

            int i1 = ((GeneralListCache.GetGeneral(word0)).moral * 7 + (GeneralListCache.GetGeneral(word0)).IQ * 3) * 10 / 99;  // ���㽱��ֵ
            i1 = (i1 - 70) / 5;  // ��������ֵ
            if (i1 == 4)
            {
                i1 = 6;  // ����ֵΪ6
            }
            else if (i1 == 5)
            {
                i1 = 8;  // ����ֵΪ8
            }
            i1 = GeneralListCache.GetGeneral(word1).getCurPhysical() + GeneralListCache.GetGeneral(word1).getLoyalty() - i1 + CommonUtils.getRandomInt() % 4;  // ��������ֵ
            return (i1 < 100);  // �������ֵС��100���򷵻�true
        }

        /// <summary>
        /// AI�Ƿ��н��ҷ����죿
        /// </summary>
        /// <param name="word0"></param>
        /// <param name="word1"></param>
        /// <returns></returns>
        bool IsSummonToSurrenderEasy(short word0, short word1)
        {
            if (GeneralListCache.GetGeneral(word1).getLoyalty() > 99)
                return false;  // ��������ҳ϶ȴ���99��������

            int i1 = ((GeneralListCache.GetGeneral(word0)).moral * 7 + (GeneralListCache.GetGeneral(word0)).IQ * 3) * 10 / 99;  // ���㽱��ֵ
            i1 = (i1 - 70) / 5;  // ��������ֵ
            if (i1 == 4)
            {
                i1 = 6;  // ����ֵΪ6
            }
            else if (i1 == 5)
            {
                i1 = 8;  // ����ֵΪ8
            }
            i1 = GeneralListCache.GetGeneral(word1).getCurPhysical() + GeneralListCache.GetGeneral(word1).getLoyalty() - i1 + CommonUtils.getRandomInt() % 4;  // ��������ֵ
            return (i1 < 110);  // �������ֵС��110���򷵻�true
        }

        /// <summary>
        /// ������ڽ�������ֵ��ĳ�ֹ�������Ч��
        /// </summary>
        /// <param name="word0"></param>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        int GeneralAtkValue(short word0, short word1, short word2)
        {
            int i1 = (GeneralListCache.GetGeneral(word0)).force;  // ��ȡ��������ֵ
            i1 *= word1;  // ���Բ���word1
            i1 /= word2;  // ���Բ���word2
            if (i1 > 2 * (GeneralListCache.GetGeneral(word0)).force)
                i1 = 2 * (GeneralListCache.GetGeneral(word0)).force;  // �������ֵ
            if (i1 < (GeneralListCache.GetGeneral(word0)).force / 3)
                i1 = (GeneralListCache.GetGeneral(word0)).force / 3;  // ������Сֵ
            i1 += i1 / 5;  // ����5%�ļ���ֵ
            return i1;
        }

        /// <summary>
        /// ���ȷ��������
        /// </summary>
        /// <param name="atkId"></param>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        byte getAtkDea(short atkId, short atk, short def)
        {
            byte dea = 1;  // ��ʼ��������
            dea = (byte)(GeneralAtkValue(atkId, atk, def) / 8);  // ���ݹ���������������
            if (dea < 0)
                dea = 100;  // ȷ����������С��0
            return dea;
        }

        /// <summary>
        /// ���ȫ������������
        /// </summary>
        /// <param name="atkId"></param>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        byte getAllAtkDea(short atkId, short atk, short def)
        {
            byte dea = 1;  // ��ʼ��������
            dea = (byte)(GeneralAtkValue(atkId, atk, def) / 2);  // ���ݹ���������������
            if (dea < 0)
                dea = 100;  // ȷ����������С��0
            return dea;
        }

        /// <summary>
        /// ���ι������
        /// </summary>
        /// <param name="atkGeneralId"></param>
        /// <param name="defGeneralId"></param>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        byte singlePin(short atkGeneralId, short defGeneralId, short atk, short def)
        {
            this.c_int_fld = 1;  // �����ڲ���־Ϊ1
            byte byte0 = (byte)(GeneralAtkValue(atkGeneralId, atk, def) / 20);  // ���㹥��Ч��
            if (byte0 > 0)
                return byte0;  // ���Ч������0������Ч��ֵ
            return 1;  // ���򷵻�1
        }

        /// <summary>
        /// ���ι���
        /// </summary>
        /// <param name="atkGeneralId"></param>
        /// <param name="defGeneralId"></param>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        byte singleAtk(short atkGeneralId, short defGeneralId, short atk, short def)
        {
            this.c_int_fld = 2;  // �����ڲ���־Ϊ2
            bool hmatk = false;  // ��־�Ƿ�Ϊ��Ҫ����
            byte hurt = 0;  // �˺�ֵ��ʼ��Ϊ0
            if (atkGeneralId == this.HMGeneralId)
                hmatk = true;  // �����������HMGeneral����Ϊ��Ҫ����
            if (getPercentage(atkGeneralId, defGeneralId, false, hmatk) > MathUtils.getRandomInt(100))
                hurt = getAtkDea(atkGeneralId, atk, def);  // ��������ʼ���ͨ���������˺�ֵ
            return hurt;  // �����˺�ֵ
        }

        /// <summary>
        /// Ⱥ�幥��
        /// </summary>
        /// <param name="atkGeneralId"></param>
        /// <param name="defGeneralId"></param>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        byte singleAllAtk(short atkGeneralId, short defGeneralId, short atk, short def)
        {
            this.X = 3;  // �����ڲ���־Ϊ3
            bool hmatk = false;  // ��־�Ƿ�Ϊ��Ҫ����
            byte hurt = 0;  // �˺�ֵ��ʼ��Ϊ0
            if (atkGeneralId == this.HMGeneralId)
                hmatk = true;  // �����������HMGeneral����Ϊ��Ҫ����
            if (getPercentage(atkGeneralId, defGeneralId, true, hmatk) > CommonUtils.getRandomInt() % 100)
            {
                hurt = getAllAtkDea(atkGeneralId, atk, def);  // ��������ʼ���ͨ��������Ⱥ���˺�
            }
            else
            {
                hurt = (byte)(this.random.Next() % 5 - 20);  // �����������˺�ֵ
            }
            return hurt;  // �����˺�ֵ
        }

        // ���ݱ�־�����ֵ
        short short_B_a(bool flag)
        {
            short word0 = 0;  // ��ʼ�����
            if (flag)
            {
                for (byte byte0 = 1; byte0 < 4; byte0++)
                    word0 = (short)(word0 + this.x_short_array1d_fld[byte0]);  // �ۼ�x_short_array1d_fld��ֵ
            }
            else
            {
                for (byte byte1 = 1; byte1 < 4; byte1++)
                    word0 = (short)(word0 + this.y_short_array1d_fld[byte1]);  // �ۼ�y_short_array1d_fld��ֵ
            }
            return word0;  // ���ؼ�����
        }


       /// <summary>
       /// ��������
       /// </summary>
        void aatkNum()
        {
            byte aNum = 0;  // ���ڵ�ʿ������
            byte longAtkNum = 0;  // �����빥������
            byte longAtkaNum = 0;  // ��һ�ֳ����빥������

            // ��������Сʿ��
            for (int index = 0; index < this.aiSmallSoldierNum; index++)
            {
                // �ж�ʿ���Ƿ���������Ϊ2������Ϊĳ��ʿ�����ͣ�
                if (this.smallSoldier_isSurvive[1][index] && this.smallSoldierKind[1][index] == 2)
                {
                    aNum = (byte)(aNum + 1);  // ���Ӵ��ڵ�ʿ������

                    // ����䳤���빥������
                    for (byte i = 1; i < 7;)
                    {
                        byte x = (byte)(this.smallSoldierCellX[1][index] - i);  // ��ȡʿ����X����
                        byte y = this.smallSoldierCellY[1][index];  // ��ȡʿ����Y����

                        // ����Ƿ񳬳���ͼ��Χ
                        if (x < 0)
                            break;

                        // ����Ƿ���Գ����빥��
                        if (this.smallWarCoordinate[y][x] == 64 && i >= 5)
                        {
                            longAtkNum = (byte)(longAtkNum + 1);
                        }
                        else
                        {
                            if (this.smallWarCoordinate[y][x] == 64)
                                break;
                            i = (byte)(i + 1);
                        }

                        // ���з�ʿ���Ƿ��ڹ�����Χ��
                        for (int hmindex = 1; hmindex < this.humanSmallSoldierNum; hmindex++)
                        {
                            if (this.smallSoldier_isSurvive[0][hmindex] && this.smallSoldierCellX[0][hmindex] == x && this.smallSoldierCellY[0][hmindex] == y && this.smallSoldierKind[0][hmindex] == 2)
                                longAtkaNum = (byte)(longAtkaNum + 1);
                        }
                        break;
                    }
                }
            }

            // ����W��ֵ������������
            if (this.W < 8)
            {
                if (aNum > 0 && longAtkNum >= aNum / 2 + 1)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
            }
            else
            {
                if (aNum > 1 && longAtkNum == aNum)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
                if (aNum > 1 && longAtkaNum >= aNum / 2 + 1)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
                if (aNum == 1 && longAtkNum >= aNum)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
            }
        }
        
        /// <summary>
        /// �ź�����������
        /// </summary>
        /// <returns></returns>
        byte NaHanAtk()
        {
            byte canAtkNum = 0;  // ���Թ�����ʿ������

            // �������ез�Сʿ��
            for (int index = 0; index < this.aiSmallSoldierNum; index++)
            {
                // �ж�ʿ���Ƿ���
                if (this.smallSoldier_isSurvive[1][index])
                {
                    byte x = this.smallSoldierCellX[1][index];  // ʿ����X����
                    byte y = this.smallSoldierCellY[1][index];  // ʿ����Y����

                    // �ж�ʿ�����Ͳ�����Ƿ���Թ���
                    if (this.smallSoldierKind[1][index] == 1)
                    {
                        if (x > 0 && this.smallWarCoordinate[y][x - 1] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y > 0 && this.smallWarCoordinate[y - 1][x] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y < 6 && this.smallWarCoordinate[y + 1][x] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (x > 1 && this.smallWarCoordinate[y][x - 2] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (x > 0 && y > 0 && this.smallWarCoordinate[y - 1][x - 1] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (x > 0 && y < 6 && this.smallWarCoordinate[y + 1][x - 1] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                    }
                    else if (this.smallSoldierKind[1][index] == 0 || this.smallSoldierKind[1][index] == 3)
                    {
                        if (x > 0 && this.smallWarCoordinate[y][x - 1] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y > 0 && this.smallWarCoordinate[y - 1][x] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y < 6 && this.smallWarCoordinate[y + 1][x] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                    }
                    else
                    {
                        // �����빥��
                        for (int d = 1; d < 5; d++)
                        {
                            if (x > d - 1)
                            {
                                byte hx = (byte)(this.smallSoldierCellX[1][index] - d);
                                byte hy = this.smallSoldierCellY[1][index];
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                            if (y > d - 1)
                            {
                                byte hx = this.smallSoldierCellX[1][index];
                                byte hy = (byte)(this.smallSoldierCellY[1][index] - d);
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                            if (y < 7 - d)
                            {
                                byte hx = this.smallSoldierCellX[1][index];
                                byte hy = (byte)(this.smallSoldierCellY[1][index] + d);
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return canAtkNum;
        }


        // aiʹ��ս������
        void aiUseZhanshu()
        {
            byte unitNum = 0;
            // �����Ҵ�С������
            for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
            {
                if (this.smallSoldier_isSurvive[1][i])
                    unitNum = (byte)(unitNum + 1);
            }

            // ��Wֵ���ڵ���8ʱ������ʹ��ս��
            if (this.W >= 8)
            {
                byte nahanNum = NaHanAtk();  // ��ȡ�ɹ�����λ����
                                                // ����ɹ��������㹻����С�������㹻ʱ������W��ִ��ս��
                if (nahanNum >= unitNum / 3 + 1 && unitNum >= 3)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }

                aatkNum();  // ����Զ�̹�������
                if (this.W >= 8 && nahanNum >= unitNum / 2 + 1 && unitNum >= 2)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }

                if (this.W >= 8 && nahanNum >= unitNum && unitNum >= 1)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }
            }
            else if (this.W >= 7)
            {
                aatkNum();  // ����Զ�̹�������
            }
        }

        /// <summary>
        /// ai�ж��ĸ�������
        /// </summary>
        void void_bv()
        {
            aiUseZhanshu();  // aiʹ��ս��
        }

        // ai���ض�������ִ���ж�
        void void_i_t(int i1)
        {
            // ��������ض�����������С���´�����Ϊ2
            if (boolean_f() && i1 >= 4)
            {
                for (byte byte0 = 0; byte0 < this.aiSmallSoldierNum; byte0 = (byte)(byte0 + 1))
                    this.smallSoldierOrder[1][byte0] = 2;
                return;
            }

            void_bv();  // ִ��ai�ж�
            for (byte byte1 = 0; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                this.smallSoldierOrder[1][byte1] = 1;  // С���´�����Ϊ1
        }

        // aiִ�и�������ж�
        void void_i_u(int i1)
        {
            // ��������ض�����������С���´�����Ϊ2
            if (boolean_f() && i1 >= 4)
            {
                for (byte byte0 = 0; byte0 < this.aiSmallSoldierNum; byte0 = (byte)(byte0 + 1))
                    this.smallSoldierOrder[1][byte0] = 2;
                return;
            }

            void_bv();  // ִ��ai�ж�
            this.smallSoldierOrder[1][0] = 1;  // ��һ��С���´�����Ϊ1
            for (byte byte1 = 1; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                this.smallSoldierOrder[1][byte1] = 0;  // ����С������Ϊ0
        }

        /// <summary>
        /// ����С�����
        /// </summary>
        void HumanSoldierDetection()
        {
            // ������������С��
            for (byte byte0 = 1; byte0 < this.humanSmallSoldierNum; byte0 = (byte)(byte0 + 1))
            {
                if (this.smallSoldier_isSurvive[0][byte0])
                {
                    byte x = this.smallSoldierCellX[0][byte0];
                    byte y = this.smallSoldierCellY[0][byte0];

                    // ���С���Ƿ���ָ�������ڣ�������Ӧ��aiС���Ƿ���Ա�����
                    for (byte byte1 = 1; byte1 < 5; byte1 = (byte)(byte1 + 1))
                    {
                        // ����Ϸ�
                        if (y >= byte1 && (this.smallWarCoordinate[y - byte1][x] & 0x80) != 0)
                        {
                            byte byte2 = 1;
                            while (byte2 < this.aiSmallSoldierNum)
                            {
                                if (this.smallSoldier_isSurvive[1][byte2] && this.smallSoldierCellX[1][byte2] == x && this.smallSoldierCellY[1][byte2] == y - byte1)
                                {
                                    // �����Ӧ��С������Զ�̹���С�������l_boolean_fldΪtrue
                                    if (this.smallSoldierKind[1][byte2] != 2)
                                    {
                                        this.l_boolean_fld = true;
                                        return;
                                    }
                                    break;
                                }
                                byte2 = (byte)(byte2 + 1);
                            }
                        }

                        // ����·�
                        if (y + byte1 <= 6 && (this.smallWarCoordinate[y + byte1][x] & 0x80) != 0)
                        {
                            byte byte3 = 1;
                            while (byte3 < this.aiSmallSoldierNum)
                            {
                                if (this.smallSoldier_isSurvive[1][byte3] && this.smallSoldierCellX[1][byte3] == x && this.smallSoldierCellY[1][byte3] == y + byte1)
                                {
                                    if (this.smallSoldierKind[1][byte3] != 2)
                                    {
                                        this.l_boolean_fld = true;
                                        return;
                                    }
                                    break;
                                }
                                byte3 = (byte)(byte3 + 1);
                            }
                        }

                        // ������
                        if (x >= byte1 && (this.smallWarCoordinate[y][x - byte1] & 0x80) != 0)
                        {
                            byte byte4 = 1;
                            while (byte4 < this.aiSmallSoldierNum)
                            {
                                if (this.smallSoldier_isSurvive[1][byte4] && this.smallSoldierCellX[1][byte4] == x - byte1 && this.smallSoldierCellY[1][byte4] == y)
                                {
                                    if (this.smallSoldierKind[1][byte4] != 2)
                                    {
                                        this.l_boolean_fld = true;
                                        return;
                                    }
                                    break;
                                }
                                byte4 = (byte)(byte4 + 1);
                            }
                        }

                        // ����Ҳ�
                        if (x + byte1 <= 15 && (this.smallWarCoordinate[y][x + byte1] & 0x80) != 0)
                        {
                            byte byte5 = 1;
                            while (byte5 < this.aiSmallSoldierNum)
                            {
                                if (this.smallSoldier_isSurvive[1][byte5] && this.smallSoldierCellX[1][byte5] == x + byte1 && this.smallSoldierCellY[1][byte5] == y)
                                {
                                    if (this.smallSoldierKind[1][byte5] != 2)
                                    {
                                        this.l_boolean_fld = true;
                                        return;
                                    }
                                    break;
                                }
                                byte5 = (byte)(byte5 + 1);
                            }
                        }
                    }
                }
            }
        }


        // ai��������ִ��ĳЩ����
        void void_i_v(int i1)
        {
            // ��������ض���������i1���ڵ���4������С���´�����Ϊ2
            if (boolean_f() && i1 >= 4)
            {
                for (byte byte0 = 0; byte0 < this.aiSmallSoldierNum; byte0 = (byte)(byte0 + 1))
                    this.smallSoldierOrder[1][byte0] = 2;
                return;
            }

            // ����������ȡ����������ֵ
            short word0 = short_B_a(true);
            short word1 = short_B_a(false);

            // ִ��ai�ж�
            void_bv();

            // ���l_boolean_fldΪfalse��ִ�������߼�
            if (!this.l_boolean_fld)
            {
                // ����С���´�����Ϊ1
                for (byte byte1 = 0; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                    this.smallSoldierOrder[1][byte1] = 1;

                // �Ƚ�word1��word0������l_boolean_fld
                if (word1 > word0)
                {
                    this.l_boolean_fld = true;
                }
                else
                {
                    HumanSoldierDetection(); // ִ������С�����
                }

                // ���l_boolean_fldΪtrue��������С����������Ϊ0
                if (this.l_boolean_fld)
                {
                    for (byte byte2 = 1; byte2 < this.aiSmallSoldierNum; byte2 = (byte)(byte2 + 1))
                        this.smallSoldierOrder[1][byte2] = 0;
                }
            }
        }

        // �Ƚ������佫�����������ض�Ӧ״̬
        byte byte_ss_c(short word0, short word1)
        {
            // ���word0�佫������С��20�����ֵ��������������4
            if (GeneralListCache.GetGeneral(word0).getCurPhysical() < 20 && CommonUtils.getRandomInt() % 2 == 0)
                return 4;

            // �������word1�佫������״̬����1��0
            return (byte)((GeneralListCache.GetGeneral(word1).getCurPhysical() >= (GeneralListCache.GetGeneral(word1)).maxPhysical / 2 || GeneralListCache.GetGeneral(word0).getCurPhysical() - GeneralListCache.GetGeneral(word1).getCurPhysical() <= 10) ? 1 : 0);
        }

        // ����i1��ִֵ�в�ͬ���߼�
        int int_i_d(int i1)
        {
            byte byte0;
            i1 /= 1000; // ��i1����1000

            // ����i1��ֵ����byte0
            switch (i1)
            {
                case 1:
                    byte0 = 20;
                    break;
                case 2:
                    byte0 = 50;
                    break;
                case 3:
                    byte0 = 70;
                    break;
                default:
                    byte0 = 80;
                    break;
            }

            // ������ֵ����byte0����X����Ϊ0
            if (CommonUtils.getRandomInt() % 100 > byte0)
                this.X = 0;

            return i1;
        }

        // ѡ���ҳ϶���ߵ��佫������Ϊ̫��
        void AiAppointPrefectByLoyalty(byte byte0, short[] aword0, byte byte1)
        {
            int i1 = 0;
            short word0 = aword0[0];

            // �������к�ѡ�佫��ѡ���ҳ϶���ߵ�
            for (byte byte2 = 1; byte2 < byte1; byte2 = (byte)(byte2 + 1))
            {
                if (GeneralListCache.GetGeneral(word0).getLoyalty() < GeneralListCache.GetGeneral(aword0[byte2]).getLoyalty())
                {
                    word0 = aword0[byte2];
                    i1 = byte2;
                }
            }

            // ���ҳ϶���ߵ��佫����Ϊ̫��
            CityListCache.GetCityByCityId(byte0).prefectId = word0;

            // ������ѡ�佫�б�
            for (byte byte3 = (byte)i1; byte3 > 0; byte3 = (byte)(byte3 - 1))
                aword0[byte3] = aword0[byte3 - 1];

            aword0[0] = word0;
        }

        // ����̫��
        void AiAppointPrefectInCity(byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            city.AppointmentPrefect(); // ����City����ķ���������̫��
        }

        // ���ݺ�ѡ�б����˳�򣬽������������佫������λ
        void SortOutSuitableGen(short[] aword0, byte byte0)
        {
            short word0 = aword0[0];
            byte byte1 = 0;
            int i1 = 0;

            // �������к�ѡ�佫
            for (byte byte2 = 0; byte2 < byte0; byte2 = (byte)(byte2 + 1))
            {
                // ����佫����Ŀ����еĹ��������������б���λ
                if (aword0[byte2] == CityListCache.GetCityByCityId(this.tarCity).cityBelongKing)
                {
                    word0 = aword0[0];
                    aword0[0] = aword0[byte2];
                    aword0[byte2] = word0;
                    return;
                }

                // ����ѡ��������ߵ��佫
                if (GeneralListCache.GetGeneral(aword0[byte2]).IQ > byte1)
                {
                    word0 = aword0[byte2];
                    i1 = byte2;
                    byte1 = GeneralListCache.GetGeneral(word0).IQ;
                }
            }

            // ��������ߵ��佫�����б���λ
            aword0[i1] = aword0[0];
            aword0[0] = word0;
        }

        // ������������֮���ʿ���뽫�����
        int DiffSoldierGenBetweenCity(byte byte0, byte byte1)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            int i1 = city.GetFood() / 4 * 1000 / 45;
            int j1;

            // ����ʿ������
            if (i1 >= city.GetCityAllSoldierNum())
            {
                j1 = city.GetCityAllSoldierNum() - CityListCache.GetCityByCityId(byte1).GetCityAllSoldierNum();
            }
            else
            {
                j1 = i1 - CityListCache.GetCityByCityId(byte1).GetCityAllSoldierNum();
            }

            // ���㽫�����
            j1 += (city.getCityGeneralNum() - CityListCache.GetCityByCityId(byte1).getCityGeneralNum()) * 200;
            return j1;
        }

        // ������������ӳ���֮������ʿ���ͽ������
        int TrappedUnitNum_b(byte byte0)
        {
            int i1 = -20000;

            // �������ӵĳ��У�������ʿ���ͽ���Ĳ���
            for (byte byte1 = 0; byte1 < CityListCache.GetCityByCityId(byte0).connectCityId.Length; byte1 = (byte)(byte1 + 1))
            {
                byte byte2 = (byte)CityListCache.GetCityByCityId(byte0).connectCityId[byte1];
                int j1 = CityListCache.GetCityByCityId(byte2).GetCityAllSoldierNum() + CityListCache.GetCityByCityId(byte2).getCityGeneralNum() * 200
                            - CityListCache.GetCityByCityId(byte0).GetCityAllSoldierNum() - CityListCache.GetCityByCityId(byte0).getCityGeneralNum() * 200;

                // ����i1Ϊ������ֵ
                if (i1 < j1)
                    i1 = j1;
            }

            return i1;
        }


        // ���ݳ���ID������ֵi1��Ѱ�����ӵĳ��У��������ų��еĽ������������
        int DiffSoldierGenBetweenConnectCityInCountry(byte byte0, int i1)
        {
            int j1 = 1;  // ��¼������
            int k1 = i1 - 1999;  // ���ڱȽϵĲ�ֵ
            for (byte byte1 = 0; byte1 < CityListCache.GetCityByCityId(byte0).connectCityId.Length; byte1 = (byte)(byte1 + 1))
            {
                byte byte2 = (byte)CityListCache.GetCityByCityId(byte0).connectCityId[byte1];

                // ����Ƿ�����ͬһ���������Ҹó��еĽ���������1
                if (CityListCache.GetCityByCityId(byte2).cityBelongKing == CityListCache.GetCityByCityId(byte0).cityBelongKing && CityListCache.GetCityByCityId(byte2).getCityGeneralNum() > 1)
                {
                    if (!cityIsEnemy(byte2))  // ����ó��в��ǵжԳ���
                    {
                        // ���µ�ǰ����Ϊ���������ĳ���
                        if (CityListCache.GetCityByCityId(byte2).getCityGeneralNum() > j1)
                        {
                            this.curCity = byte2;
                            j1 = CityListCache.GetCityByCityId(byte2).getCityGeneralNum();
                        }
                    }
                    // �����ǰ����ֻ��һ��������i1����0�����Ը��³���
                    else if (j1 == 1 && i1 > 0)
                    {
                        int l1 = TrappedUnitNum_b(byte2);  // ����ó��еı�����
                        if (l1 < k1)
                        {
                            this.curCity = byte2;
                            k1 = l1;
                        }
                    }
                }
            }

            // ����ж�����죬���ؽ�������1
            if (j1 > 1)
                return j1 - 1;

            // ���򣬷��ظ��ݲ�ֵ����Ľ��
            if (k1 < i1 - 1999)
            {
                int i2 = (i1 - k1) / 2;
                if (i2 > i1)
                    return i1;
                return i2;
            }
            return 0;
        }

        // ������������֮��ı������죬�����ݽ��������������ղ���
        int DiffSoldierGenByFightBetweenCity(byte thisCityId, byte byte1)
        {
            int i1 = 0;
            City city = CityListCache.GetCityByCityId(thisCityId);
            int l1 = city.getAlreadyAllSoldierNum() * 4 * 30 / 1000;  // ���㵱ǰ���еı���ֵ
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            City otherCity = CityListCache.GetCityByCityId(byte1);
            short[] officeGeneralIdArray2 = otherCity.getCityOfficeGeneralIdArray();

            // �����ǰ��������ĳ������������ó��еĽ�������
            if (city.cityBelongKing > 0)
                i1 = WholeGeneralFightValue(officeGeneralIdArray, city.getCityGeneralNum());

            // ������б������ڵ�ǰ�����������������ٱ���ֵ
            if (l1 > city.GetFood())
                i1 = i1 * city.GetFood() / l1;

            // ����Է���������ĳ������������Է����еĽ������������²���
            if (CityListCache.GetCityByCityId(byte1).cityBelongKing > 0)
            {
                int j1 = WholeGeneralFightValue(officeGeneralIdArray2, otherCity.getCityGeneralNum());
                int k1 = GeneralListCache.GetGeneral(otherCity.prefectId).lead * GeneralListCache.GetGeneral(otherCity.prefectId).generalSoldier * 3 / 2;
                k1 = DiffSoldierGen(GeneralListCache.GetGeneral(otherCity.prefectId).lead, k1);
                j1 += k1;
                i1 -= j1;
            }

            return i1;
        }

        // ����һ�����е��ܱ����������ݽ�����������
        int SoldierGenByFightInCity(byte byte0)
        {
            int i1 = 0;
            City city = CityListCache.GetCityByCityId(byte0);
            int l1 = city.getAlreadyAllSoldierNum() * 4 * 30 / 1000;  // ���㵱ǰ���еı���ֵ

            // �����������ĳ�����������㽫������
            if (city.cityBelongKing > 0)
                i1 = WholeGeneralFightValue(city.getCityOfficeGeneralIdArray(), city.getCityGeneralNum());

            // ������ݲ��㣬���������ٱ���ֵ
            if (l1 > city.GetFood())
                i1 = i1 * city.GetFood() / l1;

            return i1;
        }

        /// <summary>
        /// ����ĳ��������жԳ��е�������
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        byte connectNun(byte countryId)
        {
            byte num = 0;

            // �������ҵ����г���
            for (int byte1 = 0; byte1 < CountryListCache.GetCountryByCountryId(countryId).GetHaveCityNum(); byte1++)
            {
                byte curCity = CountryListCache.GetCountryByCountryId(countryId).getCity(byte1);

                // �����ǰ�����ǵжԳ��У����������ӵĵжԳ�����
                if (cityIsEnemy(curCity))
                {
                    for (byte i = 0; i < CityListCache.GetCityByCityId(curCity).connectCityId.Length; i = (byte)(i + 1))
                    {
                        byte curCity2 = (byte)CityListCache.GetCityByCityId(curCity).connectCityId[i];
                        if (CityListCache.GetCityByCityId(curCity2).cityBelongKing != CountryListCache.GetCountryByCountryId(countryId).countryKingId)
                            num = (byte)(num + 1);
                    }
                }
            }

            return num;
        }

        /// <summary>
        /// ����ĳ��������жԳ��е����������ų�ָ����Ŀ�����
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="removetar"></param>
        /// <returns></returns>
        byte connectNun2(byte countryId, byte removetar)
        {
            byte num = 0;

            // �������ҵ����г���
            for (int byte1 = 0; byte1 < CountryListCache.GetCountryByCountryId(countryId).GetHaveCityNum(); byte1++)
            {
                byte curCity = CountryListCache.GetCountryByCountryId(countryId).getCity(byte1);

                // �����ǰ�����ǵжԳ��У����������ӵĵжԳ��������ų�ָ����Ŀ�����
                if (cityIsEnemy(curCity))
                {
                    for (byte i = 0; i < CityListCache.GetCityByCityId(curCity).connectCityId.Length; i = (byte)(i + 1))
                    {
                        byte curCity2 = (byte)CityListCache.GetCityByCityId(curCity).connectCityId[i];
                        if (CityListCache.GetCityByCityId(curCity2).cityBelongKing != CountryListCache.GetCountryByCountryId(countryId).countryKingId && curCity2 != removetar)
                            num = (byte)(num + 1);
                    }
                }
            }

            return num;
        }


        /// <summary>
        /// ����ռ����в�ȼ���������Ŀ����е���������ֵ
        /// </summary>
        /// <param name="threat"></param>
        /// <param name="tar"></param>
        /// <returns></returns>
        int setOcupiceTheat2(int threat, byte tar)
        {
            byte sub = (byte)(connectNun(this.curTurnsCountryId) - connectNun2(this.curTurnsCountryId, tar));  // ������������ֵ
            switch (sub)
            {
                case 1:
                    threat += 40000;
                    break;
                case 2:
                    threat += 100000;
                    break;
                case 3:
                    threat += 200000;
                    break;
                case 4:
                    threat += 400000;
                    break;
            }
            return threat;
        }

        /// <summary>
        /// ��������Ƿ��б�ռ�����в
        /// </summary>
        /// <param name="tar"></param>
        /// <param name="toWarCity"></param>
        /// <returns></returns>
        int getifOcupiceTheat(byte tar, byte toWarCity)
        {
            int threat = 0;
            short[] connectionCityIdArray = CityListCache.GetCityByCityId(tar).connectCityId;  // ��ȡ���ӵĳ���ID����
            for (byte i = 0; i < connectionCityIdArray.Length; i = (byte)(i + 1))
            {
                short connectionCityId = connectionCityIdArray[i];
                if (connectionCityId != toWarCity && connectionCityId != tar)
                {
                    City connectionCity = CityListCache.GetCityByCityId((byte)connectionCityId);
                    if (connectionCity.cityBelongKing == CityListCache.GetCityByCityId(toWarCity).cityBelongKing)
                    {
                        threat += 60000;  // ������ӳ�����ս��Ŀ������ͬһ��������������в
                    }
                    else if (connectionCity.cityBelongKing == 0)
                    {
                        threat += 10000;  // ������ӳ������������У����ӽ�����в
                    }
                    else if (connectionCity.cityBelongKing > 0)
                    {
                        threat -= GetCityAtkPower((byte)connectionCityId) / 8;  // ������в���ڹ�����
                        for (byte j = 0; j < CityListCache.GetCityByCityId((byte)connectionCityId).connectCityId.Length; j = (byte)(j + 1))
                        {
                            byte curCity2 = (byte)CityListCache.GetCityByCityId((byte)connectionCityId).connectCityId[j];
                            if (curCity2 == toWarCity)
                                threat -= GetCityAtkPower(curCity2) / 8;  // ������ӳ�����ս�����У���һ��������в
                        }
                    }
                }
            }
            if (connectionCityIdArray.Length <= 1)
                threat += 30000;  // ���ֻ��һ�����ӳ��У�������в
            threat = setOcupiceTheat2(threat, tar);  // ����ռ����в�ȼ�
            return threat;
        }

        /// <summary>
        /// ����ճǵ���в�ȼ�
        /// </summary>
        /// <param name="city"></param>
        /// <param name="towarCity"></param>
        /// <returns></returns>
        int getEmetyCityThreat(byte city, byte towarCity)
        {
            int threat = 0;
            short[] connectionCityIdArray = CityListCache.GetCityByCityId(city).connectCityId;
            for (byte i = 0; i < connectionCityIdArray.Length; i = (byte)(i + 1))
            {
                short curCity = connectionCityIdArray[i];
                if (curCity != towarCity && curCity != city)
                {
                    City cCity = CityListCache.GetCityByCityId((byte)curCity);
                    if (cCity.cityBelongKing == CityListCache.GetCityByCityId(towarCity).cityBelongKing)
                    {
                        threat += 60000;  // ������ӳ�����ս��Ŀ�����ͬ��һ��������������в
                    }
                    else if (cCity.cityBelongKing == 0)
                    {
                        threat += 30000;  // ������ӳ������������У����ӽ�����в
                    }
                    else if (cCity.cityBelongKing > 0)
                    {
                        threat -= GetCityAtkPower((byte)curCity) / 10;  // ������в���ڹ�����
                    }
                }
            }
            if (CityListCache.GetCityByCityId(city).connectCityId.Length <= 1)
                threat += 100000;  // ���ֻ��һ�����ӳ��У�����������в
            return threat;
        }

        /// <summary>
        /// ����ĳ�����еķ�������
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        int getHmCityDefPower(byte cityId)
        {
            int power = 1;
            City city = CityListCache.GetCityByCityId(cityId);
            int needFood = city.getAllSoldierNum() / 8 + 1;  // ����������ʳ��
            for (byte index = 0; index < city.getCityGeneralNum(); index = (byte)(index + 1))
            {
                short generalId = city.getCityOfficeGeneralIdArray()[index];
                General general = GeneralListCache.GetGeneral(generalId);
                if (index == 0)
                {
                    if (general.generalSoldier < 800)
                    {
                        power += getsatrapGenPower(generalId) / 2;  // �������ʿ��������800�����ӽ��ٵ�����
                        continue;
                    }
                }
                power += getGenPower(generalId);  // ���ݽ�����������ӷ�������
                continue;
            }
            if (city.GetFood() < needFood)
                power = power * (city.GetFood() + 1) / needFood * 2;  // �����ʳ���㣬������������
            power -= power / 2;  // ����һ�����������Ϊ�ͷ�
            return power;
        }

        /// <summary>
        /// AI�ж��Ƿ񷢶�ս��
        /// </summary>
        /// <param name="curTurnsCountryId"></param>
        /// <param name="warNum"></param>
        /// <returns></returns>
        bool AIThinkWar(byte curTurnsCountryId, byte warNum)
        {
            Country country = CountryListCache.GetCountryByCountryId(curTurnsCountryId);
            int minMustPower = 0;
            bool result = false;
            for (int i = 0; i < country.GetHaveCityNum(); i++)
            {
                byte curCityId = country.getCity(i);
                City curUserCity = CityListCache.GetCityByCityId(curCityId);
                int gl = 100 * curUserCity.getAlreadyAllSoldierNum() / curUserCity.getAllSoldierNum();  // ����ʿ������
                int gl2 = MathUtils.getRandomInt(101);  // �����ȡһ����ֵ�����ж�
                if (gl2 <= gl)  // ���ݸ����ж��Ƿ񷢶�ս��
                {
                    int maxAtkPower = (int)(curUserCity.getMaxAtkPower() * (0.5D + 0.5D * warNum));  // ������󹥻���
                    int maxEnemyAtkPower = (int)(CountryListCache.GetEnemyAdjacentAtkPowerArray(curCityId) * 0.65D);  // ������˵���󹥻���
                    if (maxAtkPower > maxEnemyAtkPower)  // ����ҷ����������ڵз�
                    {
                        byte[] adjacentCity = CountryListCache.GetEnemyCityIdArray(curCityId);  // ��ȡ�з����ڳ���
                        for (int enemyIndex = 0; enemyIndex < adjacentCity.Length; enemyIndex++)
                        {
                            byte curEnemyCityId = adjacentCity[enemyIndex];
                            if (GameInfo.isWatch)  // �����ǰΪ�۲�ģʽ�����������������
                            {
                                City enemyCity = CityListCache.GetCityByCityId(curEnemyCityId);
                                if (enemyCity.cityBelongKing != 0 && CountryListCache.GetCountryByKingId(enemyCity.cityBelongKing).countryId == GameInfo.humanCountryId)
                                    continue;
                            }
                            int defenseAbility = CountryListCache.GetEnemyAdjacentCityDefenseAbility(curEnemyCityId, curCityId);  // ��ȡ�з���������
                            if (maxAtkPower - maxEnemyAtkPower > defenseAbility && minMustPower < maxAtkPower - maxEnemyAtkPower - defenseAbility)
                            {
                                minMustPower = maxAtkPower - maxEnemyAtkPower - defenseAbility;  // ������С���蹥����
                                result = true;
                                this.tarCity = curCityId;
                                this.curCity = curEnemyCityId;
                            }
                            continue;
                        }
                    }
                }
            }
            return result;  // �����Ƿ񷢶�ս�����жϽ��
        }


        /// <summary>
        /// ս��������ߺ���������ս�����������Ƿ����ʤ��
        /// </summary>
        /// <param name="warNum"></param>
        /// <returns></returns>
        bool warRand(byte warNum)
        {
            City cCity = CityListCache.GetCityByCityId(this.curCity); // ��ȡ��ǰ������Ϣ
            int defenseAbility = cCity.GetDefenseAbility(); // ��ȡ��������
            City tCity = CityListCache.GetCityByCityId(this.tarCity); // ��ȡĿ�������Ϣ
            int atkPower = tCity.getMaxAtkPower(); // ��ȡĿ����е���󹥻�����
            double warAbility = (5 * warNum + getWarAbility(atkPower, defenseAbility)); // ����ս������
            int random = MathUtils.getRandomInt(100); // ��ȡ0��100�������
            if (random <= warAbility) // ��������С�ڵ���ս��������ս��ʤ��
                return true;

            if (cCity.cityBelongKing == 0) // �������û�й����Ĺ��ң�ս��ʧ��
                return false;

            if ((CountryListCache.GetCountryByKingId(cCity.cityBelongKing)).countryId == GameInfo.humanCountryId) // �������������������ҹ���
            {
                random = MathUtils.getRandomInt(100); // �ٴλ�ȡ�����
                if (random <= warAbility)
                    return true; // ����������ȻС��ս��������ս��ʤ��
            }
            return false; // ����ս��ʧ��
        }

        /// <summary>
        /// ����ս������ֵ�����ݹ�������������ı��ʵó�ս������
        /// </summary>
        /// <param name="atkPower"></param>
        /// <param name="defenseAbility"></param>
        /// <returns></returns>
        private byte getWarAbility(int atkPower, int defenseAbility)
        {
            byte ability = 0;
            if (atkPower >= 2 * defenseAbility) // �������Ƿ�����������������
            {
                ability = 80;
            }
            else if (atkPower >= 1.67D * defenseAbility)
            {
                ability = 70;
            }
            else if (atkPower >= 1.33D * defenseAbility)
            {
                ability = 60;
            }
            else if (atkPower >= defenseAbility)
            {
                ability = 50;
            }
            else if (atkPower >= 0.84D * defenseAbility)
            {
                ability = 40;
            }
            else if (atkPower >= 0.68D * defenseAbility)
            {
                ability = 30;
            }
            else if (atkPower >= 0.52D * defenseAbility)
            {
                ability = 20;
            }
            else if (atkPower >= 0.36D * defenseAbility)
            {
                ability = 10;
            }
            return ability; // ����ս������ֵ
        }

        // ִ��ĳ���߼����Դ�����������зֶδ���
        int int_i_e(int i1)
        {
            byte byte0;
            i1 /= 300000; // ������ֵ��СΪ�ض���Χ
            switch (i1)
            {
                case 1:
                    byte0 = 50;
                    break;
                case 2:
                    byte0 = 80;
                    break;
                default:
                    byte0 = 90;
                    break;
            }
            // �������������趨����ֵ����X��Ϊ0
            if (CommonUtils.getRandomInt() % 100 > byte0)
                this.X = 0;
            return i1; // ���ش�����i1ֵ
        }

        /// <summary>
        /// �������е��佫��������������������Ϊ�����䡢�ǡ�ȫ
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="abyte0"></param>
        /// <param name="abyte1"></param>
        /// <param name="abyte2"></param>
        /// <returns></returns>
        byte[] GenDivideInto3Kind(byte cityId, byte[] abyte0, byte[] abyte1, byte[] abyte2)
        {
            byte[] abyte3 = new byte[3]; // �洢�����佫������
            City city = CityListCache.GetCityByCityId(cityId); // ��ȡ������Ϣ
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ�����е���ְ�佫ID�б�

            // ���������е��佫
            for (byte i = 0; i < city.getCityGeneralNum(); i++)
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[i]); // ��ȡ�佫��Ϣ
                if (general.generalSoldier >= 100) // ֻ��ʿ��������100���佫�Ų����ж�
                {
                    if (general.lead >= general.IQ && general.lead >= 80) // �佫�������������������Ҵ����������ڵ���80
                    {
                        abyte3[0] = (byte)(abyte3[0] + 1); // �������佫��������
                        abyte0[abyte3[0]] = i; // �洢���佫��ID
                    }
                    else if (general.IQ >= 80) // ����������ڵ���80
                    {
                        abyte3[1] = (byte)(abyte3[1] + 1); // ��ı���佫��������
                        abyte1[abyte3[1]] = i; // �洢���佫��ID
                    }
                    else // ��ͨ���佫
                    {
                        abyte3[2] = (byte)(abyte3[2] + 1); // ��ͨ���佫��������
                        abyte2[abyte3[2]] = i; // �洢���佫��ID
                    }
                }
            }

            // �Դ������佫���մ�����������
            for (byte i = 0; i < abyte3[0] - 1; i++)
            {
                General general1 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte0[i]]);
                for (int j = i + 1; j < abyte3[0]; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte0[j]]);
                    if (general1.generalSoldier < general2.generalSoldier && general1.lead < general2.lead)
                    {
                        byte temp = abyte0[i];
                        abyte0[i] = abyte0[j];
                        abyte0[j] = temp;
                    }
                }
            }

            // ����ı���佫������������
            for (byte i = 0; i < abyte3[1] - 1; i++)
            {
                General general1 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte1[i]]);
                for (int j = i + 1; j < abyte3[1]; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte1[j]]);
                    if (general1.generalSoldier < general2.generalSoldier && general1.IQ < general2.IQ)
                    {
                        byte temp = abyte1[i];
                        abyte1[i] = abyte1[j];
                        abyte1[j] = temp;
                    }
                }
            }

            // ����ͨ���佫���մ�������������֮������
            for (byte i = 0; i < abyte3[2] - 1; i++)
            {
                General general1 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte2[i]]);
                for (int j = i + 1; j < abyte3[2]; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte2[j]]);
                    if (general1.IQ + general1.lead < general2.IQ + general2.lead)
                    {
                        byte temp = abyte2[i];
                        abyte2[i] = abyte2[j];
                        abyte2[j] = temp;
                    }
                }
            }

            return abyte3; // ���������佫������
        }


        /// <summary>
        /// ��ȡ���������ߵ��佫ID����
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short[] getLeadGeneralIdArray(byte cityId)
        {
            short[] abyte0 = new short[0]; // �洢���������ߵ��佫ID����
            City city = CityListCache.GetCityByCityId(cityId); // ��ȡ������Ϣ
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ��������ְ�佫��ID����
            byte i;

            // ���������ڵ��佫
            for (i = 0; i < city.getCityGeneralNum(); i = (byte)(i + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[i]); // ��ȡ�佫��Ϣ
                                                                                        // �ų�����̫�أ���ɸѡ�������������������Ҵ����������ڵ���80���佫
                if (city.prefectId != general.generalId && general.generalSoldier >= 100 && general.lead >= general.IQ && general.lead >= 80)
                {
                    short[] tempAbyte0 = new short[abyte0.Length + 1]; // ��̬��չ�����С
                    for (int j = 0; j < abyte0.Length; j++)
                        tempAbyte0[j] = abyte0[j]; // ����ԭ��������
                    tempAbyte0[tempAbyte0.Length - 1] = general.generalId; // ��ӷ����������佫ID
                    abyte0 = tempAbyte0; // ��������
                }
            }

            // ���ݴ�����������
            for (i = 0; i < abyte0.Length - 1; i = (byte)(i + 1))
            {
                General general1 = GeneralListCache.GetGeneral(abyte0[i]);
                for (int j = i + 1; j < abyte0.Length; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(abyte0[j]);
                    if (general1.generalSoldier < general2.generalSoldier && general1.lead < general2.lead)
                    {
                        short temp = abyte0[i]; // ����˳��
                        abyte0[i] = abyte0[j];
                        abyte0[j] = temp;
                    }
                }
            }
            return abyte0; // �����������佫ID����
        }

        /// <summary>
        /// ��ȡ�����ߵ��佫ID����
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short[] getIQGeneralIdArray(byte cityId)
        {
            short[] abyte1 = new short[0]; // �洢�����ߵ��佫ID����
            City city = CityListCache.GetCityByCityId(cityId); // ��ȡ������Ϣ
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ��������ְ�佫��ID����
            byte i;

            // ���������ڵ��佫
            for (i = 0; i < city.getCityGeneralNum(); i = (byte)(i + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[i]); // ��ȡ�佫��Ϣ
                                                                                        // �ų�����̫�أ�ɸѡ���������ڴ����������������С��80���佫
                if (city.prefectId != general.generalId && general.generalSoldier >= 100 && (general.lead < general.IQ || general.lead < 80))
                    if (general.IQ >= 80)
                    {
                        short[] tempAbyte1 = new short[abyte1.Length + 1]; // ��̬��չ�����С
                        for (int j = 0; j < abyte1.Length; j++)
                            tempAbyte1[j] = abyte1[j]; // ����ԭ��������
                        tempAbyte1[tempAbyte1.Length - 1] = general.generalId; // ��ӷ����������佫ID
                        abyte1 = tempAbyte1; // ��������
                    }
            }

            // ������������
            for (i = 0; i < abyte1.Length - 1; i = (byte)(i + 1))
            {
                General general1 = GeneralListCache.GetGeneral(abyte1[i]);
                for (int j = i + 1; j < abyte1.Length; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(abyte1[j]);
                    if (general1.generalSoldier < general2.generalSoldier && general1.IQ < general2.IQ)
                    {
                        short temp = abyte1[i]; // ����˳��
                        abyte1[i] = abyte1[j];
                        abyte1[j] = temp;
                    }
                }
            }
            return abyte1; // �����������佫ID����
        }

        /// <summary>
        /// ��ȡ��ͨ�佫ID���飨�������������������ߣ�
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short[] getOrdinaryGeneralIdArray(byte cityId)
        {
            short[] abyte2 = new short[0]; // �洢��ͨ�佫ID����
            City city = CityListCache.GetCityByCityId(cityId); // ��ȡ������Ϣ
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ��������ְ�佫��ID����

            // ���������ڵ��佫
            for (byte i = 0; i < city.getCityGeneralNum(); i = (byte)(i + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[i]); // ��ȡ�佫��Ϣ
                                                                                        // �ų�����̫�أ�ɸѡ������С��80�Ҵ����������ߵ��佫
                if (city.prefectId != general.generalId && general.generalSoldier >= 100 && (general.lead < general.IQ || general.lead < 80))
                    if (general.IQ < 80)
                    {
                        short[] tempAbyte2 = new short[abyte2.Length + 1]; // ��̬��չ�����С
                        for (int j = 0; j < abyte2.Length; j++)
                            tempAbyte2[j] = abyte2[j]; // ����ԭ��������
                        tempAbyte2[tempAbyte2.Length - 1] = general.generalId; // ��ӷ����������佫ID
                        abyte2 = tempAbyte2; // ��������
                    }
            }

            // ���������ʹ��������ܺ�����
            for (byte i = 0; i < abyte2.Length - 1; i = (byte)(i + 1))
            {
                General general1 = GeneralListCache.GetGeneral(abyte2[i]);
                for (int j = i + 1; j < abyte2.Length; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(abyte2[j]);
                    if (general1.IQ + general1.lead < general2.IQ + general2.lead)
                    {
                        short temp = abyte2[i]; // ����˳��
                        abyte2[i] = abyte2[j];
                        abyte2[j] = temp;
                    }
                }
            }
            return abyte2; // ������������ͨ�佫ID����
        }

        /// <summary>
        /// ���㽫�������ֵ�������佫�������������������ȼ�����������
        /// </summary>
        /// <param name="generalId"></param>
        /// <returns></returns>
        int satrapVal(short generalId)
        {
            byte zl = GeneralListCache.GetGeneral(generalId).IQ; // ��ȡ�佫������ֵ
            byte ts = GeneralListCache.GetGeneral(generalId).lead; // ��ȡ�佫�Ĵ�������ֵ
            byte dj = GeneralListCache.GetGeneral(generalId).level; // ��ȡ�佫�ĵȼ�
            byte wl = GeneralListCache.GetGeneral(generalId).force; // ��ȡ�佫������ֵ
                                                                    // ����̫�ع���ֵ�������������������������ȼ��ļ�Ȩ����
            int gjl = (int)(ts * 1.42D + zl * 0.25D + wl * 0.33D + ((ts * 2 + wl + zl) * (dj - 1)) * 0.04D);
            return gjl; // ���ؼ����̫�ع���ֵ
        }


        /// <summary>
        /// Ai����̫��
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="generlIdArray"></param>
        /// <param name="generlNum"></param>
        void AiAppointmentPrefect(byte cityId, short[] generlIdArray, byte generlNum)
        {
            int i1 = 0;
            int maxWeight = 0;
            short prefectId = 0;

            // �������н��죬Ѱ������ʵ�̫��
            for (byte byte2 = 0; byte2 < generlNum; byte2 = (byte)(byte2 + 1))
            {
                short generlId = generlIdArray[byte2];

                // ����ý����ǹ����ģ�����ֱ������Ϊ̫��
                if (generlId == (CityListCache.GetCityByCityId(cityId)).cityBelongKing)
                {
                    maxWeight = 1000;
                    prefectId = generlId;
                    i1 = byte2;
                    break;
                }

                // ��������ҳ϶ȴ��ڵ���60��������̫��ֵ���ڵ�ǰ���ֵ������̫�غ�ѡ��
                if (GeneralListCache.GetGeneral(generlId).getLoyalty() >= 60 && satrapVal(generlId) > maxWeight)
                {
                    maxWeight = satrapVal(generlId);
                    prefectId = generlId;
                    i1 = byte2;
                }
            }

            // ���û�к��ʵ�̫�غ�ѡ�ˣ���ѡ���ҳ϶���ߵĽ���
            if (maxWeight == 0)
            {
                i1 = 0;
                prefectId = generlIdArray[0];
                for (byte byte3 = 1; byte3 < generlNum; byte3 = (byte)(byte3 + 1))
                {
                    if (GeneralListCache.GetGeneral(prefectId).getLoyalty() < GeneralListCache.GetGeneral(generlIdArray[byte3]).getLoyalty())
                    {
                        prefectId = generlIdArray[byte3];
                        i1 = byte3;
                    }
                }
            }

            // ���³��е�̫����Ϣ
            (CityListCache.GetCityByCityId(cityId)).prefectId = prefectId;

            // ��̫�ط����ڽ�������ĵ�һ��λ��
            for (byte byte4 = (byte)i1; byte4 > 0; byte4 = (byte)(byte4 - 1))
                generlIdArray[byte4] = generlIdArray[byte4 - 1];
            generlIdArray[0] = prefectId;

            // ����ʿ������̫��
            AiAssignSoldier(cityId);
        }

        /// <summary>
        /// ��ճ������н����ʿ������
        /// </summary>
        /// <param name="cityId"></param>
        void CleanAllGeneralSoldierInCity(byte cityId)
        {
            for (byte byte0 = 0; byte0 < CityListCache.GetCityByCityId(cityId).getCityGeneralNum(); byte0 = (byte)(byte0 + 1))
                (GeneralListCache.GetGeneral(CityListCache.GetCityByCityId(cityId).getCityOfficeGeneralIdArray()[byte0])).generalSoldier = 0;
        }

        /// <summary>
        /// Ai�Գ����еĽ��찴̫��ֵ����
        /// </summary>
        /// <param name="cityId"></param>
        void SortGeneralBySatrapVal(byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // �ӵ�һ�����쿪ʼ����̫��ֵ��������
            for (byte byte0 = 1; byte0 < city.getCityGeneralNum(); byte0 = (byte)(byte0 + 1))
            {
                int i = satrapVal(officeGeneralIdArray[byte0]);
                for (byte byte1 = byte0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
                {
                    int j = satrapVal(officeGeneralIdArray[byte1]);
                    if (j > i)
                    {
                        int max = officeGeneralIdArray[byte1];
                        officeGeneralIdArray[byte1] = officeGeneralIdArray[byte0];
                        officeGeneralIdArray[byte0] = (short)max;
                    }
                }
            }
        }

        /// <summary>
        /// Ai����ʿ��
        /// </summary>
        /// <param name="cityId"></param>
        void AiAssignSoldier(byte cityId)
        {
            SortGeneralBySatrapVal(cityId);
            CleanAllGeneralSoldierInCity(cityId);

            City city = CityListCache.GetCityByCityId(cityId);
            short cityAllSoldierNum = (short)city.GetCityAllSoldierNum();
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // Ϊ̫�ط���ʿ��
            short needSoldier = (short)(GeneralListCache.GetGeneral(city.prefectId).getMaxGeneralSoldier() - (GeneralListCache.GetGeneral(city.prefectId)).generalSoldier);
            if (needSoldier > 0)
            {
                if (needSoldier > cityAllSoldierNum)
                    needSoldier = cityAllSoldierNum;
                (GeneralListCache.GetGeneral(city.prefectId)).generalSoldier += needSoldier;
                cityAllSoldierNum -= needSoldier;
            }

            // Ϊ�����������ʿ��
            if (cityAllSoldierNum > 0)
            {
                for (byte byte2 = 1; byte2 < city.getCityGeneralNum(); byte2 = (byte)(byte2 + 1))
                {
                    short needSoldierForGeneral = (short)(GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]).getMaxGeneralSoldier() - (GeneralListCache.GetGeneral(officeGeneralIdArray[byte2])).generalSoldier);
                    if (needSoldierForGeneral > cityAllSoldierNum)
                        needSoldierForGeneral = cityAllSoldierNum;
                    (GeneralListCache.GetGeneral(officeGeneralIdArray[byte2])).generalSoldier += needSoldierForGeneral;
                    cityAllSoldierNum -= needSoldierForGeneral;
                }
            }
        }

        /// <summary>
        /// Ai����̫��ֵ���ҳ϶�ɸѡ����
        /// </summary>
        /// <param name="aword0"></param>
        /// <param name="generalNum"></param>
        void AiSortGeneralsBySatrapVal(short[] aword0, byte generalNum)
        {
            short firstGeneralId = aword0[0];
            int j1 = 0;

            // ��������������ڹ����ģ���������ڵ�һ��λ��
            for (byte byte2 = 0; byte2 < generalNum; byte2 = (byte)(byte2 + 1))
            {
                if (aword0[byte2] == (CityListCache.GetCityByCityId(this.tarCity)).cityBelongKing)
                {
                    aword0[0] = aword0[byte2];
                    aword0[byte2] = firstGeneralId;
                    return;
                }
            }

            // �ҳ�̫��ֵ���Ľ���
            int maxval = 0;
            for (byte b1 = 0; b1 < generalNum; b1 = (byte)(b1 + 1))
            {
                int curVal = ((GeneralListCache.GetGeneral(aword0[b1])).IQ * 2 + (GeneralListCache.GetGeneral(aword0[b1])).lead) / 3;
                if (curVal > maxval && (GeneralListCache.GetGeneral(aword0[b1])).generalSoldier >= 1000)
                {
                    firstGeneralId = aword0[b1];
                    maxval = curVal;
                    j1 = b1;
                }
            }

            // ���ҵ��Ľ�������ڵ�һ��λ��
            aword0[j1] = aword0[0];
            aword0[0] = firstGeneralId;
        }


        /// <summary>
        /// AIѡ�����ս��������ǲ�Ľ�������
        /// </summary>
        /// <param name="aword0"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        byte AISelectGenToWar(short[] aword0, int power)
        {
            // ��ȡĿ����к͵�ǰ���е�����
            City city = CityListCache.GetCityByCityId(this.tarCity);
            City cCity = CityListCache.GetCityByCityId(this.curCity);

            // ��ȡĿ������еĲ�ͬ���ͽ�������
            short[] IQGeneralIdArray = getIQGeneralIdArray(this.tarCity); // �����ͽ���
            short[] leadGeneralIdArray = getLeadGeneralIdArray(this.tarCity); // �쵼�ͽ���
            short[] ordinaryGeneralIdArray = getOrdinaryGeneralIdArray(this.tarCity); // ��ͨ����

            byte dispatchGeneralNum = 0; // ����ǲ�Ľ�������
            int totalPower = 0; // �ܱ���
            byte byte5 = 0; // ��ʱ��������
            short[] cityIdArray = (CityListCache.GetCityByCityId(this.curCity)).connectCityId; // ��ǰ���������ĳ���ID����

            // ��ǰ���в������κι���ʱ
            if (cCity.cityBelongKing == 0)
            {
                // �����Ƿ�����Ŀ����������ĳ���
                for (byte5 = 0; byte5 < cityIdArray.Length && (CityListCache.GetCityByCityId((byte)cityIdArray[byte5])).cityBelongKing == this.tarCity;)
                    byte5 = (byte)(byte5 + 1);

                // ��������������ж�����Ŀ�����
                if (byte5 == cityIdArray.Length)
                {
                    // ����ͨ�������顢��������������쵼����������ѡ�����һ������
                    if (ordinaryGeneralIdArray.Length > 0)
                    {
                        short generalId = ordinaryGeneralIdArray[ordinaryGeneralIdArray.Length - 1];
                        aword0[0] = generalId;
                    }
                    else if (IQGeneralIdArray.Length > 0)
                    {
                        aword0[0] = IQGeneralIdArray[IQGeneralIdArray.Length - 1];
                    }
                    else
                    {
                        aword0[0] = leadGeneralIdArray[leadGeneralIdArray.Length - 1];
                    }
                    city.removeOfficeGeneralId(aword0[0]); // �Ƴ������еĸý���
                    return 1; // ��������ǲ�Ľ�������1
                }
            }

            // ��ǰ��������ĳ������ʱ
            if (cCity.cityBelongKing > 0)
            {
                // ������еķ����������������������
                totalPower = cCity.GetDefenseAbility();
                totalPower += CommonUtils.getRandomInt() % (totalPower / 4 + 1);

                // �����ǰ����������ҵĹ��ң�˫������
                if (cCity.cityBelongKing == (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                    totalPower *= 2;
            }

            // �������ı���
            totalPower += power;

            // �����ܱ������δ��쵼�͡������͡���ͨ������������ǲ����
            for (byte leadIndex = 0; leadIndex < leadGeneralIdArray.Length && totalPower > 0; leadIndex = (byte)(leadIndex + 1))
            {
                short generalId = leadGeneralIdArray[leadIndex];
                aword0[dispatchGeneralNum] = generalId;
                city.removeOfficeGeneralId(generalId);
                int l1 = getGenPower(generalId); // ��ȡ�����ս����
                dispatchGeneralNum = (byte)(dispatchGeneralNum + 1);
                totalPower -= l1;
            }

            for (byte IQIndex = 0; IQIndex < IQGeneralIdArray.Length && totalPower > 0; IQIndex = (byte)(IQIndex + 1))
            {
                short generalId = IQGeneralIdArray[IQIndex];
                aword0[dispatchGeneralNum] = generalId;
                city.removeOfficeGeneralId(generalId);
                int l1 = getGenPower(generalId); // ��ȡ�����ս����
                dispatchGeneralNum = (byte)(dispatchGeneralNum + 1);
                totalPower -= l1;
            }

            for (byte i = 0; i < ordinaryGeneralIdArray.Length && totalPower > 0; i = (byte)(i + 1))
            {
                short generalId = ordinaryGeneralIdArray[i];
                aword0[dispatchGeneralNum] = generalId;
                city.removeOfficeGeneralId(generalId);
                int j2 = getGenPower(aword0[dispatchGeneralNum]); // ��ȡ�����ս����
                dispatchGeneralNum = (byte)(dispatchGeneralNum + 1);
                totalPower -= j2;
            }

            // ������������˳��
            AiSortGeneralsBySatrapVal(aword0, dispatchGeneralNum);

            // ������ǲ�Ľ�������
            return dispatchGeneralNum;
        }


        /// <summary>
        /// ����ѡ���߼���������ǲ�Ľ�������
        /// </summary>
        /// <param name="aword0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        byte AISelectGenTo2(short[] aword0, int i1)
        {
            // ��ȡĿ����к��������Ľ�����Ϣ
            City city = CityListCache.GetCityByCityId(this.tarCity);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ���е����й�ԱID
            byte generalNum = city.getCityGeneralNum(); // ��ȡ���еĽ�������

            // ����������ͬ���͵Ľ�������
            byte[] abyte0 = new byte[generalNum]; // ���ڴ洢�ض����͵Ľ���
            byte[] abyte1 = new byte[generalNum]; // ���ڴ洢��һ�����͵Ľ���
            byte[] abyte2 = new byte[generalNum]; // ���ڴ洢���������͵Ľ���

            // ��ʼ��һЩ���Ʊ���
            byte byte0 = 0;
            byte byte1 = 0;
            byte byte2 = 0;
            byte byte3 = 0;
            int j1 = 0;
            byte byte5 = 0;
            int k2 = 0;

            // ͨ�����÷�����ȡ����ķ������
            byte[] abyte3 = GenDivideInto3Kind(this.tarCity, abyte1, abyte0, abyte2);
            byte1 = abyte3[0];
            byte0 = abyte3[1];
            byte2 = abyte3[2];
            abyte3 = null;

            // ��ȡ��ǰ���е�����
            City cCity = CityListCache.GetCityByCityId(this.curCity);

            // ��ǰ�������������
            if (cCity.cityBelongKing == 0)
            {
                // ����Ƿ���Ŀ����������ĳ����Ƿ�Ҳ������
                for (byte5 = 0; byte5 < (CityListCache.GetCityByCityId(this.curCity)).connectCityId.Length &&
                    (CityListCache.GetCityByCityId((byte)(CityListCache.GetCityByCityId(this.curCity)).connectCityId[byte5])).cityBelongKing == this.tarCity;)
                {
                    byte5 = (byte)(byte5 + 1);
                }

                // ��������������ж�����
                if (byte5 == (CityListCache.GetCityByCityId(this.curCity)).connectCityId.Length)
                {
                    // �������ȼ�ѡ����
                    if (byte2 > 0)
                    {
                        short generalId = officeGeneralIdArray[abyte2[byte2 - 1]];
                        aword0[0] = generalId;
                    }
                    else if (byte0 > 0)
                    {
                        short generalId = officeGeneralIdArray[abyte0[byte0 - 1]];
                        aword0[0] = generalId;
                    }
                    else
                    {
                        short generalId = officeGeneralIdArray[abyte1[byte1 - 1]];
                        aword0[0] = generalId;
                    }
                    city.removeOfficeGeneralId(aword0[0]); // �Ƴ�ѡ��Ľ���
                    AiAppointPrefectInCity(this.tarCity); // ���³���״̬
                    return 1; // ��������ǲ�Ľ�������
                }
            }

            // ͳ��Ŀ��������������е��������
            int l2 = 0;
            for (byte5 = 0; byte5 < (CityListCache.GetCityByCityId(this.tarCity)).connectCityId.Length; byte5 = (byte)(byte5 + 1))
            {
                if ((CityListCache.GetCityByCityId((byte)(CityListCache.GetCityByCityId(this.tarCity)).connectCityId[byte5])).cityBelongKing != this.tarCity)
                {
                    l2++;
                }
            }

            // ���Ŀ�����ֻ��һ���������в�������
            if (l2 == 1)
            {
                byte byte4;
                if (byte2 > 0)
                {
                    byte4 = abyte2[byte2 - 1];
                }
                else if (byte0 > 0)
                {
                    byte4 = abyte0[byte0 - 1];
                }
                else
                {
                    byte4 = abyte1[byte1 - 1];
                }

                // ��ǲ��ѡ��Ľ���������н���
                for (byte5 = 0; byte5 < city.getCityGeneralNum(); byte5 = (byte)(byte5 + 1))
                {
                    if (byte5 != byte4)
                    {
                        short generalId = officeGeneralIdArray[byte5];
                        byte3 = (byte)(byte3 + 1);
                        aword0[byte3] = generalId;
                        city.removeOfficeGeneralId(generalId);
                    }
                }
                AiAppointPrefectInCity(this.tarCity); // ���³���״̬
                AiSortGeneralsBySatrapVal(aword0, byte3); // ���½�������
                return byte3; // ������ǲ�Ľ�������
            }

            // ��ǰ�������������
            if (cCity.cityBelongKing > 0)
            {
                // ��ȡ��ǰ���еı���ֵ
                j1 = WholeGeneralFightValue(cCity.getCityOfficeGeneralIdArray(), cCity.getCityGeneralNum());
                int k1 = (GeneralListCache.GetGeneral(cCity.prefectId)).lead * ((GeneralListCache.GetGeneral(cCity.prefectId)).generalSoldier + 1500) * 3 / 2;
                k1 = DiffSoldierGen((GeneralListCache.GetGeneral(cCity.prefectId)).lead, k1);
                j1 += k1;

                // �����ǰ����������ҵĹ���
                if (cCity.cityBelongKing == (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                {
                    j1 *= 2;
                }
                else
                {
                    j1 += 700000;
                }
            }

            j1 += i1; // ����������
            byte5 = 0;
            k2 = 0;

            // ѭ����ǲ���죬ֱ��������������н������ɳ�
            while (byte3 < city.getCityGeneralNum() - 1)
            {
                // ������ǲ��һ�����͵Ľ���
                if (byte5 < byte1)
                {
                    short generalId = officeGeneralIdArray[abyte1[byte5]];
                    aword0[byte3] = generalId;
                    city.removeOfficeGeneralId(generalId);
                    int l1 = SingleGeneralFightValue(aword0[byte3]); // ����ý����ս����
                    byte3 = (byte)(byte3 + 1);

                    // ���⴦���һ����ǲ
                    if (byte5 == 0)
                    {
                        byte5 = (byte)(byte5 + 2);
                    }
                    else
                    {
                        byte5 = (byte)(byte5 + 1);
                    }
                    j1 -= l1;

                    // ��������ľ����߽�������
                    if (j1 <= 0 || byte3 >= city.getCityGeneralNum() - 1)
                    {
                        AiAppointPrefectInCity(this.tarCity);
                        AiSortGeneralsBySatrapVal(aword0, byte3);
                        return byte3;
                    }
                }

                // �����ǲ�ڶ������͵Ľ���
                if (k2 < byte0)
                {
                    short generalId = officeGeneralIdArray[abyte0[k2]];
                    aword0[byte3] = generalId;
                    city.removeOfficeGeneralId(generalId);
                    int i2 = SingleGeneralFightValue(aword0[byte3]);
                    byte3 = (byte)(byte3 + 1);
                    if (k2 == 0)
                    {
                        k2 += 2;
                    }
                    else
                    {
                        k2++;
                    }
                    j1 -= i2;

                    if (j1 <= 0)
                    {
                        AiAppointPrefectInCity(this.tarCity);
                        AiSortGeneralsBySatrapVal(aword0, byte3);
                        return byte3;
                    }
                }

                if (byte5 >= byte1 && k2 >= byte0)
                {
                    break;
                }
            }

            // �����ǲ���������͵Ľ���
            for (byte byte6 = 0; byte3 < CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum() - 1 && byte6 < byte2;)
            {
                short generalId = officeGeneralIdArray[abyte2[byte6]];
                aword0[byte3] = generalId;
                city.removeOfficeGeneralId(generalId);
                int j2 = SingleGeneralFightValue(aword0[byte3]);
                byte3 = (byte)(byte3 + 1);
                byte6 = (byte)(byte6 + 1);
                j1 -= j2;

                if (j1 <= 0)
                {
                    AiAppointPrefectInCity(this.tarCity);
                    AiSortGeneralsBySatrapVal(aword0, byte3);
                    return byte3;
                }
            }

            // ���³���״̬��������ǲ�Ľ�������
            AiAppointPrefectInCity(this.tarCity);
            AiSortGeneralsBySatrapVal(aword0, byte3);
            return byte3;
        }


        /// <summary>
        /// �ж��Ƿ���Ҫ���������ز���ֵ��ʾ�Ƿ�����
        /// </summary>
        /// <param name="curTurnsCountryId"></param>
        /// <returns></returns>
        bool AiJudDraft(byte curTurnsCountryId)
        {
            this.tarCity = 0; // ��ʼ��Ŀ�����
            int minPower = -300000; // ���ó�ʼ����С������
            Country country = CountryListCache.GetCountryByCountryId(curTurnsCountryId); // ��ȡ��ǰ�ִι��Ҷ���
            byte[] adjacentCity = country.GetEnemyAdjacentCityIdArray(); // ��ȡ�ڽ��ĵз������б�

            // ����ÿһ���ڽ��ĵз�����
            for (byte index = 0; index < adjacentCity.Length; index = (byte)(index + 1))
            {
                byte curCity = adjacentCity[index];
                if (curCity != 0)
                {
                    City city = CityListCache.GetCityByCityId(curCity); // ��ȡ��ǰ���ж���
                    int needSoldierNum = city.getAllSoldierNum() - city.cityReserveSoldier; // ������Ҫ��ʿ������
                    if (needSoldierNum > 0 && city.GetMoney() >= 100) // ����Ҫʿ���ҳ����ʽ����100ʱ
                        for (int index2 = 0; index2 < (CityListCache.GetCityByCityId(curCity)).connectCityId.Length; index2++)
                        {
                            byte enemyCityId = (byte)(CityListCache.GetCityByCityId(curCity)).connectCityId[index2]; // ��ȡ���ӵĳ���ID
                                                                                                                // ����Ƿ����ӵĳ���Ϊ�з�����
                            if ((CityListCache.GetCityByCityId(enemyCityId)).cityBelongKing != (CityListCache.GetCityByCityId(curCity)).cityBelongKing)
                            {
                                int enemyCityAtkPower = GetCityAtkPower(enemyCityId); // ��ȡ�з����еĹ�����
                                int curCityDefPower = GetCityDefPower(curCity); // ��ȡ��ǰ���еķ�����
                                int gap = enemyCityAtkPower - curCityDefPower; // ���㹥����������
                                                                                // ������󹥻������Ŀ�����
                                if (gap > minPower)
                                {
                                    minPower = gap;
                                    this.tarCity = curCity;
                                }
                            }
                        }
                }
            }

            // ���û�з���������Ŀ����У����н�һ�����
            if (this.tarCity == 0)
            {
                int minNum = 0;
                for (int i = 0; i < adjacentCity.Length; i++)
                {
                    byte curCity = adjacentCity[i];
                    City city = CityListCache.GetCityByCityId(curCity);
                    int num = city.getAllSoldierNum() - city.cityReserveSoldier;
                    if (num > 0 && city.GetMoney() >= 600) // �������Ƿ����㹻��ʿ�����ʽ�
                        if (num > minNum)
                        {
                            minNum = num;
                            this.tarCity = curCity; // ����Ŀ�����Ϊʿ���������ĳ���
                        }
                }

                // �����û�з���������Ŀ����У�����Ѱ��
                if (this.tarCity == 0)
                {
                    int con2num = 0;
                    byte[] noAdjacentCity = country.GetNoEnemyAdjacentCityIdArray(); // ��ȡ�޵з����ڳ����б�
                    for (int j = 0; j < adjacentCity.Length; j++)
                    {
                        byte city0 = adjacentCity[j];
                        for (int k = 0; k < noAdjacentCity.Length; k++)
                        {
                            byte city1 = noAdjacentCity[k];
                            City city = CityListCache.GetCityByCityId(city1);
                            // ����Ƿ��������з�������
                            for (int m = 0; m < (CityListCache.GetCityByCityId(city1)).connectCityId.Length; m++)
                            {
                                byte city3 = (byte)(CityListCache.GetCityByCityId(city1)).connectCityId[m];
                                if (city3 == city0)
                                {
                                    int must = city.getAllSoldierNum() - city.cityReserveSoldier;
                                    if (must > 0 && city.GetMoney() >= 500)
                                    {
                                        if (must > con2num)
                                        {
                                            con2num = must;
                                            this.tarCity = city1; // ����Ŀ�����Ϊʿ�����ĳ���
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return (this.tarCity != 0); // �����Ƿ��ҵ���Ŀ�����
        }

        // ������еĹ�����
        int GetCityAtkPower(byte cityId)
        {
            int power = 1;
            City city = CityListCache.GetCityByCityId(cityId);
            int needFood = city.getAllSoldierNum() / 8 + 1; // ����������ʳ
                                                            // �������н��죬�����乥����
            for (byte index = 0; index < city.getCityGeneralNum(); index = (byte)(index + 1))
                power += getGenPower(city.getCityOfficeGeneralIdArray()[index]); // ��ȡÿ������Ĺ�����

            int mufood = city.GetFood() + 1;
            // �����ʳ�Ƿ��㣬���͹�����
            if (mufood < needFood && city.cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                power = power * mufood / needFood;

            // �������������ҹ��ң����ӹ�����
            if (city.cityBelongKing == (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                power = (int)(power * 1.75D);

            return power;
        }

        // ������еķ�����
        int GetCityDefPower(byte cityId)
        {
            int power = 1;
            City city = CityListCache.GetCityByCityId(cityId);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ���еĽ���ID����
            int needFood = city.getAllSoldierNum() / 8 + 1; // ����������ʳ

            // �������죬���������
            for (byte index = 0; index < city.getCityGeneralNum(); index = (byte)(index + 1))
            {
                if (officeGeneralIdArray[index] == city.prefectId) // �����̫�أ�ʹ���������������
                {
                    power += getsatrapGenPower(officeGeneralIdArray[index]);
                }
                else
                {
                    power += getGenPower(officeGeneralIdArray[index]); // ��ȡ��ͨ����ķ�����
                }
            }

            // �����ʳ�������������ٷ�����
            if (city.GetFood() < needFood)
                power = power * (city.GetFood() + 1) / needFood;

            // �������������ҹ��ң����ӷ�����
            if (city.cityBelongKing == (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                power = (int)(power * 1.2D);

            return power;
        }


        // ������ͨ�����ս����
        int getGenPower(short generalId)
        {
            int power = 1; // ��ʼ��ս����
            short gjl = (short)satrapVal(generalId); // ��ȡ��������ֵ
            long gjl_jq = (1 + gjl * gjl * gjl / 100000); // ���㽫��Ļ���ս��������

            General general = GeneralListCache.GetGeneral(generalId); // ��ȡ�������

            // ��������ʿ������100������ս����������0
            if (general.generalSoldier < 100)
            {
                gjl_jq = Math.Min(100L, gjl_jq);
                return 0;
            }

            // ���ս�����������20�����¼���
            if (gjl_jq < 20L)
                gjl_jq = Math.Max((general.generalSoldier / 150), gjl_jq);

            power = (int)(power + gjl_jq * (general.generalSoldier + 1)); // ������ս����
            return power;
        }

        // ����̫�ؽ����ս����
        int getsatrapGenPower(short id)
        {
            General general = GeneralListCache.GetGeneral(id); // ��ȡ�������
            int power = 1; // ��ʼ��ս����
            short gjl = (short)satrapVal(id); // ��ȡ��������ֵ

            // ̫�ؽ��������ֵ����30%
            gjl = (short)(int)(gjl * 1.3D);
            long gjl_jq = (1 + gjl * gjl * gjl / 100000); // �������ս��������

            // ���ʿ������500������ս����
            if (general.generalSoldier < 500)
                gjl_jq = Math.Min(150L, gjl_jq);

            // ���ս�����������20�����¼���
            if (gjl_jq < 20L)
                gjl_jq = Math.Max((general.generalSoldier / 150), gjl_jq);

            power = (int)(power + gjl_jq * (general.generalSoldier + 1)); // ������ս����
            return power;
        }

        // ���㽫����ƶ�ս����
        bool getMoveGenPower(byte curTurnsCountryId)
        {
            this.tarCity = 0; // ��ʼ��Ŀ�����
            this.curCity = 0; // ��ʼ����ǰ����
            int movePower = 0; // ��ʼ���ƶ�ս����
            bool result = false; // ��ʼ�������־

            // ��ȡ��ǰ�������ڵĵз�����ID����
            byte[] adjacentCity = CountryListCache.GetEnemyAdjacentCityIdArray(curTurnsCountryId);

            // �������ڵĵз�����
            for (int index = 0; index < adjacentCity.Length; index++)
            {
                byte cityId = adjacentCity[index];
                City city = CityListCache.GetCityByCityId(cityId); // ��ȡ���ж���

                // ����з����ڳ��еĹ������͵�ǰ���еķ�������
                int enemyAdjacentAtkPower = CountryListCache.GetEnemyAdjacentAtkPowerArray(cityId);
                int defenseAbility = city.GetDefenseAbility();

                // �����ǰ���ƶ�ս����С�ڹ�����ֵ�������ƶ�ս����������Ŀ�����
                if (movePower < enemyAdjacentAtkPower - defenseAbility)
                {
                    movePower = enemyAdjacentAtkPower - defenseAbility;
                    this.tarCity = cityId;
                    result = true;
                }
            }

            // ����ҵ����ʵ�Ŀ����У����н�һ������
            if (result)
            {
                City tCity = CityListCache.GetCityByCityId(this.tarCity); // ��ȡĿ����ж���
                int defenseAbility = tCity.GetDefenseAbility(); // ��ȡĿ����еķ�������
                int enemyAdjacentAtkPower = CountryListCache.GetEnemyAdjacentAtkPowerArray(this.tarCity); // ��ȡ���ڵз�������
                movePower = enemyAdjacentAtkPower - defenseAbility;

                Country country = CountryListCache.GetCountryByKingId(tCity.cityBelongKing); // ��ȡĿ�������������
                byte[] cityIds = CountryListCache.GetNoEnemyAdjacentCityIdArray(country.countryId); // ��ȡ�޵з����ڵĳ���ID����

                // �����޵з����ڵĳ��У�ת�ƽ����Լ����ƶ�ս����
                for (int i = 0; i < cityIds.Length && movePower > 0; i++)
                {
                    byte cityId = cityIds[i];
                    City city = CityListCache.GetCityByCityId(cityId);
                    short[] generalIds = city.GetWarOfficeGeneralIdArray(1); // ��ȡս���칫���Ľ���ID����

                    if (generalIds.Length != 0)
                    {
                        for (int j = 0; j < generalIds.Length && movePower > 0; j++)
                        {
                            short generalId = generalIds[j];
                            General general = GeneralListCache.GetGeneral(generalId); // ��ȡ�������
                            movePower = (int)(movePower - general.GetBattlePower()); // ����ս����
                            city.removeOfficeGeneralId(generalId); // �ӵ�ǰ�����Ƴ�����
                            tCity.AddOfficeGeneralId(generalId); // ��������ӵ�Ŀ�����
                        }
                        city.AppointmentPrefect(); // Ϊ��������̫��
                    }
                }

                // �����з����ڵĳ��У�����ת�ƽ����Լ���ս����
                cityIds = CountryListCache.GetEnemyAdjacentCityIdArray(country.countryId);
                for (int i = 0; i < cityIds.Length && movePower > 0; i++)
                {
                    byte cityId = cityIds[i];
                    City city = CityListCache.GetCityByCityId(cityId);
                    int defenseAbility1 = city.GetDefenseAbility(); // ��ȡ���еķ�������
                    int enemyAdjacentAtkPower1 = CountryListCache.GetEnemyAdjacentAtkPowerArray(cityId); // ��ȡ�з�������

                    // ��鹥�����Ƿ�С�ڵ��ڷ�����
                    if (enemyAdjacentAtkPower1 <= defenseAbility1)
                    {
                        short[] generalIds = city.GetWarOfficeGeneralIdArray(enemyAdjacentAtkPower1);
                        if (generalIds.Length != 0)
                        {
                            for (int j = 0; j < generalIds.Length && movePower > 0; j++)
                            {
                                short generalId = generalIds[j];
                                General general = GeneralListCache.GetGeneral(generalId); // ��ȡ�������
                                movePower = (int)(movePower - general.GetBattlePower()); // ����ս����
                                city.removeOfficeGeneralId(generalId); // �Ƴ�����
                                tCity.AddOfficeGeneralId(generalId); // ��������ӵ�Ŀ�����
                            }
                            city.AppointmentPrefect(); // ����̫��
                        }
                    }
                }
            }
            else
            {
                int minPower = 0; // ��ʼ����Сս����

                // �������ڵĵз����У�Ѱ�����ʺϵ�Ŀ�����
                for (int i = 0; i < adjacentCity.Length; i++)
                {
                    byte cityId = adjacentCity[i];
                    City city = CityListCache.GetCityByCityId(cityId); // ��ȡ��ǰ���ж���
                    byte[] enemyCityIdArray = CountryListCache.GetEnemyCityIdArray(cityId); // ��ȡ�з�����ID����

                    for (int j = 0; j < enemyCityIdArray.Length; j++)
                    {
                        byte enemyCityId = enemyCityIdArray[j];
                        int defenseAbility = CountryListCache.GetEnemyAdjacentCityDefenseAbility(enemyCityId, cityId); // ��ȡ�з����з�������

                        // ����Ƿ�����ս����������������Сս����������Ŀ�����
                        if (city.getCityGeneralNum() < 10 && (minPower == 0 || minPower > city.getMaxAtkPower() - CountryListCache.GetEnemyAdjacentAtkPowerArray(cityId) - defenseAbility))
                        {
                            minPower = city.getMaxAtkPower() - CountryListCache.GetEnemyAdjacentAtkPowerArray(cityId) - defenseAbility;
                            result = true;
                            this.tarCity = cityId; // ����Ŀ�����
                        }
                    }
                }

                // ����ҵ����ʵ�Ŀ����У���������
                if (result)
                {
                    byte[] cityIds = CountryListCache.GetNoEnemyAdjacentCityIdArray(curTurnsCountryId); // ��ȡ�޵з����ڵĳ���
                    City tCity = CityListCache.GetCityByCityId(this.tarCity); // ��ȡĿ�����
                    bool isMove = false; // ��־�Ƿ���ɽ���ת��

                    // �����޵з����ڵĳ��У�ת�ƽ���
                    for (int j = 0; j < cityIds.Length && !isMove; j++)
                    {
                        byte cityId = cityIds[j];
                        City city = CityListCache.GetCityByCityId(cityId);
                        short[] generalIds = city.GetWarOfficeGeneralIdArray(1); // ��ȡս���칫���Ľ���ID

                        if (generalIds.Length != 0)
                        {
                            for (int k = 0; k < generalIds.Length; k++)
                            {
                                short generalId = generalIds[k];
                                General general = GeneralListCache.GetGeneral(generalId); // ��ȡ�������
                                movePower = (int)(movePower - general.GetBattlePower()); // ����ս����
                                city.removeOfficeGeneralId(generalId); // �Ƴ�����
                                tCity.AddOfficeGeneralId(generalId); // ��������ӵ�Ŀ�����
                                isMove = true; // �������ɽ���ת��
                            }
                            city.AppointmentPrefect(); // ����̫��
                        }
                    }
                }
            }

            return result; // ���ؽ��
        }


        // ������е������вֵ
        int getCityMaxTheat(byte city)
        {
            int min = -20000000; // ��ʼ����С��вֵ
                                    // ������ǰ���е����ڳ���
            for (int index = 0; index < CityListCache.GetCityByCityId(city).connectCityId.Length; index++)
            {
                short tcity = CityListCache.GetCityByCityId(city).connectCityId[index]; // ��ȡ���ڳ���ID
                                                                                        // ������ڳ��е��������Ҳ�ͬ
                if (CityListCache.GetCityByCityId((byte)tcity).cityBelongKing != CityListCache.GetCityByCityId(city).cityBelongKing)
                {
                    int enemyatkPower = GetCityAtkPower((byte)tcity); // ��ȡ�з����й�����
                    int mydefPower = GetCityDefPower(city); // ��ȡ��ǰ���з�����
                    int sub = enemyatkPower - mydefPower; // ������вֵ��
                    if (sub > min)
                        min = sub; // ���������вֵ
                }
            }
            return min; // ���������вֵ
        }

        // ������пɻ�ȡ��ս����
        int cityCangetPower(byte city, int needPower)
        {
            this.curCity = 0; // ��ʼ����ǰ����
            int cangetGenPower = 1; // ��ʼ���ɻ�ȡ�Ľ���ս����
            int cangetPower = needPower; // ��ʼ����Ҫ��ս����
                                            // �������г���
            for (byte id = 1; id < CityListCache.CITY_NUM; id = (byte)(id + 1))
            {
                City city2 = CityListCache.GetCityByCityId(id); // ��ȡ��ǰ���ж���
                                                                // �������Ƿ�����ͬһ�����ҽ�����������1
                if (id != city && city2.cityBelongKing == CityListCache.GetCityByCityId(city).cityBelongKing && city2.getCityGeneralNum() > 1)
                {
                    if (!cityIsEnemy(id)) // ����Ƿ�û�е���
                    {
                        if (city2.getCityGeneralNum() > cangetGenPower)
                        {
                            this.curCity = id; // ���µ�ǰ����
                            cangetGenPower = city2.getCityGeneralNum(); // ���¿ɻ�ȡ�Ľ���ս����
                        }
                    }
                    else if (cangetGenPower == 1 && needPower >= 0) // �������ս����Ϊ1����Ҫս�������ڵ���0
                    {
                        int threat = getCityMaxTheat(id); // ��ȡ���е������в
                        if (threat < cangetPower)
                        {
                            this.curCity = id; // ���µ�ǰ����
                            cangetPower = threat; // ���¿ɻ�ȡ��ս����
                        }
                    }
                }
            }
            // ����ɻ�ȡ�Ľ���ս��������1������ֵ����1
            if (cangetGenPower > 1)
                return cangetGenPower - 1;
            // ����ҵ����ʵĳ���
            if (this.curCity != 0)
            {
                int pj = (needPower - cangetPower) / 2; // �����м�ֵ
                if (pj > needPower)
                    return needPower; // ����м�ֵ��������ս��������������ս����
                return pj; // ���򷵻��м�ֵ
            }
            return 0; // ���û���ҵ����ʵĳ��У�����0
        }

        /// <summary>
        /// ����AiFindLowHpEnemyGeneral����
        /// </summary>
        /// <returns></returns>
        bool AiFindLowHpEnemyGeneral()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId); // ��ȡ��ǰ����
            byte[] adjacentCity = country.GetEnemyAdjacentCityIdArray(); // ��ȡ���ڵз�����ID����
            byte byte3 = 0; // ��ʼ���������/�쵼ֵ
                                // �������ڵз�����
            for (byte byte1 = 0; byte1 < adjacentCity.Length; byte1 = (byte)(byte1 + 1))
            {
                byte adjacentCityId = adjacentCity[byte1]; // ��ȡ���ڳ���ID
                if (adjacentCityId <= 0) // ���ID��Ч������ѭ��
                    break;
                City city = CityListCache.GetCityByCityId(adjacentCityId); // ��ȡ���ж���
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ���а칫������ID����
                if (city.GetMoney() >= 100) // ������н�Ǯ���ڵ���100
                {
                    // �������н���
                    for (byte byte2 = 0; byte2 < city.getCityGeneralNum(); byte2 = (byte)(byte2 + 1))
                    {
                        short generalId = officeGeneralIdArray[byte2]; // ��ȡ����ID
                                                                        // ��齫�������Ƿ�С�ڵ������������һ��
                        if (GeneralListCache.GetGeneral(generalId).getCurPhysical() <= GeneralListCache.GetGeneral(generalId).maxPhysical / 2)
                        {
                            // ����������������쵼��
                            if (GeneralListCache.GetGeneral(generalId).IQ > GeneralListCache.GetGeneral(generalId).lead)
                            {
                                if (GeneralListCache.GetGeneral(generalId).IQ > byte3) // �����������
                                {
                                    byte3 = GeneralListCache.GetGeneral(generalId).IQ;
                                    this.tarCity = adjacentCityId; // ����Ŀ�����
                                    this.HMGeneralId = generalId; // ����Ŀ�꽫��
                                }
                            }
                            else if (GeneralListCache.GetGeneral(generalId).lead > byte3) // ����Ƚ��쵼��
                            {
                                byte3 = GeneralListCache.GetGeneral(generalId).lead;
                                this.tarCity = adjacentCityId; // ����Ŀ�����
                                this.HMGeneralId = generalId; // ����Ŀ�꽫��
                            }
                            this.X = 19; // ����ĳ��״ֵ̬
                            this.tarCity = adjacentCityId; // �ٴ�����Ŀ�����
                            this.HMGeneralId = generalId; // �ٴ�����Ŀ�꽫��
                        }
                    }
                }
            }
            return (byte3 >= 0); // ����ҵ��˺��ʵĽ��죬����true
        }

        /// <summary>
        /// Ai�����ҳ϶Ƚ��췽��
        /// </summary>
        /// <returns></returns>
        bool AiFindLowLoyaltyGeneral()
        {
            int maxGeneralScore = 0; // ��ʼ�������÷�
            short tempGeneralId = 0; // ��ʼ����ʱ����ID
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId); // ��ȡ��ǰ����
                                                                                                // ���������еĳ���
            for (int k = 0; k < country.GetHaveCityNum(); k++)
            {
                byte cityId = country.getCity(k); // ��ȡ����ID
                City city = CityListCache.GetCityByCityId(cityId); // ��ȡ���ж���
                                                                    // �����н�Ǯ��������
                if (city.GetMoney() >= 50 || city.treasureNum != 0)
                {
                    short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // ��ȡ���а칫������ID����
                                                                                        // ���������еĽ���
                    for (byte i = 0; i < city.getCityGeneralNum(); i = (byte)(i + 1))
                    {
                        short GeneralId = officeGeneralIdArray[i]; // ��ȡ����ID
                        General general = GeneralListCache.GetGeneral(GeneralId); // ��ȡ�������
                        int generalScore = general.getGeneralScore(); // ��ȡ����÷�
                                                                        // ��齫���ҳ϶Ⱥͳ��еĽ�Ǯ/��������
                        if (generalScore > maxGeneralScore)
                            if (general.getLoyalty() < 90 && city.GetMoney() > 50 && city.GetMoney() / 50 > MathUtils.getRandomInt(4))
                            {
                                maxGeneralScore = generalScore; // �������÷�
                                tempGeneralId = GeneralId; // ������ʱ����ID
                                this.HMGeneralId = tempGeneralId; // ����Ŀ�꽫��
                                this.tarCity = cityId; // ����Ŀ�����
                            }
                            else if (general.getLoyalty() >= 90 && city.treasureNum > 0 && city.treasureNum > MathUtils.getRandomInt(4))
                            {
                                maxGeneralScore = generalScore; // �������÷�
                                tempGeneralId = GeneralId; // ������ʱ����ID
                                this.HMGeneralId = tempGeneralId; // ����Ŀ�꽫��
                                this.tarCity = cityId; // ����Ŀ�����
                            }
                    }
                }
            }
            if (tempGeneralId == 0) // ���û���ҵ����ʵĽ���
                return false;
            this.X = 8; // ����ĳ��״ֵ̬
            return true; // ����true
        }


        /// <summary>
        /// Ai����Ƿ���Ҫ���ʽ��һ������������һ������
        /// </summary>
        /// <returns></returns>
        bool needTransportMoneyToOtherCity()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId);
            byte num = country.GetHaveCityNum(); // ��ȡ����ӵ�еĳ�������
            if (num < 2)
                return false; // �����������С��2�������������ʽ�

            int[][] dat = new int[num * num][];
            for (int i = 0; i < num * num; i++)
                dat[i] = new int[3];

            try
            {
                // ��ʼ��dat���飬�洢���м���ʽ���Ϣ
                for (int k = 0; k < num; k++)
                {
                    for (int m = 0; m < num; m++)
                    {
                        dat[k * num + m][0] = country.getCity(k); // ����1
                        dat[k * num + m][1] = country.getCity(m); // ����2
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message); // ��׽������쳣
                return false;
            }

            // ����ÿ�Գ��е��ʽ����
            for (int i = 0; i < dat.Length; i++)
            {
                if (dat[i][0] != dat[i][1])
                {
                    byte cityId1 = (byte)dat[i][0];
                    City city1 = CityListCache.GetCityByCityId(cityId1); // ����1����
                    byte cityId2 = (byte)dat[i][1];
                    City city2 = CityListCache.GetCityByCityId(cityId2); // ����2����

                    short needMoney1 = 0;
                    short needMoney2 = 0;

                    // �жϳ���1�Ƿ��ڽ��гǣ������������ʽ�
                    if (CountryListCache.GetEnemyCityIdArray(cityId1).Length != 0)
                    {
                        needMoney1 = (short)(200 + city1.getCityGeneralNum() * 2000 - city1.getAllSoldierNum() / 5);
                    }
                    else
                    {
                        needMoney1 = (short)(200 + city1.getCityGeneralNum() * 600 - city1.getAllSoldierNum() / 5);
                    }

                    // �жϳ���2�Ƿ��ڽ��гǣ������������ʽ�
                    if (CountryListCache.GetEnemyCityIdArray(cityId2).Length != 0)
                    {
                        needMoney2 = (short)(200 + city2.getCityGeneralNum() * 2000 - city2.getAllSoldierNum() / 5);
                    }
                    else
                    {
                        needMoney2 = (short)(200 + city2.getCityGeneralNum() * 600 - city2.getAllSoldierNum() / 5);
                    }

                    // ������������֮����ʽ��
                    dat[i][2] = city1.GetMoney() - needMoney1 - city2.GetMoney() + needMoney2;
                }
            }

            // Ѱ���ʽ�����ĳ��ж�
            int val = -100000;
            byte pCity = 0;
            byte ACity = 0;

            for (int j = 0; j < dat.Length; j++)
            {
                if (dat[j][2] > val)
                {
                    byte cityId1 = (byte)dat[j][0];
                    byte cityId2 = (byte)dat[j][1];
                    City city1 = CityListCache.GetCityByCityId(cityId1);
                    City city2 = CityListCache.GetCityByCityId(cityId2);

                    if (city1 == null || city2 == null)
                        break;

                    // �����ʽ���������ҹ�ϵ��ȷ����Ҫ�����ʽ�ĳ���
                    if (city1.GetMoney() > 200 && !cityIsEnemy(cityId1) && cityIsEnemy(cityId2))
                    {
                        pCity = cityId1;
                        ACity = cityId2;
                        val = dat[j][2];
                    }
                    else if (city1.GetMoney() > 200 && cityIsEnemy(cityId1) && cityIsEnemy(cityId2) && city2.GetMoney() < 200)
                    {
                        pCity = cityId1;
                        ACity = cityId2;
                        val = dat[j][2];
                    }
                    else if (city1.GetMoney() > 200 && cityIsEnemy(cityId1) && !cityIsEnemy(cityId2) && city2.GetMoney() < 100)
                    {
                        pCity = cityId1;
                        ACity = cityId2;
                        val = dat[j][2];
                    }
                    else if (city1.GetMoney() > 200 && !cityIsEnemy(cityId1) && !cityIsEnemy(cityId2) && city2.GetMoney() < 200)
                    {
                        pCity = cityId1;
                        ACity = cityId2;
                        val = dat[j][2];
                    }
                }
            }

            // ����ҵ����ʵĳ��жԣ��򷵻�true
            if (pCity > 0 && ACity > 0)
            {
                this.tarCity = ACity;
                this.curCity = pCity;
                return true;
            }

            return false; // ���򷵻�false
        }

        /// <summary>
        /// Ai�������Ƿ���Ҫ��ʳ
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short[] cityNeedFood(byte cityId)
        {
            short[] needVal = new short[3]; // �洢���ص���ʳ������Ϣ
            short needFood = 0;
            bool isNearEnemy = false;
            City city = CityListCache.GetCityByCityId(cityId);
            short food = CityListCache.GetCityByCityId(cityId).GetFood(); // ��ȡ���е�ǰ����ʳ����

            // ��������ڽ��гǣ�������ս�����ջ����ʳ����
            if (cityIsEnemy(cityId))
            {
                isNearEnemy = true;
                needFood = (short)(needFood + city.needFoodWarAMonth());
                needFood = (short)(needFood + city.needFoodToHarvest());
            }
            else
            {
                needFood = (short)(needFood + city.needFoodToHarvest());
                if (food > needFood)
                    needFood = (short)(needFood - food - needFood); // �����ʳ�����������������
            }

            // ������ʳ�������
            if (needFood > food)
            {
                needVal[0] = 1;
                byte v1 = (byte)((needFood - food) / 100); // ������ʳȱ��
                short num = (short)(food - needFood); // ���㵱ǰ��ʳ���
                if (isNearEnemy)
                    v1 = (byte)(v1 * 4 / 3); // ����ڽ��гǣ�����������ϵ��
                needVal[1] = v1;
                needVal[2] = num;
            }
            else
            {
                needVal[0] = 0;
                byte v2 = (byte)((needFood - food) / 100);
                short num = (short)(food - needFood);
                needVal[1] = v2;
                needVal[2] = num;
            }

            return needVal; // ������ʳ������Ϣ
        }


        /// <summary>
        /// AI�ж��Ƿ���Ҫ������ʳ
        /// </summary>
        /// <returns></returns>
        bool judTransportFood()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId); // ��ȡ��ǰ�غϵĹ���
            if (country.GetHaveCityNum() < 2)
                return false; // �����������С��2��������������ʳ

            this.tarCity = 0;
            this.curCity = 0;

            // ��ʼ��һ���洢ÿ��������ʳ����Ķ�ά����
            short[][] needprot = new short[country.GetHaveCityNum()][];
            for (int i = 0; i < country.GetHaveCityNum(); i++)
            {
                byte city = country.getCity(i); // ��ȡ���ҵ�ÿ������ID
                needprot[i] = cityNeedFood(city); // ���÷�����ȡ�ó��е���ʳ������Ϣ
            }

            // ��ʼ��������С����ʳ�����������Ӧ�ĳ���
            byte max = (byte)needprot[0][1];
            byte min = (byte)needprot[0][1];
            byte maxcity = country.getCity(0);
            byte mincity = country.getCity(0);

            // �������г��У��ҵ���ʳ�����������ٵĳ���
            for (int j = 0; j < needprot.Length; j++)
            {
                if (needprot[j][1] > max)
                {
                    max = (byte)needprot[j][1];
                    maxcity = country.getCity(j);
                }
                if (needprot[j][1] < min)
                {
                    min = (byte)needprot[j][1];
                    mincity = country.getCity(j);
                }
            }

            // ���������С�ĳ�����ͬһ��������Ҫ������ʳ
            if (maxcity == mincity)
                return false;

            // ���������С������ʳ����Ĳ�ͬ��������ж�
            if (max == min && max > 0 && min > 0)
            {
                // ����������ǵгǣ���С���в��ǵгǣ�����Ҫ������ʳ
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                    return true;
                }
                if (cityIsEnemy(maxcity))
                {
                    for (int j = 0; j < CityListCache.GetCityByCityId(maxcity).connectCityId.Length; j++)
                    {
                        byte city = (byte)CityListCache.GetCityByCityId(maxcity).connectCityId[j];
                        if (CityListCache.GetCityByCityId(city).cityBelongKing == country.countryKingId)
                        {
                            this.tarCity = maxcity;
                            this.curCity = mincity;
                            this.X = 12;
                            return true;
                        }
                    }
                }
            }
            else if (max == min && max < 0 && min < 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                    return true;
                }
            }
            else if (max > 0 && min > 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                    return true;
                }
                if (cityIsEnemy(maxcity))
                {
                    for (int j = 0; j < CityListCache.GetCityByCityId(maxcity).connectCityId.Length; j++)
                    {
                        byte city = (byte)CityListCache.GetCityByCityId(maxcity).connectCityId[j];
                        if (CityListCache.GetCityByCityId(city).cityBelongKing == country.countryKingId)
                        {
                            this.tarCity = maxcity;
                            this.curCity = mincity;
                            this.X = 12;
                            return true;
                        }
                    }
                }
                else if (cityIsEnemy(maxcity) && cityIsEnemy(mincity) && max > min + 3)
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                    return true;
                }
            }
            else if (max < 0 && min < 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                    return true;
                }
            }
            else
            {
                this.tarCity = maxcity;
                this.curCity = mincity;
                this.X = 12;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Ai�жϳ��е��ʽ�����
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short[] cityNeedMoney(byte cityId)
        {
            short[] needVal = new short[3]; // ���ڴ洢���ص��ʽ�������Ϣ
            short needMoney = 0; // ��ʼ�ʽ�����Ϊ0
            bool isNearEnemy = false; // ��Ǹó����Ƿ��ڽ��г�
            City city = CityListCache.GetCityByCityId(cityId); // ��ȡ���ж���
            byte generalNum = city.getCityGeneralNum(); // ��ȡ�ó��еĽ�������

            // ����ó����ڽ��г�
            if (cityIsEnemy(cityId))
            {
                isNearEnemy = true;
                needMoney = (short)(needMoney + 100 + (city.getAllSoldierNum() - city.GetCityAllSoldierNum()) / 3);
                if (needMoney < 200 && city.GetMoney() < generalNum * 600)
                    needMoney = (short)(needMoney + generalNum * 600); // ����ʽ��㣬����������
            }
            else
            {
                needMoney = (short)(needMoney + 100 + (city.getAllSoldierNum() - city.GetCityAllSoldierNum()) / 3); // ���ڽ��г�ʱ���ʽ�����
            }

            // ����ʽ�������ڵ�ǰ�����ʽ�
            if (needMoney > city.GetMoney())
            {
                needVal[0] = 1; // �����Ҫ�ʽ�
                byte v1 = (byte)((needMoney - city.GetMoney()) / 100); // �����ʽ�ȱ��
                short num = (short)(city.GetMoney() - needMoney); // ��ǰ�����ʽ����
                if (isNearEnemy)
                    v1 = (byte)(v1 * 4 / 3); // ����ڽ��гǣ���������
                needVal[1] = v1;
                needVal[2] = num;
            }
            else
            {
                needVal[0] = 0; // ��ǲ���Ҫ�ʽ�
                byte v2 = (byte)((needMoney - city.GetMoney()) / 100); // �����ʽ�ȱ��
                short num = (short)(city.GetMoney() - needMoney); // ��ǰ�����ʽ����
                needVal[1] = v2;
                needVal[2] = num;
            }

            return needVal; // �����ʽ�������Ϣ
        }


        /// <summary>
        /// Ai�ж��Ƿ���Ҫ�����ʽ�
        /// </summary>
        void judTransportMoney()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId); // ��ȡ��ǰ�غϵĹ���
            if (country.GetHaveCityNum() < 2)
                return; // ����ù��ҳ�������С��2������Ҫ�����ʽ�

            this.tarCity = 0;
            this.curCity = 0;

            // ��ʼ����ά���飬�洢ÿ�����е��ʽ��������
            short[][] needprot = new short[country.GetHaveCityNum()][];
            for (int i = 0; i < country.GetHaveCityNum(); i++)
            {
                byte city = country.getCity(i); // ��ȡ����ID
                needprot[i] = cityNeedMoney(city); // ��ȡ�ó��е��ʽ�����
            }

            // ��ʼ��������С�ʽ��������Ӧ�ĳ���
            byte max = (byte)needprot[0][1];
            byte min = (byte)needprot[0][1];
            byte maxcity = country.getCity(0);
            byte mincity = country.getCity(0);

            // �������г��У�Ѱ��������С���ʽ��������
            for (int j = 0; j < needprot.Length; j++)
            {
                if (needprot[j][1] > max)
                {
                    max = (byte)needprot[j][1];
                    maxcity = country.getCity(j);
                }
                if (needprot[j][1] < min)
                {
                    min = (byte)needprot[j][1];
                    mincity = country.getCity(j);
                }
            }

            // ���������С�ĳ�����ͬһ��������Ҫ�����ʽ�
            if (maxcity == mincity)
                return;

            // ���������С���е��ʽ���������ж��Ƿ������ʽ�
            if (max == min && max > 0 && min > 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12; // ���������ʽ�ľ���
                }
                else if (cityIsEnemy(maxcity))
                {
                    for (int j = 0; j < CityListCache.GetCityByCityId(maxcity).connectCityId.Length; j++)
                    {
                        byte city = (byte)CityListCache.GetCityByCityId(maxcity).connectCityId[j];
                        if (CityListCache.GetCityByCityId(city).cityBelongKing == CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).countryKingId)
                        {
                            this.tarCity = maxcity;
                            this.curCity = mincity;
                            this.X = 12;
                            break;
                        }
                    }
                }
            }
            else if (max == min && max < 0 && min < 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                }
            }
            else if (max > 0 && min > 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                }
                else if (cityIsEnemy(maxcity))
                {
                    for (int j = 0; j < CityListCache.GetCityByCityId(maxcity).connectCityId.Length; j++)
                    {
                        byte city = (byte)CityListCache.GetCityByCityId(maxcity).connectCityId[j];
                        if (CityListCache.GetCityByCityId(city).cityBelongKing == CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).countryKingId)
                        {
                            this.tarCity = maxcity;
                            this.curCity = mincity;
                            this.X = 12;
                            break;
                        }
                    }
                }
                else if (cityIsEnemy(maxcity) && cityIsEnemy(mincity) && max > min + 3)
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                }
            }
            else if (max < 0 && min < 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                }
            }
            else
            {
                this.tarCity = maxcity;
                this.curCity = mincity;
                this.X = 12;
            }
        }

        /// <summary>
        /// Ai�������һ�����е�������һ������
        /// </summary>
        /// <returns></returns>
        bool AiMoveGeneralToOtherCity()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId); // ��ȡ��ǰ�غϵĹ���
            byte[] adjacentCity = country.GetEnemyAdjacentCityIdArray(); // ��ȡ�ڽ��з��ĳ���ID����
            byte[] noAdjacentCity = country.GetNoEnemyAdjacentCityIdArray(); // ��ȡ���ڽ��з��ĳ���ID����
            if (noAdjacentCity.Length <= 0)
                return false; // ���û�в��ڽ��з��ĳ��У�����Ҫ����

            double maxBattlePower = 0.0D; // ���ս����
            short moveGeneralId = 0; // ��Ҫ�ƶ��Ľ���ID
            byte moveCityId = 0; // ��Ҫ�ƶ��ĳ���ID

            // �������в��ڽ��з��ĳ��У�Ѱ��ս������ߵĽ���
            for (int index = 0; index < noAdjacentCity.Length; index++)
            {
                byte thisCity = noAdjacentCity[index];
                City city = CityListCache.GetCityByCityId(thisCity);
                for (byte id = 0; id < city.getCityGeneralNum(); id++)
                {
                    short generalId = city.getCityOfficeGeneralIdArray()[id];
                    if (generalId != 0)
                    {
                        General general = GeneralListCache.GetGeneral(generalId);
                        double curVal = general.GetBattlePower();
                        if (curVal > maxBattlePower)
                        {
                            moveGeneralId = generalId;
                            maxBattlePower = curVal;
                            moveCityId = thisCity;
                        }
                    }
                }
            }

            double minBattlePower = maxBattlePower; // ��Сս����
            short beMoveId = 0; // ���滻�Ľ���ID
            byte beCityId = 0; // ���滻�ĳ���ID

            // ���������ڽ��з��ĳ��У�Ѱ��ս������͵Ľ���
            for (int i = 0; i < adjacentCity.Length; i++)
            {
                byte thisCity = adjacentCity[i];
                City city = CityListCache.GetCityByCityId(thisCity);
                for (byte id = 0; id < city.getCityGeneralNum(); id++)
                {
                    short generalId = city.getCityOfficeGeneralIdArray()[id];
                    if (generalId != 0)
                    {
                        General general = GeneralListCache.GetGeneral(generalId);
                        double curVal = general.GetBattlePower();
                        if (curVal < minBattlePower)
                        {
                            beMoveId = generalId;
                            minBattlePower = curVal;
                            beCityId = thisCity;
                        }
                    }
                }
            }

            // ���ս������ߵĽ����ս������͵Ľ���ߣ�����е���
            if (maxBattlePower > minBattlePower)
            {
                country.ChangeGeneral(moveCityId, moveGeneralId, beCityId, beMoveId); // ��������
                return true;
            }

            return false;
        }


        /// <summary>
        /// AI�ж����ڳ����Ƿ��������
        /// </summary>
        /// <returns></returns>
        bool AiJudCityFit()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId);  // ��ȡ��ǰ�غϵĹ���
            byte[] adjacentCity = country.GetEnemyAdjacentCityIdArray();  // ��ȡ�з����ڳ���ID����
            byte[] noAdjacentCity = country.GetNoEnemyAdjacentCityIdArray();  // ��ȡ�ǵз����ڳ���ID����
            byte byte1 = 0;

            // ������ڵз������Ƿ��������
            for (byte byte3 = 0; byte3 < adjacentCity.Length; byte3++)
            {
                if ((this.k_byte_array1d_fld[adjacentCity[byte3]] & 0x2) == 2)  // ����־λ�Ƿ�Ϊ2
                    byte1 = 1;
            }

            // ���û�����ڵĵз����з�������������ǵз����ڳ���
            if (byte1 == 0)
            {
                for (byte byte4 = 0; byte4 < noAdjacentCity.Length; byte4++)
                {
                    if ((this.k_byte_array1d_fld[noAdjacentCity[byte4]] & 0x2) == 2)  // ����־λ�Ƿ�Ϊ2
                        byte1 = 1;
                }
            }

            // �����Ȼû�з��������ĳ��У�����false
            return byte1 != 0;
        }

        /// <summary>
        /// Ai�ж��Ƿ�������
        /// </summary>
        /// <returns></returns>
        bool haveGrainShop()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId);  // ��ȡ��ǰ�غϵĹ���
            byte[] adjacentCity = country.GetEnemyAdjacentCityIdArray();  // ��ȡ�з����ڳ���ID����
            byte byte1 = 0;

            // ������ڵз������Ƿ�������
            for (byte byte3 = 0; byte3 < adjacentCity.Length; byte3++)
            {
                if ((this.k_byte_array1d_fld[adjacentCity[byte3]] & 0x8) == 8)  // ������ֱ�־λ
                    byte1 = 1;
            }

            byte[] noAdjacentCity = country.GetNoEnemyAdjacentCityIdArray();  // ��ȡ�ǵз����ڳ���ID����

            // ���û�ез����������֣�����ǵз����ڳ���
            if (byte1 == 0)
            {
                for (byte byte4 = 0; byte4 < noAdjacentCity.Length; byte4++)
                {
                    if ((this.k_byte_array1d_fld[noAdjacentCity[byte4]] & 0x8) == 8)  // ������ֱ�־λ
                        byte1 = 1;
                }
            }

            // �����Ƿ�������
            return byte1 != 0;
        }

        // ���ݸ���������ֵ���ҽ���
        short AiFindMostLeadEnemyGeneral(byte byte0)
        {
            short word0 = 0;
            int i1 = 0;

            // �������г���
            for (byte byte1 = 1; byte1 < CityListCache.CITY_NUM; byte1++)
            {
                byte k1 = byte1;

                // �жϳ����Ƿ����ڵ�ǰ����
                if (CityListCache.GetCityByCityId(k1).cityBelongKing != CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).countryKingId)
                {
                    // �����ó��е����н���
                    for (byte byte2 = 0; byte2 < CityListCache.GetCityByCityId(k1).getCityGeneralNum(); byte2++)
                    {
                        short word1 = CityListCache.GetCityByCityId(k1).getCityOfficeGeneralIdArray()[byte2];
                        General general = GeneralListCache.GetGeneral(word1);

                        // ɸѡ���������Ľ���
                        if (general.lead > i1 && general.getLoyalty() < 99 &&
                            (general.getLoyalty() <= 96 || general.IQ + 70 <= byte0) &&
                            (general.getLoyalty() <= 89 || general.IQ + 40 <= byte0) &&
                            general.IQ + 20 <= byte0)
                        {
                            word0 = word1;
                            i1 = general.lead;  // ���µ�ǰ�����쵼��
                        }
                    }
                }
            }
            return word0;
        }

        /// <summary>
        /// AI�������罫��ĸ���
        /// </summary>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        /// <returns></returns>
        int AiBribeProbability(short gohireId, short behireId)
        {
            General beGeneral = GeneralListCache.GetGeneral(behireId);  // ��ȡ�������Ľ���
            General goGeneral = GeneralListCache.GetGeneral(gohireId);  // ��ȡ�����Ľ���

            if (beGeneral.getLoyalty() == 100)  // ����ҳ϶�Ϊ100��ֱ�ӷ���0
                return 0;

            short kingId = GetOfficeGenBelongKing(behireId);  // ��ȡ���������������ľ���
            if (kingId <= 0)
            {
                Debug.Log("δ�ҵ�" + beGeneral.generalName + "����������");
                return 0;
            }

            short bepk = GeneralListCache.GetGeneral(kingId).phase;  // ����������ľ�������
            short pk = GeneralListCache.GetGeneral(GetOfficeGenBelongKing(gohireId)).phase;  // ��������ľ�������

            int d1 = GetdPhase(bepk, beGeneral.phase);  // �������Բ��
            int d2 = GetdPhase(pk, beGeneral.phase);    // �������Բ��
            int d3 = GetdPhase(goGeneral.phase, beGeneral.phase);  // ���������뱻������������Բ��

            if (d1 == 0)
                return 0;
            if (d2 == 0)
                return 1000;

            int val = d1 - d2 - d3 * 2 + 100 - beGeneral.getLoyalty();  // ���������ɹ��ļ���
            if (val > 0)
                return val * 20;

            // ������ж��Ƿ������ɹ�
            if (CommonUtils.getRandomInt() % 120 < goGeneral.IQ - beGeneral.IQ)
                return (goGeneral.IQ - beGeneral.IQ) / 2;

            return 0;
        }

        /// <summary>
        /// Ai�ж��������
        /// </summary>
        /// <returns></returns>
        bool AiJudgeBribe()
        {
            short gohireId = 0;
            short behireId = 0;
            byte behireCity = 0;
            byte gohireCity = 0;
            int val = 0;

            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId);  // ��ȡ��ǰ�غϹ���
            byte[] cityIds = country.GetCities();  // ��ȡ�ù��ҵ����г���

            // �������г���
            for (byte i = 1; i < CityListCache.CITY_NUM; i++)
            {
                City otherCity = CityListCache.GetCityByCityId(i);

                if (otherCity.cityBelongKing != country.countryKingId)  // �ж��Ƿ�Ϊ�з�����
                {
                    short[] otherOfficeGeneralIdArray = otherCity.getCityOfficeGeneralIdArray();

                    for (byte j = 0; j < cityIds.Length; j++)
                    {
                        City thisCity = CityListCache.GetCityByCityId(cityIds[j]);

                        if (thisCity.getCityGeneralNum() <= 9)  // ������еĽ�������������9
                        {
                            short[] thisOfficeGeneralIdArray = thisCity.getCityOfficeGeneralIdArray();

                            for (int k = 0; k < thisOfficeGeneralIdArray.Length; k++)
                            {
                                short thisGeneralId = thisOfficeGeneralIdArray[k];

                                for (int m = 0; m < otherOfficeGeneralIdArray.Length; m++)
                                {
                                    short otherGeneralId = otherOfficeGeneralIdArray[m];
                                    int per = AiBribeProbability(thisGeneralId, otherGeneralId);  // ���������ɹ���

                                    if (per > 0)
                                    {
                                        General otherGeneral = GeneralListCache.GetGeneral(otherGeneralId);
                                        int curval = (otherGeneral.lead * 3 + otherGeneral.force + otherGeneral.IQ) * per;

                                        if (curval > val)
                                        {
                                            behireId = otherGeneralId;
                                            gohireId = thisGeneralId;
                                            behireCity = i;
                                            gohireCity = cityIds[j];
                                            val = curval;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (behireId == 0)
                return false;

            // ִ����������
            if (behireId != 0 && gohireCity != 0 && gohireId != 0)
            {
                if (BribeRate(gohireId, behireId))  // �ж������ɹ�
                {
                    AiBribe(gohireCity, behireCity, gohireId, behireId);
                    return true;
                }
                AiAlienate(behireCity, gohireId, behireId);  // �������ʧ�ܣ�ִ����������
                return true;
            }

            return false;
        }

        // �Ƿ�����
        bool AiJudgeEmploy(short word0, short word1)
        {
            // ��������ҳ϶�С��80����������
            if (GeneralListCache.GetGeneral(word1).getLoyalty() < 80)
                return AiEmploy(word0, word1);
            return false;
        }

        // ������������
        int CalculateIQDIfference(short word0, short word1)
        {
            byte byte0 = GeneralListCache.GetGeneral(word0).IQ;
            int i1 = GeneralListCache.GetGeneral(word1).IQ;
            byte byte1 = GeneralListCache.GetGeneral(word1).getLoyalty();

            if (byte1 > 99)
            {
                i1 = 10000; // �ҳ϶ȼ���ʱ�����⴦��
            }
            else if (byte1 > 96)
            {
                i1 += 50; // �ҳ϶ȴ���96ʱ���Ӷ���ֵ
            }
            else if (byte1 > 89)
            {
                i1 += 20; // �ҳ϶ȴ���89ʱ���Ӷ���ֵ
            }

            return byte0 - i1; // ����������ֵ
        }

        /// <summary>
        /// ��ȡ�����е�����ߵĽ���ID
        /// </summary>
        /// <param name="byte0"></param>
        /// <returns></returns>
        short GetMostMoralGeneralInCity(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            short word0 = officeGeneralIdArray[0];
            byte byte1 = GeneralListCache.GetGeneral(word0).moral;

            // �����������飬�ҳ�������ߵĽ���
            for (byte byte2 = 1; byte2 < city.getCityGeneralNum(); byte2++)
            {
                if (byte1 < GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]).moral)
                {
                    word0 = officeGeneralIdArray[byte2];
                    byte1 = GeneralListCache.GetGeneral(word0).moral;
                }
            }
            return word0;
        }

        /// <summary>
        /// ��ȡ�����������͵������ۺ���߽���ID
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short GetMostIQMoralGeneralInCity(byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            short generalId = officeGeneralIdArray[0];
            General general = GeneralListCache.GetGeneral(generalId);
            int i1 = general.IQ + general.moral / 2;

            // �������н��죬���������+�������ۺ�ֵ��ߵĽ���
            for (byte byte1 = 1; byte1 < city.getCityGeneralNum(); byte1++)
            {
                General otherGeneral = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]);
                if (i1 < otherGeneral.IQ + otherGeneral.moral / 2)
                {
                    generalId = officeGeneralIdArray[byte1];
                    i1 = otherGeneral.IQ + otherGeneral.moral / 2;
                }
            }
            return generalId;
        }

        /// <summary>
        /// ���ݻ�ȡ���ʺ������Ľ���
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="beGenId"></param>
        /// <returns></returns>
        short GetDoSearchGen(byte cityId, short beGenId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            short generalId = officeGeneralIdArray[0];
            byte d = 100;

            // �������н��죬�ҳ���Ŀ�꽫���׺Ͷ���͵Ľ���
            for (byte byte2 = 1; byte2 < city.getCityGeneralNum(); byte2++)
            {
                short curId = officeGeneralIdArray[byte2];
                byte curd = (byte)GetdPhase(curId, beGenId);
                if (curd < d)
                {
                    generalId = officeGeneralIdArray[byte2];
                    d = curd;
                }
            }
            return generalId;
        }

        /// <summary>
        /// AI������������
        /// </summary>
        /// <param name="curTurnsCountryId"></param>
        void aiDoSearchGen(byte curTurnsCountryId)
        {
            // ���50%���ʽ�������
            if (MathUtils.getRandomInt(100) < 50)
                return;

            Country country = CountryListCache.GetCountryByCountryId(curTurnsCountryId);

            // �����������г��У�Ѱ�ҿ��������Ľ���
            for (int index = 0; index < country.GetHaveCityNum(); index++)
            {
                byte curCityId = country.getCity(index);
                City city = CityListCache.GetCityByCityId(curCityId);
                if (city.getCityGeneralNum() < 10 && city.GetOppositionGeneralNum() > 0)
                {
                    short generalId = city.GetOppositionGeneralId((byte)(CommonUtils.getRandomInt() % city.GetOppositionGeneralNum()));
                    if (generalId > 0)
                    {
                        short employGeneralId = GetDoSearchGen(curCityId, generalId);
                        if (isEmploy(curCityId, employGeneralId, generalId))
                            return;
                    }
                }
            }

            // �ٴα���������ʣ�������
            for (int byte1 = 0; byte1 < country.GetHaveCityNum(); byte1++)
            {
                byte curCityId = country.getCity(byte1);
                City city = CityListCache.GetCityByCityId(curCityId);
                if (city.GetOppositionGeneralNum() > 0)
                {
                    short generalId = GetMostIQMoralGeneralInCity(curCityId);
                    SearchOrder(curCityId, generalId);
                }
            }
        }

        // ��������
        void AiDoSearchEmploy(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            try
            {
                // ������н�����������10�����Խ�������
                if (city.getCityGeneralNum() < 10 && city.GetOppositionGeneralNum() > 0)
                {
                    short behireId = city.GetOppositionGeneralId((byte)(CommonUtils.getRandomInt() % city.GetOppositionGeneralNum()));
                    if (behireId <= 0)
                        return;

                    short word0 = GetMostMoralGeneralInCity(byte0);
                    isEmploy(byte0, word0, behireId);
                }

                short word1 = GetMostIQMoralGeneralInCity(byte0);
                SearchOrder(byte0, word1);
            }
            catch (Exception exception)
            {
            Debug.Log(exception); // �����쳣����ֹ�������
            }
        }


        /// <summary>
        /// AI��ȡ�����������������ۺ�������ߵĽ���ID
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short AiFindMostIQPoliticalGeneralInCity(byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            short generalId = officeGeneralIdArray[0];
            General general = GeneralListCache.GetGeneral(generalId);

            // �����ۺ�����ֵ (���� + ���� * 2) / 3
            short byte1 = (short)((general.IQ + general.political * 2) / 3);

            // �����������飬�ҳ��ۺ�����ֵ��ߵĽ���
            for (byte byte2 = 1; byte2 < city.getCityGeneralNum(); byte2++)
            {
                General curGeneral = GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]);
                short curVal = (short)((curGeneral.IQ + curGeneral.political * 2) / 3);
                if (byte1 < curVal)
                {
                    generalId = officeGeneralIdArray[byte2];
                    byte1 = curVal;
                    // �������߱�ĳЩ�ؼ����������̲ţ�����ֵ�ӱ�
                    if (GetSkill_4(generalId, 0) || GetSkill_4(generalId, 2) || GetSkill_4(generalId, 3))
                        byte1 = (short)(byte1 * 2);
                }
            }
            return generalId;
        }

        // AI��ȡ���������
        short AIgetGenToXC(byte city)
        {
            short id = CityListCache.GetCityByCityId(city).getCityOfficeGeneralIdArray()[0];
            General general = GeneralListCache.GetGeneral(id);

            // �����ʼ�ۺ�����ֵ (���� + ���� * 2 + ���� * 2) / 5
            int val = (general.IQ + general.political * 2 + general.moral * 2) / 5;

            // �����������飬�ҳ��ۺ�����ֵ��ߵĽ���
            for (byte index = 0; index < CityListCache.GetCityByCityId(city).getCityGeneralNum(); index++)
            {
                short curId = CityListCache.GetCityByCityId(city).getCityOfficeGeneralIdArray()[index];
                General curGeneral = GeneralListCache.GetGeneral(curId);
                int curVal = (curGeneral.IQ + curGeneral.political * 2 + curGeneral.moral * 2) / 5;

                // �������߱�ĳЩ�ؼ�������ֵ�ӱ�
                if (GetSkill_4(curId, 0) || GetSkill_4(curId, 1))
                    curVal *= 2;
                if (curVal > val)
                {
                    id = curId;
                    val = curVal;
                }
            }
            return id;
        }

        /// <summary>
        /// AI�Զ�ѡ����������
        /// </summary>
        /// <param name="cityId"></param>
        void AutoInteriorLogic(byte cityId)
        {
            short generalId = AiFindMostIQPoliticalGeneralInCity(cityId);
            City city = CityListCache.GetCityByCityId(cityId);

            // ���Ƚ�����ˮ
            if (city.floodControl < 99)
            {
                AiTameOrder(cityId, generalId);
                return;
            }

            // �������ȷ�չũҵ��ó��
            if (CommonUtils.getRandomInt() % 3 > 1)
            {
                if (city.agro < 999 && city.trade < 999)
                {
                    if (GameInfo.month < 4 || GameInfo.month >= 10)
                    {
                        AiMercantileOrder(cityId, generalId);
                    }
                    else
                    {
                        AiReclaimOrder(cityId, generalId);
                    }
                    return;
                }
                if (city.agro < 999)
                {
                    AiReclaimOrder(cityId, generalId);
                    return;
                }
                if (city.trade < 999)
                {
                    AiMercantileOrder(cityId, generalId);
                    return;
                }
            }

            // �˿�δ�����������ȷ�չ�˿�
            if (city.population < 990000)
            {
                generalId = AIgetGenToXC(cityId);
                AiPatrolOrder(cityId, generalId);
                return;
            }

            // ���������ˮ
            AiTameOrder(cityId, generalId);
        }

        /// <summary>
        /// AI���㲢ִ����������
        /// </summary>
        /// <param name="cityId"></param>
        void AiCalculateInterior(byte cityId)
        {
            int i = MathUtils.getRandomInt(13);
            short generalId = AiFindMostIQPoliticalGeneralInCity(cityId);
            City city = CityListCache.GetCityByCityId(cityId);

            // �����ʽ���ʱ������ѡ���ض�����
            if (city.GetMoney() < 50)
                i = 7;

            // ����������ѡ�������ж�
            switch (i)
            {
                case 0:
                    if (city.floodControl < 99)
                        AiTameOrder(cityId, generalId);
                    break;
                case 1:
                    if (city.agro < 999)
                        AiReclaimOrder(cityId, generalId);
                    break;
                case 2:
                    if (city.trade < 999)
                        AiMercantileOrder(cityId, generalId);
                    break;
                case 3:
                case 4:
                    if (city.population < 990000)
                    {
                        generalId = AIgetGenToXC(cityId);
                        AiPatrolOrder(cityId, generalId);
                    }
                    break;
                case 5:
                case 6:
                    AiJudgeBribe(); // ִ���ض���Ϊ
                    break;
                case 7:
                case 8:
                    AiDoSearchEmploy(cityId); // ִ�������ж�
                    break;
            }
        }

        /// <summary>
        /// Ai��ʼִ����������
        /// </summary>
        /// <param name="curTurnsCountryId"></param>
        void AiStartInterior(byte curTurnsCountryId)
        {
            Country country = CountryListCache.GetCountryByCountryId(curTurnsCountryId);
            byte cityId = 0;
            byte CITY_NUM = country.GetHaveCityNum();

            // ���ѡ��һ�����н�����������
            int index = CommonUtils.getRandomInt() % CITY_NUM;
            cityId = country.getCity(index);
            AiCalculateInterior(cityId);
        }

        /// <summary>
        /// ����ս�������ཫ���������ֵ
        /// </summary>
        /// <param name="humanGeneralId_inWar"></param>
        /// <param name="humanGeneralNum_inWar"></param>
        /// <param name="abyte0"></param>
        /// <returns></returns>
        int GetTotalGeneralFightValInWar(short[] humanGeneralId_inWar, int humanGeneralNum_inWar, byte[] abyte0)
        {
            int j1 = 0;

            // ������ս�Ľ��죬�������������������ֵ
            for (int index = 0; index < humanGeneralNum_inWar; index++)
            {
                if (abyte0[index] <= 0 || abyte0[index] >= 4)
                {
                    int k1 = SingleGeneralFightValue(humanGeneralId_inWar[index]);
                    j1 += k1;
                }
            }
            return j1;
        }

        /// <summary>
        /// �жϽ����Ƿ�߱�����ս��������
        /// </summary>
        /// <param name="i1"></param>
        /// <returns></returns>
        bool AiJudgeGeneralToWar(int i1)
        {
            // ����Ƿ������������
            if (!boolean_bsi_a(curWarCityId, this.aiKingId))
                return false;

            // ��齫���ʿ�������Ƿ�С��100
            return (GeneralListCache.GetGeneral(this.aiGeneralId_inWar[i1]).generalSoldier < 100);
        }


        /// <summary>
        /// ��ȡ���Գ��˵ĳ���ID
        /// </summary>
        /// <param name="kingId"></param>
        /// <param name="canRetreatCityIdArray"></param>
        /// <param name="canRetreatNum"></param>
        /// <param name="curWarCity"></param>
        /// <returns></returns>
        byte getCanRetreatCityId(short kingId, byte[] canRetreatCityIdArray, byte canRetreatNum, byte curWarCity)
        {
            // ����һ���µ�����洢����kingId�ĳ���
            byte[] abyte1 = new byte[canRetreatNum];
            byte byte2 = 0;

            // �������Գ��˵ĳ���ID���飬�ҳ�����kingId�ĳ���
            for (byte i = 0; i < canRetreatNum; i++)
            {
                if (CityListCache.GetCityByCityId(canRetreatCityIdArray[i]).cityBelongKing == kingId)
                {
                    abyte1[byte2] = canRetreatCityIdArray[i];
                    byte2++;
                }
            }

            // ����ҵ�������kingId�ĳ���
            if (byte2 > 0)
            {
                byte x = 10; // ��ʼ����Ϊ�������
                byte y = 0;
                byte mb = 0; // ���ʺϳ��˵ĳ���ID

                // �����ҵ��ĳ��У�ѡ���������ٵĳ���
                for (byte b1 = 0; b1 < byte2; b1++)
                {
                    byte b3 = abyte1[b1];
                    byte generalNum = CityListCache.GetCityByCityId(b3).getCityGeneralNum();

                    // �ų���ǰս�����У��ҳ�����������10����С�ĳ���
                    if (b3 != curWarCity && CityListCache.GetCityByCityId(b3).cityBelongKing == kingId && generalNum < 10 && generalNum < x)
                    {
                        x = generalNum;
                        mb = b3;
                        y++;
                    }
                }

                // ����ҵ��˺��ʵĳ��У����ظó���ID
                if (y > 0)
                    return mb;

                // ���򷵻ؽ����������ĳ���
                byte cityId = abyte1[0];
                for (byte b2 = 1; b2 < byte2; b2++)
                {
                    if (CityListCache.GetCityByCityId(cityId).getCityGeneralNum() < CityListCache.GetCityByCityId(abyte1[b2]).getCityGeneralNum())
                        cityId = abyte1[b2];
                }
                return cityId;
            }

            // ���û���ҵ�����kingId�ĳ��У�������һ�����Գ��˵ĳ���
            if (canRetreatNum > 0)
            {
                for (byte i = 0; i < canRetreatNum; i++)
                {
                    for (byte byte8 = 1; byte8 < CityListCache.CITY_NUM; byte8++)
                    {
                        if (byte8 != curWarCity && CityListCache.GetCityByCityId(byte8).cityBelongKing == kingId && CityListCache.GetCityByCityId(byte8).getCityGeneralNum() < 10)
                            return canRetreatCityIdArray[i];
                    }
                }
                // �������һ������ID
                return canRetreatCityIdArray[CommonUtils.getRandomInt() % canRetreatNum];
            }

            // ���û���ҵ����Գ��˵ĳ��У�����0
            return 0;
        }

        /// <summary>
        /// AI�ж��Ƿ���
        /// </summary>
        /// <returns></returns>
        bool aiGenchetui1()
        {
            // �жϵ�ǰ����������Ƿ���ڶԷ�������ɵ��˺�
            if (GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() < getAtkDea(this.HMGeneralId, this.HMSingleAtk, this.AISingleDef) + 1)
                return true;

            // �������ʧ������
            return !IsSuccessOfCompetition();
        }


        /// <summary>
        /// AI�ж��Ƿ���
        /// </summary>
        /// <returns></returns>
        bool aiGenchetui()
        {
            // ��ȡ����ս����ʿ���������ֱ���㼺���͵з�������
            short word0 = soldierInWarNum(true);  // ����ʿ������
            short word1 = soldierInWarNum(false); // �з�ʿ������

            // ��ȡ����ʿ���ĳ�ʼ����
            byte aix = this.smallSoldierCellX[1][0]; // AIʿ����X����
            byte aiy = this.smallSoldierCellY[1][0]; // AIʿ����Y����

            short canatkps = 0;  // �ɹ�������
            byte testx = 0;     // ������X����
            byte testy = 0;     // ������Y����

            try
            {
                // ����ս����ÿһ����Ԫ�񣬲��ҿ��Խ��й����ĵ���
                for (byte celly = 0; celly < 7; celly++)
                {
                    for (byte cellx = 0; cellx < 16; cellx++)
                    {
                        testx = cellx;
                        testy = celly;

                        // ��鵱ǰ��Ԫ���Ƿ��ез�ʿ��
                        if (this.smallWarCoordinate[celly][cellx] == 64)
                        {
                            byte dx = (byte)Math.Abs(aix - cellx); // X�����ϵľ���
                            byte dy = (byte)Math.Abs(aiy - celly); // Y�����ϵľ���
                            bool flag1 = false; // �ж��Ƿ���Թ���
                            bool flag2 = false; // δʹ�õı�־λ

                            // ���ʿ������͹�����������ͬ�Ĺ����߼������ڲ�ͬ��ʿ�����ࣩ
                            if (this.coodinateSoldierKind[celly][cellx] == 2 && ((dx <= 6 && dy == 0) || dx == 0 || dx + dy <= 2))
                            {
                                // ����dx >= 5 ��������ж��Ƿ���Թ���
                                if (dx >= 5 && dx <= 6 && dy == 0 && (this.aa & 0xF0) == 48 && aix > cellx)
                                {
                                    for (int i = 1; i < dx; i++)
                                    {
                                        if (this.smallWarCoordinate[celly][cellx + i] == Byte.MinValue)
                                        {
                                            flag1 = false;
                                            break;
                                        }
                                        flag1 = true;
                                    }
                                }

                                // �����������жϣ������߼����ƣ���ͬ��dx��dy�ᴥ����ͬ���ж�
                                if (dx <= 4 && dx >= 1 && dy == 0 && aix > cellx)
                                {
                                    if (aix > cellx + 1)
                                    {
                                        for (int i = 1; i < dx; i++)
                                        {
                                            if (this.smallWarCoordinate[celly][cellx + i] == Byte.MinValue)
                                            {
                                                flag1 = false;
                                                break;
                                            }
                                            flag1 = true;
                                        }
                                    }
                                    else if (aix == cellx + 1)
                                    {
                                        flag1 = true;
                                    }
                                }

                                // ���������ϵ��ж�
                                if (dx == 0)
                                {
                                    if (aiy > celly + 1)
                                    {
                                        for (int i = 1; i < dy; i++)
                                        {
                                            if (this.smallWarCoordinate[celly + i][cellx] == Byte.MinValue)
                                            {
                                                flag1 = false;
                                                break;
                                            }
                                            flag1 = true;
                                        }
                                    }
                                    else if (aiy < celly - 1)
                                    {
                                        for (int i = 1; i < dy; i++)
                                        {
                                            if (this.smallWarCoordinate[celly - i][cellx] == Byte.MinValue)
                                            {
                                                flag1 = false;
                                                break;
                                            }
                                            flag1 = true;
                                        }
                                    }
                                    else if (aiy == celly + 1 || aiy == celly - 1)
                                    {
                                        flag1 = true;
                                    }
                                }
                            }

                            // ���Ƶ��߼����ڲ�ͬ�����ʿ��
                            else if (this.coodinateSoldierKind[celly][cellx] == 1 && dx + dy <= 2)
                            {
                                // �ж��Ƿ���Թ���������
                                if (aiy == celly && aix == cellx + 2 && this.smallWarCoordinate[aiy][aix - 1] != Byte.MinValue)
                                    flag1 = true;
                                if (aiy == celly && aix == cellx + 1)
                                    flag1 = true;
                                if (aiy == celly && aix == cellx - 2 && this.smallWarCoordinate[aiy][aix + 1] != Byte.MinValue)
                                    flag1 = true;
                                if (aiy == celly && aix == cellx + 1)
                                    flag1 = true;
                                if (aix == cellx && aiy == celly + 2 && this.smallWarCoordinate[aiy + 1][aix] != Byte.MinValue)
                                    flag1 = true;
                                if (aix == cellx && aiy == celly + 1)
                                    flag1 = true;
                                if (aix == cellx && aiy == celly - 2 && this.smallWarCoordinate[aiy - 1][aix] != Byte.MinValue)
                                    flag1 = true;
                                if (aix == cellx && aiy == celly - 1)
                                    flag1 = true;
                            }

                            // ������Թ��������㹥������
                            if (flag1)
                            {
                                short blood = 1;
                                short atk = 1;

                                // ��������ʿ���б��ҵ���Ӧ��ʿ���������乥������
                                for (int hmindex = 0; hmindex < this.humanSmallSoldierNum; hmindex++)
                                {
                                    if (this.smallSoldier_isSurvive[0][hmindex] && this.smallSoldierCellX[0][hmindex] == cellx && this.smallSoldierCellY[0][hmindex] == celly)
                                    {
                                        if (this.smallSoldierKind[0][hmindex] == 0)
                                        {
                                            blood = 300;
                                            atk = this.smallSoldierAtk[0][0];
                                            break;
                                        }
                                        blood = this.smallSoldierBlood[0][hmindex];
                                        atk = this.smallSoldierAtk[0][hmindex];
                                        break;
                                    }
                                }
                                canatkps = (short)(canatkps + getshs(atk, this.smallSoldierDef[1][0], blood));
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                canatkps = 50; // �����쳣������Ĭ�Ϲ�������
                Debug.LogError(e);
            }

            // ���ݼ���Ĺ��������͵�ǰAI����������ж��Ƿ���
            if ((canatkps > GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() - 35 && canatkps > 0) || (GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() < 35 && word0 > 450 && word1 < 100 && this.W < 12))
                return true;

            // �ж��Ƿ���Ҫִ��"��Ѫ����"����
            if (maibebaowei(canatkps))
                return true;

            return false;
        }


        /// <summary>
        /// �����˺�ֵ
        /// </summary>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <param name="blood"></param>
        /// <returns></returns>
        short getshs(short atk, short def, short blood)
        {
            int gjl = atk; // ������
            int fyl = def; // ������
            int F = blood / 20; // Ѫ������
            float t1 = fyl / 150.0F; // �����������
            t1 *= d.hj[fyl - 1]; // ����ϵ������
            float sh = gjl * 1.0F / (1.0F + t1); // ��������˺�ֵ
            if (blood < 200) // ���Ѫ������200���˺�����������
                sh = sh * blood / 200.0F;
            if (sh < F) // �˺�ֵ��С������˺�ֵF
                sh = F;
            sh /= 6.0F; // ƽ���˺�ֵ
            if (sh < 1.0F) // �˺�ֵ��С��1
                sh = 1.0F;
            return (short)(int)sh;
        }

        /// <summary>
        /// AI��Ϊ����
        /// </summary>
        /// <param name="truns"></param>
        void aifield(int truns)
        {
            byte x = this.smallSoldierCellX[1][0]; // AIʿ��X����
            byte y = this.smallSoldierCellY[1][0]; // AIʿ��Y����
            byte s0Num = 0; // 0Ѫ����ʿ������
            byte s50Num = 0; // Ѫ�����ڵ���50��ʿ������

            // ͳ��AI����ʿ����Ѫ����Ϣ
            for (byte index = 1; index < this.aiSmallSoldierNum; index = (byte)(index + 1))
            {
                if (this.smallSoldierBlood[1][index] > 0)
                    s0Num = (byte)(s0Num + 1);
                if (this.smallSoldierBlood[1][index] >= 50)
                    s50Num = (byte)(s50Num + 1);
            }

            // ���Wֵ���ڵ���12������ݾ������AI��Ϊ
            if (this.W >= 12)
            {
                byte hmX = this.smallSoldierCellX[0][0]; // ���ʿ��X����
                byte hmY = this.smallSoldierCellY[0][0]; // ���ʿ��Y����
                byte dx = (byte)(x - hmX); // X�����
                byte dy = (byte)Math.Abs(y - hmY); // Y�����

                // ���AI�����ʿ���ľ�����������������Wֵ������AI�ж���־
                if (dx >= 1 && dx <= 3 && dy <= 1)
                {
                    this.W = (byte)(this.W - 12);
                    //this.gamecanvas.w_boolean_fld = true; // ���ò�����־��ʾAI�Ѿ��ж�
                    this.ah = 40; // �����ж����״̬
                }
                else
                {
                    byte canBoolNum = 0; // ���ж��ĸ�������

                    // ����ս���ϵ����и��ӣ���������ж��ĸ�������
                    for (byte cellY = 0; cellY < 7; cellY = (byte)(cellY + 1))
                    {
                        for (byte cellX = 0; cellX < 16; cellX = (byte)(cellX + 1))
                        {
                            if (this.smallWarCoordinate[cellY][cellX] == 64)
                            {
                                byte dsx = (byte)(x - cellX);
                                byte dsy = (byte)Math.Abs(y - cellY);
                                if (dsx >= 1 && dsx <= 3 && dsy <= 1)
                                    canBoolNum = (byte)(canBoolNum + 1);
                            }
                        }
                    }

                    bool doBool = false; // �Ƿ�����ж�

                    // ����Ѫ�����ڵ���50��ʿ�������Ϳ����ж��ĸ������������Ƿ��ж�
                    if (s50Num <= 1 && canBoolNum >= 1)
                    {
                        doBool = true;
                    }
                    else if (s50Num <= 2 && canBoolNum >= 2)
                    {
                        doBool = true;
                    }
                    else if (canBoolNum >= 3)
                    {
                        doBool = true;
                    }

                    if (doBool)
                    {
                        this.W = (byte)(this.W - 12);
                        //this.gamecanvas.w_boolean_fld = true; // ���ò�����־��ʾAI�Ѿ��ж�
                        this.ah = 40; // �����ж����״̬
                    }
                }
            }

            // ��ȡAI�����ս���е�ʿ������
            short word0 = soldierInWarNum(true);
            short word1 = soldierInWarNum(false);
            void_bv(); // ִ��AI�ĸ�������

            // ���AIδ���ó��˱�־
            if (!this.l_boolean_fld)
            {
                // ��������AIʿ�����ж�ָ��Ϊ����
                for (byte byte1 = 0; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                    this.smallSoldierOrder[1][byte1] = 1;

                // �ж��Ƿ���Ҫ����
                if (word1 > word0 * 2 || word1 >= 350)
                {
                    this.l_boolean_fld = true; // ���ó��˱�־
                }
                else
                {
                    HumanSoldierDetection(); // ִ��AI�Ľ����߼�
                }

                // �����Ҫ���ˣ�������AIʿ�����ж�ָ������Ϊ����
                if (this.l_boolean_fld)
                {
                    for (byte byte2 = 1; byte2 < this.aiSmallSoldierNum; byte2 = (byte)(byte2 + 1))
                        this.smallSoldierOrder[1][byte2] = 0;
                }
            }

            int maxsh = 0; // �������˺�ֵ

            // �����������ʿ�������˺�
            for (int j = 1; j < this.humanSmallSoldierNum; j++)
            {
                if (this.smallSoldier_isSurvive[0][j])
                {
                    int cursh = getshs(this.smallSoldierAtk[0][j], this.smallSoldierDef[1][0], this.smallSoldierBlood[0][j]);
                    maxsh += cursh;
                }
            }

            byte hm70Num = 0; // Ѫ�����ڵ���100�����ʿ������
            for (int i = 1; i < this.humanSmallSoldierNum; i++)
            {
                if (this.smallSoldierBlood[0][i] >= 100)
                    hm70Num = (byte)(hm70Num + 1);
            }

            // ������ҵ�ǰ״̬��AI״̬����AI�Ĳ���
            if (GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() - 35 > maxsh && (hm70Num < 3 || maxsh < 25) && !aiGenchetui1())
            {
                if (maibeSingleAtk2() && aiGenchetui1())
                {
                    this.smallSoldierOrder[1][0] = 1; // ����
                }
                else
                {
                    this.smallSoldierOrder[1][0] = 0; // ����
                }
            }
            else
            {
                this.smallSoldierOrder[1][0] = 1; // ����
            }

            // AI�����ж�
            if (aiGenchetui())
                this.smallSoldierOrder[1][0] = 2;

            if ((aiGenchetui1() && word1 < 100) || (maibeSingleAtk() && aiGenchetui1()))
                this.smallSoldierOrder[1][0] = 2;

            // ���AI�ܹ�����ʤ���ҽӽ����ʿ��������е���
            if (canSingleWin() && canNearSingle())
                this.smallSoldierOrder[1][0] = 0;
        }

        /// <summary>
        /// �ж�AI�Ƿ��ܹ�������ʤ
        /// </summary>
        /// <returns></returns>
        bool canSingleWin()
        {
            if (GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() < getAtkDea(this.HMGeneralId, this.HMSingleAtk, this.AISingleDef) + 1)
                return false;
            if (IsSuccessOfCompetition())
                return true;
            return false;
        }

        /// <summary>
        /// �ж�AI�Ƿ�ӽ����Ե�����λ��
        /// </summary>
        /// <returns></returns>
        bool canNearSingle()
        {
            byte aix = this.smallSoldierCellX[1][0]; // AIʿ��X����
            byte aiy = this.smallSoldierCellY[1][0]; // AIʿ��Y����
            byte hmx = this.smallSoldierCellX[0][0]; // ���ʿ��X����
            byte hmy = this.smallSoldierCellY[0][0]; // ���ʿ��Y����

            if (this.aq > 0) // ���AQֵ����0����������
                return false;

            // �ж�AI�Ƿ���Խӽ����ʿ��
            if (aix > hmx)
            {
                if (aix - hmx == 2 && aiy == hmy && this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                    return true;
                if (aix - hmx == 1 && aiy - hmy == 1 && this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                    return true;
                if (aix - hmx == 1 && hmy - aiy == 1 && this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                    return true;
            }
            else if (aix == hmx)
            {
                if (Math.Abs(aiy - hmy) <= 2)
                    return true;
            }
            else
            {
                if (hmx - aix == 2 && hmy == aiy)
                    return true;
                if (hmx - aix == 1 && Math.Abs(aiy - hmy) <= 2)
                    return true;
            }
            return false;
        }


        // ����Ƿ��ܹ�ʹ����������
        bool maibebaowei(short hurt)
        {
            byte aix = this.smallSoldierCellX[1][0];
            byte aiy = this.smallSoldierCellY[1][0];
            bool flag = false;

            // ����ս������
            for (int celly = 0; celly < 7; celly++)
            {
                for (int cellx = 0; cellx < 16; cellx++)
                {
                    if (this.smallWarCoordinate[celly][cellx] == 64 && (this.coodinateSoldierKind[celly][cellx] == 0 || this.coodinateSoldierKind[celly][cellx] == 1))
                    {
                        // ����Ƿ��ڱ�����Χ��
                        if (aix == cellx && Mathf.Abs(celly - aiy) == 1)
                        {
                            flag = true;
                            break;
                        }
                        if (cellx == aix + 1 && Mathf.Abs(celly - aiy) <= 2)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }

            General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId);
            if (aiGeneral.getCurPhysical() - hurt - 15 < 0 && flag)
                return true;

            byte curps = aiGeneral.getCurPhysical();
            aiGeneral.decreaseCurPhysical((byte)hurt);
            if (aiGeneral.getCurPhysical() < 1)
                aiGeneral.setCurPhysical((byte)1);

            if (aiGenchetui1() && flag)
            {
                aiGeneral.setCurPhysical(curps);
                return true;
            }

            aiGeneral.setCurPhysical(curps);
            return false;
        }

        // ��ȡ��ս���е�ʿ������
        short soldierInWarNum(bool ishm)
        {
            short num = 0;

            if (ishm)
            {
                for (byte index = 1; index < this.humanSmallSoldierNum; index = (byte)(index + 1))
                {
                    if (this.smallSoldier_isSurvive[0][index])
                        num = (short)(num + this.smallSoldierBlood[0][index]);
                }
            }
            else
            {
                for (byte index = 1; index < this.aiSmallSoldierNum; index = (byte)(index + 1))
                {
                    if (this.smallSoldier_isSurvive[1][index])
                        num = (short)(num + this.smallSoldierBlood[1][index]);
                }
            }

            return num;
        }

        // AI ����Χ��
        void aiSiege(int turns)
        {
            byte x = this.smallSoldierCellX[1][0];
            byte y = this.smallSoldierCellY[1][0];
            byte s0Num = 0;
            byte s50Num = 0;

            // ͳ�� AI С��״̬
            for (byte index = 1; index < this.aiSmallSoldierNum; index = (byte)(index + 1))
            {
                if (this.smallSoldier_isSurvive[1][index])
                {
                    if (this.smallSoldierBlood[1][index] > 0)
                        s0Num = (byte)(s0Num + 1);
                    if (this.smallSoldierBlood[1][index] >= 50)
                        s50Num = (byte)(s50Num + 1);
                }
            }

            if (this.W >= 12)
            {
                byte hmX = this.smallSoldierCellX[0][0];
                byte hmY = this.smallSoldierCellY[0][0];
                byte dx = (byte)(x - hmX);
                byte dy = (byte)Mathf.Abs(y - hmY);

                if (dx >= 1 && dx <= 3 && dy <= 1)
                {
                    this.W = (byte)(this.W - 12);
                    //this.gamecanvas.w_boolean_fld = true;
                    this.ah = 40;
                }
                else
                {
                    byte canBoolNum = 0;
                    for (byte cellY = 0; cellY < 7; cellY = (byte)(cellY + 1))
                    {
                        for (byte cellX = 0; cellX < 16; cellX = (byte)(cellX + 1))
                        {
                            if (this.smallWarCoordinate[cellY][cellX] == 64)
                            {
                                byte dsx = (byte)(x - cellX);
                                byte dsy = (byte)Mathf.Abs(y - cellY);
                                if (dsx >= 1 && dsx <= 3 && dsy <= 1)
                                    canBoolNum = (byte)(canBoolNum + 1);
                            }
                        }
                    }

                    bool doBool = false;
                    if (s50Num <= 1 && canBoolNum >= 1)
                    {
                        doBool = true;
                    }
                    else if (s50Num <= 2 && canBoolNum >= 2)
                    {
                        doBool = true;
                    }
                    else if (canBoolNum >= 3)
                    {
                        doBool = true;
                    }

                    if (doBool)
                    {
                        this.W = (byte)(this.W - 12);
                        //this.gamecanvas.w_boolean_fld = true;
                        this.ah = 40;
                    }
                }
            }

            short hmsoldier = soldierInWarNum(true);
            short word0 = soldierInWarNum(false);
            aiCastleDefUseZhanshu();

            for (byte byte1 = 1; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                this.smallSoldierOrder[1][byte1] = 0;
            this.smallSoldierOrder[1][0] = 1;

            byte aiAtcherNum = 0;
            for (byte aiIndex = 1; aiIndex < this.aiSmallSoldierNum; aiIndex = (byte)(aiIndex + 1))
            {
                if (this.smallSoldier_isSurvive[1][aiIndex] && this.smallSoldierKind[1][aiIndex] == 2)
                    aiAtcherNum = (byte)(aiAtcherNum + 1);
            }

            byte hmAtcherNum = 0;
            for (int hmIndex = 1; hmIndex < this.humanSmallSoldierNum; hmIndex++)
            {
                if (this.smallSoldier_isSurvive[0][hmIndex] && this.smallSoldierKind[0][hmIndex] == 2)
                    hmAtcherNum = (byte)(hmAtcherNum + 1);
            }

            if (hmAtcherNum >= 2 && aiAtcherNum <= 1)
                for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
                {
                    if (this.smallSoldier_isSurvive[1][i] && this.smallSoldierKind[1][i] == 3 && this.smallSoldierCellX[1][i] >= 8 && !sroundCanAtk(this.smallSoldierCellX[1][i], this.smallSoldierCellY[1][i]))
                        this.smallSoldierOrder[1][i] = 2;
                }

            if (word0 < 100 || aiGenchetui() || (maibeSingleAtk() && aiGenchetui1()))
                this.smallSoldierOrder[1][0] = 2;

            if (hmsoldier <= 100 && !aiGenchetui1())
                this.smallSoldierOrder[1][0] = 0;
        }


        // ���������� (x, y) �Ƿ���Ա�����
        bool sroundCanAtk(byte x, byte y)
        {
            if (x < 15 && x > 0)
            {
                if (y == 0)
                {
                    // ����ϡ��¡��������������Ƿ�ɹ���
                    if (this.smallWarCoordinate[y][x - 1] == 64 ||
                        this.smallWarCoordinate[y][x + 1] == 64 ||
                        this.smallWarCoordinate[y + 1][x] == 64)
                        return true;
                }
                else if (y == 6)
                {
                    // ����ϡ��¡��������������Ƿ�ɹ���
                    if (this.smallWarCoordinate[y][x - 1] == 64 ||
                        this.smallWarCoordinate[y][x + 1] == 64 ||
                        this.smallWarCoordinate[y - 1][x] == 64)
                        return true;
                }
                else
                {
                    // ����ϡ��¡��������������Ƿ�ɹ���
                    if (this.smallWarCoordinate[y][x - 1] == 64 ||
                        this.smallWarCoordinate[y][x + 1] == 64 ||
                        this.smallWarCoordinate[y - 1][x] == 64 ||
                        this.smallWarCoordinate[y + 1][x] == 64)
                        return true;
                }
            }
            return false;
        }

        // AI ����Χ������
        void aiDefSiege(int turns)
        {
            byte x = this.smallSoldierCellX[1][0];
            byte y = this.smallSoldierCellY[1][0];
            byte s0Num = 0;
            byte s50Num = 0;

            // ͳ�� AI С����Ѫ��
            for (byte index = 1; index < this.aiSmallSoldierNum; index = (byte)(index + 1))
            {
                if (this.smallSoldierBlood[1][index] > 0)
                    s0Num = (byte)(s0Num + 1);
                if (this.smallSoldierBlood[1][index] >= 50)
                    s50Num = (byte)(s50Num + 1);
            }

            byte hmX = this.smallSoldierCellX[0][0];
            byte hmY = this.smallSoldierCellY[0][0];

            if (this.W >= 12)
            {
                byte dx = (byte)(x - hmX);
                byte dy = (byte)Mathf.Abs(y - hmY);

                if (dx >= 1 && dx <= 3 && dy <= 1)
                {
                    this.W = (byte)(this.W - 12);
                    //this.gamecanvas.w_boolean_fld = true;
                    this.ah = 40;
                }
                else
                {
                    byte canBoolNum = 0;

                    // ����Ƿ��п��Թ����ķ�Χ
                    for (byte cellY = 0; cellY < 7; cellY = (byte)(cellY + 1))
                    {
                        for (byte cellX = 0; cellX < 16; cellX = (byte)(cellX + 1))
                        {
                            if (this.smallWarCoordinate[cellY][cellX] == 64)
                            {
                                byte dsx = (byte)(x - cellX);
                                byte dsy = (byte)Mathf.Abs(y - cellY);
                                if (dsx >= 1 && dsx <= 3 && dsy <= 1)
                                    canBoolNum = (byte)(canBoolNum + 1);
                            }
                        }
                    }

                    bool doBool = false;
                    if (s50Num <= 1 && canBoolNum >= 1)
                    {
                        doBool = true;
                    }
                    else if (s50Num <= 2 && canBoolNum >= 2)
                    {
                        doBool = true;
                    }
                    else if (canBoolNum >= 3)
                    {
                        doBool = true;
                    }

                    if (doBool)
                    {
                        this.W = (byte)(this.W - 12);
                        //this.gamecanvas.w_boolean_fld = true;
                        this.ah = 40;
                    }
                }
            }

            short hmSoldierNum = soldierInWarNum(true);
            short aiSoldierNum = soldierInWarNum(false);
            aiCastleDefUseZhanshu();

            // ��ʼ��С������
            for (byte byte2 = 0; byte2 < this.aiSmallSoldierNum; byte2 = (byte)(byte2 + 1))
                this.smallSoldierOrder[1][byte2] = 1;

            byte aiAtcherNum = 0;
            for (byte aiIndex = 1; aiIndex < this.aiSmallSoldierNum; aiIndex = (byte)(aiIndex + 1))
            {
                if (this.smallSoldier_isSurvive[1][aiIndex] && this.smallSoldierKind[1][aiIndex] == 2)
                    aiAtcherNum = (byte)(aiAtcherNum + 1);
            }

            byte hmAtcherNum = 0;
            for (int hmIndex = 1; hmIndex < this.humanSmallSoldierNum; hmIndex++)
            {
                if (this.smallSoldier_isSurvive[0][hmIndex] && this.smallSoldierKind[0][hmIndex] == 2)
                    hmAtcherNum = (byte)(hmAtcherNum + 1);
            }

            // ���ݹ����ֵ���������С���Ĺ�������
            if (hmAtcherNum >= 1 && aiAtcherNum <= 1)
                for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
                {
                    if (this.smallSoldier_isSurvive[1][i] && this.smallSoldierKind[1][i] == 3 && !sroundCanAtk(this.smallSoldierCellX[1][i], this.smallSoldierCellY[1][i]))
                        this.smallSoldierOrder[1][i] = 2;
                }

            if (getSkill_2(this.HMGeneralId, 6))
                for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
                {
                    if (this.smallSoldier_isSurvive[1][i] && this.smallSoldierKind[1][i] == 2)
                        this.smallSoldierOrder[1][i] = 0;
                }

            if (hmX >= 9)
                for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
                {
                    if (this.smallSoldier_isSurvive[1][i] && this.smallSoldierKind[1][i] == 2)
                        this.smallSoldierOrder[1][i] = 0;
                }

            if (aiAtcherNum == 0 && hmAtcherNum > 0)
                this.smallSoldierOrder[1][0] = 2;

            if ((aiSoldierNum < 100 && (hmSoldierNum > 450 || hmAtcherNum >= 1)) || aiGenchetui() || (maibeSingleAtk() && aiGenchetui1()))
                this.smallSoldierOrder[1][0] = 2;
        }


        // �ж��Ƿ���Ե��ι���
        bool maibeSingleAtk()
        {
            byte aix = this.smallSoldierCellX[1][0];
            byte aiy = this.smallSoldierCellY[1][0];
            byte hmx = this.smallSoldierCellX[0][0];
            byte hmy = this.smallSoldierCellY[0][0];

            // �ж������Ƿ����㹥��
            if (aix > hmx)
            {
                if (aix - hmx == 2 && aiy == hmy && this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                    return true;
                if (aix - hmx == 1 && aiy == hmy)
                    return true;
                if (aix - hmx == 1 && aiy - hmy == 1 && this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                    return true;
                if (aix - hmx == 1 && hmy - aiy == 1 && this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                    return true;
            }
            else if (aix == hmx)
            {
                // �ж���������Ƿ�С�ڵ��� 2
                if (Mathf.Abs(aiy - hmy) <= 2)
                    return true;
            }
            else
            {
                if (hmx - aix == 2 && hmy == aiy)
                    return true;
                if (hmx - aix == 1 && Mathf.Abs(aiy - hmy) <= 2)
                    return true;
            }
            return false;
        }

        // �ж��Ƿ���Խ��е��ι�������һ�������
        bool maibeSingleAtk2()
        {
            byte aix = this.smallSoldierCellX[1][0];
            byte aiy = this.smallSoldierCellY[1][0];
            byte hmx = this.smallSoldierCellX[0][0];
            byte hmy = this.smallSoldierCellY[0][0];

            // �ж������پ����Ƿ�С�ڵ��� 3
            if (Mathf.Abs(aix - hmx) + Mathf.Abs(aiy - hmy) <= 3)
                return true;
            return false;
        }

        // ���㹭�����ܹ���������
        void archerCanAtkNum()
        {
            byte aNum = 0; // ����������
            byte longAtkNum = 0; // �����빥������
            byte longAtkaNum = 0; // �������빥��������

            // ��������С��
            for (int index = 1; index < this.aiSmallSoldierNum; index++)
            {
                if (this.smallSoldier_isSurvive[1][index] && this.smallSoldierKind[1][index] == 2)
                {
                    aNum = (byte)(aNum + 1);
                    for (byte i = 1; i < 7;)
                    {
                        byte x = (byte)(this.smallSoldierCellX[1][index] - i);
                        byte y = this.smallSoldierCellY[1][index];
                        if (x < 0)
                            break;
                        if (this.smallWarCoordinate[y][x] == 64 && i >= 5)
                        {
                            longAtkNum = (byte)(longAtkNum + 1);
                        }
                        else
                        {
                            if (this.smallWarCoordinate[y][x] == 64)
                                break;
                            i = (byte)(i + 1);
                        }
                        for (int hmindex = 1; hmindex < this.humanSmallSoldierNum; hmindex++)
                        {
                            if (this.smallSoldier_isSurvive[0][hmindex] && this.smallSoldierCellX[0][hmindex] == x && this.smallSoldierCellY[0][hmindex] == y && this.smallSoldierKind[0][hmindex] == 2)
                                longAtkaNum = (byte)(longAtkaNum + 1);
                        }
                        break;
                    }
                }
            }

            // �ж��Ƿ���Խ��й���
            if (this.W < 8)
            {
                if (aNum > 0 && longAtkNum >= aNum / 3 + 1)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
            }
            else
            {
                if (aNum > 1 && longAtkNum == aNum / 2 + 1)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
                if (aNum == 1 && longAtkNum >= aNum)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
            }
        }

        // ������湥��������
        byte fireAtk()
        {
            byte canAtkNum = 0;

            // ��������С��
            for (int index = 1; index < this.aiSmallSoldierNum; index++)
            {
                if (this.smallSoldier_isSurvive[1][index] && this.smallSoldierKind[1][index] == 2)
                {
                    byte x = this.smallSoldierCellX[1][index];
                    byte y = this.smallSoldierCellY[1][index];

                    // ����������ҵĹ�����Χ
                    for (int d = 1; d < 5; d++)
                    {
                        if (x > d - 1)
                        {
                            byte hx = (byte)(this.smallSoldierCellX[1][index] - d);
                            byte hy = this.smallSoldierCellY[1][index];
                            if (this.smallWarCoordinate[hy][hx] == 64)
                            {
                                if (this.coodinateSoldierKind[hy][hx] == 2)
                                    canAtkNum = (byte)(canAtkNum + 1);
                                canAtkNum = (byte)(canAtkNum + 1);
                                break;
                            }
                        }
                        if (y > d - 1)
                        {
                            byte hx = this.smallSoldierCellX[1][index];
                            byte hy = (byte)(this.smallSoldierCellY[1][index] - d);
                            if (this.smallWarCoordinate[hy][hx] == 64)
                            {
                                if (this.coodinateSoldierKind[hy][hx] == 2)
                                    canAtkNum = (byte)(canAtkNum + 1);
                                canAtkNum = (byte)(canAtkNum + 1);
                                break;
                            }
                        }
                        if (y < 7 - d)
                        {
                            byte hx = this.smallSoldierCellX[1][index];
                            byte hy = (byte)(this.smallSoldierCellY[1][index] + d);
                            if (this.smallWarCoordinate[hy][hx] == 64)
                            {
                                if (this.coodinateSoldierKind[hy][hx] == 2)
                                    canAtkNum = (byte)(canAtkNum + 1);
                                canAtkNum = (byte)(canAtkNum + 1);
                                break;
                            }
                        }
                    }
                }
            }
            return canAtkNum;
        }


        // ������Խ����ɺ�����������
        byte defNaHanAtk()
        {
            byte canAtkNum = 0;

            // ��������С��
            for (int index = 0; index < this.aiSmallSoldierNum; index++)
            {
                if (this.smallSoldier_isSurvive[1][index])
                {
                    byte x = this.smallSoldierCellX[1][index];
                    byte y = this.smallSoldierCellY[1][index];

                    // �ж�С�����ͣ����������Χ�Ƿ��пɹ�����Ŀ��
                    if (this.smallSoldierKind[1][index] == 0 || this.smallSoldierKind[1][index] == 1 || this.smallSoldierKind[1][index] == 3)
                    {
                        if (x > 0 && this.smallWarCoordinate[y][x - 1] == 64)
                        {
                            if (this.coodinateSoldierKind[y][x - 1] == 2)
                                canAtkNum = (byte)(canAtkNum + 1);
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y > 0 && this.smallWarCoordinate[y - 1][x] == 64)
                        {
                            if (this.coodinateSoldierKind[y - 1][x] == 2)
                                canAtkNum = (byte)(canAtkNum + 1);
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y < 6 && this.smallWarCoordinate[y + 1][x] == 64)
                        {
                            if (this.coodinateSoldierKind[y + 1][x] == 2)
                                canAtkNum = (byte)(canAtkNum + 1);
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                    }
                    else
                    {
                        // ���С����Χ�ĳ����빥����Χ
                        for (int d = 1; d < 5; d++)
                        {
                            if (x > d - 1)
                            {
                                byte hx = (byte)(this.smallSoldierCellX[1][index] - d);
                                byte hy = this.smallSoldierCellY[1][index];
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    if (this.coodinateSoldierKind[hy][hx] == 2)
                                        canAtkNum = (byte)(canAtkNum + 1);
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                            if (y > d - 1)
                            {
                                byte hx = this.smallSoldierCellX[1][index];
                                byte hy = (byte)(this.smallSoldierCellY[1][index] - d);
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    if (this.coodinateSoldierKind[hy][hx] == 2)
                                        canAtkNum = (byte)(canAtkNum + 1);
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                            if (y < 7 - d)
                            {
                                byte hx = this.smallSoldierCellX[1][index];
                                byte hy = (byte)(this.smallSoldierCellY[1][index] + d);
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    if (this.coodinateSoldierKind[hy][hx] == 2)
                                        canAtkNum = (byte)(canAtkNum + 1);
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return canAtkNum;
        }

        // AI �Ǳ�����ʹ��ս��
        void aiCastleDefUseZhanshu()
        {
            byte unitNum = 0; // С������
            byte actherNum = 0; // ����������

            // ͳ�ƴ���С�������͹���������
            for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
            {
                if (this.smallSoldier_isSurvive[1][i])
                {
                    unitNum = (byte)(unitNum + 1);
                    if (this.smallSoldierKind[1][i] == 2)
                        actherNum = (byte)(actherNum + 1);
                }
            }

            // ���ݲ�ͬ����ѡ��ս��
            if (this.W >= 10)
            {
                byte fireNum = fireAtk();
                if (fireNum >= actherNum / 3 + 1)
                {
                    this.W = (byte)(this.W - 10);
                    this.ab = 83;
                    return;
                }
                if (fireNum >= 2 && actherNum <= 2)
                {
                    this.W = (byte)(this.W - 10);
                    this.ab = 83;
                    return;
                }
                if (fireNum == 1 && actherNum == 1)
                {
                    this.W = (byte)(this.W - 10);
                    this.ab = 83;
                    return;
                }
            }
            else if (this.W >= 8)
            {
                byte nahanNum = defNaHanAtk();
                if (nahanNum >= unitNum / 3 + 1 && unitNum >= 3)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }
                aatkNum();
                if (this.W >= 8 && nahanNum >= unitNum / 2 + 1 && unitNum >= 2)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }
                if (this.W >= 8 && nahanNum >= unitNum && unitNum >= 1)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }
            }
            else if (this.W >= 7)
            {
                aatkNum();
            }
        }

        // AI ����ָ��
        byte AISingleOrder(short aigeneralId, short hmgeneralId)
        {
            // �ж��Ƿ���Խ��й���
            if (singlePin(aigeneralId, hmgeneralId, this.AISingleAtk, this.HMSingleDef) >= GeneralListCache.GetGeneral(hmgeneralId).getCurPhysical())
                return 0;
            if (getAtkDea(aigeneralId, this.AISingleAtk, this.HMSingleDef) >= GeneralListCache.GetGeneral(hmgeneralId).getCurPhysical())
                return 1;
            if (GeneralListCache.GetGeneral(aigeneralId).getCurPhysical() < 20 || getAtkDea(hmgeneralId, this.HMSingleAtk, this.AISingleDef) >= GeneralListCache.GetGeneral(aigeneralId).getCurPhysical())
                return 4;
            if (GeneralListCache.GetGeneral(aigeneralId).getCurPhysical() > 35 && getPercentage(aigeneralId, hmgeneralId, true, false) >= 30 && getAllAtkDea(aigeneralId, this.AISingleAtk, this.HMSingleDef) >= GeneralListCache.GetGeneral(hmgeneralId).getCurPhysical() && getAtkDea(aigeneralId, this.AISingleAtk, this.HMSingleDef) + 5 < getAtkDea(hmgeneralId, this.HMSingleAtk, this.AISingleDef) && GeneralListCache.GetGeneral(aigeneralId).getCurPhysical() + 10 < GeneralListCache.GetGeneral(hmgeneralId).getCurPhysical() && getPercentage(aigeneralId, hmgeneralId, true, false) >= CommonUtils.getRandomInt() % 40)
                return 2;
            int qw = getPercentage(aigeneralId, hmgeneralId, false, false) * getAtkDea(aigeneralId, this.AISingleAtk, this.HMSingleDef) / 100;
            if (qw > singlePin(aigeneralId, hmgeneralId, this.AISingleAtk, this.HMSingleDef) + 1)
                return 1;
            return 0;
        }


    
    }


