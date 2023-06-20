using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{

    public void OnButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}