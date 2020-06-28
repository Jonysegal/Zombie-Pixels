using SFML.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Tile
{
    //Bright ground is just for debugging
    public enum Type { Floor, Soldier };

    public enum Alliance { Red, Blue };

    public Type type;

    public Alliance alliance;

    public bool overridesColor = false;

    public Color color;

    public static readonly Dictionary<Tile.Type, Color> TypeColorMap = new Dictionary<Tile.Type, Color>()
        {
            {Tile.Type.Floor, Color.Black },
        };

    static readonly Dictionary<Alliance, Color> AllianceColorMap = new Dictionary<Alliance, Color>()
    {
        {Alliance.Red, Color.Red },
        {Alliance.Blue, Color.Blue }
    };

    public Tile(Type type)
    {
        this.type = type;
    }

    public Tile(Type type, Alliance alliance) : this(type)
    {
        this.alliance = alliance;
    }

    public void OverrideColor(Color newColor)
    {
        overridesColor = true;
        color = newColor;
    }

    public bool EquivelentForDrawing(Tile checkAgainst)
    {
        if (type == Type.Floor && checkAgainst.type == Type.Floor)
            return true;
        else if (type == Type.Soldier && checkAgainst.type == Type.Soldier && alliance == checkAgainst.alliance)
            return true;
        return false;
    }

    public Color GetDrawingColor()
    {
        if (overridesColor)
            return color;
        if (TypeColorMap.TryGetValue(type, out var typeColor))
            return typeColor;
        if (AllianceColorMap.TryGetValue(alliance, out var allianceColor))
            return allianceColor;
        Console.WriteLine("tried to get color but couldn't find one for tile " + type + " " + alliance);
        return Color.Yellow;
    }

}


