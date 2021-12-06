using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RockPlacer : MonoBehaviour
{
    [SerializeField] private GameObject selectedRockPrefab;

    [SerializeField] private GameObject rocksParent;

    public GameObject rockPreview;
    [SerializeField] private Vector2 worldPosition2D;

    [SerializeField]
    private float eulerRot;
    [SerializeField] private Quaternion previewRotation;
    [SerializeField] private float rotSpeed;
    [SerializeField] private GameObject pointer;

    private void Start()
    {
        rockPreview = Instantiate(selectedRockPrefab);
        rockPreview.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0.5f);
        rockPreview.GetComponent<Rigidbody2D>().isKinematic = true;
        rockPreview.GetComponent<Collider2D>().enabled = false;
        previewRotation = Quaternion.identity;
        
    }

    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition2D = new Vector2(worldPosition.x, worldPosition.y);
        
        if (Input.GetMouseButtonDown(1))
        {
            var randomRotation = Quaternion.Euler( 0 , 0 , Random.Range(0, 360));
            GameObject newRock = Instantiate(selectedRockPrefab, worldPosition2D, previewRotation, rocksParent.transform); //set as type rock?
        }
        
        eulerRot = eulerRot + Input.GetAxis("Mouse ScrollWheel") * rotSpeed * Time.deltaTime;
        previewRotation =  quaternion.Euler(0f, 0f, eulerRot);

        PreviewSelectedRock();
        pointer.transform.position = worldPosition2D;
    }

    public void PreviewSelectedRock()
    {
        rockPreview.transform.position = worldPosition2D;
        rockPreview.transform.rotation = previewRotation;
    }
}
