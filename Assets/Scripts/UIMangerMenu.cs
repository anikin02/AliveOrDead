using UnityEngine;
using UnityEngine.UI;

public class UIMangerMenu : MonoBehaviour
{
    [SerializeField] private Text counterMoney;
    [SerializeField] private Text counterWaves;

    private void Update()
    {
        changeUI();
    }

    private void changeUI()
    {
        counterMoney.text = DataHolder.Money.ToString();
        counterWaves.text = "Your record waves: " + DataHolder.Wave.ToString();
    }
}
