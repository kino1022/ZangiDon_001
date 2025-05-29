using System.Collections.Generic;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Camera {
    /// <summary>
    /// ターゲットの候補を管理するコンポーネント
    /// </summary>
    public class TargetCandidateManager : IManyTargetHolder<GameObject> {

        public List<GameObject> GetTargets() {
            return new List<GameObject>();
        }
    }
}