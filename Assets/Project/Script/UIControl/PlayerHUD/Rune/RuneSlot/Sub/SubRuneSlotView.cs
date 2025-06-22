using System.Collections.Generic;
using Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Sub.Interface;
using Project.Script.UIControl.PlayerHUD.Rune.RuneUI.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Interface;

namespace Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Sub {
    public class SubRuneSlotView : SerializedMonoBehaviour, ISubRuneSlotView {
                
        [OdinSerialize, LabelText("ルーンのUI管理クラス")]
        protected List<IRuneUI> m_runes;

        public void Set(int index, IRune rune) {
            m_runes[index].Set(rune);
        }

        public void Remove(int index) {
            m_runes[index].Remove();
        }
    }
}