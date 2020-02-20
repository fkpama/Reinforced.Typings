using System.Linq;
using Reinforced.Typings.Ast;
#pragma warning disable 1591
namespace Reinforced.Typings.Visitors.TypeScript
{
    partial class TypeScriptExportVisitor
    {
        public override void Visit(RtClass node)
        {
            if (node == null) return;
            Visit(node.Documentation);
            var prev = Context;
            Context = WriterContext.Class;
            AppendTabs();
            Decorators(node);
            if (node.Export) Write("export ");
            if (node.Abstract)
            {
                if (node.Const)
                {
                    Write("const ");
                }
                else
                {
                    Write("abstract ");
                }
            }
            else Write("class ");
            Visit(node.Name);
            if (node.Extendee != null)
            {
                Write(" extends ");
                Visit(node.Extendee);
            }
            if (node.Implementees.Count > 0)
            {
                Write(" implements ");
                SequentialVisit(node.Implementees, ", ");
            }
            if (node.Const)
            {
                Write(" = ");
            }
            else
            {
                Br(); AppendTabs();
            }
            Write("{"); Br();
            Tab();
            var members = DoSortMembers(node.Members);
            foreach (var rtMember in members)
            {
                Visit(rtMember);
            }
            UnTab();
            if (!node.Const)
            {
                AppendTabs();
                WriteLine("}");
            }
            else
            {
                WriteLine("};");
                Write($"Object.freeze(");
                Visit(node.Name);
                WriteLine(");");
            }
            Br();
            Context = prev;
        }

    }
}
