using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PopupPause : Popup
{
    [SerializeField]
      Button resumeBtn, settingBtn, saveBtn, exitBtn;
    
    public void OnClickSettingsBtn()
    {
        PopupController.instance.popupSettings.Show(null);
    }

    public void OnClickExitBtn()
    {
        SceneManager.LoadScene(0);
    }
}
