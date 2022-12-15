using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseKeyImage : MonoBehaviour
{
    public Sprite[] Images;
    private GameController gc;

    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update () {
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = Images[gc.HasKeys];
    }

}
