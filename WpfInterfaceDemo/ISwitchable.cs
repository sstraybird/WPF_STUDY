namespace WpfInterfaceDemo
{
    // 接口 (Interface) 就像是一个“契约”或“标准”。
    // 它规定了：任何“实现了”这个接口的东西，都必须具备某些能力。
    // 这里我们定义了一个“可开关设备”的标准。
    public interface ISwitchable
    {
        // 接口里只写“长什么样”，不写“怎么做”
        string DeviceName { get; }
        string TurnOn();
        string TurnOff();

        // 3. 接口也可以定义事件！
        // 这表示：任何实现我的类，都必须能向外发送“StatusUpdated”这个通知。
        event Action<string> StatusUpdated;

        // 4. 标准 .NET 事件模式
        // 使用 EventHandler，符合 .NET 规范的事件定义
        event EventHandler StateChanged;
    }
}
