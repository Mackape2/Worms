using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMP_Dropdown dropDownSurvivors;
    public TMP_Dropdown dropDownTeams;
    public static int survivors;
    public static int teams;

    public void BeginButton()
   {
         survivors = dropDownSurvivors.value + 1;
         teams = dropDownTeams.value + 2;

         SceneManager.LoadScene("GameWorld");
   }
}
