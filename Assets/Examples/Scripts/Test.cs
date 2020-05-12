/*
*R0-V1.0
*Modify Date:2019-12-4
*Modifier:ZoJet
*Modify Content:
*/

using GameFramework.Localisation;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    //1.固定文字
    //2.动态文字 

    public Button zh_CNBtn, en_USBtn, skipBtn;

    void Awake() {
        GlobalLocalisation.Load();
    }

    private void Start() {
        en_USBtn.onClick.AddListener(delegate {
            GlobalLocalisation.Language = SystemLanguage.English.ToString();
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        });

        zh_CNBtn.onClick.AddListener(delegate {
            GlobalLocalisation.Language = SystemLanguage.ChineseSimplified.ToString();
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        });

        skipBtn.onClick.AddListener(delegate {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scene02");
        });
    }
}
