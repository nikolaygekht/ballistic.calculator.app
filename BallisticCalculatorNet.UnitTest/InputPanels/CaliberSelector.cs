using BallisticCalculator.Data.Dictionary;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using Moq;
using System;
using System.Windows.Forms;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.InputPanels
{
    public class CaliberSelector
    {
        [Fact]
        public void CaliberListInitialized()
        {
            using var selector = new CaliberSelectorForm();

            selector.ListView("listViewCalibers")
                .Should()
                .HaveItems();
            
            selector.ListView("listViewCalibers")
                .Should()
                .HaveItem(lv => lv.Tag.As<AmmunitionCaliber>().Name == "9x19mm")
                .And
                .HaveItem(lv => lv.Tag.As<AmmunitionCaliber>().Name == "5.56x45mm")
                .And
                .HaveItem(lv => lv.Tag.As<AmmunitionCaliber>().Name == "7.62x39mm")
                .And
                .HaveItem(lv => lv.Tag.As<AmmunitionCaliber>().Name == "12ga");

            selector.ListView("listViewCalibers")
                .Should()
                .HaveNoSelection();
        }

        [Fact]
        public void CaliberListInitiallySortedByType()
        {
            using var selector = new CaliberSelectorForm();

            selector.ListView("listViewCalibers")
                .Should()
                .HaveItemsInOrder((lv0, lv1) =>
                {
                    var t0 = lv0.Tag.As<AmmunitionCaliber>();
                    var t1 = lv1.Tag.As<AmmunitionCaliber>();
                    return t0.TypeOfAmmunition < t1.TypeOfAmmunition ||
                           t0.TypeOfAmmunition == t1.TypeOfAmmunition &&
                           string.Compare(t0.Name, t1.Name) <= 0;
                });
        }

        [Fact]
        public void CaliberListSortedByTypeAfterClick()
        {
            using var selector = new CaliberSelectorForm();

            var args = new ColumnClickEventArgs(0);
            selector.InvokeEventHandler("listViewCalibers_ColumnClick", args);

            selector.ListView("listViewCalibers")
                .Should()
                .HaveItemsInOrder((lv0, lv1) =>
                {
                    var t0 = lv0.Tag.As<AmmunitionCaliber>();
                    var t1 = lv1.Tag.As<AmmunitionCaliber>();
                    return t0.TypeOfAmmunition < t1.TypeOfAmmunition ||
                           t0.TypeOfAmmunition == t1.TypeOfAmmunition &&
                           string.Compare(t0.Name, t1.Name) <= 0;
                });
        }

        [Fact]
        public void CaliberListSortedByNameAfterClick()
        {
            using var selector = new CaliberSelectorForm();

            var args = new ColumnClickEventArgs(1);
            selector.InvokeEventHandler("listViewCalibers_ColumnClick", args);

            selector.ListView("listViewCalibers")
                .Should()
                .HaveItemsInOrder((lv0, lv1) =>
                {
                    var t0 = lv0.Tag.As<AmmunitionCaliber>();
                    var t1 = lv1.Tag.As<AmmunitionCaliber>();
                    return string.Compare(t0.Name, t1.Name) <= 0;
                });
        }

        [Fact]
        public void CaliberListSortedByCaliberAfterClick()
        {
            using var selector = new CaliberSelectorForm();

            var args = new ColumnClickEventArgs(2);
            selector.InvokeEventHandler("listViewCalibers_ColumnClick", args);

            selector.ListView("listViewCalibers")
                .Should()
                .HaveItemsInOrder((lv0, lv1) =>
                {
                    var t0 = lv0.Tag.As<AmmunitionCaliber>();
                    var t1 = lv1.Tag.As<AmmunitionCaliber>();
                    return t0.BulletDiameter <= t1.BulletDiameter;
                });
        }


        [Fact]
        public void Finder()
        {
            var messageBoxInvoked = false;

            var messageBoxFactory = new Mock<IMessageFactory>();
            messageBoxFactory.Setup(f => f.ShowMessage(
                    It.IsAny<IWin32Window>(),
                    It.Is<string>(s => s.Contains("isn't found")),
                    It.IsAny<string>(),
                    It.Is<MessageBoxButtons>(s => s == MessageBoxButtons.OK),
                    It.IsAny<MessageBoxIcon>()))
                .Returns(DialogResult.OK)
                .Callback((Action)(() => { messageBoxInvoked = true; }));

            using var selector = new CaliberSelectorForm();
            selector.MessageFactory = messageBoxFactory.Object;
            selector.TextBox("textBoxFind").Text = "Lapua";
            selector.InvokeEventHandler("buttonFind_Click", EventArgs.Empty);

            messageBoxInvoked.Should().BeFalse();
            
            selector.ListView("listViewCalibers")
                .Should()
                .HaveItemSelected((lvi, index) => lvi.Tag.As<AmmunitionCaliber>().Name.Contains("300 Lapua"));

            selector.InvokeEventHandler("buttonFind_Click", EventArgs.Empty);

            messageBoxInvoked.Should().BeFalse();

            selector.ListView("listViewCalibers")
                .Should()
                .HaveItemSelected((lvi, index) => lvi.Tag.As<AmmunitionCaliber>().Name.Contains("338 Lapua"));

            selector.InvokeEventHandler("buttonFind_Click", EventArgs.Empty);

            messageBoxInvoked.Should().BeTrue();
        }

        [Fact]
        public void OK_WhenSelected()
        {
            using var selector = new CaliberSelectorForm();
            selector.TextBox("textBoxFind").Text = "Lapua";
            selector.InvokeEventHandler("buttonFind_Click", EventArgs.Empty);
            selector.InvokeEventHandler("buttonSelect_Click", EventArgs.Empty);
            selector.Caliber.Should().NotBeNull();
            selector.Caliber.Name.Should().Contain("Lapua");
        }

        [Fact]
        public void OK_WhenNotSelected()
        {
            using var selector = new CaliberSelectorForm();
            selector.InvokeEventHandler("buttonSelect_Click", EventArgs.Empty);
            selector.Caliber.Should().BeNull();
            selector.DialogResult.Should().Be(DialogResult.None);
        }
    }
}
