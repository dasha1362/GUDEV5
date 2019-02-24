using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;
    private int levelToLoad;

    // void Start() {
    //     button.onClick.addListener(x
    //     );
    // }
    // Update is called once per frame
    void Update()
    {
    }


    public void FadeToLevel (int levelIndex) {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete () {
        SceneManager.LoadScene(levelToLoad);
    }
}
