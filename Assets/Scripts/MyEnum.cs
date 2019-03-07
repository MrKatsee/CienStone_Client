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
        DISABLE
    }

    public enum CardState
    {
        ERROR = 0,
        FIELD,
        HAND,
        GRAVE,
        DECK,
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