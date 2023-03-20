using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject TabletPrefab;
    [SerializeField] private Transform TabletPose;

    private Tablet tabletInstance;

    public void SpawnTablet()
    {
        if (tabletInstance == null)
        {
            tabletInstance = Instantiate(TabletPrefab).GetComponent<Tablet>();
            tabletInstance.gameObject.name = "Tablet (" + Time.time.GetHashCode() + ")";
        }
        else tabletInstance.gameObject.SetActive(true);

        tabletInstance.transform.position = TabletPose.position;
        tabletInstance.transform.rotation = TabletPose.rotation;
    }
}
