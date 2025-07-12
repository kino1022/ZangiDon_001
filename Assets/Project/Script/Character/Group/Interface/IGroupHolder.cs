using System.Collections.Generic;

namespace Teiwas.Script.Character.Group.Interface {
    public interface IGroupHolder {
        public List<IGroup> Groups { get; set; }
    }
}
