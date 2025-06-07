using System;
using System.Collections.Generic;
using Project.Script.Rune.Manage.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune.Manage.Modules {
    [Serializable]
    public class RuneListModule : IRuneListHolder{
        
        [OdinSerialize,LabelText("管理しているルーン")]　protected List<RuneInstance> m_list = new List<RuneInstance>();

        [OdinSerialize, LabelText("ルーンの最大数")] protected int m_maxList;
        
        protected RuneListModule() {}
        
        public List<RuneInstance> List => m_list;

        public RuneInstance GetRune(int index) {

            if (index < 0 || index >= m_list.Count) {
                Debug.Log("指定されたインデックスが範囲外です");
                return null;
            }
            
            return m_list[index];
        }

        public void SetRune(RuneInstance rune) {
            
            if (m_list.Count + 1 >= m_maxList) {
                Debug.Log("最大管理数を超えたルーンがセットされそうになりました");
                return;
            }
            
            m_list.Add(rune);
        }

        public void RemoveRune(RuneInstance rune) {

            if (!m_list.Find(x => x == rune).Equals(null)) {
                Debug.Log("指定されたルーンが見つかりませんでした");
                return;
            }
            
            m_list.Remove(rune);
        }

        public bool GetIsFullList() {
            return m_list.Count >= m_maxList;
        }
    }
}