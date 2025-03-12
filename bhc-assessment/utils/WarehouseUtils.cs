static class WarehouseUtils {

    static public double CalculateTotalLinesCurrentWeight(Line[] lines) {

        // taking max line capacity since all line will be loaded to capacity
        // if we take account of weight of partially full racks or lines we will overload the warehouse
        // when all the racks and lines are full

        double weight = 0;

        foreach (Line item in lines)
        {
            weight += item.MaxLineCapacity;
        }

        return weight;
    }

    static public double CalculateTotalRackCurrentWeight(Rack[] racks) {

        // taking max line capacity since all line will be loaded to capacity
        // if we take account of weight of partially full racks or lines we will overload the warehouse
        // when all the racks and lines are full

        double weight = 0;

        foreach (Rack item in racks)
        {
            weight += item.RackCapacity;
        }

        return weight;
    }
}