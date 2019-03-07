using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MyCard
{
    public MyPlayer master { get; private set; }
    public MyEnum.CardState cardState { get; set; }

    public MyCard(MyPlayer _master)
    {
        master = _master;
    }

    public MyChain ChainReaction(MyChain parentChain)
    {
        // parentChain 이 반응하는 체인인지 확인한다.
        return null;
    }
}
