using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardToggle : MonoBehaviour
{
    public GameObject drawingBoard;
    public Vector3 drawingBoardPosition;
    GameObject drawingBoardInstance;
    bool boardActive;

    private void Start()
    {
        boardActive = false;
    }
    public void ToggleDrawingBoard()
    {    
        if (boardActive == true && drawingBoardInstance != null)
        {
            Destroy(drawingBoardInstance);
            boardActive = false;
        } else
        {
            drawingBoardInstance = Instantiate(drawingBoard, drawingBoardPosition, drawingBoard.transform.rotation);
            boardActive = true;
        }
        
    }
}
