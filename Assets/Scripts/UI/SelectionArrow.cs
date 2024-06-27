using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    private RectTransform rect;
    [SerializeField] private RectTransform[] options;
    private int currentPosition;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePosition(-1);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangePosition(1);
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            Interact();
    }
    private void ChangePosition(int position) {
        currentPosition += position;
        if (currentPosition > options.Length -1) {
            currentPosition = 0;
        }
        else if(currentPosition<0) { 
            currentPosition = options.Length-1;
        
        }

        rect.position=new Vector3 (rect.position.x, options[currentPosition].position.y, 0);
    }

    private void Interact() {

        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}
