using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> tutors;
    public Button tabBtn;

    private int idTutorActive;

    private void Start()
    {
        idTutorActive = 0;
        tutors[0].SetActive(true);
    }

    public void ClickTab()
    {
        if (idTutorActive < tutors.Count - 1)
        {
            tutors[idTutorActive].SetActive(false);
            idTutorActive += 1;
            tutors[idTutorActive].SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
