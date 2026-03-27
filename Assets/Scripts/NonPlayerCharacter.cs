using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public void Falar()
    {
        UIHandler.instance.DisplayDialogue();
    }
}