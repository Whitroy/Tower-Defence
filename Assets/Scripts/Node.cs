using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer _renderer;
    private Color _startColor;
    private GameObject _turret;
    private Color _hoverColor;

    public Color hoverColor;
    public Vector3 SpawnOffset;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
        _hoverColor = hoverColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(_turret!=null)
            _hoverColor = Color.red; 
    }

    private void OnMouseEnter()
    {
        _renderer.material.color = _hoverColor;
    }

    private void OnMouseDown()
    {
        if (_turret != null)
        {
            Debug.Log("Can't build");
            return;
        }

        GameObject BuildObject = BuildManager._instance.GetTurret();
       _turret= Instantiate(BuildObject, transform.position+SpawnOffset, transform.rotation);
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
