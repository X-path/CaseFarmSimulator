using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> placedGameObjects =new List<GameObject>();
    [SerializeField]
    PlacementSystem placementSystem;
    [SerializeField] GameObject removeParticle;
   
    public int PlaceObject(GameObject prefab, Vector3 position)
    {
        GameObject newObject = Instantiate(prefab);
        newObject.transform.position = position;
        placedGameObjects.Add(newObject);
        placementSystem.StopPlacement();
        if(newObject.GetComponent<CropController>()!=null)
        {
            StartCoroutine(newObject.GetComponent<CropController>().GrowCrops());
        }
        return placedGameObjects.Count - 1;
        
    }
  
    public void MoveObject(int gameObjectIndex, Vector3 newPosition)
    {
        if (gameObjectIndex >= 0 && gameObjectIndex < placedGameObjects.Count && placedGameObjects[gameObjectIndex] != null)
        {
            placedGameObjects[gameObjectIndex].transform.position = newPosition;
        }
    }
    public GameObject GetPlacedObject(int index)
    {
        if (index < 0 || index >= placedGameObjects.Count)
            return null;

        return placedGameObjects[index];
    }

    public void RemoveObjectAt(int gameObjectIndex)
    {
        if (placedGameObjects.Count <= gameObjectIndex 
            || placedGameObjects[gameObjectIndex] == null)
            return;

        Instantiate(removeParticle,new Vector3(placedGameObjects[gameObjectIndex].transform.position.x, removeParticle.transform.position.y, placedGameObjects[gameObjectIndex].transform.position.z),removeParticle.transform.rotation);
       
        Destroy(placedGameObjects[gameObjectIndex]);
        placedGameObjects[gameObjectIndex] = null;
        
        
    }
}
