using Reinforced.Typings.Ast;
using Reinforced.Typings.Attributes;
using Reinforced.Typings.Xmldoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforced.Typings.Generators
{
    public class ConstCodeGenerator : ClassCodeGenerator
    {
        public override RtClass GenerateNode(Type element, RtClass result, TypeResolver resolver)
        {
            result.Const = true;
            result = base.GenerateNode(element, result, resolver);
            return result;
        }

        protected override void ExportMembers(Type element, TypeResolver resolver, ITypeMember typeMember, IAutoexportSwitchAttribute swtch)
        {
            ExportFields(typeMember, element, resolver, swtch);
            ExportMethods(typeMember, element, resolver, swtch);
        }
    }
}
