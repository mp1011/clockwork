using Clockwork.Engine;
using Clockwork.Engine.Behaviors;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Models.Scene;
using Clockwork.Engine.Services;
using Clockwork.Engine.Services.ObjectLoaders;
using Clockwork.Tests.MockFactories;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Numerics;

namespace Clockwork.Tests.Services
{
    class CollisionManagerTests : TestBase
    {
      

        [Test]
        public void ObjectCanCollideWithTiles()
        {
            var map = DIRegistrar.GetInstance<TileMapLoader>().Load("testmap");

            var movingObject = ICollidableFactory.Create(0, 10);
            movingObject.Position.Center = new Vector2(50, 50);


            
            var collisionManager = new CollisionManager();
            collisionManager.AddObject(movingObject);

            Assert.Fail();
        }
    }
}
