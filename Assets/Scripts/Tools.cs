using UnityEngine;
using System;

public class Tools
{
    public static T RandomEnumValue<T>()
    {
        var value = System.Enum.GetValues(typeof(T));
        return (T)value.GetValue(new System.Random().Next(value.Length));
    }
}