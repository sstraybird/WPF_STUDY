using System.Windows;
using System.Windows.Media;

namespace WpfInterfaceDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 核心点：我定义变量时，不需要知道具体是 Bulb 还是 Fan，我只需要它是“ISwitchable”
        // 这就是接口的威力：多态 (Polymorphism)
        private ISwitchable? _connectedDevice;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UseBulbBtn_Click(object sender, RoutedEventArgs e)
        {
            ConnectDevice(new Bulb());
        }

        private void UseFanBtn_Click(object sender, RoutedEventArgs e)
        {
            ConnectDevice(new Fan());
        }

        private void ConnectDevice(ISwitchable newDevice)
        {
            // 1. 先解除旧设备的事件绑定 (防止内存泄漏和重复调用)
            if (_connectedDevice != null)
            {
                _connectedDevice.StatusUpdated -= OnDeviceStatusUpdated;
                _connectedDevice.StateChanged -= OnDeviceStateChanged;
            }

            _connectedDevice = newDevice;

            // 2. 绑定新设备的事件
            // 每当设备内部发生状态变化，都会自动调用 OnDeviceStatusUpdated
            _connectedDevice.StatusUpdated += OnDeviceStatusUpdated;
            _connectedDevice.StateChanged += OnDeviceStateChanged;

            UpdateDeviceStatus();
        }

        // 这是一个回调函数 (Event Handler)
        private void OnDeviceStatusUpdated(string message)
        {
            // 更新 UI
            StatusText.Text = $"[来自事件通知] {message}";
        }

        // 标准 EventHandler 回调
        private void OnDeviceStateChanged(object? sender, EventArgs e)
        {
            if (sender is ISwitchable device)
            {
                // 这里我们可以做一些独立于 StatusUpdated 的逻辑
                // 比如我们可以追加文本，或者记录日志
                // 为了演示，我们只是简单地追加一行日志
                 StatusText.Text += $"\n[StateChanged] {device.DeviceName} 状态改变了 (Standard .NET Event)";
            }
        }

        private void OnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_connectedDevice == null)
            {
                StatusText.Text = "⚠️ 请先连接设备！";
                return;
            }
            // 我们不再直接使用返回值来设置 Text，而是依赖事件
            // 调用方法 -> 设备做事 -> 触发事件 -> UI更新
            _connectedDevice.TurnOn();
        }

        private void OffBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_connectedDevice == null)
            {
                StatusText.Text = "⚠️ 请先连接设备！";
                return;
            }
            _connectedDevice.TurnOff();
        }

        private void UpdateDeviceStatus()
        {
            if (_connectedDevice != null)
            {
                CurrentDeviceText.Text = _connectedDevice.DeviceName;
                CurrentDeviceText.Foreground = Brushes.Black;
                StatusText.Text = "设备已就绪。";
            }
        }
    }
}