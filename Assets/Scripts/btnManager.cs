using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnManager : MonoBehaviour
{
    public Image img;
    public bool imgFlag;

    void start(){
        img.enabled = false;
        imgFlag = false;
    }
    //  New Game: Load and Initialize level 1
    public void InviteFriend(){
        Debug.Log("Inviting Friend");  
        if(imgFlag == false){
            img.enabled = true;
            imgFlag = true;
        }
        else{
            img.enabled = false;
            imgFlag = false;
        }
    }

    //  Exit application
    public void ExitGameBtn(){
        Debug.Log("Exiting application.");
        Application.Quit();
    }

}