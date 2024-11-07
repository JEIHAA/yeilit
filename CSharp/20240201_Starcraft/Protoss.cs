using Sonji;
using System;
using System.Threading;
using static Sonji.Program;
using static Sonji.Protoss;
using static SonJiTerran.Terran.TBuilding;


namespace Sonji
{
    partial class Protoss
    {
        public enum EPrtossUnits
        {
            Probe, Zealot, Dragoon, HighTemplar, Archon, DarkTemplar, DarkArchon, Reaver,
            Scout, Carrier, Corsair, Arbiter, Observer
        }
        public enum EPrtossBuildings
        {
            Nexus, Pylon, Assimilator, Gateway, Forge, PhotonCannon,
            CyberneticsCore, ShieldBattery, RoboticsFacility, RoboticsSupportBay,
            Observatory, CitadelOfAdun, TemplarArchives, Stargate, FleetBeacon, ArbiterTribunal
        }
        public class PBuilding : GameObject
        {
            protected int shield = 0; // 실드
            protected int shieldArmor = 0; // 실드 방어력
        }
        public class UnitBase : GameObject
        {
            protected int groundAtk = 0; // 지상 공격력
            protected int airAtk = 0; // 공중 공격
            protected int range = 0; //  공격사거리
            protected int sight = 0; //  시야
            protected int buildTime = 0; // 생산속도
            protected int attackSpeed = 0; // 공격속도
            protected float moveSpeed = 0.0f; // 이동속도
            protected bool isFly = false; // 비행 여부
        }
        public class PUnit : UnitBase
        {
            protected int shield = 0; // 실드
            protected int shieldArmor = 0; // 실드 방어력
        }

        public class Probe : PUnit
        {
            public Probe()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }

            public PBuilding MakePBuilding (EPrtossBuildings _type) {
                PBuilding building = Protoss.PbuildingSpawn(_type);
                Console.WriteLine($"\n{_type}생성");
                return building;
            }
        }
        protected class Zealot : PUnit
        {
            public Zealot()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }
        protected class Dragoon : PUnit
        {
            public Dragoon()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }
        protected class HighTemplar : PUnit
        {
            public HighTemplar()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }
        protected class Archon : PUnit
        {
            public Archon()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }
        protected class DarkTemplar : PUnit
        {
            public DarkTemplar()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }
        protected class DarkArchon : PUnit
        {
            public DarkArchon()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }
        protected class Reaver : PUnit
        {
            public Reaver()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }
        protected class Scout : PUnit
        {
            public Scout()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }
        protected class Carrier : PUnit
        {
            public Carrier()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }
        protected class Corsair : PUnit
        {
            public Corsair()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }
        protected class Arbiter : PUnit
        {
            public Arbiter()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }
        protected class Observer : PUnit
        {
            public Observer()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.airAtk = 0;
                base.groundAtk = 5;
                base.armor = 0;
                base.range = 1;
                base.sight = 8;
                base.buildTime = 20;
                base.attackSpeed = 22;
                base.moveSpeed = 2.344f;
                base.isFly = false;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
        }

        public static PUnit PUnitSpawn(EPrtossUnits _type)
        {
            switch (_type)
            {
                case EPrtossUnits.Probe:
                    return new Probe();
                case EPrtossUnits.Zealot:
                    return new Zealot();
                case EPrtossUnits.Dragoon:
                    return new Dragoon();
                case EPrtossUnits.HighTemplar:
                    return new HighTemplar();
                case EPrtossUnits.Archon:
                    return new Archon();
                case EPrtossUnits.DarkTemplar:
                    return new DarkTemplar();
                case EPrtossUnits.DarkArchon:
                    return new DarkArchon();
                case EPrtossUnits.Reaver:
                    return new Reaver();
                case EPrtossUnits.Scout:
                    return new Scout();
                case EPrtossUnits.Carrier:
                    return new Scout();
                case EPrtossUnits.Corsair:
                    return new Corsair();
                case EPrtossUnits.Arbiter:
                    return new Arbiter();
                case EPrtossUnits.Observer:
                    return new Observer();
            }
            return null;
        }


        interface PProductionBuilding
        {
            protected void ProductionPUnit();
        }

        interface PUpgradeBuilding
        {
            protected void UpgradePUnit();
        }

        interface PTechTreeBuilding
        {
            protected void TechTreeOpen();
        }

        public class Nexus : PBuilding, PProductionBuilding
        {
            public Nexus()
            {
                base.curHp = 20;
                base.maxHp = 20;
                base.armor = 0;
                base.minerals = 50;
                base.gas = 0;
                base.pop = 1;
                base.shield = 20;
                base.shieldArmor = 0;
            }
            public PUnit MakePUnit(EPrtossUnits _type)
            {
                PUnit pUnit = Protoss.PUnitSpawn(_type);
                Console.WriteLine($"\n{_type}생성");
                return pUnit;
            }


            public void ProductionPUnit() { }


        }
        
        protected class Gateway : PBuilding, PProductionBuilding, PTechTreeBuilding
        {
            public void ProductionPUnit() { }
            public void TechTreeOpen() { }
        }
        protected class RoboticsFacility : PBuilding, PProductionBuilding, PTechTreeBuilding
        {
            public void ProductionPUnit() { }
            public void TechTreeOpen() { }
        }
        protected class Stargate : PBuilding, PProductionBuilding
        {
            public void ProductionPUnit() { }
        }

        protected class Forge : PBuilding, PUpgradeBuilding, PTechTreeBuilding
        {
            public void UpgradePUnit() { }
            public void TechTreeOpen() { }
        }
        protected class PhotonCannon : PBuilding
        {

        }

        protected class RoboticsSupportBay : PBuilding, PUpgradeBuilding, PTechTreeBuilding
        {
            public void UpgradePUnit() { }
            public void TechTreeOpen() { }
        }
        protected class TemplarArchives : PBuilding, PUpgradeBuilding, PTechTreeBuilding
        {
            public void UpgradePUnit() { }
            public void TechTreeOpen() { }
        }
        protected class FleetBeacon : PBuilding, PUpgradeBuilding, PTechTreeBuilding
        {
            public void UpgradePUnit() { }
            public void TechTreeOpen() { }
        }
        protected class ArbiterTribunal : PBuilding, PUpgradeBuilding
        {
            public void UpgradePUnit() { }
        }
        protected class CitadelOfAdun : PBuilding, PUpgradeBuilding, PTechTreeBuilding
        {
            public void UpgradePUnit() { }
            public void TechTreeOpen() { }
        }
        protected class CyberneticsCore : PBuilding, PUpgradeBuilding, PTechTreeBuilding
        {
            public void UpgradePUnit() { }
            public void TechTreeOpen() { }
        }
        protected class Observatory : PBuilding, PTechTreeBuilding
        {
            public void TechTreeOpen() { }
        }
        protected class Assimilator : PBuilding
        {
         
        }
        protected class Pylon : PBuilding
        {

        }
        protected class ShieldBattery : PBuilding
        {
         
        }
        
        public static PBuilding PbuildingSpawn(EPrtossBuildings _type)
        {
            switch (_type)
            {
                case EPrtossBuildings.Nexus:
                    return new Nexus();

                case EPrtossBuildings.Pylon:
                    return new Pylon();

                case EPrtossBuildings.Assimilator:
                    return new Assimilator();

                case EPrtossBuildings.Gateway:
                    return new Gateway();

                case EPrtossBuildings.Forge:
                    return new Forge();

                case EPrtossBuildings.PhotonCannon:
                    return new PhotonCannon();

                case EPrtossBuildings.CyberneticsCore:
                    return new CyberneticsCore();

                case EPrtossBuildings.ShieldBattery:
                    return new ShieldBattery();

                case EPrtossBuildings.RoboticsFacility:
                    return new RoboticsFacility();

                case EPrtossBuildings.RoboticsSupportBay:
                    return new RoboticsSupportBay();

                case EPrtossBuildings.Observatory:
                    return new Observatory();

                case EPrtossBuildings.CitadelOfAdun:
                    return new CitadelOfAdun();

                case EPrtossBuildings.Stargate:
                    return new Stargate();

                case EPrtossBuildings.FleetBeacon:
                    return new FleetBeacon();

                case EPrtossBuildings.ArbiterTribunal:
                    return new ArbiterTribunal();

            }
            return null;
        }

    }
}
///프로토스(Protoss) end-------------------------------------------------------------------------------------------







