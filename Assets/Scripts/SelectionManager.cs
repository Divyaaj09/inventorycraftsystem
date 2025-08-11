using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }

    public bool onTarget;
    public GameObject selectedObject;

    public GameObject interaction_Info_UI;
    private Text interaction_text;

    private void Awake()
    {
        // Ensure singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        onTarget = false;

        if (interaction_Info_UI != null)
        {
            interaction_text = interaction_Info_UI.GetComponent<Text>();
        }
        else
        {
            Debug.LogError("SelectionManager: interaction_Info_UI is not assigned in the inspector!");
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            InteractableObject interactable = selectionTransform.GetComponent<InteractableObject>();

            if (interactable != null && interactable.playerInRange)
            {
                onTarget = true;
                selectedObject = interactable.gameObject;

                if (interaction_text != null)
                {
                    interaction_text.text = interactable.GetItemName();
                }

                interaction_Info_UI?.SetActive(true);
            }
            else
            {
                onTarget = false;
                interaction_Info_UI?.SetActive(false);
                selectedObject = null;
            }
        }
        else
        {
            onTarget = false;
            interaction_Info_UI?.SetActive(false);
            selectedObject = null;
        }
    }
}
