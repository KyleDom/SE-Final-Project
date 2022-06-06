using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenUI : MonoBehaviour
{
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI bodyText;
    
    public void SetEndScreen (bool didWin, int roundsSurvived)
    {
        if(didWin == true){
            headerText.text = $"Mission Success! Congratulations!";
            headerText.color = Color.green;
            bodyText.text = $"Mission Completed in {roundsSurvived} waves";
            bodyText.color = Color.yellow;
            
        }else {
            headerText.text = $"Mission failed! Polluta has taken over!";
            headerText.color = Color.red;
            bodyText.text = $"You survived {roundsSurvived} waves";
             bodyText.color = Color.yellow;
        }
        
    }

    public void OnPlayAgainButton ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }
}
