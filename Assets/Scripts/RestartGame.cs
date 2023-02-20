using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(changeScene);
    }

    private void changeScene()
    {   
        SceneManager.LoadScene("PlayScene");
    }

    public void EnableButton()
    {
        gameObject.SetActive(true);
    }
}
