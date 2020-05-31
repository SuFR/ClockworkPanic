using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f,20f)] float gridSize = 10f;
    //private TextMesh textMesh;
    private void Start()
    {
       
       
    }
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        //textMesh = GetComponentInChildren<TextMesh>();
        transform.position = new Vector3(snapPos.x, snapPos.y, snapPos.z);
        //string labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        //textMesh.text = labelText;
        //gameObject.name = "Cube-" + labelText; 
    }


}
