using System;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager _instance;
    private TurretBluePrint _TurretToBuild;
    private Node SelectedNode;
    public NodeUI nodeUI;
    public GameObject buildEffect;
    private void Awake()
    {
        if(_instance!=null)
        {
            Debug.Log("BuildManager already exist");
            return;
        }

        _instance = this;
    }
    public bool CanBuild
    {
        get
        {
            return _TurretToBuild != null;
        }
    }
    public bool HasMoney
    {
        get
        {
            return playerStats.Money>=_TurretToBuild.cost;
        }
    }

    public void SelectTurretToBuild(TurretBluePrint Turret)
    {
        _TurretToBuild = Turret;
        DeSelectNode();
    }

    public void SelectNode(Node node)
    {
        if(SelectedNode == node)
        {
            DeSelectNode();
            return;
        }

        SelectedNode = node;
        _TurretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeSelectNode()
    {
        SelectedNode = null;
        nodeUI.Hide();
    }

    public void BuildTurretOn(Node node)
    {
        if(playerStats.Money<_TurretToBuild.cost)
        {
            Debug.Log("Not Enough Money to build");
            return;
        }
        playerStats.Money -= _TurretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(_TurretToBuild.prefab, node.GetBuildPosition(),Quaternion.identity);
        node._turret = turret;

        Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);

        Debug.Log("Money Left:- " + playerStats.Money);
    }
}
