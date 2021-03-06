﻿using System;
using Windows.Foundation.Metadata;
using Windows.System.Profile;
using Windows.UI.Composition;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;

namespace UICompositionAnimations.Helpers
{
    /// <summary>
    /// A static class that provides useful information on the available APIs
    /// </summary>
    public static class ApiInformationHelper
    {
        #region OS build

        static Version osversion;

        /// <summary>
        /// Gets the current OS version for the device in use
        /// </summary>
        public static Version OSVersion
        {
            get
            {
                if (osversion == null)
                {
                    string deviceFamilyVersion = AnalyticsInfo.VersionInfo.DeviceFamilyVersion;
                    ulong version = ulong.Parse(deviceFamilyVersion);
                    ulong major = (version & 0xFFFF000000000000L) >> 48;
                    ulong minor = (version & 0x0000FFFF00000000L) >> 32;
                    ulong build = (version & 0x00000000FFFF0000L) >> 16;
                    ulong revision = version & 0x000000000000FFFFL;
                    osversion = new Version((int)major, (int)minor, (int)build, (int)revision);
                }
                return osversion;
            }
        }

        /// <summary>
        /// Gets whether or not the current OS version is at least the Anniversary Update (14393)
        /// </summary>
        /// <returns></returns>
        public static bool IsAnniversaryUpdateOrLater => OSVersion.Build > 14000;

        /// <summary>
        /// Gets whether or not the current OS version is at least the Creator's Update (15063)
        /// </summary>
        /// <returns></returns>
        public static bool IsCreatorsUpdateOrLater => OSVersion.Build > 15000;

        /// <summary>
        /// Gets whether or not the current OS version is at least the Fall Creator's Update (16xxx)
        /// </summary>
        /// <returns></returns>
        public static bool IsFallCreatorsUpdateOrLater => OSVersion.Build > 16000;

        #endregion

        #region Available APIs

        /// <summary>
        /// Gets whether or not the connected animations APIs are available
        /// </summary>
        public static bool AreConnectedAnimationsAvailable
        {
            get
            {
                return ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.Animation.ConnectedAnimationService");
            }
        }

        /// <summary>
        /// Gets whether or not the APIs to find the focusable elements are available
        /// </summary>
        public static bool IsFindFirstFocusableElementAvailable
        {
            get
            {
                return ApiInformation.IsMethodPresent("Windows.UI.Xaml.Input.FocusManager", nameof(FocusManager.FindFirstFocusableElement));
            }
        }

        /// <summary>
        /// Gets or sets whether the Target property of the composition animation APIs is available
        /// </summary>
        public static bool SupportsCompositionAnimationTarget
        {
            get
            {
                return ApiInformation.IsPropertyPresent("Windows.UI.Composition.CompositionAnimation", nameof(CompositionAnimation.Target));
            }
        }

        /// <summary>
        /// Gets whether or not the composition animation group type is present
        /// </summary>
        public static bool IsCompositionAnimationGroupAvailable
        {
            get
            {
                return ApiInformation.IsTypePresent("Windows.UI.Composition.CompositionAnimationGroup");
            }
        }

        /// <summary>
        /// Gets whether or not the implicit animations APIs are available
        /// </summary>
        /// <returns></returns>
        public static bool AreImplicitAnimationsAvailable
        {
            get
            {
                return ApiInformation.IsMethodPresent("Windows.UI.Composition.Compositor", nameof(Compositor.CreateImplicitAnimationCollection));
            }
        }

        /// <summary>
        /// Gets whether or not the implicit show/hide animation APIs are available
        /// </summary>
        public static bool AreImplicitShowHideAnimationsAvailable
        {
            get
            {
                return ApiInformation.IsMethodPresent("Windows.UI.Xaml.Hosting.ElementCompositionPreview", nameof(ElementCompositionPreview.SetImplicitShowAnimation));
            }
        }

        /// <summary>
        /// Gets whether or not the XAML lights APIs are available
        /// </summary>
        public static bool AreXamlLightsSupported => ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlLight");

        /// <summary>
        /// Gets whether or not the custom XAML brush APIs are available
        /// </summary>
        public static bool AreCustomBrushesSupported => ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase");

        /// <summary>
        /// Gets whether or not the XYFocusUp property is available/>
        /// </summary>
        /// <returns></returns>
        public static bool IsXYFocusAvailable => ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Controls.Control", nameof(Control.XYFocusUp));

        /// <summary>
        /// Gets whether or not the host backdrop effects are available
        /// </summary>
        /// <returns></returns>
        public static bool AreHostBackdropEffectsAvailable
        {
            get
            {
                return ApiInformation.IsTypePresent("Microsoft.Graphics.Canvas.Effects.GaussianBlurEffect") && ApiInformation.IsMethodPresent("Windows.UI.Composition.Compositor", nameof(Compositor.CreateHostBackdropBrush));
            }
        }

        /// <summary>
        /// Gets whether or not the backdrop effects APIs are available
        /// </summary>
        /// <returns></returns>
        public static bool AreBackdropEffectsAvailable
        {
            get
            {
                return ApiInformation.IsTypePresent("Microsoft.Graphics.Canvas.Effects.GaussianBlurEffect") && ApiInformation.IsMethodPresent("Windows.UI.Composition.Compositor", nameof(Compositor.CreateBackdropBrush));
            }
        }

        /// <summary>
        /// Gets whether or not the drop shadows APIs are available
        /// </summary>
        public static bool AreDropShadowsAvailable => ApiInformation.IsMethodPresent("Windows.UI.Composition.Compositor", nameof(Compositor.CreateDropShadow));

        /// <summary>
        /// Gets whether or not the staggering method is available
        /// </summary>
        /// <returns></returns>
        public static bool IsRepositionStaggerringAvailable() => ApiInformation.IsMethodPresent("Windows.UI.Xaml.Media.Animation.RepositionThemeTransition", "IsStaggeringEnabled");

        /// <summary>
        /// Gets whether or not the RequiresPointer property is available
        /// </summary>
        public static bool IsRequiresPointerAvailable => ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Controls.Control", nameof(Control.RequiresPointer));

        #endregion
    }
}
