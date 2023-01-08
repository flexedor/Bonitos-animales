using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public enum Biomes
    {
        Desert,
        Iceland,
        Swamp,
        Forest,
        Ocean,
        Tundra,
        Savanna,
        Rainforest,
        Steppe
    }
    
   
}
