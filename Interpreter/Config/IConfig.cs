using Config.Net;

namespace Interpreter.Config
{
    public interface IConfig
    {
        Introducer.IConfig Introducer { get; set; }
    }
}
