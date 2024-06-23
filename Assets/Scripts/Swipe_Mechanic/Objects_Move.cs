using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Objects_Move : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Image image;
    public Fight_Manager fightManager { get; private set; }
    public Rocket_Type rocketType { get; private set; }

    Camera MainCamera;

    Vector3 offset;

    public Vector3 initialPos;
    public Vector3 ShowNewPos;

    public int moveDirection;

    public float Xdiff;
    public float Ydiff;

    //GameObject TempRocket;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        MainCamera = Camera.allCameras[0];
        rocketType = GetComponent<Rocket_Type>();
        fightManager = FindObjectOfType<Fight_Manager>();

        rectTransform.anchoredPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!fightManager.playerMoved && !rocketType.TypeIsDicorded)
        {
            image.raycastTarget = false;
            initialPos = transform.position;
            offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!fightManager.playerMoved && !rocketType.TypeIsDicorded)
        {
            rectTransform.anchoredPosition += eventData.delta;
            Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
            newPos.z = 0;
            transform.position = newPos + offset;

            ShowNewPos = newPos;

            if (transform.position != initialPos)
            {
                float Xdiff = newPos.x;
                float Ydiff = newPos.y;

                float XdiffCheck = Xdiff;
                if (XdiffCheck < 0)
                    XdiffCheck *= -1;

                float YdiffCheck = Ydiff;
                if (YdiffCheck < 0)
                    YdiffCheck *= -1;

                if (XdiffCheck > YdiffCheck)
                {
                    if (Xdiff > 0)
                        moveDirection = 4; // Right
                    else
                        moveDirection = 3; // Left
                    Debug.Log("Horizontal - X: " + XdiffCheck + "/ Y: " + YdiffCheck);
                    Debug.Log("MoveDirection(hor): " + moveDirection);
                }
                else
                {
                    if (Ydiff > 0)
                        moveDirection = 1; // Up
                    else
                        moveDirection = 2; // Bottom
                    Debug.Log("Vertical - X: " + XdiffCheck + "/ Y: " + YdiffCheck);
                    Debug.Log("MoveDirection(ver): " + moveDirection);
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (!fightManager.playerMoved && !rocketType.TypeIsDicorded)
        {
            transform.position = initialPos;
            rocketType.ExchangeTypes(moveDirection);

            fightManager.playerMoved = true;
            image.raycastTarget = true;
        }
        
    }

}
