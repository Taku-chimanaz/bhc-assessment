
class Warehouse(string name, double maxCapacity)
{

    private string name = name;
    private double maxCapacity = maxCapacity; // in kgs
    
    public Line[] lines = [];

    public Rack[] racks = [];


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
            Console.WriteLine($"{rack.RackSerialNumber}");
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
            Console.WriteLine($"{rack.RackSerialNumber} packages");
            for(int i = 0; i < rack.rackPackages.Length; i++){
                Console.WriteLine($"Serial Number: {rack.rackPackages[i].SerialNumber}");
            }

            Console.WriteLine($"{rack.RackSerialNumber} pallets");
            for(int i = 0; i < rack.rackPallets.Length; i++){
                Console.WriteLine($"Serial Number: {rack.rackPallets[i].SerialNumber}");
            }

            Console.WriteLine("=============================================");
        }
    }


    public string WarehouseSnapshoot() {

        string snapshop = @$"
            Name: {name}
            No of Racks: {racks.Length}
            No of Lines: {lines.Length}
            Total Lines Capacity: {WarehouseUtils.CalculateTotalLinesCurrentWeight(lines)}
            Total Racks Capacity: {WarehouseUtils.CalculateTotalRackCurrentWeight(racks)}
        ";

        return snapshop;
    }

    public string SearchForRackBySerialNumber(string serialNumber){

        bool isRackAvailable = false;
        Rack? foundRack = null;

        foreach (Rack rack in racks)
        {
            if(rack.RackSerialNumber == serialNumber){
                isRackAvailable = true;
                foundRack = rack;
                break;
            }
        }

        if(isRackAvailable){
            return $"Rack found in {name} warehouse.\n{foundRack?.rackPackages.Length} packages\n{foundRack?.rackPallets.Length} pallets";
        }else {
            return $"Rack not found";
        }
    }

    public string SearchForPackageBySerialNumber(string serialNumber){

        bool isPackageAvailable = false;
        string? location = null;

        foreach (Line line in lines)
        {

            if(isPackageAvailable){
                break;
            }

            foreach (Package package in line.linePackages)
            {
                if(package.SerialNumber == serialNumber){
                    isPackageAvailable = true;
                    location = $"Line - {line.LineNumber}";
                    break;
                }
            }

        }

        // if not found in lines look in racks

        if(!isPackageAvailable){

            foreach (Rack rack in racks)
            {   

                if(isPackageAvailable){
                    break;
                }

                foreach (Package package in rack.rackPackages)
                {
                    if(package.SerialNumber == serialNumber){
                        isPackageAvailable = true;
                        location = $"Rack - {rack.RackSerialNumber}";
                        break;
                    }
                }
            }
        }


        if(isPackageAvailable){
            return $"Package found in warehouse {name}.Found in {location}";
        }else {
            return $"Package not found";
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