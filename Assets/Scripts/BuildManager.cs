using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager _instance;

    public GameObject StandardTurret;

    private GameObject _TurretToBuild;
    private void Awake()
    {
        if(_instance!=null)
        {
            Debug.Log("BuildManager already exist");
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        _TurretToBuild = StandardTurret;
    }

    public GameObject GetTurret()
    {
        return _TurretToBuild;
    }
}
