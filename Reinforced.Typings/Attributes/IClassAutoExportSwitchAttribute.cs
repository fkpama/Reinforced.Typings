namespace Reinforced.Typings.Attributes
{
    public interface IClassAutoExportSwitchAttribute : IAutoexportSwitchAttribute
    {
        bool? IsAbstract { get; }
    }
}