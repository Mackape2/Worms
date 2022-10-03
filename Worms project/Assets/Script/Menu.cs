using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{ 
    //GameObject prep = GameObject.Find("prepScreen");  
    
    public TMP_Dropdown dropDownSurvivors;
    public TMP_Dropdown dropDownTeams;
    public static int survivors;
    public static int teams;

    public void BeginButton()
   {
         survivors = dropDownSurvivors.value + 1;
         teams = dropDownTeams.value + 1;

         SceneManager.LoadScene("SampleScene");
   }
}