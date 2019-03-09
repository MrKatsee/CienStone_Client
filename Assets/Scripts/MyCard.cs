using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCard
{
    public static List<MyCard> Parse(MyPlayer _master, params int[] indexs)
    {
        return new List<MyCard>();
    }

    public MyPlayer master { get; private set; }
    public MyEnum.CardState cardState { get; set; }

    private MyCardData cardData;

    public MyCard(MyPlayer _master)
    {
        master = _master;
    }

    public MyCard(MyPlayer _master, int _index)
    {
        master = _master;
    }

    public MyChain ChainReaction(MyChain parentChain)
    {
        return null;
    }
}
