using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.Common.PersistentState
{
    public sealed class WindowState
    {
        [JsonPropertyName("left")]
        public int? Left { get; set; }
        
        [JsonPropertyName("top")]
        public int? Top { get; set; }
        
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        
        [JsonPropertyName("state")]
        public FormWindowState State { get; set; }

        [JsonIgnore]
        public bool IsEmpty => Left == null || Top == null || Width == null || Height == null;

        public void Save(Form form)
        {
            State = form.WindowState;
            if (form.WindowState != FormWindowState.Normal)
                form.WindowState = FormWindowState.Normal;
            Left = form.Left;
            Top = form.Top;
            Height = form.Height;
            Width = form.Width;
        }

        public void Restore(Form form, bool sizeOnly = false)
        {
            if (IsEmpty)
                return;
            form.StartPosition = FormStartPosition.Manual;
            if (!sizeOnly)
                form.Location = new Point(Left.Value, Top.Value);
            form.Size = new Size(Width.Value, Height.Value);
            if (form.WindowState != State)
                form.WindowState = State;
        }
    }
}
