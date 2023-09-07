using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    public TMP_Text introText;

    private string text =
        "Amidst the untouched wilderness, a tale unfolds in the heart of a remote, enigmatic island. " +
        "Journey back to a time when modern comforts were mere whispers in the wind, and survival was an " +
        "instinct etched into every breath. As you step into the shoes of a lone castaway," +
        " the game of Survival Island beckons, inviting you to unveil the secrets of nature's dominion. ";

    public float delta;
    private IEnumerator Start()
    {
        int i = 0;
        while (i < text.Length)
        {
            introText.text += text[i];
            i++;
            yield return new WaitForSeconds(delta);
        }
    }

    public void LoadSceneGame()
    {
        SceneManager.LoadScene(1);
    }
}
