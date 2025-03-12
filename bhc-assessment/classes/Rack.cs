class Rack(int rackNumber, double rackCapacity)
{

    private int rackNumber = rackNumber;

    private double rackCapacity = rackCapacity;

    public Pallet[] rackPallets = [];

    public Package[] rackPackages = [];

    public string orderOfOffloading = "newest";


    // ======= Methods ==========

    public string LoadAPallet(Pallet pallet) {

        double palletWeight = pallet.CalculatePalletWeight();
         bool doesLineHaveCapacity = (LineUtils.calculateTotalPalletsWeight(rackPallets) + palletWeight) <= rackCapacity;

        if(!doesLineHaveCapacity){
            return "Rack capacity is insufficient for this operation";
        }

        rackPallets = [..rackPallets, pallet];

        return "Pallet was loaded";
    }

    public string LoadAPackage(Package package) {

        double weightOfPackage = package.qualityMarker.ProductMass;
        double finalRackWeight = rackCapacity + weightOfPackage;

        if(rackCapacity < finalRackWeight){
            return "Rack capacity is insufficient for this operation";
        }

        rackPackages = [..rackPackages, package];

        return "Package was loaded";
    }


    public string OffloadAPackageBySerialNumber(string serialNumber){
        Package[] filteredPackages = [.. rackPackages.Where(p => p.SerialNumber != serialNumber)];
        rackPackages = filteredPackages;
        return "Packed offloaded";
    }

    public string OffloadAPalletBySerialNumber(string serialNumber){
        Pallet[] filteredPallets = [.. rackPallets.Where(p => p.SerialNumber != serialNumber)];
        rackPallets = filteredPallets;
        return "Pallet offloaded";
    }

    public string ToggleOffloadingOrder() {
        if(orderOfOffloading == "newest"){
            orderOfOffloading = "oldest";
        }else {
            orderOfOffloading = "newest";
        }
        
        return $"Offloading in ${orderOfOffloading} order";
    }

   public string OffloadAPackage(){

        Console.WriteLine($"Offloading in ${orderOfOffloading} order");

        if(orderOfOffloading == "newest"){
            Package[] newPackages = [.. rackPackages.Take(rackPackages.Length - 1)];
            rackPackages = newPackages;
        }else {
            Package[] newPackages = [.. rackPackages.Skip(1)];
            rackPackages = newPackages;
        }

        return "Package offloaded";

    }

    public string OffloadAPallet(){

        Console.WriteLine($"Offloading in ${orderOfOffloading} order");

        if(orderOfOffloading == "newest"){
            Pallet[] newPallets = [.. rackPallets.Take(rackPallets.Length - 1)];
            rackPallets = newPallets;
        }else {
            Pallet[] newPallets = [.. rackPallets.Skip(1)];
            rackPallets = newPallets;
        }

        return "Package offloaded";

    }


    // Properties


    public int RackNumber {
        get {
            return rackNumber;
        }

        set {
            rackNumber = value;
        }
    }

    public double RackCapacity {
        get {
            return rackCapacity;
        }

        set {
            rackCapacity = value;
        }
    }



}