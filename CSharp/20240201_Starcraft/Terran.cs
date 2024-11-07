using Sonji;
using System;
using System.Threading;
using static Sonji.Program;
using static SonJiTerran.Terran.TBuilding;
using System.Timers;

namespace SonJiTerran
{
    


    public class Terran {

        ///�׶�(Terran)--------------------------------------------------------------------------------------------------


        public class Tribe : GameObject
        {
            public int groundAtk = 0; // ���� ���ݷ�
            public int airAtk = 0; // ���� ����
            public int armor = 0; //����     
            public int range = 0; // ���ݻ�Ÿ�
            public int sight = 0; // �þ�
            public int buildTime = 0; // ����ӵ�
            public int attackSpeed = 0; // ���ݼӵ�
            public float moveSpeed = 0.0f; // �̵��ӵ�
            public bool isfly = false; // ���� ����
            
        }
    public class TerranBase : Tribe
        {
            public int minerals = 0; // �Ҹ� �̳׶�
            public int gas = 0; //�Ҹ� ����
            public int pop = 1; // �Ҹ� �α���


        }

    public class TBuilding : TerranBase { 
        public class Command_Center : TBuilding
            {
                public Command_Center()
                {
                    curHp = 1500; //����ü��
                    maxHp = 1500; // �ִ�ü��
                    minerals = 400; // �Ҹ� �̳׶�
                    gas = 0; //�Ҹ� ����
                    pop = -10; // �Ҹ� �α���
                    groundAtk = 0; // ���� ���ݷ�
                    airAtk = 0; // ���� ����
                    armor = 1; //����     
                    range = 0; // ���� ��Ÿ�
                    sight = 10; // �þ�
                    buildTime = 120; // ���� �ӵ�
                    attackSpeed = 0; // ���� �ӵ�
                    moveSpeed = 0.0f; // �̵� �ӵ�
                    isfly = false; // ���� ����                    
                }
                public void Command_center_Lift(bool value)
                {
                    if(value == true)
                    {
                        moveSpeed = moveSpeed +1;
                    }
                    else
                    {
                        moveSpeed = moveSpeed -1;
                    }

                }

            }

            public class Comsat_Station : TBuilding
            {
                public Comsat_Station()
                {
                    base.curHp = 500; //����ü��
                    base.maxHp = 500; // �ִ�ü��
                    base.minerals = 50; // �Ҹ� �̳׶�
                    base.gas = 50; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 10; // �þ�
                    base.buildTime = 40; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Nuclear_Silo : TBuilding
            {
                public Nuclear_Silo()
                {
                    base.curHp = 600; //����ü��
                    base.maxHp = 600; // �ִ�ü��
                    base.minerals = 100; // �Ҹ� �̳׶�
                    base.gas = 100; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 8; // �þ�
                    base.buildTime = 80; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Supply_Depot : TBuilding
            {
                public Supply_Depot()
                {
                    base.curHp = 500; //����ü��
                    base.maxHp = 500; // �ִ�ü��
                    base.minerals = 100; // �Ҹ� �̳׶�
                    base.gas = 0; //�Ҹ� ����
                    base.pop = -8; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 8; // �þ�
                    base.buildTime = 40; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Refiery : TBuilding
            {
                public Refiery()
                {
                    base.curHp = 750; //����ü��
                    base.maxHp = 750; // �ִ�ü��
                    base.minerals = 100; // �Ҹ� �̳׶�
                    base.gas = 0; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 8; // �þ�
                    base.buildTime = 40; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Academy : TBuilding
            {
                public Academy()
                {
                    base.curHp = 600; //����ü��
                    base.maxHp = 600; // �ִ�ü��
                    base.minerals = 150; // �Ҹ� �̳׶�
                    base.gas = 0; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 8; // �þ�
                    base.buildTime = 80; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ���Τ�                    
                }


            }
            public class Engineering_bay : TBuilding
            {
                public Engineering_bay()
                {
                    base.curHp = 850; //����ü��
                    base.maxHp = 850; // �ִ�ü��
                    base.minerals = 125; // �Ҹ� �̳׶�
                    base.gas = 0; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 8; // �þ�
                    base.buildTime = 60; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Misiile_Turret : TBuilding
            {

                public Misiile_Turret()
                {
                    base.curHp = 200; //����ü��
                    base.maxHp = 200; // �ִ�ü��
                    base.minerals = 75; // �Ҹ� �̳׶�
                    base.gas = 0; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 20; // ���� ����
                    base.armor = 0; //����     
                    base.range = 7; // ���� ��Ÿ�
                    base.sight = 11; // �þ�
                    base.buildTime = 40; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Bunker : TBuilding
            {
                public Bunker()
                {
                    base.curHp = 350; //����ü��
                    base.maxHp = 350; // �ִ�ü��
                    base.minerals = 100; // �Ҹ� �̳׶�
                    base.gas = 0; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 10; // �þ�
                    base.buildTime = 30; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Factory : TBuilding
            {
                public Factory()
                {
                    base.curHp = 1250; //����ü��
                    base.maxHp = 125; // �ִ�ü��
                    base.minerals = 200; // �Ҹ� �̳׶�
                    base.gas = 100; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 8; // �þ�
                    base.buildTime = 80; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Machine_shop : TBuilding
            {
                public Machine_shop()
                {
                    base.curHp = 750; //����ü��
                    base.maxHp = 750; // �ִ�ü��
                    base.minerals = 50; // �Ҹ� �̳׶�
                    base.gas = 50; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 8; // �þ�
                    base.buildTime = 40; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class StarPort : TBuilding
            {
                public StarPort()
                {
                    base.curHp = 1300; //����ü��
                    base.maxHp = 1300; // �ִ�ü��
                    base.minerals = 150; // �Ҹ� �̳׶�
                    base.gas = 100; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 10; // �þ�
                    base.buildTime = 70; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Control_Tower : TBuilding
            {
                public Control_Tower()
                {
                    base.curHp = 500; //����ü��
                    base.maxHp = 500; // �ִ�ü��
                    base.minerals = 50; // �Ҹ� �̳׶�
                    base.gas = 50; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 8; // �þ�
                    base.buildTime = 40; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Science_Facility : TBuilding
            {
                public Science_Facility()
                {
                    base.curHp = 850; //����ü��
                    base.maxHp = 850; // �ִ�ü��
                    base.minerals = 100; // �Ҹ� �̳׶�
                    base.gas = 50; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 8; // �þ�
                    base.buildTime = 80; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Physics_Lab : TBuilding
            {
                public Physics_Lab()
                {
                    base.curHp = 600; //����ü��
                    base.maxHp = 600; // �ִ�ü��
                    base.minerals = 50; // �Ҹ� �̳׶�
                    base.gas = 50; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 8; // �þ�
                    base.buildTime = 40; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
            public class Covert_Ops : TBuilding
            {
                public Covert_Ops()
                {
                    base.curHp = 750; //����ü��
                    base.maxHp = 750; // �ִ�ü��
                    base.minerals = 50; // �Ҹ� �̳׶�
                    base.gas = 50; //�Ҹ� ����
                    base.pop = 0; // �Ҹ� �α���
                    base.groundAtk = 0; // ���� ���ݷ�
                    base.airAtk = 0; // ���� ����
                    base.armor = 1; //����     
                    base.range = 0; // ���� ��Ÿ�
                    base.sight = 8; // �þ�
                    base.buildTime = 40; // ���� �ӵ�
                    base.attackSpeed = 0; // ���� �ӵ�
                    base.moveSpeed = 0.0f; // �̵� �ӵ�
                    base.isfly = false; // ���� ����
                }
            }
    }
        public class SCV : TerranBase
    {
        public SCV()
        {
            base.curHp = 60; //����ü��
            base.maxHp = 60; // �ִ�ü��
            base.minerals = 50; // �Ҹ� �̳׶�
            base.gas = 0; //�Ҹ� ����
            base.pop = 1; // �Ҹ� �α���
            base.groundAtk = 5; // ���� ���ݷ�
            base.airAtk = 0; // ���� ����
            base.armor = 0; //����     
            base.range = 1; // ���ݻ�Ÿ�
            base.sight = 7; // �þ�
            base.buildTime = 20; // ����ӵ�
            base.attackSpeed = 15; // ���ݼӵ�
            base.moveSpeed = 2.344f; // �̵��ӵ�
            base.isfly = false; // ���� ����
        }
    }
    public class Marine : TerranBase
    {
        public Marine()
        {
            base.curHp = 40; //����ü��
            base.maxHp = 40; // �ִ�ü��
            base.minerals = 50; // �Ҹ� �̳׶�
            base.gas = 0; //�Ҹ� ����
            base.pop = 1; // �Ҹ� �α���
            base.groundAtk = 6; // ���� ���ݷ�
            base.airAtk = 6; // ���� ����
            base.armor = 0; //����     
            base.range = 4; // ���ݻ�Ÿ�
            base.sight = 7; // �þ�
            base.buildTime = 24; // ����ӵ�
            base.attackSpeed = 15; // ���ݼӵ�
            base.moveSpeed = 1.875f; // �̵��ӵ�
            base.isfly = true; // ���� ����
        }
            public float Marine_StimPack()
            {
                moveSpeed = moveSpeed + 0.9375f;
                Console.WriteLine("���� ������ ���(Ah! That's the stuff!)");
                return moveSpeed + 0.9375f;
            }
        }

    public class FireBat : TerranBase
    {
        public FireBat()
        {
                base.curHp = 50; //����ü��
                base.maxHp = 50; // �ִ�ü��
                base.minerals = 50; // �Ҹ� �̳׶�
                base.gas = 25; //�Ҹ� ����
                base.pop = 1; // �Ҹ� �α���
                base.groundAtk = 9 * 2; // ���� ���ݷ�
                base.airAtk = 6; // ���� ����
                base.armor = 0; //����     
                base.range = 4; // ���ݻ�Ÿ�
                base.sight = 7; // �þ�
                base.buildTime = 24; // ����ӵ�
                base.attackSpeed = 15; // ���ݼӵ�
                base.moveSpeed = 1.875f; // �̵��ӵ�
                base.isfly = false; // ���� ����
            }
    }

    public class Ghost : TerranBase
    {
        public Ghost()
        {
                base.curHp = 45; //����ü��
                base.maxHp = 45; // �ִ�ü��
                base.minerals = 25; // �Ҹ� �̳׶�
                base.gas = 75; //�Ҹ� ����
                base.pop = 1; // �Ҹ� �α���
                base.groundAtk = 10; // ���� ���ݷ�
                base.airAtk = 10; // ���� ����
                base.armor = 0; //����     
                base.range = 7; // ���ݻ�Ÿ�
                base.sight = 9; // �þ�
                base.buildTime = 50; // ����ӵ�
                base.attackSpeed = 22; // ���ݼӵ�
                base.moveSpeed = 1.875f; // �̵��ӵ�
                base.isfly = true; // ���� ����
            }
    }

    public class Medic : TerranBase
    {
        public Medic()
        {
                base.curHp = 60; //����ü��
                base.maxHp = 60; // �ִ�ü��
                base.minerals = 50; // �Ҹ� �̳׶�
                base.gas = 25; //�Ҹ� ����
                base.pop = 1; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; //����     
                base.range = 0; // ���ݻ�Ÿ�
                base.sight = 9; // �þ�
                base.buildTime = 30; // ����ӵ�
                base.attackSpeed = 0; // ���ݼӵ�
                base.moveSpeed = 1.875f; // �̵��ӵ�
                base.isfly = false; // ���� ����
            }
    }

    public class Vulture : TerranBase
    {
        public Vulture()
        {
                base.curHp = 80; //����ü��
                base.maxHp = 80; // �ִ�ü��
                base.minerals = 75; // �Ҹ� �̳׶�
                base.gas = 0; //�Ҹ� ����
                base.pop = 2; // �Ҹ� �α���
                base.groundAtk = 20; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 0; //����     
                base.range = 5; // ���ݻ�Ÿ�
                base.sight = 8; // �þ�
                base.buildTime = 30; // ����ӵ�
                base.attackSpeed = 30; // ���ݼӵ�
                base.moveSpeed = 3.126f; // �̵��ӵ�
                base.isfly = false; // ���� ����
        }
    }

    public class Tank : TerranBase
    {
        public Tank()
        {
                base.curHp = 150; //����ü��
                base.maxHp = 150; // �ִ�ü��
                base.minerals = 150; // �Ҹ� �̳׶�
                base.gas = 100; //�Ҹ� ����
                base.pop = 2; // �Ҹ� �α���
                base.groundAtk = 30; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; //����     
                base.range = 7; // ���ݻ�Ÿ�
                base.sight = 10; // �þ�
                base.buildTime = 50; // ����ӵ�
                base.attackSpeed = 37; // ���ݼӵ�
                base.moveSpeed = 1.875f; // �̵��ӵ�
                base.isfly = false; // ���� ����
        }

    }

    public class Goliath : TerranBase
    {
        public Goliath()
        {
                base.curHp = 125; //����ü��
                base.maxHp = 125; // �ִ�ü��
                base.minerals = 100; // �Ҹ� �̳׶�
                base.gas = 50; //�Ҹ� ����
                base.pop = 2; // �Ҹ� �α���
                base.groundAtk = 12; // ���� ���ݷ�
                base.airAtk = 10 * 2; // ���� ����
                base.armor = 1; //����     
                base.range = 8; // ���ݻ�Ÿ�
                base.sight = 8; // �þ�
                base.buildTime = 40; // ����ӵ�
                base.attackSpeed = 22; // ���ݼӵ�
                base.moveSpeed =2.2f; // �̵��ӵ�
                base.isfly = false; // ���� ����
        }
    }

    public class Wraith : TerranBase
    {
        public Wraith()
        {
                base.curHp = 120; //����ü��
                base.maxHp = 120; // �ִ�ü��
                base.minerals = 150; // �Ҹ� �̳׶�
                base.gas = 100; //�Ҹ� ����
                base.pop = 2; // �Ҹ� �α���
                base.groundAtk = 8; // ���� ���ݷ�
                base.airAtk = 20; // ���� ����
                base.armor = 0; //����     
                base.range = 5; // ���ݻ�Ÿ�
                base.sight = 7; // �þ�
                base.buildTime = 60; // ����ӵ�
                base.attackSpeed = 30; // ���ݼӵ�
                base.moveSpeed = 3.126f; // �̵��ӵ�
                base.isfly = false; // ���� ����
            }
    }

    public class Drop_Ship : TerranBase
    {
        public Drop_Ship()
        {
                base.curHp = 150; //����ü��
                base.maxHp = 150; // �ִ�ü��
                base.minerals = 100; // �Ҹ� �̳׶�
                base.gas = 100; //�Ҹ� ����
                base.pop = 2; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; //����     
                base.range = 0; // ���ݻ�Ÿ�
                base.sight = 8; // �þ�
                base.buildTime = 50; // ����ӵ�
                base.attackSpeed = 0; // ���ݼӵ�
                base.moveSpeed = 2.563f; // �̵��ӵ�
                base.isfly = true; // ���� ����
            }
    }

    public class Science_Vessel : TerranBase
    {
        public Science_Vessel()
        {
                base.curHp = 200; //����ü��
                base.maxHp = 200; // �ִ�ü��
                base.minerals = 100; // �Ҹ� �̳׶�
                base.gas = 225; //�Ҹ� ����
                base.pop = 2; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; //����     
                base.range = 0; // ���ݻ�Ÿ�
                base.sight = 10; // �þ�
                base.buildTime = 80; // ����ӵ�
                base.attackSpeed = 0; // ���ݼӵ�
                base.moveSpeed = 2.344f; // �̵��ӵ�
                base.isfly = true; // ���� ����
            }

    }

    public class Battlecruiser : TerranBase
    {
        public Battlecruiser()
        {
                base.curHp = 500; //����ü��
                base.maxHp = 500; // �ִ�ü��
                base.minerals = 400; // �Ҹ� �̳׶�
                base.gas = 300; //�Ҹ� ����
                base.pop = 6; // �Ҹ� �α���
                base.groundAtk = 25; // ���� ���ݷ�
                base.airAtk = 25; // ���� ����
                base.armor = 3; //����     
                base.range = 6; // ���ݻ�Ÿ�
                base.sight = 11; // �þ�
                base.buildTime = 133; // ����ӵ�
                base.attackSpeed = 30; // ���ݼӵ�
                base.moveSpeed = 1.172f; // �̵��ӵ�
                base.isfly = true; // ���� ����
            }

    }

    public class Valkyrie : TerranBase
    {
        public Valkyrie()
            {
                base.curHp = 200; //����ü��
                base.maxHp = 200; // �ִ�ü��
                base.minerals = 250; // �Ҹ� �̳׶�
                base.gas = 125; //�Ҹ� ����
                base.pop = 3; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 6 * 8; // ���� ����
                base.armor = 2; //����     
                base.range = 6; // ���ݻ�Ÿ�
                base.sight = 8; // �þ�
                base.buildTime = 50; // ����ӵ�
                base.attackSpeed = 64; // ���ݼӵ�
                base.moveSpeed = 3.094f; // �̵��ӵ�
                base.isfly = true; // ���� ����
            }
    }



        public static TerranBase Spawn(ETUnitList _type)
    {
            switch (_type)
        {
                case ETUnitList.SCV:                    
                    return new SCV();
                case ETUnitList.Marine:
                    return new Marine();
                case ETUnitList.Medic:
                    return new Medic();
                case ETUnitList.FireBat:
                    return new FireBat();
                case ETUnitList.Ghost:
                    return new Ghost();
                case ETUnitList.Vulture:
                    return new Vulture();
                case ETUnitList.Goliath:
                    return new Goliath();
                case ETUnitList.Tank:
                    return new Tank();
                case ETUnitList.Wraith:
                    return new Wraith();
                case ETUnitList.Drop_Ship:
                    return new Drop_Ship();
                case ETUnitList.Science_Vessel:
                    return new Science_Vessel();
                case ETUnitList.Battlecruiser:                    
                    return new Battlecruiser();
                case ETUnitList.Valkyrie:
                    return new Valkyrie();
            }
            return null;
        }
        public static TBuilding Build(ETBuildingList _type)
        {
            switch (_type)
            {
                case ETBuildingList.Command_Center:                 
                    return new Command_Center();
                case ETBuildingList.Nuclear_Silo:
                    return new Nuclear_Silo();
                case ETBuildingList.Supply_Depot:
                    return new Supply_Depot();
                case ETBuildingList.Refiery:
                    return new Refiery();
                case ETBuildingList.Academy:
                    return new Academy();
                case ETBuildingList.Engineering_bay:
                    return new Engineering_bay();
                case ETBuildingList.Misiile_Turret:
                    return new Misiile_Turret();
                case ETBuildingList.Bunker:
                    return new Bunker();
                case ETBuildingList.Factory:
                    return new Factory();
                case ETBuildingList.Machine_shop:
                    return new Machine_shop();
                case ETBuildingList.StarPort:
                    return new StarPort();
                case ETBuildingList.Control_Tower:
                    return new Control_Tower();
                case ETBuildingList.Science_Facility:
                    return new Science_Facility();
                case ETBuildingList.Physics_Lab:
                    return new Physics_Lab();
                case ETBuildingList.Covert_Ops:
                    return new Covert_Ops();
            }
            return null;
        }

    }

    ///�׶�(Terran) end-----------------------------------------------------------------------------------------------
}