using QA.Base.Handlers;

namespace QA.Test
{
    internal static class TestExtension
    {
        internal static string Join(params string[] list) => list.ToSubjectString();
    }
}
