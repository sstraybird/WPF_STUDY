namespace WpfInterfaceDemo
{
    // 电灯泡实现了 ISwitchable 接口
    public class Bulb : ISwitchable
    {
        public string DeviceName => "卧室台灯";

        // 实现接口定义的事件
        public event Action<string>? StatusUpdated;
        
        // 实现接口定义的 EventHandler
        public event EventHandler? StateChanged;

        public string TurnOn()
        {
            var msg = "💡 灯亮了！房间变得明亮。";
            // 触发事件，通知外部
            StatusUpdated?.Invoke($"[{DeviceName}] {msg}");
            StateChanged?.Invoke(this, EventArgs.Empty);
            return msg;
        }

        public string TurnOff()
        {
            var msg = "🌑 灯灭了。晚安。";
            StatusUpdated?.Invoke($"[{DeviceName}] {msg}");
            StateChanged?.Invoke(this, EventArgs.Empty);
            return msg;
        }
    }
}
