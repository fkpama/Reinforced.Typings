using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforced.Typings.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TsConstAttribute : TsDeclarationAttributeBase, IClassAutoExportSwitchAttribute
    {
        public bool AutoExportMethods { get; set; }
        public bool AutoExportFields { get; set; }
        public Type DefaultMethodCodeGenerator { get; set; }
        bool IAutoexportSwitchAttribute.AutoExportConstructors { get; }

        // user experience: remove those from intellisense
        bool IAutoexportSwitchAttribute.AutoExportProperties { get; set; }
        bool? IClassAutoExportSwitchAttribute.IsAbstract { get; }
    }
}
