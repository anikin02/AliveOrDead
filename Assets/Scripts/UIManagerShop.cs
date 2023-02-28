using UnityEngine;
using UnityEngine.UI;

public class UIManagerShop : MonoBehaviour
{
    [SerializeField] private Text counterMoney;
    [SerializeField] private GameObject[] characters;
    private void Start()
    {
        
    }

    private void Update()
    {
        changeUI();
    }

    private void changeUI()
    {
        counterMoney.text = DataHolder.Money.ToString();

        for (int i = 0; i < characters.Length; i++)
        {
            if (DataHolder.players[i])
            {
                characters[i].GetComponent<Button>().interactable = false;
                characters[i].GetComponent<Image>().color = new Color(168, 94, 94, 255);
            }
        }
    }
}
