using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MyChain
{
    private static bool isInit;
    private static List<MyPlayer> players;

    private static void ChainReaction(MyChain masterChain)
    {
        if (!isInit) return;
        MyPlayer master = masterChain.Master;
        List<MyPlayer> friends = players.FindAll(x => x.team == master.team && x != master);
        List<MyPlayer> enemies = players.FindAll(x => x.team != master.team);

        
        // 일단 보류!!!!!
        bool isEnd = false;
        List<MyChain> parentChain = new List<MyChain>() { masterChain };
        List<MyChain> childChain = new List<MyChain>();
        List<MyChain> masterChainData = new List<MyChain>();
        Dictionary<MyChain, List<MyChain>> chainData = new Dictionary<MyChain, List<MyChain>>();
        while (!isEnd)
        {
            isEnd = true;
            for (int parentLoop = 0; parentLoop < parentChain.Count; ++parentLoop)
            {
                for (int positionLoop = 1; positionLoop < MyEnum.Count<MyEnum.CardState>(); ++positionLoop)
                {
                    for (int targetLoop = 0; targetLoop < 1 + friends.Count + enemies.Count; ++targetLoop)
                    {
                        MyPlayer targetPlayer = null;
                        if (targetLoop == 0) targetPlayer = master;
                        else if (0 <= targetLoop - 1 && targetLoop - 1 < friends.Count) targetPlayer = friends[targetLoop - 1];
                        else if (0 <= targetLoop - friends.Count - 1 && targetLoop - friends.Count - 1 < enemies.Count) targetPlayer = enemies[targetLoop - friends.Count - 1];

                        if (targetPlayer == null) continue;

                        List<MyCard> targetCard = null;
                        switch (MyEnum.Parse<MyEnum.CardState>(positionLoop))
                        {
                            case MyEnum.CardState.FIELD: targetCard = targetPlayer.field; break;
                            case MyEnum.CardState.HAND: targetCard = targetPlayer.hand; break;
                            case MyEnum.CardState.GRAVE: targetCard = targetPlayer.grave; break;
                            case MyEnum.CardState.DECK: targetCard = targetPlayer.deck; break;
                        }

                        if (targetCard == null) continue;

                        for (int loop = 0; loop < targetCard.Count; ++loop)
                        {
                            MyChain newChain = targetCard[loop].ChainReaction(parentChain[parentLoop]);
                            if (newChain != null)
                            {
                                isEnd = false;
                                childChain.Add(newChain);
                                if (newChain.IsEndChain) goto NEXTLOOP;
                            }
                        }
                    }
                }
                NEXTLOOP:
                chainData.Add(parentChain[parentLoop], childChain);
                masterChainData.Add(parentChain[parentLoop]);
            }
            parentChain.Clear();
            parentChain.AddRange(childChain);
            childChain.Clear();
        }
    }

    public static void Init(params MyPlayer[] _players)
    {
        if (!isInit) isInit = true;
        players = new List<MyPlayer>(_players);
    }

    public MyPlayer Master { get; private set; }                        // 체인을 발생시킨 주체
    public List<MyCard> Cards { get; private set; }                     // 체인의 대상이 되는 카드
    public MyEnum.ChainType ChainType { get; private set; }             // 체인의 종류
    public bool IsEndChain => ChainType == MyEnum.ChainType.DISABLE;    // 무효화 하는 체인인지 체크

    public MyChain(MyPlayer master, MyEnum.ChainType chainType)
    {
        Master = master;
        ChainType = chainType;
    }

    public MyChain(MyPlayer master, MyEnum.ChainType chainType, params MyCard[] cards)
    {
        Master = master;
        ChainType = chainType;
        Cards = new List<MyCard>(cards);
    }

    public void Start()
    {
        ChainReaction(this);
    }

    public bool Execute()                                   // 이 실행이 상위 실행을 무효화 시키지 않는다면 true를 리턴.
    {
        return true;
    }


}
