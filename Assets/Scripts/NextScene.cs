using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    [SerializeField] private string nameScene; 
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(changeScene);
    }

    private void changeScene()
    {   
        SceneManager.LoadScene(nameScene);
    }
}
