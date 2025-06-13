using Project.Script.StatusEffect.Definition;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.UI;

namespace Project.Script.StatusEffect.Data {
    public class StatusEffectData : SerializedScriptableObject {
        
        [OdinSerialize, LabelText("アイコン")] public Image icon;
        
        [OdinSerialize, LabelText("表示名")] public string displayName;
        
        [OdinSerialize, LabelText("分類")] public EffectType effectType;
        
        
    }
}