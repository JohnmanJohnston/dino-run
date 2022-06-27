using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static bool GameHasEnded;
    private void Awake() => GameHasEnded = false;

    public static IEnumerator OnLose() {
        GameHasEnded = true;
        Time.timeScale = 0.2f;
        
        yield return new WaitForSecondsRealtime(1f);
        
        int TargetBuildIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        SceneManager.LoadScene(TargetBuildIndex);
    }
}
