using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    Tower towerPrefab;

    [SerializeField]
    bool isPlacable;
    public bool IsPlacable
    {
        set
        {
            isPlacable = value;
            HoverOverMaterialPicker();
        }
        get { return isPlacable; }
    }

    Renderer hoverOver;

    [SerializeField]
    Material placeable;

    [SerializeField]
    Material notPlaceable;

    void Start()
    {
        hoverOver = transform.GetChild(2).GetComponent<MeshRenderer>();
        HoverOverMaterialPicker();
        hoverOver.enabled = false;
    }

    void OnMouseOver()
    {
        hoverOver.enabled = true;
    }

    void OnMouseExit()
    {
        hoverOver.enabled = false;
    }

    void OnMouseDown()
    {
        if (IsPlacable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            IsPlacable = !isPlaced;
        }
    }

    void HoverOverMaterialPicker()
    {
        if (IsPlacable)
        {
            hoverOver.material = placeable;
        }
        else
        {
            hoverOver.material = notPlaceable;
        }
    }
}
