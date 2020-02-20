using Reinforced.Typings.Attributes;
using Reinforced.Typings.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforced.Typings.Fluent
{
    /// <summary>
    /// Fluent const export configuration builder for class
    /// </summary>
    public class ConstExportBuilder : ClassOrInterfaceExportBuilder
    {
        internal ConstExportBuilder(TypeBlueprint blueprint) : base(blueprint)
        {
            if (Blueprint.TypeAttribute == null)
                Blueprint.TypeAttribute = new TsConstAttribute
                {
                    AutoExportFields = false,
                    AutoExportMethods = false
                };
        }

        internal TsConstAttribute Attr
        {
            get { return (TsConstAttribute)Blueprint.TypeAttribute; }
        }
    }

    /// <summary>
    /// Set of extensions for type export configuration
    /// </summary>
    public static partial class TypeConfigurationBuilderExtensions
    {
        public static ConfigurationBuilder ExportAsConst(this ConfigurationBuilder builder,
                                                         IEnumerable<Type> types,
                                                         Action<ConstExportBuilder> action = null)
        {
            foreach (var type in types)
            {
                ExportAsConst(builder, type, action);
            }
            return builder;
        }
        public static ConstExportBuilder ExportAsConst(this ConfigurationBuilder builder,
                                                         Type type,
                                                         Action<ConstExportBuilder> action = null)
        {
            var bp = builder.GetCheckedBlueprint<TsConstAttribute>(type);

            var conf =
                builder.TypeExportBuilders.GetOrCreate(type, () => new ConstExportBuilder(bp))
                    as ConstExportBuilder;
            if (conf == null)
            {
                ErrorMessages.RTE0017_FluentContradict.Throw(type, "class");
            }

            try
            {
                action?.Invoke(conf);
            }
            catch(Exception ex)
            {
                ErrorMessages.RTE0006_FluentSingleError.Throw(ex.Message, "type", type.FullName);
            }
            return conf;
        }
    }
}
