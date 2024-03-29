﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculator.Reticle;
using BallisticCalculator.Reticle.Data;
using BallisticCalculatorNet.ReticleEditor.Forms;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.ReticleEditor
{
    public class EditForms
    {
        [Fact]
        public void CircleEdit1()
        {
            ReticleCircle circle = new ReticleCircle()
            {
                Center = new ReticlePosition(1, 2, AngularUnit.Mil),
                Radius = AngularUnit.MOA.New(3),
                LineWidth = AngularUnit.MOA.New(0.1),
                Color = "black",
                Fill = true,
            };

            EditCircleForm form = new EditCircleForm(circle);

            form.MeasurementControl("measurementX").Should().HaveValue(circle.Center.X);
            form.MeasurementControl("measurementY").Should().HaveValue(circle.Center.Y);
            form.MeasurementControl("measurementR").Should().HaveValue(circle.Radius);
            form.MeasurementControl("measurementWidth").Should().HaveValue(circle.LineWidth.Value);
            form.ComboBox("comboBoxColor").Should().HaveText(circle.Color);
            form.CheckBox("checkBoxFill").Should().BeChecked();

            form.MeasurementControl("measurementX").Value = AngularUnit.MOA.New(10);
            form.MeasurementControl("measurementY").Value = AngularUnit.MOA.New(11);
            form.MeasurementControl("measurementR").Value = AngularUnit.MOA.New(12);
            form.MeasurementControl("measurementWidth").Value = AngularUnit.MOA.New(13);
            form.ComboBox("comboBoxColor").Text = "aqua";
            form.CheckBox("checkBoxFill").Checked = false;

            circle.Center.X.Should().NotBe(AngularUnit.MOA.New(10));
            circle.Center.Y.Should().NotBe(AngularUnit.MOA.New(11));
            circle.Radius.Should().NotBe(AngularUnit.MOA.New(12));
            circle.LineWidth.Should().NotBe(AngularUnit.MOA.New(13));
            circle.Color.Should().NotBe("aqua");
            circle.Fill.Should().NotBeFalse();

            form.Save();

            circle.Center.X.Should().Be(AngularUnit.MOA.New(10));
            circle.Center.Y.Should().Be(AngularUnit.MOA.New(11));
            circle.Radius.Should().Be(AngularUnit.MOA.New(12));
            circle.LineWidth.Should().Be(AngularUnit.MOA.New(13));
            circle.Color.Should().Be("aqua");
            circle.Fill.Should().BeFalse();
        }

        [Fact]
        public void LineEdit1()
        {
            ReticleLine line = new ReticleLine()
            {
                Start = new ReticlePosition(1, 2, AngularUnit.Mil),
                End = new ReticlePosition(3, 4, AngularUnit.Mil),
                LineWidth = AngularUnit.MOA.New(0.1),
                Color = "black",
            };

            EditLineForm form = new EditLineForm(line);

            form.MeasurementControl("measurementX1").Should().HaveValue(line.Start.X);
            form.MeasurementControl("measurementY1").Should().HaveValue(line.Start.Y);
            form.MeasurementControl("measurementX2").Should().HaveValue(line.End.X);
            form.MeasurementControl("measurementY2").Should().HaveValue(line.End.Y);
            form.MeasurementControl("measurementWidth").Should().HaveValue(line.LineWidth.Value);
            form.ComboBox("comboBoxColor").Should().HaveText(line.Color);

            form.MeasurementControl("measurementX1").Value = AngularUnit.MOA.New(10);
            form.MeasurementControl("measurementY1").Value = AngularUnit.MOA.New(11);
            form.MeasurementControl("measurementX2").Value = AngularUnit.MOA.New(12);
            form.MeasurementControl("measurementY2").Value = AngularUnit.MOA.New(13);
            form.MeasurementControl("measurementWidth").Value = AngularUnit.MOA.New(21);
            form.ComboBox("comboBoxColor").Text = "aqua";

            line.Start.X.Should().NotBe(AngularUnit.MOA.New(10));
            line.Start.Y.Should().NotBe(AngularUnit.MOA.New(11));
            line.End.X.Should().NotBe(AngularUnit.MOA.New(12));
            line.End.Y.Should().NotBe(AngularUnit.MOA.New(13));
            line.LineWidth.Should().NotBe(AngularUnit.MOA.New(21));
            line.Color.Should().NotBe("aqua");

            form.Save();

            line.Start.X.Should().Be(AngularUnit.MOA.New(10));
            line.Start.Y.Should().Be(AngularUnit.MOA.New(11));
            line.End.X.Should().Be(AngularUnit.MOA.New(12));
            line.End.Y.Should().Be(AngularUnit.MOA.New(13));
            line.LineWidth.Should().Be(AngularUnit.MOA.New(21));
            line.Color.Should().Be("aqua");
        }

        [Fact]
        public void RectangleEdit1()
        {
            ReticleRectangle rectangle = new ReticleRectangle()
            {
                TopLeft = new ReticlePosition(1, 2, AngularUnit.Mil),
                Size = new ReticlePosition(3, 4, AngularUnit.Mil),
                LineWidth = AngularUnit.MOA.New(0.1),
                Color = "black",
                Fill = true
            };

            EditRectangleForm form = new EditRectangleForm(rectangle);

            form.MeasurementControl("measurementX1").Should().HaveValue(rectangle.TopLeft.X);
            form.MeasurementControl("measurementY1").Should().HaveValue(rectangle.TopLeft.Y);
            form.MeasurementControl("measurementX2").Should().HaveValue(rectangle.Size.X);
            form.MeasurementControl("measurementY2").Should().HaveValue(rectangle.Size.Y);
            form.MeasurementControl("measurementWidth").Should().HaveValue(rectangle.LineWidth.Value);
            form.ComboBox("comboBoxColor").Should().HaveText(rectangle.Color);
            form.CheckBox("checkBoxFill").Should().BeChecked();

            form.MeasurementControl("measurementX1").Value = AngularUnit.MOA.New(10);
            form.MeasurementControl("measurementY1").Value = AngularUnit.MOA.New(11);
            form.MeasurementControl("measurementX2").Value = AngularUnit.MOA.New(12);
            form.MeasurementControl("measurementY2").Value = AngularUnit.MOA.New(13);
            form.MeasurementControl("measurementWidth").Value = AngularUnit.MOA.New(21);
            form.ComboBox("comboBoxColor").Text = "aqua";
            form.CheckBox("checkBoxFill").Checked = false;

            rectangle.TopLeft.X.Should().NotBe(AngularUnit.MOA.New(10));
            rectangle.TopLeft.Y.Should().NotBe(AngularUnit.MOA.New(11));
            rectangle.Size.X.Should().NotBe(AngularUnit.MOA.New(12));
            rectangle.Size.Y.Should().NotBe(AngularUnit.MOA.New(13));
            rectangle.LineWidth.Should().NotBe(AngularUnit.MOA.New(21));
            rectangle.Color.Should().NotBe("aqua");
            rectangle.Fill.Should().NotBeFalse();

            form.Save();

            rectangle.TopLeft.X.Should().Be(AngularUnit.MOA.New(10));
            rectangle.TopLeft.Y.Should().Be(AngularUnit.MOA.New(11));
            rectangle.Size.X.Should().Be(AngularUnit.MOA.New(12));
            rectangle.Size.Y.Should().Be(AngularUnit.MOA.New(13));
            rectangle.LineWidth.Should().Be(AngularUnit.MOA.New(21));
            rectangle.Color.Should().Be("aqua");
            rectangle.Fill.Should().BeFalse();
        }

        [Fact]
        public void TextEdit1()
        {
            ReticleText text = new ReticleText()
            {
                Position = new ReticlePosition(1, 2, AngularUnit.Mil),
                TextHeight = AngularUnit.MOA.New(3),
                Color = "black",
                Text = "123",
            };

            EditTextForm form = new EditTextForm(text);

            form.MeasurementControl("measurementX").Should().HaveValue(text.Position.X);
            form.MeasurementControl("measurementY").Should().HaveValue(text.Position.Y);
            form.MeasurementControl("measurementH").Should().HaveValue(text.TextHeight);
            form.ComboBox("comboBoxColor").Should().HaveText(text.Color);
            form.TextBox("textBox").Should().HaveText(text.Text);

            form.MeasurementControl("measurementX").Value = AngularUnit.MOA.New(10);
            form.MeasurementControl("measurementY").Value = AngularUnit.MOA.New(11);
            form.MeasurementControl("measurementH").Value = AngularUnit.MOA.New(12);
            form.ComboBox("comboBoxColor").Text = "aqua";
            form.TextBox("textBox").Text = "456";

            text.Position.X.Should().NotBe(AngularUnit.MOA.New(10));
            text.Position.Y.Should().NotBe(AngularUnit.MOA.New(11));
            text.TextHeight.Should().NotBe(AngularUnit.MOA.New(12));
            text.Color.Should().NotBe("aqua");
            text.Text.Should().NotBe("456");

            form.Save();

            text.Position.X.Should().Be(AngularUnit.MOA.New(10));
            text.Position.Y.Should().Be(AngularUnit.MOA.New(11));
            text.TextHeight.Should().Be(AngularUnit.MOA.New(12));
            text.Color.Should().Be("aqua");
            text.Text.Should().Be("456");
        }

        [Fact]
        public void BdcEdit()
        {
            ReticleBulletDropCompensatorPoint bdc = new ReticleBulletDropCompensatorPoint()
            {
                Position = new ReticlePosition(1, 2, AngularUnit.Mil),
                TextHeight = AngularUnit.MOA.New(3),
                TextOffset = AngularUnit.MOA.New(4),
            };

            EditBdcForm form = new EditBdcForm(bdc);

            form.MeasurementControl("measurementX").Should().HaveValue(bdc.Position.X);
            form.MeasurementControl("measurementY").Should().HaveValue(bdc.Position.Y);
            form.MeasurementControl("measurementH").Should().HaveValue(bdc.TextHeight);
            form.MeasurementControl("measurementO").Should().HaveValue(bdc.TextOffset);

            form.MeasurementControl("measurementX").Value = AngularUnit.MOA.New(10);
            form.MeasurementControl("measurementY").Value = AngularUnit.MOA.New(11);
            form.MeasurementControl("measurementH").Value = AngularUnit.MOA.New(12);
            form.MeasurementControl("measurementO").Value = AngularUnit.MOA.New(13);

            bdc.Position.X.Should().NotBe(AngularUnit.MOA.New(10));
            bdc.Position.Y.Should().NotBe(AngularUnit.MOA.New(11));
            bdc.TextHeight.Should().NotBe(AngularUnit.MOA.New(12));
            bdc.TextOffset.Should().NotBe(AngularUnit.MOA.New(13));

            form.Save();

            bdc.Position.X.Should().Be(AngularUnit.MOA.New(10));
            bdc.Position.Y.Should().Be(AngularUnit.MOA.New(11));
            bdc.TextHeight.Should().Be(AngularUnit.MOA.New(12));
            bdc.TextOffset.Should().Be(AngularUnit.MOA.New(13));
        }

        [Fact]
        public void MoveToEdit()
        {
            ReticlePathElementMoveTo el = new ReticlePathElementMoveTo()
            {
                Position = new ReticlePosition(1, 2, AngularUnit.Mil),
            };

            EditMoveToForm form = new EditMoveToForm(el);

            form.MeasurementControl("measurementX1").Should().HaveValue(el.Position.X);
            form.MeasurementControl("measurementY1").Should().HaveValue(el.Position.Y);

            form.MeasurementControl("measurementX1").Value = AngularUnit.MOA.New(10);
            form.MeasurementControl("measurementY1").Value = AngularUnit.MOA.New(11);

            el.Position.X.Should().NotBe(AngularUnit.MOA.New(10));
            el.Position.Y.Should().NotBe(AngularUnit.MOA.New(11));

            form.Save();

            el.Position.X.Should().Be(AngularUnit.MOA.New(10));
            el.Position.Y.Should().Be(AngularUnit.MOA.New(11));
        }

        [Fact]
        public void LineToEdit()
        {
            ReticlePathElementLineTo el = new ReticlePathElementLineTo()
            {
                Position = new ReticlePosition(1, 2, AngularUnit.Mil),
            };

            EditLineToForm form = new EditLineToForm(el);

            form.MeasurementControl("measurementX1").Should().HaveValue(el.Position.X);
            form.MeasurementControl("measurementY1").Should().HaveValue(el.Position.Y);

            form.MeasurementControl("measurementX1").Value = AngularUnit.MOA.New(10);
            form.MeasurementControl("measurementY1").Value = AngularUnit.MOA.New(11);

            el.Position.X.Should().NotBe(AngularUnit.MOA.New(10));
            el.Position.Y.Should().NotBe(AngularUnit.MOA.New(11));

            form.Save();

            el.Position.X.Should().Be(AngularUnit.MOA.New(10));
            el.Position.Y.Should().Be(AngularUnit.MOA.New(11));
        }

        [Fact]
        public void ArcEdit()
        {
            ReticlePathElementArc el = new ReticlePathElementArc()
            {
                Position = new ReticlePosition(1, 2, AngularUnit.Mil),
                Radius = AngularUnit.Mil.New(3),
                MajorArc = true,
                ClockwiseDirection = true,
            };

            EditArcForm form = new EditArcForm(el);

            form.MeasurementControl("measurementX1").Should().HaveValue(el.Position.X);
            form.MeasurementControl("measurementY1").Should().HaveValue(el.Position.Y);
            form.MeasurementControl("measurementR").Should().HaveValue(el.Radius);
            form.CheckBox("checkBoxMajorArc").Should().Be(el.MajorArc);
            form.CheckBox("checkBoxClockwise").Should().Be(el.ClockwiseDirection);

            form.MeasurementControl("measurementX1").Value = AngularUnit.MOA.New(10);
            form.MeasurementControl("measurementY1").Value = AngularUnit.MOA.New(11);
            form.MeasurementControl("measurementR").Value = AngularUnit.MOA.New(13);
            form.CheckBox("checkBoxMajorArc").Checked = false;
            form.CheckBox("checkBoxClockwise").Checked = false;

            el.Position.X.Should().NotBe(AngularUnit.MOA.New(10));
            el.Position.Y.Should().NotBe(AngularUnit.MOA.New(11));
            el.Radius.Should().NotBe(AngularUnit.MOA.New(13));
            el.MajorArc.Should().BeTrue();
            el.ClockwiseDirection.Should().BeTrue();

            form.Save();

            el.Position.X.Should().Be(AngularUnit.MOA.New(10));
            el.Position.Y.Should().Be(AngularUnit.MOA.New(11));
            el.Radius.Should().Be(AngularUnit.MOA.New(13));
            el.MajorArc.Should().BeFalse();
            el.ClockwiseDirection.Should().BeFalse();
        }
    }

    public class EditPath
    {
        [Fact]
        public void Parameters_Save()
        {
            MilDotReticle mildot = new MilDotReticle();

            ReticlePath path = new ReticlePath()
            {
                LineWidth = AngularUnit.MOA.New(0.1),
                Color = "black",
                Fill = true
            };

            EditPathForm form = new EditPathForm(path, mildot);

            form.MeasurementControl("measurementWidth").Should().HaveValue(path.LineWidth.Value);
            form.ComboBox("comboBoxColor").Should().HaveText(path.Color);
            form.CheckBox("checkBoxFill").Should().BeChecked();

            form.MeasurementControl("measurementWidth").Value = AngularUnit.MOA.New(21);
            form.ComboBox("comboBoxColor").Text = "aqua";
            form.CheckBox("checkBoxFill").Checked = false;

            path.LineWidth.Should().NotBe(AngularUnit.MOA.New(21));
            path.Color.Should().NotBe("aqua");
            path.Fill.Should().NotBeFalse();

            form.buttonOK_Click(this, EventArgs.Empty);

            path.LineWidth.Should().Be(AngularUnit.MOA.New(21));
            path.Color.Should().Be("aqua");
            path.Fill.Should().BeFalse();

            form.Close();
            form.EditPathForm_FormClosed(this, new FormClosedEventArgs(CloseReason.UserClosing));
            form.Dispose();

            path.LineWidth.Should().Be(AngularUnit.MOA.New(21));
            path.Color.Should().Be("aqua");
            path.Fill.Should().BeFalse();
        }

        [Fact]
        public void Parameters_Preview_Then_Cancel()
        {
            MilDotReticle mildot = new MilDotReticle();

            ReticlePath path = new ReticlePath()
            {
                LineWidth = AngularUnit.MOA.New(0.1),
                Color = "black",
                Fill = true
            };

            EditPathForm form = new EditPathForm(path, mildot);

            form.MeasurementControl("measurementWidth").Should().HaveValue(path.LineWidth.Value);
            form.ComboBox("comboBoxColor").Should().HaveText(path.Color);
            form.CheckBox("checkBoxFill").Should().BeChecked();

            form.MeasurementControl("measurementWidth").Value = AngularUnit.MOA.New(21);
            form.ComboBox("comboBoxColor").Text = "aqua";
            form.CheckBox("checkBoxFill").Checked = false;

            path.LineWidth.Should().NotBe(AngularUnit.MOA.New(21));
            path.Color.Should().NotBe("aqua");
            path.Fill.Should().NotBeFalse();

            form.Save();

            path.LineWidth.Should().Be(AngularUnit.MOA.New(21));
            path.Color.Should().Be("aqua");
            path.Fill.Should().BeFalse();

            form.Revert();

            path.LineWidth.Should().Be(AngularUnit.MOA.New(0.1));
            path.Color.Should().Be("black");
            path.Fill.Should().BeTrue();
        }

        [Fact]
        public void Parameters_Preview_Then_Close()
        {
            MilDotReticle mildot = new MilDotReticle();

            ReticlePath path = new ReticlePath()
            {
                LineWidth = AngularUnit.MOA.New(0.1),
                Color = "black",
                Fill = true
            };

            EditPathForm form = new EditPathForm(path, mildot);

            form.MeasurementControl("measurementWidth").Should().HaveValue(path.LineWidth.Value);
            form.ComboBox("comboBoxColor").Should().HaveText(path.Color);
            form.CheckBox("checkBoxFill").Should().BeChecked();

            form.MeasurementControl("measurementWidth").Value = AngularUnit.MOA.New(21);
            form.ComboBox("comboBoxColor").Text = "aqua";
            form.CheckBox("checkBoxFill").Checked = false;

            path.LineWidth.Should().NotBe(AngularUnit.MOA.New(21));
            path.Color.Should().NotBe("aqua");
            path.Fill.Should().NotBeFalse();

            form.Save();

            path.LineWidth.Should().Be(AngularUnit.MOA.New(21));
            path.Color.Should().Be("aqua");
            path.Fill.Should().BeFalse();

            form.Close();
            form.EditPathForm_FormClosed(this, new FormClosedEventArgs(CloseReason.UserClosing));
            form.Dispose();

            path.LineWidth.Should().Be(AngularUnit.MOA.New(0.1));
            path.Color.Should().Be("black");
            path.Fill.Should().BeTrue();
        }

        [Theory]
        [InlineData(typeof(ReticlePathElementMoveTo), typeof(EditMoveToForm))]
        [InlineData(typeof(ReticlePathElementLineTo), typeof(EditLineToForm))]
        [InlineData(typeof(ReticlePathElementArc), typeof(EditArcForm))]
        public void CreateFormObject(Type objectType, Type formType)
        {
            object x = Activator.CreateInstance(objectType);
            var form = EditPathForm.FormForObject(x);
            form.Should().NotBeNull();
            form.Should().BeOfType(formType);
        }
    }
}
