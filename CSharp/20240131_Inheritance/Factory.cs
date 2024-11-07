using System;

public class Factory() {
    public enum EMonsterType {
        Orc, DarkElf
    }

    public class Monster {
        public int hp = 0;
        public int mp = 0;
        public int atk = 0;
        public int def = 0;
    }

    public class DarkElf : Monster
    {
        public int arrow = 0;

        public DarkElf()
        {
            base.hp = 123;
            base.mp = 987;
            base.atk = 21;
            base.def = 92;

            this.arrow = 1000;
        }
    }

    //Monster orc; =/= Orc : Monster
    // public class BossOrc : Orc { } // 오크인데 변경사항이 더 있는 오크

    public class Orc : Monster {
        public int rage = 0;
    }

    public Orc SpawnOrc()
    {
        Orc orc = new Orc();
        orc.hp = 100;
        orc.mp = 200;
        orc.atk = 1000;
        orc.def = 10;
        orc.rage = 200;
        return orc;
    }

    public DarkElf SpawnDarkElf() {
        return new DarkElf();
    }

    public static Monster Spawn(EMonsterType _type) { // Monster라는 부모형으로 선언하고 Monster 클래스를 상속받은 Orc, DarkElf등의 각 몬스터 클래스로 동적할당함. 사용할때 Downcasting해서 쓰면 됨
        switch (_type)
        {
            case EMonsterType.Orc:
                return new Orc();
            case EMonsterType.DarkElf:
                return new DarkElf();
        }
        return null;

        // is~a / has~a 자식은 부모의 모든 것을 사용해야함 부모는 모든 자식이 필요로 하는 것을 가지고 있어야 함
        // 챔피언 클래스 - 챔피언을 상속받은 mp있는 클래스, 챔피언을 상속받은 분노있는 클래스, 챔피언을 상속받은 기력 있는 클래스, 챔피언을 상속받은 보조게이지없는 클래스
        // 챔피언을 상속받은 mp있는 클래스를 상속받은 라이즈, 트페, 케틀 등
        // 챔피언을 상속받은 분노있는 클래스를 상속받은 나르, 레넥톤 등
        // 챔피언을 상속받은 기력 있는 클래스를 상속받은 아칼리, 제드 등
        // 챔피언을 상속받은 보조게이지없는 클래스를 상속받은 자크 등
        // 근데 한명 빼고 모두가 필요한데 그게 딱 변수 하나라면 그냥 직접 다 넣어야하나
        // mp, 분노, 기력 등의 변수 하나 차이인데 변수 하나 들어있는 클래스를 다 따로 만들어야하나
    }
}