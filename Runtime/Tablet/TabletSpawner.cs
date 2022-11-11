using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject TabletPrefab;
    [SerializeField] private Transform TabletPose;

    public void SpawnTablet()
    {
        var tablet = Instantiate(TabletPrefab);
        tablet.gameObject.name = "Tablet (" + Time.time.GetHashCode() + ")";
        tablet.transform.position = TabletPose.position;
        tablet.transform.rotation = TabletPose.rotation;
    }
}
