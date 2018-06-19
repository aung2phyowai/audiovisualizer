﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AudioVisualizer.test
{
    [TestClass]
    public class DiscreteVUBarTests
    {
        DiscreteVUBar sut;

        [TestInitialize]
        public void TestInit()
        {
            sut = new AudioVisualizer.DiscreteVUBar();
        }

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_DefaultSourceIsNull()
        {
            Assert.IsNull(sut.Source);
        }

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_CanSetSource()
        {
            FakeVisualizationSource source = new FakeVisualizationSource();
            sut.Source = source;
            Assert.AreEqual(source, sut.Source);
        }

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_DefaultBackgroundIsTransparent()
        {
            Assert.AreEqual(Windows.UI.Colors.Transparent, sut.BackgroundColor);
        }
        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_CanSetBackground()
        {
            sut.BackgroundColor = Windows.UI.Colors.White;
            Assert.AreEqual(Windows.UI.Colors.White, sut.BackgroundColor);
        }

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_IsDefaultChannelSetToZero()
        {
            Assert.AreEqual(0u, sut.ChannelIndex);
        }
        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_CanSetChannelIndex()
        {
            sut.ChannelIndex = 1;
            Assert.AreEqual(1u, sut.ChannelIndex);
        }

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_IsDefaultLevelsSet()
        {
            CollectionAssert.AreEqual(g_DefaultLevels, sut.Levels);
        }

        MeterBarLevel[] g_LevelsToSet = new MeterBarLevel[]
        {
            new MeterBarLevel() { Level = -10, Color = Colors.Red },
            new MeterBarLevel() { Level = -5, Color = Colors.Red },
            new MeterBarLevel() { Level = 0, Color = Colors.Lime}
        };
        MeterBarLevel[] g_DefaultLevels = new MeterBarLevel[]
        {
            new MeterBarLevel() { Level = -60, Color = Colors.Lime },
            new MeterBarLevel() { Level = -57, Color = Colors.Lime },
            new MeterBarLevel() { Level = -54, Color = Colors.Lime },
            new MeterBarLevel() { Level = -51, Color = Colors.Lime },
            new MeterBarLevel() { Level = -48, Color = Colors.Lime },
            new MeterBarLevel() { Level = -45, Color = Colors.Lime },
            new MeterBarLevel() { Level = -42, Color = Colors.Lime },
            new MeterBarLevel() { Level = -39, Color = Colors.Lime },
            new MeterBarLevel() { Level = -36, Color = Colors.Lime },
            new MeterBarLevel() { Level = -33, Color = Colors.Lime },
            new MeterBarLevel() { Level = -30, Color = Colors.Lime },
            new MeterBarLevel() { Level = -27, Color = Colors.Lime },
            new MeterBarLevel() { Level = -24, Color = Colors.Lime },
            new MeterBarLevel() { Level = -21, Color = Colors.Lime },
            new MeterBarLevel() { Level = -18, Color = Colors.Lime },
            new MeterBarLevel() { Level = -15, Color = Colors.Lime },
            new MeterBarLevel() { Level = -12, Color = Colors.Lime },
            new MeterBarLevel() { Level = -9, Color = Colors.Lime },
            new MeterBarLevel() { Level = -6, Color = Colors.Yellow },
            new MeterBarLevel() { Level = -3, Color = Colors.Yellow },
            new MeterBarLevel() { Level = -0, Color = Colors.Yellow },
            new MeterBarLevel() { Level = 3, Color = Colors.Red },
            new MeterBarLevel() { Level = 6, Color = Colors.Red },
        };

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_CanSetLevels()
        {
            sut.Levels = g_LevelsToSet;
            CollectionAssert.AreEqual(g_LevelsToSet, sut.Levels);
        }

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_SettingLevelsToNullThrows()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                sut.Levels = null;
            });
        }
        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_SettingLevelsToEmptyThrows()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                sut.Levels = new MeterBarLevel[] { };
            });
        }
        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_SettingLevelsToNonAscendingOrderThrows()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                sut.Levels = new MeterBarLevel[] {
                    new MeterBarLevel() { Level = -100 },
                    new MeterBarLevel() { Level = -100 },
                    new MeterBarLevel() { Level = -80 },
                };
            });
        }

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_IsDefaultOrientationVertical()
        {
            Assert.AreEqual(Orientation.Vertical, sut.Orientation);
        }
        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_CanSetOrientation()
        {
            sut.Orientation = Orientation.Horizontal;
            Assert.AreEqual(Orientation.Horizontal, sut.Orientation);
        }

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_IsDefaultRelativeElementMarginZero()
        {
            Assert.AreEqual(new Thickness(0), sut.RelativeElementMargin);
        }

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_CanSetRelativeElementMargin()
        {
            var margin = new Thickness(0.1);
            sut.RelativeElementMargin = margin;
            Assert.AreEqual(margin, sut.RelativeElementMargin);
        }

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_IsDefaultUnlitElementGray()
        {
            Assert.AreEqual(Colors.DarkGray, sut.UnlitElement);
        }

        [UITestMethod]
        [TestCategory("DiscreteVUBar")]
        public void DiscreteVUBar_CanSetUnlitElement()
        {
            sut.UnlitElement = Colors.Gray;
            Assert.AreEqual(Colors.Gray, sut.UnlitElement);
        }
    }
}
