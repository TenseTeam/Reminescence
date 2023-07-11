using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Base Item")]
public class ItemBaseData : ScriptableObject
{
    public ItemType Type;
    public AudioClip AudioSFX;
}
