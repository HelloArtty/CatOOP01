using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;  
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonCustomEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI txt;
    private Color baseColor;
    private string hoverColor = "#632912";
    private string clickColor = "#280f06";
    void Start(){
        txt = GetComponentInChildren<TextMeshProUGUI>();
        baseColor = txt.color;
    }

    void OnDisable(){
        txt.color = baseColor;
    }

    public void OnPointerClick(PointerEventData eventData) // Not working idk why
    {
        Debug.Log("Pointer Clicked!");
        txt.color = HexToColor(clickColor);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        txt.color = HexToColor(hoverColor); 
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        txt.color = baseColor;
    }

    private Color HexToColor(string hex)
    {
        Color color;
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }
}
