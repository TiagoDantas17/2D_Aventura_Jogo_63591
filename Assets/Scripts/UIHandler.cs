using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    private VisualElement m_Healthbar;
    public static UIHandler instance { get; private set; }

    public UIDocument uiDocument;

    public float displayTime = 4.0f;
    private VisualElement m_NonPlayerDialogue;
    private float m_TimerDisplay;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (uiDocument == null)
        {
            Debug.LogError("Falta ligar o UIDocument no Inspector.");
            return;
        }

        VisualElement root = uiDocument.rootVisualElement;

        if (root == null)
        {
           Debug.Log("rootVisualElement está vazio.");
            return;
        }

        m_Healthbar = root.Q<VisualElement>("HealthBar");
        if (m_Healthbar == null)
        {
           Debug.Log("Não encontrou 'HealthBar'.");
        }

        m_NonPlayerDialogue = root.Q<VisualElement>("Background");
        if (m_NonPlayerDialogue == null)
        {
            Debug.Log("Não encontrou 'Background'.");
            return;
        }

        if (m_Healthbar != null)
        {
            SetHealthValue(1.0f);
        }

        m_NonPlayerDialogue.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;
    }

    private void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;

            if (m_TimerDisplay < 0 && m_NonPlayerDialogue != null)
            {
                m_NonPlayerDialogue.style.display = DisplayStyle.None;
            }
        }
    }

    public void SetHealthValue(float percentage)
    {
        if (m_Healthbar != null)
        {
            m_Healthbar.style.width = Length.Percent(100 * percentage);
        }
    }

    public void DisplayDialogue()
    {
        Debug.Log("DisplayDialogue 1");

        if (m_NonPlayerDialogue != null)
        {
            Debug.Log("DisplayDialogue 2");

            m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
            m_TimerDisplay = displayTime;
        }
    }
}