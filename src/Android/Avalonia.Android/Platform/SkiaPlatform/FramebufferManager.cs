﻿using System;
using Avalonia.Controls.Platform.Surfaces;
using Avalonia.Platform;

namespace Avalonia.Android.Platform.SkiaPlatform
{
    internal sealed class FramebufferManager : IFramebufferPlatformSurface
    {
        private readonly TopLevelImpl _topLevel;

        public FramebufferManager(TopLevelImpl topLevel)
        {
            _topLevel = topLevel;
        }

        public ILockedFramebuffer Lock() => new AndroidFramebuffer(
            _topLevel.InternalView.Holder?.Surface ?? throw new InvalidOperationException("TopLevel.InternalView.Holder.Surface was not expected to be null."),
            _topLevel.RenderScaling);

        public IFramebufferRenderTarget CreateFramebufferRenderTarget() => new FuncFramebufferRenderTarget(Lock);
    }
}
