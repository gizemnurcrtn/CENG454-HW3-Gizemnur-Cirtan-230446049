using TMPro;
using UnityEngine;

public class GameStateUI : MonoBehaviour
{
    public TMP_Text stateText;

    public void ShowWin()
    {
        stateText.text = "YOU WIN";
    }

    public void ShowLose()
    {
        stateText.text = "GAME OVER";
    }
}