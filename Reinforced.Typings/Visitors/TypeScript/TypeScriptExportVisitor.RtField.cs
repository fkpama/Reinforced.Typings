using Reinforced.Typings.Ast;
#pragma warning disable 1591
namespace Reinforced.Typings.Visitors.TypeScript
{
    partial class TypeScriptExportVisitor
    {
        public override void Visit(RtField node)
        {
            if (node == null) return;
            Visit(node.Documentation);
            AppendTabs();
            if (Context != WriterContext.Interface)
            {
                Decorators(node);
                if (!node.ConstMember)
                {
                    Modifiers(node);
                }
            }
            Visit(node.Identifier);
            if (!node.ConstMember)
            {
                Write(": ");
                Visit(node.Type);
            }
            if (!string.IsNullOrEmpty(node.InitializationExpression))
            {
                if (!node.ConstMember)
                {
                    Write(" = ");
                }
                else
                {
                    Write(": ");
                }
                Write(node.InitializationExpression);
            }

            WriteIf(!node.ConstMember, ";");
            WriteIf(node.ConstMember && !node.IsLast, ",");

            Br();
            if (!string.IsNullOrEmpty(node.LineAfter))
            {
                AppendTabs();
                Write(node.LineAfter);
                Br();
            }
        }
    }
}
