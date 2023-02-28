using UnityEngine;
using UnityEngine.UI;

public class BuyNewCharacter : MonoBehaviour
{
    [SerializeField] private int id;
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(buying);
    }

    private void buying()
    {
        if (id < 3)
        {
            DataHolder.players[id] = true; 
        }
        else
        {
            DataHolder.CounterAidKit++;
        }
    }
}
