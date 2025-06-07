using System;
using Project.Script.Interface;
using Project.Script.Rune.Manage.Modules;
using Project.Script.Rune.Manage.RuneSelector.Module;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Rune.Manage.RuneSelector {
    [Serializable]
    public class RuneSelector : ARuneManager {

        [OdinSerialize, SerializeField, LabelText("送信対象セレクター")] protected SendTargetSelector m_selector;
        public ITargetHolder<IReceiver<RuneInstance>> Selector => m_selector;

        [OdinSerialize, SerializeField, LabelText("一文字目を管理するクラス")]
        protected ARuneManager m_mainSlot;
        
        [OdinSerialize,SerializeField,LabelText("二文字目以降を管理するクラス")] 
        protected ARuneManager m_supportSlot;

        public RuneSelector (ARuneManager main,ARuneManager support) {
            m_selector = new SendTargetSelector(main, support);
        }

        #region API

        /// <summary>
        /// ＵＩからindexのみを指定された際を想定したルーン送信メソッド
        /// </summary>
        /// <param name="index">何番目のルーンを送信するか</param>
        public void SendRuneFromIndex (int index) {
            var rune = List.GetRune(index);

            if (rune == null) {
                Debug.Log("送信対象となるルーンのインスタンスが存在しませんでした");
                return;
            }

            var target = Selector.GetTarget();

            if (target == null) {
                Debug.Log("ルーンを送信する対象のIReceiverが見つかりませんでした");
                return;
            }

            List.RemoveRune(rune);
            target.Receive(rune);
        }


        #endregion
    }
}