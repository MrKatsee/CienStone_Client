using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class MyEnum
{
    public enum ChainType
    {
        ERROR = 0,
        TURN_START,
        TURN_DRAW,

        TURN_END,
    }

    public enum CardType
    {
        ERROR = 0,
        MONSTER,                    // '몬스터' 타입
        MAGIC,                      // '마법' 타입. 필드에 소환되지 아니하며, 패에서 사용한 즉시 코스트를 사용하고 효과를 발휘한다.
        TRAP                        // '함정' 타입. 필드에 상대방이 보지 못하는 형태로 코스트를 지불하고 소환되며, 조건을 만족하면 효과를 발휘한다.
    }

    public enum CardState
    {
        ERROR = 0,
        FIELD,                      // 이 카드는 '필드'에 있다.
        HAND,                       // 이 카드는 '패'에 있다.
        GRAVE,                      // 이 카드는 '묘지'에 있다.
        DECK,                       // 이 카드는 '덱'에 있다.
    }

    public enum CardAttribute
    {
        ERROR = 0,
        RUSH,                       // '돌진' 속성. 소환된 턴에도 공격할 수 있다.
        TAUNT,                      // '도발' 속성. 상대방은 이 속성을 가진 카드'들'을 우선적으로 파괴해야한다.
    }

    public static T Parse<T>(int value)
    {
        if (!Enum.IsDefined(typeof(T), value)) return default;
        return (T)Enum.Parse(typeof(T), Enum.GetName(typeof(T), value));
    }

    public static T Parse<T>(string value)
    {
        if (!Enum.IsDefined(typeof(T), value)) return default;
        return (T)Enum.Parse(typeof(T), value);
    }

    public static int Count<T>()
    {
        return Enum.GetValues(typeof(T)).Length;
    }

}