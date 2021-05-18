using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.MsrmentControl
{
    public class FormRunnerTest
    {
        [Fact]
        public void Run()
        {
            using TestForm tf = new TestForm();

            var editBox = tf.AddControl<TextBox>(1, 1, 20, 10);
            var button = tf.AddControl<Button>(25, 25, 10, 10);

            List<char> actions = new List<char>();
            editBox.KeyPress += (sender, args) => actions.Add(args.KeyChar);

            bool clicked = false;
            button.Click += (sender, args) => clicked = true;

            FormRunner runner = new FormRunner(tf);
            runner.Start();
            runner.IsAlive.Should().BeTrue();
            editBox.SendKey(VirtualKeys.A, 'a');
            editBox.Text.Should().Be("a");
            editBox.SendKey(VirtualKeys.B, 'b');
            editBox.SafeInvoke<string>(() => editBox.Text).Should().Be("ab");
            editBox.SendKey(VirtualKeys.Left);
            editBox.SendKey(VirtualKeys.Back);
            editBox.SafeInvoke<string>(() => editBox.Text).Should().Be("b");
            button.LeftButtonClick();

            tf.SafeInvokeAction(() => tf.Close());
            runner.Join(TimeSpan.FromSeconds(5)).Should().BeTrue();
            runner.IsAlive.Should().BeFalse();
            runner.Exception.Should().BeNull();

            actions.Should().HaveCount(3);
            actions[0].Should().Be('a');
            actions[1].Should().Be('b');

            clicked.Should().BeTrue();
        }
    }
}
