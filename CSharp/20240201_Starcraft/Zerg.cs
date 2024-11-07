/*using Sonji;
using System;
using System.Threading;
using static JongHunZerg.Zerg;
using static Sonji.Program;
using static SonJiTerran.Terran;


namespace JongHunZerg
{
    public enum EZUnitList
    {
        Hatchery, Lair, Hive, Extractor, SpawningPool, EvolutionChamber, CreepColony, SporeColony, SunkenColony,
        HydraliskDen, Spire, GraterSpire, Queensnest, InfestedCommandCenter, UltraliskCavern, DefilerMound, NydusCanal
    }
    public enum EZBuildingList
    {
        Lava, Drone, Overload, Zergling, Hydralisk, Egg, Lucker, Mutalisk, Scourge, Queen, Broodling, InfestedTerran,
        Guardian, Devourer, Defiler, Ultralisk
    }

    public class Zerg
    {

        public class Tribe : GameObject
        {
            protected int groundAtk = 0; // ���� ���ݷ�
            protected int airAtk = 0; // ���� ����
            protected int armor = 0; //����     
            protected int range = 0; // ���ݻ�Ÿ�
            protected int sight = 0; // �þ�
            protected int buildTime = 0; // ����ӵ�
            protected int attackSpeed = 0; // ���ݼӵ�
            protected float moveSpeed = 0.0f; // �̵��ӵ�
            protected bool isfly = false; // ���� ����

        }
        public class ZergBase : Tribe
        {
            protected int minerals = 0; // �Ҹ� �̳׶�
            protected int gas = 0; //�Ҹ� ����
            protected int pop = 1; // �Ҹ� �α���
        }

        ///////////////////////////////////////////////////////////////////////////////////

        // Zerg Building : ���� �ǹ�
        
        ///////////////////////////////////////////////////////////////////////////////////
        
        // ��ó�� //
        public class Hatchery : ZergBase
        {
            public Hatchery()
            {
                base.curhp = 1250; //����ü��
                base.maxhp = 1250; // �ִ�ü��
                base.minerals = 300; // �Ҹ� �̳׶�
                base.gas = 0; //�Ҹ� ����
                base.pop = -1; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; //����     
                base.range = 0; // ���� ��Ÿ�
                base.sight = 9; // �þ�
                base.buildTime = 120; // ���� �ӵ�
                base.attackSpeed = 0; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����

                // Ư���ɷ� : �ẹ ���׷��̵� M100/G100/T80
                // lava �ִ� 3����
            }
        }
        // ���� : ������ Ǯ �ʿ� //
        public class Lair : Hatchery
        {
            public Lair()
            {
                base.curhp = 1800; //����ü��
                base.maxhp = 1800; // �ִ�ü��
                base.minerals = 150; // �Ҹ� �̳׶�
                base.gas = 100; //�Ҹ� ����
                base.pop = -1; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; //����     
                base.range = 0; // ���� ��Ÿ�
                base.sight = 10; // �þ�
                base.buildTime = 100; // ���� �ӵ�
                base.attackSpeed = 0; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : Evolve Ventral Ascs(�����ε� ���� ���)
            // Evolve Antennae(�����ε� ����Ʈ ���� ����),
            // Evolve Pneumatized Carapace(�����ε� �̵��ӵ� ���)

        }
        // ���̺� : ���� �׽�Ʈ �ʿ� //
        public class Hive : Lair
        {
            public Hive()
            {
                base.curhp = 2500; //����ü��
                base.maxhp = 2500; // �ִ�ü��
                base.minerals = 200; // �Ҹ� �̳׶�
                base.gas = 150; //�Ҹ� ����
                base.pop = -1; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; //����     
                base.range = 0; // ���� ��Ÿ�
                base.sight = 11; // �þ�
                base.buildTime = 120; // ���� �ӵ�
                base.attackSpeed = 0; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ�
        }
        // �ͽ�Ʈ���� : ������ ����õ ���� �Ǽ� //
        public class Extractor : ZergBase
        {
            public Extractor()
            {
                base.curhp = 500; //����ü��
                base.maxhp = 500; // �ִ�ü��
                base.minerals = 25; // �Ҹ� �̳׶�
                base.gas = 30; //�Ҹ� ����
                base.pop = 0; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; //����     
                base.range = 0; // ���� ��Ÿ�
                base.sight = 9; // �þ�
                base.buildTime = 30; // ���� �ӵ�
                base.attackSpeed = 0; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : ����� ���� ȹ�� ���� : ����� ������ ĳ�� �ð� ���� �ʿ�.
        }
        // ������ Ǯ : ��ó�� �ʿ�
        public class SpawningPool : ZergBase
        {
            public SpawningPool()
            {
                base.curhp = 750; //����ü��
                base.maxhp = 750; // �ִ�ü��
                base.minerals = 200; // �Ҹ� �̳׶�
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
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : Evolve Metabolic Boost(���۸� �̼� ����) M100/G100/T100
            // Evolve Adrenal Glands (���۸� ���� ����) M200/G200/T100 : ���̺� �ʿ�
        }
        // ������� è�� : ��ó�� �ʿ� //
        public class EvolutionChamber : ZergBase
        {
            public EvolutionChamber()
            {
                base.curhp = 750; //����ü��
                base.maxhp = 750; // �ִ�ü��
                base.minerals = 75; // �Ҹ� �̳׶�
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
            // Ư���ɷ� : Upgragde Melee Attacks(���� ���ݷ� ����)
            // 1�ܰ� 100/100/266 -> 2�ܰ� 150/150/298 -> 3�ܰ� 200/200/330
            // Upgrade Missile Attacks(���Ÿ� ���ݷ� ����)
            // 1�ܰ� 100/100/266 -> 2�ܰ� 150/150/298 -> 3�ܰ� 200/200/330
            // Evolve Carapace(���� ���� ���� ����)
            // 1�ܰ� 150/150/266 -> 2�ܰ� 225/225/298 -> 3�ܰ� 300/300/330
        }
        // ũ�� �ݷδ�(���� ��ü)
        public class CreepColony : ZergBase
        {
            public CreepColony()
            {
                base.curhp = 400; //����ü��
                base.maxhp = 400; // �ִ�ü��
                base.minerals = 75; // �Ҹ� �̳׶�
                base.gas = 0; //�Ҹ� ����
                base.pop = 0; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 0; //����     
                base.range = 0; // ���� ��Ÿ�
                base.sight = 10; // �þ�
                base.buildTime = 20; // ���� �ӵ�
                base.attackSpeed = 0; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : ������ �ݷδ�(M50/T20)�� ��ū �ݷδ�(M50/T20)�� ����
            // ũ�� ���� ����
        }
        // ������ �ݷδ� : ������� ü�ӹ� �ʿ�
        public class SporeColony : CreepColony
        {
            public SporeColony()
            {
                base.curhp = 400; //����ü��
                base.maxhp = 400; // �ִ�ü��
                base.minerals = 50; // �Ҹ� �̳׶�
                base.gas = 0; //�Ҹ� ����
                base.pop = 0; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 15; // ���� ����
                base.armor = 0; //����     
                base.range = 7; // ���� ��Ÿ�
                base.sight = 10; // �þ�
                base.buildTime = 20; // ���� �ӵ�
                base.attackSpeed = 15; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : ���� ���� ���� ����. ������
        }
        // ��ū �ݷδ� : ������ Ǯ �ʿ�
        public class SunkenColony : CreepColony
        {
            public SunkenColony()
            {
                base.curhp = 300; //����ü��
                base.maxhp = 300; // �ִ�ü��
                base.minerals = 50; // �Ҹ� �̳׶�
                base.gas = 0; //�Ҹ� ����
                base.pop = 0; // �Ҹ� �α���
                base.groundAtk = 40; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 2; //����     
                base.range = 7; // ���� ��Ÿ�
                base.sight = 10; // �þ�
                base.buildTime = 20; // ���� �ӵ�
                base.attackSpeed = 32; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : ���� ���� ���� ����
        }
        // ����󸮽�ũ �� //
        public class HydraliskDen : ZergBase
        {
            public HydraliskDen()
            {
                base.curhp = 850; //����ü��
                base.maxhp = 850; // �ִ�ü��
                base.minerals = 100; // �Ҹ� �̳׶�
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
            // Ư���ɷ� : Evolve Muscular Augments(����� �̵� �ӵ� ����) 150/150/100
            // Evolve Grooved Spines(����� ���� ��Ÿ� ����) 150/150/100
            // Evolve Lurker Aspect(��Ŀ ���� ����) 200/200/120 : ������ Ǯ �ʿ�
        }
        // �����̾� //
        public class Spire : ZergBase
        {
            public Spire()
            {
                base.curhp = 600; //����ü��
                base.maxhp = 600; // �ִ�ü��
                base.minerals = 200; // �Ҹ� �̳׶�
                base.gas = 150; //�Ҹ� ����
                base.pop = 0; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; //����     
                base.range = 0; // ���� ��Ÿ�
                base.sight = 8; // �þ�
                base.buildTime = 120; // ���� �ӵ�
                base.attackSpeed = 0; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : Upgrade Flyer Attacks(����ü ���ݷ� ����)
            // 1�ܰ� 100/100/266 -> 2�ܰ� 175/175/298 -> 3�ܰ� 250/250/330
            // Upgrade Flyer Carapace(����ü ���� ����)
            // 1�ܰ� 150/150/266 -> 2�ܰ� 225/225/298 -> 3�ܰ� 300/300/330
        }
        // �׷����� �����̾� : ���̺� �ʿ� //
        public class GraterSpire : Spire
        {
            public GraterSpire()
            {
                base.curhp = 1000; //����ü��
                base.maxhp = 1000; // �ִ�ü��
                base.minerals = 100; // �Ҹ� �̳׶�
                base.gas = 150; //�Ҹ� ����
                base.pop = 0; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; //����     
                base.range = 0; // ���� ��Ÿ�
                base.sight = 8; // �þ�
                base.buildTime = 120; // ���� �ӵ�
                base.attackSpeed = 0; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : ��Ż => ��ٿ췯, ����� ���� ����
        }
        // ���� �׽�Ʈ : ���� �ʿ� //
        public class QueensNest : ZergBase
        {
            public QueensNest()
            {
                base.curhp = 850; //����ü��
                base.maxhp = 850; // �ִ�ü��
                base.minerals = 150; // �Ҹ� �̳׶�
                base.gas = 100; //�Ҹ� ����
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
            // Ư���ɷ� : Spawn Brooding(���鸵 ��ȯ ����) 100/100/80
            // Ensnare(�ӹ� ����) 100/100/80
            // Gamete Meiosis(���� ���� ��� ������ ���� �ӵ� ����) 150/150/166
        }
        // ���佺Ƽ�� Ŀ�ǵ� ���� : Ŀ��� ���� hp ���� ����
        public class InfestedCommandCenter : ZergBase
        {
            public InfestedCommandCenter()
            {
                base.curhp = 1500; // ����ü��
                base.maxhp = 1500; // �ִ�ü��
                base.minerals = 0; // �Ҹ� �̳׶�
                base.gas = 0; // �Ҹ� ����
                base.pop = 0; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; // ����     
                base.range = 0; // ���� ��Ÿ�
                base.sight = 10; // �þ�
                base.buildTime = 0; // ���� �ӵ�
                base.attackSpeed = 0; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : Infested Terran ���� ����, �̷��ؼ� �̵� �� ���� ����
        }
        // ��Ʈ�󸮽�ũ ĳ�� : ���̺� �ʿ�
        public class UltraliskCavern : ZergBase
        {
            public UltraliskCavern()
            {
                base.curhp = 600; // ����ü��
                base.maxhp = 600; // �ִ�ü��
                base.minerals = 150; // �Ҹ� �̳׶�
                base.gas = 200; // �Ҹ� ����
                base.pop = 0; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; // ����     
                base.range = 0; // ���� ��Ÿ�
                base.sight = 8; // �þ�
                base.buildTime = 80; // ���� �ӵ�
                base.attackSpeed = 0; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : Evolve Anabolic SynThesis(��Ʈ�󸮽�ũ �̼� ����) 200/200/133
            // Evolve Chitinous Plating(��Ʈ�󸮽�ũ ���� ����) 150/150/133
        }
        // �����Ϸ� ����� : ���̺� �ʿ�
        public class DefilerMound : ZergBase
        {
            public DefilerMound()
            {
                base.curhp = 850; // ����ü��
                base.maxhp = 850; // �ִ�ü��
                base.minerals = 100; // �Ҹ� �̳׶�
                base.gas = 100; // �Ҹ� ����
                base.pop = 0; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; // ����     
                base.range = 0; // ���� ��Ÿ�
                base.sight = 8; // �þ�
                base.buildTime = 60; // ���� �ӵ�
                base.attackSpeed = 0; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : Plage(���� ���� ����) 200/200/100
            // Consume(Zerg ���� ��� ����) 100/100/100
            // Metasynaptic Node(�ִ� ������ ����) 150/150/166
        }
        // ���̴��� Ŀ��
        public class NydusCanal : ZergBase
        {
            public NydusCanal()
            {
                base.curhp = 250; // ����ü��
                base.maxhp = 250; // �ִ�ü��
                base.minerals = 150; // �Ҹ� �̳׶�
                base.gas = 0; // �Ҹ� ����
                base.pop = 0; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 1; // ����     
                base.range = 0; // ���� ��Ÿ�
                base.sight = 8; // �þ�
                base.buildTime = 40; // ���� �ӵ�
                base.attackSpeed = 0; // ���� �ӵ�
                base.moveSpeed = 0.0f; // �̵� �ӵ�
                base.isfly = false; // ���� ����
            }
            // Ư���ɷ� : �̾��� ������ ���� ��� �̵� ����, ������ �ⱸ ��ġ T40
        }

        ///////////////////////////////////////////////////////////////////////////////////

        // Zerg Building : ���� ����

        ///////////////////////////////////////////////////////////////////////////////////
        
        ////////////////////////////////////////////////////////////////// ��ó�� �ܰ�

        public class ZergGroundUnit : ZergBase
        {
            bool BurrowAbilty = false;

            ActivateBurrowAblity(bool)
                if 
        }

        // �ֹ��� // �Ϸ�
        public class Lava : ZergBase
        {
            public Lava()
            {
                // �⺻ ����
                
                // Ư���ɷ� : �ֹ����� ��ȭ
            }
        }
        // ��� // �Ϸ�
        public class Drone : ZergBase
        {
            public Drone()
            {
                //�⺻ ����
                
                // Ư���ɷ� : �̳׶� �� ���� ä��
            }
        }
        // �����ε� // �Ϸ�
        public class Overload : ZergBase
        {
            public Overload()
            {
                //�⺻ ����
                
                // Ư���ɷ� : �α��� �߰�(+8), ���۴ɷ�, ������,
            }
        }
        // ���۸� : ������ Ǯ �ʿ�
        public class Zergling : ZergBase
        {
            public Zergling()
            {
                //�⺻ ����
                base.curhp = 35; // ����ü��
                base.maxhp = 35; // �ִ�ü��
                base.minerals = 25; // �Ҹ� �̳׶� *2
                base.gas = 0; // �Ҹ� ����
                base.pop = 0.5; // �Ҹ� �α��� *2
                base.groundAtk = 5; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 0; // ����
                base.range = 1; // ���ݻ�Ÿ�
                base.sight = 5; // �þ�
                base.buildTime = 28; // ����ӵ�
                base.attackSpeed = 8.5; // ���ݼӵ� >5.75
                base.moveSpeed = 2.612; // �̵��ӵ� >3.917
                base.fly = false; // ���� ����
                                  // Ư���ɷ� : ����
            }
        }
        // ����󸮽�ũ
        public class Hydralisk : ZergBase
        {
            public HydraLisk()
            {
                //�⺻ ����
                base.curhp = ; // ����ü��
                base.maxhp = ; // �ִ�ü��
                base.minerals = ; // �Ҹ� �̳׶�
                base.gas = ; // �Ҹ� ����
                base.pop = ; // �Ҹ� �α���
                base.groundAtk = ; // ���� ���ݷ�
                base.airAtk = ; // ���� ����
                base.armor = ; // ����
                base.range = ; // ���ݻ�Ÿ�
                base.sight = ; // �þ�
                base.buildTime = ; // ����ӵ�
                base.attackSpeed = ; // ���ݼӵ�
                base.moveSpeed = ; // �̵��ӵ�
                base.fly = false; // ���� ����
                                  // Ư���ɷ� : �α��� �߰�, ���۴ɷ�, ������
            }
        }
        // ����
        public class Egg : ZergBase
        {
                // �⺻ ����
                base.curhp = 200; //����ü��
                base.maxhp = 200; // �ִ�ü��
                base.minerals = 0; // �Ҹ� �̳׶�
                base.gas = 0; // �Ҹ� ����
                base.pop = 0; // �Ҹ� �α���
                base.groundAtk = 0; // ���� ���ݷ�
                base.airAtk = 0; // ���� ����
                base.armor = 10; // ����
                base.range = 0; // ���ݻ�Ÿ�
                base.sight = 4; // �þ�
                base.buildTime = 0; // ����ӵ�
                base.attackSpeed = 0; // ���ݼӵ�
                base.moveSpeed = 0; // �̵��ӵ�
                base.fly = false; // ���� ����
                // Ư���ɷ� : ���� �������� ��ȭ. ��ȭ�ϴ� ���� �˷��ִ� ���.
        }
        ////////////////////////////////////////////////////////////////// ���� �ܰ�
        // ��Ŀ
        public class Lucker : ZergBase
        {
        }
        // ��Ż����ũ
        public class Mutalisk : ZergBase
        {
        }
        // ������
        public class Scourge : ZergBase
        {
        }
        // ��
        public class Queen : ZergBase
        {
        }
        // ���鸵
        public class Broodling : ZergBase
        {
        }
        // ���佺Ƽ�� �׶�
        public class InfestedTerran : ZergBase
        {
        }
        ////////////////////////////////////////////////////////////////// ���̺� �ܰ� 
        // ����� 
        public class Guardian : ZergBase
        {
        }
        // ��ٿ췯
        public class Devourer : ZergBase
        {
        }
        // �����Ϸ�
        public class Defiler : ZergBase
        {
        }
        // ��Ʈ�󸮽�ũ
        public class Ultralisk : ZergBase
        {
        }
        public static ZUnit Spawn(EZergUnit _type)
        {
            switch (_type)
            {
                case EZergUnit.Zergling:
                    return new Zergling();
            }
            return null;
        }
        ///����(Zerg) end--------------------------------------------------------------------------------------------------
                
    }
}*/