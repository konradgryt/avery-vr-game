using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateHud : MonoBehaviour
{

    static UpdateHud _instance;

    public static UpdateHud GetInstance()
    {
        if (_instance == null)
            _instance = FindObjectOfType(typeof(UpdateHud)) as UpdateHud;

        return _instance;
    }

    public GameObject go;
    static Text info;
    const string _PREFIXSCORE = "Score: ";
    const string _PREFIXLIVES = "Lives: ";

    static int score;

    private void Start()
    {
        score = 0;
        info = go.GetComponent<Text>();
    }


    private void Update()
    {
        bool isPressed = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        UpdateHud.GetInstance().Show(isPressed);
    }

    public void UpdateScore(int amount)
    {
        score += amount;
    }

    public void Show(bool toShow)
    {
        if (toShow)
        {
            info.text = _PREFIXSCORE + score.ToString() + "\n";
            info.text += _PREFIXLIVES + Player.GetInstance().Lives().ToString();
        }
        else
            info.text = "";
    }

}
