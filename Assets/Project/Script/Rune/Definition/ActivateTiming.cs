namespace Teiwas.Script.Rune.Definition {
    public enum ActivateTiming {
        /// <summary>
        /// ルーン選択時に発動
        /// </summary>
        OnSelect,
        /// <summary>
        /// 術の発動前に発動
        /// </summary>
        OnPreCast,
        /// <summary>
        /// 術の発動後に発動
        /// </summary>
        OnPostCast,
        /// <summary>
        /// 生成した弾にヒットした際に発動
        /// </summary>
        OnHit,
    }
}