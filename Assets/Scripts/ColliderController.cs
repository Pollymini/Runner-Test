using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ColliderController : MonoBehaviour
{
           //collider.material = physicMaterial;

    private void Start()
    {
        MeshCollider collider = gameObject.AddComponent<MeshCollider>();

        collider.cookingOptions = MeshColliderCookingOptions.CookForFasterSimulation | MeshColliderCookingOptions.EnableMeshCleaning | MeshColliderCookingOptions.WeldColocatedVertices | MeshColliderCookingOptions.UseFastMidphase;
        collider.convex = false;
        
        collider.enabled = true;
    }
   
}
