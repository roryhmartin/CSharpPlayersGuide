namespace The_Properties_Of_Arrows;

public class Arrow
{
    public ArrowHead ArrowHead { get; set; }
    public Fletching Fletching { get; }
    public float Length { get; }
    
    public Arrow(ArrowHead arrowhead, Fletching fletching, float length)
    {
        ArrowHead = arrowhead;
        Fletching = fletching;
        Length = length;
    }
    public float GetCost()
    {
        float arrowHeadCost = ArrowHead switch
        {
            ArrowHead.Wood => 3,
            ArrowHead.Steel => 10,
            ArrowHead.Obsidian => 5
        };

        float fletchingCost = Fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.Feather => 5,
            Fletching.GooseFeathers => 3
        };

        float shaftCost = Length * 0.05f;

        return arrowHeadCost + fletchingCost + shaftCost;
    }

    public static Arrow CreateEliteArrow()
    {
         Arrow eliteArrow = new Arrow(ArrowHead.Steel, Fletching.Plastic, 95);
         return eliteArrow;
    }

    public static Arrow CreateBeginnerArrow()
    {
        Arrow beginnerArrow = new Arrow(ArrowHead.Wood, Fletching.GooseFeathers, 75);
        return beginnerArrow;
    }

    public static Arrow CreateMarksmanArrow()
    {
        Arrow marksmanArrow = new Arrow(ArrowHead.Steel, Fletching.GooseFeathers, 65);
        return marksmanArrow;
    }
        
}