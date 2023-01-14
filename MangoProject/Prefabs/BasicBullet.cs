using System.Numerics;
using Easel.Entities;
using Easel.Entities.Components;
using System.Numerics;
using Easel.Graphics;
using MangoProject.Components;

namespace MangoProject.Prefabs;

public class BasicBullet
{
    private Texture2D texture;
    private float size;
    
    public BasicBullet(Texture2D texture, float size)
    {
        this.texture = texture;
        this.size = size;
    }

    public Entity Instantiate(Vector3 startingPos)
    {
        Entity bullet = new Entity();
        bullet.AddComponent(new Sprite(texture));
        bullet.Transform.Scale = new Vector3(size, size, 2f);
        bullet.Transform.Origin = new Vector3(texture.Size.Width / 2, texture.Size.Height / 2, 1);
        bullet.Transform.Position = startingPos;
        bullet.AddComponent(new CircleCollider(texture.Size.Width / 2 * size, false));
        bullet.AddComponent(new Rigidbody());
        
        return bullet;
    }
}