using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    //why public? should it be accessed by other scripts?
    //strange naming convention for code stile and not consistent
    public float scroll_Speed = 0.3f;
    private MeshRenderer mesh_Renderer;
    private string MainTex = "_MainTex";
    
    //access modifiers?
    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset(MainTex);
        offset.y += Time.deltaTime * scroll_Speed;

        mesh_Renderer.sharedMaterial.SetTextureOffset(MainTex, offset);
    }
}
