
class Warehouse {

    private string name;
    private double maxCapacity; // in kgs
    
    private Line[] lines = [];

    private Rack[] racks = [];


    //========== Methods =============

    public string LoadALine(Line line){

        double warehouseWeightAfterLoading = WarehouseUtils.CalculateTotalLinesCurrentWeight(lines) + WarehouseUtils.CalculateTotalRackCurrentWeight(racks) + line.MaxLineCapacity;

        if(maxCapacity < warehouseWeightAfterLoading){
            return "Warehouse does not have capacity to load this line";
        }

        lines = [.. lines, line];

        return "Line was Loaded";
    }

    public string LoadARack(Rack rack){

        double warehouseWeightAfterLoading = WarehouseUtils.CalculateTotalLinesCurrentWeight(lines) + WarehouseUtils.CalculateTotalRackCurrentWeight(racks) + rack.RackCapacity;

        if(maxCapacity < warehouseWeightAfterLoading){
            return "Warehouse does not have capacity to load this rack";
        }

        racks = [.. racks, rack];

        return "Rack loaded";
    }

    public void GetRacksRecord(){
        Console.WriteLine($"This is a record of all Racks in {name} warehouse"); // records can be pulled from a db on a more complex solution
        foreach (Rack rack in racks)
        {
            Console.WriteLine($"{rack.RackNumber}");
        }
    }

     public void GetLinesRecord(){
        Console.WriteLine($"This is a record of all Lines in {name} warehouse");
        foreach (Line line in lines)
        {
            Console.WriteLine($"{line.LineNumber}");
        }
    }

    public void GetPackagesRecord(){
        // getting current packages stored in racks of the warehouse and lines
        // record ever placed can be managed by a db.

        Console.WriteLine($"This is a record of all Packages in {name} warehouse");

        foreach (Line line in lines)
        {
            Console.WriteLine($"{line.LineNumber} packages");
            for(int i = 0; i < line.linePackages.Length; i++){
                Console.WriteLine($"Serial Number: {line.linePackages[i].SerialNumber}");
            }

            Console.WriteLine($"{line.LineNumber} pallets");
            for(int i = 0; i < line.linePallets.Length; i++){
                Console.WriteLine($"Serial Number: {line.linePallets[i].SerialNumber}");
            }

            Console.WriteLine("=============================================");
        }

        foreach (Rack rack in racks)
        {
            Console.WriteLine($"{rack.RackNumber} packages");
            for(int i = 0; i < rack.rackPackages.Length; i++){
                Console.WriteLine($"Serial Number: {rack.rackPackages[i].SerialNumber}");
            }

            Console.WriteLine($"{rack.RackNumber} pallets");
            for(int i = 0; i < rack.rackPallets.Length; i++){
                Console.WriteLine($"Serial Number: {rack.rackPallets[i].SerialNumber}");
            }

            Console.WriteLine("=============================================");
        }
    }

    // Properties

    public string Name {
        get {
            return name;
        }
        set {
            name = value;
        }
    }

    public double MaxCapacity {
        get {
            return maxCapacity;
        }

        set {
            maxCapacity = value;
        }
    }
}