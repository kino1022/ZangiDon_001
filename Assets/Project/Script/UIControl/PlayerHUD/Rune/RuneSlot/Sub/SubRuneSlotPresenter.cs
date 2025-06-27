using Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Sub.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;

namespace Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Sub {
    public class SubRuneSlotPresenter : ARuneListPresenter<ISubRuneSlot,ISubRuneSlotView> {
        protected override void InitializeView() {

            if (m_model == null) {
                Debug.LogError($"{m_model.GetType()}が存在しませんでした");
                return;
            }

            if (m_model.List == null) {
                Debug.LogError($"{m_model.GetType()}からListを取得できなかったため処理を中断します");
                return;
            }
            
            for (int i = 0; i < m_model.List.Count; ++i) {
                if (m_model.List[i] != null) {
                    m_view.Set(i,m_model.List[i]);
                }
                else {
                    m_view.Remove(i);
                }
            }
        }
    }
}