using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Manager.Helper;
using Teiwas.Script.Spell.Manager.Selector.Interface;
using Teiwas.Script.Spell.Manager.Selector.Module.Interface;
using Teiwas.Script.Spell.Manager.Supplier.Interface;
using Teiwas.Script.Spell.Slot.Selector;
using Unity.Mathematics;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Spell.Manager.Selector {
    /// <summary>
    /// プレイヤーの選択できるスペルを管理するクラス
    /// </summary>
    public class SpellSelector : ASpellManager<SelectorSpellSlot>, ISpellSelector<SelectorSpellSlot> {

        [OdinSerialize, LabelText("供給クラス")]
        protected ISpellSupplier m_supplier;

        [OdinSerialize, LabelText("供給タイミング管理")]
        protected ISpellSupplyTimingManager m_timing;

        [OdinSerialize, LabelText("メインスペルの供給率"), TitleGroup("設定"), ProgressBar(0.0f, 1.0f)]
        protected ISupplyPatternManager m_pattern;

        protected void Start() {

            m_supplier = m_resolver.Resolve<ISpellSupplier>()
                        ?? throw new ArgumentNullException();

            m_timing = m_resolver.Resolve<ISpellSupplyTimingManager>()
                    ?? throw new ArgumentNullException();

            //供給タイミングの購読処理
            RegisterSupplyTiming();

        }

        protected void OnDestroy() {
            //供給タイミングの購読解除処理
            DisRegisterSupplyTiming();
        }

        public bool Select(int index) {

            if(index < 0 || index > Length) {
                throw new ArgumentOutOfRangeException();
            }

            //選択されたスロットの取得
            var targetSlot = m_spells[index];

            //選択されたスロットが存在しなかった場合
            if(targetSlot is null) {
                throw new NullReferenceException();
            }

            //選択されたスロットが空であった場合の分岐処理
            if(targetSlot.IsEmpty is true) {
                Debug.Log($"{GetType().Name}で選択されたスロットが既に空でした");
                return false;
            }


            /// 選択されたスペルを他クラスに対して送信する処理は、別クラスに任せる方が良さそう
            /// そのためにその別クラスへの送信処理をここに差し込む

            throw new NotImplementedException();
        }

        /// <summary>
        /// 補充タイミング通知処理の購読処理
        /// </summary>
        protected void RegisterSupplyTiming() {
            if(m_timing is null) throw new NullReferenceException();
            m_timing.OnSupply += OnSupplyTiming;
        }

        /// <summary>
        /// 補充タイミング通知処理の購読解除処理
        /// </summary>
        protected void DisRegisterSupplyTiming() {
            if(m_timing is null) throw new NullReferenceException();
            m_timing.OnSupply -= OnSupplyTiming;
        }

        protected void OnSupplyTiming() {

            //既にスペルが満タンである際の例外処理
            if(m_isFull.IsFull is true) {
                Debug.Log($"{nameof(m_timing)}から補充タイミングの指示がありましたが、既にスペルがいっぱいでした。補充処理を終了します");
                //本当に満タンかどうか精査するメソッドを挿入した方がいいかもしれない
                return;
            }

            var success = SupplySpell();

            //補充に失敗した際の分岐処理
            if(success is false) {
                Debug.LogWarning($"{GetType().Name}のスペル補充処理においてなんらかの原因で補充に失敗しました");
            }

        }

        ///　実際にスペルの補充を行う処理
        protected virtual bool SupplySpell() {

            var index = SpellManagerHelper.GetFirstEmpty<SelectorSpellSlot>(this);

            //空きスロットが存在しなかった場合の分岐処理
            if(index is -1) {
                return false;
            }

            var target = Spells[index];

            //取得したスロットが存在しなかった場合の分岐処理
            if(target is null) {
                throw new NullReferenceException();
            }

            //取得したスロットが既に埋まっていた場合の分岐処理
            if(target.IsEmpty is false) {
                return false;
            }

            //代入するインスタンス
            var instance = m_supplier.SupplyBath();

            //取得したインスタンスがどちらもnullだった場合
            if(instance.Item1 is null && instance.Item2 is null) {
                return false;
            }

            if(instance.Item1 is null) {
                return target.SetInstance(instance.Item2);
            }

            if(instance.Item2 is null) {
                return target.SetInstance(instance.Item1);
            }

            //インスタンスの代入処理が成功したかどうか
            var success = target.SetInstance(m_pattern.DecideSupply(instance));

            return success;
        }

    }
}
