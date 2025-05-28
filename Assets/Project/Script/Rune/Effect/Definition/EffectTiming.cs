namespace Project.Script.Rune.Effect.Definition {
    /// <summary>
    /// ルーンの追加効果が発生するタイミングを示したEnum
    /// </summary>
    public enum EffectTiming {
        /// <summary>
        /// ルーン選択時に効果が発動する
        /// </summary>
        OnSet,
        /// <summary>
        /// 魔術発動時に効果が発生する
        /// </summary>
        OnCast,
        /// <summary>
        /// 魔術攻撃ヒット時に効果が発生する
        /// </summary>
        OnHit,
    }
}