using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private Renderer _renderer;
    private Color _startColor;
    [Header("Optional")]
    public GameObject _turret;
    private Color _hoverColor;

    public Color hoverColor;
    public Color nothavingMoreMoneyColor;
    public Vector3 SpawnOffset;
    public BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
        _hoverColor = hoverColor;
        buildManager = BuildManager._instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(_turret!=null)
            _hoverColor = Color.red; 
    }

    private void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.HasMoney)
            _renderer.material.color = _hoverColor;
        else
            _renderer.material.color = nothavingMoreMoneyColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + SpawnOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (_turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
