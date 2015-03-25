namespace Nine.Animation
{
    using System;
    using System.ComponentModel;
#if WPF
    using System.Windows;
    using System.Windows.Media;
#endif

    [EditorBrowsable(EditorBrowsableState.Never)]
    static class AnimatableExtensions
    {
#if WPF
        private static readonly DependencyProperty animatableProperty = DependencyProperty.RegisterAttached("Animatable", typeof(IAnimatable2D), typeof(AnimatableExtensions));

        public static IAnimatable2D Animate(this FrameworkElement element)
        {
            var result = (IAnimatable2D)element.GetValue(animatableProperty);
            if (result != null) return result;
            element.SetValue(animatableProperty, result = new FrameworkElementAnimatable(element));
            return result;
        }

        class FrameworkElementAnimatable : IAnimatable2D
        {
            private FrameworkElement e;
            private TranslateTransform translate;
            private RotateTransform rotate;

            public IFrameTimer FrameTimer
            {
                get { return PortableFrameTimer.Default; }
            }

            public FrameworkElementAnimatable(FrameworkElement e)
            {
                var transform = new TransformGroup();
                transform.Children.Add(translate = new TranslateTransform());
                transform.Children.Add(rotate = new RotateTransform());

                this.e = e;
                this.e.RenderTransform = transform;
            }

            public double Alpha
            {
                get { return (double)e.Opacity; }
                set { e.Opacity = value; }
            }

            public double Orientation
            {
                get { return (double)e.Opacity; }
                set { e.Opacity = value; }
            }

            public double X
            {
                get { return (double)translate.X; }
                set { translate.X = value; }
            }

            public double Y
            {
                get { return (double)translate.Y; }
                set { translate.Y = value; }
            }
        }
#endif
    }
}