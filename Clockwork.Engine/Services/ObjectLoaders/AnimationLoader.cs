using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Services.Resource;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clockwork.Engine.Services.ObjectLoaders
{
    public class AnimationLoader : ObjectLoader<AnimationConfig, Animation>
    {
        private SpriteSheetLoader _spriteSheetLoader;

        public AnimationLoader(ResourceService resourceService, SpriteSheetLoader spriteSheetLoader)
            : base(resourceService)
        {
            _spriteSheetLoader = spriteSheetLoader;
        }

        protected override Animation Create(AnimationConfig config)
        {
            var spriteSheet = _spriteSheetLoader.Load(config.SpriteSheet);

            List<AnimationFrame> frames = new List<AnimationFrame>();
            foreach(var ix in Enumerable.Range(0,config.Frames.Length))
            {
                frames.Add(
                    new AnimationFrame
                    (
                        duration: TimeSpan.FromMilliseconds(config.MSPerFrame[ix]),
                        texture: spriteSheet[config.Frames[ix]]
                    ));
            }
            return new Animation(frames);
        }
    }
}
