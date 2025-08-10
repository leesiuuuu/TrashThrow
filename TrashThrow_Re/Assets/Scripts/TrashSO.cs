using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu]
public class TrashSO : ScriptableObject
{
    public string Name;
    public Size Size;
    public Weight Weight;
}

public enum Size
{
    small = 0,
    medium,
    big
}
public enum Weight
{
    verylight = 0,
    light,
    medium,
    heavy
}
