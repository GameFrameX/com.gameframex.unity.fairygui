using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FairyGUI;
using GameFrameX.Asset.Runtime;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.FairyGUI.Runtime
{
    /// <summary>
    /// 管理所有UI 包
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/FairyGUIPackage")]
    public sealed class FairyGUIPackageComponent : GameFrameworkComponent
    {
        private readonly Dictionary<string, UIPackage> _uiPackages = new Dictionary<string, UIPackage>(32);

        public UniTask<UIPackage> AddPackageAsync(string descFilePath)
        {
            if (!_uiPackages.TryGetValue(descFilePath, out var package))
            {
                var tcs = new UniTaskCompletionSource<UIPackage>();
                UIPackage.AddPackageAsync(descFilePath, (uiPackage) =>
                {
                    package = uiPackage;
                    package.LoadAllAssets();
                    _uiPackages.Add(descFilePath, package);
                    tcs.TrySetResult(package);
                });
                return tcs.Task;
            }

            return UniTask.FromResult(package);
        }

        public void AddPackage(string descFilePath)
        {
            if (!_uiPackages.TryGetValue(descFilePath, out var package))
            {
                package = UIPackage.AddPackage(descFilePath);
                package.LoadAllAssets();
                _uiPackages.Add(descFilePath, package);
            }
        }

        public void RemovePackage(string descFilePath)
        {
            if (_uiPackages.TryGetValue(descFilePath, out var package))
            {
                UIPackage.RemovePackage(descFilePath);
                _uiPackages.Remove(descFilePath);
            }
        }

        public void RemoveAllPackages()
        {
            UIPackage.RemoveAllPackages();
            _uiPackages.Clear();
        }


        public bool Has(string uiPackageName)
        {
            return Get(uiPackageName) != null;
        }

        public UIPackage Get(string uiPackageName)
        {
            if (_uiPackages.TryGetValue(uiPackageName, out var package))
            {
                return package;
            }

            return null;
        }

        protected override void Awake()
        {
            IsAutoRegister = false;
            base.Awake();
            UIPackage.SetAsyncLoadResource(new FairyGUILoadAsyncResourceHelper());
        }

        private AssetComponent _assetComponent;

        private void Start()
        {
            _assetComponent = GameEntry.GetComponent<AssetComponent>();
            if (_assetComponent == null)
            {
                Log.Fatal("Asset component is invalid.");
                return;
            }
        }
    }
}