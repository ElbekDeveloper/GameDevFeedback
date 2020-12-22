using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour {
  
  private float scroll_Speed = 0.3f;
  private MeshRenderer _meshRenderer;
  private string _mainTex = "_MainTex";

  
  void Awake() { _meshRenderer = GetComponent<MeshRenderer>(); }

  // Update is called once per frame
  void Update() { Scroll(); }

  private void Scroll() {
    Vector2 offset = _meshRenderer.sharedMaterial.GetTextureOffset(_mainTex);
    offset.y += Time.deltaTime * scroll_Speed;

        _meshRenderer.sharedMaterial.SetTextureOffset(_mainTex, offset);
  }
}
