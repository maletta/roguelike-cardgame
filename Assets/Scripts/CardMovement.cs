using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalLocalPointerPosition; // mouse pointer
    private Vector3 originalPanelLocalPosition; // card original location
    private Vector3 originalScale; // 
    private int currentState = 0; // 0 initial ; 1 hover; 2 dragged;   
    private Quaternion originalRotation;
    private Vector3 originalPosition;

    // private doesnt appear on inspector, but with SerializedField its shown
    [SerializeField] private float selectScale = 1.1f; // to add an effect to our card ?
    [SerializeField] private Vector2 cardPlay;
    [SerializeField] private Vector3 playPosition; // where our card going to jump to
    [SerializeField] private GameObject glowEffect;
    [SerializeField] private GameObject playArrow;



    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponent<Canvas>();
        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.localPosition;
        originalRotation = rectTransform.localRotation;
    }

    void Update()
    {
        switch (currentState)
        {
            case 1:
                HandleHoverState();
                break;
            case 2:
                HandleDrageState();
                if (!Input.GetMouseButton(0)) // check if mouse button is released
                {
                    TransitionToState0();
                }
            case 3:
                HandlePlayState();
                if (!Input.GetMouseButton(0)) // check if mouse button is released
                {
                    TransitionToState0();
                }
            default:
                break;
        }
    }

    private void TransitionToState0()
    {
        currentState = 0;
        rectTransform.localScale = originalScale; // reset scake
        rectTransform.localRotation = originalRotation; // reset rotation
        rectTransform.localPosition = originalPosition; // reset position
        glowEffect.SetActive(false); // disable glow effect
        playArrow.SetActive(false); // disable play arrow
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentState == 0)
        {
            originalPosition = rectTransform.localPosition;
            originalRotation = rectTransform.localRotation;
            originalScale = rectTransform.localScale;

            currentState = 1;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentState == 1)
        {
            TransitionToState0();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentState == 1)
        {
            currentState = 2;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out originalLocalPointerPosition);
        }
    }

    private void HandleHoverState()
    {
        glowEffect.SetActive(true);
        rectTransform.localScale = originalScale * selectScale;
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }






}
