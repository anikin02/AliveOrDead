using UnityEngine;

public class RestartGame : MonoBehaviour
{
    private bool isEnabled = true;
    public void EnableButton()
    {
        isEnabled = !isEnabled;
        gameObject.SetActive(isEnabled);
    }
}
