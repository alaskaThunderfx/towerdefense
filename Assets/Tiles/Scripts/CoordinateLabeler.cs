using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
<<<<<<< HEAD
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
=======
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField]
    Color defaultColor = Color.white;

    [SerializeField]
    Color blockedColor = Color.grey;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;
>>>>>>> waypoint

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
<<<<<<< HEAD
=======
        label.enabled = false;

        waypoint = GetComponentInParent<Waypoint>();
>>>>>>> waypoint
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
<<<<<<< HEAD
=======

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void SetLabelColor()
    {
        if (waypoint.IsPlacable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
>>>>>>> waypoint
    }

    void DisplayCoordinates()
    {
<<<<<<< HEAD
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
=======
        coordinates.x = Mathf.RoundToInt(
            transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x
        );
        coordinates.y = Mathf.RoundToInt(
            transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z
        );
>>>>>>> waypoint

        label.text = $"{coordinates.x}, {coordinates.y}";
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
