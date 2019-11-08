using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.GameObjectInterfaces;
using Clockwork.Engine.Models.General;
using System;
using System.Collections.Generic;

namespace Clockwork.Engine.Models.Graphics
{
    public class Animation : IUpdateable
    {
        private AnimationFrameBank _frames;
        private double _msUntilNextFrame;

        public ITextureSection CurrentFrame => _frames;

        public Animation(IEnumerable<AnimationFrame> frames)
        {
            _frames = new AnimationFrameBank(frames);
            _msUntilNextFrame = _frames.Current.Duration.TotalMilliseconds;
        }

        public void Update(TimeSpan elapsedInFrame)
        {
            _msUntilNextFrame -= elapsedInFrame.TotalMilliseconds;
            if(_msUntilNextFrame <= 0)
            {
                _frames.Index++;
                _msUntilNextFrame = _frames.Current.Duration.TotalMilliseconds;
            }
        }
    }
}
