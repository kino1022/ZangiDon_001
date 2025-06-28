using ObservableCollections;
using Project.Script.UIControl.PlayerHUD.Rune.RuneUI;
using Project.Script.UIControl.PlayerHUD.Rune.RuneUI.Interface;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;
using VContainer;

namespace Project.Script.UIControl.PlayerHUD.Rune {
    public class ARuneListView : AListView<IRune> {

        [OdinSerialize] 
        protected ObservableDictionary<int, IRuneUI> m_items = new ObservableDictionary<int, IRuneUI>();

        public override void Set(int index, IRune item) {
            var ui = m_items[index];

            if (ui == null) {
                Debug.Log($"{index}に要素が存在しませんでした,インスペクターの設定を見直してください");
                return;
            }
            
            ui.Set(item);
        }

        public override void Remove(int index) {
            var ui = m_items[index];
            
            if (ui == null) {
                Debug.Log($"{index}に要素が存在しませんでした,インスペクターの設定を見直してください");
                return;
            }
            
            ui.Remove();
        }
    }
}