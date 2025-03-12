class Pallet(string serialNumber, int maxPackagesCapacity, QualityMaker palletQualityMaker, Package[] loosePackages)
{
    
    private string serialNumber = serialNumber;
    private int maxPackagesCapacity = maxPackagesCapacity;
    public Package[] loosePackages = Array.FindAll(loosePackages, (package) => PalletUtils.IsPackageValid(package, palletQualityMaker));

    public QualityMaker palletQualityMaker = palletQualityMaker;

    // Methods
    public string AddPackagesToPallet(Package[] packages){

        Package[] packagesWithValidQualityMaker = Array.FindAll(
            packages, (package) => PalletUtils.IsPackageValid(package, palletQualityMaker)
        );
        Package[] inValidPackages = Array.FindAll(
            packages, package => !packagesWithValidQualityMaker.Contains(package)
        );
        int totalPackagesAfterAddition = packagesWithValidQualityMaker.Length + loosePackages.Length;

        // checking to see if pallet has enough space for the packages
        if(maxPackagesCapacity < totalPackagesAfterAddition){   
            return "Pallet does not have enough capacity for this operation";
        }

        Package[] mergedPackages = loosePackages.Concat(packagesWithValidQualityMaker).ToArray();
        loosePackages = mergedPackages;
        
        return $"{inValidPackages.Length}  packages were not added to pallet";
        
    }

    public double CalculatePalletWeight(){

        double weight = 0;

        foreach (Package item in loosePackages)
        {
            weight += item.qualityMarker.ProductMass;
        }

        return weight;
    }

    public string RemovePackagesToPallet(Package[] packages){

        foreach (Package package in packages)
        {
           Package[] filteredPackages = loosePackages.Where(p => p.SerialNumber != package.SerialNumber).ToArray();
           loosePackages = filteredPackages;
        }

        return "Pallets removed";
    }

    public string ClearPalletPackages(){
        loosePackages = [];
        return "Packages cleared";
    }


    // Properties


    public string SerialNumber {
        get {
            return serialNumber;
        }

        set {
            serialNumber = value;
        }  
    }

    public int MaxPackagesCapacity {
        get {
            return maxPackagesCapacity;
        }

        set {
            maxPackagesCapacity = value;
        }
    }



    
}