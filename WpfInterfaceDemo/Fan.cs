namespace WpfInterfaceDemo
{
    // 风扇也实现了 ISwitchable 接口
    // 虽然它开/关的具体表现和灯完全不一样，但“用法”是一样的。
    public class Fan : ISwitchable
    {
        public string DeviceName => "强力电扇";

        public event Action<string>? StatusUpdated;
        
        public event EventHandler? StateChanged;

        public string TurnOn()
        {
            var msg = "🌪️ 呼呼呼！风扇开始旋转，好凉快。";
            StatusUpdated?.Invoke($"[{DeviceName}] {msg}");
            StateChanged?.Invoke(this, EventArgs.Empty);
            return msg;
        }

        public string TurnOff()
        {
            var msg = "🛑 风扇慢慢停下来了。";
            StatusUpdated?.Invoke($"[{DeviceName}] {msg}");
            StateChanged?.Invoke(this, EventArgs.Empty);
            return msg;
        }
    }
}
