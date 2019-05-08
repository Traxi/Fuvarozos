
using UnityEngine;

public class IngameUIController : MonoBehaviour
{

    public ShopUIController ShopUiController;

    public AuctionUIController AuctionUiController;

    public CitiesDropdownController CitiesDropdownController;

    public void Start()
    {
        Instance = this;
    }
    public static IngameUIController Instance { get; private set; }
}
