public class FeatureCollection
{
    public List<Feature> Features { get; set; } = new();
}

public class Feature
{
    public FeatureProperties Properties { get; set; } = new();
}

public class FeatureProperties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}