using System;
using System.Windows.Forms;
using Xunit;
using FluentAssertions;

namespace Gehtsoft.Winforms.FluentAssertions.Test
{
    public class InvokeTest
    {
        public class InvokeSubject : Form
        {
            public bool ClickInvoked { get; set; }
            public bool ChangedInvoked { get; set; }

#pragma warning disable S1144, RCS1213 // Unused private types or members should be removed: Methods actually are called via reflection
            private void on_MyControlClick(object obj, MouseEventArgs args)
            {
                ClickInvoked = true;
            }

            private void on_MyControlChanged(object obj, EventArgs args)
            {
                ChangedInvoked = true;
            }
#pragma warning restore S1144, RCS1213 // Unused private types or members should be removed
        }

        [Fact]
        public void InvokeClick()
        {
            var target = new InvokeSubject();

            target.InvokeEventHandler("Click", new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));

            target.ClickInvoked.Should().BeTrue();
            target.ChangedInvoked.Should().BeFalse();
        }

        [Fact]
        public void InvokeChange()
        {
            var target = new InvokeSubject();

            target.InvokeEventHandler("Change", EventArgs.Empty);

            target.ClickInvoked.Should().BeFalse();
            target.ChangedInvoked.Should().BeTrue();
        }

        [Fact]
        public void InvokeNoMethod_Name()
        {
            var target = new InvokeSubject();

            ((Action)(() => target.InvokeEventHandler("NoSuchName", EventArgs.Empty)))
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void InvokeNoMethod_Args()
        {
            var target = new InvokeSubject();

            ((Action)(() => target.InvokeEventHandler("Click", EventArgs.Empty)))
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void InvokeTwoMatches_Name()
        {
            var target = new InvokeSubject();

            ((Action)(() => target.InvokeEventHandler("Control", new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0))))
                .Should().Throw<ArgumentException>();
        }
    }
}
