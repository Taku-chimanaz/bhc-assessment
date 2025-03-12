static class LineUtils {

     public static bool IsPackageValidForLine(Package package, QualityMaker lineQualityMaker){

        bool isMassEqual = package.qualityMarker.ProductMass == lineQualityMaker.ProductMass;
        bool isProductTypeEqual = package.qualityMarker.ProductType == lineQualityMaker.ProductType;
        bool isLoosePackage = package.typeOfPackage == PackageType.Carton;

        if(isMassEqual && isProductTypeEqual && isLoosePackage){
            return true;
        }else {
            return false;
        }
    }

    public static bool IsPalletValidForLine(Pallet pallet, QualityMaker lineQualityMaker){

        bool isMassEqual = pallet.palletQualityMaker.ProductMass == lineQualityMaker.ProductMass;
        bool isProductTypeEqual = pallet.palletQualityMaker.ProductType == lineQualityMaker.ProductType;

        if(isMassEqual && isProductTypeEqual){
            return true;
        }else {
            return false;
        }
    }

    public static double calculateTotalPalletsWeight(Pallet[] pallets){

        double totalWeight = 0;

        foreach (Pallet item in pallets)
        {
            totalWeight += item.CalculatePalletWeight();
        }

        return totalWeight;
    }

    
}