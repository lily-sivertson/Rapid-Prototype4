using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int shots_left = 6;
    int shots_taken = 0;

    public bool ball_moving=false;
    [SerializeField] TextMeshProUGUI shot_text;
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI game_state_text;
    [SerializeField] TextMeshProUGUI shots_taken_text;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
    
            Destroy(gameObject);
        }
        else
        {
            Instance = this;

        }
    }

   
    void Start()
    {
        panel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shots_left==0 && !ball_moving)
        {
            GameOver("lose");
        }
    }



    public void GameOver(string s)
    {
        panel.SetActive(true);
        if (s== "win")
        {
            game_state_text.text = "You win!!";
            shots_taken_text.text = "shots taken: " + shots_taken;
        }
        else if (s== "lose")
        {
            game_state_text.text = "You lost!";
            shots_taken_text.text = "better luck next time";
        }
    }


    public void ChangeShots()
    {
        shots_left--;
        shot_text.text = "shots left: " + shots_left;
        shots_taken++;
    }

}
