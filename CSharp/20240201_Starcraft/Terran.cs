using Sonji;
using System;
using System.Threading;
using static Sonji.Program;
using static SonJiTerran.Terran.TBuilding;
using System.Timers;

namespace SonJiTerran
{
    


    public class Terran {

        ///테란(Terran)--------------------------------------------------------------------------------------------------


        public class Tribe : GameObject
        {
            public int groundAtk = 0; // 지상 공격력
            public int airAtk = 0; // 공중 공격
            public int armor = 0; //방어력     
            public int range = 0; // 공격사거리
            public int sight = 0; // 시야
            public int buildTime = 0; // 생산속도
            public int attackSpeed = 0; // 공격속도
            public float moveSpeed = 0.0f; // 이동속도
            public bool isfly = false; // 비행 여부
            
        }
    public class TerranBase : Tribe
        {
            public int minerals = 0; // 소모 미네랄
            public int gas = 0; //소모 가스
            public int pop = 1; // 소모 인구수


        }

    public class TBuilding : TerranBase { 
        public class Command_Center : TBuilding
            {
                public Command_Center()
                {
                    curHp = 1500; //현재체력
                    maxHp = 1500; // 최대체력
                    minerals = 400; // 소모 미네랄
                    gas = 0; //소모 가스
                    pop = -10; // 소모 인구수
                    groundAtk = 0; // 지상 공격력
                    airAtk = 0; // 공중 공격
                    armor = 1; //방어력     
                    range = 0; // 공격 사거리
                    sight = 10; // 시야
                    buildTime = 120; // 생산 속도
                    attackSpeed = 0; // 공격 속도
                    moveSpeed = 0.0f; // 이동 속도
                    isfly = false; // 비행 여부                    
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
                    base.curHp = 500; //현재체력
                    base.maxHp = 500; // 최대체력
                    base.minerals = 50; // 소모 미네랄
                    base.gas = 50; //소모 가스
                    base.pop = 0; // 소모 인구수
                    base.groundAtk = 0; // 지상 공격력
                    base.airAtk = 0; // 공중 공격
                    base.armor = 1; //방어력     
                    base.range = 0; // 공격 사거리
                    base.sight = 10; // 시야
                    base.buildTime = 40; // 생산 속도
                    base.attackSpeed = 0; // 공격 속도
                    base.moveSpeed = 0.0f; // 이동 속도
                    base.isfly = false; // 비행 여부
                }
            }
            public class Nuclear_Silo : TBuilding
            {
                public Nuclear_Silo()
                {
                    base.curHp = 600; //현재체력
                    base.maxHp = 600; // 최대체력
                    base.minerals = 100; // 소모 미네랄
                    base.gas = 100; //소모 가스
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
            }
            public class Supply_Depot : TBuilding
            {
                public Supply_Depot()
                {
                    base.curHp = 500; //현재체력
                    base.maxHp = 500; // 최대체력
                    base.minerals = 100; // 소모 미네랄
                    base.gas = 0; //소모 가스
                    base.pop = -8; // 소모 인구수
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
            }
            public class Refiery : TBuilding
            {
                public Refiery()
                {
                    base.curHp = 750; //현재체력
                    base.maxHp = 750; // 최대체력
                    base.minerals = 100; // 소모 미네랄
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
            }
            public class Academy : TBuilding
            {
                public Academy()
                {
                    base.curHp = 600; //현재체력
                    base.maxHp = 600; // 최대체력
                    base.minerals = 150; // 소모 미네랄
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
                    base.isfly = false; // 비행 여부ㅈ                    
                }


            }
            public class Engineering_bay : TBuilding
            {
                public Engineering_bay()
                {
                    base.curHp = 850; //현재체력
                    base.maxHp = 850; // 최대체력
                    base.minerals = 125; // 소모 미네랄
                    base.gas = 0; //소모 가스
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
            }
            public class Misiile_Turret : TBuilding
            {

                public Misiile_Turret()
                {
                    base.curHp = 200; //현재체력
                    base.maxHp = 200; // 최대체력
                    base.minerals = 75; // 소모 미네랄
                    base.gas = 0; //소모 가스
                    base.pop = 0; // 소모 인구수
                    base.groundAtk = 0; // 지상 공격력
                    base.airAtk = 20; // 공중 공격
                    base.armor = 0; //방어력     
                    base.range = 7; // 공격 사거리
                    base.sight = 11; // 시야
                    base.buildTime = 40; // 생산 속도
                    base.attackSpeed = 0; // 공격 속도
                    base.moveSpeed = 0.0f; // 이동 속도
                    base.isfly = false; // 비행 여부
                }
            }
            public class Bunker : TBuilding
            {
                public Bunker()
                {
                    base.curHp = 350; //현재체력
                    base.maxHp = 350; // 최대체력
                    base.minerals = 100; // 소모 미네랄
                    base.gas = 0; //소모 가스
                    base.pop = 0; // 소모 인구수
                    base.groundAtk = 0; // 지상 공격력
                    base.airAtk = 0; // 공중 공격
                    base.armor = 1; //방어력     
                    base.range = 0; // 공격 사거리
                    base.sight = 10; // 시야
                    base.buildTime = 30; // 생산 속도
                    base.attackSpeed = 0; // 공격 속도
                    base.moveSpeed = 0.0f; // 이동 속도
                    base.isfly = false; // 비행 여부
                }
            }
            public class Factory : TBuilding
            {
                public Factory()
                {
                    base.curHp = 1250; //현재체력
                    base.maxHp = 125; // 최대체력
                    base.minerals = 200; // 소모 미네랄
                    base.gas = 100; //소모 가스
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
            }
            public class Machine_shop : TBuilding
            {
                public Machine_shop()
                {
                    base.curHp = 750; //현재체력
                    base.maxHp = 750; // 최대체력
                    base.minerals = 50; // 소모 미네랄
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
            }
            public class StarPort : TBuilding
            {
                public StarPort()
                {
                    base.curHp = 1300; //현재체력
                    base.maxHp = 1300; // 최대체력
                    base.minerals = 150; // 소모 미네랄
                    base.gas = 100; //소모 가스
                    base.pop = 0; // 소모 인구수
                    base.groundAtk = 0; // 지상 공격력
                    base.airAtk = 0; // 공중 공격
                    base.armor = 1; //방어력     
                    base.range = 0; // 공격 사거리
                    base.sight = 10; // 시야
                    base.buildTime = 70; // 생산 속도
                    base.attackSpeed = 0; // 공격 속도
                    base.moveSpeed = 0.0f; // 이동 속도
                    base.isfly = false; // 비행 여부
                }
            }
            public class Control_Tower : TBuilding
            {
                public Control_Tower()
                {
                    base.curHp = 500; //현재체력
                    base.maxHp = 500; // 최대체력
                    base.minerals = 50; // 소모 미네랄
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
            }
            public class Science_Facility : TBuilding
            {
                public Science_Facility()
                {
                    base.curHp = 850; //현재체력
                    base.maxHp = 850; // 최대체력
                    base.minerals = 100; // 소모 미네랄
                    base.gas = 50; //소모 가스
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
            }
            public class Physics_Lab : TBuilding
            {
                public Physics_Lab()
                {
                    base.curHp = 600; //현재체력
                    base.maxHp = 600; // 최대체력
                    base.minerals = 50; // 소모 미네랄
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
            }
            public class Covert_Ops : TBuilding
            {
                public Covert_Ops()
                {
                    base.curHp = 750; //현재체력
                    base.maxHp = 750; // 최대체력
                    base.minerals = 50; // 소모 미네랄
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
            }
    }
        public class SCV : TerranBase
    {
        public SCV()
        {
            base.curHp = 60; //현재체력
            base.maxHp = 60; // 최대체력
            base.minerals = 50; // 소모 미네랄
            base.gas = 0; //소모 가스
            base.pop = 1; // 소모 인구수
            base.groundAtk = 5; // 지상 공격력
            base.airAtk = 0; // 공중 공격
            base.armor = 0; //방어력     
            base.range = 1; // 공격사거리
            base.sight = 7; // 시야
            base.buildTime = 20; // 생산속도
            base.attackSpeed = 15; // 공격속도
            base.moveSpeed = 2.344f; // 이동속도
            base.isfly = false; // 비행 여부
        }
    }
    public class Marine : TerranBase
    {
        public Marine()
        {
            base.curHp = 40; //현재체력
            base.maxHp = 40; // 최대체력
            base.minerals = 50; // 소모 미네랄
            base.gas = 0; //소모 가스
            base.pop = 1; // 소모 인구수
            base.groundAtk = 6; // 지상 공격력
            base.airAtk = 6; // 공중 공격
            base.armor = 0; //방어력     
            base.range = 4; // 공격사거리
            base.sight = 7; // 시야
            base.buildTime = 24; // 생산속도
            base.attackSpeed = 15; // 공격속도
            base.moveSpeed = 1.875f; // 이동속도
            base.isfly = true; // 비행 여부
        }
            public float Marine_StimPack()
            {
                moveSpeed = moveSpeed + 0.9375f;
                Console.WriteLine("마린 스팀팩 사용(Ah! That's the stuff!)");
                return moveSpeed + 0.9375f;
            }
        }

    public class FireBat : TerranBase
    {
        public FireBat()
        {
                base.curHp = 50; //현재체력
                base.maxHp = 50; // 최대체력
                base.minerals = 50; // 소모 미네랄
                base.gas = 25; //소모 가스
                base.pop = 1; // 소모 인구수
                base.groundAtk = 9 * 2; // 지상 공격력
                base.airAtk = 6; // 공중 공격
                base.armor = 0; //방어력     
                base.range = 4; // 공격사거리
                base.sight = 7; // 시야
                base.buildTime = 24; // 생산속도
                base.attackSpeed = 15; // 공격속도
                base.moveSpeed = 1.875f; // 이동속도
                base.isfly = false; // 비행 여부
            }
    }

    public class Ghost : TerranBase
    {
        public Ghost()
        {
                base.curHp = 45; //현재체력
                base.maxHp = 45; // 최대체력
                base.minerals = 25; // 소모 미네랄
                base.gas = 75; //소모 가스
                base.pop = 1; // 소모 인구수
                base.groundAtk = 10; // 지상 공격력
                base.airAtk = 10; // 공중 공격
                base.armor = 0; //방어력     
                base.range = 7; // 공격사거리
                base.sight = 9; // 시야
                base.buildTime = 50; // 생산속도
                base.attackSpeed = 22; // 공격속도
                base.moveSpeed = 1.875f; // 이동속도
                base.isfly = true; // 비행 여부
            }
    }

    public class Medic : TerranBase
    {
        public Medic()
        {
                base.curHp = 60; //현재체력
                base.maxHp = 60; // 최대체력
                base.minerals = 50; // 소모 미네랄
                base.gas = 25; //소모 가스
                base.pop = 1; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격사거리
                base.sight = 9; // 시야
                base.buildTime = 30; // 생산속도
                base.attackSpeed = 0; // 공격속도
                base.moveSpeed = 1.875f; // 이동속도
                base.isfly = false; // 비행 여부
            }
    }

    public class Vulture : TerranBase
    {
        public Vulture()
        {
                base.curHp = 80; //현재체력
                base.maxHp = 80; // 최대체력
                base.minerals = 75; // 소모 미네랄
                base.gas = 0; //소모 가스
                base.pop = 2; // 소모 인구수
                base.groundAtk = 20; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 0; //방어력     
                base.range = 5; // 공격사거리
                base.sight = 8; // 시야
                base.buildTime = 30; // 생산속도
                base.attackSpeed = 30; // 공격속도
                base.moveSpeed = 3.126f; // 이동속도
                base.isfly = false; // 비행 여부
        }
    }

    public class Tank : TerranBase
    {
        public Tank()
        {
                base.curHp = 150; //현재체력
                base.maxHp = 150; // 최대체력
                base.minerals = 150; // 소모 미네랄
                base.gas = 100; //소모 가스
                base.pop = 2; // 소모 인구수
                base.groundAtk = 30; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 7; // 공격사거리
                base.sight = 10; // 시야
                base.buildTime = 50; // 생산속도
                base.attackSpeed = 37; // 공격속도
                base.moveSpeed = 1.875f; // 이동속도
                base.isfly = false; // 비행 여부
        }

    }

    public class Goliath : TerranBase
    {
        public Goliath()
        {
                base.curHp = 125; //현재체력
                base.maxHp = 125; // 최대체력
                base.minerals = 100; // 소모 미네랄
                base.gas = 50; //소모 가스
                base.pop = 2; // 소모 인구수
                base.groundAtk = 12; // 지상 공격력
                base.airAtk = 10 * 2; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 8; // 공격사거리
                base.sight = 8; // 시야
                base.buildTime = 40; // 생산속도
                base.attackSpeed = 22; // 공격속도
                base.moveSpeed =2.2f; // 이동속도
                base.isfly = false; // 비행 여부
        }
    }

    public class Wraith : TerranBase
    {
        public Wraith()
        {
                base.curHp = 120; //현재체력
                base.maxHp = 120; // 최대체력
                base.minerals = 150; // 소모 미네랄
                base.gas = 100; //소모 가스
                base.pop = 2; // 소모 인구수
                base.groundAtk = 8; // 지상 공격력
                base.airAtk = 20; // 공중 공격
                base.armor = 0; //방어력     
                base.range = 5; // 공격사거리
                base.sight = 7; // 시야
                base.buildTime = 60; // 생산속도
                base.attackSpeed = 30; // 공격속도
                base.moveSpeed = 3.126f; // 이동속도
                base.isfly = false; // 비행 여부
            }
    }

    public class Drop_Ship : TerranBase
    {
        public Drop_Ship()
        {
                base.curHp = 150; //현재체력
                base.maxHp = 150; // 최대체력
                base.minerals = 100; // 소모 미네랄
                base.gas = 100; //소모 가스
                base.pop = 2; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격사거리
                base.sight = 8; // 시야
                base.buildTime = 50; // 생산속도
                base.attackSpeed = 0; // 공격속도
                base.moveSpeed = 2.563f; // 이동속도
                base.isfly = true; // 비행 여부
            }
    }

    public class Science_Vessel : TerranBase
    {
        public Science_Vessel()
        {
                base.curHp = 200; //현재체력
                base.maxHp = 200; // 최대체력
                base.minerals = 100; // 소모 미네랄
                base.gas = 225; //소모 가스
                base.pop = 2; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 0; // 공중 공격
                base.armor = 1; //방어력     
                base.range = 0; // 공격사거리
                base.sight = 10; // 시야
                base.buildTime = 80; // 생산속도
                base.attackSpeed = 0; // 공격속도
                base.moveSpeed = 2.344f; // 이동속도
                base.isfly = true; // 비행 여부
            }

    }

    public class Battlecruiser : TerranBase
    {
        public Battlecruiser()
        {
                base.curHp = 500; //현재체력
                base.maxHp = 500; // 최대체력
                base.minerals = 400; // 소모 미네랄
                base.gas = 300; //소모 가스
                base.pop = 6; // 소모 인구수
                base.groundAtk = 25; // 지상 공격력
                base.airAtk = 25; // 공중 공격
                base.armor = 3; //방어력     
                base.range = 6; // 공격사거리
                base.sight = 11; // 시야
                base.buildTime = 133; // 생산속도
                base.attackSpeed = 30; // 공격속도
                base.moveSpeed = 1.172f; // 이동속도
                base.isfly = true; // 비행 여부
            }

    }

    public class Valkyrie : TerranBase
    {
        public Valkyrie()
            {
                base.curHp = 200; //현재체력
                base.maxHp = 200; // 최대체력
                base.minerals = 250; // 소모 미네랄
                base.gas = 125; //소모 가스
                base.pop = 3; // 소모 인구수
                base.groundAtk = 0; // 지상 공격력
                base.airAtk = 6 * 8; // 공중 공격
                base.armor = 2; //방어력     
                base.range = 6; // 공격사거리
                base.sight = 8; // 시야
                base.buildTime = 50; // 생산속도
                base.attackSpeed = 64; // 공격속도
                base.moveSpeed = 3.094f; // 이동속도
                base.isfly = true; // 비행 여부
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

    ///테란(Terran) end-----------------------------------------------------------------------------------------------
}