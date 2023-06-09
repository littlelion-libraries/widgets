﻿using System;

namespace Widgets
{
    public class ExtensionWidgetFactory : IExtensionWidgetFactory
    {
        private Action<IWidget> _addChild;
        private IWidgetFactory _impl;

        public Action<IWidget> AddChild
        {
            set => _addChild = value;
        }

        public IWidgetFactory Impl
        {
            set => _impl = value;
        }

        public T CreateWidget<T>(string widgetName) where T : class, IWidgetExtension
        {
            var widget = _impl.CreateWidget<T>(widgetName);
            _addChild(widget.Widget);
            return widget;
        }

        public void DestroyWidget(IWidget widget)
        {
            _impl.DestroyWidget(widget);
        }
    }
}