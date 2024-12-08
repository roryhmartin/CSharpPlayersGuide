namespace Vin_Fletchers_Arrows;

public class Arrow
{
    private ArrowHead _arrowhead;
    private Fletching _fletching;
    private float _length;

    
    
    public Arrow(ArrowHead arrowhead, Fletching fletching, float length)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    public ArrowHead GetArrowHead() => _arrowhead;
    public Fletching GetFletching() => _fletching;
    public float GetLength() => _length;
    
    public void SetArrowHead(ArrowHead arrowHead) => _arrowhead = arrowHead;
    
    public void SetFletching(Fletching fletching) => _fletching = fletching;
    
    public void SetLength(float length) => _length = length;
    
    public float GetCost()
    {
        float arrowHeadCost = _arrowhead switch
        {
            ArrowHead.Wood => 3,
            ArrowHead.Steel => 10,
            ArrowHead.Obsidian => 5
        };

        float fletchingCost = _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.Feather => 5,
            Fletching.GooseFeathers => 3
        };

        float shaftCost = _length * 0.05f;

        return arrowHeadCost + fletchingCost + shaftCost;
    }
    
    
}