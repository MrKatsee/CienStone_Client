using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    private static int turn;
    public static int Turn
    {
        get
        {
            return turn;
        }
        set
        {
            turn = value;
            OnTurnChanged?.Invoke(turn);
        }
    }

    public static int Count
    {
        get
        {
            if (players == null) return 0;
            return players.Count;
        }
    }

    private static List<MyPlayer> players;

    public static List<MyPlayer> GetPlayers()
    {
        if (players == null) return null;
        return players;
    }

    public delegate void EventHandler_Turn(int _turn);
    public static event EventHandler_Turn OnTurnChanged;

    public int index;
    public int team;
    public MyCard Player { get; private set; }
    public List<MyCard> Deck { get; private set; }
    public List<MyCard> Field { get; private set; }
    public List<MyCard> Hand { get; private set; }
    public List<MyCard> Grave { get; private set; }

    public static void Init()
    {
        Turn = 0;
        players = new List<MyPlayer>();
    }

    public static MyPlayer Create(int team, MyCard player)
    {
        MyPlayer newPlayer = new GameObject("Player_" + Count).AddComponent<MyPlayer>();
        newPlayer.team = team;
        newPlayer.Player = player;
        newPlayer.Field.Add(player);                        // 플레이어 또한 필드에 있는 것으로 간주한다.
        OnTurnChanged += newPlayer.OnTurn;
        players.Add(newPlayer);
        players.Sort((x, y) => x.team.CompareTo(y.team));   // 팀 변수를 기준으로 하여 오름차순으로 정렬한다.
        return newPlayer;
    }

    private void OnTurn(int _turn)
    {

    }

    private void OnDestroy()
    {
        OnTurnChanged -= OnTurn;
    }

}
