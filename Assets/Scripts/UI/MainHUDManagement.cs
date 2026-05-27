using UnityEngine;
using UnityEngine.UIElements;

public class MainHUDManagement : MonoBehaviour
{
    private static MainHUDManagement instance;

    public static MainHUDManagement GetInstance()
    {
        return instance;
    }

    void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Root
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Interaction section
        interactionSection = root.Q<VisualElement>("InteractionSection");
        interactionItemImage = interactionSection.Q<Image>("InteractionItemImage");
        interactionItemText = interactionSection.Q<Label>("InteractionItemText");

        // Status bar
        healthBar = root.Q<ProgressBar>("Health");
        manaBar = root.Q<ProgressBar>("Mana");
        levelBar = root.Q<ProgressBar>("Level");

        // Clear init stat
        SetInteractionItem(null, null);
    }

    // Interaction
    private VisualElement interactionSection;
    private Image interactionItemImage;
    private Label interactionItemText;

    public void SetInteractionItem(string text, Texture2D image)
    {
        interactionItemText.text = text;
        interactionItemImage.image = image;

        if (text == null)
        {
            // when interaction is cleared
            interactionSection.style.right = Length.Percent(-50);
        }
        else
        {
            // when interaction is setted
            interactionSection.style.right = Length.Percent(0);
        }
    }

    // Status bar
    private ProgressBar healthBar;
    private ProgressBar manaBar;
    private ProgressBar levelBar;

    public void SetHealth(float health)
    {
        healthBar.value = health;
    }

    public void SetMana(float health)
    {
        manaBar.value = health;
    }

    public void SetLevel(float health)
    {
        levelBar.value = health;
    }
}
