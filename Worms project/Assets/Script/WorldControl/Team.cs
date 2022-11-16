using UnityEngine;

public static class Team
{
    public static float[] PlayerTeams = new float[4] {1, 2, 3, 4};

    public static GameObject[] Player1 = new GameObject[4];
    
    public static GameObject[] Player2 = new GameObject[4];
    
    public static GameObject[] Player3 = new GameObject[4];
    
    public static GameObject[] Player4 = new GameObject[4];

    public static int Player1Alive;
    public static int Player2Alive;
    public static int Player3Alive;
    public static int Player4Alive;
}
