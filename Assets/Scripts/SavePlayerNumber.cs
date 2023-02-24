using UnityEngine;
using UnityEngine.UI;

public class SavePlayerNumber : MonoBehaviour
{
    [SerializeField] private int numberPlayer;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(choicePlayer);
    }

    private void choicePlayer()
    {
        ChoicePlayer.numberPlayer = numberPlayer;
    }
}
