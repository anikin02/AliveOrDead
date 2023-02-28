using UnityEngine;
using UnityEngine.UI;

public class OpenCloseShop : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject shop;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(openClose);
    }

    private void openClose()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        shop.SetActive(!shop.activeSelf);
    }
}
