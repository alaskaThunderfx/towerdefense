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
            // HoverOverMaterialPicker();
        }
        get { return isPlacable; }
    }

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    Renderer hoverOver;

    [SerializeField]
    Material placeableMaterial;

    [SerializeField]
    Material notPlaceableMaterial;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
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
        HoverOverMaterialPicker();
        hoverOver.enabled = true;
    }

    void OnMouseExit()
    {
        hoverOver.enabled = false;
    }

    void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);
            // Need to come up with something else for the OoverOverMaterialPicker
            IsPlacable = !isSuccessful;
            if (isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
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
