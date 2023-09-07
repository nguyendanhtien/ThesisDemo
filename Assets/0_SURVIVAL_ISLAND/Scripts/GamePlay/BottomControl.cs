using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomControl : MonoBehaviour
{
    public GameObject itemsEquipted;

    public void OpenListItem()
    {
        itemsEquipted.SetActive(true);
    }

    public void CloseListItem()
    {
        itemsEquipted.SetActive(false);
    }
}
