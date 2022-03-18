using UnityEngine;
using UnityEngine.UI;

public class SkipScene : MonoBehaviour {
    public string sceneName;
    public Button skipBtn;

    void Start () {
        skipBtn.onClick.AddListener(delegate {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        });
	}
}
