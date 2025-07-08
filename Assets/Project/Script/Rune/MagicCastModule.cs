using UnityEngine;
using Teiwas.Script.Rune.Manager.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Project.Rune
{
    public class MagicCastModule : SerializedMonoBehaviour
    {
        [OdinSerialize, LabelText("メインのルーン")]
        protected IMainRuneSlot m_main;

        [OdinSerialize, LabelText("サブのルーン")]
        protected ISubRuneSlot m_sub;

        private void Start()
        {
            m_main = GetComponent<IMainRuneSlot>();

            if (m_main == null)
            {
                Debug.LogError("メインのルーンスロットがアタッチされていません");
                return;
            }

            m_sub = GetComponent<ISubRuneSlot>();

            if (m_sub == null)
            {
                Debug.LogError("サブのルーンスロットがアタッチされていません");
                return;
            }
        }

        public void OnMagicCast()
        {
            m_sub.OnPreCast(this.gameObject);
            m_main.OnCasted(this.gameObject);
            m_sub.OnPostCast(this.gameObject);
        } 
        
    }
}