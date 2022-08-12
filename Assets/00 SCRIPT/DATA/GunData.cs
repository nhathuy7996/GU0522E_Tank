using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GunData", menuName ="DATA/Gun")]
public class GunData : ScriptableObject
{
    public float AtkSpeed => DataManager.Instant.atkSpeed;
    public float Dmg;
    public GameObject butlletPrefab;
}
