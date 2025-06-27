using System;
using System.Linq;
using ObservableCollections;
using Project.Script.UIControl.PlayerHUD.Rune;
using R3;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using Teiwas.Script.UIControl.PlayerHUD.RuneSelector.Interface;
using Teiwas.Script.UIControl.Utility;
using UnityEngine;

namespace Teiwas.Script.UIControl.PlayerHUD.RuneSelector {
    /// <summary>
    /// IRuneSelectorとIRuneSelectorViewの仲介をするクラス
    /// </summary>
    [Serializable]
    public class RuneSelectorPresenter : ARuneListPresenter<IRuneSelector,IRuneSelectorView> {
        
        
        protected override void InitializeView() {

            if (m_model == null) {
                Debug.Log("UIに反映させる対象が見つかりません処理を中断します");
                return;
            }

            if (m_model.List.Count == 0) {
                return;
            }

            for (int i = 0; i < m_model.List.Count; i++) {
                if (m_model.List.ContainsKey(i) == false) {
                    m_view.Remove(i);
                }
                else {
                    m_view.Set(i, m_model.List[i]);
                }
            }
            
        }
    }
}