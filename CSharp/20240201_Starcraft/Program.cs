using System;
using System.Buffers.Text;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SonJiTerran;
using static Sonji.Protoss;
using Sonji;
using static SonJiTerran.Terran;
using static SonJiTerran.Terran.TBuilding;


namespace Sonji
{
    public enum ETUnitList
    {
        SCV, Marine, Medic, FireBat, Ghost, Vulture, Goliath, Tank, Siege_Tank,
        Wraith, Drop_Ship, Science_Vessel, Battlecruiser, Valkyrie
    }
    public enum ETBuildingList
    {
        Command_Center, Comsat_Station, Nuclear_Silo, Supply_Depot, Refiery, Academy, Engineering_bay, Misiile_Turret,
        Bunker, Factory, Machine_shop, StarPort, Control_Tower, Science_Facility, Physics_Lab, Covert_Ops
    }
    public class Program

    {
        public class GameObject
        {
            protected int curHp = 0; //현재체력
            protected int maxHp = 0; // 최대체력+
            protected int armor = 0;
            protected int minerals = 50;
            protected int gas = 0;
            protected int pop = 1;
        }
        //코스트
        public class TerranCost
        {
            public int mineral = 0;
            public int vespenegas = 0;
            public int curPop = 8;
            public int maxPop = 200;
            //일꾼의 수 X 초당 미네랄 및 가스 
        }
        public class ZergCost
        {
            public int mineral = 0;
            public int vespenegas = 0;
            public int curPop = 8;
            public int maxPop = 200;
            //일꾼의 수 X 초당 미네랄 및 가스 
        }
        public class ProtossCost
        {
            public int mineral = 0;
            public int vespenegas = 0;
            public int curPop = 8;
            public int maxPop = 200;
            //일꾼의 수 X 초당 미네랄 및 가스 
        }



        public void PrintAll(string[] _args)
        {
            
        }



        // 코스트
        public static void Main(string[] _args)
        {
            Console.WriteLine("Hello, StartCraft!");

            //Terran.TBuilding Command_Center = Terran.Build(ETBuildingList.Command_Center);
            Command_Center temp = new Command_Center();
            Marine marine = new Marine();

            temp.Command_center_Lift(true);//커맨드 센터 띄우기            
            Console.WriteLine($"비행상태 : {temp.isfly} 입니다."); // 띄우는거 확인
            Console.WriteLine($"이동속도 : {temp.moveSpeed} 입니다."); // 띄우는거 확인
            temp.Command_center_Lift(false);//커맨드 센터 띄우기
            Console.WriteLine($"비행상태 : {temp.isfly} 입니다."); // 띄우는거 확인
            Console.WriteLine($"이동속도 : {temp.moveSpeed} 입니다."); // 띄우는거 확인
            //PrintAll(temp);
            Console.WriteLine($"현재이동속도 : {marine.moveSpeed} 입니다."); // 띄우는거 확인
            marine.Marine_StimPack();
            Console.WriteLine($"현재이동속도 : {marine.moveSpeed} 입니다."); // 띄우는거 확인


            Protoss protoss = new Protoss();
            Protoss.PUnit defaultProve = Protoss.PUnitSpawn(Protoss.EPrtossUnits.Probe);
            Protoss.PBuilding pBuilding = ((Protoss.Probe)defaultProve).MakePBuilding(Protoss.EPrtossBuildings.Nexus);

            Protoss.PUnit pUnit = ((Protoss.Nexus)pBuilding).MakePUnit(Protoss.EPrtossUnits.DarkTemplar);



        }




    }
}