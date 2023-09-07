using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DataItem", menuName = "Popup/ new DataItem")]
public class DataItem : ScriptableObject
{
    public List<Sprite> listItemIcon;
    public List<Sprite> listEquiptableItemIcons;
}
