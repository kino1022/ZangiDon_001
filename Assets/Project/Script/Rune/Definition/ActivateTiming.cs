namespace Project.Script.Rune.Effect.Definition {
    /// <summary>
    /// ルーンの効果がどのタイミングで発動するかを記述した列挙型
    /// </summary>
    public enum ActivateTiming {
        /// <summary>
        /// ルーンを選択したタイミングで発動
        /// </summary>
        OnSelect,
        /// <summary>
        /// ルーンを選択した状態で魔術を発動した際に発動
        /// </summary>
        OnCast,
        /// <summary>
        /// 使用した魔術が敵にヒットした際に発動(攻撃系魔術限定)
        /// </summary>
        OnHit,
    }
}