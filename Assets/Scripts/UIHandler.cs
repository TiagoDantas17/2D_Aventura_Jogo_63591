
using UnityEngine;
using TMPro; // Se usares TextMeshPro


public class UIHandler : MonoBehaviour
{

    public static UIHandler instance { get; private set; }

    public GameObject dialoguePanel; // Arraste o Painel aqui no Inspetor
    public float displayTime = 4.0f;
    private float m_TimerDisplay;

    void Awake()
    {
        instance = this;
    }


    void Start()

    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false); // Garante que começa escondido
        }
        m_TimerDisplay = -1.0f;
    }

    void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;
            if (m_TimerDisplay <= 0)
            {
                dialoguePanel.SetActive(false);
            }
        }
    }

    public void DisplayDialogue()
    {
        if (dialoguePanel != null)
        {
            Debug.Log("UIHandler: A receber ordem para mostrar o diálogo!");
            dialoguePanel.SetActive(true);
            m_TimerDisplay = displayTime;
        }
    }
   

// Função para a barra de vida (opcional se não tiveres barra)
public void SetHealthValue(float percentage) { }
}