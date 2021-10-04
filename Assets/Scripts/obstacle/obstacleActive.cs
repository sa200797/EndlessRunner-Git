using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleActive : MonoBehaviour
{
    [SerializeField] public List<GameObject> Childs;
    [SerializeField] public SphereCollider SphereCollider;
    [SerializeField] public CapsuleCollider CapsuleCollider;
    [SerializeField] public BoxCollider BoxCollider;
    private void Awake()
    {
        GetAllChlidObject();
    }
    void Start()
    {
    }
    void GetAllChlidObject()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Childs.Add(transform.GetChild(i).gameObject);
        }
        if (SphereCollider == null)
        {
            var isSphereCollider = gameObject.HasComponent<SphereCollider>();
            if (isSphereCollider == true) { SphereCollider = GetComponent<SphereCollider>(); }
        }
        if (CapsuleCollider == null)
        {
            var CapsuleColliders = gameObject.HasComponent<CapsuleCollider>();
            if (CapsuleColliders == true) { CapsuleCollider = GetComponent<CapsuleCollider>(); }
        }
        if (BoxCollider == null)
        {
            var BoxColliders = gameObject.HasComponent<BoxCollider>();
            if (BoxColliders == true) { BoxCollider = GetComponent<BoxCollider>(); }
        }
    }
    public void SetobstacleActiveAndDeactive(bool isActive)
    {
        for (int i = 0; i < Childs.Count; i++)
        {
            Childs[i].gameObject.SetActive(isActive);
        }
        if (SphereCollider != null) { SphereCollider.enabled = isActive; }
        if (CapsuleCollider != null) { CapsuleCollider.enabled = isActive; }
        if (BoxCollider != null) { BoxCollider.enabled = isActive; }
    }
}
