using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    // Public singleton so other scripts can access Instance.RefreshNeededItems()
    public static CraftingSystem Instance { get; private set; }

    // example public flag used elsewhere
    public bool isOpen;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // Optional: DontDestroyOnLoad(gameObject);
    }

    // <-- This must be public so InventoryItem/TrashSlot can call it
    public void RefreshNeededItems()
    {
        // Put your crafting refresh logic here.
        Debug.Log("CraftingSystem: RefreshNeededItems called.");
    }
}
