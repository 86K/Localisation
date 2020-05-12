/*
*R0-V1.0
*Modify Date:2019-12-4
*Modifier:ZoJet
*Modify Content:
*/

using UnityEngine;
using UnityEngine.UI;

public class SkipScene : MonoBehaviour {
    public string sceneName;
    public Button skipBtn;

	private void Start () {
        skipBtn.onClick.AddListener(delegate {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        });
	}
}
