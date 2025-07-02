using System.Collections.Generic;
using UnityCommonModule.Correction.Interface;

namespace Teiwas.Script.Bullet.Movement.FirstSpeed.Interface {
    /// <summary>
    /// 生成物の初速を管理するクラスに対して約束するインターフェイス
    /// </summary>
    public interface IBulletFirstSpeedHolder {
        /// <summary>
        /// 初速を取得する
        /// </summary>
        public float FirstSpeed { get; }
        
        public void ApplyCorrect (List<ICorrection> corrections);
    }
}