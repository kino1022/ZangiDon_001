using Teiwas.Script.Spell.Slot.Interface;

namespace Teiwas.Script.Spell.Manager.Helper {
    public static class SpellManagerHelper {

        /// <summary>
        /// リスト内で最初にヒットしたからのスロットのKeyを返すメソッド
        /// </summary>
        /// <param name="manager"></param>
        /// <typeparam name="S"></typeparam>
        /// <returns></returns>
        public static int GetFirstEmpty<S>(ASpellManager<S> manager) where S : ISpellSlot, new() {

            foreach(var slots in manager.Spells) {
                if (slots.Value.IsEmpty) return slots.Key;
            }

            return -1;
        }
    }
}
