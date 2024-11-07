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
            protected int groundAtk = 0; // 지상 공격력
            protected int airAtk = 0; // 공중 공격
            protected int armor = 0; //방어력     
            protected int range = 0; // 공격사거리
            protected int sight = 0; // 시야
            protected int buildTime = 0; // 생산속도
            protected int attackSpeed = 0; // 공격속도
            protected float moveSpeed = 0.0f; // 이동속도
            protected bool isfly = false; // 비행 여부

        }
        public class ZergBase : Tribe
        {
            protected int minerals = 0; // 소모 미네랄
            protected int gas = 0; //소모 가스
            protected int pop = 1; // 소모 인구수
        }

        ///////////////////////////////////////////////////////////////////////////////////

        // Zerg Building : 저그 건물
        
        ///////////////////////////////////////////////////////////////////////////////////
        
        // 해처리 //
        public class Hatchery : ZergBase
        {
            public Hatchery()
            {
                base.curhp = 1250; //현재체력
                base.maxhp = 1250; // 최대체력
                base.minerals = 300; // 소모 미네랄
                base.gas = 0; //소모 가스
                base.pop = -1; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격 사거리
                base.sight = 9; // 시야
                base.buildTime = 120; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부

                // 특수능력 : 잠복 업그레이드 M100/G100/T80
                // lava 최대 3마리
            }
        }
        // 레어 : 스포닝 풀 필요 //
        public class Lair : Hatchery
        {
            public Lair()
            {
                base.curhp = 1800; //현재체력
                base.maxhp = 1800; // 최대체력
                base.minerals = 150; // 소모 미네랄
                base.gas = 100; //소모 가스
                base.pop = -1; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격 사거리
                base.sight = 10; // 시야
                base.buildTime = 100; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : Evolve Ventral Ascs(오버로드 수송 기능)
            // Evolve Antennae(오버로드 디텍트 범위 증가),
            // Evolve Pneumatized Carapace(오버로드 이동속도 향상)

        }
        // 하이브 : 퀸즈 네스트 필요 //
        public class Hive : Lair
        {
            public Hive()
            {
                base.curhp = 2500; //현재체력
                base.maxhp = 2500; // 최대체력
                base.minerals = 200; // 소모 미네랄
                base.gas = 150; //소모 가스
                base.pop = -1; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격 사거리
                base.sight = 11; // 시야
                base.buildTime = 120; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력
        }
        // 익스트랙터 : 베스핀 간헐천 위에 건설 //
        public class Extractor : ZergBase
        {
            public Extractor()
            {
                base.curhp = 500; //현재체력
                base.maxhp = 500; // 최대체력
                base.minerals = 25; // 소모 미네랄
                base.gas = 30; //소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격 사거리
                base.sight = 9; // 시야
                base.buildTime = 30; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : 드론이 가스 획득 가능 : 드론이 가스를 캐는 시간 설정 필요.
        }
        // 스포닝 풀 : 해처리 필요
        public class SpawningPool : ZergBase
        {
            public SpawningPool()
            {
                base.curhp = 750; //현재체력
                base.maxhp = 750; // 최대체력
                base.minerals = 200; // 소모 미네랄
                base.gas = 0; //소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격 사거리
                base.sight = 8; // 시야
                base.buildTime = 80; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : Evolve Metabolic Boost(저글링 이속 증가) M100/G100/T100
            // Evolve Adrenal Glands (저글링 공속 증가) M200/G200/T100 : 하이브 필요
        }
        // 에볼루션 챔버 : 해처리 필요 //
        public class EvolutionChamber : ZergBase
        {
            public EvolutionChamber()
            {
                base.curhp = 750; //현재체력
                base.maxhp = 750; // 최대체력
                base.minerals = 75; // 소모 미네랄
                base.gas = 0; //소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격 사거리
                base.sight = 8; // 시야
                base.buildTime = 40; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : Upgragde Melee Attacks(근접 공격력 증가)
            // 1단계 100/100/266 -> 2단계 150/150/298 -> 3단계 200/200/330
            // Upgrade Missile Attacks(원거리 공격력 증가)
            // 1단계 100/100/266 -> 2단계 150/150/298 -> 3단계 200/200/330
            // Evolve Carapace(지상 유닛 방어력 증가)
            // 1단계 150/150/266 -> 2단계 225/225/298 -> 3단계 300/300/330
        }
        // 크립 콜로니(점막 군체)
        public class CreepColony : ZergBase
        {
            public CreepColony()
            {
                base.curhp = 400; //현재체력
                base.maxhp = 400; // 최대체력
                base.minerals = 75; // 소모 미네랄
                base.gas = 0; //소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 0; //방어력     
                base.range = 0; // 공격 사거리
                base.sight = 10; // 시야
                base.buildTime = 20; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : 스포어 콜로니(M50/T20)나 성큰 콜로니(M50/T20)로 변태
            // 크립 범위 증가
        }
        // 스포어 콜로니 : 에볼루션 체임버 필요
        public class SporeColony : CreepColony
        {
            public SporeColony()
            {
                base.curhp = 400; //현재체력
                base.maxhp = 400; // 최대체력
                base.minerals = 50; // 소모 미네랄
                base.gas = 0; //소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 15; // 공중 공격
                base.armor = 0; //방어력     
                base.range = 7; // 공격 사거리
                base.sight = 10; // 시야
                base.buildTime = 20; // 생산 속도
                base.attackSpeed = 15; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : 공중 유닛 공격 가능. 디텍터
        }
        // 성큰 콜로니 : 스포닝 풀 필요
        public class SunkenColony : CreepColony
        {
            public SunkenColony()
            {
                base.curhp = 300; //현재체력
                base.maxhp = 300; // 최대체력
                base.minerals = 50; // 소모 미네랄
                base.gas = 0; //소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 40; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 2; //방어력     
                base.range = 7; // 공격 사거리
                base.sight = 10; // 시야
                base.buildTime = 20; // 생산 속도
                base.attackSpeed = 32; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : 지상 유닛 공격 가능
        }
        // 히드라리스크 덴 //
        public class HydraliskDen : ZergBase
        {
            public HydraliskDen()
            {
                base.curhp = 850; //현재체력
                base.maxhp = 850; // 최대체력
                base.minerals = 100; // 소모 미네랄
                base.gas = 50; //소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격 사거리
                base.sight = 8; // 시야
                base.buildTime = 40; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : Evolve Muscular Augments(히드라 이동 속도 증가) 150/150/100
            // Evolve Grooved Spines(히드라 공격 사거리 증가) 150/150/100
            // Evolve Lurker Aspect(러커 변태 가능) 200/200/120 : 스포닝 풀 필요
        }
        // 스파이어 //
        public class Spire : ZergBase
        {
            public Spire()
            {
                base.curhp = 600; //현재체력
                base.maxhp = 600; // 최대체력
                base.minerals = 200; // 소모 미네랄
                base.gas = 150; //소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격 사거리
                base.sight = 8; // 시야
                base.buildTime = 120; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : Upgrade Flyer Attacks(비행체 공격력 증가)
            // 1단계 100/100/266 -> 2단계 175/175/298 -> 3단계 250/250/330
            // Upgrade Flyer Carapace(비행체 방어력 증가)
            // 1단계 150/150/266 -> 2단계 225/225/298 -> 3단계 300/300/330
        }
        // 그레이터 스파이어 : 하이브 필요 //
        public class GraterSpire : Spire
        {
            public GraterSpire()
            {
                base.curhp = 1000; //현재체력
                base.maxhp = 1000; // 최대체력
                base.minerals = 100; // 소모 미네랄
                base.gas = 150; //소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격 사거리
                base.sight = 8; // 시야
                base.buildTime = 120; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : 뮤탈 => 디바우러, 가디언 변태 가능
        }
        // 퀸즈 네스트 : 레어 필요 //
        public class QueensNest : ZergBase
        {
            public QueensNest()
            {
                base.curhp = 850; //현재체력
                base.maxhp = 850; // 최대체력
                base.minerals = 150; // 소모 미네랄
                base.gas = 100; //소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격 사거리
                base.sight = 8; // 시야
                base.buildTime = 60; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : Spawn Brooding(브루들링 소환 가능) 100/100/80
            // Ensnare(속박 가능) 100/100/80
            // Gamete Meiosis(퀸이 만든 기생 생물의 번식 속도 증가) 150/150/166
        }
        // 인페스티드 커맨드 센터 : 커멘드 센터 hp 절반 이하
        public class InfestedCommandCenter : ZergBase
        {
            public InfestedCommandCenter()
            {
                base.curhp = 1500; // 현재체력
                base.maxhp = 1500; // 최대체력
                base.minerals = 0; // 소모 미네랄
                base.gas = 0; // 소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; // 방어력     
                base.range = 0; // 공격 사거리
                base.sight = 10; // 시야
                base.buildTime = 0; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : Infested Terran 생산 가능, 이륙해서 이동 및 착륙 가능
        }
        // 울트라리스크 캐번 : 하이브 필요
        public class UltraliskCavern : ZergBase
        {
            public UltraliskCavern()
            {
                base.curhp = 600; // 현재체력
                base.maxhp = 600; // 최대체력
                base.minerals = 150; // 소모 미네랄
                base.gas = 200; // 소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; // 방어력     
                base.range = 0; // 공격 사거리
                base.sight = 8; // 시야
                base.buildTime = 80; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : Evolve Anabolic SynThesis(울트라리스크 이속 증가) 200/200/133
            // Evolve Chitinous Plating(울트라리스크 방어력 증가) 150/150/133
        }
        // 디파일러 마운드 : 하이브 필요
        public class DefilerMound : ZergBase
        {
            public DefilerMound()
            {
                base.curhp = 850; // 현재체력
                base.maxhp = 850; // 최대체력
                base.minerals = 100; // 소모 미네랄
                base.gas = 100; // 소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; // 방어력     
                base.range = 0; // 공격 사거리
                base.sight = 8; // 시야
                base.buildTime = 60; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : Plage(역병 살포 가능) 200/200/100
            // Consume(Zerg 유닛 흡수 가능) 100/100/100
            // Metasynaptic Node(최대 에너지 증가) 150/150/166
        }
        // 나이더스 커널
        public class NydusCanal : ZergBase
        {
            public NydusCanal()
            {
                base.curhp = 250; // 현재체력
                base.maxhp = 250; // 최대체력
                base.minerals = 150; // 소모 미네랄
                base.gas = 0; // 소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; // 방어력     
                base.range = 0; // 공격 사거리
                base.sight = 8; // 시야
                base.buildTime = 40; // 생산 속도
                base.attackSpeed = 0; // 공격 속도
                base.moveSpeed = 0.0f; // 이동 속도
                base.isfly = false; // 비행 여부
            }
            // 특수능력 : 이어진 곳으로 유닛 즉시 이동 가능, 땅굴관 출구 배치 T40
        }

        ///////////////////////////////////////////////////////////////////////////////////

        // Zerg Building : 저그 유닛

        ///////////////////////////////////////////////////////////////////////////////////
        
        ////////////////////////////////////////////////////////////////// 해처리 단계

        public class ZergGroundUnit : ZergBase
        {
            bool BurrowAbilty = false;

            ActivateBurrowAblity(bool)
                if 
        }

        // 애벌레 // 완료
        public class Lava : ZergBase
        {
            public Lava()
            {
                // 기본 스탯
                
                // 특수능력 : 애벌레로 변화
            }
        }
        // 드론 // 완료
        public class Drone : ZergBase
        {
            public Drone()
            {
                //기본 스탯
                
                // 특수능력 : 미네랄 및 가스 채집
            }
        }
        // 오버로드 // 완료
        public class Overload : ZergBase
        {
            public Overload()
            {
                //기본 스탯
                
                // 특수능력 : 인구수 추가(+8), 수송능력, 디텍터,
            }
        }
        // 저글링 : 스포닝 풀 필요
        public class Zergling : ZergBase
        {
            public Zergling()
            {
                //기본 스탯
                base.curhp = 35; // 현재체력
                base.maxhp = 35; // 최대체력
                base.minerals = 25; // 소모 미네랄 *2
                base.gas = 0; // 소모 가스
                base.pop = 0.5; // 소모 인구수 *2
                base.groundAtk = 5; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 0; // 방어력
                base.range = 1; // 공격사거리
                base.sight = 5; // 시야
                base.buildTime = 28; // 생산속도
                base.attackSpeed = 8.5; // 공격속도 >5.75
                base.moveSpeed = 2.612; // 이동속도 >3.917
                base.fly = false; // 비행 여부
                                  // 특수능력 : 없음
            }
        }
        // 히드라리스크
        public class Hydralisk : ZergBase
        {
            public HydraLisk()
            {
                //기본 스탯
                base.curhp = ; // 현재체력
                base.maxhp = ; // 최대체력
                base.minerals = ; // 소모 미네랄
                base.gas = ; // 소모 가스
                base.pop = ; // 소모 인구수
                base.groundAtk = ; // 지상 공격력
                base.airAtk = ; // 공중 공격
                base.armor = ; // 방어력
                base.range = ; // 공격사거리
                base.sight = ; // 시야
                base.buildTime = ; // 생산속도
                base.attackSpeed = ; // 공격속도
                base.moveSpeed = ; // 이동속도
                base.fly = false; // 비행 여부
                                  // 특수능력 : 인구수 추가, 수송능력, 디텍터
            }
        }
        // 에그
        public class Egg : ZergBase
        {
                // 기본 스탯
                base.curhp = 200; //현재체력
                base.maxhp = 200; // 최대체력
                base.minerals = 0; // 소모 미네랄
                base.gas = 0; // 소모 가스
                base.pop = 0; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 10; // 방어력
                base.range = 0; // 공격사거리
                base.sight = 4; // 시야
                base.buildTime = 0; // 생산속도
                base.attackSpeed = 0; // 공격속도
                base.moveSpeed = 0; // 이동속도
                base.fly = false; // 비행 여부
                // 특수능력 : 각종 유닛으로 변화. 변화하는 유닛 알려주는 기능.
        }
        ////////////////////////////////////////////////////////////////// 레어 단계
        // 러커
        public class Lucker : ZergBase
        {
        }
        // 뮤탈리스크
        public class Mutalisk : ZergBase
        {
        }
        // 스콜지
        public class Scourge : ZergBase
        {
        }
        // 퀸
        public class Queen : ZergBase
        {
        }
        // 브루들링
        public class Broodling : ZergBase
        {
        }
        // 인페스티드 테란
        public class InfestedTerran : ZergBase
        {
        }
        ////////////////////////////////////////////////////////////////// 하이브 단계 
        // 가디언 
        public class Guardian : ZergBase
        {
        }
        // 디바우러
        public class Devourer : ZergBase
        {
        }
        // 디파일러
        public class Defiler : ZergBase
        {
        }
        // 울트라리스크
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
        ///저그(Zerg) end--------------------------------------------------------------------------------------------------
                
    }
}*/