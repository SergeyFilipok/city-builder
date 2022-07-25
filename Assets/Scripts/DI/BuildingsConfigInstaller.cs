using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "BuildingsConfigInstaller", menuName = "Installers/BuildingsConfigInstaller")]
public class BuildingsConfigInstaller : ScriptableObjectInstaller<BuildingsConfigInstaller> {
    [SerializeField] private BuildingsConfig _buildingsConfig = null;

    public override void InstallBindings() {
        Container.Bind<BuildingsConfig>().FromInstance(_buildingsConfig).AsSingle();
    }
}