using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
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

    GridManager gridManager;

    Vector2Int coordinates = new Vector2Int();

    Renderer hoverOver;

    [SerializeField]
    Material placeableMaterial;

    [SerializeField]
    Material notPlaceableMaterial;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    void Start()
    {
        if (gridManager != null) 
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlacable)
            {
                gridManager.BlockNode(coordinates);
            }
        }

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
            hoverOver.material = placeableMaterial;
        }
        else
        {
            hoverOver.material = notPlaceableMaterial;
        }
    }
}
