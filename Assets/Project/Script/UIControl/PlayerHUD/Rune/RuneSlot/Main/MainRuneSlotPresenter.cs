using Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Main.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;

namespace Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Main {
    public class MainRuneSlotPresenter : ARuneListPresenter<IMainRuneSlot,IMainRuneSlotView> {
        
        protected override void InitializeView() {

            if (m_model == null) {
                Debug.LogError($"{m_model.GetType()}が存在しませんでした");
                return;
            }
            
            for (int i = 0; i < m_model.List.Count; ++i) {
                if (m_model.List[i] != null) {
                    m_view.Set(i,m_model.List[i]);
                    return;
                }
                else {
                    m_view.Remove(i);
                }
            }
        }
    }
}