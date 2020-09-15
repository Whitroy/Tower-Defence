using UnityEngine;

public class shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBluePrint standardTurret;
    public TurretBluePrint MissileLauncher;
    public TurretBluePrint LaserBeamer;
    private void Start()
    {
        buildManager = BuildManager._instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLaucher()
    {
        buildManager.SelectTurretToBuild(MissileLauncher);
    }
    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(LaserBeamer);
    }
}
