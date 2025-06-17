using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu]
public class TrashSO : ScriptableObject
{
    public string name;
    public Size size;
    public Weight weight;
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
