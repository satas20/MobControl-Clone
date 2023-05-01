using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject introHand;
    public GameObject tapToMove;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FirstTouch()
    {
        introHand.SetActive(false);
        tapToMove.SetActive(false);

    }
}
