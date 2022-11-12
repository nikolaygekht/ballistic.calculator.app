using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculator.Reticle.Data;
using BallisticCalculator.Reticle.Draw;
using BallisticCalculator.Reticle.Graphics;
using BallisticCalculatorNet.ReticleCanvas;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.ReticleEditor.Forms
{
    public partial class EditPathForm : Form
    {
        internal ReticlePath Path { get; }

        private ReticlePath Copy { get; set; }

        private ReticleDefinition Reticle { get; }

        public EditPathForm(ReticlePath path, ReticleDefinition reticle)
        {
            Path = path;
            Copy = path.Clone() as ReticlePath;
            Reticle = reticle;
            InitializeComponent();
            Setup();
        }

        internal void Setup()
        {
            measurementWidth.Value = Path.LineWidth;

            comboBoxColor.FillByColors();
            comboBoxColor.Text = Path.Color;

            checkBoxFill.Checked = Path.Fill ?? false;

            listBoxElements.Items.Clear();
            for (int i = 0; i < Path.Elements.Count; i++)
                listBoxElements.Items.Add(Path.Elements[i]);

            UpdateImage();
        }

        internal void Save()
        {
            Path.LineWidth = measurementWidth.ValueAsMeasurement<AngularUnit>();
            Path.Color = comboBoxColor.Text;
            Path.Fill = checkBoxFill.Checked;
        }

        internal void Revert()
        {
            Path.Color = Copy.Color;
            Path.LineWidth = Copy.LineWidth;
            Path.Fill = Copy.Fill;

            Path.Elements.Clear();
            for (int i = 0; i < Copy.Elements.Count; i++)
                Path.Elements.Add(Copy.Elements[i].Clone());

            Setup();
        }

        internal void UpdateImage()
        {
            if (Reticle.Size == null)
            {
                picturePreview.Image = null;
                return;
            }

            ReticleCanvasUtils.CalculateReticleImageSize(picturePreview.Size.Width, picturePreview.Size.Height,
                                      Reticle.Size.X, Reticle.Size.Y, out int imageX, out int imageY);

            Bitmap bm = new Bitmap(imageX, imageY);
            GraphicsCanvas canvas = GraphicsCanvas.FromImage(bm, Color.White);
            ReticleDrawController controller = new ReticleDrawController(Reticle, canvas);
            canvas.Clear();
            controller.DrawElement(Path);
            picturePreview.Image = bm;
        }

        internal void buttonOK_Click(object sender, EventArgs e)
        {
            Save();
            Copy = null;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Revert();
            Copy = null;
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            Save();
            UpdateImage();
        }

        internal void EditPathForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Copy != null)
                Revert();
        }

        internal static Form FormForObject(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            Type type;

            if (obj is ReticlePathElementMoveTo)
                type = typeof(EditMoveToForm);
            else if (obj is ReticlePathElementLineTo)
                type = typeof(EditLineToForm);
            else if (obj is ReticlePathElementArc)
                type = typeof(EditArcForm);
            else
                throw new ArgumentException($"The path element type {obj.GetType().FullName} is not supported", nameof(obj));

            var constructor = type.GetConstructor(new Type[] { obj.GetType() });

            if (constructor == null)
                throw new InvalidOperationException($"There is not constructor that accepts {obj.GetType().FullName} argument in {type.FullName}");

            return (Form)constructor.Invoke(new object[] { obj });
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            ReticlePathElementMoveTo el = new ReticlePathElementMoveTo()
            {
                Position = new ReticlePosition()
                {
                    X = Reticle.Size.X.Unit.New(0),
                    Y = Reticle.Size.Y.Unit.New(0),
                }
            };

            using var form = FormForObject(el);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Path.Elements.Add(el);
                listBoxElements.Items.Add(el);
                UpdateImage();
            }
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            ReticlePathElementLineTo el = new ReticlePathElementLineTo()
            {
                Position = new ReticlePosition()
                {
                    X = Reticle.Size.X.Unit.New(0),
                    Y = Reticle.Size.Y.Unit.New(0),
                }
            };

            using var form = FormForObject(el);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Path.Elements.Add(el);
                listBoxElements.Items.Add(el);
                UpdateImage();
            }
        }

        private void buttonArc_Click(object sender, EventArgs e)
        {
            ReticlePathElementArc el = new ReticlePathElementArc()
            {
                Position = new ReticlePosition()
                {
                    X = Reticle.Size.X.Unit.New(0),
                    Y = Reticle.Size.Y.Unit.New(0),
                }
            };

            using var form = FormForObject(el);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Path.Elements.Add(el);
                listBoxElements.Items.Add(el);
                UpdateImage();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBoxElements.SelectedItem == null)
            {
                MessageBox.Show(this, "Select the element to edit", "Error", MessageBoxButtons.OK);
                return;
            }

            var el = listBoxElements.SelectedItem;
            using var form = FormForObject(el);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var idx = listBoxElements.SelectedIndex;
                listBoxElements.Items.RemoveAt(idx);
                listBoxElements.Items.Insert(idx, el);
                listBoxElements.SelectedIndex = idx;
                UpdateImage();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxElements.SelectedItem == null)
            {
                MessageBox.Show(this, "Select the element to edit", "Error", MessageBoxButtons.OK);
                return;
            }

            var el = listBoxElements.SelectedItem;

            for (int i = 0; i < Path.Elements.Count; i++)
            {
                if (ReferenceEquals(el, Path.Elements[i]))
                {
                    Path.Elements.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < listBoxElements.Items.Count; i++)
            {
                if (ReferenceEquals(el, listBoxElements.Items[i]))
                {
                    listBoxElements.Items.RemoveAt(i);
                    i--;
                }
            }
            UpdateImage();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            Revert();
            UpdateImage();
        }
    }
}
